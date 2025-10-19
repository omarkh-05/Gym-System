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
    public partial class SubscriberControl : UserControl
    {
        public int _SubscriberID = -1;
        public int _PersonID = -1;
        Subscriber _subscriber;
        SubscribersBLL _SubscribersBLL;

        public SubscriberControl()
        {
            InitializeComponent();
        }

        public void LoadDate(int SubscriberID)
        {
            _SubscriberID = SubscriberID;

            _subscriber = SubscribersBLL.Find(_SubscriberID);

            if (_subscriber == null)
            {
                MessageBox.Show($"لا يوجد مشترك برقم {_SubscriberID}");
                return;
            }

            _SubscribersBLL = new SubscribersBLL(_subscriber);

            string Department = DepartmentBLL.Find(_subscriber.DepartmentID).DepartmentName;
            string SubPlan = SubInfoBLL.Find(_subscriber.SubscriptionInfo).DepartmentName;

            PersonInfoControl.LoadPersonData(_subscriber.PersonID);
            lblDepartment.Text = Department;
            lblSubDate.Text = _subscriber.SubDate.Value.ToShortDateString();
            lblEndDate.Text = _subscriber.EndDate.Value.ToShortDateString();
            lblIsPaid.Text = _subscriber.IsPaid?"Paid":"Not Paid";
            lblSubPlan.Text = SubPlan;
        }
    }
}
