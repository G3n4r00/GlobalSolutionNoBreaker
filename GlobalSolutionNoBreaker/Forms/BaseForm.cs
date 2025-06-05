using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalSolutionNoBreaker.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            SetStandardProperties();
        }

        private void SetStandardProperties()
        {
            // Set standard size
            this.Size = new Size(960, 680);

            // Set standard starting position
            this.StartPosition = FormStartPosition.CenterScreen;

            // Optional: Set other common properties
            this.MinimumSize = new Size(400, 300);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

        }

        // Override SetVisibleCore to ensure consistent positioning
        protected override void SetVisibleCore(bool value)
        {
            if (value && this.WindowState == FormWindowState.Normal)
            {
                // Ensure form appears in center screen every time
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            base.SetVisibleCore(value);
        }
    }
}
