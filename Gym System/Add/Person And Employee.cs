using BussinessLayer;
using Entities;
using Gym_System.Employees;
using Gym_System.Subscribers;
using Gym_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Gym_System.Add.frmPerson_And_Employee;


namespace Gym_System.Add
{
    public partial class frmPerson_And_Employee : Form
    {

        public enum enMode { AddNew = 1, Update = 2 };
         enMode _Mode = enMode.AddNew;
        public enum enPerson { Employee = 1, Subscriber = 2 }
        enPerson _Person = enPerson.Employee;


        private int _SubscriberID = -1;
        Subscriber _subscriber;
        SubscribersBLL _SubscribersBLL;


        private int _EmployeeID = -1;
        Employee _employee;
        EmployeeBLL _EmployeeBLL;


        public frmPerson_And_Employee(int personID,string PersonType)
        {
            InitializeComponent();
            if (PersonType == "Subscriber" )
            _Person = enPerson.Subscriber;
            else
                _Person = enPerson.Employee;

            if (_Person == enPerson.Subscriber)
            {
                _SubscriberID = personID;
                _Mode = (_SubscriberID == -1) ? enMode.AddNew : enMode.Update;
                rbSubs.Checked = true;
            }
            else
            {
                _EmployeeID = personID;
                _Mode = (_EmployeeID == -1) ? enMode.AddNew : enMode.Update;
                rbEmp.Checked = true;
            }
        }
        private void _SubPageLoadSettings()
        {
            cbCountry.SelectedIndex = 83;
            cbPersonType.SelectedIndex = 0;
            cbPlanSub.SelectedIndex = 0;
            cbDepartment.SelectedIndex = 0;

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-17);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-90);
            dtpSubDate.MinDate = DateTime.Now;
            dtpSubDate.MaxDate = DateTime.Now.AddDays(10);

