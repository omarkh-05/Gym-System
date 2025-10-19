using BussinessLayer;
using Entities;
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

namespace Gym_System.Presence
{
    public partial class frmSubscribersPresence : Form
    {
        public frmSubscribersPresence()
        {
            InitializeComponent();
        }

       static public DataTable _GetAllCheckinPresence = CheckinPresenceBLL.GetAllCheckinRegister();
       static public DataTable _GetAllCheckoutPresence = CheckinPresenceBLL.GetAllCheckoutRegister();

        DataTable _GetCheckin = _GetAllCheckinPresence.DefaultView.ToTable(false,"PresenceID", "PersonID","PresenceTime","EnterID");
       DataTable _GetCheckout = _GetAllCheckoutPresence.DefaultView.ToTable(false, "CheckoutPersenceID", "PersonID", "CheckoutTime", "EnterID");

        public void LoadPresenceToGrid()
        {
            DataTable dt = CheckinPresenceBLL.GetAllCheckinRegister();
            dgvCheckinPresence.DataSource = dt;
        }
        public void LoadCheckoutPresenceToGrid()
        {
            DataTable dt = CheckinPresenceBLL.GetAllCheckoutRegister();
            dgvCheckoutPresence.DataSource = dt;
        }

        private async Task _LoadData()
        {
            dgvCheckinPresence.DataSource = _GetCheckin;
            dgvCheckoutPresence.DataSource = _GetCheckout;
            cbFilter.SelectedIndex = 0;

            dgvCheckinPresence.AutoGenerateColumns = false;
            dgvCheckinPresence.AllowUserToAddRows = false;
            dgvCheckinPresence.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCheckinPresence.MultiSelect = false;
            dgvCheckinPresence.RowHeadersVisible = false;
            dgvCheckinPresence.EnableHeadersVisualStyles = false;
            dgvCheckinPresence.AllowUserToResizeColumns = false;
            dgvCheckinPresence.AllowUserToResizeRows = false;

            dgvCheckinPresence.Columns.Clear();

            dgvCheckoutPresence.AutoGenerateColumns = false;
            dgvCheckoutPresence.AllowUserToAddRows = false;
            dgvCheckoutPresence.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCheckoutPresence.MultiSelect = false;
            dgvCheckoutPresence.RowHeadersVisible = false;
            dgvCheckoutPresence.EnableHeadersVisualStyles = false;
            dgvCheckoutPresence.AllowUserToResizeColumns = false;
            dgvCheckoutPresence.AllowUserToResizeRows = false;

            dgvCheckoutPresence.Columns.Clear();

            // إنشاء الأعمدة النصية
            foreach (DataColumn col in _GetCheckin.Columns)
            {
                dgvCheckinPresence.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }
            AddButtonColumn("Show", "🔍", 100);


            foreach (DataColumn col in _GetCheckout.Columns)
            {
                dgvCheckoutPresence.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }
            AddCheckoutButtonColumn("Show", "🔍", 100);

            // ضبط عرض الأعمدة
            SetPresenceColumnWidths();
            SetCheckoutPresenceColumnWidths();
            // حجم الصفوف والهيدر
            dgvCheckinPresence.RowTemplate.Height = 45;
            dgvCheckinPresence.ColumnHeadersHeight = 40;
            dgvCheckinPresence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvCheckoutPresence.RowTemplate.Height = 45;
            dgvCheckoutPresence.ColumnHeadersHeight = 40;
            dgvCheckoutPresence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // ألوان صفوف متبادلة
            dgvCheckinPresence.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCheckinPresence.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvCheckoutPresence.RowsDefaultCellStyle.BackColor = Color.White;
            dgvCheckoutPresence.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم خطوط الهيدر
            dgvCheckinPresence.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
           dgvCheckinPresence.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvCheckinPresence.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dgvCheckoutPresence.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvCheckoutPresence.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvCheckoutPresence.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            // تصميم خطوط الصفوف
            dgvCheckinPresence.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvCheckoutPresence.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecord.Text = dgvCheckinPresence.Rows.Count.ToString();
            lblRecordCheckout.Text = dgvCheckoutPresence.Rows.Count.ToString();

            dgvCheckinPresence.CellClick -= dgvCheckinPresence_CellClick;
            dgvCheckinPresence.CellClick += dgvCheckinPresence_CellClick;

            dgvCheckoutPresence.CellClick -= dgvCheckoutPresence_CellClick;
            dgvCheckoutPresence.CellClick += dgvCheckoutPresence_CellClick;
        }
        private void AddButtonColumn(string header, string text, int width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                Resizable = DataGridViewTriState.False
            };
            dgvCheckinPresence.Columns.Add(btn);
        }
        private void SetPresenceColumnWidths()
        {
            if (dgvCheckinPresence.Columns.Contains("PresenceID")) dgvCheckinPresence.Columns["PresenceID"].Width = 150;
            if (dgvCheckinPresence.Columns.Contains("PersonID")) dgvCheckinPresence.Columns["PersonID"].Width = 150;
            if (dgvCheckinPresence.Columns.Contains("PresenceTime")) dgvCheckinPresence.Columns["PresenceTime"].Width = 150;
            if (dgvCheckinPresence.Columns.Contains("EnterID")) dgvCheckinPresence.Columns["EnterID"].Width = 150;
        }
        private void dgvCheckinPresence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCheckinPresence.Rows[e.RowIndex];

