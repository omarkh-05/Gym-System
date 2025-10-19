using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : Person
    {
       public int EmployeeID {  get; set; }
       public short EmployeeRank { get; set; }
       public short AddedBy { get; set; }
       public decimal Salary { get; set; }
       public bool IsActive { get; set; }
       public string WorkTime { get; set; }
       public string EmployeeType { get; set; }
       public string ImagePath { get; set; }
       public DateTime JoinningGymDate { get; set; }
       public DateTime EndDurationDate { get; set; }

    }
}
