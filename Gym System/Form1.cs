using Entities;
using Gym_System.Add;
using Gym_System.Employees;
using Gym_System.Presence;
using Gym_System.Subscribers;
using Gym_System.Subscription_Info;
using Gym_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        public enum enPerson { Subscriber = 1, Employee=2};
        enPerson _Person;

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock1.Text = DateTime.Now.ToString("HH:mm");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text = UserSession.UserName;
            Visible = false;
            timer1.Start();
            Visible = true;
        }

        private Form currentForm = null; // متغير لتخزين الفورم المفتوح حالياً
        private void OpenFormInPanel(Form frm)
        {
            if (frm == null) return; // حماية من null

            try
            {
                // اغلق الفورم الحالي إن وجد
                if (currentForm != null)
                {
                    if (!currentForm.IsDisposed)
                    {
                        currentForm.Close();
                    }
                    panel1?.Controls.Remove(currentForm);
                    currentForm?.Dispose();
                    currentForm = null;
                }

                currentForm = frm;

                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                panel1?.Controls.Add(frm);
                frm.BringToFront();
                frm.Show();

                // حدث عند إغلاق الفورم يدوياً
                frm.FormClosed += (s, e) =>
                {
                    currentForm = null;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء فتح الفورم: {ex.Message}");
            }
        }
        private bool CheckIfFormOpen(Form frm)
        {
            if (frm == null) return false; // حماية من null

            if (currentForm != null && !currentForm.IsDisposed)
            {
                if (currentForm.GetType() == frm.GetType())
                {
                    MessageBox.Show("انت في هذه الصفحة حاليا");
                    return true;
                }
            }
            return false;
        }

        private void btnSubInfo1_Click(object sender, EventArgs e)
        {
            if (UserSession.UserID != 1)
            {
                return;
            }
            
            frmSubscription_Info frmSubscribers_Info1 = new frmSubscription_Info();
            if (CheckIfFormOpen(frmSubscribers_Info1))
            {
                return;
            }
            OpenFormInPanel(frmSubscribers_Info1);
        }

        private void btnEmployee1_Click(object sender, EventArgs e)
        {
            if (UserSession.UserID != 1)
            {
                return;
            }
           
            frmEmployees employees1 = new frmEmployees();
            if (CheckIfFormOpen(employees1))
            {
                return;
            }
            OpenFormInPanel(employees1);
        }

        private void btnSubscriber1_Click(object sender, EventArgs e)
        {
            frmSubscribers_Info frmSubscribers_Info1 = new frmSubscribers_Info();
            if (CheckIfFormOpen(frmSubscribers_Info1))
            {
                return;
            }
            OpenFormInPanel(frmSubscribers_Info1);
        }

        private void btnUser1_Click(object sender, EventArgs e)
        {
            if (UserSession.UserID != 1)
            {
                return;
            }
            frmUser_Info frmUser = new frmUser_Info();
            if (CheckIfFormOpen(frmUser))
            {
                return;
            }
            OpenFormInPanel(frmUser);
        }

        private void SubscriberPresence_Click(object sender, EventArgs e)
        {
            frmSubscribersPresence frmSubscribersPresence = new frmSubscribersPresence();
            if (CheckIfFormOpen(frmSubscribersPresence))
            {
                return;
            }
            OpenFormInPanel(frmSubscribersPresence);
        }

        private void EmployeePresence_Click(object sender, EventArgs e)
        {
            frmEmployeesPresence frmEmployeesPresence = new frmEmployeesPresence();
            if (CheckIfFormOpen(frmEmployeesPresence))
            {
                return;
            }
            OpenFormInPanel(frmEmployeesPresence);
        }

        private void PresenceID_Click(object sender, EventArgs e)
        {
            frmPresenceID presenceID = new frmPresenceID();
            if (CheckIfFormOpen(presenceID))
            {
                return;
            }
            OpenFormInPanel(presenceID);
        }

        private void EmployeePresenceID_Click(object sender, EventArgs e)
        {
            frmEmployeePresenceID EmployeepresenceID = new frmEmployeePresenceID();
            if (CheckIfFormOpen(EmployeepresenceID))
            {
                return;
            }
            OpenFormInPanel(EmployeepresenceID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            if (UserSession.UserID == 1)
            {
                ToolStripMenuItem subscriberItem = new ToolStripMenuItem("Subscriber");
                subscriberItem.Font = new Font("Segoe UI", 12); // تكبير الخط
                subscriberItem.Image = Image.FromFile(ConfigurationManager.AppSettings["SubscriberIcon"]); // إضافة صورة
                subscriberItem.Click += SubscriberPresence_Click;

                // Employees item
                ToolStripMenuItem employeesItem = new ToolStripMenuItem("Employees");
                employeesItem.Font = new Font("Segoe UI", 12);
                employeesItem.Image = Image.FromFile(ConfigurationManager.AppSettings["EmployeeIcon"]);
                employeesItem.Click += EmployeePresence_Click;

                ToolStripMenuItem PresenceID = new ToolStripMenuItem("PresenceID");
                PresenceID.Font = new Font("Segoe UI", 12);
                PresenceID.Image = Image.FromFile(ConfigurationManager.AppSettings["PresenceIcon"]);
                PresenceID.Click += PresenceID_Click;

                // إضافة العناصر للمنيو
                ToolStripMenuItem EmployeePresenceID = new ToolStripMenuItem("Employee PresenceID");
                EmployeePresenceID.Font = new Font("Segoe UI", 12);
                EmployeePresenceID.Image = Image.FromFile(ConfigurationManager.AppSettings["PresenceIcon"]);
                EmployeePresenceID.Click += EmployeePresenceID_Click;

                // إضافة العناصر للمنيو
                menu.Items.Add(subscriberItem);
                menu.Items.Add(employeesItem);
                menu.Items.Add(PresenceID);
                menu.Items.Add(EmployeePresenceID);

                menu.Show(Presence, new Point(0, Presence.Height));
            }
            else
            {
                ToolStripMenuItem subscriberItem = new ToolStripMenuItem("Subscriber");
                subscriberItem.Font = new Font("Segoe UI", 12); // تكبير الخط
                subscriberItem.Image = Image.FromFile(ConfigurationManager.AppSettings["SubscriberIcon"]); // إضافة صورة
                subscriberItem.Click += SubscriberPresence_Click;

                ToolStripMenuItem PresenceID = new ToolStripMenuItem("PresenceID");
                PresenceID.Font = new Font("Segoe UI", 12);
                PresenceID.Image = Image.FromFile(ConfigurationManager.AppSettings["PresenceIcon"]);
                PresenceID.Click += PresenceID_Click;

                menu.Items.Add(PresenceID);
                menu.Items.Add(subscriberItem);

                menu.Show(Presence, new Point(0, Presence.Height));
            }
            
        }

        private void AddSubscriberOrEmployee_Click(object sender, EventArgs e)
        {
            frmPerson_And_Employee frmPerson_And_Employee = new frmPerson_And_Employee(-1,"Subscriber");
            if (CheckIfFormOpen(frmPerson_And_Employee))
            {
                return;
            }
            OpenFormInPanel(frmPerson_And_Employee);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            if (UserSession.UserID == 1)
            {
                ToolStripMenuItem SubEmpItem = new ToolStripMenuItem("Subscriber / Employee");
               SubEmpItem.Font = new Font("Segoe UI", 12); // تكبير الخط
               SubEmpItem.Image = Image.FromFile(ConfigurationManager.AppSettings["PersonIcon"]); // إضافة صورة
                SubEmpItem.Click += AddSubscriberOrEmployee_Click;

                ToolStripMenuItem UserItem = new ToolStripMenuItem("User");
                UserItem.Font = new Font("Segoe UI", 12);
                UserItem.Image = Image.FromFile(ConfigurationManager.AppSettings["UserIcon"]);
                UserItem.Click += AddUser_Click;

                // إضافة العناصر للمنيو
                menu.Items.Add(SubEmpItem);
                menu.Items.Add(UserItem);


                menu.Show(Add, new Point(0, Add.Height));
            }else
            {
                ToolStripMenuItem subscriberItem = new ToolStripMenuItem("Subscriber");
                subscriberItem.Font = new Font("Segoe UI", 12); // تكبير الخط
                subscriberItem.Image = Image.FromFile(ConfigurationManager.AppSettings["PersonIcon"]); // إضافة صورة
                subscriberItem.Click += AddSubscriberOrEmployee_Click;

                // إضافة العناصر للمنيو
                menu.Items.Add(subscriberItem);


                menu.Show(Add, new Point(0, Add.Height));
            }
               
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            frmaddUser addUser = new frmaddUser(-1);
            if (CheckIfFormOpen(addUser))
            {
                return;
            }
            OpenFormInPanel(addUser);
        }
        
        private void btnLogout1_Click(object sender, EventArgs e)
        {
            Login_Screen login = new Login_Screen();
            login.Show();
            this.Close();
        }
       
    }
}