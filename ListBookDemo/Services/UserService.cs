using ListBookDemo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBookDemo.DB.Services
{
    public class UserService
    {
        public void SaveUser (User user)
        {
            if (user != null)
            {
                SqliteContext context = new SqliteContext ();
                context.Users.Update (user);
                context.SaveChanges (); 
            }
        }

    }
}
