using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGS.Pagine
{
    public partial class UCPaginaEditRicettaCam : UserControl
    {

        private Class.AppManager appManager = null;
        private string idFormato = null;
        private DataType.Impostazioni impostazioni = null;
        private DataType.ImpostazioniCamera impostazioniCamera = null;

        private int idCamera = -1;
        private int numTest = -1;
        private bool isFirst = false;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private Algoritmi.AlgoritmoGMM algoritmoGMMTappeto = null;
        private Algoritmi.AlgoritmoGMM algoritmoGMMColore_1 = null;
        private Algoritmi.AlgoritmoGMM algoritmoGMMColore_2 = null;
        private Algoritmi.AlgoritmoGMM algoritmoGMMColore2 = null;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaEditRicettaCam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, int idCamera, int numTest, bool isFirst, Utilities.SimpleDirtyTracker simpleDirtyTracker, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
            this.idCamera = idCamera;
            this.numTest = numTest;
            this.isFirst = isFirst;

            switch (idCamera)
            {
                case 0:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera1;
                    break;
                case 1:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera2;
                    break;
                case 2:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera3;
                    break;
                case 3:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera4;
                    break;
                case 4:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera5;
                    break;
                case 5:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera6;
                    break;
            }

            string fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", string.Format("ImgPosCam{0}.jpg", idCamera + 1));
            if (System.IO.File.Exists(fileName))
            {
                pictureBox1.BackgroundImage = new Bitmap(fileName);
            }

            //fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", "BeltDir.jpg");
            //if (System.IO.File.Exists(fileName))
            //{
            //    pictureBox2.BackgroundImage = new Bitmap(fileName);
            //}

            int cnt = 1;

            ucEditExpoGain1.Init(cnt++, appManager, idCamera, numTest, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);

            // TOP
            ucEditCentraggio1.Init(cnt++, appManager, idCamera, numTest, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock); 
            ucEditAlgCam1_Foto1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam1_Foto2.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam2_Foto1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam3_Foto1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam3_Foto2.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam4_Foto1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam5_Foto1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgCam5_Foto2.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);

            ucEditExpoGain1.OnComplete += Uc_OnComplete;
            ucEditCentraggio1.OnComplete += Uc_OnComplete;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            ucEditExpoGain1.Translate(linguaManager);
            // TOP
            ucEditCentraggio1.Translate(linguaManager); 
            ucEditAlgCam1_Foto1.Translate(linguaManager);
            ucEditAlgCam1_Foto2.Translate(linguaManager);
        }

        public void CaricaRicetta(string idFormato)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                this.idFormato = idFormato;

                this.algoritmoWizard?.Dispose();
                int idStazione = this.appManager.GetIdStazione();
                this.algoritmoWizard = new Algoritmi.AlgoritmoWizard(this.idCamera, idStazione, this.impostazioni, this.linguaManager);

                HideAllControls();

                DataType.ParametriAlgoritmo parametri = DBL.FormatoManager.ReadParametriAlgoritmo(idFormato, this.idCamera, this.numTest);
                if (parametri == null)
                    parametri = new DataType.ParametriAlgoritmo();

                System.Diagnostics.Debug.WriteLine(string.Format("  - 1 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                this.algoritmoWizard.LoadFiles(idFormato);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 2 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                this.algoritmoWizard.SetAlgoritmoParam(parametri);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 3 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                this.algoritmoGMMTappeto?.Dispose();
                this.algoritmoGMMTappeto = new Algoritmi.AlgoritmoGMM(idCamera, idStazione, 0.000001, impostazioni, this.linguaManager);

                this.algoritmoGMMColore_1?.Dispose();
                this.algoritmoGMMColore_1 = new Algoritmi.AlgoritmoGMM(idCamera, idStazione, 0.0001, impostazioni, this.linguaManager);

                this.algoritmoGMMColore_2?.Dispose();
                this.algoritmoGMMColore_2 = new Algoritmi.AlgoritmoGMM(idCamera, idStazione, 0.0001, impostazioni, this.linguaManager);

                this.algoritmoGMMColore2?.Dispose();
                this.algoritmoGMMColore2 = new Algoritmi.AlgoritmoGMM(idCamera, idStazione, 0.000001, impostazioni, this.linguaManager);

                ucEditExpoGain1.SetAlgoritmo(idFormato, this.algoritmoWizard, this.algoritmoGMMTappeto);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 4 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                // TOP
                ucEditCentraggio1.SetAlgoritmo(this.algoritmoWizard); 
                ucEditAlgCam1_Foto1.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam1_Foto2.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam2_Foto1.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam3_Foto1.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam3_Foto2.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam4_Foto1.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam5_Foto1.SetAlgoritmo(this.algoritmoWizard);
                ucEditAlgCam5_Foto2.SetAlgoritmo(this.algoritmoWizard);


                // ------------------------------------------------------
                if (parametri.Template != null)
                {
                    ucEditExpoGain1.Visible = true;

                    if (this.impostazioniCamera.TipoCamera == DataType.TipoCamera.Camera)
                    {
                        ucEditCentraggio1.Visible = true;

                        if (impostazioniCamera.IdStazione == 0)
                        {
                            if (numTest == 1)
                                ucEditAlgCam1_Foto1.Visible = true;
                            if (numTest == 2)
                                ucEditAlgCam1_Foto2.Visible = true;

                        }
                        if (impostazioniCamera.IdStazione == 1)
                            ucEditAlgCam2_Foto1.Visible = true;

                        if (impostazioniCamera.IdStazione == 2)
                        {
                            if (numTest == 1)
                                ucEditAlgCam3_Foto1.Visible = true;
                            if (numTest == 2)
                                ucEditAlgCam3_Foto2.Visible = true;

                        }

                        if (impostazioniCamera.IdStazione == 3)
                            ucEditAlgCam4_Foto1.Visible = true;

                        if (impostazioniCamera.IdStazione == 4)
                        {
                            if (numTest == 1)
                                ucEditAlgCam5_Foto1.Visible = true;
                            if (numTest == 2)
                                ucEditAlgCam5_Foto2.Visible = true;

                        }
                    }


                    SetDimGrigliaControlli();
                }
                System.Diagnostics.Debug.WriteLine(string.Format("  - 5 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void HideAllControls()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.Visible = false;
            }
        }

        private void SetDimGrigliaControlli()
        {
            int cnt = 0;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.Visible)
                    cnt++;
            }

            tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, (cnt * 70) + 5);
        }

        public void Salva()
        {
            try
            {
                DBL.FormatoManager.WriteParametriAlgoritmo(this.idFormato, this.idCamera, this.numTest, this.algoritmoWizard.GetAlgoritmoParam());
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void Uc_OnComplete(object sender, EventArgs e)
        {
            try
            {
                if (sender != ucEditCentraggio1) ucEditCentraggio1.CheckForComplete(); 
                if (sender != ucEditAlgCam1_Foto1) ucEditAlgCam1_Foto1.CheckForComplete();
                if (sender != ucEditAlgCam1_Foto2) ucEditAlgCam1_Foto2.CheckForComplete();
                if (sender != ucEditAlgCam2_Foto1) ucEditAlgCam2_Foto1.CheckForComplete();
                if (sender != ucEditAlgCam3_Foto1) ucEditAlgCam3_Foto1.CheckForComplete();
                if (sender != ucEditAlgCam3_Foto2) ucEditAlgCam3_Foto2.CheckForComplete();
                if (sender != ucEditAlgCam4_Foto1) ucEditAlgCam4_Foto1.CheckForComplete();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}