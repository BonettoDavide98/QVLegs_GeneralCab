namespace QVLEGS.DataType
{
    public class Rectangle1Param
    {

        public double Row1 { get; set; }
        public double Column1 { get; set; }
        public double Row2 { get; set; }
        public double Column2 { get; set; }

        public Rectangle1Param(double row1, double column1, double row2, double column2)
        {
            this.Row1 = row1;
            this.Column1 = column1;
            this.Row2 = row2;
            this.Column2 = column2;
        }

        public Rectangle1Param() : this(0, 0, 0, 0) { }
        
        public override string ToString()
        {
            return $"Row1={Row1:0.00}; Column1={Column1:0.00}; Row2={Row2:0.00}; Column2={Column2:0.00}";
        }

    }
}