            if (dgvCheckinPresence.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvCheckinPresence.Columns[e.ColumnIndex].HeaderText;
                int PresenceID = Convert.ToInt32(dgvCheckinPresence.CurrentRow.Cells["PresenceID"].Value);
                int personID = Convert.ToInt32(dgvCheckinPresence.CurrentRow.Cells["PersonID"].Value);
                if (header == "Show")
                {
                    PersonInfoControl.LoadPersonData(personID);
                    LoadPresenceToGrid();
                }
            }
        }
        private void dgvCheckinPresence_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCheckinPresence.ClearSelection();
            dgvCheckinPresence.CurrentCell = null;
        }




        private async void frmSubscribersPresence_Load(object sender, EventArgs e)
        {
            await _LoadData();
            LoadPresenceToGrid();
            LoadCheckoutPresenceToGrid();
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
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "EnterID":
                    FilterColumn = "EnterID";
                    break;

                case "Checkout Time":
                    FilterColumn = "CheckoutTime";
                    break;

                case "Checkin Time":
                    FilterColumn = "PresenceTime";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _GetCheckin.DefaultView.RowFilter = "";
                _GetCheckout.DefaultView.RowFilter = "";
                lblRecord.Text = dgvCheckinPresence.Rows.Count.ToString();
                lblRecordCheckout.Text = dgvCheckoutPresence.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "PresenceID")
            {
                // تأكد أن القيمة المدخلة رقم
                if (int.TryParse(tbSearch.Text.Trim(), out int numericValue))
                {
                    _GetCheckin.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, numericValue);
                    _GetCheckout.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, numericValue);
                }
                else
                    _GetCheckin.DefaultView.RowFilter = "";
                  _GetCheckout.DefaultView.RowFilter = ""; // إذا مش رقم رجّع كل النتائج
            }
            else if (FilterColumn == "PresenceTime") // فلترة حسب التاريخ/الوقت
            {
                // نحوله إلى نص ونستخدم LIKE عليه
                _GetCheckin.DefaultView.RowFilter = string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }
            else if(FilterColumn == "CheckoutTime")
            {
                _GetCheckout.DefaultView.RowFilter = string.Format("CONVERT([{0}], System.String) LIKE '%{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }
            else
            {
                _GetCheckin.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
                _GetCheckout.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim().Replace("'", "''"));
            }

            lblRecord.Text = dgvCheckinPresence.Rows.Count.ToString();
            lblRecordCheckout.Text = dgvCheckoutPresence.Rows.Count.ToString();
        }




        private void dgvCheckoutPresence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCheckoutPresence.Rows[e.RowIndex];

            if (dgvCheckoutPresence.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string header = dgvCheckoutPresence.Columns[e.ColumnIndex].HeaderText;
                int personID = Convert.ToInt32(dgvCheckoutPresence.CurrentRow.Cells["PersonID"].Value);
                if (header == "Show")
                {
                    PersonInfoControl.LoadPersonData(personID);
                    LoadPresenceToGrid();
                }
            }
        }
        private void dgvCheckoutPresence_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCheckoutPresence.ClearSelection();
            dgvCheckoutPresence.CurrentCell = null;
        }
        private void AddCheckoutButtonColumn(string header, string text, int width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width,
                Resizable = DataGridViewTriState.False
            };
            dgvCheckoutPresence.Columns.Add(btn);
        }
        private void SetCheckoutPresenceColumnWidths()
        {
            if (dgvCheckoutPresence.Columns.Contains("CheckoutPersenceID")) dgvCheckoutPresence.Columns["CheckoutPersenceID"].Width = 200;
            if (dgvCheckoutPresence.Columns.Contains("PersonID")) dgvCheckoutPresence.Columns["PersonID"].Width = 150;
            if (dgvCheckoutPresence.Columns.Contains("CheckoutTime")) dgvCheckoutPresence.Columns["CheckoutTime"].Width = 150;
            if (dgvCheckoutPresence.Columns.Contains("EnterID")) dgvCheckoutPresence.Columns["EnterID"].Width = 150;
        }
    }
}
