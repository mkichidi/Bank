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

namespace Bank
{
    public partial class AccountPopup : Form
    {
        public AccountPopup()
        {
            InitializeComponent();
            BindDropdowns();
        }

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
            row["AccountNo"] = "-Select-";
            row["Active"] = true;
            dataTable.Rows.InsertAt(row, 0);
            DdlAccount.DataSource = new DataView(dataTable);
            DdlAccount.DisplayMember = "AccountNo";
            DdlAccount.ValueMember = "AccountId";
            DdlAccount.SelectedIndex = 0;
            con.Close();
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (DdlAccount.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Account No");
                DdlAccount.Focus();
                return;
            }

            if (JswDatatable.navigator == "passbook")
            {
                JswDatatable.accountNo =Convert.ToInt32( DdlAccount.SelectedValue);
                Bank.PassBookOnAccount PassBookOnAccount = new Bank.PassBookOnAccount();
                PassBookOnAccount.Show();
                this.Close();
            }
            else if (JswDatatable.navigator == "statement")
            {
                JswDatatable.accountNo = Convert.ToInt32(DdlAccount.SelectedValue);
                Bank.StatementOnAccount StatementOnAccount = new Bank.StatementOnAccount();
                StatementOnAccount.Show();
                this.Close();
            }
        }
    }
}
