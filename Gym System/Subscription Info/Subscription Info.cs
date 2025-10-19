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

namespace Gym_System.Subscription_Info
{
    public partial class frmSubscription_Info : Form
    {
        public enum enSubscriptionMode { Add = 1, Update = 2 }
        private enSubscriptionMode _mode = enSubscriptionMode.Add;

        private byte _SubscriptionID = 0;
        private SubscriptionInfo _subscription;
        private SubsicriptionInfoBLL _subscriptionBLL;

        static DataTable _dtAllSubscriptions = SubsicriptionInfoBLL.GetAllSubsicriptionInfo();
        DataTable _dtSubscriptions;

        public frmSubscription_Info(byte subscriptionID = 0)
        {
            InitializeComponent();
            _SubscriptionID = subscriptionID;

            _mode = _SubscriptionID == 0 ? enSubscriptionMode.Add : enSubscriptionMode.Update;

            _dtSubscriptions = _dtAllSubscriptions.DefaultView.ToTable(false,
                "SubTimeID", "StartTime", "EndTime", "DepartmentName", "Fees", "MinAge", "SubscriptionDuration");
        }
        private void LoadSubscriptionToGrid()
        {
            DataTable dt = SubsicriptionInfoBLL.GetAllSubsicriptionInfo();
            dgvSupscriptionInfo.DataSource = dt;
        }
        private async void frmSubscription_Info_Load(object sender, EventArgs e)
        {
            await _LoadData();
            if (_mode == enSubscriptionMode.Update)
            {
                _subscription = SubsicriptionInfoBLL.Find(_SubscriptionID);
                if (_subscription != null)
                    FillPanelData(_subscription);
                _subscriptionBLL = new SubsicriptionInfoBLL(_subscription);
            }
        }

        private async Task _LoadData()
        {
            dgvSupscriptionInfo.DataSource = _dtSubscriptions;

            cbFilter.SelectedIndex = 0;

            dgvSupscriptionInfo.CellFormatting += (s, e) =>
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "Full Time";
                    e.FormattingApplied = true;
                }
            };

            dgvSupscriptionInfo.AutoGenerateColumns = false;
            dgvSupscriptionInfo.AllowUserToAddRows = false;
            dgvSupscriptionInfo.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvSupscriptionInfo.MultiSelect = false;
            dgvSupscriptionInfo.RowHeadersVisible = false;
            dgvSupscriptionInfo.EnableHeadersVisualStyles = false;
            dgvSupscriptionInfo.AllowUserToResizeColumns = false;
            dgvSupscriptionInfo.AllowUserToResizeRows = false;

            dgvSupscriptionInfo.Columns.Clear();

