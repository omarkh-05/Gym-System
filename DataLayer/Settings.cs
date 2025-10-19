using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class Settings
    {
        public static string connectionstring = ConfigurationManager.ConnectionStrings["GymDataBase"].ConnectionString;
    }
}
