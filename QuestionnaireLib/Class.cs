using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class Class : IDBEntity
    {
        public Guid ID {get; set;}
        public string SchoolYear { get; set; }
        public string Course { get; set; }

        /// <summary>
        /// Default constructor. (non-existing record)
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="course"></param>
        /// <param name="ID"></param>
        public Class(string schoolYear, string course)
        {
            this.SchoolYear = schoolYear;
            this.Course = course;
        }

        /// <summary>
        /// Default constructor. (existing record)
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="course"></param>
        /// <param name="ID"></param>
        public Class(string schoolYear, string course, Guid ID)
        {
            this.ID = ID;
            this.SchoolYear = schoolYear;
            this.Course = course;
        }

        /// <summary>
        /// Retrieves the class corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Class FromID(Guid classID)
        {
            using(OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using(OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Classes] WHERE ID=@ClassID";
                command.Parameters.AddWithValue("ClassID", classID);
                
                using(DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Class(reader.GetString(1), reader.GetString(2), reader.GetGuid(0));
                }
            }
        }

        /// <summary>
        /// Retrieves a class form its schoolyear and course.
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        public static Class FromData(string schoolYear, string course)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Classes] WHERE SchoolYear=@SchoolYear AND Course=@Course";
                command.Parameters.AddWithValue("SchoolYear", schoolYear);
                command.Parameters.AddWithValue("Course", course);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Class(reader.GetString(1), reader.GetString(2), reader.GetGuid(0));
                }
            }
        }

        /// <summary>
        /// Saves the object if it already exists in the db, or creates it in the db.
        /// </summary>
        public async void SaveAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            if (ID.Equals(new Guid()))
             {
                 //new record, insert it into db and update the ID property of the current object
                 command = new OleDbCommand("INSERT INTO Class(ID, SchoolYear, Course) VALUES (@ID, @SchoolYear, @Course)",
                     conn);
                 command.Parameters.AddWithValue("ID", Guid.NewGuid());
                 command.Parameters.AddWithValue("SchoolYear", SchoolYear);
                 command.Parameters.AddWithValue("Course", Course);
                 ID = (Guid)(command.Parameters["ID"].Value);
                 await command.ExecuteNonQueryAsync();
             }
            else
            {
                //existing record, update it
                 command = new OleDbCommand("UPDATE Classes SET SchoolYear=@SchoolYear, Course=@Course WHERE ID=@ID",
                     conn);
                 command.Parameters.AddWithValue("SchoolYear", SchoolYear);
                 command.Parameters.AddWithValue("Course", Course);
                 command.Parameters.AddWithValue("ID", ID);
                 await command.ExecuteNonQueryAsync();
            }

            conn.Close();

        }

        /// <summary>
        /// Delete the object
        /// </summary>
        public async void DeleteAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("DELETE * FROM Classes WHERE Classes.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Get all Classes
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Class>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Class> classes = new List<Class>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT * FROM Classes",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                classes.Add(new Class(reader.GetString(1), reader.GetString(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return classes;
        }

        /// <summary>
        /// Retrives the student associated with this class.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetStudentsAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            List<Student> students = new List<Student>();
            DbDataReader reader;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Students.*, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM (( Students INNER JOIN Users ON Students.USER_ID=Users.ID) INNER JOIN Classes ON Students.CLASS_ID=Classes.ID) WHERE Classes.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                BasicUserProperties properties;

                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(3);
                properties.SecondName = reader.GetString(4);
                properties.BirthDate = reader.GetDateTime(5);
                students.Add(new Student(properties, this, reader.GetGuid(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return students;
        }

        /// <summary>
        /// Retrives the teacher associated with this class.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            List<Teacher> teacher = new List<Teacher>();
            DbDataReader reader;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Teachers.*, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM (((Teachers INNER JOIN Users ON Teacher.USER_ID=Teachers.ID) INNER JOIN TeachesClass ON TeachesClass.TEACHER_ID=Teachers.ID) INNER JOIN Classes ON TeachesClass.CLASS_ID=Classes.ID) WHERE Classes.ID=@ID'",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                BasicUserProperties properties;

                properties = new BasicUserProperties(reader.GetString(3), reader.GetString(4), reader.GetDateTime(5), reader.GetString(6));
                teacher.Add(new Teacher(properties, reader.GetGuid(1), reader.GetGuid(0)));

            }

            reader.Close();
            conn.Close();
            return teacher;
        }

    }
}
