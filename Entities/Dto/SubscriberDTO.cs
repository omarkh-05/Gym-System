using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
        public class AttendanceDTO
        {
            public DateTime? CheckinTime { get; set; }
            public DateTime? CheckoutTime { get; set; }
            public string Status { get; set; }
        }

        public class SubscriberDTO
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gendor { get; set; }
            public string PhoneNumber { get; set; }
            public string NationalityNumber { get; set; }

            public int NationalityID { get; set; }
            public string Address { get; set; }
            public bool HasDisease { get; set; }

            public int SubscriberID { get; set; }
            public bool IsActive { get; set; }
            public DateTime SubDate { get; set; }
            public DateTime EndSubDate { get; set; }

            public string SubTimeChosen { get; set; }
            public string PackageName { get; set; }
            public int SubscriptionDuration { get; set; }

            public string DepartmentName { get; set; }

            public List<AttendanceDTO> Attendance { get; set; } = new List<AttendanceDTO>();
        }
}
