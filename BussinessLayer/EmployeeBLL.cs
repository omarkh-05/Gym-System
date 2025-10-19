using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class EmployeeBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;

        private Employee _employee;

        public EmployeeBLL()
        {
            _employee = new Employee();
            _mode = enMode.AddMode;
        }

        public EmployeeBLL(Employee employee)
        {
            _employee = employee;
            _mode = enMode.UpdateMode;
        }

        public Employee Employees
        {
            get { return _employee; }
            set { _employee = value; }
        }

        // جلب كل الموظفين
        public static DataTable GetAllEmployees()
        {
            return EmployeeDLL.GetAllEmployees();
        }

        public static DataTable GetAllEmployeesView()
        {
            return EmployeeDLL.GetAllEmployeesView();
        }
        // إضافة موظف جديد
        private bool _Add()
        {
            _employee.EmployeeID = EmployeeDLL.AddNewEmployee(_employee);
            return _employee.EmployeeID != -1;
        }

        // تحديث موظف
        private bool _Update()
        {
            return EmployeeDLL.UpdateEmployee(_employee);
        }

        // حذف موظف
        public static bool Delete(int employeeID)
        {
            return EmployeeDLL.DeleteEmployee(employeeID);
        }

        // البحث عن موظف بالـ ID
        public static Employee Find(int employeeID)
        {
            return EmployeeDLL.GetEmployeeByID(employeeID);
        }

        // الحفظ (إضافة أو تحديث)
        public bool Save()
        {
            switch (_mode)
            {
                case enMode.AddMode:
                    if (_Add())
                    {
                        _mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _Update();
            }
            return false;
        }
    }
}
