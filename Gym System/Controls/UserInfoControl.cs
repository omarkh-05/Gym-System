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
    public partial class UserInfoControl : UserControl
    {
        public short _UserID = -1;
        public int _PersonID = -1;
        User _User;
        UserBLL _UserBLL;
        Employee _Employee;
        EmployeeBLL _EmployeeBLL;
        public UserInfoControl()
        {
            InitializeComponent();
        }

        public void LoadData(short UserID,int PersonID)
        {
            _UserID = UserID;
            _PersonID = PersonID;
            _User = UserBLL.Find(_UserID);
         
            if (_User == null)
            {
                MessageBox.Show($"لا يوجد مستخدم برقم {_UserID}");
                return;
            }

            _UserBLL = new UserBLL(_User);
            _Employee = EmployeeBLL.Find(_User.EmployeeID);


            PersonInfoControl.LoadPersonData(_PersonID);

            lblEmpRank.Text = _Employee.EmployeeRank.ToString();
            lblEmpType.Text = _Employee.EmployeeType;
            pbUserImage.ImageLocation = _Employee.ImagePath;
            lblRole.Text = _User.Role;
        }
    }
}
