using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : Employee
    {
       public short UserID { get; set; }
       public short UserAddBy { get; set; }
       public string PasswordHash { get; set; }
       public string UserName { get; set; }
       public string Role { get; set; }
       public bool Status { get; set; }
    }
}
