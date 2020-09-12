using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace Bank
{
    public partial class RTGSForm : Form
    {
        public RTGSForm()
        {
            InitializeComponent();
            BindDropdowns();
        }

        DataTable backupBenificiary = new DataTable();
        DataTable backupAccount = new DataTable();

        public void BindDropdowns()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            DataRow row = dataTable.NewRow();
            backupAccount = dataTable;
            row["AccountNo"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlApplicant.DataSource = new DataView(dataTable);
            DdlApplicant.DisplayMember = "AccountNo";
            DdlApplicant.ValueMember = "AccountId";
            DdlApplicant.SelectedIndex = 0;
            con.Close();

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetBankBeneficiaryData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            backupBenificiary = dataTable;
            row = dataTable.NewRow();
            row["BeneficiaryName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlBeneficiary.DataSource = new DataView(dataTable);
            DdlBeneficiary.DisplayMember = "BeneficiaryName";
            DdlBeneficiary.ValueMember = "BeneficiaryId";
            DdlBeneficiary.SelectedIndex = 0;
            con.Close();

            con = new SqlConnection(Connection.InvAdminConn());
            cmd = new SqlCommand("GetBankGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            reader = cmd.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            row = dataTable.NewRow();
            row["BankGroupName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlGroup.DataSource = new DataView(dataTable);
            DdlGroup.DisplayMember = "BankGroupName";
            DdlGroup.ValueMember = "BankGroupId";
            DdlGroup.SelectedIndex = 0;
            con.Close();
        }

        private void DdlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlApplicant.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetAccountOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", DdlApplicant.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtAccountHolderName.Text = Convert.ToString(dataTable.Rows[0]["AccountHolderName"]);
                    TxtApplicantBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                }
                con.Close();
            }
        }

        private void DdlBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlBeneficiary.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankBeneficiaryDataOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", DdlBeneficiary.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtBeneficiary.Text = Convert.ToString(dataTable.Rows[0]["BeneficiaryName"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    TxtAccountType.Text = Convert.ToString(dataTable.Rows[0]["AccountType"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    txtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    txtCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);
                    TxtMobileNo.Text = Convert.ToString(dataTable.Rows[0]["MobileNo"]);
                }
                con.Close();
            }
        }

        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            decimal amount = 0M;
            decimal commision = 0M;
            if (DdlApplicant.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Applicant");
                DdlApplicant.Focus();
                return;
            }
            else if (DdlBeneficiary.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Beneficiary");
                DdlBeneficiary.Focus();
                return;
            } 
            else if (string.IsNullOrEmpty(TxtChequeno.Text))
            {
                MessageBox.Show("Please enter Cheque no");
                TxtChequeno.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtAmount.Text))
            {
                MessageBox.Show("Please enter Amount");
                TxtAmount.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtAmount.Text,out amount))
            {
                MessageBox.Show("Please enter correct Amount");
                TxtAmount.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtCommision.Text))
            {
                MessageBox.Show("Please enter Commision");
                TxtAmount.Focus();
                return;
            }
            else if (!decimal.TryParse(TxtCommision.Text, out commision))
            {
                MessageBox.Show("Please enter correct Commision");
                TxtCommision.Focus();
                return;
            }

            TxtAmount.Text = Convert.ToString(amount - commision);

            string filename = "D:\\Bank\\RTGSForms\\";

            if (DdlGroup.SelectedIndex > 0)
            {
                filename += DdlGroup.Text + "\\";
            }

            System.IO.Directory.CreateDirectory(filename);
            filename += TxtBeneficiary.Text + "_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".doc";

            System.IO.File.Copy(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "TGMC.doc"), filename,true);

         if (TxtApplicantBank.Text.ToUpper().Contains("TGMC"))
         {
             object fileName = System.IO.Path.Combine(filename);
             Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
             Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(fileName, ReadOnly: false, Visible: true);
             aDoc.Activate();
             FindAndReplace(wordApp, "@@BeneficiaryAccount", TxtAccountNo.Text);
             FindAndReplace(wordApp, "@@BeneficiaryMobile", TxtMobileNo.Text);
             FindAndReplace(wordApp, "@@Beneficiary", TxtBeneficiary.Text);
             FindAndReplace(wordApp, "@@Bank", TxtBank.Text);
             FindAndReplace(wordApp, "@@Branch", TxtBranch.Text);
             FindAndReplace(wordApp, "@@City", txtCity.Text);
             FindAndReplace(wordApp, "@@IFSC", txtIFSC.Text);

             FindAndReplace(wordApp, "@@Account", DdlApplicant.Text);
             FindAndReplace(wordApp, "@@ChequeNo", TxtChequeno.Text);
             FindAndReplace(wordApp, "@@ChequeDate", TxtChequeDate.Value.ToString("dd-MM-yyyy"));
             FindAndReplace(wordApp, "@@Applicant", TxtAccountHolderName.Text);
             FindAndReplace(wordApp, "@@MobileNo", TxtApplicantMobileNo.Text);
             FindAndReplace(wordApp, "@@Type", TxtAccountType.Text);

             FindAndReplace(wordApp, "@@Amount", String.Format(new CultureInfo("en-IN", false), "{0:n0}", Convert.ToDouble(Convert.ToInt32(TxtAmount.Text))) + "/-");
             FindAndReplace(wordApp, "@@TotalAmount", String.Format(new CultureInfo("en-IN", false), "{0:n0}", Convert.ToDouble(Convert.ToInt32(TxtAmount.Text) + Convert.ToInt32(TxtCommision.Text))) + "/-");
             FindAndReplace(wordApp, "@@Commission", TxtCommision.Text + "/-");
             FindAndReplace(wordApp, "@@InWords ", JswDatatable.ConvertNumbertoWords(Convert.ToInt32(TxtAmount.Text) + Convert.ToInt32(TxtCommision.Text)));

         }
         DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         if (ans == DialogResult.Yes)
         {
             System.Diagnostics.Process.Start(filename);
         }
        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
           decimal a=0M;
            if (decimal.TryParse(TxtAmount.Text,out a))
            {
                if(a <= 10001){
                        TxtCommision.Text = upto10000;
                    return;
                }
                if((10001<= a) && (a <= 100000)){
                        TxtCommision.Text = tenThousndtolakh;
                    return;
                }

                if((100001 <= a)&& (a<= 200000)){
                        TxtCommision.Text = lakhto2Lakh;
                    return;
                }

                if((200001 <= a)&&(a <= 500000)){
                        TxtCommision.Text = twolakhto5Lakh;
                    return;
                }

                if(a >= 500001){
                        TxtCommision.Text = fivelakhabove;
                    return;
                }
            }
        }

        private string upto10000 = "3";
        private string tenThousndtolakh= "6";
        private string lakhto2Lakh = "18";
        private string twolakhto5Lakh = "30";
        private string fivelakhabove = "59";

        private void DdlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DdlGroup.SelectedIndex) > 0)
            {
                if (backupBenificiary.Select("[GroupId] =" + Convert.ToInt32(DdlGroup.SelectedValue)).Count() > 0)
                {
                    //DdlBeneficiary.DataSource = null;
                    DdlBeneficiary.DataSource = backupBenificiary.Select("[GroupId] =" + DdlGroup.SelectedValue).CopyToDataTable();
                    return;
                }
                else
                {
                    MessageBox.Show("No benificiary found for selected group. Showing all benificiary.");
                }
            }
            DdlBeneficiary.DataSource = backupBenificiary;
        }

        private void DdlApplicant_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
