using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SubscriptionsPackages
    {
        public byte SubTimeID { get; set; }
        public string PackageName { get; set; }
        public decimal Fees { get; set; }
        public byte SubscriptionDuration { get; set; }
    }
}
