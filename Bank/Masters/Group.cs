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
    public partial class Group : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public Group()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxGroupID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtGroupID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtGroupName.Text))
            {
                MessageBox.Show("Please enter Group");
                TxtGroupName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertBankGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankGroupName", TxtGroupName.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);

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
                    MessageBox.Show("Group Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Group already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateBankGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BankGroupId", TxtGroupID.Text);
                cmd.Parameters.AddWithValue("@BankGroupName", TxtGroupName.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescription.Text);
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
                    MessageBox.Show("Group Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Group already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetBankGroup", con);
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
            TxtGroupName.Text = string.Empty;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankGroupOnId", con);
                cmd.Parameters.AddWithValue("@BankGroupId", EditId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                if (dataTable.Rows.Count > 0)
                {
                    TxtGroupID.Text = Convert.ToString(dataTable.Rows[0]["BankGroupId"]);
                    TxtGroupName.Text = Convert.ToString(dataTable.Rows[0]["BankGroupName"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
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
                GvDestination.DataSource = backup.Select("[BankGroupName] Like '%" + TxtBankSearch.Text + "%'").Any() ? backup.Select("[BankGroupName] Like '%" + TxtBankSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }
    }
}
