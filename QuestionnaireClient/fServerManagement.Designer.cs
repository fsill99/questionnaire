namespace QuestionnaireClient
{
    partial class fServerManagement
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
            this.cmdCommitChanges = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdSetDefaultValues = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAppPoolName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSitePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuHelp = new System.Windows.Forms.MenuStrip();
            this.aiutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiModifyMethodInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiModifyDataInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiServerErrors = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCommitChanges
            // 
            this.cmdCommitChanges.Location = new System.Drawing.Point(302, 387);
            this.cmdCommitChanges.Name = "cmdCommitChanges";
            this.cmdCommitChanges.Size = new System.Drawing.Size(116, 43);
            this.cmdCommitChanges.TabIndex = 12;
            this.cmdCommitChanges.Text = "Salva modifiche";
            this.cmdCommitChanges.UseVisualStyleBackColor = true;
            this.cmdCommitChanges.Click += new System.EventHandler(this.cmdCommitChanges_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmdSetDefaultValues);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.txtSitePath);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSiteName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 354);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurazione veloce sito IIS";
            // 
            // cmdSetDefaultValues
            // 
            this.cmdSetDefaultValues.Location = new System.Drawing.Point(263, 306);
            this.cmdSetDefaultValues.Name = "cmdSetDefaultValues";
            this.cmdSetDefaultValues.Size = new System.Drawing.Size(163, 31);
            this.cmdSetDefaultValues.TabIndex = 20;
            this.cmdSetDefaultValues.Text = "Reimposta a valori di default";
            this.cmdSetDefaultValues.UseVisualStyleBackColor = true;
            this.cmdSetDefaultValues.Click += new System.EventHandler(this.cmdSetDefaultValues_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtAppPoolName);
            this.groupBox2.Location = new System.Drawing.Point(19, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 60);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informazioni Application Pool";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nome Application Pool:";
            // 
            // txtAppPoolName
            // 
            this.txtAppPoolName.Location = new System.Drawing.Point(134, 27);
            this.txtAppPoolName.Name = "txtAppPoolName";
            this.txtAppPoolName.ReadOnly = true;
            this.txtAppPoolName.Size = new System.Drawing.Size(177, 20);
            this.txtAppPoolName.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHostname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(19, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 102);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni binding";
            // 
            // txtHostname
            // 
            this.txtHostname.Location = new System.Drawing.Point(127, 74);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(184, 20);
            this.txtHostname.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(127, 22);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 20);
            this.txtPort.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Indirizzo IP:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(127, 48);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(184, 20);
            this.txtIPAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hostname:";
            // 
            // txtSitePath
            // 
            this.txtSitePath.Location = new System.Drawing.Point(132, 59);
            this.txtSitePath.Name = "txtSitePath";
            this.txtSitePath.ReadOnly = true;
            this.txtSitePath.Size = new System.Drawing.Size(547, 20);
            this.txtSitePath.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Percorso fisico:";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(132, 33);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.ReadOnly = true;
            this.txtSiteName.Size = new System.Drawing.Size(177, 20);
            this.txtSiteName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nome del sito:";
            // 
            // menuHelp
            // 
            this.menuHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aiutoToolStripMenuItem});
            this.menuHelp.Location = new System.Drawing.Point(0, 0);
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(720, 24);
            this.menuHelp.TabIndex = 20;
            this.menuHelp.Text = "menuStrip1";
            // 
            // aiutoToolStripMenuItem
            // 
            this.aiutoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiInfo,
            this.tsiModifyMethodInfo,
            this.tsiModifyDataInfo,
            this.tsiServerErrors});
            this.aiutoToolStripMenuItem.Name = "aiutoToolStripMenuItem";
            this.aiutoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aiutoToolStripMenuItem.Text = "Aiuto";
            // 
            // tsiInfo
            // 
            this.tsiInfo.Name = "tsiInfo";
            this.tsiInfo.Size = new System.Drawing.Size(443, 22);
            this.tsiInfo.Text = "Cos\'è questo pannello?";
            this.tsiInfo.Click += new System.EventHandler(this.tsiInfo_Click);
            // 
            // tsiModifyMethodInfo
            // 
            this.tsiModifyMethodInfo.Name = "tsiModifyMethodInfo";
            this.tsiModifyMethodInfo.Size = new System.Drawing.Size(443, 22);
            this.tsiModifyMethodInfo.Text = "Come modifico gli altri dati?";
            this.tsiModifyMethodInfo.Click += new System.EventHandler(this.tsiModifyMethodInfo_Click);
            // 
            // tsiModifyDataInfo
            // 
            this.tsiModifyDataInfo.Name = "tsiModifyDataInfo";
            this.tsiModifyDataInfo.Size = new System.Drawing.Size(443, 22);
            this.tsiModifyDataInfo.Text = "Quali dati posso modificare dal pannello di IIS?";
            this.tsiModifyDataInfo.Click += new System.EventHandler(this.tsiModifyDataInfo_Click);
            // 
            // tsiServerErrors
            // 
            this.tsiServerErrors.Name = "tsiServerErrors";
            this.tsiServerErrors.Size = new System.Drawing.Size(443, 22);
            this.tsiServerErrors.Text = "Visualizzo errori http quando cerco di accedere al sito tramite browser.";
            this.tsiServerErrors.Click += new System.EventHandler(this.tsiServerErrors_Click);
            // 
            // fServerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 439);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdCommitChanges);
            this.Controls.Add(this.menuHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuHelp;
            this.MaximizeBox = false;
            this.Name = "fServerManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire [Gestione Server] - Amministratore: ";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuHelp.ResumeLayout(false);
            this.menuHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCommitChanges;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAppPoolName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSitePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSetDefaultValues;
        private System.Windows.Forms.MenuStrip menuHelp;
        private System.Windows.Forms.ToolStripMenuItem aiutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiInfo;
        private System.Windows.Forms.ToolStripMenuItem tsiModifyMethodInfo;
        private System.Windows.Forms.ToolStripMenuItem tsiModifyDataInfo;
        private System.Windows.Forms.ToolStripMenuItem tsiServerErrors;
    }
}