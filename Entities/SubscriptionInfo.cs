using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubscriptionInfo
    {
        public byte SubTimeID { get; set; }                  // tinyint
        public TimeSpan? StartTime { get; set; }             // TIME(0)
        public TimeSpan? EndTime { get; set; }               // TIME(0)
        public string DepartmentName { get; set; }
        public decimal Fees { get; set; }                    // decimal(6,2)
        public byte MinAge { get; set; }                     // tinyint
        public byte SubscriptionDuration { get; set; }       // tinyint

    }
}
