using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuestionnaireLib
{
    [Serializable]
    public class QuestionnaireSession : IDBEntity
    {
        private List<Class> _involvedClasses;
        private List<Evaluation> _evaluations;
        private List<Student> _involvedStudents;
        private Questionnaire _questionnaire;

        public Guid ID { get; set; }

        public Questionnaire Questionnaire
        {
            get
            {
                if (_questionnaire == null && !ID.Equals(new Guid()))
                    _questionnaire = BinaryDeserialize(Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, FilesystemFileName)).Questionnaire;
                return _questionnaire;
            }
            set { _questionnaire = value; }
        }

        public List<Student> InvolvedStudents
        {
            get
            {
                if (_involvedStudents == null && !ID.Equals(new Guid()))
                    _involvedStudents = BinaryDeserialize(Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, FilesystemFileName)).InvolvedStudents;
                return _involvedStudents;
            }
            set { _involvedStudents = value; }
        }

        public DateTime SessionDate { get; set; }

        public string Description { get; set; }

        public string FilesystemDirectoryName
        {
            get
            {
                if (ID.Equals(new Guid()))
                    throw new Exception("The file does not exist. First save the record and then serialize it.");
                return ID.ToString() + SessionDate.ToString("MM-dd-yy");
            }
        }

        public string FilesystemFileName
        {
            get
            {
                return FilesystemDirectoryName + ".dat";
            }
        }

        public List<Evaluation> Evaluations
        {
            get
            {
                if (_evaluations == null)
                    _evaluations = GetEvaluations();
                return _evaluations;
            }
        }

        public List<Class> InvolvedClasses
        { 
            get
            {
                if(_involvedClasses == null)
                {
                    _involvedClasses = InvolvedStudents.Select(s => s.Class).GroupBy(c => c).Select(grp => grp.First()).ToList();
                }
                return _involvedClasses;
            }
        }

        /// <summary>
        /// Non-existing record constructor.
        /// </summary>
        /// <param name="questionnaire"></param>
        /// <param name="students"></param>
        /// <param name="description"></param>
        public QuestionnaireSession(Questionnaire questionnaire, List<Student> students, string description = "")
        {
            Questionnaire = questionnaire;
            InvolvedStudents = students;
            SessionDate = DateTime.Now;
            ID = new Guid();
            Description = description;
        }

        /// <summary>
        /// Existing record constructor.
        /// </summary>
        /// <param name="questionnaire"></param>
        /// <param name="students"></param>
        /// <param name="description"></param>
        public QuestionnaireSession(Guid ID, string description, DateTime sessionDate)
        {
            SessionDate = sessionDate;
            this.ID = ID;
            Description = description;
        }

        /// <summary>
        /// Deserializes a QuestionnaireSession object from a binary formatted file.
        /// </summary>
        /// <param name="path">Binary formatted file path.</param>
        /// <returns></returns>
        public static QuestionnaireSession BinaryDeserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(path, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return (QuestionnaireSession)obj;
        }

        /// <summary>
        /// Serializes the current QuestionnaireSession object to the specified binary formatted file path.
        /// </summary>
        /// <param name="path"></param>
        public void BinarySerialize(string path)
        {
            FileStream writeStream = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writeStream, this);
            writeStream.Close();
        }

        /// <summary>
        /// Serializes the current QuestionnaireSession object as the current server session object.
        /// </summary>
        /// <param name="path"></param>
        public void CurrentServerSessionSerializitazion()
        {
            BinarySerialize(AppConfiguration.questionnaireSessionFilePath);
        }

        /// <summary>
        /// Serializes the current QuestionnaireSession object as the current server session object.
        /// </summary>
        /// <param name="path"></param>
        public void SaveSerialization()
        {
            BinarySerialize(Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, FilesystemFileName));
            Directory.CreateDirectory(Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, FilesystemDirectoryName));
        }

        /// <summary>
        /// Inserts the new record in the db.
        /// </summary>
        public async void SaveAsync()
        {
            if(ID.Equals(new Guid()))
            {
                using(OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
                using(OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "INSERT INTO QuestionnaireSessions ([ID], [SessionDate], [Description]) VALUES (@ID, @SessionDate, @Description)";
                    command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                    command.Parameters.Add(new OleDbParameter("SessionDate", OleDbType.Date) { Value = SessionDate });
                    command.Parameters.AddWithValue("Description", Description);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// Deletes the record from the db.
        /// </summary>
        public async void DeleteAsync()
        {
            if (!ID.Equals(new Guid()))
            {
                using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
                using (OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "DElETE FROM QuestionnaireSessions WHERE ID = @ID";
                    command.Parameters.AddWithValue("ID", ID);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// Returns all the evaluations associated with this questionnaire session.
        /// </summary>
        /// <returns></returns>
        public List<Evaluation> GetEvaluations()
        {
            if (!ID.Equals(new Guid()))
            {
                using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
                using (OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    List<Evaluation> evaluations = new List<Evaluation>();
                    command.Connection = conn;
                    command.CommandText = "SELECT Evaluations.* FROM Evaluations INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID=QuestionnaireSessions.ID WHERE QuestionnaireSessions.ID = @ID";
                    command.Parameters.AddWithValue("ID", ID);

                    using(DbDataReader reader= command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            evaluations.Add(new Evaluation(reader.GetDateTime(1), reader.GetDouble(2), reader.GetGuid(3), reader.GetGuid(4), reader.GetGuid(0)));
                        }

                        return evaluations;
                    }
                }
            }
            else
            {
                return new List<Evaluation>();
            }
        }

        /// <summary>
        /// Returns all the QuestionnaireSession in the database.
        /// </summary>
        /// <returns></returns>
        public async static Task<List<QuestionnaireSession>> GetAllAsync()
        {
            
            using(OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using(OleDbCommand command = new OleDbCommand())
            {
                List<QuestionnaireSession> qSessions = new List<QuestionnaireSession>();
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM QuestionnaireSessions";

                using(DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        qSessions.Add(new QuestionnaireSession(reader.GetGuid(0), reader.GetString(2), reader.GetDateTime(1)));
                    }
                    return qSessions;
                }
            }
        }

        /// <summary>
        /// Retrieves the existing questionnaire session corresponding to the passed ID.
        /// </summary>
        /// <param name="id"></param>
        public static QuestionnaireSession FromID(Guid questionnaireSessionID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [QuestionnaireSessions] WHERE ID=@QuestionnaireSessionID";
                command.Parameters.AddWithValue("QuestionnaireSessionID", questionnaireSessionID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new QuestionnaireSession(reader.GetGuid(0), reader.GetString(2), reader.GetDateTime(1));
                }
            }
        }

        public static void Stampa(string NomeFile,string questionnaireSessionDescription)
        {
            
            StreamWriter FileEvalautions;
            OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString);
            string query;
            OleDbCommand command;
            DbDataReader reader;
            conn.Open();
            query = "SELECT Users.SecondName, Users.FirstName, Evaluations.Grade, QuestionnaireSessions.SessionDate  FROM((Evaluations INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID = QuestionnaireSessions.ID) INNER JOIN Students ON Evaluations.STUDENT_ID = Students.ID) INNER JOIN Users ON Students.USER_ID = Users.ID WHERE QuestionnaireSessions.Description = '" + questionnaireSessionDescription + "' ORDER BY Users.SecondName";
           

            command = new OleDbCommand(query, conn);
            FileEvalautions = new StreamWriter(NomeFile);

            reader = command.ExecuteReader();

            FileEvalautions.WriteLine("DESCRIZIONE DEL QUESTIONARIO: " + questionnaireSessionDescription);
            reader.Read();
            FileEvalautions.WriteLine("DATA DEL QUESTIONARIO: " + reader.GetDateTime(3).ToShortDateString());
            FileEvalautions.WriteLine(" ");
            FileEvalautions.WriteLine(" ");
            FileEvalautions.WriteLine("STUDENTI         " + "                   VOTO  ");
            FileEvalautions.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + "                 " + reader.GetDouble(2));

            while (reader.Read() == true)
            {
                FileEvalautions.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + "                   " + reader.GetDouble(2));
            }

            FileEvalautions.Close();
            conn.Close();

        }
    }
}
