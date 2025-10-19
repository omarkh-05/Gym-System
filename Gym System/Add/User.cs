using BussinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static Gym_System.Add.frmPerson_And_Employee;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym_System.Add
{
    using System;
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography;
    using System.Text;

 

    public partial class frmaddUser : Form
    {
        
        public enum enUserMode { Add = 1,Update=2 }
        enUserMode _UserMode = enUserMode.Add;

        private short _UserID = -1;
        User _User;
        UserBLL _UserBLL;
        private int _EmployeeID = -1;

        public frmaddUser(short UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            if (_UserID == -1)
            {
                _UserMode = enUserMode.Add;
            }
            else
            {
                _UserMode = enUserMode.Update;
            }
        }

        static DataTable  _dtAllPeople = EmployeeBLL.GetAllEmployees();

            // عمل نسخة مختارة من الأعمدة
        DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false,
                "EmployeeID", "Name", "Gendor", "DateOfBirth", "IsActive",
                "NationalityNumber", "PhoneNumber", "EnterID", "Rank", "EmployeeType",
                "JoinningGymDate", "WorkTime");

       public void UpdateDataGrid()
        {
            DataTable dt = EmployeeBLL.GetAllEmployees();
            dgvUserInfo.DataSource = dt;
        }
        // ربط البيانات بالـ DataGridView
        private async Task _GetAllEmployees ()
        {

            dgvUserInfo.DataSource = _dtPeople;
            cbFilter.SelectedIndex = 0;
            // إعدادات أساسية
            dgvUserInfo.AutoGenerateColumns = false;
            dgvUserInfo.AllowUserToAddRows = false;
            dgvUserInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUserInfo.MultiSelect = false;
            dgvUserInfo.RowHeadersVisible = false;
            dgvUserInfo.EnableHeadersVisualStyles = false;
            dgvUserInfo.AllowUserToResizeColumns = false;
            dgvUserInfo.AllowUserToResizeRows = false;

            // مسح الأعمدة القديمة
            dgvUserInfo.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtPeople.Columns)
            {
                dgvUserInfo.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None, // عشان يتحكم في الـ Width
                    Resizable = DataGridViewTriState.False
                });
            }

            // أزرار تعديل وحذف/يوزر
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 90,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(editBtn);

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
            {
                HeaderText = "User",
                Text = "👤",
                UseColumnTextForButtonValue = true,
                Width = 90,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(deleteBtn);

            // الآن نضبط الـ Width بعد إنشاء الأعمدة
            if (dgvUserInfo.Columns.Contains("EmployeeID")) dgvUserInfo.Columns["EmployeeID"].Width = 75;
            if (dgvUserInfo.Columns.Contains("Name")) dgvUserInfo.Columns["Name"].Width = 175;
            if (dgvUserInfo.Columns.Contains("Gendor")) dgvUserInfo.Columns["Gendor"].Width = 90;
            if (dgvUserInfo.Columns.Contains("DateOfBirth")) dgvUserInfo.Columns["DateOfBirth"].Width = 150;
            if (dgvUserInfo.Columns.Contains("IsActive")) dgvUserInfo.Columns["IsActive"].Width = 90;
            if (dgvUserInfo.Columns.Contains("NationalityNumber")) dgvUserInfo.Columns["NationalityNumber"].Width = 185;
            if (dgvUserInfo.Columns.Contains("PhoneNumber")) dgvUserInfo.Columns["PhoneNumber"].Width = 150;
            if (dgvUserInfo.Columns.Contains("EnterID")) dgvUserInfo.Columns["EnterID"].Width = 90;
            if (dgvUserInfo.Columns.Contains("Rank")) dgvUserInfo.Columns["Rank"].Width = 90;
            if (dgvUserInfo.Columns.Contains("EmployeeType")) dgvUserInfo.Columns["EmployeeType"].Width = 160;
            if (dgvUserInfo.Columns.Contains("JoinningGymDate")) dgvUserInfo.Columns["JoinningGymDate"].Width = 190;
            if (dgvUserInfo.Columns.Contains("WorkTime")) dgvUserInfo.Columns["WorkTime"].Width = 110;

            // حجم الرووز والهيدر
            dgvUserInfo.RowTemplate.Height = 45;
            dgvUserInfo.ColumnHeadersHeight = 40;
            dgvUserInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvUserInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUserInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم الخطوط في الهيدر
            dgvUserInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvUserInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvUserInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم الخطوط في الصفوف
            dgvUserInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // تحديث عدد الصفوف
            lblRecord.Text = dgvUserInfo.Rows.Count.ToString();

            // حدث الأزرار
            dgvUserInfo.CellClick -= dgvUserInfo_CellClick;
            dgvUserInfo.CellClick += dgvUserInfo_CellClick;
        }
        private void dgvUserInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUserInfo.ClearSelection();
            dgvUserInfo.CurrentCell = null;
        }
        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvUserInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvUserInfo.Columns[e.ColumnIndex].HeaderText;
                var EmployeeID = dgvUserInfo.Rows[e.RowIndex].Cells["EmployeeID"].Value;
                _EmployeeID = (int)EmployeeID;
                if (header == "Update")
                {
                    frmPerson_And_Employee addEmployee = new frmPerson_And_Employee(_EmployeeID,"Employee");
                    addEmployee.ShowDialog();
                    UpdateDataGrid();
                }
                else if (header == "User")
                {
                   if(_CheackIfEmployeeUser(_EmployeeID))
                    {
                        pnlUserInfo.Enabled = true;
                        tbUserName.Focus();
                        dgvUserInfo.Enabled = false;
                    }
                }
            }
        }

        bool _CheackIfEmployeeUser(int EmployeeID)
        {
            var Employee = EmployeeBLL.Find(EmployeeID);
            if (Employee == null)
            {
                MessageBox.Show("الموظف غير موجود");
                return false;
            }

            if(UserBLL.FindUserByEmployeeID(EmployeeID))
            {
                MessageBox.Show("هذا الموظف هو مستخدم بالفعل");
                return false;
            }


            if(Employee.EmployeeRank == 12 && Employee.EmployeeType == "User")
            {
                return true;
            }
            else
            {
                MessageBox.Show("هذا الموظف غير مصنف كمستخدم أو الرتبة لا تساوي 12");
                return false;
            }
        }


        async Task _LoadDate()
        {
            await _GetAllEmployees();
            cbRole.SelectedIndex = 1;

            if (_UserMode == enUserMode.Add)
            {
                _User = new User();
                _UserBLL = new UserBLL();
                return;
            }

            _User = UserBLL.Find(_UserID); // <-- تأكد أن _UserID صحيح

            if (_User == null)
            {
                MessageBox.Show($"المستخدم {_UserID} غير موجود");
                return;
            }

            _UserBLL = new UserBLL(_User);

            _UserBLL.Users = _User;

            pnlUserInfo.Enabled = true;
            pnlnewPass.Visible = true;
            label10.Text = "Old Password :";

            // ملء الحقول
            tbUserName.Text = _UserBLL.Users.UserName ?? "";
            cbRole.Text = _UserBLL.Users.Role ?? "";
            rbActive1.Checked = _UserBLL.Users.Status;
            rbActive0.Checked = !_UserBLL.Users.Status;
        }


        private async void frmaddUser_Load(object sender, EventArgs e)
        {
           await _LoadDate();
        }


        void MoveUserData()
        {
            if (_User == null)
                _User = new User();

            _User.UserName = tbUserName.Text;
            _User.Role = cbRole.Text;
            _User.Status = rbActive1.Checked;
            _User.EmployeeID = _EmployeeID;
            _User.UserAddBy = 1;

            if (_UserMode == enUserMode.Add)
            {
                _User.PasswordHash = PasswordHasher.HashPassword(tbPassword.Text);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(ValidateRequiredFields(this, errorProvider1))
           {
                MessageBox.Show("لا يمكن اضافة مستخدم غير موظف");
                return; 
           }

            MoveUserData();

            if (_UserBLL == null)
            {
                // إذا لم يتم تهيئته، أنشئه الآن
                _UserBLL = new UserBLL();
            }
            

            if (_UserMode == enUserMode.Update)
            {
                if (!_UserBLL.VerifyOldPassword(_UserID, tbPassword.Text))
                {
                    MessageBox.Show("كلمة المرور القديمة غير مطابقة!");
                    return;
                }

                // إذا صح، خزن كلمة السر الجديدة مع Hash
                _User.PasswordHash = PasswordHasher.HashPassword(tbnewPass.Text);
            }

            _UserBLL.Users = _User;

            if (_UserBLL.Save())
                MessageBox.Show((_UserMode == enUserMode.Add ? " تم إضافة " : " تم تعديل ") + $" كمستخدم {tbUserName.Text} ");
            else
                MessageBox.Show((_UserMode == enUserMode.Add ? " تعذر إضافة " : " تعذر تعديل ") + $" {tbUserName.Text}");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidateRequiredFields(Control parent, ErrorProvider errorProvider)
        {
            bool allValid = true;

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is RequiredTextBox rtb)
                {
                    if (!rtb.IsValid())
                    {
                        errorProvider.SetError(rtb, rtb.ErrorMessage);
                        allValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(rtb, string.Empty);
                    }
                }
                else if (ctrl is RequiredComboBox rcb)
                {
                    if (!rcb.IsValid())
                    {
                        errorProvider.SetError(rcb, rcb.ErrorMessage);
                        allValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(rcb, string.Empty);
                    }
                }
                else if (ctrl.HasChildren)
                {
                    if (!ValidateRequiredFields(ctrl, errorProvider))
                        allValid = false;
                }
            }

            return allValid;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None");
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "Employee ID":
                    FilterColumn = "EmployeeID";
                    break;

                case "National No.":
                    FilterColumn = "NationalityNumber";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "Gendor":
                    FilterColumn = "Gendor";
                    break;

                case "Phone Number":
                    FilterColumn = "PhoneNumber";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecord.Text = dgvUserInfo.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "EmployeeID" || FilterColumn == "PhoneNumber" || FilterColumn == "NationalityNumber")
                //in this case we deal with integer not string.
                try
                {
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbSearch.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("لا يمكن كتابة احرف");
                }

            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim());


            lblRecord.Text = dgvUserInfo.Rows.Count.ToString();
        }
    }
}
