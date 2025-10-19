using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System.Users
{
    public partial class Login_Screen : Form
    {
        private UserBLL _usersBussinessObject;
        private User _user;
        public Login_Screen()
        {
            InitializeComponent();
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            string savedUsername = "", savedPassword = "";
            UserSession.GetStoredCredential(ref savedUsername, ref savedPassword);
            if (!string.IsNullOrEmpty(savedUsername))
            {
                txtUserName.Text = savedUsername;
                txtPassword.Text = savedPassword;
                cbRememberme.Checked = true;
            }
        }

        private bool _CheackLoginInfo()
        {
            _user = UserBLL.FindUserForLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (_user == null || !_user.IsActive)
            {
                return false;
            }
            return true;

        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["LogPath"];

            // تخزين بيانات اليوزر إذا تم التفعيل
            if (cbRememberme.Checked)
                UserSession.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            else
                UserSession.RememberUsernameAndPassword("", "");

            if (_CheackLoginInfo())
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - User {_user.UserName} logged in");
                }

                UserSession.SetUser(_user);

                frmMain mainForm = new frmMain();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("خطأ في اسم المستخدم / كلمة المرور أو المستخدم غير فعال");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
