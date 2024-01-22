using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using HalconDotNet;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam4_Foto1Param : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }


        public CircleParam CircleCenter { get; set; }
        public double ThresholdCircleCenter { get; set; }
        public double AreaMaxCircleCenter { get; set; }

        public Rectangle1Param RectGrayLeft { get; set; }
        public double ThresholdGrayLeft { get; set; }
        public double AreaMinGrayLeft { get; set; }

        public Rectangle1Param RectGrayRight { get; set; }
        public double ThresholdGrayRight { get; set; }
        public double AreaMinGrayRight { get; set; }

        public Rectangle1Param RectBlueLeft { get; set; }
        public double ThresholdBlueLeft { get; set; }
        public double AreaMaxBlueLeft { get; set; }

        public Rectangle1Param RectBlueUp { get; set; }
        public double ThresholdBlueUp { get; set; }
        public double AreaMaxBlueUp { get; set; }

        public Rectangle1Param RectBlueRight { get; set; }
        public double ThresholdBlueRight { get; set; }
        public double AreaMaxBlueRight { get; set; }

        public Rectangle1Param RectYellowRight { get; set; }
        public double ThresholdYellowRight { get; set; }
        public double AreaMaxYellowRight { get; set; }

        public BullEyeParam CircleYellowCenter { get; set; }
        public double ThresholdYellowCenter { get; set; }
        public double AreaMaxYellowCenter { get; set; }

        public CircleParam CircleBlueCenter { get; set; }
        public double ThresholdBlueCenter { get; set; }
        public double AreaMaxBlueCenter { get; set; }

        public Rectangle1Param RectBlueLeft2 { get; set; }
        public double ThresholdBlueLeft2 { get; set; }
        public double AreaMaxBlueLeft2 { get; set; }

        public Rectangle1Param RectBlueLeft3 { get; set; }
        public double ThresholdBlueLeft3 { get; set; }
        public double AreaMaxBlueLeft3 { get; set; }

        public Rectangle1Param RectBlueLeft4 { get; set; }
        public double ThresholdBlueLeft4 { get; set; }
        public double AreaMaxBlueLeft4 { get; set; }

        public Rectangle1Param RectBlueRight2 { get; set; }
        public double ThresholdBlueRight2 { get; set; }
        public double AreaMaxBlueRight2 { get; set; }

        public Rectangle1Param RectYellowRight2 { get; set; }
        public double ThresholdYellowRight2 { get; set; }
        public double AreaMaxYellowRight2 { get; set; }

        public Rectangle1Param RectRedLeft { get; set; }
        public double ThresholdRedLeft { get; set; }
        public double AreaMaxRedLeft { get; set; }

        public Rectangle1Param RectRedRight { get; set; }
        public double ThresholdRedRight { get; set; }
        public double AreaMaxRedRight { get; set; }


        public Cam4_Foto1Param()
        {
            this.CircleCenter = new CircleParam();
            this.ThresholdCircleCenter = 50;
            this.AreaMaxCircleCenter = 20;

            this.CircleYellowCenter = new BullEyeParam();
            this.ThresholdYellowCenter = 50;
            this.AreaMaxYellowCenter = 10;

            this.CircleBlueCenter = new CircleParam();
            this.ThresholdBlueCenter = 50;
            this.AreaMaxBlueCenter = 10;

            this.RectGrayLeft = new Rectangle1Param();
            this.ThresholdGrayLeft = 50;
            this.AreaMinGrayLeft = 50;

            this.RectGrayRight = new Rectangle1Param();
            this.ThresholdGrayRight = 50;
            this.AreaMinGrayRight = 50;

            this.RectBlueLeft = new Rectangle1Param();
            this.ThresholdBlueLeft = 0;
            this.AreaMaxBlueLeft = 10;

            this.RectBlueUp = new Rectangle1Param();
            this.ThresholdBlueUp = 0;
            this.AreaMaxBlueUp = 10;

            this.RectBlueRight = new Rectangle1Param();
            this.ThresholdBlueRight = 0;
            this.AreaMaxBlueRight = 10;

            this.RectYellowRight = new Rectangle1Param();
            this.ThresholdYellowRight = 0;
            this.AreaMaxYellowRight = 10;


            this.RectBlueLeft2 = new Rectangle1Param();
            this.ThresholdBlueLeft2 = 0;
            this.AreaMaxBlueLeft2 = 10;

            this.RectBlueLeft3 = new Rectangle1Param();
            this.ThresholdBlueLeft3 = 0;
            this.AreaMaxBlueLeft3 = 10;

            this.RectBlueLeft4 = new Rectangle1Param();
            this.ThresholdBlueLeft4 = 0;
            this.AreaMaxBlueLeft4 = 10;

            this.RectBlueRight2 = new Rectangle1Param();
            this.ThresholdBlueRight2 = 0;
            this.AreaMaxBlueRight2 = 10;

            this.RectYellowRight2 = new Rectangle1Param();
            this.ThresholdYellowRight2 = 0;
            this.AreaMaxYellowRight2 = 10;

            this.RectRedRight = new Rectangle1Param();
            this.ThresholdRedRight = 0;
            this.AreaMaxRedRight = 10;

            this.RectRedLeft = new Rectangle1Param();
            this.ThresholdRedLeft = 0;
            this.AreaMaxRedLeft = 10;
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
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~Cam4_Foto1Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}