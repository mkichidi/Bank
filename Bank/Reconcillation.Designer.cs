namespace Bank
{
    partial class Reconcillation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reconcillation));
            this.label9 = new System.Windows.Forms.Label();
            this.DdlAccount = new System.Windows.Forms.ComboBox();
            this.GvPassbook = new System.Windows.Forms.DataGridView();
            this.GvStatement = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtChequeNoSearch = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtGroupSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DtTo = new System.Windows.Forms.DateTimePicker();
            this.DtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtChequeNoSearchStatement = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtGroupSearchStatement = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DtToStatement = new System.Windows.Forms.DateTimePicker();
            this.DtFromStatement = new System.Windows.Forms.DateTimePicker();
            this.GvStatementConsolidate = new System.Windows.Forms.DataGridView();
            this.GvPassbookConsolidate = new System.Windows.Forms.DataGridView();
            this.CtrlBtnPrintBill = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.TxtDeposite = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtWithdraw = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtWithdrawStatement = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtDepositeStatement = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GvPassbook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvStatementConsolidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvPassbookConsolidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(321, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 145;
            this.label9.Text = "Account no";
            // 
            // DdlAccount
            // 
            this.DdlAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DdlAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DdlAccount.FormattingEnabled = true;
            this.DdlAccount.Location = new System.Drawing.Point(407, 3);
            this.DdlAccount.Name = "DdlAccount";
            this.DdlAccount.Size = new System.Drawing.Size(244, 21);
            this.DdlAccount.TabIndex = 144;
            this.DdlAccount.SelectedIndexChanged += new System.EventHandler(this.DdlAccount_SelectedIndexChanged);
            // 
            // GvPassbook
            // 
            this.GvPassbook.AllowDrop = true;
            this.GvPassbook.AllowUserToAddRows = false;
            this.GvPassbook.AllowUserToDeleteRows = false;
            this.GvPassbook.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvPassbook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GvPassbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvPassbook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvPassbook.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvPassbook.Location = new System.Drawing.Point(0, 0);
            this.GvPassbook.Name = "GvPassbook";
            this.GvPassbook.Size = new System.Drawing.Size(440, 228);
            this.GvPassbook.TabIndex = 146;
            this.GvPassbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvPassbook_CellContentClick);
            // 
            // GvStatement
            // 
            this.GvStatement.AllowDrop = true;
            this.GvStatement.AllowUserToAddRows = false;
            this.GvStatement.AllowUserToDeleteRows = false;
            this.GvStatement.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvStatement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvStatement.Location = new System.Drawing.Point(0, 0);
            this.GvStatement.Name = "GvStatement";
            this.GvStatement.Size = new System.Drawing.Size(438, 228);
            this.GvStatement.TabIndex = 147;
            this.GvStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvStatement_CellContentClick);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(258, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 18);
            this.label18.TabIndex = 195;
            this.label18.Text = "Group";
            // 
            // TxtChequeNoSearch
            // 
            this.TxtChequeNoSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequeNoSearch.Location = new System.Drawing.Point(117, 14);
            this.TxtChequeNoSearch.Name = "TxtChequeNoSearch";
            this.TxtChequeNoSearch.Size = new System.Drawing.Size(108, 24);
            this.TxtChequeNoSearch.TabIndex = 193;
            this.TxtChequeNoSearch.TextChanged += new System.EventHandler(this.TxtChequeNoSearch_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(28, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 18);
            this.label21.TabIndex = 194;
            this.label21.Text = "Cheque No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 200;
            this.label6.Text = "To";
            // 
            // TxtGroupSearch
            // 
            this.TxtGroupSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtGroupSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TxtGroupSearch.FormattingEnabled = true;
            this.TxtGroupSearch.Location = new System.Drawing.Point(314, 14);
            this.TxtGroupSearch.Name = "TxtGroupSearch";
            this.TxtGroupSearch.Size = new System.Drawing.Size(121, 21);
            this.TxtGroupSearch.TabIndex = 196;
            this.TxtGroupSearch.SelectedIndexChanged += new System.EventHandler(this.TxtGroupSearch_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 197;
            this.label5.Text = "Date";
            // 
            // DtTo
            // 
            this.DtTo.Location = new System.Drawing.Point(262, 47);
            this.DtTo.Name = "DtTo";
            this.DtTo.Size = new System.Drawing.Size(115, 20);
            this.DtTo.TabIndex = 199;
            this.DtTo.ValueChanged += new System.EventHandler(this.DtTo_ValueChanged);
            // 
            // DtFrom
            // 
            this.DtFrom.Location = new System.Drawing.Point(109, 47);
            this.DtFrom.Name = "DtFrom";
            this.DtFrom.Size = new System.Drawing.Size(115, 20);
            this.DtFrom.TabIndex = 198;
            this.DtFrom.ValueChanged += new System.EventHandler(this.DtFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 203;
            this.label1.Text = "Group";
            // 
            // TxtChequeNoSearchStatement
            // 
            this.TxtChequeNoSearchStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChequeNoSearchStatement.Location = new System.Drawing.Point(125, 11);
            this.TxtChequeNoSearchStatement.Name = "TxtChequeNoSearchStatement";
            this.TxtChequeNoSearchStatement.Size = new System.Drawing.Size(108, 24);
            this.TxtChequeNoSearchStatement.TabIndex = 201;
            this.TxtChequeNoSearchStatement.TextChanged += new System.EventHandler(this.TxtChequeNoSearchStatement_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 202;
            this.label2.Text = "Cheque No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 208;
            this.label3.Text = "To";
            // 
            // TxtGroupSearchStatement
            // 
            this.TxtGroupSearchStatement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtGroupSearchStatement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TxtGroupSearchStatement.FormattingEnabled = true;
            this.TxtGroupSearchStatement.Location = new System.Drawing.Point(322, 11);
            this.TxtGroupSearchStatement.Name = "TxtGroupSearchStatement";
            this.TxtGroupSearchStatement.Size = new System.Drawing.Size(121, 21);
            this.TxtGroupSearchStatement.TabIndex = 204;
            this.TxtGroupSearchStatement.SelectedIndexChanged += new System.EventHandler(this.TxtGroupSearchStatement_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 205;
            this.label4.Text = "Date";
            // 
            // DtToStatement
            // 
            this.DtToStatement.Location = new System.Drawing.Point(269, 46);
            this.DtToStatement.Name = "DtToStatement";
            this.DtToStatement.Size = new System.Drawing.Size(115, 20);
            this.DtToStatement.TabIndex = 207;
            this.DtToStatement.ValueChanged += new System.EventHandler(this.DtToStatement_ValueChanged);
            // 
            // DtFromStatement
            // 
            this.DtFromStatement.Location = new System.Drawing.Point(116, 46);
            this.DtFromStatement.Name = "DtFromStatement";
            this.DtFromStatement.Size = new System.Drawing.Size(115, 20);
            this.DtFromStatement.TabIndex = 206;
            this.DtFromStatement.ValueChanged += new System.EventHandler(this.DtFromStatement_ValueChanged);
            // 
            // GvStatementConsolidate
            // 
            this.GvStatementConsolidate.AccessibleName = "";
            this.GvStatementConsolidate.AllowDrop = true;
            this.GvStatementConsolidate.AllowUserToAddRows = false;
            this.GvStatementConsolidate.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvStatementConsolidate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GvStatementConsolidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvStatementConsolidate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvStatementConsolidate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvStatementConsolidate.Location = new System.Drawing.Point(0, 0);
            this.GvStatementConsolidate.Name = "GvStatementConsolidate";
            this.GvStatementConsolidate.ReadOnly = true;
            this.GvStatementConsolidate.Size = new System.Drawing.Size(438, 246);
            this.GvStatementConsolidate.TabIndex = 210;
            this.GvStatementConsolidate.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvStatementConsolidate_CellMouseDown);
            this.GvStatementConsolidate.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvStatementConsolidate_DragDrop);
            this.GvStatementConsolidate.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvStatementConsolidate_DragEnter);
            this.GvStatementConsolidate.DragOver += new System.Windows.Forms.DragEventHandler(this.GvStatementConsolidate_DragOver);
            // 
            // GvPassbookConsolidate
            // 
            this.GvPassbookConsolidate.AccessibleName = "";
            this.GvPassbookConsolidate.AllowDrop = true;
            this.GvPassbookConsolidate.AllowUserToAddRows = false;
            this.GvPassbookConsolidate.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvPassbookConsolidate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvPassbookConsolidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvPassbookConsolidate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvPassbookConsolidate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GvPassbookConsolidate.Location = new System.Drawing.Point(0, 0);
            this.GvPassbookConsolidate.Name = "GvPassbookConsolidate";
            this.GvPassbookConsolidate.ReadOnly = true;
            this.GvPassbookConsolidate.Size = new System.Drawing.Size(440, 246);
            this.GvPassbookConsolidate.TabIndex = 209;
            this.GvPassbookConsolidate.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvPassbookConsolidate_CellMouseDown);
            this.GvPassbookConsolidate.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView2_DragDrop);
            this.GvPassbookConsolidate.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView2_DragEnter);
            this.GvPassbookConsolidate.DragOver += new System.Windows.Forms.DragEventHandler(this.GvPassbookConsolidate_DragOver);
            // 
            // CtrlBtnPrintBill
            // 
            this.CtrlBtnPrintBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrlBtnPrintBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CtrlBtnPrintBill.BackgroundImage")));
            this.CtrlBtnPrintBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlBtnPrintBill.FlatAppearance.BorderSize = 0;
            this.CtrlBtnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CtrlBtnPrintBill.Location = new System.Drawing.Point(907, 686);
            this.CtrlBtnPrintBill.Name = "CtrlBtnPrintBill";
            this.CtrlBtnPrintBill.Size = new System.Drawing.Size(35, 48);
            this.CtrlBtnPrintBill.TabIndex = 211;
            this.CtrlBtnPrintBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CtrlBtnPrintBill.UseVisualStyleBackColor = true;
            this.CtrlBtnPrintBill.Click += new System.EventHandler(this.CtrlBtnPrintBill_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(176, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 212;
            this.label7.Text = "Passbook";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(167, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 25);
            this.label8.TabIndex = 213;
            this.label8.Text = "Statement";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GvPassbook);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GvPassbookConsolidate);
            this.splitContainer1.Size = new System.Drawing.Size(440, 478);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 214;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GvStatement);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.GvStatementConsolidate);
            this.splitContainer2.Size = new System.Drawing.Size(438, 478);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 215;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(30, 202);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(882, 478);
            this.splitContainer3.SplitterDistance = 440;
            this.splitContainer3.TabIndex = 216;
            // 
            // TxtDeposite
            // 
            this.TxtDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDeposite.Location = new System.Drawing.Point(117, 73);
            this.TxtDeposite.Name = "TxtDeposite";
            this.TxtDeposite.Size = new System.Drawing.Size(108, 24);
            this.TxtDeposite.TabIndex = 217;
            this.TxtDeposite.TextChanged += new System.EventHandler(this.TxtDeposite_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(44, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 18);
            this.label10.TabIndex = 218;
            this.label10.Text = "Deposite";
            // 
            // TxtWithdraw
            // 
            this.TxtWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWithdraw.Location = new System.Drawing.Point(324, 74);
            this.TxtWithdraw.Name = "TxtWithdraw";
            this.TxtWithdraw.Size = new System.Drawing.Size(108, 24);
            this.TxtWithdraw.TabIndex = 219;
            this.TxtWithdraw.TextChanged += new System.EventHandler(this.TxtWithdraw_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(251, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 18);
            this.label11.TabIndex = 220;
            this.label11.Text = "Withdraw";
            // 
            // TxtWithdrawStatement
            // 
            this.TxtWithdrawStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWithdrawStatement.Location = new System.Drawing.Point(331, 74);
            this.TxtWithdrawStatement.Name = "TxtWithdrawStatement";
            this.TxtWithdrawStatement.Size = new System.Drawing.Size(108, 24);
            this.TxtWithdrawStatement.TabIndex = 223;
            this.TxtWithdrawStatement.TextChanged += new System.EventHandler(this.TxtWithdrawStatement_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(258, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 18);
            this.label12.TabIndex = 224;
            this.label12.Text = "Withdraw";
            // 
            // TxtDepositeStatement
            // 
            this.TxtDepositeStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDepositeStatement.Location = new System.Drawing.Point(125, 74);
            this.TxtDepositeStatement.Name = "TxtDepositeStatement";
            this.TxtDepositeStatement.Size = new System.Drawing.Size(108, 24);
            this.TxtDepositeStatement.TabIndex = 221;
            this.TxtDepositeStatement.TextChanged += new System.EventHandler(this.TxtDepositeStatement_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(52, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 18);
            this.label13.TabIndex = 222;
            this.label13.Text = "Deposite";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(30, 5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.DdlAccount);
            this.splitContainer4.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(957, 188);
            this.splitContainer4.SplitterDistance = 28;
            this.splitContainer4.TabIndex = 225;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.DtTo);
            this.splitContainer5.Panel1.Controls.Add(this.DtFrom);
            this.splitContainer5.Panel1.Controls.Add(this.label5);
            this.splitContainer5.Panel1.Controls.Add(this.TxtGroupSearch);
            this.splitContainer5.Panel1.Controls.Add(this.label6);
            this.splitContainer5.Panel1.Controls.Add(this.TxtWithdraw);
            this.splitContainer5.Panel1.Controls.Add(this.label21);
            this.splitContainer5.Panel1.Controls.Add(this.label11);
            this.splitContainer5.Panel1.Controls.Add(this.TxtChequeNoSearch);
            this.splitContainer5.Panel1.Controls.Add(this.TxtDeposite);
            this.splitContainer5.Panel1.Controls.Add(this.label18);
            this.splitContainer5.Panel1.Controls.Add(this.label10);
            this.splitContainer5.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.TxtWithdrawStatement);
            this.splitContainer5.Panel2.Controls.Add(this.TxtDepositeStatement);
            this.splitContainer5.Panel2.Controls.Add(this.label12);
            this.splitContainer5.Panel2.Controls.Add(this.DtFromStatement);
            this.splitContainer5.Panel2.Controls.Add(this.DtToStatement);
            this.splitContainer5.Panel2.Controls.Add(this.label13);
            this.splitContainer5.Panel2.Controls.Add(this.label4);
            this.splitContainer5.Panel2.Controls.Add(this.TxtGroupSearchStatement);
            this.splitContainer5.Panel2.Controls.Add(this.label8);
            this.splitContainer5.Panel2.Controls.Add(this.label3);
            this.splitContainer5.Panel2.Controls.Add(this.label2);
            this.splitContainer5.Panel2.Controls.Add(this.label1);
            this.splitContainer5.Panel2.Controls.Add(this.TxtChequeNoSearchStatement);
            this.splitContainer5.Size = new System.Drawing.Size(957, 156);
            this.splitContainer5.SplitterDistance = 483;
            this.splitContainer5.TabIndex = 225;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1027, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 129);
            this.button1.TabIndex = 226;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reconcillation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.CtrlBtnPrintBill);
            this.Name = "Reconcillation";
            this.Text = "Reconcillation";
            ((System.ComponentModel.ISupportInitialize)(this.GvPassbook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvStatementConsolidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvPassbookConsolidate)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox DdlAccount;
        private System.Windows.Forms.DataGridView GvPassbook;
        private System.Windows.Forms.DataGridView GvStatement;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TxtChequeNoSearch;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TxtGroupSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtTo;
        private System.Windows.Forms.DateTimePicker DtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtChequeNoSearchStatement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TxtGroupSearchStatement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtToStatement;
        private System.Windows.Forms.DateTimePicker DtFromStatement;
        private System.Windows.Forms.DataGridView GvStatementConsolidate;
        private System.Windows.Forms.DataGridView GvPassbookConsolidate;
        private System.Windows.Forms.Button CtrlBtnPrintBill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox TxtDeposite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtWithdraw;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtWithdrawStatement;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtDepositeStatement;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
    }
}