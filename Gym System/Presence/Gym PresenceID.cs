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
    public partial class frmPresenceID : Form
    {
        public frmPresenceID()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmSubscribersPresence frmSubscribersPresence = new frmSubscribersPresence();
           MessageBox.Show(CheckinPresenceBLL.RegisterCheckin(tbCheckinID.Text.Trim()).ToString());
            tbCheckinID.Text = string.Empty;
            frmSubscribersPresence.LoadPresenceToGrid();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            frmSubscribersPresence frmSubscribersPresence = new frmSubscribersPresence();
            MessageBox.Show(CheckinPresenceBLL.RegisterCheckout(tbCheckoutID.Text.Trim()).ToString());
            tbCheckoutID.Text = string.Empty;
            frmSubscribersPresence.LoadCheckoutPresenceToGrid();
        }

        private void frmPresenceID_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCheckinClock1.Text = DateTime.Now.ToString("HH:mm");
            lblCheckoutClock1.Text = DateTime.Now.ToString("HH:mm");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
