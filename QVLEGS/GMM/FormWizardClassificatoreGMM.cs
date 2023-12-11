using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGS
{
    public partial class FormWizardClassificatoreGMM : Form
    {

        private const int ROI_CLASSIFICATORE = 1000;


        #region Variabili Private

        private Class.AppManager appManager = null;
        private Class.CoreRegolazioni setupCore = null;
        private Algoritmi.AlgoritmoGMM algoritmo = null;
        private ViewROI.HWndCtrl mViewCamera = null;
        private ViewROI.ROIController roiController = null;
        private DBL.LinguaManager linguaMngr = null;
        private object repaintLock = null;
        private object imgLockCamera = new object();
        private HalconDotNet.HImage imageCamera = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;

        private int imageWidth = 0;
        private int imageHeight = 0;

        private int currentState = 0;
        private List<string> nomiDifetti = new List<string>();
        private List<string> toClear = new List<string>();
        private List<HalconDotNet.HImage> imgGrabbate = new List<HalconDotNet.HImage>();
        private int idxImageToShow = -1;

        private bool wizardOk = false;

        private ViewROI.ROIRectangle1Cross roi1ROIRectangle = null;
        private HalconDotNet.HRegion roi = null;

        #endregion Variabili Private

        public FormWizardClassificatoreGMM(Class.AppManager appManager, Class.CoreRegolazioni setupCore, Algoritmi.AlgoritmoGMM algoritmo, int imageWidth, int imageHeight, DBL.LinguaManager linguaMngr, object repaintLock)
        {
            InitializeComponent();

            this.appManager = appManager;
            this.setupCore = setupCore;
            this.algoritmo = algoritmo;

            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;

            this.linguaMngr = linguaMngr;

            this.repaintLock = repaintLock;

            mViewCamera = new ViewROI.HWndCtrl(hMainWndCntrlCamera1);
            roiController = new ViewROI.ROIController();
            mViewCamera.useROIController(roiController);
            mViewCamera.NotifyIconObserver = new ViewROI.IconicDelegate(UpdateViewData);
            roiController.NotifyRCObserver = new ViewROI.IconicDelegate(UpdateViewData);

            this.setupCore.SetAlgorithm(algoritmo.TestWizard);

            this.setupCore.SetNewImageToDisplayEvent(DisplaySetupOutputCamera);

            string[] descrizioni = this.algoritmo.GetDescrizioniCalssificatore();
            if (descrizioni != null)
            {
                foreach (var item in descrizioni)
                {
                    dgvDifetti.Rows.Add(item);
                }
            }

            btnStartAcq.Visible = false;
            btnStopAcq.Visible = false;
            btnFotoNext.Visible = false;
            btnFotoPrev.Visible = false;
            btnTerminaTrain.Visible = false;
            lblNomeDifetto.Visible = false;
            cmbNomeDifetto.Visible = false;
            lblNumFoto.Visible = false;

            btnAggiungiRiga.Text = linguaMngr.GetTranslation("LBL_BTN_ADD_ROW");
            btnEliminaRiga.Text = linguaMngr.GetTranslation("LBL_BTN_DELETE_ROW");
            btnPulisciRiga.Text = linguaMngr.GetTranslation("LBL_BTN_CLEAR_ROW");
            btnStartAcq.Text = linguaMngr.GetTranslation("LBL_BTN_START_ACQ");
            btnStopAcq.Text = linguaMngr.GetTranslation("LBL_BTN_STOP_ACQ");
            btnFotoNext.Text = linguaMngr.GetTranslation("LBL_BTN_FOTO_NEXT");
            btnFotoPrev.Text = linguaMngr.GetTranslation("LBL_BTN_FOTO_PREV");
            btnConferma.Text = linguaMngr.GetTranslation("LBL_BTN_CONFERMA");
            btnTerminaTrain.Text = linguaMngr.GetTranslation("LBL_BTN_TERMINA");
            lblIstruzioni.Text = linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_0");
            dgvDifetti.Columns[0].HeaderText = linguaMngr.GetTranslation("LBL_NOME_DIFETTO");
            lblNomeDifetto.Text = linguaMngr.GetTranslation("LBL_NOME_DIFETTO");

            this.simpleDirtyTracker = new Utilities.SimpleDirtyTracker(this.Controls);
            this.simpleDirtyTracker.SetAsClean();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            try
            {
                if (wizardOk)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            finally
            {
                if (imgGrabbate != null)
                {
                    for (int i = 0; i < imgGrabbate.Count; i++)
                    {
                        imgGrabbate[i]?.Dispose();
                    }
                }

                imageCamera?.Dispose();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this.simpleDirtyTracker.IsDirty && wizardOk == false)
            {
                DialogResult res = MessageBox.Show(linguaMngr.GetTranslation("MSG_WIZARD_CHIUDERE"), linguaMngr.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void GoToState(int state)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { GoToState(state); }));
            }
            else
            {
                this.currentState = state;
                switch (state)
                {
                    case 1:
                        btnConferma.Enabled = true;
                        lblIstruzioni.Text = this.linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_1");
                        break;
                    case 2:
                        btnFotoNext.Visible = true;
                        btnFotoPrev.Visible = true;
                        btnConferma.Visible = true;
                        btnStartAcq.Visible = false;
                        btnStopAcq.Visible = false;
                        btnTerminaTrain.Visible = true;
                        lblNomeDifetto.Visible = true;
                        cmbNomeDifetto.Visible = true;
                        //cmbNomeDifetto.SelectedIndex = -1;
                        lblNumFoto.Visible = true;
                        lblIstruzioni.Text = this.linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_2");
                        break;
                    case 3:
                        btnFotoNext.Visible = false;
                        btnFotoPrev.Visible = false;
                        btnConferma.Visible = false;
                        btnTerminaTrain.Visible = true;
                        lblNomeDifetto.Visible = false;
                        cmbNomeDifetto.Visible = false;
                        lblIstruzioni.Text = this.linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_3");
                        break;
                    case 4:
                        btnFotoNext.Visible = false;
                        btnFotoPrev.Visible = false;
                        btnConferma.Visible = false;
                        btnTerminaTrain.Visible = true;
                        btnStartAcq.Visible = true;
                        btnStopAcq.Visible = true;
                        btnAggiungiRiga.Visible = false;
                        btnEliminaRiga.Visible = false;
                        btnPulisciRiga.Visible = false;
                        lblIstruzioni.Text = this.linguaMngr.GetTranslation("LBL_ISTRUZIONI_STEP_4");
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplaySetupOutputCamera(int numCamera, ArrayList iconicVarList, DataType.ElaborateResult result)
        {
            try
            {
                lock (imgLockCamera)
                {
                    if (imageCamera != null) imageCamera.Dispose();

                    if (iconicVarList.Count > 0)
                    {
                        Utilities.ObjectToDisplay obj = (Utilities.ObjectToDisplay)iconicVarList[0];
                        HalconDotNet.HImage image = (HalconDotNet.HImage)(obj.IconicVar);
                        imageCamera = image.CopyImage();

                        if (this.currentState == 4)
                        {
                            HalconDotNet.HImage imageTmp = imageCamera.CopyImage();
                            this.imgGrabbate.Add(imageTmp);
                        }
                    }
                }

                this.BeginInvoke(new Action(() =>
                {
                    if (this.currentState == 4)
                        btnStopAcq.Enabled = true;
                }));

                /*
                this.Invoke(new Action(() =>
                {
                    this.setupCore.StopAndWaitEnd(true);
                    GoToState(1);

                    this.roiController.reset();
                    double delta = 50;
                    double midRow = this.imageHeight / 2;
                    double midColumn = this.imageWidth / 4;
                    double row1 = midRow - delta;
                    double column1 = midColumn - delta;
                    double row2 = midRow + delta;
                    double column2 = midColumn + delta;

                    ViewROI.ROIRectangle1 roi1 = new ViewROI.ROIRectangle1();
                    roi1.setOperatorFlag(ViewROI.ROIController.MODE_ROI_NONE);
                    roi1.createROI(midRow, midColumn);
                    roi1.setRoiId(ROI_CLASSIFICATORE);
                    roi1.setModelData(new HalconDotNet.HTuple(row1, column1, row2, column2));

                    midColumn *= 3;
                    row1 = midRow - delta;
                    column1 = midColumn - delta;
                    row2 = midRow + delta;
                    column2 = midColumn + delta;

                    ViewROI.ROIRectangle1 roi2 = new ViewROI.ROIRectangle1();
                    roi2.setOperatorFlag(ViewROI.ROIController.MODE_ROI_NONE);
                    roi2.createROI(midRow, midColumn);
                    roi2.setRoiId(ROI_CLASSIFICATORE);
                    roi2.setModelData(new HalconDotNet.HTuple(row1, column1, row2, column2));

                    roiController.ROIList.Add(roi1);
                    roiController.ROIList.Add(roi2);

                    roiController.setActiveROIIdx(0);
                }));
                */

                Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mViewCamera, hMainWndCntrlCamera1, this.repaintLock);
                Utilities.CommonUtility.DisplayResult(result, hMainWndCntrlCamera1, this.repaintLock);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void UpdateViewData(int val)
        {
            HalconDotNet.HImage image = null;
            try
            {
                if (roiController.getActiveROI() != null)
                {
                    lock (imgLockCamera)
                    {
                        image = imageCamera.CopyImage();
                    }
                    if (image != null)
                    {
                        int id = roiController.getActiveROI().getRoiId();

                        switch (val)
                        {
                            case ViewROI.ROIController.EVENT_CREATED_ROI:
                            case ViewROI.ROIController.EVENT_CHANGED_ROI_SIGN:
                            case ViewROI.ROIController.EVENT_DELETED_ACTROI:
                            case ViewROI.ROIController.EVENT_DELETED_ALL_ROIS:
                            case ViewROI.ROIController.EVENT_ACTIVATED_ROI:
                            case ViewROI.ROIController.EVENT_DEACTIVATED_ROI:
                            case ViewROI.ROIController.EVENT_MOVING_ROI:

                                DisplayModelGraphics(image, mViewCamera);
                                this.simpleDirtyTracker.SetAsDirty();

                                break;

                            case ViewROI.ROIController.EVENT_UPDATE_ROI:

                                HalconDotNet.HTuple roiData = roiController.getActiveROI().getModelData();

                                if (id == ROI_CLASSIFICATORE)
                                {
                                    if (this.roi != null)
                                        this.roi.Dispose();
                                    this.roi = TrovaRegion(image, roiData);
                                }

                                ArrayList iconicVarList = new ArrayList();
                                iconicVarList.Add(new Utilities.ObjectToDisplay(image.Clone()));
                                if (this.roi != null)
                                    iconicVarList.Add(new Utilities.ObjectToDisplay(this.roi.Clone(), ColorHexConverter(Color.Magenta, 180), 2) { DrawMode = "fill" });

                                Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mViewCamera, hMainWndCntrlCamera1, this.repaintLock);

                                this.simpleDirtyTracker.SetAsDirty();

                                break;

                            case ViewROI.HWndCtrl.ERR_READING_IMG:
                                MessageBox.Show("Problem occured while reading file! \n" + mViewCamera.exceptionText, "Matching assistant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                if (image != null) image.Dispose();
            }
        }

        private void DisplayModelGraphics(HalconDotNet.HImage image, ViewROI.HWndCtrl mView)
        {
            lock (repaintLock)
            {
                mView.clearList();
                mView.changeGraphicSettings(ViewROI.GraphicsContext.GC_LINESTYLE, new HalconDotNet.HTuple());
                if (image != null)
                {
                    mView.addIconicVar(image);
                }
                mView.repaint();

                lock (imgLockCamera)
                {
                    if (imageCamera != null) imageCamera.Dispose();
                    imageCamera = image.CopyImage();
                }
            }
        }

        private HalconDotNet.HImage GetNextImageToShow()
        {
            idxImageToShow++;
            if (idxImageToShow >= imgGrabbate.Count)
                idxImageToShow = imgGrabbate.Count - 1;

            return imgGrabbate[idxImageToShow].Clone();
        }

        private HalconDotNet.HImage GetPrevImageToShow()
        {
            idxImageToShow--;
            if (idxImageToShow < 0)
                idxImageToShow = 0;

            return imgGrabbate[idxImageToShow].Clone();
        }

        private void AggiornaLblNumFoto()
        {
            lblNumFoto.Text = string.Format("{0}/{1}", idxImageToShow + 1, imgGrabbate.Count);
        }

        private HalconDotNet.HRegion TrovaRegion(HalconDotNet.HImage image, HalconDotNet.HTuple roiData)
        {
            HalconDotNet.HRegion r = null;
            HalconDotNet.HRegion regHSV = null;
            try
            {
                double row1 = roiData[0];
                double column1 = roiData[1];
                double row2 = roiData[2];
                double column2 = roiData[3];

                double rc = row1 + (row2 - row1) / 2.0;
                double cc = column1 + (column2 - column1) / 2.0;

                double dimRect = 1;

                r = new HalconDotNet.HRegion();
                r.GenRectangle1(rc - dimRect, cc - dimRect, rc + dimRect, cc + dimRect);

                //regHSV = TrovaRegionHSV(image, r);
                return TrovaRegionCalssificatore(image, r);
            }
            finally
            {
                r?.Dispose();
                regHSV?.Dispose();
            }
        }

        #region Eventi Form

        private void dgvDifetti_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDifetti.Rows[e.RowIndex].Selected = true;
            }

            if (dgvDifetti.Rows[e.RowIndex].IsNewRow == true)
            {
                Utilities.KeyBoardOsk.showKeypad((sender as Control).Handle);
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Utilities.KeyBoardOsk.showKeypad((sender as Control).Handle);
        }

        private void btnAggiungiRiga_Click(object sender, EventArgs e)
        {
            try
            {
                FormStringInput frm = new FormStringInput(string.Empty, 0, false);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string newRow = frm.Testo;

                    List<string> tmpNomi = new List<string>();
                    foreach (DataGridViewRow item in dgvDifetti.Rows)
                    {
                        if (item.IsNewRow == false)
                        {
                            string descrizione = ((string)item.Cells[0].Value).Trim();
                            if (!string.IsNullOrWhiteSpace(descrizione))
                            {
                                tmpNomi.Add(descrizione);
                            }
                        }
                    }

                    if (tmpNomi.Select(k => k.ToUpper()).Contains(newRow.ToUpper()))
                    {
                        MessageBox.Show(linguaMngr.GetTranslation("MSG_STRINGA_PRESENTE"), linguaMngr.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        dgvDifetti.Rows.Add(newRow);
                        dgvDifetti.Rows[dgvDifetti.Rows.Count - 1].Selected = true;
                        dgvDifetti.CurrentCell = dgvDifetti.Rows[dgvDifetti.Rows.Count - 1].Cells[0];

                        this.simpleDirtyTracker.SetAsDirty();
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnEliminaRiga_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDifetti.SelectedRows.Count > 0 && dgvDifetti.Rows[dgvDifetti.SelectedRows[0].Index].IsNewRow == false)
                {
                    if (MessageBox.Show(linguaMngr.GetTranslation("MSG_ELIMINA_DIFETTO"), linguaMngr.GetTranslation("MSG_ELIMINARE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dgvDifetti.Rows.RemoveAt(dgvDifetti.SelectedRows[0].Index);
                        this.simpleDirtyTracker.SetAsDirty();
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnPulisciRiga_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDifetti.SelectedRows.Count > 0 && dgvDifetti.Rows[dgvDifetti.SelectedRows[0].Index].IsNewRow == false)
                {
                    if (MessageBox.Show(linguaMngr.GetTranslation("MSG_PULIRE_DIFETTO"), linguaMngr.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.toClear.Add((string)dgvDifetti.SelectedRows[0].Cells[0].Value);
                        this.simpleDirtyTracker.SetAsDirty();
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnFotoNext_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                image = GetNextImageToShow();
                if (image != null)
                {
                    GoToState(2);
                    DisplayModelGraphics(image, mViewCamera);

                    HalconDotNet.HTuple roiData = this.roi1ROIRectangle.getModelData();
                    this.roi = TrovaRegion(image, roiData);

                    ArrayList iconicVarList = new ArrayList();
                    iconicVarList.Add(new Utilities.ObjectToDisplay(image.Clone()));
                    if (this.roi != null)
                        iconicVarList.Add(new Utilities.ObjectToDisplay(this.roi.Clone(), ColorHexConverter(Color.Magenta, 180), 2) { DrawMode = "fill" });

                    Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mViewCamera, hMainWndCntrlCamera1, this.repaintLock);
                }
                AggiornaLblNumFoto();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
        }

        private void btnFotoPrev_Click(object sender, EventArgs e)
        {
            HalconDotNet.HImage image = null;
            try
            {
                image = GetPrevImageToShow();
                if (image != null)
                {
                    GoToState(2);
                    DisplayModelGraphics(image, mViewCamera);

                    HalconDotNet.HTuple roiData = this.roi1ROIRectangle.getModelData();
                    this.roi = TrovaRegion(image, roiData);

                    ArrayList iconicVarList = new ArrayList();
                    iconicVarList.Add(new Utilities.ObjectToDisplay(image.Clone()));
                    if (this.roi != null)
                        iconicVarList.Add(new Utilities.ObjectToDisplay(this.roi.Clone(), ColorHexConverter(Color.Magenta, 180), 2) { DrawMode = "fill" });

                    Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mViewCamera, hMainWndCntrlCamera1, this.repaintLock);
                }
                AggiornaLblNumFoto();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
            finally
            {
                image?.Dispose();
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.currentState == 0)
                {
                    dgvDifetti.Visible = false;
                    btnFotoNext.Visible = true;
                    btnFotoPrev.Visible = true;
                    //btnConferma.Enabled = false;

                    foreach (DataGridViewRow item in dgvDifetti.Rows)
                    {
                        if (item.IsNewRow == false)
                        {
                            string descrizione = ((string)item.Cells[0].Value).Trim();
                            if (!string.IsNullOrWhiteSpace(descrizione))
                            {
                                this.nomiDifetti.Add(descrizione);
                                cmbNomeDifetto.Items.Add(descrizione);
                            }
                        }
                    }

                    this.algoritmo.InitCalssificatore(this.nomiDifetti.Count, new HalconDotNet.HTuple(0), this.nomiDifetti, toClear);
                }
                else if (this.currentState == 2)
                {
                    HalconDotNet.HImage image = null;

                    lock (imgLockCamera)
                    {
                        image = imageCamera.CopyImage();
                    }

                    if (image != null)
                    {
                        if (this.roi == null)
                        {
                            MessageBox.Show(this.linguaMngr.GetTranslation("MSG_MOVE_RECT_SELEZIONATORE"), this.linguaMngr.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            bool error = false;

                            ArrayList lRoi = roiController.getROIList();
                            HalconDotNet.HRegion roi = this.roi;

                            string nome = cmbNomeDifetto.Text;
                            if (!string.IsNullOrWhiteSpace(nome))
                            {

                                if (MessageBox.Show(string.Format(this.linguaMngr.GetTranslation("MSG_CONFERMA_ADD_CLASSIFICATORE"), nome), this.linguaMngr.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    this.algoritmo.AddClassificatore(nome, image, roi);
                                    this.simpleDirtyTracker.SetAsDirty();
                                }
                                else
                                    error = true;
                            }
                            else
                            {
                                MessageBox.Show(this.linguaMngr.GetTranslation("MSG_NO_DIFETTO_SELEZIONATO"), this.linguaMngr.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                error = true;
                            }

                            //this.currentIdx++;

                            image.Dispose();
                            roi.Dispose();

                            if (error)
                            {
                                return;
                            }
                        }
                    }
                }

                if (this.currentState == 0)
                {
                    GoToState(4);
                }
                else
                {
                    HalconDotNet.HImage image = GetNextImageToShow();
                    if (image != null)
                    {
                        GoToState(2);
                        DisplayModelGraphics(image, mViewCamera);

                        HalconDotNet.HTuple roiData1 = this.roi1ROIRectangle.getModelData();
                        this.roi = TrovaRegion(image, roiData1);

                        ArrayList iconicVarList = new ArrayList();
                        iconicVarList.Add(new Utilities.ObjectToDisplay(image.Clone()));
                        if (this.roi != null)
                            iconicVarList.Add(new Utilities.ObjectToDisplay(this.roi.Clone(), ColorHexConverter(Color.Magenta, 180), 2) { DrawMode = "fill" });

                        Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mViewCamera, hMainWndCntrlCamera1, this.repaintLock);
                    }
                    AggiornaLblNumFoto();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnStartAcq_Click(object sender, EventArgs e)
        {
            try
            {
                setupCore.Run();
                btnStartAcq.Enabled = false;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnStopAcq_Click(object sender, EventArgs e)
        {
            try
            {
                setupCore.StopAndWaitEnd(true);

                GoToState(2);

                this.Invoke(new Action(() =>
                {
                    //this.setupCore.StopAndWaitEnd(true);
                    //GoToState(1);

                    this.roiController.reset();
                    double delta = 10;
                    double midRow = this.imageHeight / 2;
                    double midColumn = this.imageWidth / 2;
                    double row1 = midRow - delta;
                    double column1 = midColumn - delta;
                    double row2 = midRow + delta;
                    double column2 = midColumn + delta;

                    this.roi1ROIRectangle = new ViewROI.ROIRectangle1Cross();
                    this.roi1ROIRectangle.setOperatorFlag(ViewROI.ROIController.MODE_ROI_NONE);
                    this.roi1ROIRectangle.createROI(midRow, midColumn);
                    this.roi1ROIRectangle.setRoiId(ROI_CLASSIFICATORE);
                    this.roi1ROIRectangle.setModelData(new HalconDotNet.HTuple(row1, column1, row2, column2));


                    roiController.ROIList.Add(this.roi1ROIRectangle);

                    roiController.setActiveROIIdx(0);
                }));

                HalconDotNet.HImage image = GetNextImageToShow();
                DisplayModelGraphics(image, mViewCamera);

                AggiornaLblNumFoto();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnTerminaTrain_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = this.algoritmo.TrainClassificatore();

                if (!ok)
                {
                    MessageBox.Show(this.linguaMngr.GetTranslation("MSG_ERRORE_TRAINING_WIZARD"), this.linguaMngr.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    wizardOk = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            this.appManager?.Snap();
        }

        #endregion Eventi Form

        //private HalconDotNet.HRegion TrovaRegionHSV(HalconDotNet.HImage image, HalconDotNet.HRegion region)
        //{
        //    HalconDotNet.HImage imgR = null;
        //    HalconDotNet.HImage imgG = null;
        //    HalconDotNet.HImage imgB = null;
        //    HalconDotNet.HImage imgH = null;
        //    HalconDotNet.HImage imgS = null;
        //    HalconDotNet.HImage imgV = null;


        //    HalconDotNet.HRegion classRegions = null;

        //    try
        //    {
        //        imgR = image.Decompose3(out imgG, out imgB);
        //        imgH = imgR.TransFromRgb(imgG, imgB, out imgS, out imgV, "hsv");

        //        classRegions = imgH.Threshold(140.0, 170.0);
        //    }
        //    finally
        //    {
        //        imgR?.Dispose();
        //        imgG?.Dispose();
        //        imgB?.Dispose();
        //        imgH?.Dispose();
        //        imgS?.Dispose();
        //        imgV?.Dispose();
        //    }

        //    return classRegions;
        //}

        private HalconDotNet.HRegion TrovaRegionCalssificatore(HalconDotNet.HImage image, HalconDotNet.HRegion region)
        {
            HalconDotNet.HClassGmm GMMHandle = null;
            HalconDotNet.HClassLUT classLUTHandle = null;
            HalconDotNet.HImage imageReduced = null;
            HalconDotNet.HRegion classRegions = null;
            try
            {
                GMMHandle = new HalconDotNet.HClassGmm(3, 1, 1, "full", "none", 3, 42);
                GMMHandle.AddSamplesImageClassGmm(image, region, 0.0);

                HalconDotNet.HTuple iter;
                GMMHandle.TrainClassGmm(100, 0.001, "training", 0.001, out iter);
                HalconDotNet.HTuple genParamNameClassLUT = new HalconDotNet.HTuple("rejection_threshold");
                HalconDotNet.HTuple genParamValueClassLUT = new HalconDotNet.HTuple(0.000001/*0.00001*/);
                classLUTHandle = new HalconDotNet.HClassLUT(GMMHandle, genParamNameClassLUT, genParamValueClassLUT);

                imageReduced = image.ReduceDomain(region);

                classRegions = classLUTHandle.ClassifyImageClassLut(image);
            }
            finally
            {
                GMMHandle?.Dispose();
                classLUTHandle?.Dispose();
                imageReduced?.Dispose();
            }

            return classRegions;
        }

        private string ColorHexConverter(Color c, int alpha)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2") + alpha.ToString("X2");
        }

    }
}