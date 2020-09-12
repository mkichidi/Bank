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

namespace Bank.Masters
{
    public partial class Accounts : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public Accounts()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
            BindDropdown();
            clear();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxAccountID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtBankID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void BindDropdown()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetBank", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            DataRow row = dataTable.NewRow();
            row["BankName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DDLBank.DataSource = new DataView(dataTable);
            DDLBank.DisplayMember = "BankName";
            DDLBank.ValueMember = "BankId";
            DDLBank.SelectedIndex = 0;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAccountHolderName.Text))
            {
                MessageBox.Show("Please enter Account Holder Name Name");
                TxtAccountHolderName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtAccountNo.Text))
            {
                MessageBox.Show("Please enter Account No ");
                TxtAccountNo.Focus();
                return;
            }
            else if (DDLBank.SelectedIndex<1)
            {
                MessageBox.Show("Please select Bank");
                DDLBank.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtNickName.Text))
            {
                MessageBox.Show("Please enter Account Nick Name ");
                TxtNickName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountHolderName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Bank", DDLBank.SelectedValue);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@NickName", TxtNickName.Text);
                cmd.Parameters.AddWithValue("@AccountType", TxtAccountType.Text);
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text);

                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }
                cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
                cmd.Parameters.AddWithValue("@CD", DateTime.Now);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Account No Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Account No already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AccountId", TxtBankID.Text);
                cmd.Parameters.AddWithValue("@AccountHolderName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Bank", DDLBank.SelectedValue);
                cmd.Parameters.AddWithValue("@NickName", TxtNickName.Text);
                cmd.Parameters.AddWithValue("@AccountType", TxtAccountType.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@Branch", txtBranch.Text);

                if (ChkActive.Checked)
                {
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                }
                cmd.Parameters.AddWithValue("@CB", JswDatatable.userId);
                cmd.Parameters.AddWithValue("@CD", "");
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Account No Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Account No already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetAccount", con);
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
            TxtDescription.Text = string.Empty;
            TxtAccountHolderName.Text = string.Empty;
            TxtAccountNo.Text = string.Empty;
            TxtNickName.Text = string.Empty;
            DDLBank.SelectedIndex = 0;
            TxtAccountType.Text = string.Empty;

            LblAccName.Text = string.Empty;
            LblAccountType.Text = string.Empty;
            LblAccountNo.Text = string.Empty;
            LblBank.Text = string.Empty;
            LblBranch.Text = string.Empty;
            LblIFSC.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetAccountOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtBankID.Text = Convert.ToString(dataTable.Rows[0]["AccountId"]);
                    TxtAccountHolderName.Text = Convert.ToString(dataTable.Rows[0]["AccountHolderName"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    DDLBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    TxtNickName.Text = Convert.ToString(dataTable.Rows[0]["NickName"]);
                    TxtAccountType.Text = Convert.ToString(dataTable.Rows[0]["AccountType"]);
                    txtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    if (Convert.ToBoolean(dataTable.Rows[0]["IsActive"]) == true)
                    {
                        ChkActive.Checked = true;
                    }
                    else
                    {
                        ChkActive.Checked = false;
                    }

                }
                con.Close();
            }
        }

        private void GvDestination_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GvDestination.SelectedRows)
            {
                EditId = row.Cells[0].Value.ToString();

              DataRow[] dr=  backup.Select("AccountId =" + EditId);

              if (dr.Count() > 0)
              {
                  LblAccName.Text = Convert.ToString(dr[0]["AccountHolderName"]);
                  LblAccountType.Text = Convert.ToString(dr[0]["AccountType"]);
                  LblAccountNo.Text = Convert.ToString(dr[0]["AccountNo"]);
                  LblBank.Text = Convert.ToString(dr[0]["BankName"]);
                  LblBranch.Text = Convert.ToString(dr[0]["Branch"]);
                  LblIFSC.Text = Convert.ToString(dr[0]["IFSC"]);
              }

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
                GvDestination.DataSource = backup.Select("[AccountHolderName] Like '%" + TxtBankSearch.Text + "%'").Any() ? backup.Select("[AccountHolderName] Like '%" + TxtBankSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNickNameSearch.Text))
            {
                GvDestination.DataSource = backup.Select("[NickName] Like '%" + TxtNickNameSearch.Text + "%'").Any() ? backup.Select("[NickName] Like '%" + TxtNickNameSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void TxtType_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtType.Text))
            {
                GvDestination.DataSource = backup.Select("AccountType Like '%" + TxtType.Text + "%'").Any() ? backup.Select("AccountType Like '%" + TxtType.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }
    }
}
