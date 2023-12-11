using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Integrita4Param : IDisposable
    {

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        public double AreaMinSingolo { get; set; }
        public double AreaMaxSingolo { get; set; }

        public double AreaMinTot { get; set; }
        public double AreaMaxTot { get; set; }

        public int CntMinBlob { get; set; }
        public int CntMaxBlob { get; set; }

        public Integrita4Param()
        {
            AreaMinSingolo = 1;
            AreaMaxSingolo = 500;

            AreaMinTot = 50;
            AreaMaxTot = 1000;

            CntMinBlob = 0;
            CntMaxBlob = 5;
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
        ~Integrita4Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}