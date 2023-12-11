using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam5_Foto2Param : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        public Rectangle1Param Roi { get; set; }
        public double AreaMin { get; set; }
        public double ThresholdMax { get; set; }



        public Cam5_Foto2Param()
        {
            this.Roi = new Rectangle1Param();
            this.AreaMin = 100;
            this.ThresholdMax = 100;
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
        ~Cam5_Foto2Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}