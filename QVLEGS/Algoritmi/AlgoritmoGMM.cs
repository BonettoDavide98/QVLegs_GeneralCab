using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace QVLEGS.Algoritmi
{
    public class AlgoritmoGMM : Algoritmo, IDisposable
    {

        public class TmpObjWizardClassificatore : IDisposable
        {

            private bool disposed = false;

            public HImage Image { get; set; }
            public HRegion Region { get; set; }

            public double R { get; set; }
            public double G { get; set; }
            public double B { get; set; }

            public int Delta { get; set; }

            #region IDisposable

            //Implement IDisposmoable.
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
                    if (Image != null)
                    {
                        Image.Dispose();
                        Image = null;
                    }
                    if (Region != null)
                    {
                        Region.Dispose();
                        Region = null;
                    }
                    disposed = true;
                }
            }

            // Use C# destructor syntax for finalization code.
            ~TmpObjWizardClassificatore()
            {
                // Simply call Dispose(false).
                Dispose(false);
            }

            #endregion IDisposable

        }

        private class ObjWizardClassificatore
        {
            public HClassGmm GmmHandle { get; set; }
            public HClassLUT ClassLUTHandle { get; set; }
            public List<TmpObjWizardClassificatore> ObjCampioni { get; set; }
        }

        private bool disposed = false;

        private object lockObj = new object();


        private ObjWizardClassificatore classificatore;

        private HTuple genParamNameClassLUT = new HTuple("rejection_threshold");
        private HTuple genParamValueClassLUT = null;

        public bool InitDone { get; set; } = false;

        public int DeltaTrain { get; set; } = 2;

        public bool ShowNone { get; set; }
        public bool ShowAll { get; set; } = true;
        public int ShowIndex { get; set; }

        public AlgoritmoGMM(int idCamera, int idStazione, double rejectionThreshold, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
            this.genParamValueClassLUT = new HTuple(rejectionThreshold);
            this.classificatore = new ObjWizardClassificatore();
        }

        #region Gestione File

        public void ClearWizardDir(string path)
        {
            if (System.IO.Directory.Exists(path))
                System.IO.Directory.Delete(path, true);
        }

        public void SaveFile(string path)
        {
            if (this.InitDone == true)
            {
                if (System.IO.Directory.Exists(path))
                    System.IO.Directory.Delete(path, true);

                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                SaveClassGmm(path, "GmmHandle.ggc", this.classificatore.GmmHandle);

                SaveAllWizardFiles(path, this.classificatore.ObjCampioni);
            }
        }

        public void LoadFile(string path)
        {
            this.classificatore.GmmHandle = LoadClassGmm(path, "GmmHandle.ggc");

            List<TmpObjWizardClassificatore> ObjCampioniTmp = null;

            ObjCampioniTmp = this.classificatore.ObjCampioni;
            LoadAllWizardFiles(path, out ObjCampioniTmp);
            this.classificatore.ObjCampioni = ObjCampioniTmp;
        }

        private void LoadAllWizardFiles(string path, out List<TmpObjWizardClassificatore> objCampioni)
        {
            objCampioni = new List<TmpObjWizardClassificatore>();

            if (System.IO.Directory.Exists(path))
            {
                string[] fileImg = System.IO.Directory.GetFiles(path, "*.tiff");
                string[] fileReg = System.IO.Directory.GetFiles(path, "*.reg");

                List<string> files = fileImg.Concat(fileReg).Where(k => Regex.IsMatch(System.IO.Path.GetFileName(k), "^[0-9]{4}.")).OrderBy(t => t).ToList();

                List<int> listIdx = files.Select(k => Convert.ToInt32(System.IO.Path.GetFileName(k).Substring(0, 4))).Distinct().ToList();

                foreach (var item in listIdx)
                {
                    TmpObjWizardClassificatore obj = new TmpObjWizardClassificatore();
                    obj.Image = LoadImage(path, string.Format("{0:0000}.tiff", item));
                    obj.Region = LoadRegion(path, string.Format("{0:0000}.reg", item));
                    HTuple t = LoadTuple(path, string.Format("{0:0000}.tup", item));

                    obj.R = t.DArr[0];
                    obj.G = t.DArr[1];
                    obj.B = t.DArr[2];

                    if (obj.Image != null && obj.Region != null)
                    {
                        objCampioni.Add(obj);
                    }
                    else
                    {
                        obj.Dispose();
                    }
                }
            }
        }

        private void SaveAllWizardFiles(string path, List<TmpObjWizardClassificatore> objCampioni)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            int idx = 0;
            foreach (var item in objCampioni)
            {
                if (item != null && item.Image != null && item.Region != null)
                {
                    SaveImage(path, string.Format("{0:0000}.tiff", idx), item.Image);
                    SaveRegion(path, string.Format("{0:0000}.reg", idx), item.Region);
                    SaveTuple(path, string.Format("{0:0000}.tup", idx), new HTuple(item.R, item.G, item.B));
                    idx++;
                }
            }
        }

        private void SaveTuple(string basePath, string fileName, HTuple tuple)
        {
            if (tuple != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                tuple.WriteTuple(file);
            }
        }

        private void SaveImage(string basePath, string fileName, HImage image)
        {
            if (image != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                image.WriteImage("tiff", 255, file);
            }
        }

        private void SaveRegion(string basePath, string fileName, HRegion region)
        {
            if (region != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                region.WriteRegion(file);
            }
        }

        private void SaveClassGmm(string basePath, string fileName, HClassGmm gmm)
        {
            if (gmm != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                gmm.WriteClassGmm(file);
            }
        }

        private void SaveClassLUT(string basePath, string fileName, HClassLUT lut)
        {
            if (lut != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                using (System.IO.FileStream myWriter = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
                {
                    lut.Serialize(myWriter);
                }
            }
        }

        private HTuple LoadTuple(string basePath, string fileName)
        {
            HTuple ret = null;
            string file = System.IO.Path.Combine(basePath, fileName);
            if (System.IO.File.Exists(file))
            {
                ret = HTuple.ReadTuple(file);
            }
            return ret;
        }

        private HImage LoadImage(string basePath, string fileName)
        {
            HImage ret = null;
            string file = System.IO.Path.Combine(basePath, fileName);
            if (System.IO.File.Exists(file))
            {
                ret = new HImage(file);
            }
            return ret;
        }

        private HRegion LoadRegion(string basePath, string fileName)
        {
            HRegion ret = null;
            string file = System.IO.Path.Combine(basePath, fileName);
            if (System.IO.File.Exists(file))
            {
                ret = new HRegion();
                ret.ReadRegion(file);
            }
            return ret;
        }

        private HClassGmm LoadClassGmm(string basePath, string fileName)
        {
            HClassGmm ret = null;
            string file = System.IO.Path.Combine(basePath, fileName);
            if (System.IO.File.Exists(file))
            {
                ret = new HClassGmm(file);
            }
            return ret;
        }

        private HClassLUT LoadClassLUT(string basePath, string fileName)
        {
            HClassLUT ret = null;
            string file = System.IO.Path.Combine(basePath, fileName);
            if (System.IO.File.Exists(file))
            {
                using (System.IO.FileStream myWriter = new System.IO.FileStream(file, System.IO.FileMode.Open))
                {
                    ret = new HClassLUT(HClassLUT.Deserialize(myWriter));
                }
            }
            return ret;
        }

        #endregion

        public void InitAlgoritmo()
        {
            lock (lockObj)
            {
                if (this.classificatore.GmmHandle != null)
                    this.classificatore.ClassLUTHandle = new HClassLUT(this.classificatore.GmmHandle, this.genParamNameClassLUT, this.genParamValueClassLUT);
            }
            this.InitDone = true;
        }

        public HClassLUT GetGMM()
        {
            return classificatore.ClassLUTHandle;
        }

        public List<TmpObjWizardClassificatore> GetObjCampioni()
        {
            return classificatore.ObjCampioni;
        }

        public void AddClassificatore(HImage image, HTuple roiData, int delta)
        {
            HClassGmm GMMHandle = null;

            HRegion classRegions2 = null;

            HRegion regionConfine = null;
            HRegion regionIntersection = null;

            double r = 0;
            double g = 0;
            double b = 0;

            try
            {
                classRegions2 = TrovaRegionCalssificatore2Pt1(image, roiData, out GMMHandle);

                regionConfine = new HRegion();
                regionConfine.GenRectangle1(roiData[0].D, roiData[1].D, roiData[2].D, roiData[3].D);

                regionIntersection = classRegions2.Intersection(regionConfine);

                GetMediaRGB(image, regionIntersection, out r, out g, out b);

                classificatore.ObjCampioni.Add(new TmpObjWizardClassificatore() { Image = image.Clone(), Region = regionIntersection, R = r, G = g, B = b, Delta = delta });
            }
            finally
            {
                GMMHandle?.Dispose();
                classRegions2?.Dispose();
                regionConfine?.Dispose();
            }
        }

        public bool TrainClassificatore()
        {
            bool ret = false;
            try
            {
                lock (lockObj)
                {
                    if (classificatore.GmmHandle != null)
                    {
                        classificatore.GmmHandle.Dispose();
                        classificatore.GmmHandle = null;
                    }
                    if (classificatore.ClassLUTHandle != null)
                    {
                        classificatore.ClassLUTHandle.Dispose();
                        classificatore.ClassLUTHandle = null;
                    }

                    if (classificatore.ObjCampioni.Count > 0)
                    {
                        classificatore.GmmHandle = new HClassGmm(3, classificatore.ObjCampioni.Count, 1, "full", "none", 3, 42);

                        HRegion emptyRegion = new HRegion();
                        emptyRegion.GenEmptyRegion();

                        for (int i = 0; i < classificatore.ObjCampioni.Count; i++)
                        {
                            var item = classificatore.ObjCampioni[i];

                            // creo una region per ogni classe (foto) con valorizzata solo quella della foto corrente.

                            HRegion region = i == 0 ? item.Region : emptyRegion.Clone();

                            for (int j = 1; j < classificatore.ObjCampioni.Count; j++)
                            {
                                region = region.ConcatObj(i == j ? item.Region : emptyRegion.Clone());
                            }

                            classificatore.GmmHandle.AddSamplesImageClassGmm(item.Image, region, new HTuple(0));
                        }

                        HTuple iter;
                        classificatore.GmmHandle.TrainClassGmm(100, 0.001, "training", 0.001, out iter);
                        classificatore.ClassLUTHandle = new HClassLUT(classificatore.GmmHandle, this.genParamNameClassLUT, this.genParamValueClassLUT);
                    }
                    else
                    {
                        ret = true;
                    }
                }
                ret = true;
            }
            catch (Exception)
            {
                ret = false;
            }
            return ret;
        }

        public void TestWizard(HImage image, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            ArrayList workingList = new ArrayList();
            DataType.ElaborateResult res = new DataType.ElaborateResult();

            HRegion regionClass = null;
            try
            {
                workingList.Add(new Utilities.ObjectToDisplay(image.Clone()));

                if (this.classificatore != null && this.classificatore.ClassLUTHandle != null)
                {
                    if (ShowNone == false)
                    {
                        regionClass = GetRegionCalssificatore(image);

                        workingList.Add(new Utilities.ObjectToDisplay(regionClass.Clone(), GetColorTrasparenza(Color.Green, 180), 2) { DrawMode = "fill" });
                    }
                }
            }
            catch (Exception)
            {
                res.Success = false;
            }
            finally
            {
                iconicList = workingList;
                result = res;

                regionClass?.Dispose();
            }
        }

        public void TestTrain(HImage image, HTuple roiData, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            ArrayList workingList = new ArrayList();
            DataType.ElaborateResult res = new DataType.ElaborateResult();

            HRegion regionClass = null;
            HRegion regionConfine = null;
            HRegion regionTmp1 = null;
            HRegion regionTmp2 = null;
            HRegion regionTmp3 = null;

            HRegion regionIntersection = null;
            try
            {
                workingList.Add(new Utilities.ObjectToDisplay(image.Clone()));

                if (this.classificatore != null && this.classificatore.ClassLUTHandle != null)
                {
                    if (ShowNone == false)
                    {
                        regionClass = GetRegionCalssificatore(image);
                        workingList.Add(new Utilities.ObjectToDisplay(regionClass.Clone(), GetColorTrasparenza(Color.Green, 180), 2) { DrawMode = "fill" });
                    }
                }

                regionConfine = new HRegion();
                regionConfine.GenRectangle1(roiData[0].D, roiData[1].D, roiData[2].D, roiData[3].D);

                regionTmp3 = TrovaRegionCalssificatore2(image, roiData);

                regionIntersection = regionTmp3.Intersection(regionConfine);

                workingList.Add(new Utilities.ObjectToDisplay(regionIntersection.Clone(), GetColorTrasparenza(Color.Magenta, 180), 2) { DrawMode = "fill" });
            }
            catch (Exception)
            {
                res.Success = false;
            }
            finally
            {
                iconicList = workingList;
                result = res;

                regionClass?.Dispose();
                regionConfine?.Dispose();
                regionTmp1?.Dispose();
                regionTmp2?.Dispose();
                regionTmp3?.Dispose();
                regionIntersection?.Dispose();
            }
        }

        private HRegion TrovaRegionCalssificatore2Pt1(HImage image, HTuple roiData, out HClassGmm GMMHandle)
        {
            GMMHandle = null;

            HImage imageR = null;
            HImage imageG = null;
            HImage imageB = null;

            HRegion regionR = null;
            HRegion regionG = null;
            HRegion regionB = null;

            HRegion regionIntersection = null;
            HRegion region = null;

            HRegion classRegions1 = null;
            HRegion classRegions2 = null;
            try
            {
                double row1 = roiData[0];
                double column1 = roiData[1];
                double row2 = roiData[2];
                double column2 = roiData[3];

                double rc = row1 + (row2 - row1) / 2.0;
                double cc = column1 + (column2 - column1) / 2.0;

                HTuple grayval = image.GetGrayval(rc, cc);

                HTuple minT = grayval - this.DeltaTrain;
                HTuple maxT = grayval + this.DeltaTrain;

                imageR = image.AccessChannel(1);
                imageG = image.AccessChannel(2);
                imageB = image.AccessChannel(3);

                regionR = imageR.Threshold(minT[0].D, maxT[0].D);
                regionG = imageG.Threshold(minT[1].D, maxT[1].D);
                regionB = imageB.Threshold(minT[2].D, maxT[2].D);

                regionIntersection = regionR.Intersection(regionG);
                region = regionIntersection.Intersection(regionB);

                GMMHandle = new HClassGmm(3, 1, 1, "full", "none", 3, 42);
                GMMHandle.AddSamplesImageClassGmm(image, region, 0.0);

                classRegions1 = TestGMM(GMMHandle, image);

                GMMHandle.AddSamplesImageClassGmm(image, classRegions1, 0.0);

                classRegions2 = TestGMM(GMMHandle, image);
            }
            finally
            {
                imageR?.Dispose();
                imageG?.Dispose();
                imageB?.Dispose();

                regionR?.Dispose();
                regionG?.Dispose();
                regionB?.Dispose();

                regionIntersection?.Dispose();
                region?.Dispose();

                classRegions1?.Dispose();
            }

            return classRegions2;
        }

        private HRegion TrovaRegionCalssificatore2(HImage image, HTuple roiData)
        {
            HClassGmm GMMHandle = null;

            HRegion classRegions2 = null;
            HRegion classRegions3 = null;
            try
            {
                classRegions2 = TrovaRegionCalssificatore2Pt1(image, roiData, out GMMHandle);

                GMMHandle.AddSamplesImageClassGmm(image, classRegions2, 0.0);

                classRegions3 = TestGMM(GMMHandle, image);
            }
            finally
            {
                GMMHandle?.Dispose();
                classRegions2?.Dispose();
            }

            return classRegions3;
        }

        private void GetMediaRGB(HImage image, HRegion regionIntersection, out double r, out double g, out double b)
        {
            HImage imageR = null;
            HImage imageG = null;
            HImage imageB = null;

            r = 0;
            g = 0;
            b = 0;

            try
            {
                regionIntersection.GetRegionPoints(out HTuple rows, out HTuple columns);

                imageR = image.AccessChannel(1);
                imageG = image.AccessChannel(2);
                imageB = image.AccessChannel(3);

                HTuple grayvalR = imageR.GetGrayval(rows, columns);
                HTuple grayvalG = imageG.GetGrayval(rows, columns);
                HTuple grayvalB = imageB.GetGrayval(rows, columns);

                r = grayvalR.TupleMean();
                g = grayvalG.TupleMean();
                b = grayvalB.TupleMean();
            }
            finally
            {
                imageR?.Dispose();
                imageG?.Dispose();
                imageB?.Dispose();
            }
        }

        //private HRegion GetRegionCalssificatore(HImage image)
        //{
        //    HRegion regionClass = null;

        //    HRegion ret = null;
        //    try
        //    {
        //        regionClass = this.classificatore.ClassLUTHandle.ClassifyImageClassLut(image);
        //        if (ShowAll)
        //        {
        //            ret = regionClass.Clone();
        //        }
        //        else
        //        {
        //            ret = regionClass.SelectObj(ShowIndex + 1);
        //        }
        //    }
        //    finally
        //    {
        //        regionClass?.Dispose();
        //    }
        //    return ret;
        //}

        private HRegion GetRegionCalssificatore(HImage image)
        {
            HRegion ret = null;
            try
            {
                if (ShowAll)
                {
                    ret = this.classificatore.ClassLUTHandle.ClassifyImageClassLut(image);
                }
                else
                {
                    if (this.classificatore.ObjCampioni?.Count > 0)
                    {
                        TmpObjWizardClassificatore obj = this.classificatore.ObjCampioni[ShowIndex];
                        ret = TrovaRegionCalssificatore(obj.Image, obj.Region, image);
                    }
                }
            }
            finally
            {

            }
            return ret;
        }

        private HRegion TestGMM(HClassGmm GMMHandle, HImage image)
        {
            HClassLUT classLUTHandle = null;
            HRegion classRegions = null;
            try
            {
                HTuple iter;
                GMMHandle.TrainClassGmm(100, 0.001, "training", 0.001, out iter);
                classLUTHandle = new HClassLUT(GMMHandle, this.genParamNameClassLUT, this.genParamValueClassLUT);

                classRegions = classLUTHandle.ClassifyImageClassLut(image);
            }
            finally
            {
                classLUTHandle?.Dispose();
            }

            return classRegions;
        }



        private HRegion TrovaRegion(HImage image, HTuple roiData)
        {
            double row1 = roiData[0];
            double column1 = roiData[1];
            double row2 = roiData[2];
            double column2 = roiData[3];

            double rc = row1 + (row2 - row1) / 2.0;
            double cc = column1 + (column2 - column1) / 2.0;

            double dimRect = 1;

            HRegion r = new HRegion();
            r.GenRectangle1(rc, cc, rc + dimRect, cc + dimRect);

            return TrovaRegionCalssificatore(image, r, image);
        }


        private HRegion TrovaRegionCalssificatore(HImage image, HRegion region, HImage imgTest)
        {
            HClassGmm GMMHandle = null;
            HClassLUT classLUTHandle = null;
            HRegion classRegions = null;
            try
            {
                GMMHandle = new HClassGmm(3, 1, 1, "full", "none", 3, 42);
                GMMHandle.AddSamplesImageClassGmm(image, region, 0.0);

                HTuple iter;
                GMMHandle.TrainClassGmm(100, 0.001, "training", 0.001, out iter);
                classLUTHandle = new HClassLUT(GMMHandle, this.genParamNameClassLUT, this.genParamValueClassLUT);

                classRegions = classLUTHandle.ClassifyImageClassLut(imgTest);
            }
            finally
            {
                GMMHandle?.Dispose();
                classLUTHandle?.Dispose();
            }

            return classRegions;
        }





        #region IDisposable

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
        ~AlgoritmoGMM()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}
