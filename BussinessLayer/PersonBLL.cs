using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BussinessLayer
{
    public interface IPersonBLL
    {
        Task<Person> GetByRefreshTokenId(Guid tokenId);
        Task<int> RegisterPerson(Person person);
        Task<Person> GetPersonByPhone(string phoneNumber);
        Task<bool> UpdateAuth(Person person);
    }
    public class PersonBLL : IPersonBLL
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

        public async Task<Person> GetPersonByPhone(string phoneNumber)
        {
            return await PersonDLL.GetAuthUserByPhoneNumber(phoneNumber);
        }

        public async Task<Person> GetByRefreshTokenId(Guid tokenId)
        {
            return await PersonDLL.GetByRefreshTokenId(tokenId);
        }

        public async Task<bool> UpdateAuth(Person person)
        {
            return await PersonDLL.UpdateAuth(person);
        }

        public async Task<int> RegisterPerson(Person person)
        {
            return await PersonDLL.RegisterPerson(person);
        }

    }
}
