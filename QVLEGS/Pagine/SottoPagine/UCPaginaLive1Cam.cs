using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaLive1Cam : UserControl, IUCPaginaLive
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera1 = null;

        public UCPaginaLive1Cam()
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
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {

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
                    //if (useDisplay)
                    //{
                    this.hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                    //lblTempi.Text = result.DescrizioneTempi;
                    //}
                    //else
                    //{
                    //    Utilities.CommonUtility.ClearArrayList(iconicVarList);
                    //}
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}