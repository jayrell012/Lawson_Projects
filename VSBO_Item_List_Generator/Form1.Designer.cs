namespace VSBO_Item_List_Generator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnStop_ = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRun_ = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReset_ = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStopSaveExcel_ = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSaveExcel_ = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label6 = new System.Windows.Forms.Label();
            this.storeProgressBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 26);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(134, 259);
            this.checkedListBox1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "List of Stores ▼";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "BARCODE",
            "SELLING PRICE",
            "BASE COST",
            "NET COST",
            "AVERAGE COST",
            "SUPLLIER",
            "DEPARTMENT",
            "CATEGORY",
            "VAT TPYE",
            "ASSORTMENT",
            "SUPPLIER"});
            this.checkedListBox2.Location = new System.Drawing.Point(3, 26);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(134, 154);
            this.checkedListBox2.TabIndex = 15;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(169, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Details ▼";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 288);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Select All";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.checkedListBox2);
            this.panel2.Location = new System.Drawing.Point(169, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 185);
            this.panel2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(6, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Select All";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Location = new System.Drawing.Point(132, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 100);
            this.panel3.TabIndex = 8;
            this.panel3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(84, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 38);
            this.label5.TabIndex = 24;
            this.label5.Text = "{0}%\r\ngetting data from {1}";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(376, 10);
            this.progressBar1.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(554, 326);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
            this.dataGridView1.MouseEnter += new System.EventHandler(this.dataGridView1_MouseEnter);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 358);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Records: 0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1013, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnStop_
            // 
            this.btnStop_.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStop_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop_.BackColor = System.Drawing.Color.Crimson;
            this.btnStop_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop_.BorderRadius = 0;
            this.btnStop_.ButtonText = "Stop";
            this.btnStop_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop_.DisabledColor = System.Drawing.Color.Gray;
            this.btnStop_.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStop_.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStop_.Iconimage")));
            this.btnStop_.Iconimage_right = null;
            this.btnStop_.Iconimage_right_Selected = null;
            this.btnStop_.Iconimage_Selected = null;
            this.btnStop_.IconMarginLeft = 0;
            this.btnStop_.IconMarginRight = 0;
            this.btnStop_.IconRightVisible = true;
            this.btnStop_.IconRightZoom = 0D;
            this.btnStop_.IconVisible = true;
            this.btnStop_.IconZoom = 45D;
            this.btnStop_.IsTab = false;
            this.btnStop_.Location = new System.Drawing.Point(499, 8);
            this.btnStop_.Name = "btnStop_";
            this.btnStop_.Normalcolor = System.Drawing.Color.Crimson;
            this.btnStop_.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStop_.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStop_.selected = false;
            this.btnStop_.Size = new System.Drawing.Size(77, 30);
            this.btnStop_.TabIndex = 3;
            this.btnStop_.Text = "Stop";
            this.btnStop_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop_.Textcolor = System.Drawing.Color.White;
            this.btnStop_.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop_.Click += new System.EventHandler(this.btnStop__Click);
            // 
            // btnRun_
            // 
            this.btnRun_.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRun_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun_.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRun_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRun_.BorderRadius = 0;
            this.btnRun_.ButtonText = "Run";
            this.btnRun_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun_.DisabledColor = System.Drawing.Color.Gray;
            this.btnRun_.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRun_.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRun_.Iconimage")));
            this.btnRun_.Iconimage_right = null;
            this.btnRun_.Iconimage_right_Selected = null;
            this.btnRun_.Iconimage_Selected = null;
            this.btnRun_.IconMarginLeft = 0;
            this.btnRun_.IconMarginRight = 0;
            this.btnRun_.IconRightVisible = true;
            this.btnRun_.IconRightZoom = 0D;
            this.btnRun_.IconVisible = true;
            this.btnRun_.IconZoom = 45D;
            this.btnRun_.IsTab = false;
            this.btnRun_.Location = new System.Drawing.Point(499, 8);
            this.btnRun_.Name = "btnRun_";
            this.btnRun_.Normalcolor = System.Drawing.Color.MediumSeaGreen;
            this.btnRun_.OnHovercolor = System.Drawing.Color.MediumAquamarine;
            this.btnRun_.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRun_.selected = false;
            this.btnRun_.Size = new System.Drawing.Size(77, 30);
            this.btnRun_.TabIndex = 2;
            this.btnRun_.Text = "Run";
            this.btnRun_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun_.Textcolor = System.Drawing.Color.White;
            this.btnRun_.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun_.Click += new System.EventHandler(this.btnRun__Click);
            // 
            // btnReset_
            // 
            this.btnReset_.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReset_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset_.BackColor = System.Drawing.Color.Tomato;
            this.btnReset_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset_.BorderRadius = 0;
            this.btnReset_.ButtonText = " Reset";
            this.btnReset_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset_.DisabledColor = System.Drawing.Color.Gray;
            this.btnReset_.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReset_.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnReset_.Iconimage")));
            this.btnReset_.Iconimage_right = null;
            this.btnReset_.Iconimage_right_Selected = null;
            this.btnReset_.Iconimage_Selected = null;
            this.btnReset_.IconMarginLeft = 0;
            this.btnReset_.IconMarginRight = 0;
            this.btnReset_.IconRightVisible = true;
            this.btnReset_.IconRightZoom = 0D;
            this.btnReset_.IconVisible = true;
            this.btnReset_.IconZoom = 35D;
            this.btnReset_.IsTab = false;
            this.btnReset_.Location = new System.Drawing.Point(410, 8);
            this.btnReset_.Name = "btnReset_";
            this.btnReset_.Normalcolor = System.Drawing.Color.Tomato;
            this.btnReset_.OnHovercolor = System.Drawing.Color.SandyBrown;
            this.btnReset_.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReset_.selected = false;
            this.btnReset_.Size = new System.Drawing.Size(83, 30);
            this.btnReset_.TabIndex = 4;
            this.btnReset_.Text = " Reset";
            this.btnReset_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset_.Textcolor = System.Drawing.Color.White;
            this.btnReset_.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset_.Click += new System.EventHandler(this.btnReset__Click);
            // 
            // btnStopSaveExcel_
            // 
            this.btnStopSaveExcel_.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStopSaveExcel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopSaveExcel_.BackColor = System.Drawing.Color.Crimson;
            this.btnStopSaveExcel_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStopSaveExcel_.BorderRadius = 0;
            this.btnStopSaveExcel_.ButtonText = "Stop";
            this.btnStopSaveExcel_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopSaveExcel_.DisabledColor = System.Drawing.Color.Gray;
            this.btnStopSaveExcel_.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStopSaveExcel_.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStopSaveExcel_.Iconimage")));
            this.btnStopSaveExcel_.Iconimage_right = null;
            this.btnStopSaveExcel_.Iconimage_right_Selected = null;
            this.btnStopSaveExcel_.Iconimage_Selected = null;
            this.btnStopSaveExcel_.IconMarginLeft = 0;
            this.btnStopSaveExcel_.IconMarginRight = 0;
            this.btnStopSaveExcel_.IconRightVisible = true;
            this.btnStopSaveExcel_.IconRightZoom = 0D;
            this.btnStopSaveExcel_.IconVisible = true;
            this.btnStopSaveExcel_.IconZoom = 45D;
            this.btnStopSaveExcel_.IsTab = false;
            this.btnStopSaveExcel_.Location = new System.Drawing.Point(499, 8);
            this.btnStopSaveExcel_.Name = "btnStopSaveExcel_";
            this.btnStopSaveExcel_.Normalcolor = System.Drawing.Color.Crimson;
            this.btnStopSaveExcel_.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStopSaveExcel_.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStopSaveExcel_.selected = false;
            this.btnStopSaveExcel_.Size = new System.Drawing.Size(77, 30);
            this.btnStopSaveExcel_.TabIndex = 6;
            this.btnStopSaveExcel_.Text = "Stop";
            this.btnStopSaveExcel_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopSaveExcel_.Textcolor = System.Drawing.Color.White;
            this.btnStopSaveExcel_.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopSaveExcel_.Click += new System.EventHandler(this.btnStopSaveExcel__Click);
            // 
            // btnSaveExcel_
            // 
            this.btnSaveExcel_.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSaveExcel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExcel_.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaveExcel_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveExcel_.BorderRadius = 0;
            this.btnSaveExcel_.ButtonText = "Export";
            this.btnSaveExcel_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveExcel_.DisabledColor = System.Drawing.Color.Gray;
            this.btnSaveExcel_.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSaveExcel_.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSaveExcel_.Iconimage")));
            this.btnSaveExcel_.Iconimage_right = null;
            this.btnSaveExcel_.Iconimage_right_Selected = null;
            this.btnSaveExcel_.Iconimage_Selected = null;
            this.btnSaveExcel_.IconMarginLeft = 0;
            this.btnSaveExcel_.IconMarginRight = 0;
            this.btnSaveExcel_.IconRightVisible = true;
            this.btnSaveExcel_.IconRightZoom = 0D;
            this.btnSaveExcel_.IconVisible = true;
            this.btnSaveExcel_.IconZoom = 45D;
            this.btnSaveExcel_.IsTab = false;
            this.btnSaveExcel_.Location = new System.Drawing.Point(499, 8);
            this.btnSaveExcel_.Name = "btnSaveExcel_";
            this.btnSaveExcel_.Normalcolor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaveExcel_.OnHovercolor = System.Drawing.Color.MediumAquamarine;
            this.btnSaveExcel_.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSaveExcel_.selected = false;
            this.btnSaveExcel_.Size = new System.Drawing.Size(77, 30);
            this.btnSaveExcel_.TabIndex = 5;
            this.btnSaveExcel_.Text = "Export";
            this.btnSaveExcel_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveExcel_.Textcolor = System.Drawing.Color.White;
            this.btnSaveExcel_.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExcel_.Click += new System.EventHandler(this.btnSaveExcel__Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "1/1 tab(s)";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(890, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "savinf file {0}";
            this.label6.Visible = false;
            // 
            // storeProgressBar
            // 
            this.storeProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.storeProgressBar.Location = new System.Drawing.Point(0, 442);
            this.storeProgressBar.Name = "storeProgressBar";
            this.storeProgressBar.Size = new System.Drawing.Size(592, 10);
            this.storeProgressBar.TabIndex = 26;
            this.storeProgressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 452);
            this.Controls.Add(this.storeProgressBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStopSaveExcel_);
            this.Controls.Add(this.btnSaveExcel_);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset_);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStop_);
            this.Controls.Add(this.btnRun_);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(608, 491);
            this.Name = "Form1";
            this.Text = "Lawson Item Master List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Bunifu.Framework.UI.BunifuFlatButton btnSaveExcel_;
        private Bunifu.Framework.UI.BunifuFlatButton btnStopSaveExcel_;
        private Bunifu.Framework.UI.BunifuFlatButton btnReset_;
        private Bunifu.Framework.UI.BunifuFlatButton btnRun_;
        private Bunifu.Framework.UI.BunifuFlatButton btnStop_;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar storeProgressBar;
    }
}

