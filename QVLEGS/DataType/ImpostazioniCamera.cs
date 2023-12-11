using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ImpostazioniCamera
    {

        public TipoCamera TipoCamera { get; set; }

        public string IpCamera { get; set; }
        public string PathImmaginiDaCamera { get; set; }

        public double FiltroMinArea { get; set; }
        public double KConvPX_mm { get; set; }

        public double KConvPX_mm_W { get; set; }
        public double KConvPX_mm_H { get; set; }

        public double ScaleWidth { get; set; }
        public double ScaleHeight { get; set; }

        public int IdStazione { get; set; }
        public bool Attiva { get; set; }

        //public double AreaMinSegmentazione { get; set; }
        //public double AreaMaxSegmentazione { get; set; }
        public double ThresholdMaxSfondo { get; set; }

        public ImpostazioniCamera()
        {
            this.TipoCamera = TipoCamera.Camera;

            this.FiltroMinArea = 200;
            this.KConvPX_mm = 1;

            this.KConvPX_mm_W = 1;
            this.KConvPX_mm_H = 1;

            this.ScaleWidth = 1.0;
            this.ScaleHeight = 1.0;

            //this.AreaMinSegmentazione = 70000;
            //this.AreaMaxSegmentazione = 2000000;
            this.ThresholdMaxSfondo = 45;

            this.Attiva = true;
        }

    }
}