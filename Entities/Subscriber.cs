using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Subscriber : Person
    {
        public  int SubscriberID { get; set; }
        public  DateTime? SubDate { get; set; }
        public  DateTime? EndDate { get; set; }
        public bool IsPaid { get; set; }
        public int DepartmentID { get; set; }
        public  short SubscriptionInfo { get; set; }
        public  short AddedBy { get; set; }

    }
}
