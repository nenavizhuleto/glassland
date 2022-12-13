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


       
    }
}
