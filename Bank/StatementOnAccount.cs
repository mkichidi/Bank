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
using OfficeOpenXml;



namespace Bank
{
    public partial class StatementOnAccount : Form
    {
        string EditId = string.Empty;
        int flag = 0;
        DataTable backup = new DataTable();
        decimal balance = 0M;

        public StatementOnAccount()
        {
            InitializeComponent();
            BindDropdowns();
            IncrementShipment();
            BindGrid();

            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetAccountOnId", con);
            cmd.Parameters.AddWithValue("@AccountId", JswDatatable.accountNo);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            if (dataTable.Rows.Count > 0)
            {
                LblAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
            }
            DdlAccount_SelectedIndexChanged();
        }

        public void IncrementShipment()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxStatementTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtShipmentID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
       {
            bool res;
            if (keyData == (System.Windows.Forms.Keys.ControlKey | System.Windows.Forms.Keys.Control) || (keyData == System.Windows.Forms.Keys.S) || (keyData == System.Windows.Forms.Keys.R))
            {
                if (keyData == (System.Windows.Forms.Keys.ControlKey | System.Windows.Forms.Keys.Control)){
                    flag = 1;
                    return false;
                }
                if (flag == 1)
                {
                    if ((keyData == System.Windows.Forms.Keys.S))
                    {
                        toolStrip1.Items["tsBtnSave"].PerformClick();
                        flag = 0;
                         res = base.ProcessCmdKey(ref msg, keyData);
                        return true;
                    }
                    else if ((keyData == System.Windows.Forms.Keys.R))
                    {
                        toolStrip1.Items["tsBtnRefresh"].PerformClick();
                        flag = 0;
                         res = base.ProcessCmdKey(ref msg, keyData);
                        return true;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                else
                {
                    flag = 0;
                }
            }
            else
            {
                flag = 0;
            }
             res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }

        public void BindDropdowns()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetBankGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
          SqlDataReader  reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
          DataRow   row = dataTable.NewRow();
             row["BankGroupName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlBankGroup.DataSource = new DataView(dataTable);
            DdlBankGroup.DisplayMember = "BankGroupName";
            DdlBankGroup.ValueMember = "BankGroupId";
            DdlBankGroup.SelectedIndex = 0;


            TxtGroupSearch.DataSource = new DataView(dataTable);
            TxtGroupSearch.DisplayMember = "BankGroupName";
            TxtGroupSearch.ValueMember = "BankGroupId";
            TxtGroupSearch.SelectedIndex = 0;
            con.Close();

        }

        private void clear()
        {
            TxtChequeNo.Text = "NA";
            TxtParticular.Text = string.Empty;
            TxtWithdraw.Text = string.Empty;
            TxtParticular.Text = string.Empty;
            TxtChequeNo.Text = string.Empty;
            TxtDeposit.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            TxtBalance.Text = string.Empty;
            TxtBalanceCalculated.Text = string.Empty;
            DdlBankGroup.SelectedIndex = 0;
            balance = 0;
            DdlAccount_SelectedIndexChanged();
        }

        public void BindGrid()
        {
           
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetStatementTransaction", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Account", JswDatatable.accountNo);
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            GvShipment.DataSource = dataTable;
            backup = dataTable;
            this.GvShipment.AllowUserToAddRows = false;
            con.Close();
           
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            int a = 0;
            decimal b = 0M;
            if (string.IsNullOrEmpty(TxtDeposit.Text) && string.IsNullOrEmpty(TxtWithdraw.Text) && Convert.ToString(DdlBankGroup.SelectedValue) != "9")
            {
                MessageBox.Show("Please enter Withdraw or Deposit money");
                TxtDeposit.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtWithdraw.Text) && !string.IsNullOrEmpty(TxtDeposit.Text) && !decimal.TryParse(TxtDeposit.Text, out b) && Convert.ToString(DdlBankGroup.SelectedValue) != "9")
            {
                MessageBox.Show("Please enter Correct Deposit");
                TxtDeposit.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtDeposit.Text) && !string.IsNullOrEmpty(TxtWithdraw.Text) && !decimal.TryParse(TxtWithdraw.Text, out b) &&
           Convert.ToString(DdlBankGroup.SelectedValue) != "9")
            {
                MessageBox.Show("Please enter Correct Withdraw");
                TxtWithdraw.Focus();
                return;
            }
                else if (string.IsNullOrEmpty(TxtParticular.Text))
            {
                MessageBox.Show("Please enter Particular");
                TxtParticular.Focus();
                return;
            }
             else if (DdlBankGroup.SelectedIndex<1)
            {
                MessageBox.Show("Please select Group");
                DdlBankGroup.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtBalanceCalculated.Text) || !decimal.TryParse(TxtBalanceCalculated.Text, out b))
            {
                MessageBox.Show("Please enter correct Calculated Balance");
                TxtBalanceCalculated.Focus();
                return;
            }
            //else if (string.IsNullOrEmpty(TxtDeposit.Text) && !string.IsNullOrEmpty(TxtWithdraw.Text) && !string.IsNullOrEmpty(TxtChequeNo.Text))
            //{
            //    SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //    SqlCommand cmd = new SqlCommand("CheckChequeNoStatement", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Account", JswDatatable.accountNo);
            //    cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
            //    con.Open();
            //    SqlDataReader reader;
            //    reader = cmd.ExecuteReader();
            //    DataTable dataTable = new DataTable();
            //    dataTable.Load(reader);
            //    con.Open();

