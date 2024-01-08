namespace AutoFiller_APP
{
    partial class Main
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
            this._existingForms = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlienNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USCISNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ExportData = new System.Windows.Forms.Button();
            this.btnSetConfig = new System.Windows.Forms.Button();
            this._selectedCivilSurgeonPreview = new System.Windows.Forms.Label();
            this._selectedPreparerPreview = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.grbDateRange = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImportJotformData = new System.Windows.Forms.Button();
            this.txtUSCISNumber = new System.Windows.Forms.TextBox();
            this.txtAlienNumber = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFilterCnt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.chkBirth = new System.Windows.Forms.CheckBox();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterOption = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).BeginInit();
            this.grbDateRange.SuspendLayout();
            this.grbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _existingForms
            // 
            this._existingForms.AllowUserToAddRows = false;
            this._existingForms.AllowUserToDeleteRows = false;
            this._existingForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._existingForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._existingForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LastName,
            this.FirstName,
            this.AlienNumber,
            this.USCISNumber,
            this.Date,
            this.Source,
            this.Completed});
            this._existingForms.Location = new System.Drawing.Point(12, 96);
            this._existingForms.MultiSelect = false;
            this._existingForms.Name = "_existingForms";
            this._existingForms.ReadOnly = true;
            this._existingForms.RowHeadersVisible = false;
            this._existingForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._existingForms.Size = new System.Drawing.Size(892, 369);
            this._existingForms.TabIndex = 2;
            this._existingForms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._existingForms_CellContentClick);
            this._existingForms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._existingForms_CellDoubleClick);
            this._existingForms.KeyUp += new System.Windows.Forms.KeyEventHandler(this._existingForms_KeyUp);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // AlienNumber
            // 
            this.AlienNumber.HeaderText = "Alien Number";
            this.AlienNumber.Name = "AlienNumber";
            this.AlienNumber.ReadOnly = true;
            // 
            // USCISNumber
            // 
            this.USCISNumber.HeaderText = "USCIS Number";
            this.USCISNumber.Name = "USCISNumber";
            this.USCISNumber.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            // 
            // Completed
            // 
            this.Completed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Completed.HeaderText = "Completed";
            this.Completed.Name = "Completed";
            this.Completed.ReadOnly = true;
            this.Completed.Width = 63;
            // 
            // _refresh
            // 
            this._refresh.Location = new System.Drawing.Point(16, 370);
            this._refresh.Name = "_refresh";
            this._refresh.Size = new System.Drawing.Size(194, 23);
            this._refresh.TabIndex = 3;
            this._refresh.Text = "Set Filter";
            this._refresh.UseVisualStyleBackColor = true;
            this._refresh.Click += new System.EventHandler(this._refresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Civil Surgeon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Preparer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(239, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "Statistics";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // ExportData
            // 
            this.ExportData.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExportData.Location = new System.Drawing.Point(354, 9);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(100, 23);
            this.ExportData.TabIndex = 50;
            this.ExportData.Text = "Export";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.ExportData_Click);
            // 
            // btnSetConfig
            // 
            this.btnSetConfig.Location = new System.Drawing.Point(12, 9);
            this.btnSetConfig.Name = "btnSetConfig";
            this.btnSetConfig.Size = new System.Drawing.Size(100, 23);
            this.btnSetConfig.TabIndex = 51;
            this.btnSetConfig.Text = "Server Setting";
            this.btnSetConfig.UseVisualStyleBackColor = true;
            this.btnSetConfig.Click += new System.EventHandler(this.button5_Click);
            // 
            // _selectedCivilSurgeonPreview
            // 
            this._selectedCivilSurgeonPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedCivilSurgeonPreview.Location = new System.Drawing.Point(127, 41);
            this._selectedCivilSurgeonPreview.Name = "_selectedCivilSurgeonPreview";
            this._selectedCivilSurgeonPreview.Size = new System.Drawing.Size(777, 20);
            this._selectedCivilSurgeonPreview.TabIndex = 47;
            this._selectedCivilSurgeonPreview.Text = "Management";
            // 
            // _selectedPreparerPreview
            // 
            this._selectedPreparerPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedPreparerPreview.Location = new System.Drawing.Point(127, 70);
            this._selectedPreparerPreview.Name = "_selectedPreparerPreview";
            this._selectedPreparerPreview.Size = new System.Drawing.Size(777, 20);
            this._selectedPreparerPreview.TabIndex = 48;
            this._selectedPreparerPreview.Text = "Management";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Last 7 days",
            "Last 30 days",
            "Last year",
            "Custom date range"});
            this.cmbFilter.Location = new System.Drawing.Point(104, 245);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(106, 21);
            this.cmbFilter.TabIndex = 53;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(54, 23);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtFrom.Size = new System.Drawing.Size(105, 20);
            this.dtFrom.TabIndex = 54;
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(54, 48);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(107, 20);
            this.dtTo.TabIndex = 56;
            // 
            // grbDateRange
            // 
            this.grbDateRange.Controls.Add(this.label8);
            this.grbDateRange.Controls.Add(this.label3);
            this.grbDateRange.Controls.Add(this.dtTo);
            this.grbDateRange.Controls.Add(this.dtFrom);
            this.grbDateRange.Location = new System.Drawing.Point(16, 278);
            this.grbDateRange.Name = "grbDateRange";
            this.grbDateRange.Size = new System.Drawing.Size(194, 76);
            this.grbDateRange.TabIndex = 58;
            this.grbDateRange.TabStop = false;
            this.grbDateRange.Text = "Date Range";
            this.grbDateRange.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 70;
            this.label8.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "From";
            // 
            // btnImportJotformData
            // 
            this.btnImportJotformData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnImportJotformData.Location = new System.Drawing.Point(465, 9);
            this.btnImportJotformData.Name = "btnImportJotformData";
            this.btnImportJotformData.Size = new System.Drawing.Size(100, 23);
            this.btnImportJotformData.TabIndex = 59;
            this.btnImportJotformData.Text = "Import Jotform Data";
            this.btnImportJotformData.UseVisualStyleBackColor = true;
            this.btnImportJotformData.Click += new System.EventHandler(this.btnImportJotformData_Click);
            // 
            // txtUSCISNumber
            // 
            this.txtUSCISNumber.Location = new System.Drawing.Point(103, 112);
            this.txtUSCISNumber.Name = "txtUSCISNumber";
            this.txtUSCISNumber.Size = new System.Drawing.Size(106, 20);
            this.txtUSCISNumber.TabIndex = 60;
            // 
            // txtAlienNumber
            // 
            this.txtAlienNumber.Location = new System.Drawing.Point(103, 81);
            this.txtAlienNumber.Name = "txtAlienNumber";
            this.txtAlienNumber.Size = new System.Drawing.Size(106, 20);
            this.txtAlienNumber.TabIndex = 61;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(102, 51);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(106, 20);
            this.txtFirstName.TabIndex = 62;
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(101, 24);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(106, 20);
            this.txtLastname.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "USCIS Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Alien Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "First Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Fiter Entries";
            // 
            // lblFilterCnt
            // 
            this.lblFilterCnt.AutoSize = true;
            this.lblFilterCnt.Location = new System.Drawing.Point(12, 475);
            this.lblFilterCnt.Name = "lblFilterCnt";
            this.lblFilterCnt.Size = new System.Drawing.Size(76, 13);
            this.lblFilterCnt.TabIndex = 69;
            this.lblFilterCnt.Text = "Total Result: 0";
            this.lblFilterCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(103, 142);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(107, 20);
            this.txtPhone.TabIndex = 70;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirth.Location = new System.Drawing.Point(103, 175);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpBirth.Size = new System.Drawing.Size(107, 20);
            this.dtpBirth.TabIndex = 73;
            // 
            // chkBirth
            // 
            this.chkBirth.AutoSize = true;
            this.chkBirth.Location = new System.Drawing.Point(13, 178);
            this.chkBirth.Name = "chkBirth";
            this.chkBirth.Size = new System.Drawing.Size(87, 17);
            this.chkBirth.TabIndex = 74;
            this.chkBirth.Text = "Date Of Birth";
            this.chkBirth.UseVisualStyleBackColor = true;
            // 
            // grbFilter
            // 
            this.grbFilter.Controls.Add(this.label9);
            this.grbFilter.Controls.Add(this.cmbSatus);
            this.grbFilter.Controls.Add(this.label7);
            this.grbFilter.Controls.Add(this.chkBirth);
            this.grbFilter.Controls.Add(this._refresh);
            this.grbFilter.Controls.Add(this.dtpBirth);
            this.grbFilter.Controls.Add(this.cmbFilter);
            this.grbFilter.Controls.Add(this.label1);
            this.grbFilter.Controls.Add(this.grbDateRange);
            this.grbFilter.Controls.Add(this.txtPhone);
            this.grbFilter.Controls.Add(this.txtUSCISNumber);
            this.grbFilter.Controls.Add(this.txtAlienNumber);
            this.grbFilter.Controls.Add(this.txtFirstName);
            this.grbFilter.Controls.Add(this.label6);
            this.grbFilter.Controls.Add(this.txtLastname);
            this.grbFilter.Controls.Add(this.label5);
            this.grbFilter.Controls.Add(this.label2);
            this.grbFilter.Controls.Add(this.label4);
            this.grbFilter.Location = new System.Drawing.Point(921, 94);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(222, 399);
            this.grbFilter.TabIndex = 75;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "Filter Options";
            this.grbFilter.Visible = false;
            // 
            // btnFilterOption
            // 
            this.btnFilterOption.Location = new System.Drawing.Point(804, 470);
            this.btnFilterOption.Name = "btnFilterOption";
            this.btnFilterOption.Size = new System.Drawing.Size(100, 23);
            this.btnFilterOption.TabIndex = 76;
            this.btnFilterOption.Text = "Filter ->";
            this.btnFilterOption.UseVisualStyleBackColor = true;
            this.btnFilterOption.Click += new System.EventHandler(this.btnFilterOption_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "Status";
            // 
            // cmbSatus
            // 
            this.cmbSatus.FormattingEnabled = true;
            this.cmbSatus.Items.AddRange(new object[] {
            "All",
            "Completed",
            "Not Completed"});
            this.cmbSatus.Location = new System.Drawing.Point(103, 208);
            this.cmbSatus.Name = "cmbSatus";
            this.cmbSatus.Size = new System.Drawing.Size(106, 21);
            this.cmbSatus.TabIndex = 75;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 502);
            this.Controls.Add(this.btnFilterOption);
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.lblFilterCnt);
            this.Controls.Add(this.btnImportJotformData);
            this.Controls.Add(this.btnSetConfig);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.button4);
            this.Controls.Add(this._selectedPreparerPreview);
            this.Controls.Add(this._selectedCivilSurgeonPreview);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._existingForms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Autofiller 3.5 – Property of Partida Corona Medical Center ©2023";
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).EndInit();
            this.grbDateRange.ResumeLayout(false);
            this.grbDateRange.PerformLayout();
            this.grbFilter.ResumeLayout(false);
            this.grbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView _existingForms;
        private System.Windows.Forms.Button _refresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ExportData;
        private System.Windows.Forms.Button btnSetConfig;
        private System.Windows.Forms.Label _selectedCivilSurgeonPreview;
        private System.Windows.Forms.Label _selectedPreparerPreview;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.GroupBox grbDateRange;
        private System.Windows.Forms.Button btnImportJotformData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlienNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn USCISNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Completed;
        private System.Windows.Forms.TextBox txtUSCISNumber;
        private System.Windows.Forms.TextBox txtAlienNumber;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFilterCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.CheckBox chkBirth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.Button btnFilterOption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSatus;
    }
}

