namespace Bank
{
    partial class PassBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.GvShipment = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtShipmentID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtDate = new System.Windows.Forms.DateTimePicker();
            this.TxtWithdraw = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtDeposit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtChequeNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxtBalance = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DdlBankGroup = new System.Windows.Forms.ComboBox();
            this.TxtUploadfile = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.DownloadFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtGroupSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtChequeNoSearch = new System.Windows.Forms.TextBox();
            this.DtTo = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtParticular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DdlAccount = new System.Windows.Forms.ComboBox();
            this.TxtBalanceCalculated = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnEdit,
            this.tsBtnSave,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(921, 39);
            this.toolStrip1.TabIndex = 123;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnNew
            // 
            this.tsBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNew.Image")));
            this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNew.Name = "tsBtnNew";
            this.tsBtnNew.Size = new System.Drawing.Size(67, 36);
            this.tsBtnNew.Text = "&New";
            this.tsBtnNew.ToolTipText = "New";
            this.tsBtnNew.Click += new System.EventHandler(this.tsBtnNew_Click);
            // 
            // tsBtnEdit
            // 
            this.tsBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEdit.Image")));
            this.tsBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEdit.Name = "tsBtnEdit";
            this.tsBtnEdit.Size = new System.Drawing.Size(63, 36);
            this.tsBtnEdit.Text = "&Edit";
            this.tsBtnEdit.ToolTipText = "Edit";
            this.tsBtnEdit.Click += new System.EventHandler(this.tsBtnEdit_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(67, 36);
            this.tsBtnSave.Text = "&Save";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 36);
            this.toolStripButton1.Text = "E&xit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // GvShipment
            // 
            this.GvShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvShipment.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvShipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvShipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvShipment.Location = new System.Drawing.Point(15, 41);
            this.GvShipment.Name = "GvShipment";
            this.GvShipment.Size = new System.Drawing.Size(873, 212);
            this.GvShipment.TabIndex = 125;
            this.GvShipment.SelectionChanged += new System.EventHandler(this.GvShipment_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Tan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(23, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 124;
            this.label4.Text = "Ledger";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 119;
            this.label2.Text = "Ledger ID";
            // 
            // TxtShipmentID
            // 
            this.TxtShipmentID.Enabled = false;
            this.TxtShipmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShipmentID.Location = new System.Drawing.Point(185, 98);
            this.TxtShipmentID.Name = "TxtShipmentID";
            this.TxtShipmentID.Size = new System.Drawing.Size(100, 24);
            this.TxtShipmentID.TabIndex = 120;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(99, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 143;
            this.label9.Text = "Account no";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(410, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 18);
            this.label10.TabIndex = 141;
            this.label10.Text = "Date";
            // 
            // TxtDate
            // 
            this.TxtDate.Location = new System.Drawing.Point(451, 96);
            this.TxtDate.Name = "TxtDate";
            this.TxtDate.Size = new System.Drawing.Size(115, 20);
            this.TxtDate.TabIndex = 1;
            // 
            // TxtWithdraw
            // 
            this.TxtWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWithdraw.Location = new System.Drawing.Point(720, 173);
            this.TxtWithdraw.Name = "TxtWithdraw";
            this.TxtWithdraw.Size = new System.Drawing.Size(167, 24);
            this.TxtWithdraw.TabIndex = 6;
            this.TxtWithdraw.TextChanged += new System.EventHandler(this.TxtWithdraw_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(644, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 18);
            this.label12.TabIndex = 149;
            this.label12.Text = "Withdraw";
            // 
            // TxtDeposit
            // 
            this.TxtDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDeposit.Location = new System.Drawing.Point(720, 137);
            this.TxtDeposit.Name = "TxtDeposit";
            this.TxtDeposit.Size = new System.Drawing.Size(167, 24);
            this.TxtDeposit.TabIndex = 5;
            this.TxtDeposit.TextChanged += new System.EventHandler(this.TxtDeposit_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(652, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 18);
            this.label13.TabIndex = 147;
            this.label13.Text = "Deposit";
            // 
            // TxtChequeNo
            // 
            this.TxtChequeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequeNo.Location = new System.Drawing.Point(720, 98);
            this.TxtChequeNo.Name = "TxtChequeNo";
            this.TxtChequeNo.Size = new System.Drawing.Size(167, 24);
            this.TxtChequeNo.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(632, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 18);
            this.label14.TabIndex = 145;
            this.label14.Text = "Cheque No";
            // 
            // TxtBalance
            // 
            this.TxtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalance.Location = new System.Drawing.Point(720, 211);
            this.TxtBalance.Name = "TxtBalance";
            this.TxtBalance.ReadOnly = true;
            this.TxtBalance.Size = new System.Drawing.Size(167, 24);
            this.TxtBalance.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(648, 214);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 18);
            this.label20.TabIndex = 162;
            this.label20.Text = "Balance";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(399, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 18);
            this.label15.TabIndex = 165;
            this.label15.Text = "Group";
            // 
            // DdlBankGroup
            // 
            this.DdlBankGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlBankGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlBankGroup.FormattingEnabled = true;
            this.DdlBankGroup.Location = new System.Drawing.Point(451, 214);
            this.DdlBankGroup.Name = "DdlBankGroup";
            this.DdlBankGroup.Size = new System.Drawing.Size(121, 21);
            this.DdlBankGroup.TabIndex = 8;
            // 
            // TxtUploadfile
            // 
            this.TxtUploadfile.Enabled = false;
            this.TxtUploadfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUploadfile.Location = new System.Drawing.Point(334, 303);
            this.TxtUploadfile.Name = "TxtUploadfile";
            this.TxtUploadfile.Size = new System.Drawing.Size(253, 24);
            this.TxtUploadfile.TabIndex = 12;
            this.TxtUploadfile.TextChanged += new System.EventHandler(this.TxtUploadfile_TextChanged);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(585, 303);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 13;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(676, 303);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 14;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // DownloadFile
            // 
            this.DownloadFile.Location = new System.Drawing.Point(217, 303);
            this.DownloadFile.Name = "DownloadFile";
            this.DownloadFile.Size = new System.Drawing.Size(75, 23);
            this.DownloadFile.TabIndex = 11;
            this.DownloadFile.Text = "Download";
            this.DownloadFile.UseVisualStyleBackColor = true;
            this.DownloadFile.Click += new System.EventHandler(this.DownloadFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtGroupSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.GvShipment);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.TxtChequeNoSearch);
            this.groupBox1.Controls.Add(this.DtTo);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.DtFrom);
            this.groupBox1.Location = new System.Drawing.Point(13, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(897, 262);
            this.groupBox1.TabIndex = 170;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(692, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 192;
            this.label6.Text = "To";
            // 
            // TxtGroupSearch
            // 
            this.TxtGroupSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtGroupSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TxtGroupSearch.FormattingEnabled = true;
            this.TxtGroupSearch.Location = new System.Drawing.Point(374, 14);
            this.TxtGroupSearch.Name = "TxtGroupSearch";
            this.TxtGroupSearch.Size = new System.Drawing.Size(121, 21);
            this.TxtGroupSearch.TabIndex = 181;
            this.TxtGroupSearch.SelectedIndexChanged += new System.EventHandler(this.TxtGroupSearch_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(526, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 189;
            this.label5.Text = "Date";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(318, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 18);
            this.label18.TabIndex = 175;
            this.label18.Text = "Group";
            // 
            // TxtChequeNoSearch
            // 
            this.TxtChequeNoSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequeNoSearch.Location = new System.Drawing.Point(177, 13);
            this.TxtChequeNoSearch.Name = "TxtChequeNoSearch";
            this.TxtChequeNoSearch.Size = new System.Drawing.Size(108, 24);
            this.TxtChequeNoSearch.TabIndex = 19;
            this.TxtChequeNoSearch.TextChanged += new System.EventHandler(this.TxtShipmentSearch_TextChanged);
            // 
            // DtTo
            // 
            this.DtTo.Location = new System.Drawing.Point(724, 14);
            this.DtTo.Name = "DtTo";
            this.DtTo.Size = new System.Drawing.Size(115, 20);
            this.DtTo.TabIndex = 191;
            this.DtTo.ValueChanged += new System.EventHandler(this.DtTo_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(88, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 18);
            this.label21.TabIndex = 174;
            this.label21.Text = "Cheque No";
            // 
            // DtFrom
            // 
            this.DtFrom.Location = new System.Drawing.Point(571, 14);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Size = new System.Drawing.Size(115, 20);
            this.DtFrom.TabIndex = 190;
            this.DtFrom.ValueChanged += new System.EventHandler(this.DtFrom_ValueChanged);
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescription.Location = new System.Drawing.Point(451, 136);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(158, 60);
            this.TxtDescription.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 178;
            this.label1.Text = "Description";
            // 
            // TxtParticular
            // 
            this.TxtParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParticular.Location = new System.Drawing.Point(185, 137);
            this.TxtParticular.Multiline = true;
            this.TxtParticular.Name = "TxtParticular";
            this.TxtParticular.Size = new System.Drawing.Size(158, 60);
            this.TxtParticular.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 180;
            this.label3.Text = "Particular";
            // 
            // DdlAccount
            // 
            this.DdlAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlAccount.FormattingEnabled = true;
            this.DdlAccount.Location = new System.Drawing.Point(185, 213);
            this.DdlAccount.Name = "DdlAccount";
            this.DdlAccount.Size = new System.Drawing.Size(158, 21);
            this.DdlAccount.TabIndex = 7;
            this.DdlAccount.SelectedIndexChanged += new System.EventHandler(this.DdlAccount_SelectedIndexChanged);
            // 
            // TxtBalanceCalculated
            // 
            this.TxtBalanceCalculated.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBalanceCalculated.Location = new System.Drawing.Point(185, 251);
            this.TxtBalanceCalculated.Name = "TxtBalanceCalculated";
            this.TxtBalanceCalculated.Size = new System.Drawing.Size(167, 24);
            this.TxtBalanceCalculated.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 18);
            this.label7.TabIndex = 182;
            this.label7.Text = "Balance Calculated";
            // 
            // PassBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 620);
            this.Controls.Add(this.TxtBalanceCalculated);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtParticular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DownloadFile);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.TxtUploadfile);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.DdlBankGroup);
            this.Controls.Add(this.TxtBalance);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TxtWithdraw);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtDeposit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TxtChequeNo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TxtDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DdlAccount);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtShipmentID);
            this.Name = "PassBook";
            this.Text = "Ledger";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvShipment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsBtnEdit;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.DataGridView GvShipment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtShipmentID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker TxtDate;
        private System.Windows.Forms.TextBox TxtWithdraw;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtDeposit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtChequeNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtBalance;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox DdlBankGroup;
        private System.Windows.Forms.TextBox TxtUploadfile;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button DownloadFile;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtParticular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtChequeNoSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox TxtGroupSearch;
        private System.Windows.Forms.ComboBox DdlAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtTo;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private System.Windows.Forms.TextBox TxtBalanceCalculated;
        private System.Windows.Forms.Label label7;
    }
}