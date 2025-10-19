using BussinessLayer;
using Entities;
using Gym_System.Add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gym_System.Subscribers
{
    public partial class frmSubscribers_Info : Form
    {
        static DataTable _dtAllSubscribers = SubscribersBLL.GetAllSubscribersView();
        DataTable _dtSubscribers;
        int _SubscriberID = -1;
        int _PersonID = -1;
        public frmSubscribers_Info()
        {
            InitializeComponent();
            _dtSubscribers = _dtAllSubscribers.DefaultView.ToTable(false,
    "SubscriberID","PersonID","Name","DateOfBirth","Gendor", "PhoneNumber", "NationalityNumber", "IsActive",
    "SubDate", "EndSubDate", "IsPaid", "DepartmentID", "SubscriptionInfo","AddedBy");
        }

        public void LoadSubscribersToGrid()
        {
            DataTable dt = SubscribersBLL.GetAllSubscribersView();
            dgvSubsInfo.DataSource = dt;
        }
        async Task _LoadData()
        {
            dgvSubsInfo.DataSource = _dtSubscribers;

            cbFilter.SelectedIndex = 0;

            dgvSubsInfo.AutoGenerateColumns = false;
            dgvSubsInfo.AllowUserToAddRows = false;
            dgvSubsInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSubsInfo.MultiSelect = false;
            dgvSubsInfo.RowHeadersVisible = false;
            dgvSubsInfo.EnableHeadersVisualStyles = false;
            dgvSubsInfo.AllowUserToResizeColumns = false;
            dgvSubsInfo.AllowUserToResizeRows = false;

            dgvSubsInfo.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtSubscribers.Columns)
            {
                dgvSubsInfo.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }

            // أزرار تعديل
            DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Update",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvSubsInfo.Columns.Add(editBtn);

            DataGridViewButtonColumn showBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Show",
                Text = "🔍",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvSubsInfo.Columns.Add(showBtn);

            DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 100,
                Resizable = DataGridViewTriState.False
            };
            dgvSubsInfo.Columns.Add(deleteBtn);

            // ضبط Widths كما في القديم
            if (dgvSubsInfo.Columns.Contains("SubscriberID")) dgvSubsInfo.Columns["SubscriberID"].Width = 80;
            if (dgvSubsInfo.Columns.Contains("PersonID")) dgvSubsInfo.Columns["PersonID"].Width = 80;
            if (dgvSubsInfo.Columns.Contains("Name")) dgvSubsInfo.Columns["Name"].Width = 150;
            if (dgvSubsInfo.Columns.Contains("DateOfBirth")) dgvSubsInfo.Columns["DateOfBirth"].Width = 120;
            if (dgvSubsInfo.Columns.Contains("Gendor")) dgvSubsInfo.Columns["Gendor"].Width = 70;
            if (dgvSubsInfo.Columns.Contains("PhoneNumber")) dgvSubsInfo.Columns["PhoneNumber"].Width = 120;
            if (dgvSubsInfo.Columns.Contains("NationalityNumber")) dgvSubsInfo.Columns["NationalityNumber"].Width = 120;
            if (dgvSubsInfo.Columns.Contains("IsActive")) dgvSubsInfo.Columns["IsActive"].Width = 70;
            if (dgvSubsInfo.Columns.Contains("SubDate")) dgvSubsInfo.Columns["SubDate"].Width = 120;
            if (dgvSubsInfo.Columns.Contains("EndSubDate")) dgvSubsInfo.Columns["EndSubDate"].Width = 120;
            if (dgvSubsInfo.Columns.Contains("IsPaid")) dgvSubsInfo.Columns["IsPaid"].Width = 70;
            if (dgvSubsInfo.Columns.Contains("DepartmentID")) dgvSubsInfo.Columns["DepartmentID"].Width = 90;
            if (dgvSubsInfo.Columns.Contains("SubscriptionInfo")) dgvSubsInfo.Columns["SubscriptionInfo"].Width = 100;
            if (dgvSubsInfo.Columns.Contains("AddedBy")) dgvSubsInfo.Columns["AddedBy"].Width = 50;


            // حجم الصفوف والهيدر
            dgvSubsInfo.RowTemplate.Height = 45;
            dgvSubsInfo.ColumnHeadersHeight = 40;
            dgvSubsInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvSubsInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSubsInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم خطوط الهيدر
            dgvSubsInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSubsInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvSubsInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم خطوط الصفوف
            dgvSubsInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecord.Text = dgvSubsInfo.Rows.Count.ToString();

            dgvSubsInfo.CellClick -= dgvSubsInfo_CellClick;
            dgvSubsInfo.CellClick += dgvSubsInfo_CellClick;
        }
        private void dgvSubsInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSubsInfo.Rows[e.RowIndex];

            if (dgvSubsInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvSubsInfo.Columns[e.ColumnIndex].HeaderText;
                int SubscriberID = (int) dgvSubsInfo.CurrentRow.Cells["SubscriberID"].Value;
                _SubscriberID = SubscriberID;
                int PersonID = (int)dgvSubsInfo.CurrentRow.Cells[1].Value;
                _PersonID = PersonID;

                if (header == "Update")
                {
                    frmPerson_And_Employee frm = new frmPerson_And_Employee(SubscriberID, "Subscriber");
                    frm.ShowDialog();

                    LoadSubscribersToGrid();
                }
                else if (header == "Show")
                {
                    SubscribersInfoControl.LoadDate(_SubscriberID);

                    LoadSubscribersToGrid();
                }
                else if (header == "Delete")
                {
                    if ((bool)dgvSubsInfo.CurrentRow.Cells["IsActive"].Value == false)
                    {
                        MessageBox.Show("هذا المشترك معطل بالفعل");
                        return;
                    }

                    if (MessageBox.Show($"هل انت متأكد من تعطيل المشترك رقم {_PersonID}","حذف",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (SubscribersBLL.Deactive(_PersonID))
                        {
                            MessageBox.Show("تم تعطيل المشترك بتجاح");
                        }else
                        {
                            MessageBox.Show("تعذر تعطيل المشترك");
                        }
                    }

                    LoadSubscribersToGrid();
                    return;
                }
            }
        }
        private void dgvSubsInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSubsInfo.ClearSelection();
            dgvSubsInfo.CurrentCell = null;
        }


        private async void frmSubscribers_Info_Load(object sender, EventArgs e)
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
        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
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

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                case "Is Paid":
                    FilterColumn = "IsPaid";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtSubscribers.DefaultView.RowFilter = "";
                lblRecord.Text = dgvSubsInfo.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "IsActive" || FilterColumn == "IsPaid")
            {
                if (tbSearch.Text.Trim().ToLower() == "true" || tbSearch.Text.Trim() == "1")
                    _dtSubscribers.DefaultView.RowFilter = $"{FilterColumn} = true";
                else if (tbSearch.Text.Trim().ToLower() == "false" || tbSearch.Text.Trim() == "0")
                    _dtSubscribers.DefaultView.RowFilter = $"{FilterColumn} = false";
                else
                    _dtSubscribers.DefaultView.RowFilter = ""; // تجاهل لو قيمة غلط
            }
            else
            {
                // باقي الأعمدة
                _dtSubscribers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }

            lblRecord.Text = dgvSubsInfo.Rows.Count.ToString();
        }

    }
}
