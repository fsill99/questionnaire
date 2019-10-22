using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestionnaireLib;
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireClient
{
    public partial class fInsStudents : Form
    {
        public bool bOk;
        public Student Student;

        //student id null reference exception on insert new
        //do not modify student passwords
        public fInsStudents(Student student)
        {
            InitializeComponent();
            bOk = false;
            Student = student;

            for (int i = 1; i < 6; i++)
            {
                cboSchoolYear.Items.Add(i);
            }
            cboSchoolYear.Text = "1";
            txtFirstName.Text = student.FirstName;
            txtSecondName.Text = student.SecondName;
            if (student.BirthDate > dtpBirthDate.MinDate)
            {
                dtpBirthDate.Value = student.BirthDate;
            }
            if (student.Class != null)
            {
                cboSchoolYear.Text = student.Class.SchoolYear;
                cboCourse.Text = student.Class.Course;             
            }
            else
            {
                cboCourse.Text = "";
                cboSchoolYear.Text = "";
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            return txtFirstName.Text != "" && txtSecondName.Text != "";
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT ID FROM [Classes] WHERE SchoolYear=@SchoolYear AND Course=@Course";
                command.Parameters.AddWithValue("SchoolYear", cboSchoolYear.SelectedItem);
                command.Parameters.AddWithValue("Course", cboCourse.SelectedItem);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    if (ValidateData() == true)
                    {
                        Student.FirstName = txtFirstName.Text;
                        Student.SecondName = txtSecondName.Text;
                        if (dtpBirthDate.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
                        {
                            //Student.BirthDate = DateTime.Today;
                            Student.BirthDate = DateTime.Parse(DateTime.Today.ToShortDateString());
                        }
                        else
                        {
                            //Student.BirthDate = dtpBirthDate.Value;
                            Student.BirthDate = DateTime.Parse(dtpBirthDate.Value.ToShortDateString());
                        }

                        Student.Class = new Class(cboSchoolYear.Text, cboCourse.Text, reader.GetGuid(0));
                        bOk = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Dati non validi");
                    }
                }
            }
        }

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCourse.Items.Clear();
            cboCourse.Text = "";
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT Course FROM [Classes] WHERE SchoolYear=@SchoolYear";
                command.Parameters.AddWithValue("SchoolYear", cboSchoolYear.SelectedItem);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        cboCourse.Items.Add(reader.GetString(0));
                    }
                }
            }
            if(cboCourse.Items.Count>0)
                cboCourse.SelectedItem = cboCourse.Items[0];
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void classesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
