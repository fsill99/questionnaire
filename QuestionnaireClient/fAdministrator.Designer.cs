namespace QuestionnaireClient
{
    partial class fAdministrator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdManagementD = new System.Windows.Forms.Button();
            this.cmdManagementS = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdManagementD);
            this.groupBox1.Controls.Add(this.cmdManagementS);
            this.groupBox1.Location = new System.Drawing.Point(146, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Azioni";
            // 
            // cmdManagementD
            // 
            this.cmdManagementD.Location = new System.Drawing.Point(34, 110);
            this.cmdManagementD.Name = "cmdManagementD";
            this.cmdManagementD.Size = new System.Drawing.Size(157, 43);
            this.cmdManagementD.TabIndex = 3;
            this.cmdManagementD.Text = "Gestisci Database";
            this.cmdManagementD.UseVisualStyleBackColor = true;
            this.cmdManagementD.Click += new System.EventHandler(this.cmdManagementD_Click);
            // 
            // cmdManagementS
            // 
            this.cmdManagementS.Enabled = false;
            this.cmdManagementS.Location = new System.Drawing.Point(34, 31);
            this.cmdManagementS.Name = "cmdManagementS";
            this.cmdManagementS.Size = new System.Drawing.Size(157, 43);
            this.cmdManagementS.TabIndex = 2;
            this.cmdManagementS.Text = "Gestisci Server";
            this.cmdManagementS.UseVisualStyleBackColor = true;
            this.cmdManagementS.Click += new System.EventHandler(this.cmdManagementS_Click);
            // 
            // fAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 238);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fAdministrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire [Slezione azione] - Amministratore: ";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdManagementD;
        private System.Windows.Forms.Button cmdManagementS;


    }
}