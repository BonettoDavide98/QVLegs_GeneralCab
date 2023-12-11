namespace QVLEGS.DataType
{
    public class FrameGrabberParam
    {

        public string Param { get; set; }
        public string Value { get; set; }

        public FrameGrabberParam() : this(string.Empty, string.Empty) { }

        public FrameGrabberParam(string param, string value)
        {
            this.Param = param;
            this.Value = value;
        }

    }
}