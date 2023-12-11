using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam1_Foto1Param : IDisposable
    {
        [Browsable(false)]
        public bool CSV { get; set; }

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        public Rectangle2Param RoiCalliper { get; set; }
        public CircleParam Circle1 { get; set; }
        public CircleParam Circle2 { get; set; }
        public CircleParam Circle3 { get; set; }
        public CircleParam Circle4 { get; set; }
        public CircleParam CircleEdge { get; set; }

        public double ThresholdCircle1 { get; set; }
        public double AreaMaxCircle1 { get; set; }
        public double ThresholdCircle2 { get; set; }
        public double AreaMaxCircle2 { get; set; }
        public double ThresholdCircle3 { get; set; }
        public double AreaMaxCircle3 { get; set; }
        public double ThresholdCircle4 { get; set; }
        public double AreaMaxCircle4 { get; set; }

        public double ThresholdCenterCircle { get; set; }
        public double DistMinCircle { get; set; }

        public double ThresholdRectangle { get; set; }
        public double DistMinRectangle { get; set; }
        public double DistMaxRectangle { get; set; }

        public double LengthMinCircle { get; set; }
        public double LengthMaxCircle { get; set; }

        public Cam1_Foto1Param()
        {
            this.RoiCalliper = new Rectangle2Param();
            this.Circle1 = new CircleParam();
            this.Circle2 = new CircleParam();
            this.Circle3 = new CircleParam();
            this.Circle4 = new CircleParam();
            this.CircleEdge = new CircleParam();

            this.ThresholdCircle1 = 150;
            this.AreaMaxCircle1 = 10;

            this.ThresholdCircle2 = 150;
            this.AreaMaxCircle2 = 10;

            this.ThresholdCircle3 = 150;
            this.AreaMaxCircle3 = 10;

            this.ThresholdCircle4 = 150;
            this.AreaMaxCircle4 = 10;

            this.ThresholdCenterCircle = 30;

            this.DistMinCircle = 10;

            this.ThresholdRectangle = 100;
            this.DistMinRectangle = 0;
            this.DistMaxRectangle = 0;

            this.LengthMinCircle = 0;
            this.LengthMaxCircle = 0;
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
        ~Cam1_Foto1Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}