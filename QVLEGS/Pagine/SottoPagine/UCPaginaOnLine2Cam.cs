using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaOnLine2Cam : UserControl, IUCPaginaOnLine
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera2 = null;

        private UCPaginaOnLine.ShowMode showMode = UCPaginaOnLine.ShowMode.Show1_N;
        private int cnt = 0;

        public UCPaginaOnLine2Cam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, int idStazione, DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.appManager = appManager;
            this.idStazione = idStazione;
            this.repaintLock = repaintLock;

            this.hWndCtrlManagerCamera1 = new Utilities.HWndCtrlManager(panelCamera1, false, false, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera1.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

            this.hWndCtrlManagerCamera2 = new Utilities.HWndCtrlManager(panelCamera2, false, false, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera2.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);
            this.hWndCtrlManagerCamera2.SetFeedbackIconVisible();
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

        public void SetShowMode(UCPaginaOnLine.ShowMode showMode)
        {
            this.showMode = showMode;
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
                    bool show = false;

                    //if (this.showMode == ShowMode.ShowBad && result.Count(k => k == null || k.Success == false) > 0)
                    if (this.showMode == UCPaginaOnLine.ShowMode.ShowBad && result.Count(k => k != null && k.Success == false) > 0)
                        show = true;
                    else if (this.showMode == UCPaginaOnLine.ShowMode.Show1_N && ++cnt >= 1)
                    {
                        cnt = 0;
                        show = true;
                    }

                    if (show)
                    {
                        if (numTest == 1)
                            hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                        else
                            hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    }
                    else
                    {
                        for (int i = 0; i < iconicVarList.Length; i++)
                            Utilities.CommonUtility.ClearArrayList(iconicVarList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}