            // إنشاء الأعمدة من DataTable
            foreach (DataColumn col in _dtSubscriptions.Columns)
            {
                dgvSupscriptionInfo.Columns.Add(new DataGridViewTextBoxColumn()
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
                Width = 150,
                Resizable = DataGridViewTriState.False
            };
            dgvSupscriptionInfo.Columns.Add(editBtn);

            // ضبط Widths كما في القديم
            if (dgvSupscriptionInfo.Columns.Contains("SubTimeID")) dgvSupscriptionInfo.Columns["SubTimeID"].Width = 200;
            if (dgvSupscriptionInfo.Columns.Contains("StartTime")) dgvSupscriptionInfo.Columns["StartTime"].Width = 200;
            if (dgvSupscriptionInfo.Columns.Contains("EndTime")) dgvSupscriptionInfo.Columns["EndTime"].Width = 200;
            if (dgvSupscriptionInfo.Columns.Contains("DepartmentName")) dgvSupscriptionInfo.Columns["DepartmentName"].Width = 230;
            if (dgvSupscriptionInfo.Columns.Contains("Fees")) dgvSupscriptionInfo.Columns["Fees"].Width = 200;
            if (dgvSupscriptionInfo.Columns.Contains("MinAge")) dgvSupscriptionInfo.Columns["MinAge"].Width = 200;
            if (dgvSupscriptionInfo.Columns.Contains("SubscriptionDuration")) dgvSupscriptionInfo.Columns["SubscriptionDuration"].Width = 250;

            // حجم الصفوف والهيدر
            dgvSupscriptionInfo.RowTemplate.Height = 45;
            dgvSupscriptionInfo.ColumnHeadersHeight = 40;
            dgvSupscriptionInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ألوان صفوف متبادلة
            dgvSupscriptionInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSupscriptionInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // تصميم خطوط الهيدر
            dgvSupscriptionInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSupscriptionInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dgvSupscriptionInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // تصميم خطوط الصفوف
            dgvSupscriptionInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            lblRecord.Text = dgvSupscriptionInfo.Rows.Count.ToString();

            dgvSupscriptionInfo.CellClick -= dgvSubscriptionInfo_CellClick;
            dgvSupscriptionInfo.CellClick += dgvSubscriptionInfo_CellClick;
        }
        private void dgvSubscriptionInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSupscriptionInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var row = dgvSupscriptionInfo.Rows[e.RowIndex];
                _SubscriptionID = Convert.ToByte(row.Cells["SubTimeID"].Value);
                _subscription = SubsicriptionInfoBLL.Find(_SubscriptionID);
                if (_subscription != null)
                {
                    FillPanelData(_subscription);
                    _subscriptionBLL = new SubsicriptionInfoBLL(_subscription);
                    pnlSubscriptionInfoEdit.Visible = true;
                    _mode = enSubscriptionMode.Update;
                }
            }
        }
        private void dgvSupscriptionInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSupscriptionInfo.ClearSelection();
            dgvSupscriptionInfo.CurrentCell = null;
        }


        private void FillPanelData(SubscriptionInfo sub)
        {
            tbstartTime.Text = sub.StartTime?.ToString() ?? "";
            tbendTime.Text = sub.EndTime?.ToString() ?? "";
            tbDepartmentName.Text = sub.DepartmentName;
            tbFees.Text = sub.Fees.ToString();
            tbMinAge.Text = sub.MinAge.ToString();
            tbSubscriptionDuration.Text = sub.SubscriptionDuration.ToString();
        }
        private void MovePanelDataToObject()
        {
            if (_subscription == null)
                _subscription = new SubscriptionInfo();

            TimeSpan tmp;
            _subscription.StartTime = TimeSpan.TryParse(tbstartTime.Text, out tmp) ? tmp : (TimeSpan?)null;
            _subscription.EndTime = TimeSpan.TryParse(tbendTime.Text, out tmp) ? tmp : (TimeSpan?)null;
            _subscription.DepartmentName = tbDepartmentName.Text;
            _subscription.Fees = decimal.TryParse(tbFees.Text, out decimal fee) ? fee : 0;
            _subscription.MinAge = byte.TryParse(tbMinAge.Text, out byte minAge) ? minAge : (byte)0;
            _subscription.SubscriptionDuration = byte.TryParse(tbSubscriptionDuration.Text, out byte duration) ? duration : (byte)0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateRequiredFields(this, errorProvider1)) return;

            MovePanelDataToObject();

            if (_subscriptionBLL == null)
                _subscriptionBLL = new SubsicriptionInfoBLL(_subscription);

            bool result = _subscriptionBLL.Save();
            MessageBox.Show(result
                ? (_mode == enSubscriptionMode.Add ? "تم إضافة الاشتراك بنجاح" : "تم تعديل الاشتراك بنجاح")
                : (_mode == enSubscriptionMode.Add ? "تعذر إضافة الاشتراك" : "تعذر تعديل الاشتراك"));

            LoadSubscriptionToGrid();
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
                        errorProvider.SetError(rtb, string.Empty);
                }
                else if (ctrl.HasChildren)
                    if (!ValidateRequiredFields(ctrl, errorProvider))
                        allValid = false;
            }
            return allValid;
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
            string filterColumn = "";
            switch (cbFilter.Text)
            {
                case "SubTime ID": filterColumn = "SubTimeID"; break;
                case "Fees": filterColumn = "Fees"; break;
                case "Department Name": filterColumn = "DepartmentName"; break;
                case "Min Age": filterColumn = "MinAge"; break;
                default: filterColumn = "None"; break;
            }

            if (tbSearch.Text.Trim() == "" || filterColumn == "None")
            {
                _dtSubscriptions.DefaultView.RowFilter = "";
                lblRecord.Text = dgvSupscriptionInfo.Rows.Count.ToString();
                return;
            }
            if (filterColumn == "SubTimeID" || filterColumn == "Fees")
                //in this case we deal with integer not string.
                try
                {
                    _dtSubscriptions.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, tbSearch.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("لا يمكن كتابة احرف");
                }

            else
                _dtSubscriptions.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, tbSearch.Text.Trim());

            lblRecord.Text = dgvSupscriptionInfo.Rows.Count.ToString();
        }

    }
}
