using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank
{
    public partial class Reconcillation : Form
    {

        DataTable backupPassbook = new DataTable();
        DataTable backupStatement = new DataTable();
        string Valuesfrom = string.Empty;
        string error = string.Empty;
        string correct = string.Empty;
        decimal dec = 0M;

        public Reconcillation()
        {
            InitializeComponent();

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
            TxtGroupSearchStatement.DataSource = new DataView(dataTable);
            TxtGroupSearchStatement.DisplayMember = "BankGroupName";
            TxtGroupSearchStatement.ValueMember = "BankGroupId";
            TxtGroupSearchStatement.SelectedIndex = 0;


            TxtGroupSearch.DataSource = new DataView(dataTable);
            TxtGroupSearch.DisplayMember = "BankGroupName";
            TxtGroupSearch.ValueMember = "BankGroupId";
            TxtGroupSearch.SelectedIndex = 0;
            con.Close();

        }

        private void DdlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatementConsolidate = string.Empty;
            PassbookConsolidate = string.Empty;
            BindPassbookGrid();
            BindGridStatement();
            BindReconcilatedGrid();
        }

        public void BindReconcilatedGrid()
        {
            if (DdlAccount.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetReconcilatedOnCheque", con);
                cmd.Parameters.AddWithValue("@Account", DdlAccount.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();

                GvPassbookConsolidate.DataSource = ds.Tables[0];
                GvStatementConsolidate.DataSource = ds.Tables[1];

                GvPassbook.Columns["BankTransactionId"].Visible = false;
                GvStatement.Columns["StatementTransactionId"].Visible = false;
                GvPassbookConsolidate.Columns["BankTransactionId"].Visible = false;
                GvStatementConsolidate.Columns["StatementTransactionId"].Visible = false;
            }
        }

        public void BindPassbookGrid()
        {
            if (GvPassbook.Columns.Count > 0 && GvPassbook.Columns[0].HeaderText == "Select")
            {
                GvPassbook.Columns.RemoveAt(0);
            }

            GvPassbook.DataSource = null;
            if (DdlAccount.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankTransactionForReconsilation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account", DdlAccount.SelectedValue);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                GvPassbook.DataSource = dataTable.Copy();
                //GvPassbook.Columns["Balance"].Visible = false;
                //GvPassbook.Columns["AccountNo"].Visible = false;
                //GvPassbook.Columns["AccountHolderName"].Visible = false;
                //GvPassbook.Columns["BankTransactionId"].Visible = false;
                //GvPassbook.Columns["Description"].Visible = false;
                GvPassbook.Columns["DummyDate"].Visible = false;
                //GvPassbook.Columns["BankGroupName"].Visible = false;
                backupPassbook = dataTable;
                con.Close();

                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "Select";
                GvPassbook.Columns.Insert(0,dgvCmb);
                dgvCmb.ReadOnly = false;
                GvPassbook.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        public void BindGridStatement()
        {
            if (GvStatement.Columns.Count>0 && GvStatement.Columns[0].HeaderText == "Select")
            {
                GvStatement.Columns.RemoveAt(0);
            }

            if (DdlAccount.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetStatementTransactionForReconsilation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Account", DdlAccount.SelectedValue);
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                GvStatement.DataSource = dataTable;
                //GvStatement.Columns["StatementTransactionId"].Visible = false;
                //GvStatement.Columns["Balance"].Visible = false;
                //GvStatement.Columns["AccountNo"].Visible = false;
                //GvStatement.Columns["AccountHolderName"].Visible = false;
                //GvStatement.Columns["Description"].Visible = false;
                GvStatement.Columns["DummyDate"].Visible = false;
                //GvStatement.Columns["BankGroupName"].Visible = false;
                backupStatement = dataTable;
                con.Close();

                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "Select";
                GvStatement.Columns.Insert(0, dgvCmb);
                dgvCmb.ReadOnly = false;
                GvStatement.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        private void TxtChequeNoSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtChequeNoSearch.Text))
            {
                GvPassbook.DataSource = backupPassbook.Select("ChequeNo Like '%" + TxtChequeNoSearch.Text + "%'").Any() ? backupPassbook.Select("ChequeNo Like '%" + TxtChequeNoSearch.Text + "%'").CopyToDataTable() : backupPassbook.Clone();
            }
            else
            {
                GvPassbook.DataSource = backupPassbook;
            }
        }

        private void TxtGroupSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtGroupSearch.SelectedIndex > 0)
            {
                GvPassbook.DataSource = backupPassbook.Select("BankGroupName Like '%" + TxtGroupSearch.Text + "%'").Any() ? backupPassbook.Select("BankGroupName Like '%" + TxtGroupSearch.Text + "%'").CopyToDataTable() : backupPassbook.Clone();
            }
            else
            {
                GvPassbook.DataSource = backupPassbook;
            }
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (backupPassbook.Rows.Count > 0)
            {
                GvPassbook.DataSource = backupPassbook.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").Any() ? backupPassbook.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").CopyToDataTable() : backupPassbook.Clone();
            }
        }

        private void DtTo_ValueChanged(object sender, EventArgs e)
        {
            if (backupPassbook.Rows.Count > 0)
            {
                GvPassbook.DataSource = backupPassbook.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").Any() ? backupPassbook.Select("DummyDate >='" + DtFrom.Value.Date + "' and DummyDate <='" + DtTo.Value.Date + "'").CopyToDataTable() : backupPassbook.Clone();
            }
        }
                
        private void TxtChequeNoSearchStatement_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtChequeNoSearchStatement.Text))
            {
                GvStatement.DataSource = backupStatement.Select("ChequeNo Like '%" + TxtChequeNoSearchStatement.Text + "%'").Any() ? backupStatement.Select("ChequeNo Like '%" + TxtChequeNoSearchStatement.Text + "%'").CopyToDataTable() : backupStatement.Clone();
            }
            else
            {
                GvStatement.DataSource = backupStatement;
            }
        }

        private void TxtGroupSearchStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtGroupSearchStatement.SelectedIndex > 0)
            {
                GvStatement.DataSource = backupStatement.Select("BankGroupName Like '%" + TxtGroupSearchStatement.Text + "%'").Any() ? backupStatement.Select("BankGroupName Like '%" + TxtGroupSearchStatement.Text + "%'").CopyToDataTable() : backupStatement.Clone();
            }
            else
            {
                GvStatement.DataSource = backupStatement;
            }
        }

        private void DtFromStatement_ValueChanged(object sender, EventArgs e)
        {
            if (backupStatement.Rows.Count > 0)
            {
                GvStatement.DataSource = backupStatement.Select("DummyDate >='" + DtFromStatement.Value.Date + "' and DummyDate <='" + DtToStatement.Value.Date + "'").Any() ? backupStatement.Select("DummyDate >='" + DtFromStatement.Value.Date + "' and DummyDate <='" + DtToStatement.Value.Date + "'").CopyToDataTable() : backupStatement.Clone();
            }
        }

        private void DtToStatement_ValueChanged(object sender, EventArgs e)
        {
            if (backupStatement.Rows.Count > 0)
            {
                GvStatement.DataSource = backupStatement.Select("DummyDate >='" + DtFromStatement.Value.Date + "' and DummyDate <='" + DtToStatement.Value.Date + "'").Any() ? backupStatement.Select("DummyDate >='" + DtFromStatement.Value.Date + "' and DummyDate <='" + DtToStatement.Value.Date + "'").CopyToDataTable() : backupStatement.Clone();
            }
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rw;


        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            if (GvPassbookConsolidate.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            if (Valuesfrom == "PassbookBack")
            {
                Point clientPointOn = GvPassbookConsolidate.PointToClient(new Point(e.X, e.Y));
                int rowIndexOfItemUnderMouseToDropOn = GvPassbookConsolidate.HitTest(clientPointOn.X, clientPointOn.Y).RowIndex == -1 ? 0 : GvPassbookConsolidate.HitTest(clientPointOn.X, clientPointOn.Y).RowIndex;
                DataGridViewRow rows = (DataGridViewRow)rw.Clone();
                //for (int cell = 0; cell < rw.Cells.Count; cell++)
                //{
                //    rows.Cells[cell].Value = rw.Cells[cell].Value;
                //}
                //GvPassbookConsolidate.Rows.RemoveAt(rowIndexFromMouseDown);
                //GvPassbookConsolidate.Rows.Insert(rowIndexOfItemUnderMouseToDropOn, rows);

                DataTable dataTable = (DataTable)GvPassbookConsolidate.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                for (int cell = 0; cell < rw.Cells.Count; cell++)
                {
                    drToAdd[cell] = rw.Cells[cell].Value;
                }

                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                GvPassbookConsolidate.DataSource = dataTable;
                GvPassbookConsolidate.Rows.RemoveAt(rowIndexFromMouseDown);
                return;
            }
           else if (Valuesfrom != "Passbook")
            {
                MessageBox.Show("You cannot add this data here");
                return;
            }
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = GvPassbookConsolidate.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = GvPassbookConsolidate.HitTest(clientPoint.X, clientPoint.Y).RowIndex == -1 ? 0 : GvPassbookConsolidate.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (GvPassbookConsolidate.Columns.Count <= 0)
            {
                GvPassbookConsolidate.Columns.Add("BankTransactionId", "BankTransactionId");
                GvPassbookConsolidate.Columns.Add("Date", "Date");
                GvPassbookConsolidate.Columns.Add("ChequeNo", "ChequeNo");
                GvPassbookConsolidate.Columns.Add("Particular", "Particular");
                GvPassbookConsolidate.Columns.Add("Withdrawals", "Withdrawals");
                GvPassbookConsolidate.Columns.Add("Deposit", "Deposit");
                GvPassbookConsolidate.Columns.Add("DummyDate", "DummyDate");
                GvPassbookConsolidate.Columns.Add("BankGroupName", "BankGroupName");
            }

            if (e.Effect.ToString().Contains("DragDropEffects.Move") || e.Effect.ToString().Contains("All"))
            {
                //DataGridViewRow row = (DataGridViewRow)rw.Clone();
                //for (int cell = 0; cell < rw.Cells.Count; cell++)
                //{
                //    row.Cells[cell].Value = rw.Cells[cell].Value;
                //}

                //GvPassbookConsolidate.Rows.Insert(rowIndexOfItemUnderMouseToDrop, row);
                //GvPassbook.Rows.RemoveAt(rowIndexFromMouseDown);



                DataGridViewRow row = (DataGridViewRow)rw.Clone();


                DataTable dataTable = (DataTable)GvPassbookConsolidate.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                for (int cell = 0; cell < rw.Cells.Count; cell++)
                {
                    drToAdd[cell] = rw.Cells[cell].Value;
                }

                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                GvPassbookConsolidate.DataSource = dataTable;
                GvPassbook.Rows.RemoveAt(rowIndexFromMouseDown);
            }
        }

        private void GvPassbookConsolidate_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void GvStatementConsolidate_DragDrop(object sender, DragEventArgs e)
        {
            if (Valuesfrom == "StatementBack")
            {
                Point clientPointOn = GvStatementConsolidate.PointToClient(new Point(e.X, e.Y));
                int rowIndexOfItemUnderMouseToDropOn = GvStatementConsolidate.HitTest(clientPointOn.X, clientPointOn.Y).RowIndex == -1 ? 0 : GvStatementConsolidate.HitTest(clientPointOn.X, clientPointOn.Y).RowIndex;

                DataGridViewRow row = (DataGridViewRow)rw.Clone();

                DataTable dataTable = (DataTable)GvStatementConsolidate.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                for (int cell = 0; cell < rw.Cells.Count; cell++)
                {
                    if (rw.Cells[cell].Value == null)
                    {
                        drToAdd[cell] = DBNull.Value;
                    }
                    else
                    {

                    }
                    drToAdd[cell] = rw.Cells[cell].Value;
                }

                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                GvStatementConsolidate.DataSource = dataTable;
                GvStatementConsolidate.Rows.RemoveAt(rowIndexFromMouseDown);


                return;
            }
           else if (Valuesfrom != "Statement")
            {
                MessageBox.Show("You cannot add this data here");
                return;
            }
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = GvStatementConsolidate.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = GvStatementConsolidate.HitTest(clientPoint.X, clientPoint.Y).RowIndex == -1 ? 0 : GvStatementConsolidate.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (GvStatementConsolidate.Columns.Count <= 0)
            {
                GvStatementConsolidate.Columns.Add("StatementTransactionId", "StatementTransactionId");
                GvStatementConsolidate.Columns.Add("Date", "Date");
                GvStatementConsolidate.Columns.Add("ChequeNo", "ChequeNo");
                GvStatementConsolidate.Columns.Add("Particular", "Particular");
                GvStatementConsolidate.Columns.Add("Withdrawals", "Withdrawals");
                GvStatementConsolidate.Columns.Add("Deposit", "Deposit");
                GvStatementConsolidate.Columns.Add("DummyDate", "DummyDate");
                GvStatementConsolidate.Columns.Add("BankGroupName", "BankGroupName");
            }

            if (e.Effect.ToString().Contains("DragDropEffects.Move") || e.Effect.ToString().Contains("All"))
            {

                DataGridViewRow row = (DataGridViewRow)rw.Clone();


                DataTable dataTable = (DataTable)GvStatementConsolidate.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                for (int cell = 0; cell < rw.Cells.Count; cell++)
                {
                    drToAdd[cell] = rw.Cells[cell].Value;
                }

                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                GvStatementConsolidate.DataSource = dataTable;
                GvStatement.Rows.RemoveAt(rowIndexFromMouseDown);

            }
        }

        private void GvStatementConsolidate_DragEnter(object sender, DragEventArgs e)
        {
            if (GvPassbookConsolidate.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void GvStatementConsolidate_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void GvPassbookConsolidate_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GvPassbookConsolidate.Rows.Count < 1 || e.RowIndex < 0)
                return;

            rw = (DataGridViewRow)GvPassbookConsolidate.Rows[e.RowIndex];
            rowIndexFromMouseDown = GvPassbookConsolidate.Rows[e.RowIndex].Index;
            Valuesfrom = "PassbookBack";
            GvPassbookConsolidate.DoDragDrop(rw, DragDropEffects.Move);
        }

        private void GvPassbook_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void GvPassbook_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void GvPassbook_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void GvStatement_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void GvStatement_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void GvStatement_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GvStatementConsolidate_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GvStatementConsolidate.Rows.Count < 1 || e.RowIndex < 0)
                return;

            rw = (DataGridViewRow)GvStatementConsolidate.Rows[e.RowIndex];
            rowIndexFromMouseDown = GvStatementConsolidate.Rows[e.RowIndex].Index;
            Valuesfrom = "StatementBack";
            GvStatementConsolidate.DoDragDrop(rw, DragDropEffects.Move);
        }

      
        private void CtrlBtnPrintBill_Click(object sender, EventArgs e)
        {
            DataTable dtPassbook = new DataTable();
            DataTable dtStatement = new DataTable();

            if (GvStatementConsolidate.Rows.Count == GvPassbookConsolidate.Rows.Count)
            {
                dtPassbook = (DataTable)GvPassbookConsolidate.DataSource;
                dtStatement = (DataTable)GvStatementConsolidate.DataSource;

                int errorBit = 0;
                for (int i = 0; i < GvStatementConsolidate.Rows.Count;i++ )
                {
                    if (!((string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["Withdrawals"].Value)) ? 0 : Convert.ToDecimal(GvStatementConsolidate.Rows[i].Cells["Withdrawals"].Value)) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["Withdrawals"].Value)) ? 0 : Convert.ToDecimal(GvPassbookConsolidate.Rows[i].Cells["Withdrawals"].Value))))
                    //   && 
                    //   (string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(GvStatementConsolidate.Rows[i].Cells["Deposit"].Value)) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(GvPassbookConsolidate.Rows[i].Cells["Deposit"].Value)) 
                    //   &&
                    //   (string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["ChequeNo"].Value)) ? "" : GvStatementConsolidate.Rows[i].Cells["ChequeNo"].Value) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["ChequeNo"].Value)) ? "" : GvPassbookConsolidate.Rows[i].Cells["ChequeNo"].Value)
                    //   &&
                    //(string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["Date"].Value)) ? "" : GvStatementConsolidate.Rows[i].Cells["Date"].Value) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["Date"].Value)) ? "" : GvPassbookConsolidate.Rows[i].Cells["Date"].Value))
                    {
                        if (errorBit == 0)
                        {
                            error += "Row No " + (i + 1) + Environment.NewLine;
                            errorBit = 1;
                        }
                        error += "    Please check Withdrawal amount" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(GvStatementConsolidate.Rows[i].Cells["Deposit"].Value)) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(GvPassbookConsolidate.Rows[i].Cells["Deposit"].Value))))
                    {
                        if (errorBit == 0)
                        {
                            error += "Row No " + (i + 1) + Environment.NewLine;
                            errorBit = 1;
                        }
                        error += "    Please check Deposit amount" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["ChequeNo"].Value)) ? "" : GvStatementConsolidate.Rows[i].Cells["ChequeNo"].Value.ToString()) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["ChequeNo"].Value)) ? "" : GvPassbookConsolidate.Rows[i].Cells["ChequeNo"].Value.ToString())))
                    {
                        if (errorBit == 0)
                        {
                            error += "Row No " + (i + 1) + Environment.NewLine;
                            errorBit = 1;
                        }
                        error += "    Please check Cheque No" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(GvStatementConsolidate.Rows[i].Cells["Date"].Value)) ? "" : GvStatementConsolidate.Rows[i].Cells["Date"].Value.ToString()) == (string.IsNullOrEmpty(Convert.ToString(GvPassbookConsolidate.Rows[i].Cells["Date"].Value)) ? "" : GvPassbookConsolidate.Rows[i].Cells["Date"].Value.ToString())))
                     {
                         if (string.IsNullOrEmpty(GvPassbookConsolidate.Rows[i].Cells["ChequeNo"].Value.ToString()))
                         {
                             if (errorBit == 0)
                             {
                                 error += "Row No " + (i + 1) + Environment.NewLine;
                                 //errorBit = 1;
                             }
                             error += "    Passbook date and Statement date are different" + Environment.NewLine;
                         }
                     }
                     if (errorBit == 0)
                     {
                        SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                        SqlCommand cmd = new SqlCommand("Reconcilate", con);
                        cmd.Parameters.AddWithValue("@BankTransactionId", GvPassbookConsolidate.Rows[i].Cells["BankTransactionId"].Value);
                        cmd.Parameters.AddWithValue("@StatementTransactionId", GvStatementConsolidate.Rows[i].Cells["StatementTransactionId"].Value);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            correct += "," + (i + 1);
                        }
                        con.Close();
                    }
                    errorBit = 0;
                }

                if (error.Length > 0 && correct.Length > 0)
                {
                    MessageBox.Show("Lines at " + correct.Substring(1) + " Reconsolidated succesfully." + Environment.NewLine + " Error at " + error + Environment.NewLine + "Please Check and Reconsolidate");
                    

                    string[] corrects = correct.Substring(1).Split(',');
                    for (int row = 0; row < corrects.Count(); row++)
                    {
                        dtPassbook.Rows.RemoveAt(Convert.ToInt32(corrects[row])-1);
                        dtStatement.Rows.RemoveAt(Convert.ToInt32(corrects[row])-1);
                    }
                    GvStatementConsolidate.DataSource = dtStatement;
                    GvPassbook.DataSource = dtPassbook;
                    error = string.Empty;
                    correct = string.Empty;
                }
                else if (error.Length > 0)
                {
                    MessageBox.Show(error + Environment.NewLine + "Please Check and Reconsolidate");
                    error = string.Empty;
                    correct = string.Empty;
                }
                else
                {
                    MessageBox.Show("Reconcilated succesfully");
                    error = string.Empty;
                    correct = string.Empty;
                    BindPassbookGrid();
                    BindGridStatement();
                    BindReconcilatedGrid();
                }

                
            }
            else
            {
                MessageBox.Show("Please enter correct number of rows to reconsolidate");
            }
        }

        private void TxtDeposite_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDeposite.Text)&& decimal.TryParse(TxtDeposite.Text,out dec))
            {
                GvPassbook.DataSource = backupPassbook.Select("Deposit =" + TxtDeposite.Text).Any() ? backupPassbook.Select("Deposit =" + TxtDeposite.Text).CopyToDataTable() : backupPassbook.Clone();
            }
            else
            {
                GvPassbook.DataSource = backupPassbook;
            }
        }

        private void TxtWithdraw_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtWithdraw.Text) && decimal.TryParse(TxtWithdraw.Text, out dec))
            {
                GvPassbook.DataSource = backupPassbook.Select("Withdrawals =" + TxtWithdraw.Text).Any() ? backupPassbook.Select("Withdrawals =" + TxtWithdraw.Text).CopyToDataTable() : backupPassbook.Clone();
            }
            else
            {
                GvPassbook.DataSource = backupPassbook;
            }
        }

        private void TxtDepositeStatement_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDepositeStatement.Text) && decimal.TryParse(TxtDepositeStatement.Text,out dec))
            {
                GvStatement.DataSource = backupStatement.Select("Deposit =" + TxtDepositeStatement.Text).Any() ? backupStatement.Select("Deposit =" + TxtDepositeStatement.Text).CopyToDataTable() : backupStatement.Clone();
            }
            else
            {
                GvStatement.DataSource = backupStatement;
            }
        }

        private void TxtWithdrawStatement_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtWithdrawStatement.Text) && decimal.TryParse(TxtWithdrawStatement.Text, out dec))
            {
                GvStatement.DataSource = backupStatement.Select("Withdrawals =" + TxtWithdrawStatement.Text).Any() ? backupStatement.Select("Withdrawals =" + TxtWithdrawStatement.Text).CopyToDataTable() : backupStatement.Clone();
            }
            else
            {
                GvStatement.DataSource = backupStatement;
            }
        }

        string PassbookConsolidate = string.Empty;
        private void GvPassbook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GvPassbook.EndEdit();
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)GvPassbook.Rows[GvPassbook.CurrentRow.Index].Cells[0];
          if (chk != null && Convert.ToBoolean(chk.Value) == true)
          {
              PassbookConsolidate = GvPassbook.Rows[e.RowIndex].Cells["BankTransactionId"].Value.ToString();
          }
          else
          {
              PassbookConsolidate = string.Empty;
          }

          foreach (DataGridViewRow row in GvPassbook.Rows)
          {
              if (row.Index != e.RowIndex)
                  GvPassbook.Rows[row.Index].SetValues(false);
          }
        }

        string StatementConsolidate = string.Empty;
        private void GvStatement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GvStatement.EndEdit();
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)GvStatement.Rows[GvStatement.CurrentRow.Index].Cells[0];
            if (chk != null && Convert.ToBoolean(chk.Value) == true)
            {
                StatementConsolidate = GvStatement.Rows[e.RowIndex].Cells["StatementTransactionId"].Value.ToString();
            }
            else
            {
                StatementConsolidate = string.Empty;
            }

            foreach (DataGridViewRow row in GvStatement.Rows)
            {
                if (row.Index != e.RowIndex)
                    GvStatement.Rows[row.Index].SetValues(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StatementConsolidate)|| string.IsNullOrEmpty(PassbookConsolidate))
            {
                MessageBox.Show("Please select both Passbook and Statement data to Reconcil");
                return;
            }

            if (GvPassbookConsolidate.Columns.Count <= 0)
            {
                GvPassbookConsolidate.Columns.Add("BankTransactionId", "BankTransactionId");
                GvPassbookConsolidate.Columns.Add("Date", "Date");
                GvPassbookConsolidate.Columns.Add("ChequeNo", "ChequeNo");
                GvPassbookConsolidate.Columns.Add("Particular", "Particular");
                GvPassbookConsolidate.Columns.Add("Withdrawals", "Withdrawals");
                GvPassbookConsolidate.Columns.Add("Deposit", "Deposit");
                GvPassbookConsolidate.Columns.Add("DummyDate", "DummyDate");
                GvPassbookConsolidate.Columns.Add("BankGroupName", "BankGroupName");
            }

            GvPassbook.AllowUserToAddRows = false;

            DataGridViewRow row = GvPassbook.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["BankTransactionId"].Value.ToString().Equals(PassbookConsolidate))
            .First();

           



            if (GvStatementConsolidate.Columns.Count <= 0)
            {
                GvStatementConsolidate.Columns.Add("StatementTransactionId", "StatementTransactionId");
                GvStatementConsolidate.Columns.Add("Date", "Date");
                GvStatementConsolidate.Columns.Add("ChequeNo", "ChequeNo");
                GvStatementConsolidate.Columns.Add("Particular", "Particular");
                GvStatementConsolidate.Columns.Add("Withdrawals", "Withdrawals");
                GvStatementConsolidate.Columns.Add("Deposit", "Deposit");
                GvStatementConsolidate.Columns.Add("DummyDate", "DummyDate");
                GvStatementConsolidate.Columns.Add("BankGroupName", "BankGroupName");
            }


            GvStatement.AllowUserToAddRows = false;

            DataGridViewRow rowStatement = GvStatement.Rows
            .Cast<DataGridViewRow>()
            .Where(r => r.Cells["StatementTransactionId"].Value.ToString().Equals(StatementConsolidate))
            .First();


            int errorBit = 0;

                    if (!((string.IsNullOrEmpty(Convert.ToString( rowStatement.Cells["Withdrawals"].Value)) ? 0 : Convert.ToDecimal(rowStatement.Cells["Withdrawals"].Value)) == (string.IsNullOrEmpty(Convert.ToString(row.Cells["Withdrawals"].Value)) ? 0 : Convert.ToDecimal(row.Cells["Withdrawals"].Value))))
                    {
                            errorBit = 1;
                        error += "    Please check Withdrawal amount" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(rowStatement.Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(rowStatement.Cells["Deposit"].Value)) == (string.IsNullOrEmpty(Convert.ToString(row.Cells["Deposit"].Value)) ? 0 : Convert.ToDecimal(row.Cells["Deposit"].Value))))
                    {
                        errorBit = 1;
                        error += "    Please check Deposit amount" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(rowStatement.Cells["ChequeNo"].Value)) ? "" : rowStatement.Cells["ChequeNo"].Value.ToString()) == (string.IsNullOrEmpty(Convert.ToString(row.Cells["ChequeNo"].Value)) ? "" : row.Cells["ChequeNo"].Value.ToString())))
                    {
                        errorBit = 1;
                        error += "    Please check Cheque No" + Environment.NewLine;
                    }
                     if (!((string.IsNullOrEmpty(Convert.ToString(rowStatement.Cells["Date"].Value)) ? "" : rowStatement.Cells["Date"].Value.ToString()) == (string.IsNullOrEmpty(Convert.ToString(row.Cells["Date"].Value)) ? "" : row.Cells["Date"].Value.ToString())))
                     {
                         if (string.IsNullOrEmpty(row.Cells["ChequeNo"].Value.ToString()))
                         {
                             errorBit = 1;
                             error += "    Passbook date and Statement date are different" + Environment.NewLine;
                         }
                     }


                     if (errorBit == 0)
                     {
                         //DataGridViewRow row = (DataGridViewRow)rw.Clone();
                         DataTable dataTable = (DataTable)GvPassbookConsolidate.DataSource;
                         DataRow drToAdd = dataTable.NewRow();

                         for (int cell = 1; cell < row.Cells.Count; cell++)
                         {
                             drToAdd[cell - 1] = row.Cells[cell].Value;
                         }
                         GvPassbook.AllowUserToAddRows = true;
                         dataTable.Rows.InsertAt(drToAdd, 0);
                         dataTable.AcceptChanges();
                         GvPassbookConsolidate.DataSource = dataTable;
                         GvPassbook.Rows.Remove(row);




                         DataTable dataTableStatement = (DataTable)GvStatementConsolidate.DataSource;
                         DataRow drToAddStatement = dataTableStatement.NewRow();

                         for (int cell = 1; cell < rowStatement.Cells.Count; cell++)
                         {
                             drToAddStatement[cell - 1] = rowStatement.Cells[cell].Value;
                         }
                         GvStatement.AllowUserToAddRows = true;
                         dataTableStatement.Rows.InsertAt(drToAddStatement, 0);
                         dataTableStatement.AcceptChanges();
                         GvStatementConsolidate.DataSource = dataTableStatement;
                         GvStatement.Rows.Remove(rowStatement);

                         MessageBox.Show("Selected data added sucessfully");
                         StatementConsolidate = string.Empty;
                         PassbookConsolidate = string.Empty;
                     }
                     else
                     {
                         MessageBox.Show(error);
                     }
                    errorBit = 0;
                    error = string.Empty;
        }
    }
}
