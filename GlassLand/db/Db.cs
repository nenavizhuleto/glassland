using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GlassLand.db
{
    
    public class Db
    {
        // "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = C:\\USERS\\ADMINISTRATOR\\SOURCE\\REPOS\\GLASSLAND\\GLASSLAND\\GLASSLAND.MDF;Integrated Security = True\r\n"



        static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = [DatabaseName];Integrated Security = True\r\n";
        public Db() {

        }

        public static SqlConnection Connect() {
            return new SqlConnection(connectionString);
        }

        public void Disconnect() { }


       
    }
}
