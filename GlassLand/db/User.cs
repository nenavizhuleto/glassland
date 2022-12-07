using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static User Login(string login, string password)
        {
            //TODO: find user in db
            var user = Db.GetUser(login);

            if (null == user)
            {
                return null;
            }

            if (password != user.Password)
            {
                return null;
            }

            return user;
        }
    }
}
