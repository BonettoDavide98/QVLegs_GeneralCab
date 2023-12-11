using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaLive2Cam : UserControl, IUCPaginaLive
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera2 = null;

        public UCPaginaLive2Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.HWndCtrlManager(panelCamera1, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera1.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

            this.hWndCtrlManagerCamera2 = new Utilities.HWndCtrlManager(panelCamera2, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera2.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_FOTO_1");
            lblCam2.Text = linguaManager.GetTranslation("BTN_FOTO_2");
        }

        public void ActivateDisplay()
        {
            appManager.SetNewImageToDisplayEvent(OnNewImage);
        }

        private void OnNewImage(ArrayList[] iconicVarList, DataType.ElaborateResult[] result, int numTest)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => { OnNewImage(iconicVarList, result, numTest); }));
                }
                else
                {
                    if (numTest == 1)
                        hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    else
                        hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}