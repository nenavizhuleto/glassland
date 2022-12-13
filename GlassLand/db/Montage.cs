using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class Montage
    {
        public int Id { get; set; }
        public string Master { get; set; }
        public Measurement Measurement { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }


        public bool UpdateStatus(string status)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var sql = $"UPDATE MontageOrders SET Status = '{status}' WHERE Id = '{Id}'";
                var command = new SqlCommand(sql, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool Save()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var sql = $"SELECT Id FROM Employeers WHERE Name = '{Master}'";
                var command = new SqlCommand(sql, connection);
                var reader = command.ExecuteReader();
                int masterId = -1;

                while (reader.Read())
                {
                    masterId = reader.GetInt32(0);
                }

                if (masterId == -1)
                {
                    reader.Close();
                    return false;
                }

                reader.Close();


                sql = $"INSERT INTO MontageOrders VALUES ({masterId}, {Measurement.Id}, '{Date.ToString()}', '{Status}')";

                command = new SqlCommand(sql, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
        }


        public static List<Montage> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var montages = new List<Montage>();

                var sql = @"SELECT 
                                mo.Id as Id,
                                mo.Date as OrderDate,
                                mo.Status as Status,
                                m.Id as MeasureId,
	                            m.CustomerName as CustomerName,
	                            m.WindowWidth as WindowWidth,
	                            m.WindowHeight as WindowHeight,
	                            m.Address as Address,
	                            m.Date as Date,
	                            e.Name as Master
                            FROM MontageOrders as mo 
                                LEFT JOIN Employeers as e ON mo.MasterId = e.Id
                                LEFT JOIN Measurements as m ON mo.MeasurementId = m.Id;";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var montage = new Montage
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Status = reader.GetString(2),
                        Master = reader.GetString(9),
                        Measurement = new Measurement
                        {
                            Id = reader.GetInt32(3),
                            CustomerName = reader.GetString(4),
                            WindowWidth = reader.GetDouble(5),
                            WindowHeight = reader.GetDouble(6),
                            Address = reader.GetString(7),
                            Date = reader.GetDateTime(8)
                        }
                    };
                    montages.Add(montage);
                }

                reader.Close();

                return montages;
            }
        }
    }
}
