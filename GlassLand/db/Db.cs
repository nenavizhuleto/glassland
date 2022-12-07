using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    
    public class Db
    {
        public Db() { }

        public void Connect() { }

        public void Disconnect() { }


        public static User GetUser(string username)
        {

            return new User()
            {
                Username = "admin",
                Password = "admin"
            };
        }
    }
}
