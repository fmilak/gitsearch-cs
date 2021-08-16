using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitSearch_cs.Model
{
    public class TokenContext
    {
        public string ConnectionString { get; set; }

        public TokenContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public Token GetToken()
        {
            List<Token> tokens= new List<Token>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM token", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tokens.Add(new Token()
                        {
                            Id = reader["id"].ToString(),
                            TokenValue = reader["token"].ToString()
                        });
                    }
                }
            }

            return tokens[0];
        }
    }
}
