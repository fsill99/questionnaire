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
    public class User
    {
        /// <summary>
        /// Dictonary that stores the properties of this user.
        /// </summary>
        public Dictionary<string, object> Properties;

        /// <summary>
        /// ID of the user.
        /// </summary>
        public Guid UserID
        {
            get { return (Guid)Properties["Users.ID"]; }
            set { Properties["Users.ID"] = value; }
        }
        /// <summary>
        /// First name of the user. Required for every user.
        /// </summary>
        public string FirstName
        { 
            get { return (string)Properties["FirstName"]; } 
            set { Properties["FirstName"] = value; }
        }
        /// <summary>
        /// Second name of the user. Required for every user.
        /// </summary>
        public string SecondName
        {
            get { return (string)Properties["SecondName"]; }
            set { Properties["SecondName"] = value; }
        }
        /// <summary>
        /// Birth date of the user. Required only on student accounts.
        /// </summary>
        public DateTime BirthDate 
        {
            get { return (DateTime)Properties["BirthDate"]; }
            set { Properties["BirthDate"] = value; }
        }
        /// <summary>
        /// Password of the user. Required only on teacher and admin accounts.
        /// </summary>
        public string Password
        {
            get { return (string)Properties["Password"]; }
            set { Properties["Password"] = value; }
        }

        /// <summary>
        /// Full name of the user (first name + second name).
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }

        /// <summary>
        /// Constructor from properties dictionary.
        /// </summary>
        /// <param name="properties"></param>
        public User(Dictionary<string, object> properties)
        {
            this.Properties = new Dictionary<string, object>(properties);
        }

        /// <summary>
        /// Create an user by passing properties.
        /// </summary>
        /// <param name="basicProperties">Required user properties.</param>
        public User(BasicUserProperties basicProperties)
        {
            this.Properties = new Dictionary<string,object>(
                FromArgs(
                    new KeyValuePair<string, object>("Users.ID", new Guid())
                    , new KeyValuePair<string, object>("FirstName", basicProperties.FirstName)
                    , new KeyValuePair<string, object>("SecondName", basicProperties.SecondName)
                    , new KeyValuePair<string, object>("Password", basicProperties.Password)
                    , new KeyValuePair<string, object>("BirthDate", basicProperties.BirthDate))
                );
        }

        /// <summary>
        /// Asynchronously authenticate this user.
        /// </summary>
        /// <param name="auth">Type of authentication requested.</param>
        /// <param name="queryRestrictions">Used to specify extra conditions of the query where clause. The key corresponds to the db field name, and the value corresponds to its value (you have to specify also '', ##, etc... to wrap the value)</param>
        /// <returns>Returns true if authenticated, otherwise false.</returns>
        public async Task<AuthenticationType> AuthenticateAsync(AuthenticationType auth, Dictionary<string, object> queryRestrictions = null)
        {
            
            if(auth != AuthenticationType.Unregistered)
            {
                string table = auth.ToTableName();
                List<string> requiredFields = AuthenticationRequiredFields.Get(auth);
                List<OleDbParameter> queryParametersList = new List<OleDbParameter>();

                //THER MAY BE A PROBLEM WITH SHORTDATE FORMAT
                string queryText = "SELECT * FROM Users INNER JOIN " + table + " ON Users.ID = " + table + ".USER_ID WHERE";

                foreach (string field in requiredFields)
                {
                    if(Properties.ContainsKey(field))
                    {
                        //queryParametersList.Add(new OleDbParameter(field, field == "Password" ? Cryptography.ComputeMD5Hash(Properties["Password"].ToString()) : Properties[field]));
                        queryParametersList.Add(new OleDbParameter(field, Properties[field]));
                        queryText += " " + field + "=@" + field + " AND";
                    }
                    else
                    {
                        return AuthenticationType.Unregistered;
                    }
                }
                queryText = queryText.Remove(queryText.Length - 4);

                if (queryRestrictions != null)
                {
                    //TODO: add restrictions in sql query with different operators
                    throw new NotImplementedException();
                }

                using(OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
                using(OleDbCommand command = new OleDbCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = queryText;
                    command.Parameters.AddRange(queryParametersList.ToArray());
                    using(DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            //Authenticated, fetching properties
                            //WARNING! Check for double ID resulting from INNER JOIN (problem if Fields are not preceded by table name)
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string fieldName = reader.GetSchemaTable().Rows[i].ItemArray[0].ToString();
                                //not fetching md5 checksum of Password field
                                if (fieldName != "Password")
                                {
                                    if (!Properties.ContainsKey(fieldName))
                                    {
                                        Properties.Add(fieldName, reader.GetValue(i));
                                    }
                                    else
                                    {
                                        Properties[fieldName] = reader.GetValue(i);
                                    }
                                }
                            }
                            return auth;
                        }
                        else
                        {
                            //Not authenticated, credentials not found.
                            return AuthenticationType.Unregistered;
                        }
           
            
                    }
                }
            }
            else
            {
                //Asking for AuthenticationType.UNREGISTERED authentication
                return AuthenticationType.Unregistered;
            } 
           
        }            

        /// <summary>
        /// Method used to pass a run-time elaborated dictonary (made with child's class constructor parameters) from a child class to this class.
        /// </summary>
        /// <param name="args">Parameters passed to this class, in form of KeyValuePairs.</param>
        /// <returns>The resulting dictionary of these parameters.</returns>
        protected static Dictionary<string, object> FromArgs(params KeyValuePair<string, object>[] args)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < args.Count(); i++ )
            {
                dict.Add(args[i].Key, args[i].Value);
            }
            return dict;
        }

        /// <summary>
        /// Asynchronously authenticate this user by trying the authentications passed as parameters. This method is designed to not support multiple user with same credentials.
        /// </summary>
        /// <param name="queryRestrictions">Used to specify extra conditions of the query where clause. The key corresponds to the db field name, and the value corresponds to its value (you have to specify also '', ##, etc... to wrap the value)</param>
        /// <param name="authentications"></param>
        /// <returns></returns>
        public async Task<List<AuthenticationType>> AuthenticateAsync(List<AuthenticationType> authentications, Dictionary<string, object> queryRestrictions = null)
        {
            List<AuthenticationType> auths = new List<AuthenticationType>();

            foreach(AuthenticationType auth in authentications)
            {
                AuthenticationType currentAuth = await AuthenticateAsync(auth, queryRestrictions);
                if(currentAuth != AuthenticationType.Unregistered)
                {
                    auths.Add(currentAuth);
                }
            }

            return auths.Count > 0 ? auths : new List<AuthenticationType>() { AuthenticationType.Unregistered };
        }
    }
}
