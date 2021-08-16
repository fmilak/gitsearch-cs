using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitSearch_cs.Model
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public User GetUserByUsername(string username)
        {
            List<User> users = new List<User>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE username = ?username", conn); 
                cmd.Parameters.Add(new MySqlParameter("username", username));

                using(var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        users.Add(new User()
                        {
                            Uuid = reader["uuid"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        });
                    }
                }
            }

            return users[0];
        }
    }
}
