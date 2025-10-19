using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System.Presence
{
    public partial class frmEmployeePresenceID : Form
    {
        public frmEmployeePresenceID()
        {
            InitializeComponent();
        }

        private void frmEmployeePresenceID_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCheckinClock1.Text = DateTime.Now.ToString("HH:mm");
            lblCheckoutClock1.Text = DateTime.Now.ToString("HH:mm");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            frmEmployeesPresence frmEmployeePresenceID = new frmEmployeesPresence();

            string Msg = CheckinPresenceBLL.RegisterEmployeeCheckin(tbCheckinID.Text.Trim());
            MessageBox.Show(Msg);
            frmEmployeePresenceID.CheckinLoadData();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            frmEmployeesPresence frmEmployeePresenceID = new frmEmployeesPresence();
            decimal extra;
            string Msg = CheckinPresenceBLL.RegisterEmployeeCheckout(tbCheckinID.Text.Trim(), out extra);
            MessageBox.Show(Msg);
            frmEmployeePresenceID.CheckoutLoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
