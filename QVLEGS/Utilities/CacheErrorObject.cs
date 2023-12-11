using QVLEGS.DataType;
using System;
using System.Collections;

namespace QVLEGS.Utilities
{
    public class CacheErrorObject : IDisposable
    {

        private bool disposed = false; // to detect redundant calls

        public DateTime TimeStamp { get; private set; }
        public ArrayList IconicVar { get; set; }
        public ElaborateResult ElaborateResult { get; set; }

        public CacheErrorObject(ArrayList iconicVar, ElaborateResult elaborateResult) : this(iconicVar, elaborateResult, DateTime.Now) { }

        public CacheErrorObject(ArrayList iconicVar, ElaborateResult elaborateResult, DateTime timeStamp)
        {
            this.TimeStamp = timeStamp;
            this.ElaborateResult = elaborateResult;

            this.IconicVar = new ArrayList();
            for (int i = 0; i < iconicVar.Count; i++)
            {
                this.IconicVar.Add(((ObjectToDisplay)iconicVar[i]).Clone());
            }
        }

        public CacheErrorObject Clona()
        {
            return (CacheErrorObject)this.MemberwiseClone();
        }

        #region IDisposable

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
                    if (this.IconicVar != null)
                    {
                        for (int i = 0; i < this.IconicVar.Count; i++)
                        {
                            if (this.IconicVar[i] != null)
                            {
                                ((ObjectToDisplay)this.IconicVar[i]).Dispose();
                                this.IconicVar[i] = null;
                            }
                        }
                    }
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~CacheErrorObject()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}