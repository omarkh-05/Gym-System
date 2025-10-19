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
    public partial class EmployeeControl : UserControl
    {
        public int _EmployeeID = -1;
        public int _PersonID = -1;
        Employee _Employee;
        EmployeeBLL _EmployeeBLL;

        public EmployeeControl()
        {
            InitializeComponent();
        }

        public void LoadData(int EmployeeID,int PersonID)
        {
            _EmployeeID = EmployeeID;
            _PersonID = PersonID;
            _Employee = EmployeeBLL.Find(_EmployeeID);

            if (_Employee == null)
            {
                MessageBox.Show($"لا يوجد موظف برقم {_EmployeeID}");
                return;
            }

            _EmployeeBLL = new EmployeeBLL(_Employee);

            PersonInfoControl.LoadPersonData(_PersonID);

            lblEmpRank.Text = _Employee.EmployeeRank.ToString();
            lblEmpType.Text = _Employee.EmployeeType;
            pbEmpImage.ImageLocation = _Employee.ImagePath;
            lblEndDuration.Text = _Employee.EndDurationDate.ToShortDateString();
        }
    }
}
