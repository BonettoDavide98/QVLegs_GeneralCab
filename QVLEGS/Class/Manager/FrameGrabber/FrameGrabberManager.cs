using HalconDotNet;
using QVLEGS.DataType;
using QVLEGS.Utilities;
using System;
using System.Collections;

namespace QVLEGS.Class
{
    public class FrameGrabberManager : IDisposable, IFrameGrabberManager
    {

        private bool disposed = false;

        private HFramegrabber framegrabber = null;
        private FrameGrabberConfig frameGrabberConfig = null;
        private FrameGrabberConfigOverride frameGrabberConfigOverride = null;

        public HTuple ImageHeight = null;
        public HTuple ImageWidth = null;

        public event NewImageDelegate.OnNewImageDelegate OnNewImage;

        public FrameGrabberManager(FrameGrabberConfig configFrameGrabber)
        {
            try
            {
                this.frameGrabberConfig = configFrameGrabber;
                this.framegrabber = new HFramegrabber(frameGrabberConfig.Name
                    , frameGrabberConfig.Horizzontal_resolution
                    , frameGrabberConfig.Vertical_resolution
                    , frameGrabberConfig.ImageWidth
                    , frameGrabberConfig.ImageHeight
                    , frameGrabberConfig.StartRow
                    , frameGrabberConfig.StartColumn
                    , frameGrabberConfig.Field
                    , frameGrabberConfig.BitsPerChannel
                    , frameGrabberConfig.ColorSpace
                    , frameGrabberConfig.Generic
                    , frameGrabberConfig.ExternalTrigger
                    , frameGrabberConfig.CameraType
                    , frameGrabberConfig.Device
                    , frameGrabberConfig.Port
                    , frameGrabberConfig.LineIn);

                SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);

                ImageHeight = framegrabber.GetFramegrabberParam(new HTuple("image_height"));
                ImageWidth = framegrabber.GetFramegrabberParam(new HTuple("image_width"));

                SetTrigger(false, false);
            }
            catch (Exception ex)
            {
                this.framegrabber = null;
                throw ex;
            }
        }

        private void SetConfigFrameGrabberParam(ArrayList paramList)
        {
            if (paramList != null)
            {
                for (int i = 0; i < paramList.Count; i++)
                {
                    FrameGrabberParam obj = (FrameGrabberParam)paramList[i];
                    SetParam(obj.Param, obj.Value);
                }
            }
        }

        public void SetDelegate(NewImageDelegate.OnNewImageDelegate OnNewImage_)
        {
            OnNewImage = OnNewImage_;
        }

        public void SetTrigger(bool trigger, bool triggerSoftware)
        {
            if (trigger)
            {
                SetParam("TriggerMode", "On");
                SetParam("TriggerSource", triggerSoftware ? "Software" : "Line1");
                SetParam("continuous_grabbing", "enable");
            }
            else
            {
                SetParam("continuous_grabbing", "disable");
                SetParam("TriggerMode", "Off");
                SetParam("AcquisitionFrameRate", "1");
            }
        }

        public void SetOutput(string line, bool value)
        {
            //if (!line.Equals("Line3"))
            //{
            SetParam("LineSelector", line);
            SetParam("outputLineSource", "SoftwareControlled");
            SetParam("outputLineValue", value ? "Active" : "Inactive");
            //}
        }

        public bool GetValueInput(string line)
        {
            try
            {
                SetParam("LineSelector", line);
                if (GetParam("LineStatus") == "enable")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetExpo(double expo)
        {
            SetParam("ExposureTime", expo.ToString());
        }

        public void SetGain(double gain)
        {
            SetParam("Gain", gain.ToString());
        }

        public double GetExpo()
        {
            return GetParam("ExposureTime");
        }

        public double GetGain()
        {
            return GetParam("Gain");
        }


        public void GrabImageStart()
        {
            framegrabber.GrabImageStart(-1);
        }

        public HImage GrabASyncNoDelegate(out long tPreElab)
        {
            tPreElab = 0;
            HImage img = framegrabber.GrabImageAsync(-1);

            return img;
        }

        public HImage GrabImage()
        {
            return framegrabber.GrabImage();
        }

        public void ForceTrigger()
        {
            try
            {
                framegrabber.SetFramegrabberParam(new HTuple("do_abort_grab"), new HTuple(1));
            }
            catch (Exception) { }
        }


        public void TriggerSoftware()
        {
            try
            {
                framegrabber.SetFramegrabberParam(new HTuple("TriggerSoftware"), new HTuple("False"));
            }
            catch (Exception ex) { }
        }


        public void ResetDefaulParameter()
        {
            SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);
        }

        public void SetOverrideParameter(FrameGrabberConfigOverride param)
        {
            this.frameGrabberConfigOverride = param;
            SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);
            if (param != null)
            {
                SetConfigFrameGrabberParam(this.frameGrabberConfigOverride.ParamList);
            }
        }

        public ArrayList GetParameter()
        {
            return this.frameGrabberConfig.ParamList;
        }

        public ArrayList GetOverrideParameter()
        {
            return this.frameGrabberConfigOverride == null ? null : this.frameGrabberConfigOverride.ParamList;
        }

        public void SetParam(string param, string value)
        {
            double dValue = 0.0;
            int nValue = 0;
            try
            {
#if !_Simulazione
                if (CommonUtility.TryParseDouble(value, out dValue))
                {
                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(dValue));
                }
                else if (int.TryParse(value, out nValue))
                {
                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(nValue));
                }
                else
                {
                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(value));
                }
#endif
            }
            catch (Exception) { }
        }

        public HTuple GetParam(string param)
        {
            return framegrabber.GetFramegrabberParam(param);
        }

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
                    //framegrabber.Dispose();
                    HOperatorSet.CloseFramegrabber(framegrabber);
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~FrameGrabberManager()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}