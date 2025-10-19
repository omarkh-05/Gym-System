using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_System
{
    public partial class NumberTextBox : TextBox
    {
        [Category("Validation")]
        public bool IsRequired { get; set; }

        [Category("Validation")]
        public string ErrorMessage { get; set; } = "This Field Is Required";

        public bool IsValid()
        {
            if (IsRequired && string.IsNullOrWhiteSpace(this.Text))
            {
                return false;
            }
            return true;
        }

        public NumberTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
