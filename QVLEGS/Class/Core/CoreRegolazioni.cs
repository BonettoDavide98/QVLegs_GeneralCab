using System;
using System.Collections;

namespace QVLEGS.Class
{
    public class CoreRegolazioni : CoreBase
    {

        #region Variabili Private

        private readonly Core core = null;

        private HalconDotNet.HImage lastGrabImg = null;
        private int lastNumTest = 0;
        private DataType.PrevImageData lastPrevImageData = null;

        private int numTest = -1;

        #endregion

        public CoreRegolazioni(int numCamera, int idStazione, int numTest, Core core, DataType.Impostazioni config) : base(numCamera, idStazione, config)
        {
            try
            {
                this.core = core;
                this.numTest = numTest;

                core.SetOnNewImageForRegolazioni(core_OnNewImageForRegolazioni);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IFrameGrabberManager GetFrameGrabberManager()
        {
            return this.core.GetFrameGrabberManager();
        }

        //public void ExecuteOnLastImage()
        //{
        //    HalconDotNet.HImage lastGrabImgTmp = GetLastGrabImage();

        //    if (lastGrabImgTmp != null && lastGrabImgTmp.IsInitialized())
        //    {
        //        CoreOnNewImage(lastGrabImgTmp);
        //    }
        //}

        public HalconDotNet.HImage GetLastGrabImage(out DataType.PrevImageData prevImageData)
        {
            HalconDotNet.HImage lastGrabImgTmp = null;

            lock (onNewImageLock)
            {
                if (lastGrabImg != null)
                {
                    lastGrabImgTmp = lastGrabImg.CopyImage();
                }
            }

            prevImageData = this.lastPrevImageData;
            return lastGrabImgTmp;
        }

        private void core_OnNewImageForRegolazioni(HalconDotNet.HImage hImage, int numTest, DataType.PrevImageData prevImageData)
        {
            if (this.IsRunning && this.numTest == numTest)
                CoreOnNewImage(hImage, numTest, prevImageData);
        }

        private void CoreOnNewImage(HalconDotNet.HImage hImage, int numTest, DataType.PrevImageData prevImageData)
        {
            lock (onNewImageLock)
            {
                if (this.lastGrabImg != null)
                    this.lastGrabImg.Dispose();

                this.lastGrabImg = hImage.CopyImage();

                this.lastNumTest = numTest;

                this.lastPrevImageData = prevImageData;

                double startTime = HalconDotNet.HSystem.CountSeconds();

                ArrayList iconicVarList;
                DataType.ElaborateResult result;
                ElaborateImage(hImage, numTest, prevImageData, out iconicVarList, out result);

                if (result != null)
                {
                    double tAnalisi = HalconDotNet.HSystem.CountSeconds();
                    tAnalisi = (tAnalisi - startTime) * 1000.0;

                    result.ElapsedTime = tAnalisi;

                    RaiseNewImageToDisplayEvent(numTest, iconicVarList, result);
                }
            }
        }

        public override void Run()
        {
            this.IsRunning = true;
        }

        public override void StopAndWaitEnd(bool forceTrigger)
        {
            this.IsRunning = false;
        }

        public override void CloseFrameGrabber()
        {
            if (this.lastGrabImg != null)
            {
                this.lastGrabImg.Dispose();
                this.lastGrabImg = null;
            }
            core.SetOnNewImageForRegolazioni(null);
        }

    }
}