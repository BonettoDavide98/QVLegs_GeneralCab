using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam3_Foto1Param : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        public Rectangle2Param RectRif_1 { get; set; }
        public double RifRow_1 { get; set; }
        public double RifCol_1 { get; set; }

        public Rectangle2Param RectRif_2 { get; set; }
        public double RifRow_2 { get; set; }
        public double RifCol_2 { get; set; }

        public Rectangle2Param RectCalipper_1 { get; set; }
        public double DistMax_Calipper_1 { get; set; }
        public double DistMin_Calipper_1 { get; set; }

        public Rectangle2Param RectCalipper_2 { get; set; }
        public double DistMax_Calipper_2 { get; set; }
        public double DistMin_Calipper_2 { get; set; }

        public Rectangle2Param RectHeight_1 { get; set; }
        public double DistMax_Height_1 { get; set; }
        public double DistMin_Height_1 { get; set; }

        public Rectangle2Param RectHeight_2 { get; set; }
        public double DistMax_Height_2 { get; set; }
        public double DistMin_Height_2 { get; set; }
        public Cam3_Foto1Param()
        {
            this.RectRif_1 = new Rectangle2Param();
            this.RifRow_1 = 10;
            this.RifCol_1 = 10;

            this.RectRif_2 = new Rectangle2Param();
            this.RifRow_2 = 10;
            this.RifCol_2 = 10;

            this.RectCalipper_1 = new Rectangle2Param();
            this.DistMax_Calipper_1 = 10;
            this.DistMin_Calipper_1 = 5;

            this.RectCalipper_2 = new Rectangle2Param();
            this.DistMax_Calipper_2 = 10;
            this.DistMin_Calipper_2 = 5;

            this.RectHeight_1 = new Rectangle2Param();
            this.DistMax_Height_1 = 10;
            this.DistMin_Height_1 = 5;

            this.RectHeight_2 = new Rectangle2Param();
            this.DistMax_Height_2 = 10;
            this.DistMin_Height_2 = 5;
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
        ~Cam3_Foto1Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}