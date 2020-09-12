using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using OfficeOpenXml;
using System.Data.OleDb;

namespace Bank.Masters
{
    public partial class StaffTransaction : Form
    {
        string EditId = string.Empty;
        List<string> paths = new List<string>();
        DataTable backup = new DataTable();
        public StaffTransaction()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
            BindDropdown();
        }

        private void BindDropdown()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("ShipmentDropDownStaff", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            con.Close();

            DataRow row = (ds.Tables[0]).NewRow();
            row["VehicleNo"] = "-Select-";
            ds.Tables[0].Rows.InsertAt(row, 0);
            DdlVehicle.DataSource = new DataView(ds.Tables[0]);
            DdlVehicle.DisplayMember = "VehicleNo";
            DdlVehicle.ValueMember = "VehicleID";
            DdlVehicle.SelectedIndex = 0;

            row = (ds.Tables[2]).NewRow();
            row["AccountNo"] = "-Select-";
            ds.Tables[2].Rows.InsertAt(row, 0);
            DdlAccount.DataSource = new DataView(ds.Tables[2]);
            DdlAccount.DisplayMember = "AccountNo";
            DdlAccount.ValueMember = "AccountId";
            DdlAccount.SelectedIndex = 0;

             row = (ds.Tables[1]).NewRow();
             row["Name"] = "-Select-";
            ds.Tables[1].Rows.InsertAt(row, 0);
            DdlStaff.DataSource = new DataView(ds.Tables[1]);
            DdlStaff.DisplayMember = "Name";
            DdlStaff.ValueMember = "BeneficiaryId";
            DdlStaff.SelectedIndex = 0;

           
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxStaffTransactionID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtStaffTransactionId.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            decimal a = 0M;
            if (DdlStaff.SelectedIndex < 1)
            {
                MessageBox.Show("Please select  Staff Name");
                DdlStaff.Focus();
                return;
            }
            else if (DtDateFrom.Value.Date > DtDateTo.Value.Date)
            {
                MessageBox.Show("Please From date less tahn To date");
                DdlStaff.Focus();
                return;
            }
            else if (DdlAccount.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Payment account");
                DdlAccount.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtChequeAmount.Text) && string.IsNullOrEmpty(TxtCash.Text))
            {
                MessageBox.Show("Please enter Cheque Amount or Cash");
                TxtChequeNo.Focus();
                return;
            }
            else if (!string.IsNullOrEmpty(TxtChequeAmount.Text) && decimal.TryParse(TxtChequeAmount.Text,out a))
            {
                if (string.IsNullOrEmpty(TxtChequeNo.Text))
                {
                    MessageBox.Show("Please enter Cheque nO");
                    TxtChequeNo.Focus();
                    return;
                }
            }else if (!string.IsNullOrEmpty(TxtChequeAmount.Text) && !decimal.TryParse(TxtChequeAmount.Text,out a)){
                MessageBox.Show("Please enter Correct Cheque Amount");
                TxtChequeAmount.Focus();
                return;
            }
            else if (!string.IsNullOrEmpty(TxtCash.Text) && !decimal.TryParse(TxtCash.Text, out a))
            {
                MessageBox.Show("Please enter Correct Cash Amount");
                TxtCash.Focus();
                return;
            }
                else if (string.IsNullOrEmpty(TxtBank.Text))
                {
                    MessageBox.Show("Please enter Bank name");
                    TxtBank.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(TxtBranch.Text))
                {
                    MessageBox.Show("Please enter Account Nick Name ");
                    TxtBranch.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("Please enter City ");
                    txtCity.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtIFSC.Text))
                {
                    MessageBox.Show("Please enter City ");
                    txtIFSC.Focus();
                    return;
                }
                else if (DdlVehicle.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select Category");
                    txtIFSC.Focus();
                    return;
                }
               

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertStaffAccountTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AcHolderName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@RefNo", TxtRefNo.Text);
                cmd.Parameters.AddWithValue("@DtFrom", DtDateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@DtTo", DtDateTo.Value.Date);
                cmd.Parameters.AddWithValue("@BankName", TxtBank.Text);
                cmd.Parameters.AddWithValue("@ACNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text);
                cmd.Parameters.AddWithValue("@Payment", TxtPayment.Text);

                cmd.Parameters.AddWithValue("@PaidAcNo", DdlAccount.SelectedValue);
                cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
                cmd.Parameters.AddWithValue("@ChequeAmt", TxtChequeAmount.Text);
                cmd.Parameters.AddWithValue("@Cash", TxtCash.Text);
                cmd.Parameters.AddWithValue("@PaidDate", DtPaidDate.Value.Date);
                cmd.Parameters.AddWithValue("@Depositer", TxtDepositer.Text);
                cmd.Parameters.AddWithValue("@UTRNo", TxtUTRNo.Text);
                cmd.Parameters.AddWithValue("@StaffId", DdlStaff.SelectedValue);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Transaction saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Transaction already present for these days");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateStaffAccountTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StaffTransactionId", TxtStaffTransactionId.Text);
                cmd.Parameters.AddWithValue("@AcHolderName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@RefNo", TxtRefNo.Text);
                cmd.Parameters.AddWithValue("@DtFrom", DtDateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@DtTo", DtDateTo.Value.Date);
                cmd.Parameters.AddWithValue("@BankName", TxtBank.Text);
                cmd.Parameters.AddWithValue("@ACNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text);
                cmd.Parameters.AddWithValue("@Payment", TxtPayment.Text);

                cmd.Parameters.AddWithValue("@PaidAcNo", DdlAccount.SelectedValue);
                cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
                cmd.Parameters.AddWithValue("@ChequeAmt", TxtChequeAmount.Text);
                cmd.Parameters.AddWithValue("@Cash", TxtCash.Text);
                cmd.Parameters.AddWithValue("@PaidDate", DtPaidDate.Value.Date);
                cmd.Parameters.AddWithValue("@Depositer", TxtDepositer.Text);
                cmd.Parameters.AddWithValue("@UTRNo", TxtUTRNo.Text);
                cmd.Parameters.AddWithValue("@StaffId", DdlStaff.SelectedValue);
               
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Transaction Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Transaction already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetStaffAccountTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            GvDestination.DataSource = dataTable;
            backup = dataTable;
            this.GvDestination.AllowUserToAddRows = false;
            con.Close();
        }

        private void clear()
        {
            TxtStaffTransactionId.Text = string.Empty;
            DdlStaff.SelectedIndex = 0;
            DdlVehicle.SelectedIndex = 0;

            TxtAccountHolderName.Text = string.Empty;
            TxtAccountNo.Text = string.Empty;
            TxtBranch.Text = string.Empty;
            TxtBank.Text = string.Empty;
            txtIFSC.Text = string.Empty;
            txtCity.Text =string.Empty;

            DtDateTo.Value = DateTime.Now;
            DtDateFrom.Value = DateTime.Now;
            TxtRefNo.Text = string.Empty;

            DdlAccount.SelectedIndex = 0;
            //TxtAccountName.Text = Convert.e"]);
            //TxtAccountNoPaid.Text = Conver
            DtPaidDate.Value = DateTime.Now;
            //TxtBankPaid.Text = Convert.ToS
            TxtChequeNo.Text = string.Empty;
            TxtChequeAmount.Text = string.Empty;
            TxtPayment.Text = string.Empty;
            TxtCash.Text = string.Empty;
            TxtDepositor.Text =string.Empty;
            TxtUTRNo.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetStaffAccountTransactionOnID", con);
                cmd.Parameters.AddWithValue("@StaffTransactionId", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                con.Close();

                if (dataTable.Rows.Count > 0)
                {
                    TxtStaffTransactionId.Text = Convert.ToString(dataTable.Rows[0]["StaffTransactionId"]);
                    DdlStaff.SelectedValue = Convert.ToString(dataTable.Rows[0]["StaffId"]);
                    DdlVehicle.SelectedValue = Convert.ToString(dataTable.Rows[0]["VehicleID"]);

                    TxtAccountHolderName.Text = Convert.ToString(dataTable.Rows[0]["AcHolderName"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["ACNo"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["BankName"]);
                    txtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    txtCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);

                    DtDateTo.Value = Convert.ToDateTime(dataTable.Rows[0]["DtTo"]);
                    DtDateFrom.Value = Convert.ToDateTime(dataTable.Rows[0]["DtFrom"]);
                    TxtRefNo.Text = Convert.ToString(dataTable.Rows[0]["RefNo"]);

                    DdlAccount.SelectedValue = Convert.ToString(dataTable.Rows[0]["PaidAcNo"]);
                    //TxtAccountName.Text = Convert.ToString(dataTable.Rows[0]["AccountHolderName"]);
                    //TxtAccountNoPaid.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    DtPaidDate.Value = Convert.ToDateTime(dataTable.Rows[0]["PaidDate"]);
                    //TxtBankPaid.Text = Convert.ToString(dataTable.Rows[0]["Documents"]);
                    TxtChequeNo.Text = Convert.ToString(dataTable.Rows[0]["ChequeNo"]);
                    TxtChequeAmount.Text = Convert.ToString(dataTable.Rows[0]["ChequeAmt"]);
                    TxtPayment.Text = Convert.ToString(dataTable.Rows[0]["Payment"]);
                    TxtCash.Text = Convert.ToString(dataTable.Rows[0]["Cash"]);
                    TxtDepositor.Text = Convert.ToString(dataTable.Rows[0]["Depositer"]);
                    TxtUTRNo.Text = Convert.ToString(dataTable.Rows[0]["UTRNo"]);
                }
            }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvDestination.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            clear();
            IncrementDestination();
            EditId = string.Empty;
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtDestinationSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBankSearch.Text))
            {
                GvDestination.DataSource = backup.Select("[Name] Like '%" + TxtBankSearch.Text + "%'").Any() ? backup.Select("[Name] Like '%" + TxtBankSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void DdlStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlStaff.SelectedIndex>0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankStaffAccountOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", DdlStaff.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtAccountHolderName.Text = Convert.ToString(dataTable.Rows[0]["BeneficiaryName"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    DdlAccountType.Text = Convert.ToString(dataTable.Rows[0]["AccountType"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    txtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    txtCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);
                    DdlVehicle.SelectedValue = Convert.ToString(dataTable.Rows[0]["VehicleID"]);
                }
                con.Close();
            }
        }

        private void DdlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAccount.SelectedIndex>0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetAccountOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", DdlAccount.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtAccountName.Text = Convert.ToString(dataTable.Rows[0]["AccountHolderName"]);
                    TxtAccountNoPaid.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    TxtBankPaid.Text = Convert.ToString(dataTable.Rows[0]["BankName"]);
                }
                con.Close();
            }
        }

        private void TxtCash_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0M;
            TxtCash.Text = TxtCash.Text.Trim();
            TxtChequeAmount.Text = TxtChequeAmount.Text.Trim();
            decimal total = 0M;

            if (!string.IsNullOrEmpty(TxtCash.Text) && decimal.TryParse(TxtCash.Text, out a))
            {
                total = Convert.ToDecimal(TxtCash.Text);
            }

            if (!string.IsNullOrEmpty(TxtChequeAmount.Text) && decimal.TryParse(TxtChequeAmount.Text, out a))
            {
                total += Convert.ToDecimal(TxtChequeAmount.Text);
            }

            TxtPayment.Text = Convert.ToString(total);
        }

        private void TxtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0M;
            TxtCash.Text = TxtCash.Text.Trim();
            TxtChequeAmount.Text = TxtChequeAmount.Text.Trim();
            decimal total = 0M;

            if (!string.IsNullOrEmpty(TxtChequeAmount.Text) && decimal.TryParse(TxtChequeAmount.Text, out a))
            {
                    total = Convert.ToDecimal(TxtChequeAmount.Text);
            }

            if (!string.IsNullOrEmpty(TxtCash.Text) && decimal.TryParse(TxtCash.Text, out a))
            {
                total += Convert.ToDecimal(TxtCash.Text);
            }

                    TxtPayment.Text =Convert.ToString(total);
        }


        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string filename = "D:\\Bank\\StaffTransaction\\StaffTransaction_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
            System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

            System.IO.Directory.CreateDirectory("D:\\Bank\\StaffTransaction\\");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("StaffTransaction");
                sheet.Cells["A1"].Value = "StaffTransactionID";
                sheet.Cells["B1"].Value = "StaffName";
                sheet.Cells["C1"].Value = "Vehicle No";
                sheet.Cells["D1"].Value = "DateFrom";
                sheet.Cells["E1"].Value = "DateTo";
                sheet.Cells["F1"].Value = "RefNo";

                sheet.Cells["G1"].Value = "Account";
                sheet.Cells["H1"].Value = "ChequeNo";
                sheet.Cells["I1"].Value = "ChequeAmount";
                sheet.Cells["J1"].Value = "Cash";
                sheet.Cells["K1"].Value = "Payment";
                sheet.Cells["L1"].Value = "PaidDate";
                sheet.Cells["M1"].Value = "Depositer";
                sheet.Cells["N1"].Value = "UTRNo";

                sheet.Cells["A1:N1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:N1"].Style.Font.Size = 12;

                sheet.Cells["A1:N1"].Style.Font.Bold = true;
                sheet.Cells["A1:N1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:N1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);

                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankStaffAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);


                var sheetStaff = xls.Workbook.Worksheets.Add("Staff");
                for (int dr = 1; dr <= ds.Tables[0].Rows.Count; dr++)
                {
                    sheetStaff.Cells["A" + dr].Value = ds.Tables[0].Rows[dr - 1]["BeneficiaryId"];
                    sheetStaff.Cells["B" + dr].Value = ds.Tables[0].Rows[dr - 1]["Name"];
                }

                con = new SqlConnection(Connection.InvAdminConn());
                cmd = new SqlCommand("ShipmentDropDown", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);


                var sheetVehicle = xls.Workbook.Worksheets.Add("Vehicles");
                for (int dr = 1; dr <= ds.Tables[0].Rows.Count; dr++)
                {
                    sheetVehicle.Cells["A" + dr].Value = ds.Tables[0].Rows[dr - 1]["VehicleNo"];
                }

                con = new SqlConnection(Connection.InvAdminConn());
                cmd = new SqlCommand("GetAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                DdlAccount.DataSource = new DataView(dataTable);
                DdlAccount.DisplayMember = "AccountNo";
                DdlAccount.ValueMember = "AccountId";
                DdlAccount.SelectedIndex = 0;
                con.Close();

                var AccountHolderName = xls.Workbook.Worksheets.Add("AccountNo");
                for (int dr = 1; dr <= dataTable.Rows.Count; dr++)
                {
                    AccountHolderName.Cells["A" + dr].Value = dataTable.Rows[dr - 1]["AccountNo"];
                }

                xls.Save();

                DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename + ".xlsx");
                }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            TxtUploadfile.Text = op.FileName;
        }

        public static DataTable ConvertExcelToDataTable(string FileName)
        {
            string sSheetName = null;
            string sConnection = null;
            DataTable dtTablesList = default(DataTable);
            OleDbCommand oleExcelCommand = default(OleDbCommand);
            OleDbDataReader oleExcelReader = default(OleDbDataReader);
            OleDbConnection oleExcelConnection = default(OleDbConnection);
            sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            oleExcelConnection = new OleDbConnection(sConnection);
            oleExcelConnection.Open();
            dtTablesList = oleExcelConnection.GetSchema("Tables");
            if (dtTablesList.Rows.Count > 0)
            {
                sSheetName = "StaffTransaction$";
            }
            dtTablesList.Clear();
            dtTablesList.Dispose();
            if (!string.IsNullOrEmpty(sSheetName))
            {
                oleExcelCommand = oleExcelConnection.CreateCommand();
                oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                oleExcelCommand.CommandType = CommandType.Text;
                oleExcelReader = oleExcelCommand.ExecuteReader();
                dtTablesList = new DataTable();
                dtTablesList.Load(oleExcelReader);
                oleExcelReader.Close();
            }
            oleExcelConnection.Close();

            return dtTablesList;
        }

        private string clearExcelUploadSuccess(string correct)
        {
            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(TxtUploadfile.Text)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                string[] corrects = correct.Substring(1).Split(',');
                for (int row = 0; row < corrects.Count(); row++)
                {
                    worksheet.DeleteRow(Convert.ToInt32(corrects[row]) - row);
                }
                string filename = "D:\\Bank\\StaffTransaction\\Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
                System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

                if (excel.Exists)
                {
                    excel.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Bank\\StaffTransaction\\Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx")))
                {
                    pac.Workbook.Worksheets.Add(("ShipmentDetails"), worksheet);
                    pac.Save();
                }
            }
            return ("D:\\Bank\\StaffTransaction\\Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx");
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUploadfile.Text))
            {
                DataTable dt = ConvertExcelToDataTable(TxtUploadfile.Text);

                //foreach (DataRow dr in dt.Rows)
                //{
                //    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                //    SqlCommand cmd = new SqlCommand("InsertOwnVehicle", con);
                //    cmd.Parameters.AddWithValue("@VehicleNo", dr["Vehicle No"]);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    con.Open();   
                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //}

                string error = string.Empty;
                string correct = string.Empty;

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    int errorBit = 0;
                    int deca;
                    DateTime DateTime;
                    decimal decima=0M;

                    try
                    {
                        if (((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["StaffTransactionID"]))) && (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["StaffTransactionID"])))) && (!int.TryParse(Convert.ToString(dt.Rows[row]["StaffTransactionID"]), out deca)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct StaffTransactionID" + Environment.NewLine;
                        }

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["DateFrom"]), out DateTime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct DateFrom" + Environment.NewLine;
                        }

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["DateTo"]), out DateTime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct DateTo" + Environment.NewLine;
                        }

                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["PaidDate"]), out DateTime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct PaidDate" + Environment.NewLine;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["ChequeNo"])))
                        {
                            if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["ChequeAmount"])))
                            {
                                if (errorBit == 0)
                                {
                                    error += "Line No " + (row + 2) + Environment.NewLine;
                                    errorBit = 1;
                                }
                                error += "    Please enter Cheque Amount" + Environment.NewLine;
                            }
                        }

                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["ChequeNo"])) && (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Cash"]))) && (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Cash"]), out decima)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Cash" + Environment.NewLine;
                        }

                        if ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Payment"]))) && (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Payment"]), out decima)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Payment" + Environment.NewLine;
                        }

                        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        SqlCommand cmd = new SqlCommand("GetVehicleOnName", con);
                        cmd.Parameters.AddWithValue("@VehicleNo", dt.Rows[row]["Vehicle No"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Vehicle in Vehicle Master" + Environment.NewLine;
                        }
                        con.Close();

                        if (string.IsNullOrEmpty(Convert.ToString(  dt.Rows[row]["Cash"])))
                        {
                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("GetAccountNoonName", con);
                            cmd.Parameters.AddWithValue("@accountno", dt.Rows[row]["Account"]);
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                            {
                                if (errorBit == 0)
                                {
                                    error += "Line No " + (row + 2) + Environment.NewLine;
                                    errorBit = 1;
                                }
                                error += "    Please check Account No in Account Master" + Environment.NewLine;

                            }
                            con.Close();
                        }

                        if (errorBit == 0)
                        {
                            TxtStaffTransactionId.Text = Convert.ToString(dt.Rows[row]["StaffTransactionID"]);
                            DdlStaff.SelectedValue = Convert.ToString(dt.Rows[row]["StaffTransactionID"]);
                            DdlVehicle.Text = Convert.ToString(dt.Rows[row]["Vehicle No"]);

                            DtDateTo.Value = Convert.ToDateTime(dt.Rows[row]["DateTo"]);
                            DtDateFrom.Value = Convert.ToDateTime(dt.Rows[row]["DateFrom"]);
                            TxtRefNo.Text = Convert.ToString(dt.Rows[row]["RefNo"]);

                            DdlAccount.Text = Convert.ToString(dt.Rows[row]["Account"]);
                            DtPaidDate.Value = Convert.ToDateTime(dt.Rows[row]["PaidDate"]);
                            TxtChequeNo.Text = Convert.ToString(dt.Rows[row]["ChequeNo"]);
                            TxtChequeAmount.Text = Convert.ToString(dt.Rows[row]["ChequeAmount"]);
                            TxtPayment.Text = Convert.ToString(dt.Rows[row]["Payment"]);
                            TxtCash.Text = Convert.ToString(dt.Rows[row]["Cash"]);
                            TxtDepositor.Text = Convert.ToString(dt.Rows[row]["Depositer"]);
                            TxtUTRNo.Text = Convert.ToString(dt.Rows[row]["UTRNo"]);

                            con = new SqlConnection(Connection.InvAdminConn());
                            cmd = new SqlCommand("InsertStaffAccountTransaction", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@AcHolderName", TxtAccountHolderName.Text);
                            cmd.Parameters.AddWithValue("@RefNo", TxtRefNo.Text);
                            cmd.Parameters.AddWithValue("@DtFrom", DtDateFrom.Value.Date);
                            cmd.Parameters.AddWithValue("@DtTo", DtDateTo.Value.Date);
                            cmd.Parameters.AddWithValue("@BankName", TxtBank.Text);
                            cmd.Parameters.AddWithValue("@ACNo", TxtAccountNo.Text);
                            cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                            cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text);
                            cmd.Parameters.AddWithValue("@Payment", TxtPayment.Text);

                            cmd.Parameters.AddWithValue("@PaidAcNo", DdlAccount.SelectedValue);
                            cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
                            cmd.Parameters.AddWithValue("@ChequeAmt", TxtChequeAmount.Text);
                            cmd.Parameters.AddWithValue("@Cash", TxtCash.Text);
                            cmd.Parameters.AddWithValue("@PaidDate", DtPaidDate.Value.Date);
                            cmd.Parameters.AddWithValue("@Depositer", TxtDepositer.Text);
                            cmd.Parameters.AddWithValue("@UTRNo", TxtUTRNo.Text);
                            cmd.Parameters.AddWithValue("@StaffId", DdlStaff.SelectedValue);

                            con.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                correct += "," + (row + 2);
                            }
                            con.Close();
                            clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        error += "Line No" + (row + 2) + Environment.NewLine;
                        error += ex.Message;
                        continue;
                    }
                }
                if (error.Length > 0 && correct.Length > 0)
                {
                    MessageBox.Show("Lines at " + correct.Substring(1) + " uploaded succesfully." + Environment.NewLine + " Error at " + error + Environment.NewLine + "Please correct and upload error data at " + clearExcelUploadSuccess(correct));
                    error = string.Empty;
                    correct = string.Empty;
                }
                else if (error.Length > 0)
                {
                    MessageBox.Show(error + Environment.NewLine + "Please correct and upload error data at " + TxtUploadfile.Text);
                    error = string.Empty;
                    correct = string.Empty;
                }
                else
                {
                    MessageBox.Show("Transaction details saved succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                }
                BindGrid();
            }
        }
    }
}
