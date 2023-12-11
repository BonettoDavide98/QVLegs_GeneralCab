namespace QVLEGS.DataType
{
    public class Rectangle2Param
    {

        public double Row { get; set; }
        public double Column { get; set; }
        public double Angle { get; set; }
        public double Length1 { get; set; }
        public double Length2 { get; set; }

        public Rectangle2Param(double row, double column, double angle, double length1, double length2)
        {
            this.Row = row;
            this.Column = column;
            this.Angle = angle;
            this.Length1 = length1;
            this.Length2 = length2;
        }

        public Rectangle2Param() : this(100, 100, 0, 100, 100) { }

        public override string ToString()
        {
            return $"Row={Row:0.00}; Column={Column:0.00}; Angle={Angle:0.00}; Length1={Length1:0.00}; Length2={Length2:0.00}";
        }

    }
}
