using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AllineamentoParam : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public HalconDotNet.HImage ImageRef { get; set; }
        [Browsable(false)]
        public PrevImageData PrevImageDataRef { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ImageRef")]
        public byte[] ImageRefSerialized
        {
            get
            {
                // serialize
                if (this.ImageRef == null)
                    return null;
                else
                    return this.ImageRef.SerializeImage();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.ImageRef = null;
                }
                else
                {
                    try
                    {
                        this.ImageRef = new HalconDotNet.HImage();
                        this.ImageRef.DeserializeImage(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        public Rectangle1Param RoiModel { get; set; }

        public AllineamentoShapeParam ShapeParam { get; set; }

        public bool LimitaAngolo { get; set; }
        public double MaxAngolo { get; set; }

        public AllineamentoParam()
        {
            this.ShapeParam = new AllineamentoShapeParam();
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
                    this.ShapeParam.Dispose();
                    this.ShapeParam = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AllineamentoParam()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}