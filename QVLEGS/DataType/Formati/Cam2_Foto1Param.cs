using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam2_Foto1Param : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        public Rectangle1Param RectPin { get; set; }
        public Rectangle1Param RectBlackLeft { get; set; }
        public Rectangle1Param RectBlackRight { get; set; }


        public double ThresholdLeft { get; set; }
        public double ThresholdRight { get; set; }
        public double ThresholdPin { get; set; }
        public double DistMax { get; set; }
        public double AreaMaxLeft { get; set; }
        public double AreaMaxRight { get; set; }


        public Cam2_Foto1Param()
        {
            this.RectPin = new Rectangle1Param();
            this.RectBlackLeft = new Rectangle1Param();
            this.RectBlackRight = new Rectangle1Param();

            this.ThresholdLeft = 100;
            this.ThresholdRight = 100;
            this.ThresholdPin = 100;
            this.AreaMaxRight = 10;
            this.AreaMaxLeft = 10;
            this.DistMax = 10;
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
        ~Cam2_Foto1Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}