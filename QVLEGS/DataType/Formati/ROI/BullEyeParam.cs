namespace QVLEGS.DataType
{
    public class BullEyeParam
    {

        public double Row { get; set; }
        public double Column { get; set; }
        public double RadiusInner { get; set; }
        public double RadiusOuter { get; set; }

        public BullEyeParam(double row, double column, double radiusInner, double radiusOuter)
        {
            this.Row = row;
            this.Column = column;
            this.RadiusInner = radiusInner;
            this.RadiusOuter = radiusOuter;
        }

        public BullEyeParam() : this(0, 0, 50, 60) { }

        public override string ToString()
        {
            return $"Row={Row:0.00}; Column={Column:0.00}; RadiusInner={RadiusInner:0.00}; RadiusOuter={RadiusOuter:0.00}";
        }

    }
}