            //    string messsage = string.Empty;
            //    if (dataTable.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dataTable.Rows.Count; i++)
            //        {
            //            if ((Convert.ToInt32(dataTable.Rows[i]["ChequeFrom"]) <= Convert.ToInt32(TxtChequeNo.Text)) && (Convert.ToInt32(dataTable.Rows[i]["ChequeTo"]) >= Convert.ToInt32(TxtChequeNo.Text)))
            //            {
            //                con = new SqlConnection(Connection.InvAdminConn());
            //                cmd = new SqlCommand("CheckChequeNoInTransaction", con);
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.AddWithValue("@Account", JswDatatable.accountNo);
            //                cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
            //                con.Open();
            //                reader = cmd.ExecuteReader();
            //                DataTable dataTableCheck = new DataTable();
            //                dataTableCheck.Load(reader);
            //                if (dataTableCheck.Rows.Count > 0)
            //                {
            //                    MessageBox.Show("Cheque no already issued in " + dataTableCheck.Rows[i]["Date"]);
            //                    DdlBankGroup.Focus();
            //                    return;
            //                }
            //                messsage = string.Empty;
            //                break;
            //            }
            //            else
            //            {
            //                messsage += "Please enter Cheque no between " + dataTable.Rows[i]["ChequeFrom"] + " and " + dataTable.Rows[i]["ChequeTo"] + Environment.NewLine;
            //            }

