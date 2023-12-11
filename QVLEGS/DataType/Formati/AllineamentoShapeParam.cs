using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AllineamentoShapeParam : IDisposable
    {

        [XmlIgnore]
        public HalconDotNet.HRegion ShapeMask { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ShapeMask")]
        public byte[] ShapeMaskSerialized
        {
            get
            {
                // serialize
                if (ShapeMask == null)
                    return null;
                else
                    return this.ShapeMask.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.ShapeMask = null;
                }
                else
                {
                    try
                    {
                        this.ShapeMask = new HalconDotNet.HRegion();
                        this.ShapeMask.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [XmlIgnore]
        public HalconDotNet.HShapeModel ShapeModel { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ShapeModel")]
        public byte[] ShapeModelSerialized
        {
            get
            {
                // serialize
                if (this.ShapeModel == null)
                    return null;
                else
                    return this.ShapeModel.SerializeShapeModel();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.ShapeModel = null;
                }
                else
                {
                    try
                    {
                        this.ShapeModel = new HalconDotNet.HShapeModel();
                        this.ShapeModel.DeserializeShapeModel(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        public double RowRef { get; set; }
        public double ColumnRef { get; set; }
        public double AngleRef { get; set; }

        public CreateScaledShapeModelParam CreateParam { get; set; }
        public FindScaledShapeModelParam FindParam { get; set; }

        public AllineamentoShapeParam()
        {
            this.CreateParam = new CreateScaledShapeModelParam();
            this.FindParam = new FindScaledShapeModelParam();
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
                    this.ShapeMask?.Dispose();
                    this.ShapeMask = null;

                    this.ShapeModel?.Dispose();
                    this.ShapeModel = null;
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AllineamentoShapeParam()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}
