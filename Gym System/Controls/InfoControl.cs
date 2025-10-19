using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System.Controls
{
    public partial class InfoControl : UserControl
    {
        public int _PersonID = -1;
        Person _person;
        PersonBLL _PersnoBLL = new PersonBLL();
        public InfoControl()
        {
            InitializeComponent();
        }


        public void LoadPersonData(int PersonID)
        {
            _PersonID = PersonID;

            _person = _PersnoBLL.Find(_PersonID);

            if (_person == null)
            {
                MessageBox.Show("هذا الشخص غير موجود");
                return;
            }

            string Nationality = CountriesBLL.Find(_person.NationalityID).NationalityName;

            lblName.Text = _person.Name;
            lblAge.Text = _person.DateOfBirth?.ToShortDateString() ?? "-";
            lblGendor.Text = _person.Gender;
            lblAddress.Text = _person.Address;
            lblNationality.Text = Nationality;
            lblNationalNo.Text = _person.NationalNo;
            lblPersonType.Text = _person.PersonType;
            lblPhoneNo.Text = _person.PhoneNo;
            lblEnterID.Text = _person.EnterID;
        }


    }
}
