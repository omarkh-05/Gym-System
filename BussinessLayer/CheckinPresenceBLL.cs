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
    public class CheckinPresenceBLL
    {
        public static string RegisterCheckin(string ID)
        {
            return CheckinPresenceDLL.RegisterCheckin(ID);
        }

        public static string RegisterCheckout(string ID)
        {
            return CheckinPresenceDLL.RegisterCheckout(ID);
        }

        public static DataTable GetAllCheckinRegister()
        {
            return CheckinPresenceDLL.GetAllCheckinRegister();
        }

        public static DataTable GetAllCheckoutRegister()
        {
            return CheckinPresenceDLL.GetAllCheckoutRegister();
        }

        public static string RegisterEmployeeCheckin(string ID)
        {
            return CheckinPresenceDLL.RegisterEmployeeCheckin(ID);
        }

        public static string RegisterEmployeeCheckout(string enterId, out decimal addition)
        {
            return CheckinPresenceDLL.RegisterEmployeeCheckout(enterId, out addition);
        }

        public static DataTable GetAllEmployeeCheckinRegister()
        {
            return CheckinPresenceDLL.GetAllEmployeeCheckinRegister();
        }

        public static DataTable GetAllEmployeeCheckoutRegister()
        {
            return CheckinPresenceDLL.GetAllEmployeeCheckoutRegister();
        }

    }
}
