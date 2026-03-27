using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddSubscriberDTO
    {
        public int PersonId { get; set; }
        public DateTime SubDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaid { get; set; }
        public byte SubscriptionInfo { get; set; }
        public byte DepartmentID { get; set; }

    }
}
