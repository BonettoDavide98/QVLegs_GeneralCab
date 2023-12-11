using HalconDotNet;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGS.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Cam1_Foto2Param : IDisposable
    {

        [Browsable(false)]
        public bool WizardCompleto { get; set; }

        [Browsable(false)]
        public bool AbilitaControllo { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_1 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_2 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_3 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_4 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_5 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_6 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_7 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_8 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_9 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion_10 { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_1")]
        public byte[] BigRectSerialized_1
        {
            get
            {
                // serialize
                if (bigRegion_1 == null)
                    return null;
                else
                    return this.bigRegion_1.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_1 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_1 = new HalconDotNet.HRegion();
                        this.bigRegion_1.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_2")]
        public byte[] BigRectSerialized_2
        {
            get
            {
                // serialize
                if (bigRegion_2 == null)
                    return null;
                else
                    return this.bigRegion_2.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_2 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_2 = new HalconDotNet.HRegion();
                        this.bigRegion_2.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_3")]
        public byte[] BigRectSerialized_3
        {
            get
            {
                // serialize
                if (bigRegion_3 == null)
                    return null;
                else
                    return this.bigRegion_3.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_3 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_3 = new HalconDotNet.HRegion();
                        this.bigRegion_3.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_4")]
        public byte[] BigRectSerialized_4
        {
            get
            {
                // serialize
                if (bigRegion_4 == null)
                    return null;
                else
                    return this.bigRegion_4.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_4 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_4 = new HalconDotNet.HRegion();
                        this.bigRegion_4.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_5")]
        public byte[] BigRectSerialized_5
        {
            get
            {
                // serialize
                if (bigRegion_5 == null)
                    return null;
                else
                    return this.bigRegion_5.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_5 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_5 = new HalconDotNet.HRegion();
                        this.bigRegion_5.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_6")]
        public byte[] BigRectSerialized_6
        {
            get
            {
                // serialize
                if (bigRegion_6 == null)
                    return null;
                else
                    return this.bigRegion_6.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_6 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_6 = new HalconDotNet.HRegion();
                        this.bigRegion_6.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_7")]
        public byte[] BigRectSerialized_7
        {
            get
            {
                // serialize
                if (bigRegion_7 == null)
                    return null;
                else
                    return this.bigRegion_7.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_7 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_7 = new HalconDotNet.HRegion();
                        this.bigRegion_7.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_8")]
        public byte[] BigRectSerialized_8
        {
            get
            {
                // serialize
                if (bigRegion_8 == null)
                    return null;
                else
                    return this.bigRegion_8.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_8 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_8 = new HalconDotNet.HRegion();
                        this.bigRegion_8.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_9")]
        public byte[] BigRectSerialized_9
        {
            get
            {
                // serialize
                if (bigRegion_9 == null)
                    return null;
                else
                    return this.bigRegion_9.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_9 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_9 = new HalconDotNet.HRegion();
                        this.bigRegion_9.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion_10")]
        public byte[] BigRectSerialized_10
        {
            get
            {
                // serialize
                if (bigRegion_10 == null)
                    return null;
                else
                    return this.bigRegion_10.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion_10 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion_10 = new HalconDotNet.HRegion();
                        this.bigRegion_10.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }
        
        [XmlIgnore]
        public HRegion bigRegion2_1 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_2 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_3 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_4 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_5 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_6 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_7 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_8 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_9 { get; set; }
        [XmlIgnore]
        public HRegion bigRegion2_10 { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_1")]
        public byte[] BigRectSerialized2_1
        {
            get
            {
                // serialize
                if (bigRegion2_1 == null)
                    return null;
                else
                    return this.bigRegion2_1.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_1 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_1 = new HalconDotNet.HRegion();
                        this.bigRegion2_1.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_2")]
        public byte[] BigRectSerialized2_2
        {
            get
            {
                // serialize
                if (bigRegion2_2 == null)
                    return null;
                else
                    return this.bigRegion2_2.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_2 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_2 = new HalconDotNet.HRegion();
                        this.bigRegion2_2.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_3")]
        public byte[] BigRectSerialized2_3
        {
            get
            {
                // serialize
                if (bigRegion2_3 == null)
                    return null;
                else
                    return this.bigRegion2_3.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_3 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_3 = new HalconDotNet.HRegion();
                        this.bigRegion2_3.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_4")]
        public byte[] BigRectSerialized2_4
        {
            get
            {
                // serialize
                if (bigRegion2_4 == null)
                    return null;
                else
                    return this.bigRegion2_4.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_4 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_4 = new HalconDotNet.HRegion();
                        this.bigRegion2_4.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_5")]
        public byte[] BigRectSerialized2_5
        {
            get
            {
                // serialize
                if (bigRegion2_5 == null)
                    return null;
                else
                    return this.bigRegion2_5.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_5 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_5 = new HalconDotNet.HRegion();
                        this.bigRegion2_5.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_6")]
        public byte[] BigRectSerialized2_6
        {
            get
            {
                // serialize
                if (bigRegion2_6 == null)
                    return null;
                else
                    return this.bigRegion2_6.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_6 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_6 = new HalconDotNet.HRegion();
                        this.bigRegion2_6.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_7")]
        public byte[] BigRectSerialized2_7
        {
            get
            {
                // serialize
                if (bigRegion2_7 == null)
                    return null;
                else
                    return this.bigRegion2_7.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_7 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_7 = new HalconDotNet.HRegion();
                        this.bigRegion2_7.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_8")]
        public byte[] BigRectSerialized2_8
        {
            get
            {
                // serialize
                if (bigRegion2_8 == null)
                    return null;
                else
                    return this.bigRegion2_8.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_8 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_8 = new HalconDotNet.HRegion();
                        this.bigRegion2_8.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_9")]
        public byte[] BigRectSerialized2_9
        {
            get
            {
                // serialize
                if (bigRegion2_9 == null)
                    return null;
                else
                    return this.bigRegion2_9.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_9 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_9 = new HalconDotNet.HRegion();
                        this.bigRegion2_9.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("bigRegion2_10")]
        public byte[] BigRectSerialized2_10
        {
            get
            {
                // serialize
                if (bigRegion2_10 == null)
                    return null;
                else
                    return this.bigRegion2_10.SerializeRegion();
            }
            set
            {
                // deserialize
                if (value == null)
                {
                    this.bigRegion2_10 = null;
                }
                else
                {
                    try
                    {
                        this.bigRegion2_10 = new HalconDotNet.HRegion();
                        this.bigRegion2_10.DeserializeRegion(new HalconDotNet.HSerializedItem(value));
                    }
                    catch (Exception) { }
                }
            }
        }


        public Rectangle1Param smallRect_1 { get; set; }
        public Rectangle1Param smallRect_2 { get; set; }
        public Rectangle1Param smallRect_3 { get; set; }
        public Rectangle1Param smallRect_4 { get; set; }
        public Rectangle1Param smallRect_5 { get; set; }
        public Rectangle1Param smallRect_6 { get; set; }
        public Rectangle1Param smallRect_7 { get; set; }
        public Rectangle1Param smallRect_8 { get; set; }



        public double ThresholdBig_1 { get; set; }
        public double AreaMAxBig_1 { get; set; }
        public double AreaMinBig_1 { get; set; }
        public double ThresholdBig_2 { get; set; }
        public double AreaMAxBig_2 { get; set; }
        public double AreaMinBig_2 { get; set; }
        public double ThresholdBig_3 { get; set; }
        public double AreaMAxBig_3 { get; set; }
        public double AreaMinBig_3 { get; set; }
        public double ThresholdBig_4 { get; set; }
        public double AreaMAxBig_4 { get; set; }
        public double AreaMinBig_4 { get; set; }
        public double ThresholdBig_5 { get; set; }
        public double AreaMAxBig_5 { get; set; }
        public double AreaMinBig_5 { get; set; }
        public double ThresholdBig_6 { get; set; }
        public double AreaMAxBig_6 { get; set; }
        public double AreaMinBig_6 { get; set; }
        public double ThresholdBig_7 { get; set; }
        public double AreaMAxBig_7 { get; set; }
        public double AreaMinBig_7 { get; set; }
        public double ThresholdBig_8 { get; set; }
        public double AreaMAxBig_8 { get; set; }
        public double AreaMinBig_8 { get; set; }
        public double ThresholdBig_9 { get; set; }
        public double AreaMAxBig_9 { get; set; }
        public double AreaMinBig_9 { get; set; }
        public double ThresholdBig_10 { get; set; }
        public double AreaMAxBig_10 { get; set; }
        public double AreaMinBig_10 { get; set; }

        public double ThresholdBig2_1 { get; set; }
        public double AreaMAxBig2_1 { get; set; }
        public double AreaMinBig2_1 { get; set; }
        public double ThresholdBig2_2 { get; set; }
        public double AreaMAxBig2_2 { get; set; }
        public double AreaMinBig2_2 { get; set; }
        public double ThresholdBig2_3 { get; set; }
        public double AreaMAxBig2_3 { get; set; }
        public double AreaMinBig2_3 { get; set; }
        public double ThresholdBig2_4 { get; set; }
        public double AreaMAxBig2_4 { get; set; }
        public double AreaMinBig2_4 { get; set; }
        public double ThresholdBig2_5 { get; set; }
        public double AreaMAxBig2_5 { get; set; }
        public double AreaMinBig2_5 { get; set; }
        public double ThresholdBig2_6 { get; set; }
        public double AreaMAxBig2_6 { get; set; }
        public double AreaMinBig2_6 { get; set; }
        public double ThresholdBig2_7 { get; set; }
        public double AreaMAxBig2_7 { get; set; }
        public double AreaMinBig2_7 { get; set; }
        public double ThresholdBig2_8 { get; set; }
        public double AreaMAxBig2_8 { get; set; }
        public double AreaMinBig2_8 { get; set; }
        public double ThresholdBig2_9 { get; set; }
        public double AreaMAxBig2_9 { get; set; }
        public double AreaMinBig2_9 { get; set; }
        public double ThresholdBig2_10 { get; set; }
        public double AreaMAxBig2_10 { get; set; }
        public double AreaMinBig2_10 { get; set; }


        public bool checked1 { get; set; }
        public bool invertedBlack1 { get; set; }
        public bool invertedWhite1 { get; set; }
        public bool checked2 { get; set; }
        public bool invertedBlack2 { get; set; }
        public bool invertedWhite2 { get; set; }
        public bool checked3 { get; set; }
        public bool invertedBlack3 { get; set; }
        public bool invertedWhite3 { get; set; }
        public bool checked4 { get; set; }
        public bool invertedBlack4 { get; set; }
        public bool invertedWhite4 { get; set; }
        public bool checked5 { get; set; }
        public bool invertedBlack5 { get; set; }
        public bool invertedWhite5 { get; set; }
        public bool checked6 { get; set; }
        public bool invertedBlack6 { get; set; }
        public bool invertedWhite6 { get; set; }
        public bool checked7 { get; set; }
        public bool invertedBlack7 { get; set; }
        public bool invertedWhite7 { get; set; }
        public bool checked8 { get; set; }
        public bool invertedBlack8 { get; set; }
        public bool invertedWhite8 { get; set; }
        public bool checked9 { get; set; }
        public bool invertedBlack9 { get; set; }
        public bool invertedWhite9 { get; set; }
        public bool checked10 { get; set; }
        public bool invertedBlack10 { get; set; }
        public bool invertedWhite10 { get; set; }


        public double ThresholdSmall_1 { get; set; }
        public double AreaMAxSmall_1 { get; set; }
        public double AreaMinSmall_1 { get; set; }
        public double ThresholdSmall_2 { get; set; }
        public double AreaMAxSmall_2 { get; set; }
        public double AreaMinSmall_2 { get; set; }
        public double ThresholdSmall_3 { get; set; }
        public double AreaMAxSmall_3 { get; set; }
        public double AreaMinSmall_3 { get; set; }
        public double ThresholdSmall_4 { get; set; }
        public double AreaMAxSmall_4 { get; set; }
        public double AreaMinSmall_4 { get; set; }
        public double ThresholdSmall_5 { get; set; }
        public double AreaMAxSmall_5 { get; set; }
        public double AreaMinSmall_5 { get; set; }
        public double ThresholdSmall_6 { get; set; }
        public double AreaMAxSmall_6 { get; set; }
        public double AreaMinSmall_6 { get; set; }
        public double ThresholdSmall_7 { get; set; }
        public double AreaMAxSmall_7 { get; set; }
        public double AreaMinSmall_7 { get; set; }
        public double ThresholdSmall_8 { get; set; }
        public double AreaMAxSmall_8 { get; set; }
        public double AreaMinSmall_8 { get; set; }

        public bool Hole_1 { get; set; }
        public bool Hole_2 { get; set; }
        public bool Hole_3 { get; set; }
        public bool Hole_4 { get; set; }
        public bool Hole_5 { get; set; }
        public bool Hole_6 { get; set; }
        public bool Hole_7 { get; set; }
        public bool Hole_8 { get; set; }
        public Cam1_Foto2Param()
        {
            // this.bigRegion_1 = new HRegion();
            //// bigRegion_1.SerializeRegion();
            // this.bigRegion_2 = new HRegion();
            // this.bigRegion_3 = new HRegion();
            // this.bigRegion_4 = new HRegion();
            // this.bigRegion_5 = new HRegion();
            // this.bigRegion_6 = new HRegion();
            // this.bigRegion_7 = new HRegion();
            // this.bigRegion_8 = new HRegion();
            // this.bigRegion_9 = new HRegion();
            // this.bigRegion_10 = new HRegion();
            
            //this.bigRegion2_1 = new HRegion();
            //this.bigRegion2_2 = new HRegion();
            //this.bigRegion2_3 = new HRegion();
            //this.bigRegion2_4 = new HRegion();
            //this.bigRegion2_5 = new HRegion();
            //this.bigRegion2_6 = new HRegion();
            //this.bigRegion2_7 = new HRegion();
            //this.bigRegion2_8 = new HRegion();
            //this.bigRegion2_9 = new HRegion();
            //this.bigRegion2_10 = new HRegion();

            this.smallRect_1 = new Rectangle1Param();
            this.smallRect_2 = new Rectangle1Param();
            this.smallRect_3 = new Rectangle1Param();
            this.smallRect_4 = new Rectangle1Param();
            this.smallRect_5 = new Rectangle1Param();
            this.smallRect_6 = new Rectangle1Param();
            this.smallRect_7 = new Rectangle1Param();
            this.smallRect_8 = new Rectangle1Param();



            this.ThresholdBig_1 = 100;
            this.AreaMAxBig_1 = 10000;
            this.AreaMinBig_1 = 1000;

            this.ThresholdBig_2 = 100;
            this.AreaMAxBig_2 = 10000;
            this.AreaMinBig_2 = 1000;


            this.ThresholdBig_3 = 100;
            this.AreaMAxBig_3 = 10000;
            this.AreaMinBig_3 = 1000;


            this.ThresholdBig_4 = 100;
            this.AreaMAxBig_4 = 10000;
            this.AreaMinBig_4 = 1000;


            this.ThresholdBig_5 = 100;
            this.AreaMAxBig_5 = 10000;
            this.AreaMinBig_5 = 1000;


            this.ThresholdBig_6 = 100;
            this.AreaMAxBig_6 = 10000;
            this.AreaMinBig_6 = 1000;


            this.ThresholdBig_7 = 100;
            this.AreaMAxBig_7 = 10000;
            this.AreaMinBig_7 = 1000;


            this.ThresholdBig_8 = 100;
            this.AreaMAxBig_8 = 10000;
            this.AreaMinBig_8 = 1000;


            this.ThresholdBig_9 = 100;
            this.AreaMAxBig_9 = 10000;
            this.AreaMinBig_9 = 1000;


            this.ThresholdBig_10 = 200;
            this.AreaMAxBig_10 = 10000;
            this.AreaMinBig_10 = 1000;

            this.ThresholdBig2_1 = 200;
            this.AreaMAxBig2_1 = 10000;
            this.AreaMinBig2_1 = 1000;

            this.ThresholdBig2_2 = 200;
            this.AreaMAxBig2_2 = 10000;
            this.AreaMinBig2_2 = 1000;


            this.ThresholdBig2_3 = 200;
            this.AreaMAxBig2_3 = 10000;
            this.AreaMinBig2_3 = 1000;


            this.ThresholdBig2_4 = 200;
            this.AreaMAxBig2_4 = 10000;
            this.AreaMinBig2_4 = 1000;


            this.ThresholdBig2_5 = 200;
            this.AreaMAxBig2_5 = 10000;
            this.AreaMinBig2_5 = 1000;


            this.ThresholdBig2_6 = 200;
            this.AreaMAxBig2_6 = 10000;
            this.AreaMinBig2_6 = 1000;


            this.ThresholdBig2_7 = 200;
            this.AreaMAxBig2_7 = 10000;
            this.AreaMinBig2_7 = 1000;


            this.ThresholdBig2_8 = 200;
            this.AreaMAxBig2_8 = 10000;
            this.AreaMinBig2_8 = 1000;


            this.ThresholdBig2_9 = 200;
            this.AreaMAxBig2_9 = 10000;
            this.AreaMinBig2_9 = 1000;


            this.ThresholdBig2_10 = 200;
            this.AreaMAxBig2_10 = 10000;
            this.AreaMinBig2_10 = 1000;


            this.ThresholdSmall_1 = 100;
            this.AreaMAxSmall_1 = 100;
            this.AreaMinSmall_1 = 100;

            this.ThresholdSmall_2 = 100;
            this.AreaMAxSmall_2 = 100;
            this.AreaMinSmall_2 = 100;

            this.ThresholdSmall_3 = 100;
            this.AreaMAxSmall_3 = 100;
            this.AreaMinSmall_3 = 100;

            this.ThresholdSmall_4 = 100;
            this.AreaMAxSmall_4 = 100;
            this.AreaMinSmall_4 = 100;

            this.ThresholdSmall_5 = 100;
            this.AreaMAxSmall_5 = 100;
            this.AreaMinSmall_5 = 100;

            this.ThresholdSmall_6 = 100;
            this.AreaMAxSmall_6 = 100;
            this.AreaMinSmall_6 = 100;

            this.ThresholdSmall_7 = 100;
            this.AreaMAxSmall_7 = 100;
            this.AreaMinSmall_7 = 100;

            this.ThresholdSmall_8 = 100;
            this.AreaMAxSmall_8 = 100;
            this.AreaMinSmall_8 = 100;

            this.Hole_1 = true;
            this.Hole_2 = true;
            this.Hole_3 = true;
            this.Hole_4 = true;
            this.Hole_5 = true;
            this.Hole_6 = true;
            this.Hole_7 = true;
            this.Hole_8 = true;

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
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~Cam1_Foto2Param()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}