            //        }
            //        if (!string.IsNullOrEmpty(messsage))
            //        {
            //            MessageBox.Show(messsage);
            //            TxtChequeNo.Focus();
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please enter Cheque no in Cheque Master");
            //        TxtChequeNo.Focus();
            //        return;
            //    }
            //}


         
            // if (DdlAccount.SelectedIndex == -1)
            //{
            //    DialogResult ans = MessageBox.Show("Vehicle " + DdlAccount.Text +" is not present in master.Do you want to save this Vehicle?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (ans == DialogResult.Yes)
            //    {
            //        string vehicle = DdlAccount.Text;
            //        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //        SqlCommand cmd = new SqlCommand("InsertVehicle", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@VehicleNo", vehicle);
            //        cmd.Parameters.AddWithValue("@SplVehicle", 0);
            //        con.Open();
            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            con = new SqlConnection(Connection.InvAdminConn());
            //            cmd = new SqlCommand("ShipmentDropDown", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            con.Open();
            //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //            DataSet ds = new DataSet();
            //            adapter.Fill(ds);
            //            con.Close();
            //            DataRow row = (ds.Tables[0]).NewRow();
            //            row["VehicleNo"] = "-Select-";
            //            ds.Tables[0].Rows.InsertAt(row, 0);
            //            DdlAccount.DataSource = new DataView(ds.Tables[0]);
            //            DdlAccount.DisplayMember = "VehicleNo";
            //            DdlAccount.ValueMember = "VehicleID";
            //            DdlAccount.Text = vehicle;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Vehicle No already exists");
            //        }
            //        con.Close();
            //    }
            //}
            // if (DdlParty.SelectedIndex == -1)
            //{
            //    DialogResult ans = MessageBox.Show("Party "+DdlParty.Text+" is not present in master.Do you want to save this Party?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (ans == DialogResult.Yes)
            //    {
            //        string party = DdlParty.Text;
            //        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            //        SqlCommand cmd = new SqlCommand("InsertParty", con);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@PartyName", party);
            //        cmd.Parameters.AddWithValue("@PartyPhoneNumber", "");
            //        cmd.Parameters.AddWithValue("@PartyDescription", "");
            //        cmd.Parameters.AddWithValue("@PartyAddress", "");
            //        cmd.Parameters.AddWithValue("@PartyDestinationID", DdlDestination.SelectedValue);
            //        cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
            //        cmd.Parameters.AddWithValue("@CD", DateTime.Now);
            //        cmd.Parameters.AddWithValue("@IsActive", 1);

            //        con.Open();
            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            con = new SqlConnection(Connection.InvAdminConn());
            //            cmd = new SqlCommand("ShipmentDropDown", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            con.Open();
            //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //            DataSet ds = new DataSet();
            //            adapter.Fill(ds);
            //            con.Close();
            //           DataRow row = (ds.Tables[3]).NewRow();
            //            row["Party Name"] = "-Select-";
            //            ds.Tables[3].Rows.InsertAt(row, 0);
            //            DdlParty.DataSource = new DataView(ds.Tables[3]);
            //            DdlParty.DisplayMember = "Party Name";
            //            DdlParty.ValueMember = "PartyID";
            //            DdlParty.Text = party;

