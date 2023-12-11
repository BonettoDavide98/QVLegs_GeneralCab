using System;
using System.ComponentModel;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FindScaledShapeModelParam
    {
        public double AngleStart { get; set; }
        public double AngleExtent { get; set; }
        public double ScaleMin { get; set; }
        public double ScaleMax { get; set; }
        public double MinScore { get; set; }
        public int NumMatches { get; set; }
        public double MaxOverlap { get; set; }
        public string SubPixel { get; set; }
        //public int NumLevels { get; set; }
        public int LastPyramidLevel { get; set; }
        public double Greediness { get; set; }

        public FindScaledShapeModelParam()
        {
            //ANgoli da lasciare così altrimenti non trova
            //this.AngleStart = -(double)(50.0 * Math.PI / 180.0);
            //this.AngleExtent = (double)(50.0 * Math.PI / 180.0);
            this.AngleStart = -(double)(10.0 * Math.PI / 180.0);
            this.AngleExtent = (double)(20.0 * Math.PI / 180.0);
            this.ScaleMin = 0.9;
            this.ScaleMax = 1.1;
            this.MinScore = 0.60;
            this.NumMatches = 1;
            this.MaxOverlap = 0.5;
            this.SubPixel = "least_squares";
            //this.NumLevels = 5;
            this.LastPyramidLevel = 1;
            this.Greediness = 0.75;
        }
    }
}
