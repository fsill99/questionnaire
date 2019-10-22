namespace QuestionnaireClient
{
    partial class fTopic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTopic));
            this.lblTopicName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.txtTopicDescription = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dblswQuestions = new DbListviewWinformControl.DbListview();
            this.dblwAnswerAss = new DbListviewWinformControl.DbListview();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTopicName
            // 
            this.lblTopicName.AutoSize = true;
            this.lblTopicName.BackColor = System.Drawing.Color.White;
            this.lblTopicName.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopicName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTopicName.Location = new System.Drawing.Point(21, 23);
            this.lblTopicName.Name = "lblTopicName";
            this.lblTopicName.Size = new System.Drawing.Size(264, 32);
            this.lblTopicName.TabIndex = 1;
            this.lblTopicName.Text = "Nome argomento: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Domande";
            // 
            // cmdInsert
            // 
            this.cmdInsert.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInsert.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdInsert.Location = new System.Drawing.Point(714, 127);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(200, 71);
            this.cmdInsert.TabIndex = 6;
            this.cmdInsert.Text = "Inserisci";
            this.cmdInsert.UseVisualStyleBackColor = false;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.BackColor = System.Drawing.SystemColors.Control;
            this.cmdModify.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModify.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdModify.Location = new System.Drawing.Point(714, 195);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(200, 71);
            this.cmdModify.TabIndex = 5;
            this.cmdModify.Text = "Modifica";
            this.cmdModify.UseVisualStyleBackColor = false;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDelete.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdDelete.Location = new System.Drawing.Point(714, 258);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(200, 71);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "Elimina";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // txtTopicDescription
            // 
            this.txtTopicDescription.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTopicDescription.Location = new System.Drawing.Point(291, 23);
            this.txtTopicDescription.Name = "txtTopicDescription";
            this.txtTopicDescription.Size = new System.Drawing.Size(493, 30);
            this.txtTopicDescription.TabIndex = 7;
            this.txtTopicDescription.TextChanged += new System.EventHandler(this.txtTopicDescription_TextChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSave.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.ForeColor = System.Drawing.Color.Maroon;
            this.cmdSave.Location = new System.Drawing.Point(714, 425);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(200, 71);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Salva";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.Color.Maroon;
            this.cmdCancel.Location = new System.Drawing.Point(714, 492);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(200, 71);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Annulla";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dblswQuestions
            // 
            this.dblswQuestions.DbEntityType = typeof(object);
            this.dblswQuestions.DisplayGuids = false;
            this.dblswQuestions.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dblswQuestions.FullRowSelect = true;
            this.dblswQuestions.Location = new System.Drawing.Point(19, 114);
            this.dblswQuestions.Name = "dblswQuestions";
            this.dblswQuestions.Properties = new System.Reflection.PropertyInfo[0];
            this.dblswQuestions.Size = new System.Drawing.Size(594, 201);
            this.dblswQuestions.TabIndex = 0;
            this.dblswQuestions.UseCompatibleStateImageBehavior = false;
            this.dblswQuestions.View = System.Windows.Forms.View.Details;
            this.dblswQuestions.SelectedIndexChanged += new System.EventHandler(this.dblswQuestions_SelectedIndexChanged);
            // 
            // dblwAnswerAss
            // 
            this.dblwAnswerAss.DbEntityType = typeof(object);
            this.dblwAnswerAss.DisplayGuids = false;
            this.dblwAnswerAss.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dblwAnswerAss.FullRowSelect = true;
            this.dblwAnswerAss.Location = new System.Drawing.Point(20, 369);
            this.dblwAnswerAss.Name = "dblwAnswerAss";
            this.dblwAnswerAss.Properties = new System.Reflection.PropertyInfo[0];
            this.dblwAnswerAss.Size = new System.Drawing.Size(593, 210);
            this.dblwAnswerAss.TabIndex = 10;
            this.dblwAnswerAss.UseCompatibleStateImageBehavior = false;
            this.dblwAnswerAss.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(22, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "Risposte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(585, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Funzionalità riferite alle domande";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // fTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1009, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dblwAnswerAss);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtTopicDescription);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.cmdModify);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTopicName);
            this.Controls.Add(this.dblswQuestions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire [Gestione Argomento] - Insegnante: ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DbListviewWinformControl.DbListview dblswQuestions;
        private System.Windows.Forms.Label lblTopicName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.TextBox txtTopicDescription;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private DbListviewWinformControl.DbListview dblwAnswerAss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}