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
   
    public class SubsicriptionInfoBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        private enMode _mode = enMode.AddMode;

        private SubscriptionInfo _subscription;

        public SubsicriptionInfoBLL()
        {
            _subscription = new SubscriptionInfo();
            _mode = enMode.AddMode;
        }

        public SubsicriptionInfoBLL(SubscriptionInfo subscription)
        {
            _subscription = subscription;
            _mode = enMode.UpdateMode;
        }

        public SubscriptionInfo Subscription
        {
            get { return _subscription; }
            set { _subscription = value; }
        }

        static public DataTable GetAllSubsicriptionInfo()
        {
            return SubsicriptionInfoDLL.GetAllSubsicriptionInfo();
        }

       public static async Task<List<SubscriptionsPackages>> GetAllGymSubPackages()
        {
            return await SubsicriptionInfoDLL.GetAllGymSubPackages();
        }

        public static async Task<double> GetPackFeesByPackageName(string packageName)
        {
            return await SubsicriptionInfoDLL.GetPackFeesByPackageName(packageName);
        }


        public static SubscriptionInfo Find(byte subTimeID)
        {
            return SubsicriptionInfoDLL.GetSubscriptionByID(subTimeID);
        }

        // حذف اشتراك
        public static bool Delete(byte subTimeID)
        {
            return SubsicriptionInfoDLL.DeleteSubscription(subTimeID);
        }

        // إضافة اشتراك جديد
        private bool _Add()
        {
            return SubsicriptionInfoDLL.AddSubscription(_subscription);
        }

        // تحديث الاشتراك
        private bool _Update()
        {
            return SubsicriptionInfoDLL.UpdateSubscription(_subscription);
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
                    return false;

                case enMode.UpdateMode:
                    return _Update();
            }
            return false;
        }
    }
}
