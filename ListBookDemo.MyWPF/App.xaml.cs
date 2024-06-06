using ListBookDemo.DB;
using ListBookDemo.DB.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ListBookDemo.MyWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SqliteContext sqliteContext;
        public  static User User { get; set; }

        public App ()
        {
            sqliteContext = new SqliteContext ();
            User = sqliteContext.Users.Include(x=>x.Status).Include(x=>x.Job).Where(x=>x.UserId==1).First();

        }
    }

}
