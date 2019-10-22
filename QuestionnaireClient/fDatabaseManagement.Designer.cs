namespace QuestionnaireClient
{
    partial class fDatabaseManagement
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTeachers = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvTeachers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdInsertS = new System.Windows.Forms.Button();
            this.cmdModifyS = new System.Windows.Forms.Button();
            this.cmdDeleteS = new System.Windows.Forms.Button();
            this.lsvStudents = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAdministrators = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdInsertA = new System.Windows.Forms.Button();
            this.cmdModifyA = new System.Windows.Forms.Button();
            this.cmdDeleteA = new System.Windows.Forms.Button();
            this.lsvAdministrators = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.tabTeachers.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabAdministrators.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTeachers);
            this.tabControl.Controls.Add(this.tabStudents);
            this.tabControl.Controls.Add(this.tabAdministrators);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1027, 800);
            this.tabControl.TabIndex = 1;
            // 
            // tabTeachers
            // 
            this.tabTeachers.BackColor = System.Drawing.Color.SeaGreen;
            this.tabTeachers.Controls.Add(this.label1);
            this.tabTeachers.Controls.Add(this.lsvTeachers);
            this.tabTeachers.Controls.Add(this.cmdDelete);
            this.tabTeachers.Controls.Add(this.cmdModify);
            this.tabTeachers.Controls.Add(this.cmdInsert);
            this.tabTeachers.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTeachers.Location = new System.Drawing.Point(4, 32);
            this.tabTeachers.Name = "tabTeachers";
            this.tabTeachers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeachers.Size = new System.Drawing.Size(1019, 764);
            this.tabTeachers.TabIndex = 0;
            this.tabTeachers.Text = "Docenti";
            this.tabTeachers.Click += new System.EventHandler(this.tabTeachers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(346, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "GESTISCI DOCENTI";
            // 
            // lsvTeachers
            // 
            this.lsvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvTeachers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvTeachers.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvTeachers.FullRowSelect = true;
            this.lsvTeachers.GridLines = true;
            this.lsvTeachers.Location = new System.Drawing.Point(8, 73);
            this.lsvTeachers.Name = "lsvTeachers";
            this.lsvTeachers.Scrollable = false;
            this.lsvTeachers.Size = new System.Drawing.Size(775, 502);
            this.lsvTeachers.TabIndex = 0;
            this.lsvTeachers.UseCompatibleStateImageBehavior = false;
            this.lsvTeachers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome";
            this.columnHeader1.Width = 154;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cognome";
            this.columnHeader2.Width = 173;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data di Nascita";
            this.columnHeader3.Width = 203;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Password";
            this.columnHeader4.Width = 241;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(811, 257);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(189, 95);
            this.cmdDelete.TabIndex = 3;
            this.cmdDelete.Text = "Elimina";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdModify.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModify.Location = new System.Drawing.Point(811, 418);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(189, 92);
            this.cmdModify.TabIndex = 2;
            this.cmdModify.Text = "Modifica";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdInsert
            // 
            this.cmdInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInsert.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.Location = new System.Drawing.Point(811, 105);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(189, 92);
            this.cmdInsert.TabIndex = 1;
            this.cmdInsert.Text = "Inserisci";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // tabStudents
            // 
            this.tabStudents.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tabStudents.Controls.Add(this.label2);
            this.tabStudents.Controls.Add(this.cmdInsertS);
            this.tabStudents.Controls.Add(this.cmdModifyS);
            this.tabStudents.Controls.Add(this.cmdDeleteS);
            this.tabStudents.Controls.Add(this.lsvStudents);
            this.tabStudents.Location = new System.Drawing.Point(4, 32);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1019, 764);
            this.tabStudents.TabIndex = 1;
            this.tabStudents.Text = "Studenti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(339, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "GESTISCI STUDENTI";
            // 
            // cmdInsertS
            // 
            this.cmdInsertS.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsertS.Location = new System.Drawing.Point(814, 100);
            this.cmdInsertS.Name = "cmdInsertS";
            this.cmdInsertS.Size = new System.Drawing.Size(178, 94);
            this.cmdInsertS.TabIndex = 3;
            this.cmdInsertS.Text = "Inserisci";
            this.cmdInsertS.UseVisualStyleBackColor = true;
            this.cmdInsertS.Click += new System.EventHandler(this.cmdInsertS_Click);
            // 
            // cmdModifyS
            // 
            this.cmdModifyS.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModifyS.Location = new System.Drawing.Point(814, 410);
            this.cmdModifyS.Name = "cmdModifyS";
            this.cmdModifyS.Size = new System.Drawing.Size(178, 94);
            this.cmdModifyS.TabIndex = 2;
            this.cmdModifyS.Text = "Modifica";
            this.cmdModifyS.UseVisualStyleBackColor = true;
            this.cmdModifyS.Click += new System.EventHandler(this.cmdModifyS_Click);
            // 
            // cmdDeleteS
            // 
            this.cmdDeleteS.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteS.Location = new System.Drawing.Point(814, 248);
            this.cmdDeleteS.Name = "cmdDeleteS";
            this.cmdDeleteS.Size = new System.Drawing.Size(178, 91);
            this.cmdDeleteS.TabIndex = 1;
            this.cmdDeleteS.Text = "Elimina";
            this.cmdDeleteS.UseVisualStyleBackColor = true;
            this.cmdDeleteS.Click += new System.EventHandler(this.cmdDeleteS_Click);
            // 
            // lsvStudents
            // 
            this.lsvStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lsvStudents.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvStudents.FullRowSelect = true;
            this.lsvStudents.GridLines = true;
            this.lsvStudents.Location = new System.Drawing.Point(8, 69);
            this.lsvStudents.Name = "lsvStudents";
            this.lsvStudents.Size = new System.Drawing.Size(776, 506);
            this.lsvStudents.TabIndex = 0;
            this.lsvStudents.UseCompatibleStateImageBehavior = false;
            this.lsvStudents.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nome";
            this.columnHeader5.Width = 171;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Cognome";
            this.columnHeader6.Width = 181;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Data di Nascita";
            this.columnHeader7.Width = 217;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Classe";
            this.columnHeader8.Width = 91;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Sezione";
            this.columnHeader9.Width = 112;
            // 
            // tabAdministrators
            // 
            this.tabAdministrators.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tabAdministrators.Controls.Add(this.label3);
            this.tabAdministrators.Controls.Add(this.cmdInsertA);
            this.tabAdministrators.Controls.Add(this.cmdModifyA);
            this.tabAdministrators.Controls.Add(this.cmdDeleteA);
            this.tabAdministrators.Controls.Add(this.lsvAdministrators);
            this.tabAdministrators.Location = new System.Drawing.Point(4, 32);
            this.tabAdministrators.Name = "tabAdministrators";
            this.tabAdministrators.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdministrators.Size = new System.Drawing.Size(1019, 764);
            this.tabAdministrators.TabIndex = 2;
            this.tabAdministrators.Text = "Amministratori";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(276, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(466, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "GESTISCI AMMINISTRATORI";
            // 
            // cmdInsertA
            // 
            this.cmdInsertA.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsertA.Location = new System.Drawing.Point(819, 113);
            this.cmdInsertA.Name = "cmdInsertA";
            this.cmdInsertA.Size = new System.Drawing.Size(175, 95);
            this.cmdInsertA.TabIndex = 3;
            this.cmdInsertA.Text = "Inserisci";
            this.cmdInsertA.UseVisualStyleBackColor = true;
            this.cmdInsertA.Click += new System.EventHandler(this.cmdInsertA_Click);
            // 
            // cmdModifyA
            // 
            this.cmdModifyA.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModifyA.Location = new System.Drawing.Point(819, 426);
            this.cmdModifyA.Name = "cmdModifyA";
            this.cmdModifyA.Size = new System.Drawing.Size(175, 92);
            this.cmdModifyA.TabIndex = 2;
            this.cmdModifyA.Text = "Modifica";
            this.cmdModifyA.UseVisualStyleBackColor = true;
            this.cmdModifyA.Click += new System.EventHandler(this.cmdModifyA_Click);
            // 
            // cmdDeleteA
            // 
            this.cmdDeleteA.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeleteA.Location = new System.Drawing.Point(819, 269);
            this.cmdDeleteA.Name = "cmdDeleteA";
            this.cmdDeleteA.Size = new System.Drawing.Size(175, 94);
            this.cmdDeleteA.TabIndex = 1;
            this.cmdDeleteA.Text = "Elimina";
            this.cmdDeleteA.UseVisualStyleBackColor = true;
            this.cmdDeleteA.Click += new System.EventHandler(this.cmdDeleteA_Click);
            // 
            // lsvAdministrators
            // 
            this.lsvAdministrators.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lsvAdministrators.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvAdministrators.FullRowSelect = true;
            this.lsvAdministrators.GridLines = true;
            this.lsvAdministrators.Location = new System.Drawing.Point(8, 70);
            this.lsvAdministrators.Name = "lsvAdministrators";
            this.lsvAdministrators.Size = new System.Drawing.Size(781, 505);
            this.lsvAdministrators.TabIndex = 0;
            this.lsvAdministrators.TileSize = new System.Drawing.Size(1, 1);
            this.lsvAdministrators.UseCompatibleStateImageBehavior = false;
            this.lsvAdministrators.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Nome";
            this.columnHeader10.Width = 156;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Cognome";
            this.columnHeader11.Width = 157;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Data di Nascita";
            this.columnHeader12.Width = 210;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Password";
            this.columnHeader13.Width = 254;
            // 
            // fDatabaseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 619);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fDatabaseManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire [Gestione Database] - Amministratore: ";
            this.tabControl.ResumeLayout(false);
            this.tabTeachers.ResumeLayout(false);
            this.tabTeachers.PerformLayout();
            this.tabStudents.ResumeLayout(false);
            this.tabStudents.PerformLayout();
            this.tabAdministrators.ResumeLayout(false);
            this.tabAdministrators.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTeachers;
        private System.Windows.Forms.ListView lsvTeachers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.Button cmdInsertS;
        private System.Windows.Forms.Button cmdModifyS;
        private System.Windows.Forms.Button cmdDeleteS;
        private System.Windows.Forms.ListView lsvStudents;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabAdministrators;
        private System.Windows.Forms.Button cmdInsertA;
        private System.Windows.Forms.Button cmdModifyA;
        private System.Windows.Forms.Button cmdDeleteA;
        private System.Windows.Forms.ListView lsvAdministrators;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}