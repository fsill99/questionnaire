using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireLib
{
    public sealed class Administrator : User, IDBEntity
    {
        public Guid ID
        {
            get { return (Guid)Properties["Administrators.ID"]; }
            set { Properties["Administrators.ID"] = value; }
        }

        /// <summary>
        /// Constructs new administrator from properties. (non-existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Administrator(BasicUserProperties basicProperties)
            : base(
                FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
            , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
            , new KeyValuePair<string, object>("Password", basicProperties.Password)
            , new KeyValuePair<string, object>("Administrators.ID", new Guid())
            , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
            , new KeyValuePair<string, object>("Users.ID", new Guid()))
            )
        {
        }

        /// <summary>
        /// Constructs new administrator from properties. (existing record)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="classID"></param>
        public Administrator(BasicUserProperties basicProperties, Guid userID, Guid ID)
            : base(
                FromArgs(new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
            , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
            , new KeyValuePair<string, object>("Password", basicProperties.Password)
            , new KeyValuePair<string, object>("Administrators.ID", ID)
            , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate)
            , new KeyValuePair<string, object>("Users.ID", userID))
            )
        {
        }

        /// <summary>
        /// Construct object from existing user object. (Useful after User object authentication).
        /// </summary>
        /// <param name="user"></param>
        public Administrator(User user) : base(user.Properties)
        {

        }

        /// <summary>
        /// Authenticates the Administrator.
        /// </summary>
        /// <param name="queryRestrictions">Restrictions added in the query WHERE clause. (Key is field name, Value is field value)</param>
        /// <returns>Type of the authentication obtained.</returns>
        public async Task<AuthenticationType> AuthenticateAsync(Dictionary<string, object> queryRestrictions = null)
        {
            return await base.AuthenticateAsync(AuthenticationType.Administrator, queryRestrictions);
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
                command = new OleDbCommand("INSERT INTO Users (ID, FirstName, SecondName, BirthDate, [Password]) VALUES (@ID, @FirstName, @SecondName, @BirthDate, @Password)",
                    conn);
                command.Parameters.AddWithValue("ID", UserID = Guid.NewGuid());
                command.Parameters.AddWithValue("FirstName", FirstName);
                command.Parameters.AddWithValue("SecondName", SecondName);
                command.Parameters.AddWithValue("BirthDate", BirthDate);
                command.Parameters.AddWithValue("Password", Password);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("INSERT INTO Administrators (ID, USER_ID) VALUES (@ID, @UserID)",
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
                command.Parameters.AddWithValue("Password", Password);
                command.Parameters.AddWithValue("UserID", UserID);
                await command.ExecuteNonQueryAsync();
                command = new OleDbCommand("UPDATE Administrators SET USER_ID=@UserID WHERE ID = @ID",
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

            conn.Close();
        }

        /// <summary>
        /// Get all Administrators
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Administrator>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Administrator> administrators = new List<Administrator>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Administrators.ID, Users.ID, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM Administrators INNER JOIN Users ON Administrators.USER_ID=Users.ID",
                conn);
            reader = await command.ExecuteReaderAsync();
            
            while (reader.Read())
            {
                BasicUserProperties properties;

                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(3);
                properties.SecondName = reader.GetString(4);
                properties.BirthDate = reader.GetDateTime(5);
                administrators.Add(new Administrator(properties, reader.GetGuid(1),reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return administrators;
        }
    }
}
