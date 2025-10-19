using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public string    Name           { get; set; }
        public int PersonID { get; set; } // <--- أضف هذا
        public DateTime? DateOfBirth    { get; set; }
        public string    Gender         { get; set; }
        public string    NationalNo     { get; set; }
        public string    PhoneNo        { get; set; }
        public int       NationalityID  { get; set; }
        public string    Address        { get; set; }
        public string    EnterID           { get; set; }
        public string    PersonType        { get; set; }
        public bool      HasDisease          { get; set; }
    }
}
