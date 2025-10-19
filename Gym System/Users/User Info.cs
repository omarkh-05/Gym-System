using BussinessLayer;
using Gym_System.Add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System.Users
{
    public partial class frmUser_Info : Form
    {
        static DataTable _dtAllUsers = UserBLL.GetAllUsersView();
        DataTable _dtUsers;
        short _UserID = -1;
        int _EmployeeID = -1;
        int _PersonID = -1;
        public frmUser_Info()
        {
            InitializeComponent();

            _dtUsers = _dtAllUsers.DefaultView.ToTable(false,
   "UserID","EmployeeID", "PersonID", "Name", "DateOfBirth", "Gendor", "PhoneNumber", "NationalityNumber", "IsActive",
   "JoinningGymDate", "EmployeeType", "Rank", "WorkTime","Role");
        }

        private void LoadUsersToGrid()
        {
            DataTable dt = UserBLL.GetAllUsersView();
            dgvUserInfo.DataSource = dt;
        }

        private async Task _LoadUsersData()
        {
            dgvUserInfo.DataSource = _dtUsers;
            cbFilter.SelectedIndex = 0;

            dgvUserInfo.AutoGenerateColumns = false;
            dgvUserInfo.AllowUserToAddRows = false;
            dgvUserInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUserInfo.MultiSelect = false;
            dgvUserInfo.RowHeadersVisible = false;
            dgvUserInfo.EnableHeadersVisualStyles = false;
            dgvUserInfo.AllowUserToResizeColumns = false;
            dgvUserInfo.AllowUserToResizeRows = false;

            dgvUserInfo.Columns.Clear();

            // إنشاء الأعمدة النصية
            foreach (DataColumn col in _dtUsers.Columns)
            {
                dgvUserInfo.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // أزرار Update/Show/Delete
            AddUserButtonColumn("Update", "✏️", 100);
            AddUserButtonColumn("Show", "🔍", 100);
            AddUserButtonColumn("Delete", "🗑️", 100);

            // ضبط عرض الأعمدة
            SetUserColumnWidths();

            // حجم الصفوف والهيدر
            dgvUserInfo.RowTemplate.Height = 45;
            dgvUserInfo.ColumnHeadersHeight = 40;
            dgvUserInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvUserInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUserInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم خطوط الهيدر
            dgvUserInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvUserInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvUserInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم خطوط الصفوف
            dgvUserInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecord.Text = dgvUserInfo.Rows.Count.ToString();

            dgvUserInfo.CellClick -= dgvUserInfo_CellClick;
            dgvUserInfo.CellClick += dgvUserInfo_CellClick;
        }
        private void AddUserButtonColumn(string header, string text, int width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                Resizable = DataGridViewTriState.False
            };
            dgvUserInfo.Columns.Add(btn);
        }
        private void SetUserColumnWidths()
        {
            if (dgvUserInfo.Columns.Contains("UserID")) dgvUserInfo.Columns["UserID"].Width = 80;
            if (dgvUserInfo.Columns.Contains("EmployeeID")) dgvUserInfo.Columns["EmployeeID"].Width = 80;
            if (dgvUserInfo.Columns.Contains("PersonID")) dgvUserInfo.Columns["PersonID"].Width = 80;
            if (dgvUserInfo.Columns.Contains("Name")) dgvUserInfo.Columns["Name"].Width = 140;
            if (dgvUserInfo.Columns.Contains("DateOfBirth")) dgvUserInfo.Columns["DateOfBirth"].Width = 110;
            if (dgvUserInfo.Columns.Contains("Gendor")) dgvUserInfo.Columns["Gendor"].Width = 70;
            if (dgvUserInfo.Columns.Contains("PhoneNumber")) dgvUserInfo.Columns["PhoneNumber"].Width = 140;
            if (dgvUserInfo.Columns.Contains("NationalityNumber")) dgvUserInfo.Columns["NationalityNumber"].Width = 150;
            if (dgvUserInfo.Columns.Contains("IsActive")) dgvUserInfo.Columns["IsActive"].Width = 70;
            if (dgvUserInfo.Columns.Contains("JoinningGymDate")) dgvUserInfo.Columns["JoinningGymDate"].Width = 140;
            if (dgvUserInfo.Columns.Contains("EmployeeType")) dgvUserInfo.Columns["EmployeeType"].Width = 110;
            if (dgvUserInfo.Columns.Contains("Rank")) dgvUserInfo.Columns["Rank"].Width = 70;
            if (dgvUserInfo.Columns.Contains("WorkTime")) dgvUserInfo.Columns["WorkTime"].Width = 60;
            if (dgvUserInfo.Columns.Contains("Role")) dgvUserInfo.Columns["Role"].Width = 80;
        }
        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUserInfo.Rows[e.RowIndex];

            if (dgvUserInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvUserInfo.Columns[e.ColumnIndex].HeaderText;
                short userID = Convert.ToInt16(dgvUserInfo.CurrentRow.Cells["UserID"].Value);
                int PersonID = Convert.ToInt32(dgvUserInfo.CurrentRow.Cells["PersonID"].Value);
                _UserID = userID;
                _PersonID = PersonID;

                if (header == "Update")
                {
                    frmaddUser frm = new frmaddUser(userID);
                    frm.ShowDialog();

                    // إعادة تحميل الجدول بعد التحديث
                    LoadUsersToGrid();
                }
                else if (header == "Show")
                {
                    UserInfoControl.LoadData(_UserID, _PersonID);
                    LoadUsersToGrid();
                }
                else if (header == "Delete")
                {
                    if (MessageBox.Show($" هل انت متأكد من حذف المستخدم رقم {_EmployeeID}", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (UserBLL.Delete(userID))
                        {
                            MessageBox.Show("تم حذف المستخدم بتجاح");
                        }
                        else
                        {
                            MessageBox.Show("تعذر حذف المستخدم");
                        }
                    }
                    LoadUsersToGrid();
                    return;
                }
            }
        }
        private void dgvUserInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUserInfo.ClearSelection();
            dgvUserInfo.CurrentCell = null;
        }



        private async void frmUser_Info_Load(object sender, EventArgs e)
        {
            await _LoadUsersData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilter.Text != "None");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "National Number":
                    FilterColumn = "NationalityNumber";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "Phone Number":
                    FilterColumn = "PhoneNumber";
                    break;
                case "Gendor":
                    FilterColumn = "Gendor";
                    break;
                case "Employee Type":
                    FilterColumn = "EmployeeType";
                    break;
                case "Role":
                    FilterColumn = "Role";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecord.Text = dgvUserInfo.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "IsActive")
            {
                if (tbSearch.Text.Trim().ToLower() == "true" || tbSearch.Text.Trim() == "1")
                    _dtUsers.DefaultView.RowFilter = $"{FilterColumn} = true";
                else if (tbSearch.Text.Trim().ToLower() == "false" || tbSearch.Text.Trim() == "0")
                    _dtUsers.DefaultView.RowFilter = $"{FilterColumn} = false";
                else
                    _dtUsers.DefaultView.RowFilter = "";
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }

            lblRecord.Text = dgvUserInfo.Rows.Count.ToString();
        }

    }
}
