﻿using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaOnLine5Cam : UserControl, IUCPaginaOnLine
    {

        private Class.AppManager appManager = null;
        private int idStazione = -1;
        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera1 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera2 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera3 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera4 = null;
        private Utilities.HWndCtrlManager hWndCtrlManagerCamera5 = null;

        private UCPaginaOnLine.ShowMode showMode = UCPaginaOnLine.ShowMode.Show1_N;
        private int cnt = 0;

        public UCPaginaOnLine5Cam()
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

            this.hWndCtrlManagerCamera3 = new Utilities.HWndCtrlManager(panelCamera3, false, false, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera3.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

            this.hWndCtrlManagerCamera4 = new Utilities.HWndCtrlManager(panelCamera4, false, false, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera4.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);

            this.hWndCtrlManagerCamera5 = new Utilities.HWndCtrlManager(panelCamera5, false, false, impostazioni, repaintLock);
            this.hWndCtrlManagerCamera5.SetDraw(false, Utilities.UCHWndCtrlManager.ToolType.None);
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
            lblCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            lblCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            lblCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");
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
                        hWndCtrlManagerCamera1.DisplaySetupOutputCamera(iconicVarList[0], result[0]);
                        hWndCtrlManagerCamera2.DisplaySetupOutputCamera(iconicVarList[1], result[1]);
                        hWndCtrlManagerCamera3.DisplaySetupOutputCamera(iconicVarList[2], result[2]);
                        hWndCtrlManagerCamera4.DisplaySetupOutputCamera(iconicVarList[3], result[3]);
                        hWndCtrlManagerCamera5.DisplaySetupOutputCamera(iconicVarList[4], result[4]);
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