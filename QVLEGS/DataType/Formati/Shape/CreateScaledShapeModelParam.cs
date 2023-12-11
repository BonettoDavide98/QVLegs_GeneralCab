using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CreateScaledShapeModelParam
    {
        public int NumLevels { get; set; }
        public double AngleStart { get; set; }
        public double AngleExtent { get; set; }
        public double AngleStep { get; set; }
        public double ScaleMin { get; set; }
        public double ScaleMax { get; set; }
        public double ScaleStep { get; set; }
        public string Optimization { get; set; }
        public string Metric { get; set; }
        public int Contrast { get; set; }
        public int MinContrast { get; set; }

        public CreateScaledShapeModelParam()
        {
            //Angoli da lasciare così altrimenti non trova
            this.NumLevels = 5;
            //this.AngleStart = -(double)(50.0 * Math.PI / 180.0);
            //this.AngleExtent = (double)(50.0 * Math.PI / 180.0);
            this.AngleStart = -(double)(10.0 * Math.PI / 180.0);
            this.AngleExtent = (double)(20.0 * Math.PI / 180.0);
            this.AngleStep = (double)Math.PI / 180.0;
            this.ScaleMin = 0.9;
            this.ScaleMax = 1.1;
            this.ScaleStep = 0.01;
            this.Optimization = "none";
            this.Metric = "ignore_local_polarity";
            this.Contrast = 30;
            this.MinContrast = 10;
        }
    }
}
