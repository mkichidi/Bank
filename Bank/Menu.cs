using Bank.Reports.ReportForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
          
        }

        private bool CheckForDuplicateForm(Form newForm)
        {
            bool bValue = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == newForm.GetType())
                {
                    frm.Activate();
                    bValue = true;
                }
            }
            return bValue;
        }

        private void Bank_Click(object sender, EventArgs e)
        {
            Bank.Masters.Bank Bank = new Bank.Masters.Bank();
            bool frmPresent = CheckForDuplicateForm(Bank);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Bank.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Bank.Masters.Accounts Accounts = new Bank.Masters.Accounts();
            bool frmPresent = CheckForDuplicateForm(Accounts);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Accounts.Show();
            }
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Masters.Group Group = new Bank.Masters.Group();
            bool frmPresent = CheckForDuplicateForm(Group);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Group.Show();
            }
        }

        private void jSWNotBilled_Click(object sender, EventArgs e)
        {
            Bank.PassBook PassBook = new Bank.PassBook();
            bool frmPresent = CheckForDuplicateForm(PassBook);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                PassBook.Show();
            }
        }

        private void passbookOnAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.AccountPopup AccountPopup = new Bank.AccountPopup();
            bool frmPresent = CheckForDuplicateForm(AccountPopup);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                JswDatatable.navigator = "passbook";
                AccountPopup.Show();
            }
        }

        private void statementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Statement Statement = new Bank.Statement();
            bool frmPresent = CheckForDuplicateForm(Statement);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Statement.Show();
            }
        }

        private void statementOnAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.AccountPopup AccountPopup = new Bank.AccountPopup();
            bool frmPresent = CheckForDuplicateForm(AccountPopup);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                JswDatatable.navigator = "statement";
                AccountPopup.Show();
            }
        }

        private void CtrlBtnAppClose_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Do you want to Close Application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void calciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void cheqesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Masters.Cheques Cheques = new Bank.Masters.Cheques();
            bool frmPresent = CheckForDuplicateForm(Cheques);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Cheques.Show();
            }
        }

        private void reconsilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Reconcillation Reconcillation = new Bank.Reconcillation();
            bool frmPresent = CheckForDuplicateForm(Reconcillation);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Reconcillation.Show();
            }
        }

        private void SearchOn_Click(object sender, EventArgs e)
        {
            Bank.Reports.ReportForms.SearchOn SearchOn = new Bank.Reports.ReportForms.SearchOn();
            bool frmPresent = CheckForDuplicateForm(SearchOn);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SearchOn.Show();
            }
        }

        private void searchOnPassbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Reports.ReportForms.SearchOnPassbook SearchOn = new Bank.Reports.ReportForms.SearchOnPassbook();
            bool frmPresent = CheckForDuplicateForm(SearchOn);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SearchOn.Show();
            }
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.DashBoard SearchOn = new Bank.DashBoard();
            bool frmPresent = CheckForDuplicateForm(SearchOn);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                SearchOn.Show();
            }
        }

        private void beneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Masters.Beneficiary Beneficiary = new Bank.Masters.Beneficiary();
            bool frmPresent = CheckForDuplicateForm(Beneficiary);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                Beneficiary.Show();
            }
        }

        private void rTGSFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.RTGSForm RTGSForm = new Bank.RTGSForm();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void staffCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Masters.StaffMaster RTGSForm = new Bank.Masters.StaffMaster();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void staffBeneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Masters.BeneficiaryStaff RTGSForm = new Bank.Masters.BeneficiaryStaff();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void searchOnStatementsGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Reports.ReportForms.SearchOnSatatementsGroup RTGSForm = new Bank.Reports.ReportForms.SearchOnSatatementsGroup();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void searchOnPassbookGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bank.Reports.ReportForms.SearchOnPassbookGroup RTGSForm = new Bank.Reports.ReportForms.SearchOnPassbookGroup();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void staffPaymentTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masters.StaffTransaction RTGSForm = new Masters.StaffTransaction();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }

        private void searchOnMonthWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SearchOnSatatementsGroupOnAccountHolder RTGSForm = new SearchOnSatatementsGroupOnAccountHolder();
            bool frmPresent = CheckForDuplicateForm(RTGSForm);
            if (frmPresent)
                return;
            else if (!frmPresent)
            {
                RTGSForm.Show();
            }
        }
    }
}
