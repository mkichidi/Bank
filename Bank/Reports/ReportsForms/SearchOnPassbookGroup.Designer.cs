namespace Bank.Reports.ReportForms
{
    partial class SearchOnPassbookGroup
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
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TSxtSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.DdlAccount = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.CmbBank = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.DdlAccountHolder = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.DdlGroup = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkDetails = new System.Windows.Forms.CheckBox();
            this.TxtNickName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DdlAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlAccountHolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 214;
            this.label8.Text = "Account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(333, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 212;
            this.label5.Text = "Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(625, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 216;
            this.label1.Text = "Account Holder";
            // 
            // TSxtSearch
            // 
            this.TSxtSearch.Location = new System.Drawing.Point(1000, 103);
            this.TSxtSearch.Name = "TSxtSearch";
            this.TSxtSearch.Size = new System.Drawing.Size(75, 23);
            this.TSxtSearch.TabIndex = 218;
            this.TSxtSearch.Text = "Search";
            this.TSxtSearch.UseVisualStyleBackColor = true;
            this.TSxtSearch.Click += new System.EventHandler(this.TSxtSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1111, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 219;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 220;
            this.label2.Text = "Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(727, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 227;
            this.label4.Text = "To";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(759, 106);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(115, 20);
            this.dtTo.TabIndex = 226;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(466, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 18);
            this.label6.TabIndex = 225;
            this.label6.Text = "Transaction Date";
            // 
            // DtFrom
            // 
            this.DtFrom.Location = new System.Drawing.Point(606, 106);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Size = new System.Drawing.Size(115, 20);
            this.DtFrom.TabIndex = 224;
            // 
            // DdlAccount
            // 
            this.DdlAccount.EditValue = "";
            this.DdlAccount.Location = new System.Drawing.Point(86, 67);
            this.DdlAccount.Name = "DdlAccount";
            this.DdlAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlAccount.Size = new System.Drawing.Size(223, 20);
            this.DdlAccount.TabIndex = 228;
            this.DdlAccount.EditValueChanged += new System.EventHandler(this.DdlDestination_EditValueChanged);
            // 
            // CmbBank
            // 
            this.CmbBank.EditValue = "";
            this.CmbBank.Location = new System.Drawing.Point(381, 67);
            this.CmbBank.Name = "CmbBank";
            this.CmbBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbBank.Size = new System.Drawing.Size(225, 20);
            this.CmbBank.TabIndex = 229;
            this.CmbBank.EditValueChanged += new System.EventHandler(this.CmbProduct_EditValueChanged);
            // 
            // DdlAccountHolder
            // 
            this.DdlAccountHolder.EditValue = "";
            this.DdlAccountHolder.Location = new System.Drawing.Point(741, 68);
            this.DdlAccountHolder.Name = "DdlAccountHolder";
            this.DdlAccountHolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlAccountHolder.Size = new System.Drawing.Size(219, 20);
            this.DdlAccountHolder.TabIndex = 230;
            this.DdlAccountHolder.EditValueChanged += new System.EventHandler(this.DdlCustomer_EditValueChanged);
            // 
            // DdlGroup
            // 
            this.DdlGroup.EditValue = "";
            this.DdlGroup.Location = new System.Drawing.Point(137, 105);
            this.DdlGroup.Name = "DdlGroup";
            this.DdlGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DdlGroup.Size = new System.Drawing.Size(295, 20);
            this.DdlGroup.TabIndex = 231;
            this.DdlGroup.EditValueChanged += new System.EventHandler(this.DdlVehicle_EditValueChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bank.Reports.Rdlc.SearchOnGroup.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 145);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1216, 366);
            this.reportViewer1.TabIndex = 232;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Tan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(38, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 25);
            this.label3.TabIndex = 233;
            this.label3.Text = "Search On Passbook Group";
            // 
            // ChkDetails
            // 
            this.ChkDetails.AutoSize = true;
            this.ChkDetails.Location = new System.Drawing.Point(909, 108);
            this.ChkDetails.Name = "ChkDetails";
            this.ChkDetails.Size = new System.Drawing.Size(58, 17);
            this.ChkDetails.TabIndex = 234;
            this.ChkDetails.Text = "Details";
            this.ChkDetails.UseVisualStyleBackColor = true;
            // 
            // TxtNickName
            // 
            this.TxtNickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNickName.Location = new System.Drawing.Point(1059, 67);
            this.TxtNickName.Name = "TxtNickName";
            this.TxtNickName.Size = new System.Drawing.Size(172, 24);
            this.TxtNickName.TabIndex = 235;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(974, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 236;
            this.label9.Text = "Nick Name";
            // 
            // SearchOnPassbookGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 523);
            this.Controls.Add(this.TxtNickName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ChkDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.DdlGroup);
            this.Controls.Add(this.DdlAccountHolder);
            this.Controls.Add(this.CmbBank);
            this.Controls.Add(this.DdlAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TSxtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Name = "SearchOnPassbookGroup";
            this.Text = "Search On Passbook Group";
            this.Load += new System.EventHandler(this.SearchOn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DdlAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlAccountHolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdlGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        //private JswBill JswBill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TSxtSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlAccount;
        private DevExpress.XtraEditors.CheckedComboBoxEdit CmbBank;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlAccountHolder;
        private DevExpress.XtraEditors.CheckedComboBoxEdit DdlGroup;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkDetails;
        private System.Windows.Forms.TextBox TxtNickName;
        private System.Windows.Forms.Label label9;
    }
}