using HalconDotNet;
using System;

namespace QVLEGS.Utilities
{
    public class ObjectToDisplay : IDisposable
    {

        private bool disposed = false; // to detect redundant calls

        private ObjectToDisplay()
        {
            DrawMode = "margin";
            StrToDisplay = string.Empty;
            IconicColor = "black";
            IconicLineWidth = 1;
            FontSize = 18;
        }

        public ObjectToDisplay(HImage image)
            : this()
        {
            IconicVar = (HObject)image;
        }

        public ObjectToDisplay(HXLDCont cont, string color, int width)
            : this()
        {
            this.IconicVar = (HObject)cont;
            this.IconicColor = color;
            this.IconicLineWidth = width;
        }

        public ObjectToDisplay(HXLD xld, string color, int width)
            : this()
        {
            this.IconicVar = (HObject)xld;
            this.IconicColor = color;
            this.IconicLineWidth = width;
        }

        public ObjectToDisplay(HRegion region, string color, int width)
            : this()
        {
            this.IconicVar = (HObject)region;
            this.IconicColor = color;
            this.IconicLineWidth = width;
        }

        public ObjectToDisplay(string dispObjectType, HTuple dispObject, string color, int width)
            : this()
        {
            this.DispObjectType = dispObjectType;
            this.DispObject = dispObject;
            this.IconicColor = color;
            this.IconicLineWidth = width;
        }

        public ObjectToDisplay(string text, string color, int row, int column) : this(text, color, row, column, 18) { }

        public ObjectToDisplay(string text, string color, int row, int column, int fontSize) : this(text, color, row, column, fontSize, false) { }

        public ObjectToDisplay(string text, string color, int row, int column, int fontSize, bool isStringMessage)
            : this()
        {
            this.StrToDisplay = text;
            this.IconicColor = color;
            this.Row = row;
            this.Column = column;
            this.FontSize = fontSize;
            this.IsStringMessage = isStringMessage;
        }

        public HObject IconicVar { get; set; }
        public HTuple DispObject { get; set; }
        public string DrawMode { get; set; }
        public string DispObjectType { get; set; }
        public string IconicColor { get; set; }
        public int IconicLineWidth { get; set; }
        public string StrToDisplay { get; set; }
        public int FontSize { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsStringMessage { get; set; }

        public ObjectToDisplay Clone()
        {
            ObjectToDisplay ret = new ObjectToDisplay();

            try
            {
                if (this.IconicVar != null && this.IconicVar.IsInitialized())
                {
                    if (this.IconicVar is HImage)
                        ret.IconicVar = ((HImage)this.IconicVar).CopyImage();
                    else
                        ret.IconicVar = this.IconicVar.CopyObj(1, -1);
                }
            }
            catch (Exception) { }

            ret.DispObject = this.DispObject != null ? this.DispObject.Clone() : null;
            ret.DispObjectType = this.DispObjectType;
            ret.IconicColor = this.IconicColor;
            ret.IconicLineWidth = this.IconicLineWidth;
            ret.StrToDisplay = this.StrToDisplay;
            ret.FontSize = this.FontSize;
            ret.Row = this.Row;
            ret.Column = this.Column;
            ret.DrawMode = this.DrawMode;
            ret.IsStringMessage = this.IsStringMessage;

            return ret;
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
                        this.IconicVar.Dispose();
                        this.IconicVar = null;
                    }
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ObjectToDisplay()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}
