using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ParametriAlgoritmo : IDisposable
    {

        [Browsable(false)]
        public string IdFormato { get; set; }

        [Browsable(false)]
        public string TemplateName { get; set; }
        [Browsable(false)]
        public TemplateFormato Template { get; set; }


        [Browsable(false)]
        public bool WizardAcqCompleto { get; set; }

        [Browsable(false)]
        public double Expo { get; set; }
        [Browsable(false)]
        public double Gain { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public HalconDotNet.HImage ImageRef { get; set; }
        [Browsable(false)]
        public PrevImageData PrevImageDataRef { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ImageRef")]
        public byte[] ImageRefSerialized
        {
            get
            {
                // serialize
                if (this.ImageRef == null)
                    return null;
                else
                    return this.ImageRef.SerializeImage();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.ImageRef = null;
                }
                else
                {
                    try
                    {
                        this.ImageRef = new HalconDotNet.HImage();
                        this.ImageRef.DeserializeImage(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false)]
        public Rectangle1Param RoiMain { get; set; }

        [Browsable(false)]
        public double AltezzaRoiSfondo { get; set; }
        [Browsable(false)]
        public double ThresholdSegmentazione { get; set; }
        [Browsable(false)]
        public int RigheVaschettaSegmentazione { get; set; }
        [Browsable(false)]
        public int ColonneVaschettaSegmentazione { get; set; }
        [Browsable(false)]
        public double AreaMinSegmentazione { get; set; }
        [Browsable(false)]
        public double AreaMaxSegmentazione { get; set; }

        [Browsable(false)]
        public int ThresholdMinBiscotto { get; set; }
        [Browsable(false)]
        public int ThresholdMaxBiscotto { get; set; }
        [Browsable(false)]
        public double DimensioneFiltroCioccolato { get; set; }
        [Browsable(false)]
        public double DistanzaBordo { get; set; }
        [Browsable(false)]
        public double AreaMinCioccolato { get; set; }


        // ALTA
        [Browsable(false)]
        public AllineamentoParam AllineamentoParam { get; set; }
        [Browsable(false)]
        public IntegritaParam IntegritaParam { get; set; }
        [Browsable(false)]
        public Cam1_Foto1Param Cam1_Foto1Param { get; set; }
        [Browsable(false)]
        public Cam1_Foto2Param Cam1_Foto2Param { get; set; }
        [Browsable(false)]
        public Cam2_Foto1Param Cam2_Foto1Param { get; set; }
        [Browsable(false)]
        public Cam3_Foto1Param Cam3_Foto1Param { get; set; }
        [Browsable(false)]
        public Cam3_Foto2Param Cam3_Foto2Param { get; set; }
        [Browsable(false)]
        public Cam4_Foto1Param Cam4_Foto1Param { get; set; }
        [Browsable(false)]
        public Cam5_Foto1Param Cam5_Foto1Param { get; set; }
        [Browsable(false)]
        public Cam5_Foto2Param Cam5_Foto2Param { get; set; }


        public ParametriAlgoritmo()
        {
            this.Expo = 1000;
            this.Gain = 1;

            this.RigheVaschettaSegmentazione = 1;
            this.ColonneVaschettaSegmentazione = 1;
            this.ThresholdSegmentazione = 128;
            this.AreaMinSegmentazione = 70000;
            this.AreaMaxSegmentazione = 2000000;

            this.ThresholdMinBiscotto = 40;
            this.ThresholdMaxBiscotto = 255;
            this.DimensioneFiltroCioccolato = 20;
            this.AreaMinCioccolato = 1;

            this.RoiMain = new Rectangle1Param();

            this.AllineamentoParam = new AllineamentoParam();
            this.IntegritaParam = new IntegritaParam();
            this.Cam1_Foto1Param = new Cam1_Foto1Param();
            this.Cam1_Foto2Param = new Cam1_Foto2Param();
            this.Cam2_Foto1Param = new Cam2_Foto1Param();
            this.Cam3_Foto1Param = new Cam3_Foto1Param();
            this.Cam3_Foto2Param = new Cam3_Foto2Param();
            this.Cam4_Foto1Param = new Cam4_Foto1Param();
            this.Cam5_Foto1Param = new Cam5_Foto1Param();
            this.Cam5_Foto2Param = new Cam5_Foto2Param();
        }

        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).

                    this.ImageRef?.Dispose();
                    this.ImageRef = null;

                    // ALTA
                    this.AllineamentoParam?.Dispose();
                    this.AllineamentoParam = null;

                    this.IntegritaParam?.Dispose();
                    this.IntegritaParam = null;

                    this.Cam1_Foto1Param?.Dispose();
                    this.Cam1_Foto1Param = null;

                    this.Cam1_Foto2Param?.Dispose();
                    this.Cam1_Foto2Param = null;

                    this.Cam2_Foto1Param?.Dispose();
                    this.Cam2_Foto1Param = null;

                    this.Cam3_Foto1Param?.Dispose();
                    this.Cam3_Foto1Param = null;

                    this.Cam3_Foto2Param?.Dispose();
                    this.Cam3_Foto2Param = null;

                    this.Cam4_Foto1Param?.Dispose();
                    this.Cam4_Foto1Param = null;

                    this.Cam5_Foto1Param?.Dispose();
                    this.Cam5_Foto1Param = null;

                    this.Cam5_Foto2Param?.Dispose();
                    this.Cam5_Foto2Param = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ParametriAlgoritmo()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}