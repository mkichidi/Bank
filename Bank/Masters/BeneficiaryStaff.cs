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

namespace Bank.Masters
{
    public partial class BeneficiaryStaff : Form
    {
        string EditId = string.Empty;
        List<string> paths = new List<string>();
        DataTable backup = new DataTable();
        public BeneficiaryStaff()
        {
            InitializeComponent();
            IncrementDestination();
            BindGrid();
            BindDropdown();
        }

        private void BindDropdown()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("ShipmentDropDown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataRow row = (ds.Tables[0]).NewRow();
            row["VehicleNo"] = "-Select-";
            ds.Tables[0].Rows.InsertAt(row, 0);
            DdlVehicle.DataSource = new DataView(ds.Tables[0]);
            DdlVehicle.DisplayMember = "VehicleNo";
            DdlVehicle.ValueMember = "VehicleID";
            DdlVehicle.SelectedIndex = 0;


             con = new SqlConnection(Connection.InvAdminConn());
             cmd = new SqlCommand("GetStaffCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
             adapter = new SqlDataAdapter(cmd);
             ds = new DataSet();
            adapter.Fill(ds);

             row = (ds.Tables[0]).NewRow();
             row["Category Name"] = "-Select-";
            ds.Tables[0].Rows.InsertAt(row, 0);
            DdlCategory.DataSource = new DataView(ds.Tables[0]);
            DdlCategory.DisplayMember = "Category Name";
            DdlCategory.ValueMember = "ID";
            DdlCategory.SelectedIndex = 0;

        }

        public void IncrementDestination()
        {
            SqlConnection con = new SqlConnection(Connection.InvAdminConn());
            SqlCommand cmd = new SqlCommand("GetMaxBankStaffAccountID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            TxtBankID.Text = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        [DllImport("advapi32.DLL", SetLastError = true)]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

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
            else if (DdlVehicle.SelectedIndex < 1)
            {
                MessageBox.Show("Please select Category");
                txtIFSC.Focus();
                return;
            }
            else if (DdlCategory.SelectedIndex<1)
            {
                MessageBox.Show("Please select Category");
                txtIFSC.Focus();
                return;
            }

            if (string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("InsertBankStaffAccount", con);
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

                cmd.Parameters.AddWithValue("@Name", TxtName.Text);
                cmd.Parameters.AddWithValue("@VehicleID", DdlVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@DLNo", TxtDlNo.Text);
                cmd.Parameters.AddWithValue("@DLExpDate", DtExpDate.Text);
                cmd.Parameters.AddWithValue("@Category", DdlCategory.SelectedValue);


                string pathToSave = string.Empty;

                foreach (string path in paths)
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        continue;
                    }

                    pathToSave += "\\\\admin-bv\\Manoj\\DocumentsData" + "\\" + path.Split('\\')[path.Split('\\').Count() - 1];
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    try
                    {
                        if (LogonUser("mk", "admin-bv", "mk", 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();

                            if (@"\\admin-bv\Manoj\DocumentsData" + @"\" + path.Split('\\')[path.Split('\\').Count() - 1] != path)
                                System.IO.File.Copy(path, @"\\admin-bv\Manoj\DocumentsData" + @"\" + path.Split('\\')[path.Split('\\').Count() - 1], true);
                        }
                        else
                        {
                            MessageBox.Show("Copy Failed");
                        }
                    }
                    catch (System.Exception se)
                    {
                        int ret = Marshal.GetLastWin32Error();
                        MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString());
                        MessageBox.Show(se.Message);
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                }
                cmd.Parameters.AddWithValue("@Documents", pathToSave);

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
                SqlCommand cmd = new SqlCommand("UpdateBankStaffAccount", con);
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

                cmd.Parameters.AddWithValue("@Name", TxtName.Text);
                cmd.Parameters.AddWithValue("@VehicleID", DdlVehicle.SelectedValue);
                cmd.Parameters.AddWithValue("@DLNo", TxtDlNo.Text);
                cmd.Parameters.AddWithValue("@DLExpDate", DtExpDate.Text);
                cmd.Parameters.AddWithValue("@Category", DdlCategory.SelectedValue);


                string pathToSave = string.Empty;

                foreach (string path in paths)
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        continue;
                    }


                    pathToSave += "\\\\admin-bv\\Manoj\\DocumentsData" + "\\" + path.Split('\\')[path.Split('\\').Count() - 1];
                    IntPtr admin_token = default(IntPtr);
                    WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                    WindowsIdentity wid_admin = null;
                    WindowsImpersonationContext wic = null;
                    try
                    {
                        if (LogonUser("mk", "admin-bv", "mk", 9, 0, ref admin_token) != 0)
                        {
                            wid_admin = new WindowsIdentity(admin_token);
                            wic = wid_admin.Impersonate();

                            if (@"\\admin-bv\Manoj\DocumentsData" + @"\" + path.Split('\\')[path.Split('\\').Count() - 1] != path)
                                System.IO.File.Copy(path, @"\\admin-bv\Manoj\DocumentsData" + @"\" + path.Split('\\')[path.Split('\\').Count() - 1], true);

                        }
                        else
                        {
                            MessageBox.Show("Copy Failed");
                        }
                    }
                    catch (System.Exception se)
                    {
                        int ret = Marshal.GetLastWin32Error();
                        MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString());
                        MessageBox.Show(se.Message);
                    }
                    finally
                    {
                        if (wic != null)
                        {
                            wic.Undo();
                        }
                    }
                }
                cmd.Parameters.AddWithValue("@Documents", pathToSave);

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
            SqlCommand cmd = new SqlCommand("GetBankStaffAccount", con);
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
            txtIFSC.Text = string.Empty;
            TxtMobileNo.Text = string.Empty;
            TxtBank.Text = string.Empty;
            paths = new System.Collections.Generic.List<string>();
            txtCity.Text = string.Empty;

           TxtName.Text= string.Empty;
             DdlVehicle.SelectedIndex= 0;
             TxtDlNo.Text= string.Empty;
           DtExpDate.Text= string.Empty;
             TxtDocuments.Text= string.Empty;
             DdlCategory.SelectedIndex =0;
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EditId))
            {
                SqlConnection con = new SqlConnection(Connection.InvAdminConn());
                SqlCommand cmd = new SqlCommand("GetBankStaffAccountOnId", con);
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
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    TxtBranch.Text = Convert.ToString(dataTable.Rows[0]["Branch"]);
                    TxtBank.Text = Convert.ToString(dataTable.Rows[0]["Bank"]);
                    txtIFSC.Text = Convert.ToString(dataTable.Rows[0]["IFSC"]);
                    TxtDescription.Text = Convert.ToString(dataTable.Rows[0]["Description"]);
                    txtCity.Text = Convert.ToString(dataTable.Rows[0]["City"]);
                    TxtMobileNo.Text = Convert.ToString(dataTable.Rows[0]["MobileNo"]);

                    TxtName.Text = Convert.ToString(dataTable.Rows[0]["Name"]);
                    DdlVehicle.SelectedValue = Convert.ToString(dataTable.Rows[0]["VehicleID"]);
                    DdlCategory.SelectedValue = Convert.ToString(dataTable.Rows[0]["Category"]);
                    TxtDlNo.Text = Convert.ToString(dataTable.Rows[0]["DLNo"]);
                    TxtDocuments.Text = Convert.ToString(dataTable.Rows[0]["Documents"]);
                    DtExpDate.Value = Convert.ToDateTime(dataTable.Rows[0]["DLExpDate"]);


                    paths = new List<string>();
                    paths.Add(Convert.ToString(dataTable.Rows[0]["Documents"]));
                    TxtDocuments.Text = string.Empty;
                    for (int i = 0; i < paths.Count(); i++)
                    {
                        TxtDocuments.Text = paths[i].Split('\\')[paths[i].Split('\\').Count() - 1];
                    }

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
                GvDestination.DataSource = backup.Select("[Name] Like '%" + TxtBankSearch.Text + "%'").Any() ? backup.Select("[Name] Like '%" + TxtBankSearch.Text + "%'").CopyToDataTable() : backup.Clone();
            }
            else
            {
                GvDestination.DataSource = backup;
            }
        }

        private void BtnAddDocuments_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = false;
            op.ShowDialog();
            paths = new List<string>();
            for (int i = 0; i < op.FileNames.Count(); i++)
            {
                TxtDocuments.Text = op.SafeFileNames[i] + Environment.NewLine;
                paths.Add(Convert.ToString(op.FileNames[i]));
            }
        }

        private void BtnViewDocuments_Click(object sender, EventArgs e)
        {
            if (paths.Count > 0 && (!string.IsNullOrEmpty(TxtDocuments.Text)))
            {
                JswDatatable.PdFPath = paths[0];
                //OStDatatable.paths = paths;
                //Slider Slider = new Slider();
                //Slider.Show();
                PDFViwer PDFViwer = new PDFViwer();
                PDFViwer.Show();
            }
            else
            {
                MessageBox.Show("Please select documents to view");
            }
        }
    }
}
