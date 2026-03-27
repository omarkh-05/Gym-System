using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Presence
    {
        public int PresenceId { get; set; }
        public DateTime PresenceTime { get; set; }
        public DateTime CheckoutTime { get; set; }
        public bool ProcessDetail { get; set; }
    }
}
