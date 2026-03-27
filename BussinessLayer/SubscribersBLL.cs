using DataLayer;
using Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public interface ISubscribersBLL
    {
        Task<int> AddSubscribersFE(AddSubscriberDTO subscriber,int personId);
        Task<SubscriberDTO> GetSubscriberByPersonId(int personId);
    }
    public class SubscribersBLL : ISubscribersBLL
    {
        private enum enMode { AddMode = 1, UpdateMode = 2 };
        enMode _mode = enMode.AddMode;

        private Subscriber _subscriber;

        public SubscribersBLL()
        {
            _subscriber = new Subscriber();
            _mode = enMode.AddMode; // إضافة جديدة
        }

        public SubscribersBLL(Subscriber subscriber)
        {
            _subscriber = subscriber;
            // إذا كان SubscriberID موجود، غيّر الوضع إلى تحديث
            _mode = (_subscriber.SubscriberID > 0) ? enMode.UpdateMode : enMode.AddMode;
        }

        // Property لربط الـ Entity
        public Subscriber CurrentSubscriber
        {
            get { return _subscriber; }
            set { _subscriber = value; }
        }

        public static DataTable GetAllSubscribers()
        {
            return SubscribersDLL.GetAllSubscribers();
        }

        public static DataTable GetAllSubscribersView()
        {
            return SubscribersDLL.GetAllSubscribersView();
        }

        private bool _Add()
        {
            _subscriber.SubscriberID = SubscribersDLL.AddNewSubscriber(_subscriber);
            return _subscriber.SubscriberID != -1;
        }

        public async Task<int> AddSubscribersFE(AddSubscriberDTO subscriber,int personId)
        {
            subscriber.PersonId = personId;
            return await SubscribersDLL.AddNewSubscriberFE(subscriber);
        }

        private bool _Update()
        {
            // تأكد أن SubscriberID > 0 قبل التحديث
            if (_subscriber.SubscriberID <= 0)
                return false;

            return SubscribersDLL.UpdateSubscriber(_subscriber);
        }

        public static bool Deactive(int PersonID)
        {
            return SubscribersDLL.DeactiveSubscriber(PersonID);
        }

        public static Subscriber Find(int subID)
        {
            return SubscribersDLL.GetSubscriberByID(subID);
        }

       public async Task<SubscriberDTO> GetSubscriberByPersonId(int personId)
        {
            return await SubscribersDLL.GetSubscriberByPersonId(personId);
        }

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
