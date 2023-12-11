using System;
using System.Collections.Generic;

namespace QVLEGS.DataType
{
    public class ElaborateResult : IDisposable
    {

        public bool Success { get; set; }
        public double ElapsedTime { get; set; }
        public bool InTimeout { get; set; }
        public string DescrizioneTempi { get; set; }
        public StatisticheObj StatisticheObj { get; set; }

        public List<Tuple<string, string>> TestiOutAlgoritmi { get; set; }
        public List<string> TestiRagioneScarto { get; set; }
        public Dictionary<string, ushort> ResultOutput { get; set; }

        public PrevImageData PrevImageData { get; set; }

        public ElaborateResult()
        {
            this.Success = false;
            this.ElapsedTime = 0;
            this.InTimeout = false;

            this.StatisticheObj = new StatisticheObj() { TimeStamp = DateTime.Now };

            this.TestiOutAlgoritmi = new List<Tuple<string, string>>();
            this.TestiRagioneScarto = new List<string>();

            this.ResultOutput = new Dictionary<string, ushort>();

            this.PrevImageData = null;
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
                    this.PrevImageData?.Dispose();
                    this.PrevImageData = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ElaborateResult()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }


    }
}