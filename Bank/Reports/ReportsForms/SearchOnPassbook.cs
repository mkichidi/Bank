using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;

namespace Bank.Reports.ReportForms
{
    public partial class SearchOnPassbook : Form
    {
        public SearchOnPassbook()
        {
            InitializeComponent();
            BindDropdowns();
        }

        public DataTable BindGrid()
        {
            SqlDataReader reader;
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("BankSearchonPassbook", con);

            cmd.Parameters.AddWithValue("@From", DtFrom.Value.Date.Date);
            cmd.Parameters.AddWithValue("@to", dtTo.Value.Date.Date);
            cmd.Parameters.AddWithValue("@Account", DdlAccount.Text.Replace(", ", ","));
            cmd.Parameters.AddWithValue("@Bank", CmbBank.Text.Replace(", ", ","));
            cmd.Parameters.AddWithValue("@AccountHolder", DdlAccountHolder.Text.Replace(", ", ","));
            cmd.Parameters.AddWithValue("@Group", DdlGroup.Text.Replace(", ", ","));
            cmd.Parameters.AddWithValue("@NickName", TxtNickName.Text);


            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            con.Close();
            dataTable.DefaultView.Sort = "DummyDate ASC";
            return dataTable.DefaultView.ToTable();
        }

        public void BindDropdowns()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetBank", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dataTable = new DataTable();
            dataTable = ds.Tables[0].Select("", "[BankName] ASC").CopyToDataTable();

            CmbBank.Properties.DataSource = dataTable;
            CmbBank.Properties.DisplayMember = "BankName";
            CmbBank.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            CmbBank.Properties.IncrementalSearch = true;
            CmbBank.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            dataTable = new DataTable();
            reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            dataTable = dataTable.Select("", "[AccountNo] ASC").CopyToDataTable(); ;

       
            DdlAccount.Properties.DataSource = dataTable;
            DdlAccount.Properties.DisplayMember = "AccountNo";
            DdlAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlAccount.Properties.IncrementalSearch = true;
            DdlAccount.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            //CmbProduct.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[2].Rows)
            //{
            //    CmbProduct.Items.Add(dr["Product Name"]);
            //}

            //DdlCustomer.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[3].Rows)
            //{
            //    DdlCustomer.Items.Add(dr["Party Name"]);
            //}

            //DdlVehicle.Items.Add("-ALL-");
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    DdlVehicle.Items.Add(dr["VehicleNo"]);
            //}

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetAccountHolderName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dataTable = new DataTable();
            reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            dataTable = dataTable.Select("", "[AccountHolderName] ASC").CopyToDataTable(); ;


            DdlAccountHolder.Properties.DataSource = dataTable;
            DdlAccountHolder.Properties.DisplayMember = "AccountHolderName";
            DdlAccountHolder.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlAccountHolder.Properties.IncrementalSearch = true;
            DdlAccountHolder.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetBankGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dataTable = new DataTable();
            reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            dataTable = dataTable.Select("", "[BankGroupName] ASC").CopyToDataTable(); ;

            DdlGroup.Properties.DataSource = dataTable;
            DdlGroup.Properties.DisplayMember = "BankGroupName";
            DdlGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            DdlGroup.Properties.IncrementalSearch = true;
            DdlGroup.KeyDown += new KeyEventHandler(checkedComboBoxEdit1_KeyDown);
        }

        void checkedComboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).IsPopupOpen)
                ((DevExpress.XtraEditors.CheckedComboBoxEdit)sender).ShowPopup();
        }

        private void TSxtSearch_Click(object sender, EventArgs e)
        {
            ReportParameter[] parms = new ReportParameter[1];
            if (ChkDetails.Checked)
            {
                parms[0] = new ReportParameter("Details", "False");
            }
            else 
            {
               parms[0] = new ReportParameter("Details", "True");
            }

            this.reportViewer1.LocalReport.SetParameters(parms);

            ReportDataSource rds = new ReportDataSource("SearchOn", BindGrid());
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void TxtShipmentSearch_TextChanged(object sender, EventArgs e)
        {
            //ReportDataSource rds = new ReportDataSource("BillonDate", BindGridOnSearch());
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = reportViewer1.LocalReport.Render(
               "EXCELOPENXML", null, out mimeType, out encoding, out extension,
               out streamids, out warnings);

            FileStream fs = new FileStream(@"d:\output.xlsx", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"d:\output.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[1];
                System.IO.Directory.CreateDirectory("D:\\Bank\\Reports\\");

                string filename = DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + " (" + DateTime.Now.ToString("h.mm.ss") + ")";

                System.IO.FileInfo excels = new System.IO.FileInfo(@"D:\\BankBank\\Reports\\" + filename + ".xlsx");
                if (excels.Exists)
                {
                    excels.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Bank\\Reports\\" + filename + ".xlsx")))
                {
                    var worksheetCheck = pac.Workbook.Worksheets[Convert.ToString("SearchOnAll")];

                    if (worksheetCheck == null)
                    {

                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                        pac.Save();
                    }
                    else
                    {
                        pac.Workbook.Worksheets.Delete(worksheetCheck);
                        pac.Workbook.Worksheets.Add((Convert.ToString("SearchOnAll")), worksheet);
                    }
                    DialogResult ans = MessageBox.Show("File Downloaded at " + "D:\\Bank\\Reports\\" + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("D:\\Bank\\Reports\\" + filename + ".xlsx");
                    }
                }
            }
            System.IO.FileInfo excel = new System.IO.FileInfo(@"d:\output.xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
        }

        private void JswBill_Load(object sender, EventArgs e)
        {

        }

        private void DdlDestination_EditValueChanged(object sender, EventArgs e)
        {
            DdlAccount.ToolTip = DdlAccount.Text;
        }

        private void CmbProduct_EditValueChanged(object sender, EventArgs e)
        {
            CmbBank.ToolTip = CmbBank.Text;
        }

        private void DdlCustomer_EditValueChanged(object sender, EventArgs e)
        {
            DdlAccountHolder.ToolTip = DdlAccountHolder.Text;
        }

        private void DdlVehicle_EditValueChanged(object sender, EventArgs e)
        {
            DdlGroup.ToolTip = DdlGroup.Text;
        }

        private void SearchOn_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

    }
}