            //        }
            //        else
            //        {
            //            MessageBox.Show("Party already exists");
            //        }
            //        con.Close();
            //    }
            //}

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertStatementTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
                cmd.Parameters.AddWithValue("@Particular", TxtParticular.Text);
                cmd.Parameters.AddWithValue("@Withdrawals", TxtWithdraw.Text);
                cmd.Parameters.AddWithValue("@Deposit", TxtDeposit.Text);
                cmd.Parameters.AddWithValue("@Balance", TxtBalance.Text);
                cmd.Parameters.AddWithValue("@BankGroup", DdlBankGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@BankAccount", JswDatatable.accountNo);
                cmd.Parameters.AddWithValue("@BalanceCalculated", TxtBalanceCalculated.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@Date", TxtDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Statement Entry Saved Succesfully");
                    IncrementShipment();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Statement Entry already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateStatementTransaction", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankTransactionId", TxtShipmentID.Text);
                cmd.Parameters.AddWithValue("@ChequeNo", TxtChequeNo.Text);
                cmd.Parameters.AddWithValue("@Particular", TxtParticular.Text);
                cmd.Parameters.AddWithValue("@Withdrawals", TxtWithdraw.Text);
                cmd.Parameters.AddWithValue("@Deposit", TxtDeposit.Text);
                cmd.Parameters.AddWithValue("@BalanceCalculated", TxtBalanceCalculated.Text);
                cmd.Parameters.AddWithValue("@Balance", TxtBalance.Text);
                cmd.Parameters.AddWithValue("@BankGroup", DdlBankGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@BankAccount", JswDatatable.accountNo);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@Date", TxtDate.Value.Date);
                cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Statement Entry Edited Succesfully");
                    IncrementShipment();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                con.Close();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetStatementTransactionOnId", con);
                cmd.Parameters.AddWithValue("@BankTransactionID", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtShipmentID.Text = Convert.ToString(dataTable.Rows[0]["StatementTransactionId"]);
                    TxtChequeNo.Text = Convert.ToString(dataTable.Rows[0]["ChequeNo"]);
                    TxtParticular.Text = Convert.ToString(dataTable.Rows[0]["Particular"]);
                    TxtBalance.Text = Convert.ToString(dataTable.Rows[0]["Balance"]);
                    TxtBalanceCalculated.Text = Convert.ToString(dataTable.Rows[0]["BalanceCalculated"]);
                    TxtDate.Value = Convert.ToDateTime(dataTable.Rows[0]["Date"]).Date;
                    TxtWithdraw.TextChanged -= TxtWithdraw_TextChanged;
                    TxtWithdraw.Text = Convert.ToString(dataTable.Rows[0]["Withdrawals"]);
                    TxtWithdraw.TextChanged += TxtWithdraw_TextChanged;
                    TxtDeposit.TextChanged -= TxtDeposit_TextChanged;
                    TxtDeposit.Text = Convert.ToString(dataTable.Rows[0]["Deposit"]);
                    TxtDeposit.TextChanged += TxtDeposit_TextChanged;
                    DdlBankGroup.SelectedValue = Convert.ToInt32(dataTable.Rows[0]["BankGroup"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    decimal a = 0M;
                    balance = (decimal.TryParse(TxtBalance.Text, out a) ? Convert.ToDecimal(TxtBalance.Text) : 0) + (decimal.TryParse(TxtWithdraw.Text, out a) ? Convert.ToDecimal(TxtWithdraw.Text) : 0) - (decimal.TryParse(TxtDeposit.Text, out a) ? Convert.ToDecimal(TxtDeposit.Text) : 0);
                    TxtBalance.Text = balance.ToString();
                }
                con.Close();
            }
        }

