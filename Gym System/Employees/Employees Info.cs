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

namespace Gym_System.Employees
{
    public partial class frmEmployees : Form
    {
        static DataTable _dtAllEmployees = EmployeeBLL.GetAllEmployeesView();
        DataTable _dtEmployees;
        int _EmployeeID = -1;
        int _PersonID = -1;

        public frmEmployees()
        {
            InitializeComponent();
            _dtEmployees = _dtAllEmployees.DefaultView.ToTable(false,
   "EmployeeID", "PersonID", "Name", "DateOfBirth", "Gendor", "PhoneNumber", "NationalityNumber", "IsActive",
   "JoinningGymDate", "EmployeeType", "Rank", "WorkTime");
        }


        public void LoadEmployeesToGrid()
        {
            DataTable dt = EmployeeBLL.GetAllEmployeesView();
            dgvEmpInfo.DataSource = dt;
        }
        private async Task _LoadData()
        {
            dgvEmpInfo.DataSource = _dtEmployees;
            cbFilter.SelectedIndex = 0;

            dgvEmpInfo.AutoGenerateColumns = false;
            dgvEmpInfo.AllowUserToAddRows = false;
            dgvEmpInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvEmpInfo.MultiSelect = false;
            dgvEmpInfo.RowHeadersVisible = false;
            dgvEmpInfo.EnableHeadersVisualStyles = false;
            dgvEmpInfo.AllowUserToResizeColumns = false;
            dgvEmpInfo.AllowUserToResizeRows = false;

            dgvEmpInfo.Columns.Clear();

            // إنشاء الأعمدة النصية
            foreach (DataColumn col in _dtEmployees.Columns)
            {
                dgvEmpInfo.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // أزرار Update/Show/Delete
            AddEmployeeButtonColumn("Update", "✏️", 100);
            AddEmployeeButtonColumn("Show", "🔍", 100);
            AddEmployeeButtonColumn("Delete", "🗑️", 100);

            // ضبط عرض الأعمدة
            SetEmployeeColumnWidths();

            // حجم الصفوف والهيدر
            dgvEmpInfo.RowTemplate.Height = 45;
            dgvEmpInfo.ColumnHeadersHeight = 40;
            dgvEmpInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvEmpInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEmpInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم خطوط الهيدر
            dgvEmpInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvEmpInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvEmpInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم خطوط الصفوف
            dgvEmpInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecord.Text = dgvEmpInfo.Rows.Count.ToString();

            dgvEmpInfo.CellClick -= dgvEmpInfo_CellClick;
            dgvEmpInfo.CellClick += dgvEmpInfo_CellClick;
        }
        private void AddEmployeeButtonColumn(string header, string text, int width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                Resizable = DataGridViewTriState.False
            };
            dgvEmpInfo.Columns.Add(btn);
        }

        private void SetEmployeeColumnWidths()
        {
            if (dgvEmpInfo.Columns.Contains("EmployeeID")) dgvEmpInfo.Columns["EmployeeID"].Width = 80;
            if (dgvEmpInfo.Columns.Contains("PersonID")) dgvEmpInfo.Columns["PersonID"].Width = 80;
            if (dgvEmpInfo.Columns.Contains("Name")) dgvEmpInfo.Columns["Name"].Width = 150;
            if (dgvEmpInfo.Columns.Contains("DateOfBirth")) dgvEmpInfo.Columns["DateOfBirth"].Width = 150;
            if (dgvEmpInfo.Columns.Contains("Gendor")) dgvEmpInfo.Columns["Gendor"].Width = 70;
            if (dgvEmpInfo.Columns.Contains("PhoneNumber")) dgvEmpInfo.Columns["PhoneNumber"].Width = 150;
            if (dgvEmpInfo.Columns.Contains("NationalityNumber")) dgvEmpInfo.Columns["NationalityNumber"].Width = 150;
            if (dgvEmpInfo.Columns.Contains("IsActive")) dgvEmpInfo.Columns["IsActive"].Width = 70;
            if (dgvEmpInfo.Columns.Contains("JoinningGymDate")) dgvEmpInfo.Columns["JoinningGymDate"].Width = 170;
            if (dgvEmpInfo.Columns.Contains("EmployeeType")) dgvEmpInfo.Columns["EmployeeType"].Width = 140;
            if (dgvEmpInfo.Columns.Contains("Rank")) dgvEmpInfo.Columns["Rank"].Width = 70;
            if (dgvEmpInfo.Columns.Contains("WorkTime")) dgvEmpInfo.Columns["WorkTime"].Width = 70;
        }
        private void dgvEmpInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmpInfo.Rows[e.RowIndex];

            if (dgvEmpInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvEmpInfo.Columns[e.ColumnIndex].HeaderText;
                int employeeID = Convert.ToInt32(dgvEmpInfo.CurrentRow.Cells["EmployeeID"].Value);
                int personID = Convert.ToInt32(dgvEmpInfo.CurrentRow.Cells["PersonID"].Value);

                _EmployeeID = employeeID;
                _PersonID = personID;

                if (header == "Update")
                {
                    frmPerson_And_Employee frm = new frmPerson_And_Employee(_EmployeeID, "Employee");
                    frm.ShowDialog();

                    // إعادة تحميل الجدول بعد التحديث
                    LoadEmployeesToGrid();
                }
                else if (header == "Show")
                {
                    EmployeeInfoControl.LoadData(_EmployeeID, personID); // employeeID من الصف المحدد

                    LoadEmployeesToGrid();
                }
                else if (header == "Delete")
                {
                    if (MessageBox.Show($" هل انت متأكد من حذف الموظف رقم {_EmployeeID}", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (EmployeeBLL.Delete(_EmployeeID))
                        {
                            MessageBox.Show("تم حذف الموظف بتجاح");
                        }
                        else
                        {
                            MessageBox.Show("تعذر حذف الموظف");
                        }
                    }
                    LoadEmployeesToGrid();
                    return;
                }
            }
        }
        private void dgvEmpInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEmpInfo.ClearSelection();
            dgvEmpInfo.CurrentCell = null;
        }

        private async void frmEmployees_Load(object sender, EventArgs e)
        {
            await _LoadData();
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
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtEmployees.DefaultView.RowFilter = "";
                lblRecord.Text = dgvEmpInfo.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "IsActive")
            {
                if (tbSearch.Text.Trim().ToLower() == "true" || tbSearch.Text.Trim() == "1")
                    _dtEmployees.DefaultView.RowFilter = $"{FilterColumn} = true";
                else if (tbSearch.Text.Trim().ToLower() == "false" || tbSearch.Text.Trim() == "0")
                    _dtEmployees.DefaultView.RowFilter = $"{FilterColumn} = false";
                else
                    _dtEmployees.DefaultView.RowFilter = "";
            }
            else
            {
                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }

            lblRecord.Text = dgvEmpInfo.Rows.Count.ToString();
        }
    }
}
