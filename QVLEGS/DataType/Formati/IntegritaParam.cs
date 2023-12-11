using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class IntegritaParam : IDisposable
    {

        public class BlobCioccolato
        {
            public double Dist { get; set; }
            public double Area { get; set; }
        }


        public class BlobCioccolatoDescrittore
        {
            [XmlIgnore]
            public Bitmap Bmp { get; set; }

            //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
            //[XmlElement("Bmp")]
            //public byte[] BmpSerialized
            //{
            //    get
            //    { // serialize
            //        if (Bmp == null) return null;
            //        ImageConverter converter = new ImageConverter();
            //        return (byte[])converter.ConvertTo(Bmp, typeof(byte[]));
            //    }
            //    set
            //    { // deserialize
            //        if (value == null)
            //        {
            //            Bmp = null;
            //        }
            //        else
            //        {
            //            using (MemoryStream ms = new MemoryStream(value))
            //            {
            //                Bmp = new Bitmap(ms);
            //            }
            //        }
            //    }
            //}


            //[XmlIgnore]
            //public HalconDotNet.HImage _ImageRef = null;
            //[XmlIgnore]
            //public HalconDotNet.HImage ImageRef
            //{
            //    get { return _ImageRef; }
            //    set
            //    {
            //        _ImageRef = value;
            //        Bmp = GetBitmapFromHImage(_ImageRef);
            //    }
            //}

            [XmlIgnore]
            public HalconDotNet.HImage ImageRef { get; set; }

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


            public List<BlobCioccolato> ListBlobCioccolato { get; set; }

            public BlobCioccolatoDescrittore()
            {
                this.ListBlobCioccolato = new List<BlobCioccolato>();
            }

            public void AggiornaBmp()
            {
                try
                {
                    this.Bmp = GetBitmapFromHImage(this.ImageRef);
                }
                catch (Exception) { }
            }

            private Bitmap GetBitmapFromHImage(HImage img)
            {
                Bitmap ret = null;
                string tmpFile = string.Format("{0}.bmp", System.IO.Path.GetTempFileName());
                img.WriteImage("bmp", 0, tmpFile);
                using (var fs = new System.IO.FileStream(tmpFile, System.IO.FileMode.Open))
                {
                    var bitmap = new Bitmap(fs);
                    ret = (Bitmap)bitmap.Clone();
                }
                System.IO.File.Delete(tmpFile);
                return ret;
            }
        }

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        public HalconDotNet.HImage ImageRef { get; set; }

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

        [Browsable(false)]
        [XmlIgnore]
        public HalconDotNet.HRegion ReferenceRegion { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ReferenceRegion")]
        public byte[] ReferenceRegionSerialized
        {
            get
            {
                // serialize
                if (ReferenceRegion == null)
                    return null;
                else
                    return this.ReferenceRegion.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    ReferenceRegion = null;
                }
                else
                {
                    try
                    {
                        this.ReferenceRegion = new HalconDotNet.HRegion();
                        this.ReferenceRegion.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false)]
        public double AreaRef { get; set; }
        [Browsable(false)]
        public double RowRef { get; set; }
        [Browsable(false)]
        public double ColRef { get; set; }
        [Browsable(false)]
        public double AngleRef { get; set; }

        public double DimensioneFiltro { get; set; }
        public double AreaMin { get; set; }
        public double AreaMax { get; set; }
        public double DeltaMax { get; set; }



        public bool UsaControlloBiscottoCioccolato { get; set; }
        public bool PresenzaBiscottoOK { get; set; }
        public bool AbilitaControlloScopertura { get; set; }
        //public int ThresholdMinBiscotto { get; set; }
        //public int ThresholdMaxBiscotto { get; set; }
        //public double DimensioneFiltroCioccolato { get; set; }
        public double AreaBiscottoMax { get; set; }
        public double AreaCioccolatoMin { get; set; }

        [Browsable(false)]
        public bool UsaControlloAreaCioccolato { get; set; }

        [Browsable(false)]
        public double MaxDistListBlobCioccolato { get; set; }
        [Browsable(false)]
        public double MaxDeltaAreaListBlobCioccolato { get; set; }
        [Browsable(false)]
        public List<BlobCioccolatoDescrittore> ListBlobCioccolato { get; set; }

        [Browsable(false)]
        public Integrita4Param Integrita4Param { get; set; }

        public IntegritaParam()
        {
            this.AreaRef = -1;
            this.DimensioneFiltro = 3;
            this.AreaMin = 10;

            this.MaxDistListBlobCioccolato = 20;
            this.MaxDeltaAreaListBlobCioccolato = 0.5;
            this.ListBlobCioccolato = new List<BlobCioccolatoDescrittore>();

            this.Integrita4Param = new Integrita4Param();
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

                    this.ImageRef?.Dispose();
                    this.ImageRef = null;

                    this.ReferenceRegion?.Dispose();
                    this.ReferenceRegion = null;

                    this.Integrita4Param?.Dispose();
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~IntegritaParam()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}