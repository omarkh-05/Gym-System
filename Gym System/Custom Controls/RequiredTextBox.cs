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
    public partial class RequiredTextBox : TextBox
    {
        public RequiredTextBox()
        {
            InitializeComponent();
        }

        [Category("Validation")]
        public bool IsRequired { get; set; } = false;

        [Category("Validation")]
        public string ErrorMessage { get; set; } = "Required";

        public bool IsValid()
        {
            if (IsRequired && string.IsNullOrWhiteSpace(this.Text))
            {
                return false;
            }
            return true;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
