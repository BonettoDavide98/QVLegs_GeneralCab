using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QVLEGS
{
    public partial class UCCheckbox : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler CheckboxClicked;

        private bool _checked;
        public UCCheckbox()
        {
            InitializeComponent();
        }

        [Category("Qualivision Property")]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (value)
                    picBox.Image = QVLEGS.Properties.Resources.AcceptLime512x512;
                else picBox.Image = null;
                _checked = value;
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            this.Checked = !_checked;
            CheckboxClicked?.Invoke(this, e);
        }
    }
}