            cbEmpRank.SelectedIndex = 0;
            cbEmployeeType.SelectedIndex = 0;
            
        }

        //            we use asynk task not async void 3shan 1- get data from db 2- to use await in aother function (asyncronuns) if we use task.Run() (multithreading)
        private async Task _FillCountriesComboBox()
        {
            DataTable dt = CountriesBLL.GetAllNationalities();
            cbCountry.BeginUpdate();
            foreach (DataRow row in dt.Rows)
                cbCountry.Items.Add(row["NationalityName"]);
            cbCountry.EndUpdate();
        }

        private async Task _FillDepartmentComboBox()
        {
            DataTable dt = DepartmentBLL.GetAllDepartments();
            cbDepartment.BeginUpdate();
            foreach (DataRow row in dt.Rows)
                cbDepartment.Items.Add(row["DepartmentName"]);
            cbDepartment.EndUpdate();
        }

        private async Task _FillSubInfoComboBox()
        {
            DataTable dt = SubInfoBLL.GetAllSubscriptions();
            cbPlanSub.BeginUpdate();
            foreach (DataRow row in dt.Rows)
                cbPlanSub.Items.Add(row["DepartmentName"]);
            cbPlanSub.EndUpdate();
        }

        private DateTime? SafeSqlDate(DateTime dt)
        {
            if (dt < (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue ||
                dt > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
                return null;
            return dt;
        }
        private DateTime ClampDate(DateTime dt, DateTime min, DateTime max)
        {
            if (dt < min) return min;
            if (dt > max) return max;
            return dt;
        }
        private async Task _LoadData()
        {
            if (UserSession.UserID != 1)
            {
                rbEmp.Enabled = false;
            }

            await _FillCountriesComboBox();
            await _FillDepartmentComboBox();
            await _FillSubInfoComboBox();

            _SubPageLoadSettings();

            if (_Person == enPerson.Subscriber)
            {
                if (_Mode == enMode.AddNew)
                {
                    _subscriber = new Subscriber();
                    _SubscribersBLL = new SubscribersBLL();
                    return;
                }

                _subscriber = SubscribersBLL.Find(_SubscriberID);

                if (_subscriber == null)
                {
                    MessageBox.Show($"لا يوجد مشترك برقم {_SubscriberID}");
                    this.Close();
                    return;
                }

                _SubscribersBLL = new SubscribersBLL(_subscriber);

                // تعبئة بيانات المشترك
                cbPersonType.Text = _subscriber.PersonType;
                tbName.Text = _subscriber.Name;
                dtpDateOfBirth.Value = ClampDate(_subscriber.DateOfBirth ?? DateTime.Now, dtpDateOfBirth.MinDate, dtpDateOfBirth.MaxDate);
                dtpSubDate.Value = ClampDate(_subscriber.SubDate ?? DateTime.Now, dtpSubDate.MinDate, dtpSubDate.MaxDate);
                dtpEndDate.Value = ClampDate(_subscriber.EndDate ?? DateTime.Now, dtpEndDate.MinDate, dtpEndDate.MaxDate);
                tbNationalNo.Text = _subscriber.NationalNo;
                tbAddress.Text = _subscriber.Address;
                tbPhoneNo.Text = _subscriber.PhoneNo;
                cbCountry.SelectedIndex = cbCountry.FindString(CountriesBLL.Find(_subscriber.NationalityID).NationalityName);

                rbMale.Checked = _subscriber.Gender == "Male";
                rbFemale.Checked = _subscriber.Gender != "Male";

                rbPaid1.Checked = _subscriber.IsPaid;
                rbPaid0.Checked = !_subscriber.IsPaid;

                rbDisease1.Checked = _subscriber.HasDisease;
                rbDisease0.Checked = !_subscriber.HasDisease;

                cbDepartment.SelectedIndex = cbDepartment.FindString(DepartmentBLL.Find(_subscriber.DepartmentID).DepartmentName);
                cbPlanSub.SelectedIndex = cbPlanSub.FindString(SubInfoBLL.Find(_subscriber.SubscriptionInfo).DepartmentName);
                tbID.Text = _subscriber.EnterID;
            }
            else if (_Person == enPerson.Employee)
            {
                if (_Mode == enMode.AddNew)
                {
                     _employee = new Employee();
                    _EmployeeBLL = new EmployeeBLL();  // يستعمل constructor الأول
                    return;
                }

                _employee = EmployeeBLL.Find(_EmployeeID);

                if (_employee == null)
                {
                    MessageBox.Show($"لا يوجد موظف برقم {_EmployeeID}");
                    this.Close();
                    return;
                }

                _EmployeeBLL = new EmployeeBLL(_employee);

                // تعبئة بيانات الموظف
                tbName.Text = _employee.Name;
                tbNationalNo.Text = _employee.NationalNo;
                tbPhoneNo.Text = _employee.PhoneNo;
                tbAddress.Text = _employee.Address;
                tbID.Text = _employee.EnterID;
                cbCountry.SelectedIndex = cbCountry.FindString(CountriesBLL.Find(_employee.NationalityID).NationalityName);
                cbEmployeeType.Text = _employee.EmployeeType;
                cbEmpRank.Text = _employee.EmployeeRank.ToString();

                rbMale.Checked = _employee.Gender == "Male";
                rbFemale.Checked = _employee.Gender != "Male";

                rbDisease1.Checked = _employee.HasDisease;
                rbDisease0.Checked = !_employee.HasDisease;

                rbActive1.Checked = _employee.IsActive;
                rbActive0.Checked = !_employee.IsActive;

                if (_employee.WorkTime == "A")
                    rbWorkTimeA.Checked = true;
                else
                    rbWorkTimeM.Checked = true;

                dtpDateOfBirth.Value = ClampDate(_employee.DateOfBirth ?? DateTime.Now, dtpDateOfBirth.MinDate, dtpDateOfBirth.MaxDate);
                dtpSubDate.Value = ClampDate(_employee.JoinningGymDate, dtpSubDate.MinDate, dtpSubDate.MaxDate);
                dtpEndDate.Value = ClampDate(_employee.EndDurationDate, dtpEndDate.MinDate, dtpEndDate.MaxDate);

                pbImage.ImageLocation = _employee.ImagePath;
            }
        }


        private void MoveSubscriberData()
        {
            if (_subscriber == null)
                _subscriber = new Subscriber();

            _subscriber.NationalNo = tbNationalNo.Text;
            _subscriber.Name = tbName.Text;
            _subscriber.DateOfBirth = SafeSqlDate(dtpDateOfBirth.Value) ?? DateTime.Now;
            _subscriber.Address = tbAddress.Text;
            _subscriber.PhoneNo = tbPhoneNo.Text;
            _subscriber.NationalityID = CountriesBLL.Find(cbCountry.Text).ID;
            _subscriber.Gender = rbMale.Checked ? "Male" : "Female";
            _subscriber.IsPaid = rbPaid1.Checked;
            _subscriber.HasDisease = rbDisease1.Checked;
            _subscriber.PersonType = cbPersonType.Text;
            _subscriber.SubDate = SafeSqlDate(dtpSubDate.Value) ?? DateTime.Now;
            _subscriber.EndDate = SafeSqlDate(dtpEndDate.Value) ?? DateTime.Now;
            _subscriber.EnterID = tbID.Text;
            _subscriber.AddedBy = 1;
            _subscriber.DepartmentID = DepartmentBLL.Find(cbDepartment.Text).DepartmentID;
            _subscriber.SubscriptionInfo = SubInfoBLL.Find(cbPlanSub.Text).SubTimeID;
        }

        private void MoveEmployeeData()
        {
            if (_employee == null)
                _employee = new Employee();

            _employee.NationalNo = tbNationalNo.Text;
            _employee.Name = tbName.Text;
            _employee.DateOfBirth = SafeSqlDate(dtpDateOfBirth.Value) ?? DateTime.Now;
            _employee.Address = tbAddress.Text;
            _employee.PhoneNo = tbPhoneNo.Text;
            _employee.NationalityID = CountriesBLL.Find(cbCountry.Text).ID;
            _employee.Gender = rbMale.Checked ? "Male" : "Female";
            _employee.HasDisease = rbDisease1.Checked;
            _employee.PersonType = cbPersonType.Text;
            _employee.EnterID = tbID.Text;
            _employee.AddedBy = 1;

            // حقول خاصة بالموظف
            _employee.JoinningGymDate = SafeSqlDate(dtpSubDate.Value) ?? DateTime.Now;
            _employee.EndDurationDate = SafeSqlDate(dtpEndDate.Value) ?? DateTime.Now;

            switch (cbEmpRank.SelectedItem?.ToString())
            {
                case "3":
                    _employee.Salary = 300;
                    break;
                case "6":
                    _employee.Salary = 350;
                    break;
                case "12":
                    _employee.Salary = 400;
                    break;
                default:
                    _employee.Salary = 0;
                    break;
            }

            _employee.EmployeeRank = Convert.ToByte(cbEmpRank.SelectedItem);
            _employee.EmployeeType = cbEmployeeType.Text; 
            _employee.IsActive = rbActive1.Checked;
            _employee.WorkTime = rbWorkTimeA.Checked? "A" : "M";
            _employee.ImagePath = pbImage.ImageLocation;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmSubscribers_Info frmSubscriber1s_Info = new frmSubscribers_Info();
            frmaddUser frmAddUser = new frmaddUser(-1);
            frmEmployees frmEmployees = new frmEmployees();

            if (_Person == enPerson.Subscriber)
            {
                if (!ValidateRequiredFields(this, errorProvider1))
                {
                    MessageBox.Show("قم بتعبئة جميع المعلومات");
                    return;
                }

                MoveSubscriberData();
                if (_SubscribersBLL == null)
                {
                    // إذا لم يتم تهيئته، أنشئه الآن
                    _SubscribersBLL = new SubscribersBLL();
                }
                _SubscribersBLL.CurrentSubscriber = _subscriber;

                if (_SubscribersBLL.Save())
                    MessageBox.Show((_Mode == enMode.AddNew ? " تم إضافة " : " تم تعديل ") + $" كمشترك  {_subscriber.Name} ");
                else
                    MessageBox.Show((_Mode == enMode.AddNew ? " تعذر إضافة " : " تعذر تعديل") + $" {_subscriber.Name} ");

                frmSubscriber1s_Info.LoadSubscribersToGrid();
                frmEmployees.LoadEmployeesToGrid();
            }
            else if (_Person == enPerson.Employee)
            {
                MoveEmployeeData();

                if (_EmployeeBLL == null)
                {
                    // إذا لم يتم تهيئته، أنشئه الآن
                    _EmployeeBLL = new EmployeeBLL();
                }
                _EmployeeBLL.Employees = _employee; 

                if (pbImage.Image == null)
                {
                    MessageBox.Show("قم بتعبئة الصورة الشخصية");
                    return;
                }

                if (_EmployeeBLL.Save())
                    MessageBox.Show((_Mode == enMode.AddNew ? "تم إضافة" : "تم تعديل") + $" {_employee.Name} كموظف ");
                else
                    MessageBox.Show((_Mode == enMode.AddNew ? "تعذر إضافة" : "تعذر تعديل") + $" {_employee.Name} ");

                frmAddUser.UpdateDataGrid();
                frmEmployees.LoadEmployeesToGrid(); 
            }

            _Mode = enMode.Update;
        }

        private async void frmPerson_And_Employee_Shown(object sender, EventArgs e)
        {
            gbAddPerson.Enabled = false;
            await _LoadData();
            gbAddPerson.Enabled = true;
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
                        if (allValid) rtb.Focus(); // ركز على أول خطأ
                        allValid = false;
                    }
                }
                else if (ctrl is NumberTextBox ntb)
                {
                    if (!ntb.IsValid())
                    {
                        errorProvider.SetError(ntb, ntb.ErrorMessage);
                        allValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(ntb, string.Empty);
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
    


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPaid1_CheckedChanged(object sender, EventArgs e)
        {
            rbActive1.Checked = true;
        }

        private void rbPaid0_CheckedChanged(object sender, EventArgs e)
        {
            rbActive0.Checked = true;
        }

        private void UpdateEndDate()
        {
            if (cbPlanSub.SelectedItem == null) return; // لا يوجد اختيار

            string selectedPlan = cbPlanSub.SelectedItem.ToString();
            SubInfoBLL subInfo = SubInfoBLL.Find(selectedPlan);

            if (subInfo != null)
            {
                // إضافة مدة الاشتراك (شهور) على تاريخ البداية
                dtpEndDate.Value = dtpSubDate.Value.AddMonths(subInfo.SubscriptionDuration);
            }
        }

        private void cbPlanSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
        }

        private void dtpSubDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
        }

        private void rbEmp_CheckedChanged(object sender, EventArgs e)
        {
            if(rbEmp.Checked)
            _Person = enPerson.Employee;
            else
            _Person = enPerson.Subscriber;

            if (rbEmp.Checked)
                label1.Text = "Add Employee";
            else
                label1.Text = "Add Subscriber";

            pnlEmpinfo.Visible = rbEmp.Checked;

            pnlimg.Visible = rbEmp.Checked;

            if(rbEmp.Checked)
            cbPersonType.SelectedIndex = 1;
            else cbPersonType.SelectedIndex =0;

            cbEmpRank.SelectedIndex = 0;

            cbEmployeeType.SelectedIndex = 0;

            panel2.Enabled = rbEmp.Checked;

            panel3.Enabled = !rbEmp.Checked;

            cbPlanSub.Enabled = !rbEmp.Checked;

            pnlWorkTime.Visible = rbEmp.Checked;

            cbPersonType.Text = "Employee";
        }

        private void lblRemove_Click(object sender, EventArgs e)
        {
            pbImage.ImageLocation = null;
        }

        private void lblSetImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbImage.Load(selectedFilePath);
                // pbPhoto.BackgroundImage = Image.FromFile(selectedFilePath);
                lblRemove.Visible = true;

            }
        }

        private void cbEmpRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmpRank.SelectedItem.ToString() == "3")
            {
                if (rbWorkTimeA.Checked == true)
                    cbPlanSub.SelectedItem = "Gym A 3";
                else
                    cbPlanSub.SelectedItem = "Gym M 3";
            }
            else if (cbEmpRank.SelectedItem.ToString() == "6")
            {
                if (rbWorkTimeA.Checked == true)
                    cbPlanSub.SelectedItem = "Gym A 6";
                else
                    cbPlanSub.SelectedItem = "Gym M 6";
            }
            else
            {if(rbWorkTimeA.Checked == true)
                cbPlanSub.SelectedItem = "Gym A 12";
            else
                    cbPlanSub.SelectedItem = "Gym M 12";
            }
        }

        private void frmPerson_And_Employee_Load(object sender, EventArgs e)
        {

        }
    }
}