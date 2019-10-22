namespace QuestionnaireClient
{
    partial class fLoadQuestionnaire
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLoadQuestionnaire));
            this.cmdConfirm = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dblwQuestionnaireSessions = new DbListviewWinformControl.DbListview();
            this.dblwQuestionnaireSession = new DbListviewWinformControl.DbListview();
            this.SuspendLayout();
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConfirm.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.cmdConfirm.Location = new System.Drawing.Point(194, 567);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Size = new System.Drawing.Size(198, 74);
            this.cmdConfirm.TabIndex = 1;
            this.cmdConfirm.Text = "OK";
            this.cmdConfirm.UseVisualStyleBackColor = false;
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.cmdCancel.Location = new System.Drawing.Point(570, 567);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(198, 74);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "ANNULLA";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dblwQuestionnaireSessions
            // 
            this.dblwQuestionnaireSessions.DbEntityType = typeof(object);
            this.dblwQuestionnaireSessions.DisplayGuids = false;
            this.dblwQuestionnaireSessions.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dblwQuestionnaireSessions.FullRowSelect = true;
            this.dblwQuestionnaireSessions.Location = new System.Drawing.Point(14, 14);
            this.dblwQuestionnaireSessions.Name = "dblwQuestionnaireSessions";
            this.dblwQuestionnaireSessions.Properties = new System.Reflection.PropertyInfo[0];
            this.dblwQuestionnaireSessions.Size = new System.Drawing.Size(922, 504);
            this.dblwQuestionnaireSessions.TabIndex = 0;
            this.dblwQuestionnaireSessions.UseCompatibleStateImageBehavior = false;
            this.dblwQuestionnaireSessions.View = System.Windows.Forms.View.Details;
            // 
            // dblwQuestionnaireSession
            // 
            this.dblwQuestionnaireSession.DbEntityType = typeof(object);
            this.dblwQuestionnaireSession.DisplayGuids = false;
            this.dblwQuestionnaireSession.FullRowSelect = true;
            this.dblwQuestionnaireSession.Location = new System.Drawing.Point(12, 12);
            this.dblwQuestionnaireSession.Name = "dblwQuestionnaireSession";
            this.dblwQuestionnaireSession.Properties = new System.Reflection.PropertyInfo[0];
            this.dblwQuestionnaireSession.Size = new System.Drawing.Size(467, 377);
            this.dblwQuestionnaireSession.TabIndex = 0;
            this.dblwQuestionnaireSession.UseCompatibleStateImageBehavior = false;
            this.dblwQuestionnaireSession.View = System.Windows.Forms.View.Details;
            // 
            // fLoadQuestionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(950, 683);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.dblwQuestionnaireSessions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "fLoadQuestionnaire";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleziona questionario da esaminazione precedente";
            this.ResumeLayout(false);

        }

        #endregion

        private DbListviewWinformControl.DbListview dblwQuestionnaireSession;
        private DbListviewWinformControl.DbListview dblwQuestionnaireSessions;
        private System.Windows.Forms.Button cmdConfirm;
        private System.Windows.Forms.Button cmdCancel;
    }
}