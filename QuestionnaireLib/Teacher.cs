using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireLib
{
    public sealed class Teacher : User, IDBEntity
    {
        public Guid ID
        {
            get { return (Guid)Properties["Teachers.ID"]; }
            set { Properties["Teachers.ID"] = value; }
        }

        /// <summary>
        /// Constructs new teacher from properties. (non-existing record)
        /// </summary>
        /// <param name="basicProperties"></param>
        public Teacher(BasicUserProperties basicProperties)
            : base(
                    FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
                , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
                , new KeyValuePair<string, object>("Password", basicProperties.Password)
                , new KeyValuePair<string, object>("Teachers.ID", new Guid())
                , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
                , new KeyValuePair<string, object>("Users.ID", new Guid()))
                )
        {
        }

        /// <summary>
        /// Constructs new teacher from properties. (existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Teacher(BasicUserProperties basicProperties, Guid userID, Guid ID)
            : base(
                FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
            , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
            , new KeyValuePair<string, object>("Password", basicProperties.Password)
            , new KeyValuePair<string, object>("Teachers.ID", ID)
            , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
            , new KeyValuePair<string, object>("Users.ID", userID))
            )
        {
        }

        /// <summary>
        /// Construct object from existing user object. (Useful after User object authentication).
        /// </summary>
        /// <param name="user"></param>
        public Teacher(User user) : base(user.Properties)
        {
        }

        /// <summary>
        /// Authenticates the Teacher.
        /// </summary>
        /// <param name="queryRestrictions">Restrictions added in the query WHERE clause. (Key is field name, Value is field value)</param>
        /// <returns>Type of the authentication obtained.</returns>
        public async Task<AuthenticationType> AuthenticateAsync(Dictionary<string, object> queryRestrictions = null)
        {
            return await base.AuthenticateAsync(AuthenticationType.Teacher, queryRestrictions);
        }

        /// <summary>
        /// Retrieves the teacher corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Teacher FromID(Guid teacherID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Teachers INNER JOIN Users ON Teachers.USER_ID=Users.ID WHERE ID=@TeacherID";
                command.Parameters.AddWithValue("TeacherID", teacherID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    BasicUserProperties properties = new BasicUserProperties();
                    properties.FirstName = reader.GetString(3);
                    properties.SecondName = reader.GetString(4);
                    properties.BirthDate = reader.GetDateTime(5);
                    properties.Password = reader.GetString(6);
                    return new Teacher(properties, reader.GetGuid(1), reader.GetGuid(0));
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
                command = new OleDbCommand("INSERT INTO Users(ID, FirstName, SecondName, BirthDate, [Password]) VALUES (@ID, @FirstName, @SecondName, @BirthDate, @Password)",
                    conn);
                command.Parameters.AddWithValue("ID", UserID = Guid.NewGuid());
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("SecondName", SecondName);
                command.Parameters.AddWithValue("BirthDate", BirthDate);
                command.Parameters.AddWithValue("Password", Password);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("INSERT INTO Teachers (ID, USER_ID) VALUES (@ID, @UserID)",
                    conn);
                command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                command.Parameters.AddWithValue("UserID", UserID);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                command = new OleDbCommand("UPDATE Users SET FirstName=@FirstName, SecondName=@SecondName, BirthDate=@BirthDate, [Password]=@Password WHERE Users.ID = @UserID",
                    conn);
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("SecondName", SecondName);
                command.Parameters.AddWithValue("BirthDate", BirthDate);
                command.Parameters.AddWithValue("[Password]", Password);
                command.Parameters.AddWithValue("UserID", UserID);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("UPDATE Teachers SET USER_ID=@UserID WHERE ID = @ID",
                    conn);
                command.Parameters.AddWithValue("UserID", UserID);
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

            command = new OleDbCommand("DELETE * FROM Teachers WHERE ID=@ID",
                conn);

            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Add this teacher into a class
        /// </summary>
        public async void AddTeachingClass(Class newClass)
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("INSERT INTO TeachesClass(CLASS_ID, TEACHER_ID) VALUES(@ClassID, @TeacherID)",
                conn);

            command.Parameters.AddWithValue("ClassID", newClass.ID);
            command.Parameters.AddWithValue("TeacherID", ID);
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }

        /// <summary>
        /// Removes a teaching class of the teacher
        /// </summary>
        /// <param name="newClass"></param>
        public async void RemoveTeachingClass(Class newClass)
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("DELETE * FROM TeachesClass WHERE CLASS_ID=@ClassID AND TEACHER_ID=@ID",
                conn);

            command.Parameters.AddWithValue("CLASS_ID", newClass.ID);
            command.Parameters.AddWithValue("TEACHER_ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();

        }

        /// <summary>
        /// Get all Teachers
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Teacher>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Teacher> teachers = new List<Teacher>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Teachers.ID, Users.ID, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM Teachers INNER JOIN Users ON Teachers.USER_ID=Users.ID",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                BasicUserProperties properties;

                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(2);
                properties.SecondName = reader.GetString(3);
                properties.BirthDate = reader.GetDateTime(4);
                properties.Password = reader.GetString(5);
                teachers.Add(new Teacher(properties, reader.GetGuid(1), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return teachers;
        }

        /// <summary>
        /// Retrives the topic associated with this teacher.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Topic>> GetTopicsAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Topic> topics = new List<Topic>();
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Topics.* FROM Topics INNER JOIN Teachers ON Topics.TEACHER_ID=Teachers.ID WHERE Teachers.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                topics.Add(new Topic(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return topics;
        }

        /// <summary>
        /// Retrives the classes associated with this teacher.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Class>> GetClassesAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Class> classes = new List<Class>();
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Classes.* FROM ((Classes INNER JOIN TeachesClass ON TeachesClass.CLASS_ID=Classes.ID)INNER JOIN Teachers ON TeachesClass.TEACHER_ID=Teachers.ID) WHERE Teachers.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
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
        /// Retrieve the questionnaire session created by this teacher.
        /// </summary>
        /// <returns></returns>
        public async Task<List<QuestionnaireSession>> GetQuestionnaireSessionsAsync()
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                List<QuestionnaireSession> questionnaireSessions = new List<QuestionnaireSession>();
                conn.Open();
                command.Connection = conn;
                command.CommandText = @"SELECT QuestionnaireSessions.ID, QuestionnaireSessions.SessionDate, QuestionnaireSessions.Description
                                        FROM (Topics
                                        INNER JOIN Evaluations ON Topics.ID=Evaluations.TOPIC_ID)
                                        INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID=QuestionnaireSessions.ID
                                        WHERE Topics.TEACHER_ID=@TeacherID";
                command.Parameters.AddWithValue("TeacherID", ID);

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while(reader.Read())
                    {
                        questionnaireSessions.Add(new QuestionnaireSession(reader.GetGuid(0), reader.GetString(2), reader.GetDateTime(1)));
                    }
                    return questionnaireSessions;
                }
            }
        }
    }
}