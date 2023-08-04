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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.grbDateRange = new System.Windows.Forms.GroupBox();
            this.btnImportJotformData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).BeginInit();
            this.grbDateRange.SuspendLayout();
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
            this._existingForms.Location = new System.Drawing.Point(12, 106);
            this._existingForms.MultiSelect = false;
            this._existingForms.Name = "_existingForms";
            this._existingForms.ReadOnly = true;
            this._existingForms.RowHeadersVisible = false;
            this._existingForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._existingForms.Size = new System.Drawing.Size(903, 381);
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
            this._refresh.Location = new System.Drawing.Point(815, 62);
            this._refresh.Name = "_refresh";
            this._refresh.Size = new System.Drawing.Size(100, 23);
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
            this._selectedCivilSurgeonPreview.Size = new System.Drawing.Size(327, 20);
            this._selectedCivilSurgeonPreview.TabIndex = 47;
            this._selectedCivilSurgeonPreview.Text = "Management";
            // 
            // _selectedPreparerPreview
            // 
            this._selectedPreparerPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedPreparerPreview.Location = new System.Drawing.Point(127, 70);
            this._selectedPreparerPreview.Name = "_selectedPreparerPreview";
            this._selectedPreparerPreview.Size = new System.Drawing.Size(327, 20);
            this._selectedPreparerPreview.TabIndex = 48;
            this._selectedPreparerPreview.Text = "Management";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(688, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Filter Entries";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Last 7 days",
            "Last 30 days",
            "Last year",
            "Custom date range",
            "Completed",
            "Not Completed"});
            this.cmbFilter.Location = new System.Drawing.Point(688, 64);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbFilter.TabIndex = 53;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(5, 21);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtFrom.Size = new System.Drawing.Size(93, 20);
            this.dtFrom.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "-";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(125, 21);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(93, 20);
            this.dtTo.TabIndex = 56;
            // 
            // grbDateRange
            // 
            this.grbDateRange.Controls.Add(this.dtTo);
            this.grbDateRange.Controls.Add(this.label3);
            this.grbDateRange.Controls.Add(this.dtFrom);
            this.grbDateRange.Location = new System.Drawing.Point(460, 44);
            this.grbDateRange.Name = "grbDateRange";
            this.grbDateRange.Size = new System.Drawing.Size(222, 48);
            this.grbDateRange.TabIndex = 58;
            this.grbDateRange.TabStop = false;
            this.grbDateRange.Text = "Date Range";
            this.grbDateRange.Visible = false;
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 497);
            this.Controls.Add(this.btnImportJotformData);
            this.Controls.Add(this.grbDateRange);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetConfig);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.button4);
            this.Controls.Add(this._selectedPreparerPreview);
            this.Controls.Add(this._selectedCivilSurgeonPreview);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._refresh);
            this.Controls.Add(this._existingForms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Autofiller 3.5 – Property of Partida Corona Medical Center ©2023";
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).EndInit();
            this.grbDateRange.ResumeLayout(false);
            this.grbDateRange.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
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
    }
}

