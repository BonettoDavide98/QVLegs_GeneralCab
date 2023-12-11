namespace QVLEGS.DataType
{
    public class CircleParam
    {

        public double Row { get; set; }
        public double Column { get; set; }
        public double Radius { get; set; }

        public CircleParam(double row, double column, double radius)
        {
            this.Row = row;
            this.Column = column;
            this.Radius = radius;
        }

        public CircleParam() : this(0, 0, 0) { }

        public override string ToString()
        {
            return $"Row={Row:0.00}; Column={Column:0.00}; Radiu={Radius:0.00}";
        }

    }
}
