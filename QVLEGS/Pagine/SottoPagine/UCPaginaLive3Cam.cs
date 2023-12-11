using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaLive3Cam : UserControl, IUCPaginaLive
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera2 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera3 = null;

        public UCPaginaLive3Cam()
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

            this.hWndCtrlManagerCamera3 = new Utilities.HWndCtrlManager(panelCamera3, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera3.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 1).ToString());
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 2).ToString());
            lblCam3.Text = linguaManager.GetTranslation("BTN_CAM_" + (this.idStazione * 3 + 3).ToString());
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
                    hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[1], result[1]);
                    hWndCtrlManagerCamera3.DisplaySetupOutputCamera(iconicVarList[2], result[2]);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}