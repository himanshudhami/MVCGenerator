namespace CodeGenerator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAuthentication = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.rdoSqlServer = new System.Windows.Forms.RadioButton();
            this.rdoWidows = new System.Windows.Forms.RadioButton();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.gbProjectType = new System.Windows.Forms.GroupBox();
            this.cbDal = new System.Windows.Forms.CheckBox();
            this.cbWcf = new System.Windows.Forms.CheckBox();
            this.cbWebApi = new System.Windows.Forms.CheckBox();
            this.gbProjectDetails = new System.Windows.Forms.GroupBox();
            this.btnProjectLocation = new System.Windows.Forms.Button();
            this.txtNameSpaceName = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.fdProjectLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gbAuthentication.SuspendLayout();
            this.gbProjectType.SuspendLayout();
            this.gbProjectDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBase Name";
            // 
            // gbAuthentication
            // 
            this.gbAuthentication.Controls.Add(this.label8);
            this.gbAuthentication.Controls.Add(this.label7);
            this.gbAuthentication.Controls.Add(this.txtLoginName);
            this.gbAuthentication.Controls.Add(this.txtPassword);
            this.gbAuthentication.Controls.Add(this.rdoSqlServer);
            this.gbAuthentication.Controls.Add(this.rdoWidows);
            this.gbAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAuthentication.Location = new System.Drawing.Point(76, 217);
            this.gbAuthentication.Name = "gbAuthentication";
            this.gbAuthentication.Size = new System.Drawing.Size(300, 156);
            this.gbAuthentication.TabIndex = 6;
            this.gbAuthentication.TabStop = false;
            this.gbAuthentication.Text = "Authentication";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Login Name";
            // 
            // txtLoginName
            // 
            this.txtLoginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLoginName.Location = new System.Drawing.Point(134, 83);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(149, 22);
            this.txtLoginName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(134, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(149, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // rdoSqlServer
            // 
            this.rdoSqlServer.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader;
            this.rdoSqlServer.AutoSize = true;
            this.rdoSqlServer.Location = new System.Drawing.Point(21, 54);
            this.rdoSqlServer.Name = "rdoSqlServer";
            this.rdoSqlServer.Size = new System.Drawing.Size(172, 20);
            this.rdoSqlServer.TabIndex = 1;
            this.rdoSqlServer.TabStop = true;
            this.rdoSqlServer.Text = "SqlServer Authentication";
            this.rdoSqlServer.UseVisualStyleBackColor = true;
            this.rdoSqlServer.CheckedChanged += new System.EventHandler(this.rdoSqlServer_CheckedChanged);
            // 
            // rdoWidows
            // 
            this.rdoWidows.AutoSize = true;
            this.rdoWidows.Location = new System.Drawing.Point(21, 19);
            this.rdoWidows.Name = "rdoWidows";
            this.rdoWidows.Size = new System.Drawing.Size(167, 20);
            this.rdoWidows.TabIndex = 0;
            this.rdoWidows.TabStop = true;
            this.rdoWidows.Text = "Windows Authentication";
            this.rdoWidows.UseVisualStyleBackColor = true;
            this.rdoWidows.CheckedChanged += new System.EventHandler(this.rdoWidows_CheckedChanged);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(251, 45);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(203, 20);
            this.txtServerName.TabIndex = 7;
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(251, 105);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(203, 20);
            this.txtDataBaseName.TabIndex = 8;
            // 
            // gbProjectType
            // 
            this.gbProjectType.Controls.Add(this.cbDal);
            this.gbProjectType.Controls.Add(this.cbWcf);
            this.gbProjectType.Controls.Add(this.cbWebApi);
            this.gbProjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProjectType.Location = new System.Drawing.Point(522, 41);
            this.gbProjectType.Name = "gbProjectType";
            this.gbProjectType.Size = new System.Drawing.Size(227, 135);
            this.gbProjectType.TabIndex = 9;
            this.gbProjectType.TabStop = false;
            this.gbProjectType.Text = "ProjectType";
            // 
            // cbDal
            // 
            this.cbDal.AutoSize = true;
            this.cbDal.Location = new System.Drawing.Point(17, 98);
            this.cbDal.Name = "cbDal";
            this.cbDal.Size = new System.Drawing.Size(138, 20);
            this.cbDal.TabIndex = 2;
            this.cbDal.Text = "DataAccess Layer";
            this.cbDal.UseVisualStyleBackColor = true;
            // 
            // cbWcf
            // 
            this.cbWcf.AutoSize = true;
            this.cbWcf.Location = new System.Drawing.Point(17, 66);
            this.cbWcf.Name = "cbWcf";
            this.cbWcf.Size = new System.Drawing.Size(106, 20);
            this.cbWcf.TabIndex = 1;
            this.cbWcf.Text = "WCF Service";
            this.cbWcf.UseVisualStyleBackColor = true;
            // 
            // cbWebApi
            // 
            this.cbWebApi.AutoSize = true;
            this.cbWebApi.Location = new System.Drawing.Point(17, 31);
            this.cbWebApi.Name = "cbWebApi";
            this.cbWebApi.Size = new System.Drawing.Size(76, 20);
            this.cbWebApi.TabIndex = 0;
            this.cbWebApi.Text = "WebApi";
            this.cbWebApi.UseVisualStyleBackColor = true;
            // 
            // gbProjectDetails
            // 
            this.gbProjectDetails.Controls.Add(this.btnProjectLocation);
            this.gbProjectDetails.Controls.Add(this.txtNameSpaceName);
            this.gbProjectDetails.Controls.Add(this.txtProjectName);
            this.gbProjectDetails.Controls.Add(this.lblNameSpace);
            this.gbProjectDetails.Controls.Add(this.lblProjectName);
            this.gbProjectDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProjectDetails.Location = new System.Drawing.Point(415, 222);
            this.gbProjectDetails.Name = "gbProjectDetails";
            this.gbProjectDetails.Size = new System.Drawing.Size(347, 151);
            this.gbProjectDetails.TabIndex = 10;
            this.gbProjectDetails.TabStop = false;
            this.gbProjectDetails.Text = "ProjectDetails";
            // 
            // btnProjectLocation
            // 
            this.btnProjectLocation.Location = new System.Drawing.Point(92, 98);
            this.btnProjectLocation.Name = "btnProjectLocation";
            this.btnProjectLocation.Size = new System.Drawing.Size(170, 35);
            this.btnProjectLocation.TabIndex = 9;
            this.btnProjectLocation.Text = "Project Location";
            this.btnProjectLocation.UseVisualStyleBackColor = true;
            this.btnProjectLocation.Click += new System.EventHandler(this.btnProjectLocation_Click);
            // 
            // txtNameSpaceName
            // 
            this.txtNameSpaceName.Location = new System.Drawing.Point(170, 50);
            this.txtNameSpaceName.Name = "txtNameSpaceName";
            this.txtNameSpaceName.Size = new System.Drawing.Size(164, 22);
            this.txtNameSpaceName.TabIndex = 8;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(170, 21);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(164, 22);
            this.txtProjectName.TabIndex = 7;
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(28, 56);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(123, 16);
            this.lblNameSpace.TabIndex = 6;
            this.lblNameSpace.Text = "Namespace Name";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(28, 21);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(90, 16);
            this.lblProjectName.TabIndex = 5;
            this.lblProjectName.Text = "Project Name";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(76, 399);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(550, 35);
            this.progressBar.TabIndex = 11;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(649, 399);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(113, 35);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(57, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 454);
            this.panel1.TabIndex = 13;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(72, 478);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "message";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 517);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.gbProjectDetails);
            this.Controls.Add(this.gbProjectType);
            this.Controls.Add(this.txtDataBaseName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.gbAuthentication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "AmitFormGenreater";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbAuthentication.ResumeLayout(false);
            this.gbAuthentication.PerformLayout();
            this.gbProjectType.ResumeLayout(false);
            this.gbProjectType.PerformLayout();
            this.gbProjectDetails.ResumeLayout(false);
            this.gbProjectDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbAuthentication;
        private System.Windows.Forms.RadioButton rdoSqlServer;
        private System.Windows.Forms.RadioButton rdoWidows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.GroupBox gbProjectType;
        private System.Windows.Forms.CheckBox cbDal;
        private System.Windows.Forms.CheckBox cbWcf;
        private System.Windows.Forms.CheckBox cbWebApi;
        private System.Windows.Forms.GroupBox gbProjectDetails;
        private System.Windows.Forms.TextBox txtNameSpaceName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label lblNameSpace;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.FolderBrowserDialog fdProjectLocation;
        private System.Windows.Forms.Button btnProjectLocation;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
    }
}

