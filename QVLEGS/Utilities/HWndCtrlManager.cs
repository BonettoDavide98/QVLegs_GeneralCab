using HalconDotNet; 
using System.Collections;
using System.Windows.Forms;
using ViewROI;
using static QVLEGS.Utilities.UCHWndCtrlManager;

namespace QVLEGS.Utilities
{
    public class HWndCtrlManager
    {

        public HWindowControl hWindowControl { get { return ucHWndCtrlManager.hWindowControl; } }

        private Panel panel = null;

        private UCHWndCtrlManager ucHWndCtrlManager = null;

        public HWndCtrlManager(Panel panel, DataType.Impostazioni config, object repaintLock) : this(panel, true, true, config, repaintLock) { }

        public HWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu, DataType.Impostazioni config, object repaintLock) : this(panel, true, true, true, config, repaintLock) { }

        public HWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu, bool showStringMessage, DataType.Impostazioni config, object repaintLock)
        {
            this.panel = panel;

            ucHWndCtrlManager = new UCHWndCtrlManager();
            ucHWndCtrlManager.Init(enableMiddleMoveScroll, showMenu, showStringMessage, config, repaintLock);
            panel.Controls.Add(this.ucHWndCtrlManager);

            ucHWndCtrlManager.Dock = DockStyle.Fill;

            //ucHWndCtrlManager.Dock = DockStyle.None;
            //ucHWndCtrlManager.Size = new Size(panel.Width, panel.Height);
            //ucHWndCtrlManager.Location = new Point(0, 0);
            //ucHWndCtrlManager.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        public void SetOnRoiUpdate(OnRoiUpdateDelegate del)
        {
            ucHWndCtrlManager.SetOnRoiUpdate(del);
        }


        public void SetBrushRubberSize(int value)
        {
            ucHWndCtrlManager.SetBrushRubberSize(value);
        }

        public void NessunaModalita()
        {
            ucHWndCtrlManager.NessunaModalita();
        }

        public void SetDraw(bool draw, ToolType tool)
        {
            ucHWndCtrlManager.SetDraw(draw, tool);
        }

        public void SetRoi(ROI roi, int roiId)
        {
            ucHWndCtrlManager.SetRoi(roi, roiId);
        }

        public void SetRoiNoReset(ROI roi, int roiId)
        {
            ucHWndCtrlManager.SetRoiNoReset(roi, roiId);
        }
        //public void SetRegionNoReset(HRegion roi, int roiId)
        //{
        //    ucHWndCtrlManager.SetRegionNoReset(roi, roiId);
        //}
        public void SetRoiWithValue(ROI roi, int roiId)
        {
            ucHWndCtrlManager.SetRoiWithValue(roi, roiId);
        }

        public void SetRoiWithValueNoReset(ROI roi, int roiId)
        {
            ucHWndCtrlManager.SetRoiWithValueNoReset(roi, roiId);
        }

        public ROI GetActiveRoi()
        {
            return ucHWndCtrlManager.GetActiveRoi();
        }

        public void ResetRoi()
        {
            ucHWndCtrlManager.ResetRoi();
        }


        public void GetSetupOutputCamera(out ArrayList iconicVarList, out DataType.ElaborateResult result)
        {
            ucHWndCtrlManager.GetSetupOutputCamera(out iconicVarList, out result);
        }


        public void DisplayModelGraphics(HImage image)
        {
            ucHWndCtrlManager.DisplayModelGraphics(image);
        }

        public void DisplaySetupOutputCamera(ArrayList iconicVarList, DataType.ElaborateResult result)
        {
            ucHWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, result);
        }

        //public void DisplayRegolazioni(ArrayList iconicVarList)
        //{
        //    ucHWndCtrlManager.DisplayRegolazioni(iconicVarList);
        //}

        public void DisplayMask()
        {
            ucHWndCtrlManager.DisplayMask();
        }

        public void ClearMask(HRegion region, int index)
        {
            ucHWndCtrlManager.ClearMask(region, index);
        }

        public void SetMask(HRegion region)
        {
            ucHWndCtrlManager.SetMask(region);
        }

        public void SetMask(HRegion region, int index)
        {
            ucHWndCtrlManager.SetMask(region, index);
        }

        public HRegion GetMask()
        {
            return ucHWndCtrlManager.GetMask();
        }

        public HRegion GetMask(int index)
        {
            return ucHWndCtrlManager.GetMask(index);
        }

        public HImage GetImage()
        {
            return ucHWndCtrlManager.GetImage();
        }

        public int GetBlackWhite()
        {
            return ucHWndCtrlManager.index;
        }

        public void SetBlackWhite(int index)
        {
            ucHWndCtrlManager.index = index;
        }

        public void SetFeedbackIconVisible()
        {
            ucHWndCtrlManager.SetFeedbackIconVisible();
        }
    }
}