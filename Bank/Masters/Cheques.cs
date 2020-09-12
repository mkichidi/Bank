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
    public partial class Cheques : Form
    {
        string EditId = string.Empty;
        DataTable backup = new DataTable();
        public Cheques()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
            BindDropdown();
        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxBankChequeID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtBankID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        private void BindDropdown()
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
            row["AccountNo"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlAccount.DataSource = new DataView(dataTable);
            DdlAccount.DisplayMember = "AccountNo";
            DdlAccount.ValueMember = "AccountId";
            DdlAccount.SelectedIndex = 0;
            con.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (DdlAccount.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Account no");
                DdlAccount.Focus();
                return;
            } 
            else if (string.IsNullOrEmpty(TxtChequeFrom.Text) || !int.TryParse(TxtChequeFrom.Text,out a))
            {
                MessageBox.Show("Please enter correct Cheque From");
                TxtChequeFrom.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtChequeTo.Text) || !int.TryParse(TxtChequeTo.Text, out a))
            {
                MessageBox.Show("Please enter correct Cheque To");
                TxtChequeTo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(TxtAlertNo.Text) || !int.TryParse(TxtAlertNo.Text, out a))
            {
                MessageBox.Show("Please enter Alert No");
                TxtAlertNo.Focus();
                return;
            }
            else if (Convert.ToInt32(TxtChequeFrom.Text) > Convert.ToInt32(TxtChequeTo.Text))
            {
                MessageBox.Show("Please enter Cheque From should be less than Cheque To");
                TxtChequeTo.Focus();
                return;
            }
            else if (Convert.ToInt32(TxtChequeTo.Text) - Convert.ToInt32(TxtChequeFrom.Text) < Convert.ToInt32(TxtAlertNo.Text))
            {
                MessageBox.Show("Please enter Alert number less than Cheque no's");
                TxtAlertNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertCheques", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ChequeFrom", TxtChequeFrom.Text);
                cmd.Parameters.AddWithValue("@ChequeTo", TxtChequeTo.Text);
                cmd.Parameters.AddWithValue("@AccountId", DdlAccount.SelectedValue);
                cmd.Parameters.AddWithValue("@Alert", TxtAlertNo.Text);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cheque Details Saved Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                }
                else
                {
                    MessageBox.Show("Cheque Details already exists");
                }
                con.Close();
            }
            else if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("UpdateCheque", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ChequesId", TxtBankID.Text);
                cmd.Parameters.AddWithValue("@ChequeFrom", TxtChequeFrom.Text);
                cmd.Parameters.AddWithValue("@ChequeTo", TxtChequeTo.Text);
                cmd.Parameters.AddWithValue("@AccountId", DdlAccount.SelectedValue);
                cmd.Parameters.AddWithValue("@Alert", TxtAlertNo.Text);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cheque Details Edited Succesfully");
                    IncrementDestination();
                    BindGrid();
                    clear();
                    EditId = string.Empty;
                }
                else
                {
                    MessageBox.Show("Cheque Details already exists");
                }
                con.Close();
            }

        }

        public void BindGrid()
        {
            if (DdlAccount.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankCheques", con);
                cmd.Parameters.AddWithValue("@AccountId", DdlAccount.SelectedValue);
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
        }

        private void clear()
        {
            TxtChequeTo.Text = string.Empty;
            TxtChequeFrom.Text = string.Empty;
            TxtAlertNo.Text = string.Empty;
            DdlAccount.SelectedIndex = 0;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankChequesOnId", con);
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
                    TxtChequeFrom.Text = Convert.ToString(dataTable.Rows[0]["ChequeFrom"]);
                    TxtChequeTo.Text = Convert.ToString(dataTable.Rows[0]["ChequeTo"]);
                    DdlAccount.SelectedValue = Convert.ToString(dataTable.Rows[0]["AccountId"]);
                    TxtAlertNo.Text = Convert.ToString(dataTable.Rows[0]["Alert"]);
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

        private void TxtAccountSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtAccountSearch.Text))
            {
                GvDestination.DataSource = backup.Select("AccountNo Like '%" + TxtAccountSearch.Text + "%'").Any() ? backup.Select("AccountNo Like '%" + TxtAccountSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void DdlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
