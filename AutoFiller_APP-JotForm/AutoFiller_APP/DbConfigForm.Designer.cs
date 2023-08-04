namespace AutoFiller_APP
{
    partial class DbConfigForm
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
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.lbl_database_name = new System.Windows.Forms.Label();
            this.txt_database_name = new System.Windows.Forms.TextBox();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.txt_user_name = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_test_connection = new System.Windows.Forms.Button();
            this.txtWebServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJotApiKey = new System.Windows.Forms.TextBox();
            this.txtJotformID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJotformUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(40, 38);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(197, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // lbl_serverName
            // 
            this.lbl_serverName.AutoSize = true;
            this.lbl_serverName.Location = new System.Drawing.Point(40, 19);
            this.lbl_serverName.Name = "lbl_serverName";
            this.lbl_serverName.Size = new System.Drawing.Size(93, 13);
            this.lbl_serverName.TabIndex = 1;
            this.lbl_serverName.Text = "SQL Server Name";
            // 
            // lbl_database_name
            // 
            this.lbl_database_name.AutoSize = true;
            this.lbl_database_name.Location = new System.Drawing.Point(40, 70);
            this.lbl_database_name.Name = "lbl_database_name";
            this.lbl_database_name.Size = new System.Drawing.Size(84, 13);
            this.lbl_database_name.TabIndex = 3;
            this.lbl_database_name.Text = "Database Name";
            // 
            // txt_database_name
            // 
            this.txt_database_name.Location = new System.Drawing.Point(40, 89);
            this.txt_database_name.Name = "txt_database_name";
            this.txt_database_name.Size = new System.Drawing.Size(197, 20);
            this.txt_database_name.TabIndex = 2;
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.AutoSize = true;
            this.lbl_user_name.Location = new System.Drawing.Point(40, 131);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(84, 13);
            this.lbl_user_name.TabIndex = 8;
            this.lbl_user_name.Text = "SQL User Name";
            // 
            // txt_user_name
            // 
            this.txt_user_name.Location = new System.Drawing.Point(40, 150);
            this.txt_user_name.Name = "txt_user_name";
            this.txt_user_name.Size = new System.Drawing.Size(197, 20);
            this.txt_user_name.TabIndex = 7;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(40, 184);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(77, 13);
            this.lbl_password.TabIndex = 10;
            this.lbl_password.Text = "SQL Password";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(40, 203);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(197, 20);
            this.txt_password.TabIndex = 9;
            // 
            // btn_test_connection
            // 
            this.btn_test_connection.Location = new System.Drawing.Point(40, 480);
            this.btn_test_connection.Name = "btn_test_connection";
            this.btn_test_connection.Size = new System.Drawing.Size(197, 35);
            this.btn_test_connection.TabIndex = 11;
            this.btn_test_connection.Text = "Save and Test Connection";
            this.btn_test_connection.UseVisualStyleBackColor = true;
            this.btn_test_connection.Click += new System.EventHandler(this.btn_test_connection_Click);
            // 
            // txtWebServer
            // 
            this.txtWebServer.Location = new System.Drawing.Point(40, 258);
            this.txtWebServer.Name = "txtWebServer";
            this.txtWebServer.Size = new System.Drawing.Size(197, 20);
            this.txtWebServer.TabIndex = 9;
            this.txtWebServer.Text = "http://localhost:57112";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Web Server URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Jotform API Key";
            // 
            // txtJotApiKey
            // 
            this.txtJotApiKey.Location = new System.Drawing.Point(40, 318);
            this.txtJotApiKey.Name = "txtJotApiKey";
            this.txtJotApiKey.Size = new System.Drawing.Size(197, 20);
            this.txtJotApiKey.TabIndex = 12;
            this.txtJotApiKey.Text = "498ca5f5b4d164e808595f856799bdbc";
            // 
            // txtJotformID
            // 
            this.txtJotformID.Location = new System.Drawing.Point(40, 373);
            this.txtJotformID.Name = "txtJotformID";
            this.txtJotformID.Size = new System.Drawing.Size(197, 20);
            this.txtJotformID.TabIndex = 12;
            this.txtJotformID.Text = "232005335483045";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Jotform ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Jotform Host Url";
            // 
            // txtJotformUrl
            // 
            this.txtJotformUrl.Location = new System.Drawing.Point(40, 435);
            this.txtJotformUrl.Name = "txtJotformUrl";
            this.txtJotformUrl.Size = new System.Drawing.Size(197, 20);
            this.txtJotformUrl.TabIndex = 14;
            this.txtJotformUrl.Text = "https://hipaa-api.jotform.com/";
            // 
            // DbConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 526);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJotformUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJotformID);
            this.Controls.Add(this.txtJotApiKey);
            this.Controls.Add(this.btn_test_connection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txtWebServer);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.txt_user_name);
            this.Controls.Add(this.lbl_database_name);
            this.Controls.Add(this.txt_database_name);
            this.Controls.Add(this.lbl_serverName);
            this.Controls.Add(this.txtServerName);
            this.Name = "DbConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.Label lbl_database_name;
        private System.Windows.Forms.TextBox txt_database_name;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.TextBox txt_user_name;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_test_connection;
        private System.Windows.Forms.TextBox txtWebServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJotApiKey;
        private System.Windows.Forms.TextBox txtJotformID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJotformUrl;
    }
}
