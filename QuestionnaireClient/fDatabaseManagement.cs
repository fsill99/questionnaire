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
    public partial class fDatabaseManagement : Form
    {
        Administrator Administrator;

        public fDatabaseManagement(Administrator administrator)
        {
            InitializeComponent();
            ControlsUtilities.ApplyAppIcon(this);
            Text += administrator.FullName;

            Administrator = administrator;

            ShowTeachers();
            ShowStudents();
            ShowAdministrators();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            fInsert Insert;
            Insert = new fInsert();
            Insert.ShowDialog();
            if (Insert.bOk == true)
            {
                Teacher newTeacher = new Teacher(Insert.UserProperties);
                newTeacher.SaveAsync();
                ShowTeachers();
            }
        }

        void ShowTeachers()
        {
            ListViewItem row;
            ListViewItem.ListViewSubItem elem;
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            string query;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            lsvTeachers.Items.Clear();

            query = "SELECT Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password, Teachers.ID, Users.ID FROM Teachers INNER JOIN Users ON Teachers.USER_ID=Users.ID";
            command = new OleDbCommand(query, conn);
            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                Teacher teacher;
                BasicUserProperties properties = new BasicUserProperties();

                //create a new row
                row = new ListViewItem();

                //create,set first cell
                row.Text = properties.FirstName = reader.GetString(0);

                //create subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = properties.SecondName = reader.GetString(1);
                row.SubItems.Add(elem);
                //create the second subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                properties.BirthDate = reader.GetDateTime(2);
                elem.Text = properties.BirthDate.ToShortDateString();
                row.SubItems.Add(elem);

                //create the third subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = properties.Password = reader.GetString(3);
                row.SubItems.Add(elem);

                //add row at listview
                lsvTeachers.Items.Add(row);

                teacher = new Teacher(properties, reader.GetGuid(5), reader.GetGuid(4));
                //set the reference at the object
                row.Tag = teacher;
            }
            conn.Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lsvTeachers.SelectedItems.Count > 0)
            {
                Teacher teacher = (Teacher)lsvTeachers.SelectedItems[0].Tag;
                teacher.DeleteAsync();
                ShowTeachers();
            }
            else
            {
                MessageBox.Show("Seleziona un record!");
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            fInsert Insert;
            Insert = new fInsert();

            if (lsvTeachers.SelectedItems.Count > 0)
            {
                Teacher teacher = (Teacher)lsvTeachers.SelectedItems[0].Tag;
                Insert.txtFirstName.Text = teacher.FirstName;
                Insert.txtSecondName.Text = teacher.SecondName;
                Insert.txtPassword.Text = teacher.Password;
                Insert.dtpBirthDate.Value = teacher.BirthDate;
                Insert.ShowDialog();
                if (Insert.bOk == true)
                {
                    teacher.FirstName = Insert.UserProperties.FirstName;
                    teacher.SecondName = Insert.UserProperties.SecondName;
                    teacher.BirthDate = Insert.UserProperties.BirthDate;
                    teacher.Password = Insert.UserProperties.Password;
                    teacher.SaveAsync();
                    ShowTeachers();
                }
            }
            else
            {
                MessageBox.Show("Seleziona un record!");
            }
        }

        async void ShowStudents()
        {
            ListViewItem row;
            ListViewItem.ListViewSubItem elem;

            lsvStudents.Items.Clear();

            foreach (Student newStudent in (await Student.GetAllAsync()))
            {
                row = new ListViewItem();
                row.Text = newStudent.FirstName;

                elem = new ListViewItem.ListViewSubItem();
                elem.Text = newStudent.SecondName;
                row.SubItems.Add(elem);

                elem = new ListViewItem.ListViewSubItem();
                elem.Text = newStudent.BirthDate.ToShortDateString();
                row.SubItems.Add(elem);

                elem = new ListViewItem.ListViewSubItem();
                elem.Text = newStudent.Class.SchoolYear;
                row.SubItems.Add(elem);

                elem = new ListViewItem.ListViewSubItem();
                elem.Text = newStudent.Class.Course;
                row.SubItems.Add(elem);

                lsvStudents.Items.Add(row);
                row.Tag = newStudent;
            }
        }

        private void cmdDeleteS_Click(object sender, EventArgs e)
        {
            if (lsvStudents.SelectedItems.Count > 0)
            {
                Student student = (Student)lsvStudents.SelectedItems[0].Tag;
                student.DeleteAsync();
                ShowStudents();
            }
            else
            {
                MessageBox.Show("seleziona un record!");
            }
        }

        private void cmdInsertS_Click(object sender, EventArgs e)
        {
            BasicUserProperties properties = new BasicUserProperties();
            Student newStudent = new Student(properties);
            fInsStudents InsStudents = new fInsStudents(newStudent);
            InsStudents.ShowDialog();
            if (InsStudents.bOk == true)
            {
                newStudent.SaveAsync();
                ShowStudents();
            }
        }

        private void cmdDeleteA_Click(object sender, EventArgs e)
        {

            if (lsvAdministrators.SelectedItems.Count > 0)
            {
                Administrator admin = (Administrator)lsvAdministrators.SelectedItems[0].Tag;
                admin.DeleteAsync();
                ShowAdministrators();
            }
            else
            {
                MessageBox.Show("Seleziona un record!");
            }
        }

        private void cmdModifyA_Click(object sender, EventArgs e)
        {
            Administrator administrator = (Administrator)lsvAdministrators.SelectedItems[0].Tag;
            fInsertA Insert;

            if (lsvAdministrators.SelectedItems.Count > 0)
            {

                Insert = new fInsertA(new BasicUserProperties(administrator.FirstName, administrator.SecondName, administrator.BirthDate, administrator.Password));
                Insert.ShowDialog();

                if (Insert.bOk == true)
                {
                    administrator.FirstName = Insert.UserProperties.FirstName;
                    administrator.SecondName = Insert.UserProperties.SecondName;
                    administrator.BirthDate = Insert.UserProperties.BirthDate;
                    administrator.Password = Insert.UserProperties.Password;
                    administrator.SaveAsync();
                    ShowAdministrators();
                }
            }
            else
            {
                MessageBox.Show("Seleziona un record!");
            }
        }


        private void cmdInsertA_Click(object sender, EventArgs e)
        {
            fInsert Insert;
            Insert = new fInsert();
            Insert.ShowDialog();
            if (Insert.bOk == true)
            {
                Administrator newAdmin = new Administrator(Insert.UserProperties);
                newAdmin.SaveAsync();
                ShowAdministrators();
            }
        }

        void ShowAdministrators()
        {
            ListViewItem row;
            ListViewItem.ListViewSubItem elem;
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            string query;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            lsvAdministrators.Items.Clear();

            query = "SELECT Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password, Administrators.ID, Users.ID FROM Administrators INNER JOIN Users ON Administrators.USER_ID=Users.ID";
            command = new OleDbCommand(query, conn);
            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                Administrator administrator;
                BasicUserProperties properties = new BasicUserProperties();

                //create a new row
                row = new ListViewItem();

                //create,set first cell
                row.Text = properties.FirstName = reader.GetString(0);

                //create subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = properties.SecondName = reader.GetString(1);
                row.SubItems.Add(elem);
                //create the second subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                properties.BirthDate = reader.GetDateTime(2);
                elem.Text = properties.BirthDate.ToShortDateString();
                row.SubItems.Add(elem);

                //create the third subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = properties.Password = reader.GetString(3);
                row.SubItems.Add(elem);

                //add row at listview
                lsvAdministrators.Items.Add(row);

                administrator = new Administrator(properties, reader.GetGuid(5), reader.GetGuid(4));
                //set the reference at the object
                row.Tag = administrator;
            }
            conn.Close();
        }

        private void cmdModifyS_Click(object sender, EventArgs e)
        {

            fInsertS InsertS;
            InsertS = new fInsertS();

            if (lsvStudents.SelectedItems.Count > 0)
            {
                Student student = (Student)lsvStudents.SelectedItems[0].Tag;
                InsertS.txtFirstName.Text = student.FirstName;
                InsertS.txtSecondName.Text = student.SecondName;
                //Insert.txtPassword.Text = teacher.Password;
                InsertS.dtpBirthDate.Value = student.BirthDate;

                InsertS.ShowDialog();
                if (InsertS.bOk == true)
                {
                    student.FirstName = InsertS.UserProperties.FirstName;
                    student.SecondName = InsertS.UserProperties.SecondName;
                    student.BirthDate = InsertS.UserProperties.BirthDate;
                    //student.Password = Insert.UserProperties.Password;
                    student.SaveAsync();
                    ShowStudents();
                }
            }
            else
            {
                MessageBox.Show("Seleziona un record!");
            }
        }

        private void tabTeachers_Click(object sender, EventArgs e)
        {

        }
    }
}
    

