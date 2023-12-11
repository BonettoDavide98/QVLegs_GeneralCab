using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QVLEGS.Algoritmi
{
    public class AlgoritmoMask : Algoritmo, IDisposable
    {

        private bool disposed = false;

        private object lockObj = new object();

        private HRegion regionMask = null;

        public AlgoritmoMask(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
        }

        #region Gestione File

        public void SaveFile(string path)
        {
            if (System.IO.Directory.Exists(path))
                System.IO.Directory.Delete(path, true);

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            SaveRegion(path, "RegionMask.reg", this.regionMask);
        }

        public void LoadFile(string path)
        {
            this.regionMask = LoadRegion(path, "RegionMask.reg");
        }

        private void SaveRegion(string basePath, string fileName, HRegion region)
        {
            if (region != null)
            {
                string file = System.IO.Path.Combine(basePath, fileName);
                region.WriteRegion(file);
            }
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

        #endregion

        public HRegion GetMask()
        {
            return this.regionMask?.Clone();
        }

        public void SetMask(HRegion mask)
        {
            this.regionMask?.Dispose();
            this.regionMask = null;

            if (mask != null)
                this.regionMask = mask.Clone();
        }

        public void TestWizard(HImage image, int numTest, DataType.PrevImageData prevImageData, out ArrayList iconicList, out DataType.ElaborateResult result)
        {
            ArrayList workingList = new ArrayList();
            DataType.ElaborateResult res = new DataType.ElaborateResult();

            try
            {
                workingList.Add(new Utilities.ObjectToDisplay(image.Clone()));
            }
            catch (Exception)
            {
                res.Success = false;
            }
            finally
            {
                iconicList = workingList;
                result = res;
            }
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
        ~AlgoritmoMask()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}
