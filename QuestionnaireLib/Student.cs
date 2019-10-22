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
    public sealed class Student : User, IDBEntity
    {
        private Class _class;

        public Guid ID
        {
            get { return (Guid)Properties["Students.ID"]; }
            set { Properties["Students.ID"] = value; }
        }

        public Class Class
        {
            get
            {
                if (_class == null && !ID.Equals(new Guid()))
                    _class = GetClass();
                return _class;
            }
            set
            {
                _class = value;
            }
        }

        /// <summary>
        /// Constructs new student from properties. (non-existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Student(BasicUserProperties basicProperties)
            : base(
                FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
            , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
            , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
            , new KeyValuePair<string, object>("Students.ID", new Guid())
            , new KeyValuePair<string, object>("Users.ID", new Guid())
            , new KeyValuePair<string, object>("Password", null))
            )
        {
            
        }

        /// <summary>
        /// Constructs new student from properties. (existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Student(BasicUserProperties basicProperties, Class sClass, Guid userID, Guid ID)
            : base(
                FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
            , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
            , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
            , new KeyValuePair<string, object>("Students.ID", ID)
            , new KeyValuePair<string, object>("Users.ID", userID)
            , new KeyValuePair<string, object>("Password", null))
            )
        {
            _class = sClass;
        }

        /// <summary>
        /// Constructs new student from properties. (existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Student(BasicUserProperties basicProperties, Guid classID, Guid userID, Guid ID)
            : this(basicProperties, Class.FromID(classID), userID, ID)
        {

        }

        /// <summary>
        /// Construct object from existing user object. (Useful after User object authentication).
        /// </summary>
        /// <param name="user">The existing user.</param>
        public Student(User user)
            : base(user.Properties)
        {
            
        }

        /// <summary>
        /// Authenticates the Student.
        /// </summary>
        /// <param name="queryRestrictions">Restrictions added in the query WHERE clause. (Key is field name, Value is field value)</param>
        /// <returns>Type of the authentication obtained.</returns>
        public async Task<AuthenticationType> AuthenticateAsync(Dictionary<string, object> queryRestrictions = null)
        {
            return await base.AuthenticateAsync(AuthenticationType.Student, queryRestrictions);
        }

        /// <summary>
        /// Retrieves the student corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Student FromID(Guid studentID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM (Students INNER JOIN Users ON Students.USER_ID=Users.ID)INNER JOIN Classes ON Students.CLASS_ID=Classes.ID WHERE ID=@StudentID";
                command.Parameters.AddWithValue("StudentID", studentID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    BasicUserProperties properties = new BasicUserProperties();
                    properties.FirstName = reader.GetString(5);
                    properties.SecondName = reader.GetString(6);
                    properties.BirthDate = reader.GetDateTime(7);
                    return new Student(properties, reader.GetGuid(1), reader.GetGuid(2), reader.GetGuid(0));
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
                command = new OleDbCommand("INSERT INTO Users(ID, FirstName, SecondName, BirthDate) VALUES(@ID, @FirstName, @SecondName, @BirthDate)",
                    conn);
                command.Parameters.AddWithValue("ID", UserID = Guid.NewGuid());
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("SecondName", SecondName);
                command.Parameters.AddWithValue("BirthDate", BirthDate);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("INSERT INTO Students (ID, CLASS_ID, USER_ID) VALUES (@ID,@ClassID, @UserID)",
                    conn);
                command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                command.Parameters.AddWithValue("ClassID", Class.ID);
                command.Parameters.AddWithValue("UserID", UserID);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                command = new OleDbCommand("UPDATE Users SET FirstName=@FirstName, SecondName=@SecondName, BirthDate=@BirthDate WHERE Users.ID = @UserID",
                    conn);
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("SecondName", SecondName);
                command.Parameters.AddWithValue("BirthDate", BirthDate);
                command.Parameters.AddWithValue("UserID", UserID);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("UPDATE Students SET USER_ID=@UserID, CLASS_ID=@ClassID WHERE ID = @ID",
                    conn);
                command.Parameters.AddWithValue("UserID", UserID);
                command.Parameters.AddWithValue("ClassID", Class.ID);
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

            command = new OleDbCommand("DELETE * FROM Users WHERE Users.ID=@UserID",
                conn);
            command.Parameters.AddWithValue("UserID", UserID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }
        
        /// <summary>
        /// SUCKS
        /// </summary>
        public async void UpdateStudentAsync(Class newClass)
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            if (Class.ID != new Guid())
            {
                command = new OleDbCommand("SELECT ID FROM Classes WHERE SchoolYear=@SchoolYear AND Course=@Course",
                    conn);
                command.Parameters.AddWithValue("SchoolYear", newClass.SchoolYear);
                command.Parameters.AddWithValue("Course", newClass.Course);

                reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    Class.ID = reader.GetGuid(0);
                }

                reader.Close();
            }

            command = new OleDbCommand("UPDATE Students CLASS_ID=@ClassID WHERE ID=@ID",
                conn);
            command.Parameters.AddWithValue("ClassID", Class.ID);
            command.Parameters.AddWithValue("ID", ID);

            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Get all Students
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Student>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            BasicUserProperties properties;
            Class sClass;
            List<Student> students = new List<Student>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Students.ID, Classes.ID, Users.ID, Users.FirstName, Users.SecondName, Users.BirthDate, Classes.SchoolYear, Classes.Course FROM (Students INNER JOIN Users ON Students.USER_ID=Users.ID)INNER JOIN Classes ON Students.CLASS_ID=Classes.ID",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(3);
                properties.SecondName = reader.GetString(4);
                properties.BirthDate = reader.GetDateTime(5);
                sClass = new Class(reader.GetString(6), reader.GetString(7), reader.GetGuid(1));
                students.Add(new Student(properties, sClass, reader.GetGuid(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return students;
        }

        /// <summary>
        /// Retrives the class associated with this student. TODO: unasync this method
        /// </summary>
        /// <returns></returns>
        public Class GetClass()
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand() { Connection = conn })
            {
                conn.Open();
                command.CommandText = "SELECT Classes.* FROM Students INNER JOIN Classes ON Students.CLASS_ID=Classes.ID WHERE Students.ID = @ID";
                command.Parameters.AddWithValue("ID", ID);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Class class1;
                        class1 = new Class(reader.GetString(1), reader.GetString(2), reader.GetGuid(0));

                        reader.Close();
                        conn.Close();
                        return class1;
                    }
                    else
                    {
                        throw new Exception("Query result not correct");
                    }
                }
            }
        }

        /// <summary>
        /// Retrives the evaluation associated with this student.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Evaluation>> GetEvaluationAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            List<Evaluation> evaluation = new List<Evaluation>();
            DbDataReader reader;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Evaluations.* FROM Evaluations INNER JOIN Students ON Evaluations.STUDENT_ID=Students.ID WHERE Students.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                evaluation.Add(new Evaluation(reader.GetDateTime(1), reader.GetDouble(2), reader.GetGuid(3), reader.GetGuid(4), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return evaluation;
        }
    }
}
