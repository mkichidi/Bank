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
    public partial class Beneficiary : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public Beneficiary()
        {
            InitializeComponent();
            IncrementDestination();

            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetBankGroup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            DataRow row = dataTable.NewRow();
            row["BankGroupName"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlGroup.DataSource = new DataView(dataTable);
            DdlGroup.DisplayMember = "BankGroupName";
            DdlGroup.ValueMember = "BankGroupId";
            DdlGroup.SelectedIndex = 0;
            con.Close();

            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxBeneficiaryID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtBankID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtAccountHolderName.Text))
            {
                MessageBox.Show("Please enter Account Holder Name");
                TxtAccountHolderName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtAccountNo.Text))
            {
                MessageBox.Show("Please enter Account No ");
                TxtAccountNo.Focus();
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

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertBeneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BeneficiaryName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Bank", TxtBank.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text);
                cmd.Parameters.AddWithValue("@MobileNo", TxtMobileNo.Text);
                cmd.Parameters.AddWithValue("@AccountType", DdlAccountType.Text);
                cmd.Parameters.AddWithValue("@GroupId", DdlGroup.SelectedValue);

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
                SqlCommand cmd = new SqlCommand("UpdateBeneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BeneficiaryId", TxtBankID.Text);
                cmd.Parameters.AddWithValue("@BeneficiaryName", TxtAccountHolderName.Text);
                cmd.Parameters.AddWithValue("@AccountNo", TxtAccountNo.Text);
                cmd.Parameters.AddWithValue("@Bank", TxtBank.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Branch", TxtBranch.Text);
                cmd.Parameters.AddWithValue("@IFSC", txtIFSC.Text);
                cmd.Parameters.AddWithValue("@MobileNo", TxtMobileNo.Text);
                cmd.Parameters.AddWithValue("@AccountType", DdlAccountType.Text);
                cmd.Parameters.AddWithValue("@GroupId", DdlGroup.SelectedValue);

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
            SqlCommand cmd = new SqlCommand("GetBankBeneficiaryData", con);
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
            TxtBranch.Text = string.Empty;
            DdlAccountType.SelectedIndex = 0;
            DdlGroup.SelectedIndex = 0;
            txtIFSC.Text = string.Empty;
            TxtMobileNo.Text = string.Empty;
            TxtBank.Text = string.Empty;
            txtCity.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankBeneficiaryDataOnId", con);
                cmd.Parameters.AddWithValue("@AccountId", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtBankID.Text = Convert.ToString(dataTable.Rows[0]["BeneficiaryId"]);
                    TxtAccountHolderName.Text = Convert.ToString(dataTable.Rows[0]["BeneficiaryName"]);
                    TxtAccountNo.Text = Convert.ToString(dataTable.Rows[0]["AccountNo"]);
                    DdlAccountType.Text = Convert.ToString(dataTable.Rows[0]["AccountType"]);
                    DdlGroup.SelectedValue = dataTable.Rows[0]["GroupId"]==DBNull.Value?0:Convert.ToInt32(dataTable.Rows[0]["GroupId"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    txtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    txtCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);
                    TxtMobileNo.Text = Convert.ToString(dataTable.Rows[0]["MobileNo"]);
                    if (Convert.ToBoolean(dataTable.Rows[0]["Active"]) == true)
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
                GvDestination.DataSource = backup.Select("[BeneficiaryName] Like '%" + TxtBankSearch.Text + "%'").Any() ? backup.Select("[BeneficiaryName] Like '%" + TxtBankSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }
    }
}
