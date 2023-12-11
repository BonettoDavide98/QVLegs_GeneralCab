using System.Windows.Forms;

namespace QVLEGS
{
    public partial class FormWait : Form
    {
        public FormWait(string msg,DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            label1.Text = linguaManager.GetTranslation(msg);
        }
    }
}
