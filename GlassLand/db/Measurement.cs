using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public struct Window
    {
        public float width;
        public float height;
    }
    public class Measurement
    {
        public string CustomerName { get; set; }
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
        public string Measurer { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }



        public static List<Measurement> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurements = new List<Measurement>();

                var sql = @"SELECT 
	                            m.CustomerName as CustomerName,
	                            m.WindowWidth as WindowWidth,
	                            m.WindowHeight as WindowHeight,
	                            m.Address as Address,
	                            m.Date as Date,
	                            e.Name as MeasurerName
                            FROM Measurements as m LEFT JOIN Employeers as e ON m.MeasurerId = e.Id;";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    measurements.Add(new Measurement
                    {
                        CustomerName = reader.GetString(0),
                        WindowWidth = reader.GetDouble(1),
                        WindowHeight = reader.GetDouble(2),
                        Address = reader.GetString(3),
                        Date = reader.GetDateTime(4),
                        Measurer = reader.GetString(5),
                    });
                }

                reader.Close();

                return measurements;
            }

        }
    }
}
