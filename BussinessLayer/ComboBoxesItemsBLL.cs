using ComboBoxexDataLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CountriesBLL
    {
        public int ID { get; set; }
        public string NationalityName { get; set; }

        public CountriesBLL()
        {
            this.ID = -1;
            this.NationalityName = "";
        }

        private CountriesBLL(int ID, string NationalityName)
        {
            this.ID = ID;
            this.NationalityName = NationalityName;
        }

        // Get all nationalities
        public static DataTable GetAllNationalities()
        {
            DataTable dataTable = CountryDLL.GetAllNationality();

            if (dataTable != null)
                return dataTable;

            return new DataTable(); // لو ما في بيانات يرجع جدول فارغ
        }

        // Find nationality by name
        public static CountriesBLL Find(string nationalityName)
        {
            if (CountryDLL.GetNationalityByName(nationalityName, out int id))
                return new CountriesBLL(id, nationalityName);

            return null; // لو ما لقي
        }

        // Find nationality by ID
        public static CountriesBLL Find(int id)
        {
            if (CountryDLL.GetNationalityByID(id, out string nationalityName))
                return new CountriesBLL(id, nationalityName);

            return null; // لو ما لقي
        }
    }



    public class DepartmentBLL
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public DepartmentBLL()
        {
            this.DepartmentID = -1;
            this.DepartmentName = "";
        }

        private DepartmentBLL(int id, string name)
        {
            this.DepartmentID = id;
            this.DepartmentName = name;
        }

        // Get all departments
        public static DataTable GetAllDepartments()
        {
            if (DepartmentDLL.GetAllDepartment(out DataTable dt))
                return dt;

            return new DataTable(); // لو ما في بيانات يرجع جدول فارغ
        }

        // Find department by name
        public static DepartmentBLL Find(string departmentName)
        {
            if (DepartmentDLL.GetDepartmentByName(departmentName, out int id))
                return new DepartmentBLL(id, departmentName);

            return null; // لو ما لقي
        }

        // Find department by ID
        public static DepartmentBLL Find(int id)
        {
            if (DepartmentDLL.GetDepartmentByID(id, out string departmentName))
                return new DepartmentBLL(id, departmentName);

            return null; // لو ما لقي
        }
    }



    public class SubInfoBLL
    {
        public byte SubTimeID { get; set; }
        public string SubTimeChosen { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string DepartmentName { get; set; }
        public decimal Fees { get; set; }
        public byte MinAge { get; set; }
        public byte SubscriptionDuration { get; set; }

        public SubInfoBLL()
        {
            SubTimeID = 0;
            SubTimeChosen = "";
            StartTime = null;
            EndTime = null;
            DepartmentName = "";
            Fees = 0;
            MinAge = 0;
            SubscriptionDuration = 0;
        }

        private SubInfoBLL(DataRow row)
        {
            SubTimeID = (byte)row["SubTimeID"];
            SubTimeChosen = row["SubTimeChosen"].ToString();
            StartTime = row["StartTime"] != DBNull.Value ? (TimeSpan?)row["StartTime"] : null;
            EndTime = row["EndTime"] != DBNull.Value ? (TimeSpan?)row["EndTime"] : null;
            DepartmentName = row["DepartmentName"].ToString();
            Fees = Convert.ToDecimal(row["Fees"]);
            MinAge = Convert.ToByte(row["MinAge"]);
            SubscriptionDuration = Convert.ToByte(row["SubscriptionDuration"]);
        }

        // Get all subscriptions
        public static DataTable GetAllSubscriptions()
        {
            if (SubInfoDLL.GetAllSubscriptions(out DataTable dt)) return dt;
            return new DataTable();
        }

        // Find by SubTimeID
        public static SubInfoBLL Find(short subTimeID)
        {
            if (SubInfoDLL.GetSubscriptionBySubTimeID(subTimeID, out DataRow row))
                return new SubInfoBLL(row);
            return null;
        }

        // Find by DepartmentName
        public static SubInfoBLL Find(string departmentName)
        {
            if (SubInfoDLL.GetSubscriptionByDepartmentName(departmentName, out DataRow row))
                return new SubInfoBLL(row);
            return null;
        }
    }
}
