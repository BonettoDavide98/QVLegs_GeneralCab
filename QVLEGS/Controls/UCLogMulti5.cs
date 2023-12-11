﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGS
{
    public partial class UCLogMulti5 : UserControl
    {

        public delegate void OnOpenDettaglioDelegate(ArrayList objectTodisplay, DataType.ElaborateResult result);
        public event OnOpenDettaglioDelegate OnOpenDettaglio = null;


        private object repaintLock = null;
        private Utilities.HWndCtrlManager hWndCtrlManager1 = null;
        private Utilities.HWndCtrlManager hWndCtrlManager2 = null;
        private Utilities.HWndCtrlManager hWndCtrlManager3 = null;
        private Utilities.HWndCtrlManager hWndCtrlManager4 = null;
        private Utilities.HWndCtrlManager hWndCtrlManager5 = null;

        private DataType.ElaborateResult[] resultMem = null;
        private int idxSelected = -1;

        private DateTime lastClick = DateTime.MinValue;

        public UCLogMulti5()
        {
            InitializeComponent();

            label1.Text = string.Empty;
        }

        public void Init(DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.repaintLock = repaintLock;

            lblCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            lblCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
            lblCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            lblCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            lblCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");

            this.hWndCtrlManager1 = new Utilities.HWndCtrlManager(panelImage1, false, false, false, impostazioni, repaintLock);
            this.hWndCtrlManager2 = new Utilities.HWndCtrlManager(panelImage2, false, false, false, impostazioni, repaintLock);
            this.hWndCtrlManager3 = new Utilities.HWndCtrlManager(panelImage3, false, false, false, impostazioni, repaintLock);
            this.hWndCtrlManager4 = new Utilities.HWndCtrlManager(panelImage4, false, false, false, impostazioni, repaintLock);
            this.hWndCtrlManager5 = new Utilities.HWndCtrlManager(panelImage5, false, false, false, impostazioni, repaintLock);

            lblRagioneScarto1.Text = string.Empty;
            lblRagioneScarto2.Text = string.Empty;
            lblRagioneScarto3.Text = string.Empty;
            lblRagioneScarto4.Text = string.Empty;
            lblRagioneScarto5.Text = string.Empty;

            //****************************************************************************

            panel1.MouseClick += Control1_MouseClick;
            panel2.MouseClick += Control2_MouseClick;
            panel3.MouseClick += Control3_MouseClick;
            panel4.MouseClick += Control4_MouseClick;
            panel5.MouseClick += Control5_MouseClick;

            panelImage1.MouseClick += Control1_MouseClick;
            panelImage2.MouseClick += Control2_MouseClick;
            panelImage3.MouseClick += Control3_MouseClick;
            panelImage4.MouseClick += Control4_MouseClick;
            panelImage5.MouseClick += Control5_MouseClick;

            this.hWndCtrlManager1.hWindowControl.HMouseDown += HWindowControl1_HMouseDown;
            this.hWndCtrlManager2.hWindowControl.HMouseDown += HWindowControl2_HMouseDown;
            this.hWndCtrlManager3.hWindowControl.HMouseDown += HWindowControl3_HMouseDown;
            this.hWndCtrlManager4.hWindowControl.HMouseDown += HWindowControl4_HMouseDown;
            this.hWndCtrlManager5.hWindowControl.HMouseDown += HWindowControl5_HMouseDown;
        }

        public void SetData(ArrayList[] iconicVarList, DataType.ElaborateResult[] result, DateTime ts)
        {
            groupBox1.Text = ts.ToString("yyyyMMdd HH mm ss.fff");

            this.resultMem = result;

            if (iconicVarList.Length > 0) this.hWndCtrlManager1.DisplaySetupOutputCamera(Utilities.CommonUtility.CloneArrayList(iconicVarList[0]), result[0]);
            if (iconicVarList.Length > 1) this.hWndCtrlManager2.DisplaySetupOutputCamera(Utilities.CommonUtility.CloneArrayList(iconicVarList[1]), result[1]);
            if (iconicVarList.Length > 2) this.hWndCtrlManager3.DisplaySetupOutputCamera(Utilities.CommonUtility.CloneArrayList(iconicVarList[2]), result[2]);
            if (iconicVarList.Length > 3) this.hWndCtrlManager4.DisplaySetupOutputCamera(Utilities.CommonUtility.CloneArrayList(iconicVarList[3]), result[3]);
            if (iconicVarList.Length > 4) this.hWndCtrlManager5.DisplaySetupOutputCamera(Utilities.CommonUtility.CloneArrayList(iconicVarList[4]), result[4]);

            if (iconicVarList.Length > 0) VisualizzaTesti(lblRagioneScarto1, result[0]);
            if (iconicVarList.Length > 1) VisualizzaTesti(lblRagioneScarto2, result[1]);
            if (iconicVarList.Length > 2) VisualizzaTesti(lblRagioneScarto3, result[2]);
            if (iconicVarList.Length > 3) VisualizzaTesti(lblRagioneScarto4, result[3]);
            if (iconicVarList.Length > 4) VisualizzaTesti(lblRagioneScarto5, result[4]);
        }

        private void VisualizzaTesti(Label lbl, DataType.ElaborateResult res)
        {
            try
            {
                lbl.Text = string.Empty;

                if (res != null)
                {
                    for (int i = 0; i < res.TestiRagioneScarto.Count; i++)
                    {
                        lbl.Text += res.TestiRagioneScarto[i] + "\n\r";
                    }

                    lbl.Text += Environment.NewLine;

                    for (int i = 0; i < res.TestiOutAlgoritmi.Count; i++)
                    {
                        if (res.TestiOutAlgoritmi[i].Item2 == "red")
                            lbl.Text += res.TestiOutAlgoritmi[i].Item1 + "\n\r";
                    }
                }
            }
            catch (Exception) { }
        }

        private void DisplaySelected(int idxSelected)
        {
            try
            {
                bool doubleClick = false;
                if (idxSelected == this.idxSelected && DateTime.Now.Subtract(lastClick).TotalMilliseconds < 800)
                {
                    doubleClick = true;
                }

                this.idxSelected = idxSelected;
                this.lastClick = DateTime.Now;

                panel1.BackColor = idxSelected == 1 ? Color.Silver : SystemColors.Control;
                panel2.BackColor = idxSelected == 2 ? Color.Silver : SystemColors.Control;
                panel3.BackColor = idxSelected == 3 ? Color.Silver : SystemColors.Control;
                panel4.BackColor = idxSelected == 4 ? Color.Silver : SystemColors.Control;
                panel5.BackColor = idxSelected == 5 ? Color.Silver : SystemColors.Control;

                VisualizzaTesti(label1, resultMem[idxSelected - 1]);

                if (doubleClick)
                {
                    Ingrandisci();
                }
            }
            catch (Exception) { }
        }

        private Utilities.HWndCtrlManager GetSelected()
        {
            Utilities.HWndCtrlManager ret = null;

            if (this.idxSelected == 1) ret = hWndCtrlManager1;
            else if (this.idxSelected == 2) ret = hWndCtrlManager2;
            else if (this.idxSelected == 3) ret = hWndCtrlManager3;
            else if (this.idxSelected == 4) ret = hWndCtrlManager4;
            else if (this.idxSelected == 5) ret = hWndCtrlManager5;

            return ret;
        }

        private void Ingrandisci()
        {
            try
            {
                Utilities.HWndCtrlManager hWnd = GetSelected();

                if (hWnd != null)
                {
                    hWnd.GetSetupOutputCamera(out ArrayList iconicVarList, out DataType.ElaborateResult result);

                    OnOpenDettaglio?.Invoke(iconicVarList, result);
                }
            }
            catch (Exception) { }
        }

        private void HWindowControl1_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e) { Control1_MouseClick(sender, null); }
        private void HWindowControl2_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e) { Control2_MouseClick(sender, null); }
        private void HWindowControl3_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e) { Control3_MouseClick(sender, null); }
        private void HWindowControl4_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e) { Control4_MouseClick(sender, null); }
        private void HWindowControl5_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e) { Control5_MouseClick(sender, null); }

        private void Control1_MouseClick(object sender, MouseEventArgs e) { DisplaySelected(1); }
        private void Control2_MouseClick(object sender, MouseEventArgs e) { DisplaySelected(2); }
        private void Control3_MouseClick(object sender, MouseEventArgs e) { DisplaySelected(3); }
        private void Control4_MouseClick(object sender, MouseEventArgs e) { DisplaySelected(4); }
        private void Control5_MouseClick(object sender, MouseEventArgs e) { DisplaySelected(5); }


        private void btnImage_Click(object sender, EventArgs e)
        {
            ucTabControl.SelectedTab = tabPageImage;
        }

        private void btnDescrizione_Click(object sender, EventArgs e)
        {
            ucTabControl.SelectedTab = tabPageDescrizione;
        }

        private void btnIngrandisci_Click(object sender, EventArgs e)
        {
            Ingrandisci();
        }

    }
}
