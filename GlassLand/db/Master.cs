using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Master> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<Master>();

                var sql = @"SELECT 
                                Id,
                                Name
                            FROM Employeers 
                            WHERE Post = 'Master';";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    masters.Add(new Master
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }

                reader.Close();

                return masters;
            }
        }
    }
}
