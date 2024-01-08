namespace AutoFiller_APP
{
    partial class ExportForm
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
            this.ExportPatientData = new System.Windows.Forms.Button();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
            this.endDateBox = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCity = new System.Windows.Forms.CheckBox();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkReferred = new System.Windows.Forms.CheckBox();
            this.chkCountryOfBirth = new System.Windows.Forms.CheckBox();
            this.chkDob = new System.Windows.Forms.CheckBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExportPatientData
            // 
            this.ExportPatientData.Location = new System.Drawing.Point(233, 179);
            this.ExportPatientData.Name = "ExportPatientData";
            this.ExportPatientData.Size = new System.Drawing.Size(149, 23);
            this.ExportPatientData.TabIndex = 2;
            this.ExportPatientData.Text = "Export Patients to Excel";
            this.ExportPatientData.UseVisualStyleBackColor = true;
            this.ExportPatientData.Click += new System.EventHandler(this.ExportPatientData_Click);
            // 
            // startDateBox
            // 
            this.startDateBox.Location = new System.Drawing.Point(74, 25);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(200, 20);
            this.startDateBox.TabIndex = 3;
            // 
            // endDateBox
            // 
            this.endDateBox.Location = new System.Drawing.Point(358, 25);
            this.endDateBox.Name = "endDateBox";
            this.endDateBox.Size = new System.Drawing.Size(200, 20);
            this.endDateBox.TabIndex = 4;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(14, 32);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(56, 13);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(306, 32);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(46, 13);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "To Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCity);
            this.groupBox1.Controls.Add(this.chkState);
            this.groupBox1.Controls.Add(this.chkPhone);
            this.groupBox1.Controls.Add(this.chkEmail);
            this.groupBox1.Controls.Add(this.chkReferred);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.chkCountryOfBirth);
            this.groupBox1.Controls.Add(this.chkDob);
            this.groupBox1.Controls.Add(this.chkName);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 82);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Colums";
            // 
            // chkCity
            // 
            this.chkCity.AutoSize = true;
            this.chkCity.Checked = true;
            this.chkCity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCity.Location = new System.Drawing.Point(221, 54);
            this.chkCity.Name = "chkCity";
            this.chkCity.Size = new System.Drawing.Size(50, 17);
            this.chkCity.TabIndex = 32;
            this.chkCity.Text = "CITY";
            this.chkCity.UseVisualStyleBackColor = true;
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Checked = true;
            this.chkState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkState.Location = new System.Drawing.Point(277, 54);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(61, 17);
            this.chkState.TabIndex = 31;
            this.chkState.Text = "STATE";
            this.chkState.UseVisualStyleBackColor = true;
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Checked = true;
            this.chkPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhone.Location = new System.Drawing.Point(344, 54);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(67, 17);
            this.chkPhone.TabIndex = 30;
            this.chkPhone.Text = "Phone #";
            this.chkPhone.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Checked = true;
            this.chkEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmail.Location = new System.Drawing.Point(415, 54);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(58, 17);
            this.chkEmail.TabIndex = 29;
            this.chkEmail.Text = "EMAIL";
            this.chkEmail.UseVisualStyleBackColor = true;
            // 
            // chkReferred
            // 
            this.chkReferred.AutoSize = true;
            this.chkReferred.Checked = true;
            this.chkReferred.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReferred.Location = new System.Drawing.Point(479, 54);
            this.chkReferred.Name = "chkReferred";
            this.chkReferred.Size = new System.Drawing.Size(102, 17);
            this.chkReferred.TabIndex = 28;
            this.chkReferred.Text = "REFERRED BY";
            this.chkReferred.UseVisualStyleBackColor = true;
            // 
            // chkCountryOfBirth
            // 
            this.chkCountryOfBirth.AutoSize = true;
            this.chkCountryOfBirth.Checked = true;
            this.chkCountryOfBirth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCountryOfBirth.Location = new System.Drawing.Point(117, 54);
            this.chkCountryOfBirth.Name = "chkCountryOfBirth";
            this.chkCountryOfBirth.Size = new System.Drawing.Size(98, 17);
            this.chkCountryOfBirth.TabIndex = 27;
            this.chkCountryOfBirth.Text = "Country of Birth";
            this.chkCountryOfBirth.UseVisualStyleBackColor = true;
            // 
            // chkDob
            // 
            this.chkDob.AutoSize = true;
            this.chkDob.Checked = true;
            this.chkDob.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDob.Location = new System.Drawing.Point(62, 54);
            this.chkDob.Name = "chkDob";
            this.chkDob.Size = new System.Drawing.Size(49, 17);
            this.chkDob.TabIndex = 26;
            this.chkDob.Text = "DOB";
            this.chkDob.UseVisualStyleBackColor = true;
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Checked = true;
            this.chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkName.Location = new System.Drawing.Point(6, 54);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(54, 17);
            this.chkName.TabIndex = 25;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(6, 31);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 24;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.endDateBox);
            this.groupBox2.Controls.Add(this.lblToDate);
            this.groupBox2.Controls.Add(this.startDateBox);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 62);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Date Range";
            // 
            // ExportForm
            // 
            this.ClientSize = new System.Drawing.Size(606, 223);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExportPatientData);
            this.Name = "ExportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExportPatientData;
        private System.Windows.Forms.DateTimePicker startDateBox;
        private System.Windows.Forms.DateTimePicker endDateBox;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCity;
        private System.Windows.Forms.CheckBox chkState;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.CheckBox chkReferred;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkCountryOfBirth;
        private System.Windows.Forms.CheckBox chkDob;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
