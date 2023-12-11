using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    public class PrevImageData : IDisposable
    {

        [XmlIgnore]
        [Browsable(false)]
        public HalconDotNet.HImage Image { get; set; }

        public double RowRef { get; set; }
        public double ColumnRef { get; set; }
        public double AngleRef { get; set; }

        public double Row { get; set; }
        public double Col { get; set; }
        public double Angle { get; set; }

        public PrevImageData()
        {
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
                    this.Image?.Dispose();
                    this.Image = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~PrevImageData()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}