        private void GvShipment_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvShipment.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();
            }
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
                sSheetName = "Statements$";
            }
            dtTablesList.Clear(); 
            dtTablesList.Dispose(); 
            if (!string.IsNullOrEmpty(sSheetName)) {
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

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            TxtUploadfile.Text = op.FileName ;
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUploadfile.Text))
            {
                DataTable dt = ConvertExcelToDataTable(TxtUploadfile.Text);


                string error = string.Empty;
                string correct = string.Empty;
                DateTime datetime;
                decimal dec = 0m;


                for (int row=0;row<dt.Rows.Count;row++)
                {
                    int errorBit = 0;

                    try
                    {
                        if (!DateTime.TryParse(Convert.ToString(dt.Rows[row]["Date"]), out datetime))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Date" + Environment.NewLine;
                        }

                        if ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Deposit"]))) && (string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Withdraw"]))))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter Deposit or Withdraw" + Environment.NewLine;
                        }

                        else if (((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Deposit"]))) && (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Withdraw"])))) && (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Withdraw"]), out dec)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Withdraw" + Environment.NewLine;
                        }

                        else if (((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Withdraw"]))) && (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Deposit"])))) && (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Deposit"]), out dec)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Deposit" + Environment.NewLine;
                        }

                        if ((string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Balance"]))) && (!decimal.TryParse(Convert.ToString(dt.Rows[row]["Balance"]), out dec)))
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please enter correct Balance" + Environment.NewLine;
                        }

                        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        SqlCommand cmd = new SqlCommand("GetAccountNoonName", con);
                        cmd.Parameters.AddWithValue("@accountno", dt.Rows[row]["Account No"]);
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

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetBankGroupOnName", con);
                        cmd.Parameters.AddWithValue("@group", dt.Rows[row]["Group"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Group in Group Master" + Environment.NewLine;
                        }
                        con.Close();


                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("GetBankGroupOnName", con);
                        cmd.Parameters.AddWithValue("@group", dt.Rows[row]["Group"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Please check Group in Group Master" + Environment.NewLine;
                        }
                        con.Close();

                        con = new SqlConnection(Connection.InvAdminConn());
                        cmd = new SqlCommand("CheckStatementTransactionBeforeUpload", con);

                        cmd.Parameters.AddWithValue("@ChequeNo", dt.Rows[row]["Cheque No"]);
                        cmd.Parameters.AddWithValue("@Particular", dt.Rows[row]["Particular"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Withdraw"])))
                        {
                            TxtWithdraw.Text = Convert.ToString(dt.Rows[row]["Withdraw"]);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Deposit"])))
                        {
                            TxtDeposit.Text = Convert.ToString(dt.Rows[row]["Deposit"]);
                        }

                        cmd.Parameters.AddWithValue("@Withdrawals", dt.Rows[row]["Withdraw"]);
                        cmd.Parameters.AddWithValue("@Deposit", dt.Rows[row]["Deposit"]);
                        DdlBankGroup.Text = Convert.ToString(dt.Rows[row]["Group"]);
                        cmd.Parameters.AddWithValue("@BankGroup", DdlBankGroup.SelectedValue);
                        cmd.Parameters.AddWithValue("@BankAccount", JswDatatable.accountNo);
                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dt.Rows[row]["Date"]).Date);

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            if (errorBit == 0)
                            {
                                error += "Line No " + (row + 2) + Environment.NewLine;
                                errorBit = 1;
                            }
                            error += "    Duplicate Data.Please check and upload." + Environment.NewLine;
                        }
                        con.Close();
                       

                    }    
                    catch (Exception ex)
                    {
                        error += "Line No" + (row + 2) + Environment.NewLine;
                        error += ex.Message;
                        continue;
                    }
                }
                //if (error.Length > 0 && correct.Length>0)
                //{
                //    MessageBox.Show("Lines at "+correct.Substring(1)+" uploaded succesfully."+Environment.NewLine+" Error at " + error+Environment.NewLine+"Please correct and upload error data at "+clearExcelUploadSuccess(correct));
                //    error = string.Empty;
                //    correct = string.Empty;
                //}
                //else 
                    if (error.Length > 0)
                {
                    MessageBox.Show(error + Environment.NewLine + "Please correct and upload error data at " + TxtUploadfile.Text);
                    error = string.Empty;
                    correct = string.Empty;
                }
                else
                {
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {
                        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        SqlCommand cmd = new SqlCommand("InsertStatementTransactionOnUpload", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@ChequeNo", dt.Rows[row]["Cheque No"]);
                        cmd.Parameters.AddWithValue("@Particular", dt.Rows[row]["Particular"]);
                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Withdraw"])))
                        {
                            TxtWithdraw.Text = Convert.ToString(dt.Rows[row]["Withdraw"]);
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[row]["Deposit"])))
                        {
                            TxtDeposit.Text = Convert.ToString(dt.Rows[row]["Deposit"]);
                        }
                        cmd.Parameters.AddWithValue("@Withdrawals", dt.Rows[row]["Withdraw"]);
                        cmd.Parameters.AddWithValue("@Deposit", dt.Rows[row]["Deposit"]);
                        DdlBankGroup.Text = Convert.ToString(dt.Rows[row]["Group"]);
                        cmd.Parameters.AddWithValue("@BankGroup", DdlBankGroup.SelectedValue);
                        cmd.Parameters.AddWithValue("@BalanceCalculated", dt.Rows[row]["Balance"]);
                        cmd.Parameters.AddWithValue("@BankAccount", JswDatatable.accountNo);
                        DdlAccount_SelectedIndexChanged();
                        cmd.Parameters.AddWithValue("@Balance", TxtBalance.Text);
                        cmd.Parameters.AddWithValue("@Description", dt.Rows[row]["Description"]);
                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(dt.Rows[row]["Date"]).Date);
                        cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
                        cmd.Parameters.AddWithValue("@CD", DateTime.Now);

                        con.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            correct += "," + (row + 2);
                        }
                        con.Close();
                        clear();
                    }
                    MessageBox.Show("Shipment details saved succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                }
                IncrementShipment();
                BindGrid();
                clear();
            }
        }

        private string clearExcelUploadSuccess(string correct)
        {
            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(TxtUploadfile.Text)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                string [] corrects=correct.Substring(1).Split(',');
                for (int row = 0; row < corrects.Count(); row++)
                {
                    worksheet.DeleteRow(Convert.ToInt32(corrects[row])-row);
                }
                string filename = "D:\\Bank\\Statements\\Statements_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
                System.IO.FileInfo excel = new System.IO.FileInfo(filename + ".xlsx");

                if (excel.Exists)
                {
                    excel.Delete();
                }
                using (ExcelPackage pac = new ExcelPackage(new System.IO.FileInfo("D:\\Bank\\Statements\\Statements_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx")))
                {
                    pac.Workbook.Worksheets.Add(("Statements"), worksheet);
                    pac.Save();
                }
            }
            return ("D:\\Bank\\Statements\\Statements_Error_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_') + ".xlsx");
        }

        private string ExcelDropdown(DataTable dt, string value)
        {
            string data = string.Empty;
            foreach (DataRow datarow in dt.Rows)
            {
                if (data.Length > 0)
                {
                    data += datarow[value] + ",";
                }
                else
                {
                    data += "\"" + datarow[value] + ",";
                }
            }
            if (data.Length > 0)
            {
                data = data.Substring(0, data.Length - 1);
                data += "\"";
            }
            return data;
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            string filename = "D:\\Bank\\Statements\\Statements_" + DateTime.Today.ToString().Substring(0, 10).Replace('/', '_');
            System.IO.Directory.CreateDirectory("D:\\Bank\\Statements\\");

            System.IO.FileInfo excel = new System.IO.FileInfo( filename + ".xlsx");

            if (excel.Exists)
            {
                excel.Delete();
            }
            using (var xls = new ExcelPackage(excel))
            {
                var sheet = xls.Workbook.Worksheets.Add("Statements");
                sheet.Cells["A1"].Value = "Date";
                sheet.Cells["B1"].Value = "Cheque No";
                sheet.Cells["C1"].Value = "Particular";
                sheet.Cells["D1"].Value = "Withdraw";
                sheet.Cells["E1"].Value = "Deposit";
                sheet.Cells["F1"].Value = "Balance";
                sheet.Cells["G1"].Value = "Account No";
                sheet.Cells["H1"].Value = "Group";
                sheet.Cells["I1"].Value = "Description";

                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                sheet.Column(1).Width = 20;
                sheet.Column(2).Width = 20;
                sheet.Column(3).Width = 20;
                sheet.Column(4).Width = 20;
                sheet.Column(5).Width = 20;
                sheet.Column(6).Width = 20;
                sheet.Column(7).Width = 20;
                sheet.Column(8).Width = 20;
                sheet.Column(9).Width = 20;


                //Get the final row for the column in the worksheet
                int finalrows = sheet.Dimension.End.Row;


                sheet.Cells["A1:I" + finalrows.ToString()].Style.WrapText = true;
                sheet.Cells["A1:I1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                sheet.Cells["A1:I1"].Style.Font.Size = 12;

                sheet.Cells["A1:I1"].Style.Font.Bold = true;
                sheet.Cells["A1:I1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                sheet.Cells["A1:I1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);



                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
               
                con.Close();

                var AccountHolderName = xls.Workbook.Worksheets.Add("AccountNo");
                for (int dr = 1; dr <= dataTable.Rows.Count; dr++)
                {
                    AccountHolderName.Cells["A" + dr].Value = dataTable.Rows[dr - 1]["AccountNo"];
                }




                con = new SqlConnection(Connection.InvAdminConn());
                cmd = new SqlCommand("GetBankGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                reader = cmd.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(reader);
               
                DdlBankGroup.DataSource = new DataView(dataTable);
                DdlBankGroup.DisplayMember = "BankGroupName";
                DdlBankGroup.ValueMember = "BankGroupId";
                DdlBankGroup.SelectedIndex = 0;
                con.Close();

                var Group = xls.Workbook.Worksheets.Add("Group");
                for (int dr = 1; dr <= dataTable.Rows.Count; dr++)
                {
                    Group.Cells["A" + dr].Value = dataTable.Rows[dr - 1]["BankGroupName"];
                }

               

                xls.Save();

                DialogResult ans = MessageBox.Show("File Downloaded at " + filename + Environment.NewLine + "Do you want to open?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(filename + ".xlsx");
                }
            }
        }

        private void tsBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

  

        private void TxtShipmentSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtChequeNoSearch.Text))
            {
                GvShipment.DataSource = backup.Select("ChequeNo Like '%" + TxtChequeNoSearch.Text + "%'").Any() ? backup.Select("ChequeNo Like '%" + TxtChequeNoSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void TxtDeposit_TextChanged(object sender, EventArgs e)
        {
            decimal b = 0M;
            //TxtWithdraw.Text=string.Empty;
            if (!decimal.TryParse(TxtDeposit.Text, out b))
            {
                TxtBalance.Text = balance.ToString();
                return;
            }

            //if (Convert.ToDecimal(balance)>=0)
            //{
                TxtWithdraw.TextChanged -= TxtWithdraw_TextChanged;
                TxtWithdraw.Text = string.Empty;
                TxtWithdraw.TextChanged += TxtWithdraw_TextChanged;
                TxtBalance.Text =Convert.ToString(balance + Convert.ToDecimal(TxtDeposit.Text));
            //}
        }

        private void TxtWithdraw_TextChanged(object sender, EventArgs e)
        {
            decimal b = 0M;
            //TxtDeposit.Text=string.Empty;

            if (!decimal.TryParse(TxtWithdraw.Text, out b))
            {
                TxtBalance.Text = balance.ToString();
                return;
            }

            //if (Convert.ToDecimal(balance) >= 0)
            //{
                TxtDeposit.TextChanged -= TxtDeposit_TextChanged;
                TxtDeposit.Text = string.Empty;
                TxtDeposit.TextChanged += TxtDeposit_TextChanged;
                TxtBalance.Text = Convert.ToString(balance - Convert.ToDecimal(TxtWithdraw.Text));
            //}
        }

        private void DdlAccount_SelectedIndexChanged()
        {

            decimal b = 0M;
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetAccountBalanceStatement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BankAccount", JswDatatable.accountNo);

            con.Open();
            
                balance=  Convert.ToDecimal(cmd.ExecuteScalar() == DBNull.Value ?0: cmd.ExecuteScalar() );
              TxtBalance.Text = Convert.ToString(balance);
            con.Close();
            

            if (decimal.TryParse(TxtWithdraw.Text, out b))
            {
                TxtBalance.Text = Convert.ToString(balance - Convert.ToDecimal(TxtWithdraw.Text));
            }

            if (decimal.TryParse(TxtDeposit.Text, out b))
            {
                TxtBalance.Text = Convert.ToString(balance + Convert.ToDecimal(TxtDeposit.Text));
            }
            BindGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            IncrementShipment();
            clear();
        }

        private void TxtGroupSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtGroupSearch.SelectedIndex>0)
            {
                GvShipment.DataSource = backup.Select("BankGroupName Like '%" + TxtGroupSearch.Text + "%'").Any() ? backup.Select("BankGroupName Like '%" + TxtGroupSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvShipment.DataSource = backup;
            }
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (backup.Rows.Count > 0)
            {
                GvShipment.DataSource = backup.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").Any() ? backup.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").CopyToDataTable() : backup.Clone();
            }
        }

        private void DtTo_ValueChanged(object sender, EventArgs e)
        {
            if (backup.Rows.Count > 0)
            {
                GvShipment.DataSource = backup.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").Any() ? backup.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").CopyToDataTable() : backup.Clone();
            }
        }
    }
}
