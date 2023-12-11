using System.Collections;
using HalconDotNet;
using QVLEGS.DataType;

namespace QVLEGS.Class
{
    public interface IFrameGrabberManager
    {
        event NewImageDelegate.OnNewImageDelegate OnNewImage;

        void Dispose();
        void ForceTrigger();
        double GetExpo();
        double GetGain();
        ArrayList GetOverrideParameter();
        HTuple GetParam(string param);
        ArrayList GetParameter();
        bool GetValueInput(string line);
        HImage GrabASyncNoDelegate(out long tPreElab);
        HImage GrabImage();
        void GrabImageStart();
        void ResetDefaulParameter();
        void SetDelegate(NewImageDelegate.OnNewImageDelegate OnNewImage_);
        void SetExpo(double expo);
        void SetGain(double gain);
        void SetOutput(string line, bool value);
        void SetOverrideParameter(FrameGrabberConfigOverride param);
        void SetParam(string param, string value);
        void SetTrigger(bool trigger, bool triggerSoftware);
        void TriggerSoftware();
    }
}