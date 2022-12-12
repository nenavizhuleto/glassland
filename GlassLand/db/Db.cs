using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    
    public class Db
    {

        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Administrator\\source\\repos\\GlassLand\\GlassLand\\glassland.mdf;Integrated Security=True;Connect Timeout=30";
        
        public Db() {

        }

        public static SqlConnection Connect() {
            return new SqlConnection(connectionString);
        }

        public void Disconnect() { }


        public static User GetUser(string username)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand($"SELECT * FROM Users WHERE Username = '{username}';", connection);

                var reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    reader.Read();

                    var user = new User()
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()
                    };

                    reader.Close();

                    return user;

                }
            }

            return null;

        }
    }
}
