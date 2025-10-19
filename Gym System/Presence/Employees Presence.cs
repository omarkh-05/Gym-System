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
    public partial class frmEmployeesPresence : Form
    {
        static public DataTable _GetAllEmployeeCheckinPresence = CheckinPresenceBLL.GetAllEmployeeCheckinRegister();
        static public DataTable _GetAllEmployeeCheckoutPresence = CheckinPresenceBLL.GetAllEmployeeCheckoutRegister();

        DataTable _GetCheckin = _GetAllEmployeeCheckinPresence.DefaultView.ToTable(false, "EmployeePresenceID", "EmployeeID", "PersonID", "PresenceTime", "EnterID");
        DataTable _GetCheckout = _GetAllEmployeeCheckoutPresence.DefaultView.ToTable(false, "EmployeeCheckoutID", "EmployeeID", "PersonID", "CheckoutTime", "EnterID", "Addition");

        public frmEmployeesPresence()
        {
            InitializeComponent();
        }

        public void CheckinLoadData()
        {
            DataTable dt = CheckinPresenceBLL.GetAllEmployeeCheckinRegister();
            dgvEmployeeCheckinPresence.DataSource = dt;
        }
        public void CheckoutLoadData()
        {
            DataTable dt = CheckinPresenceBLL.GetAllEmployeeCheckoutRegister();
            dgvEmployeeCheckoutPresence.DataSource = dt;
        }

        private async Task _LoadData()
        {
            dgvEmployeeCheckinPresence.DataSource = _GetCheckin;
            dgvEmployeeCheckoutPresence.DataSource = _GetCheckout;

            cbFilter.SelectedIndex = 0;

            // إعدادات عامة للـ DataGridViews
            SetupDataGridView(dgvEmployeeCheckinPresence);
            SetupDataGridView(dgvEmployeeCheckoutPresence);

            // مسح الأعمدة السابقة
            dgvEmployeeCheckinPresence.Columns.Clear();
            dgvEmployeeCheckoutPresence.Columns.Clear();

            // إنشاء أعمدة Checkin
            foreach (DataColumn col in _GetCheckin.Columns)
            {
                dgvEmployeeCheckinPresence.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }
            AddButtonColumn(dgvEmployeeCheckinPresence, "Show", "🔍", 100);

            // إنشاء أعمدة Checkout
            foreach (DataColumn col in _GetCheckout.Columns)
            {
                dgvEmployeeCheckoutPresence.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = col.ColumnName,
                    HeaderText = col.ColumnName,
                    DataPropertyName = col.ColumnName,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Resizable = DataGridViewTriState.False
                });
            }
            AddButtonColumn(dgvEmployeeCheckoutPresence, "Show", "🔍", 100);

            // ضبط أعمدة وعرضها
            SetCheckinColumnWidths();
            SetCheckoutColumnWidths();

            // صفوف وHeader
            dgvEmployeeCheckinPresence.RowTemplate.Height = 45;
            dgvEmployeeCheckinPresence.ColumnHeadersHeight = 40;
            dgvEmployeeCheckinPresence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvEmployeeCheckoutPresence.RowTemplate.Height = 45;
            dgvEmployeeCheckoutPresence.ColumnHeadersHeight = 40;
            dgvEmployeeCheckoutPresence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvEmployeeCheckinPresence.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEmployeeCheckinPresence.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvEmployeeCheckoutPresence.RowsDefaultCellStyle.BackColor = Color.White;
            dgvEmployeeCheckoutPresence.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم Header
            dgvEmployeeCheckinPresence.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvEmployeeCheckinPresence.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvEmployeeCheckinPresence.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvEmployeeCheckoutPresence.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvEmployeeCheckoutPresence.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvEmployeeCheckoutPresence.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم الخطوط
            dgvEmployeeCheckinPresence.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvEmployeeCheckoutPresence.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecordCheckin.Text = dgvEmployeeCheckinPresence.Rows.Count.ToString();
            lblRecordCheckout.Text = dgvEmployeeCheckoutPresence.Rows.Count.ToString();

            // CellClick Events
            dgvEmployeeCheckinPresence.CellClick -= dgvEmployeeCheckinPresence_CellClick;
            dgvEmployeeCheckinPresence.CellClick += dgvEmployeeCheckinPresence_CellClick;

            dgvEmployeeCheckoutPresence.CellClick -= dgvEmployeeCheckoutPresence_CellClick;
            dgvEmployeeCheckoutPresence.CellClick += dgvEmployeeCheckoutPresence_CellClick;
        }
        private void SetupDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
        }
        private void AddButtonColumn(DataGridView dgv, string header, string text, int width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                Width = width
            };
            dgv.Columns.Add(btn);
        }
        private void SetCheckinColumnWidths()
        {
            if (dgvEmployeeCheckinPresence.Columns.Contains("EmployeePresenceID")) dgvEmployeeCheckinPresence.Columns["EmployeePresenceID"].Width = 140;
            if (dgvEmployeeCheckinPresence.Columns.Contains("EmployeeID")) dgvEmployeeCheckinPresence.Columns["EmployeeID"].Width = 140;
            if (dgvEmployeeCheckinPresence.Columns.Contains("PersonID")) dgvEmployeeCheckinPresence.Columns["PersonID"].Width = 140;
            if (dgvEmployeeCheckinPresence.Columns.Contains("PresenceTime")) dgvEmployeeCheckinPresence.Columns["PresenceTime"].Width = 140;
            if (dgvEmployeeCheckinPresence.Columns.Contains("EnterID")) dgvEmployeeCheckinPresence.Columns["EnterID"].Width = 140;
        }
        private void SetCheckoutColumnWidths()
        {
            if (dgvEmployeeCheckoutPresence.Columns.Contains("EmployeeCheckoutID")) dgvEmployeeCheckoutPresence.Columns["EmployeeCheckoutID"].Width = 120;
            if (dgvEmployeeCheckoutPresence.Columns.Contains("EmployeeID")) dgvEmployeeCheckoutPresence.Columns["EmployeeID"].Width = 120;
            if (dgvEmployeeCheckoutPresence.Columns.Contains("PersonID")) dgvEmployeeCheckoutPresence.Columns["PersonID"].Width = 110;
            if (dgvEmployeeCheckoutPresence.Columns.Contains("CheckoutTime")) dgvEmployeeCheckoutPresence.Columns["CheckoutTime"].Width = 120;
            if (dgvEmployeeCheckoutPresence.Columns.Contains("EnterID")) dgvEmployeeCheckoutPresence.Columns["EnterID"].Width = 120;
            if (dgvEmployeeCheckoutPresence.Columns.Contains("Addition")) dgvEmployeeCheckoutPresence.Columns["Addition"].Width = 120;
        }
        private void dgvEmployeeCheckinPresence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEmployeeCheckinPresence.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int personID = Convert.ToInt32(dgvEmployeeCheckinPresence.CurrentRow.Cells["PersonID"].Value);
                infoControl1.LoadPersonData(personID);
            }
        }
        private void dgvEmployeeCheckoutPresence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEmployeeCheckoutPresence.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int personID = Convert.ToInt32(dgvEmployeeCheckoutPresence.CurrentRow.Cells["PersonID"].Value);
                infoControl1.LoadPersonData(personID);
            }
        }
        private void dgvEmployeeCheckinPresence_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEmployeeCheckinPresence.ClearSelection();
            dgvEmployeeCheckinPresence.CurrentCell = null;
        }
        private void dgvEmployeeCheckoutPresence_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEmployeeCheckoutPresence.ClearSelection();
            dgvEmployeeCheckoutPresence.CurrentCell = null;
        }


        private async void frmEmployeesPresence_Load(object sender, EventArgs e)
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
                case "EmployeeID": FilterColumn = "EmployeeID"; break;
                case "PersonID": FilterColumn = "PersonID"; break;
                case "EnterID": FilterColumn = "EnterID"; break;
                case "Checkin Time": FilterColumn = "PresenceTime"; break;
                case "Checkout Time": FilterColumn = "CheckoutTime"; break;
                default: FilterColumn = "None"; break;
            }

            if (tbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _GetCheckin.DefaultView.RowFilter = "";
                _GetCheckout.DefaultView.RowFilter = "";
                lblRecordCheckin.Text = dgvEmployeeCheckinPresence.Rows.Count.ToString();
                lblRecordCheckout.Text = dgvEmployeeCheckoutPresence.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "EmployeeID" || FilterColumn == "PersonID")
            {
                if (int.TryParse(tbSearch.Text.Trim(), out int val))
                {
                    _GetCheckin.DefaultView.RowFilter = $"[{FilterColumn}] = {val}";
                    _GetCheckout.DefaultView.RowFilter = $"[{FilterColumn}] = {val}";
                }
                else
                {
                    _GetCheckin.DefaultView.RowFilter = "";
                    _GetCheckout.DefaultView.RowFilter = "";
                }
            }
            else
            {
                _GetCheckin.DefaultView.RowFilter = $"CONVERT([{FilterColumn}], 'System.String') LIKE '%{tbSearch.Text.Trim()}%'";
                _GetCheckout.DefaultView.RowFilter = $"CONVERT([{FilterColumn}], 'System.String') LIKE '%{tbSearch.Text.Trim()}%'";
            }

            lblRecordCheckin.Text = dgvEmployeeCheckinPresence.Rows.Count.ToString();
            lblRecordCheckout.Text = dgvEmployeeCheckoutPresence.Rows.Count.ToString();
        }

       
    }
}
