namespace Bank
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CtrlBtnAppClose = new System.Windows.Forms.ToolStripButton();
            this.CtrlBtnMinimize = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Bank = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheqesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beneficiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffBeneficiaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditJSWBilling = new System.Windows.Forms.ToolStripMenuItem();
            this.jSWNotBilled = new System.Windows.Forms.ToolStripMenuItem();
            this.passbookOnAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statementOnAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconsilationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTGSFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffPaymentTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchOn = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnPassbookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnStatementsGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnPassbookGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchOnMonthWiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlBtnAppClose
            // 
            this.CtrlBtnAppClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CtrlBtnAppClose.Name = "CtrlBtnAppClose";
            this.CtrlBtnAppClose.Size = new System.Drawing.Size(40, 24);
            this.CtrlBtnAppClose.Text = "Close";
            this.CtrlBtnAppClose.ToolTipText = "Calculator";
            this.CtrlBtnAppClose.Click += new System.EventHandler(this.CtrlBtnAppClose_Click);
            // 
            // CtrlBtnMinimize
            // 
            this.CtrlBtnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.CtrlBtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnMinimize.FlatAppearance.BorderSize = 0;
            this.CtrlBtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CtrlBtnMinimize.Location = new System.Drawing.Point(758, 49);
            this.CtrlBtnMinimize.Name = "CtrlBtnMinimize";
            this.CtrlBtnMinimize.Size = new System.Drawing.Size(35, 31);
            this.CtrlBtnMinimize.TabIndex = 60;
            this.CtrlBtnMinimize.Text = "_";
            this.CtrlBtnMinimize.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.EditJSWBilling,
            this.toolStripMenuItem2,
            this.reportsToolStripMenuItem,
            this.calciToolStripMenuItem,
            this.CtrlBtnAppClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(823, 31);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "CtrlMainmenustrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Bank,
            this.toolStripMenuItem3,
            this.groupToolStripMenuItem,
            this.cheqesToolStripMenuItem,
            this.dashBoardToolStripMenuItem,
            this.beneficiaryToolStripMenuItem,
            this.staffCategoryToolStripMenuItem,
            this.staffBeneficiaryToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(77, 27);
            this.toolStripMenuItem1.Text = "Masters";
            // 
            // Bank
            // 
            this.Bank.Name = "Bank";
            this.Bank.Size = new System.Drawing.Size(180, 24);
            this.Bank.Text = "Bank";
            this.Bank.Click += new System.EventHandler(this.Bank_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 24);
            this.toolStripMenuItem3.Text = "Accounts";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.groupToolStripMenuItem.Text = "Group";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // cheqesToolStripMenuItem
            // 
            this.cheqesToolStripMenuItem.Name = "cheqesToolStripMenuItem";
            this.cheqesToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.cheqesToolStripMenuItem.Text = "Cheques";
            this.cheqesToolStripMenuItem.Click += new System.EventHandler(this.cheqesToolStripMenuItem_Click);
            // 
            // dashBoardToolStripMenuItem
            // 
            this.dashBoardToolStripMenuItem.Name = "dashBoardToolStripMenuItem";
            this.dashBoardToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.dashBoardToolStripMenuItem.Text = "Dash Board";
            this.dashBoardToolStripMenuItem.Click += new System.EventHandler(this.dashBoardToolStripMenuItem_Click);
            // 
            // beneficiaryToolStripMenuItem
            // 
            this.beneficiaryToolStripMenuItem.Name = "beneficiaryToolStripMenuItem";
            this.beneficiaryToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.beneficiaryToolStripMenuItem.Text = "Beneficiary";
            this.beneficiaryToolStripMenuItem.Click += new System.EventHandler(this.beneficiaryToolStripMenuItem_Click);
            // 
            // staffCategoryToolStripMenuItem
            // 
            this.staffCategoryToolStripMenuItem.Name = "staffCategoryToolStripMenuItem";
            this.staffCategoryToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.staffCategoryToolStripMenuItem.Text = "Staff Category";
            this.staffCategoryToolStripMenuItem.Click += new System.EventHandler(this.staffCategoryToolStripMenuItem_Click);
            // 
            // staffBeneficiaryToolStripMenuItem
            // 
            this.staffBeneficiaryToolStripMenuItem.Name = "staffBeneficiaryToolStripMenuItem";
            this.staffBeneficiaryToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.staffBeneficiaryToolStripMenuItem.Text = "Staff Account";
            this.staffBeneficiaryToolStripMenuItem.Click += new System.EventHandler(this.staffBeneficiaryToolStripMenuItem_Click);
            // 
            // EditJSWBilling
            // 
            this.EditJSWBilling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSWNotBilled,
            this.passbookOnAccountToolStripMenuItem,
            this.statementToolStripMenuItem,
            this.statementOnAccountToolStripMenuItem,
            this.reconsilationToolStripMenuItem,
            this.rTGSFormToolStripMenuItem,
            this.staffPaymentTransactionToolStripMenuItem});
            this.EditJSWBilling.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditJSWBilling.Name = "EditJSWBilling";
            this.EditJSWBilling.Size = new System.Drawing.Size(109, 27);
            this.EditJSWBilling.Text = "Transactions";
            // 
            // jSWNotBilled
            // 
            this.jSWNotBilled.Name = "jSWNotBilled";
            this.jSWNotBilled.Size = new System.Drawing.Size(263, 24);
            this.jSWNotBilled.Text = "Ledger";
            this.jSWNotBilled.Click += new System.EventHandler(this.jSWNotBilled_Click);
            // 
            // passbookOnAccountToolStripMenuItem
            // 
            this.passbookOnAccountToolStripMenuItem.Name = "passbookOnAccountToolStripMenuItem";
            this.passbookOnAccountToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.passbookOnAccountToolStripMenuItem.Text = "Ledger on Account";
            this.passbookOnAccountToolStripMenuItem.Click += new System.EventHandler(this.passbookOnAccountToolStripMenuItem_Click);
            // 
            // statementToolStripMenuItem
            // 
            this.statementToolStripMenuItem.Name = "statementToolStripMenuItem";
            this.statementToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.statementToolStripMenuItem.Text = "Statement";
            this.statementToolStripMenuItem.Click += new System.EventHandler(this.statementToolStripMenuItem_Click);
            // 
            // statementOnAccountToolStripMenuItem
            // 
            this.statementOnAccountToolStripMenuItem.Name = "statementOnAccountToolStripMenuItem";
            this.statementOnAccountToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.statementOnAccountToolStripMenuItem.Text = "Statement on Account";
            this.statementOnAccountToolStripMenuItem.Click += new System.EventHandler(this.statementOnAccountToolStripMenuItem_Click);
            // 
            // reconsilationToolStripMenuItem
            // 
            this.reconsilationToolStripMenuItem.Name = "reconsilationToolStripMenuItem";
            this.reconsilationToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.reconsilationToolStripMenuItem.Text = "Reconsilation";
            this.reconsilationToolStripMenuItem.Click += new System.EventHandler(this.reconsilationToolStripMenuItem_Click);
            // 
            // rTGSFormToolStripMenuItem
            // 
            this.rTGSFormToolStripMenuItem.Name = "rTGSFormToolStripMenuItem";
            this.rTGSFormToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.rTGSFormToolStripMenuItem.Text = "RTGS Form";
            this.rTGSFormToolStripMenuItem.Click += new System.EventHandler(this.rTGSFormToolStripMenuItem_Click);
            // 
            // staffPaymentTransactionToolStripMenuItem
            // 
            this.staffPaymentTransactionToolStripMenuItem.Name = "staffPaymentTransactionToolStripMenuItem";
            this.staffPaymentTransactionToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.staffPaymentTransactionToolStripMenuItem.Text = "Staff Payment Transaction";
            this.staffPaymentTransactionToolStripMenuItem.Click += new System.EventHandler(this.staffPaymentTransactionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchOn,
            this.searchOnPassbookToolStripMenuItem,
            this.searchOnStatementsGroupToolStripMenuItem,
            this.searchOnPassbookGroupToolStripMenuItem,
            this.searchOnMonthWiseToolStripMenuItem});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(76, 27);
            this.toolStripMenuItem2.Text = "Reports";
            // 
            // SearchOn
            // 
            this.SearchOn.Name = "SearchOn";
            this.SearchOn.Size = new System.Drawing.Size(280, 24);
            this.SearchOn.Text = "Search On Statements";
            this.SearchOn.Click += new System.EventHandler(this.SearchOn_Click);
            // 
            // searchOnPassbookToolStripMenuItem
            // 
            this.searchOnPassbookToolStripMenuItem.Name = "searchOnPassbookToolStripMenuItem";
            this.searchOnPassbookToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.searchOnPassbookToolStripMenuItem.Text = "Search On Passbook";
            this.searchOnPassbookToolStripMenuItem.Click += new System.EventHandler(this.searchOnPassbookToolStripMenuItem_Click);
            // 
            // searchOnStatementsGroupToolStripMenuItem
            // 
            this.searchOnStatementsGroupToolStripMenuItem.Name = "searchOnStatementsGroupToolStripMenuItem";
            this.searchOnStatementsGroupToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.searchOnStatementsGroupToolStripMenuItem.Text = "Search On Statements Group";
            this.searchOnStatementsGroupToolStripMenuItem.Click += new System.EventHandler(this.searchOnStatementsGroupToolStripMenuItem_Click);
            // 
            // searchOnPassbookGroupToolStripMenuItem
            // 
            this.searchOnPassbookGroupToolStripMenuItem.Name = "searchOnPassbookGroupToolStripMenuItem";
            this.searchOnPassbookGroupToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.searchOnPassbookGroupToolStripMenuItem.Text = "Search On Passbook Group";
            this.searchOnPassbookGroupToolStripMenuItem.Click += new System.EventHandler(this.searchOnPassbookGroupToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(12, 27);
            // 
            // calciToolStripMenuItem
            // 
            this.calciToolStripMenuItem.Name = "calciToolStripMenuItem";
            this.calciToolStripMenuItem.Size = new System.Drawing.Size(45, 27);
            this.calciToolStripMenuItem.Text = "Calci";
            this.calciToolStripMenuItem.Click += new System.EventHandler(this.calciToolStripMenuItem_Click);
            // 
            // searchOnMonthWiseToolStripMenuItem
            // 
            this.searchOnMonthWiseToolStripMenuItem.Name = "searchOnMonthWiseToolStripMenuItem";
            this.searchOnMonthWiseToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.searchOnMonthWiseToolStripMenuItem.Text = "Search On MonthWise";
            this.searchOnMonthWiseToolStripMenuItem.Click += new System.EventHandler(this.searchOnMonthWiseToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 340);
            this.Controls.Add(this.CtrlBtnMinimize);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Bank";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton CtrlBtnAppClose;
        private System.Windows.Forms.Button CtrlBtnMinimize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EditJSWBilling;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSWNotBilled;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Bank;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passbookOnAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statementOnAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheqesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconsilationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SearchOn;
        private System.Windows.Forms.ToolStripMenuItem searchOnPassbookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beneficiaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTGSFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffBeneficiaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOnStatementsGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOnPassbookGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffPaymentTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchOnMonthWiseToolStripMenuItem;
    }
}