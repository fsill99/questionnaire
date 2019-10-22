namespace QuestionnaireClient
{
    partial class fCurrentQuestionnaireSession
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.tmrElaspedTime = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEndSession = new System.Windows.Forms.Button();
            this.dgwSubmissions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubmissions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tempo trascorso:";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsedTime.ForeColor = System.Drawing.Color.White;
            this.lblElapsedTime.Location = new System.Drawing.Point(235, 30);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(0, 24);
            this.lblElapsedTime.TabIndex = 1;
            // 
            // tmrElaspedTime
            // 
            this.tmrElaspedTime.Enabled = true;
            this.tmrElaspedTime.Interval = 1000;
            this.tmrElaspedTime.Tick += new System.EventHandler(this.tmrElaspedTime_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consegne:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmdEndSession
            // 
            this.cmdEndSession.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEndSession.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEndSession.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdEndSession.Location = new System.Drawing.Point(291, 489);
            this.cmdEndSession.Name = "cmdEndSession";
            this.cmdEndSession.Size = new System.Drawing.Size(245, 77);
            this.cmdEndSession.TabIndex = 4;
            this.cmdEndSession.Text = "Termina esaminazione";
            this.cmdEndSession.UseVisualStyleBackColor = false;
            this.cmdEndSession.Click += new System.EventHandler(this.cmdEndSession_Click);
            // 
            // dgwSubmissions
            // 
            this.dgwSubmissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSubmissions.Location = new System.Drawing.Point(15, 128);
            this.dgwSubmissions.Name = "dgwSubmissions";
            this.dgwSubmissions.Size = new System.Drawing.Size(821, 355);
            this.dgwSubmissions.TabIndex = 5;
            // 
            // fCurrentQuestionnaireSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(848, 578);
            this.Controls.Add(this.dgwSubmissions);
            this.Controls.Add(this.cmdEndSession);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblElapsedTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fCurrentQuestionnaireSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire [Esaminazione] - Insegnante: ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fCurrentQuestionnaireSession_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubmissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Timer tmrElaspedTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEndSession;
        private System.Windows.Forms.DataGridView dgwSubmissions;
    }
}