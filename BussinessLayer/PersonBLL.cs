using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BussinessLayer
{
    public class PersonBLL
    {
        private Person _Person;
        public PersonBLL()
        {
            _Person = new Person();
        }

        public PersonBLL(Person person)
        {
            _Person = person;
        }
        public Person CurrentPerson
        {
            get { return _Person; }
            set { _Person = value; }
        }

        public Person Find(int PersonID)
        {
            return PersonDLL.GetPersonByID(PersonID);
        }

    }
}
