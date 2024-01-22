using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ViewROI;

namespace QVLEGS.Utilities
{
    public partial class UCHWndCtrlManager : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
         );


        private DataType.Impostazioni config = null;
        public int index = 0;

        public UCHWndCtrlManager()
        {
            InitializeComponent();
        }


        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            btnOpenMenu.Visible = false;
            panelMenu.Visible = true;
        }



        public void Init(bool enableMiddleMoveScroll, bool showMenu, bool showStringMessage, DataType.Impostazioni config, object repaintLock)
        {
            this.config = config;
            this.repaintLock = repaintLock;

            this.hWindowControl = new HalconDotNet.HWindowControl();

            this.hWindowControl.Dock = DockStyle.Fill;

            panel.Controls.Add(this.hWindowControl);

            this.mView = new HWndCtrl(this.hWindowControl);
            this.roiController = new ROIController();
            this.mView.useROIController(this.roiController);

            this.enableMiddleMoveScroll = enableMiddleMoveScroll;
            this.mView.EnableMiddleMove = enableMiddleMoveScroll;
            this.mView.ShowStringMessage = showStringMessage;

            this.mView.NotifyIconObserver = new IconicDelegate(UpdateViewData);
            this.roiController.NotifyRCObserver = new IconicDelegate(UpdateViewData);

            this.hWindowControl.HMouseMove += hWindowControl_HMouseMove;
            this.hWindowControl.HMouseWheel += hWindowControl_HMouseWheel;
            this.hWindowControl.MouseEnter += hWindowControl_MouseEnter;

            btnOpenMenu.BringToFront();
            panelMenu.BringToFront();

            btnOpenMenu.Visible = showMenu;

            panel.Resize += Panel_Resize;

            CheckForResize(null);
            if (showMenu)
                SetMoveVisible(false);

            panelMenu.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelMenu.Width, panelMenu.Height, 25, 25));
        }



        public delegate void OnRoiUpdateDelegate(ROI roi);
        private OnRoiUpdateDelegate onRoiUpdate = null;

        public enum ToolType { None = 0, Brush = 1, Rubber = 2, ROI = 3 }

        public HWindowControl hWindowControl = null;
        private HWndCtrl mView = null;
        private ROIController roiController = null;

        private object repaintLock = null;
        private object imgLock = new object();

        private double brushRubberSize = 20;

        private bool draw = false;
        private ToolType tool = ToolType.None;

        private int prevW, prevH = 0;
        private bool resize = false;

        private bool enableMiddleMoveScroll;










        private bool resizeDone = false;

        //private HImage imageCamera = null;

        private ArrayList iconicVarListMemo = null;
        private DataType.ElaborateResult resultMemo = null;



        private void CheckForResize(ArrayList iconicVarList)
        {
            //if (!resizeDone)
            {
                int w = 1280, h = 1024;

                lock (imgLock)
                {
                    //if (imageCamera != null)
                    //{
                    //    imageCamera.Dispose();
                    //    imageCamera = null;
                    //}

                    if (iconicVarList != null && iconicVarList.Count > 0)
                    {
                        ObjectToDisplay obj = (ObjectToDisplay)iconicVarList[0];
                        HImage image = (HImage)(obj.IconicVar);
                        //if (image != null)
                        //    imageCamera = image.CopyImage();

                        if (image != null)
                            image.GetImageSize(out w, out h);
                    }

                }

                if (!(prevW == w && prevH == h) || this.resize)
                {
                    this.resize = false;
                    //this.hWindowControl.BeginInvoke(new MethodInvoker(() => { FitImage(w, h); }));

                    this.hWindowControl.BeginInvoke(new MethodInvoker(() => { FitImageSetPart(w, h); }));
                }

            }
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            this.resize = true;

            //CheckForResize(null);
        }

        public void SetOnRoiUpdate(OnRoiUpdateDelegate del)
        {
            onRoiUpdate = del;
        }

        public void SetDraw(bool draw, ToolType tool)
        {
            this.draw = draw;
            this.tool = tool;
            roiController.reset();
        }

        public void SetBrushRubberSize(int value)
        {
            this.brushRubberSize = value;
        }

        private void UpdateViewData(int val)
        {
            //HImage image = null;
            try
            {
                if (roiController.getActiveROI() != null)
                {
                    //lock (imgLock)
                    //{
                    //    image = imageCamera.CopyImage();
                    //}
                    //if (image != null)
                    {
                        int id = roiController.getActiveROI().getRoiId();

                        switch (val)
                        {
                            case ROIController.EVENT_CHANGED_ROI_SIGN:
                            case ROIController.EVENT_DELETED_ACTROI:
                            case ROIController.EVENT_DELETED_ALL_ROIS:
                            case ROIController.EVENT_MOVING_ROI:

                                //DisplayModelGraphics(image);
                                mView.repaint();

                                break;

                            case ROIController.EVENT_UPDATE_ROI:

                                //DisplayModelGraphics(image);
                                mView.repaint();

                                OnRoiUpdateDelegate del = onRoiUpdate;
                                if (del != null)
                                {
                                    del(roiController.getActiveROI());
                                }

                                break;

                            case HWndCtrl.ERR_READING_IMG:
                                MessageBox.Show("Problem occured while reading file! \n" + mView.exceptionText, "Matching assistant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                }
                else
                {
                    if (val == ROIController.EVENT_DEACTIVATED_ROI)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void GetSetupOutputCamera(out ArrayList iconicVarList, out DataType.ElaborateResult result)
        {
            iconicVarList = Utilities.CommonUtility.CloneArrayList(this.iconicVarListMemo);
            result = this.resultMemo;
        }

        public void DisplayModelGraphics(HImage image)
        {
            ArrayList iconicVarList = new ArrayList();

            iconicVarList.Add(new ObjectToDisplay(image));

            DisplaySetupOutputCamera(iconicVarList, null);
        }

        public void DisplaySetupOutputCamera(ArrayList iconicVarList, DataType.ElaborateResult result, int index = 0)
        {
            this.iconicVarListMemo = iconicVarList;
            this.resultMemo = result;

            CheckForResize(iconicVarList);

            CommonUtility.DisplayRegolazioni(iconicVarList, mView, hWindowControl, this.repaintLock);
            if (result != null)
                CommonUtility.DisplayResult(result, hWindowControl, repaintLock);

            if (tool == ToolType.Brush || tool == ToolType.Rubber)
                DisplayMask(index);
        }

        //public void DisplayRegolazioni(ArrayList iconicVarList)
        //{
        //    CommonUtility.DisplayRegolazioni(iconicVarList, mView, hWindowControl, this.repaintLock);
        //}




        private void hWindowControl_HMouseMove(object sender, HMouseEventArgs e)
        {
            try
            {
                if (draw)
                {
                    //HImage image = null;

                    //lock (imgLock)
                    //{
                    //    if (imageCamera != null)
                    //        image = imageCamera.CopyImage();
                    //}

                    //if (image != null)
                    {
                        HRegion circle = new HRegion(e.Y, e.X, this.brushRubberSize);

                        //if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        //{
                        //    AddMaskPart(circle);
                        //}
                        //else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        //{
                        //    RemoveMaskPart(circle);
                        //}

                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            if (this.tool == ToolType.Brush)
                                AddMaskPart(circle);
                            else if (this.tool == ToolType.Rubber)
                                RemoveMaskPart(circle);

                            circle.Dispose();
                            circle = null;
                        }

                        DisplayMask(e.X, e.Y, index);
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void hWindowControl_MouseEnter(object sender, EventArgs e)
        {
            this.hWindowControl.Focus();
        }

        private void hWindowControl_HMouseWheel(object sender, HMouseEventArgs e)
        {
            if (draw)
            {
                this.brushRubberSize += e.Delta * SystemInformation.MouseWheelScrollLines / 120;

                if (this.brushRubberSize < 10)
                    this.brushRubberSize = 10;

                DisplayMask(e.X, e.Y);
            }
            else
            {
                if (enableMiddleMoveScroll)
                {
                    if (e.Delta > 0)
                        this.ZoomPiu(e.X, e.Y);
                    else
                        this.ZoomMeno(e.X, e.Y);
                }
            }
        }

        private void FitImage(int w, int h)
        {
            try
            {
                prevW = w;
                prevH = h;

                Rectangle result = new Rectangle();
                Size imageSize = new Size(w, h);
                float ratio = Math.Min((float)this.panel.ClientSize.Width / (float)imageSize.Width, (float)this.panel.ClientSize.Height / (float)imageSize.Height);
                result.Width = (int)(imageSize.Width * ratio);
                result.Height = (int)(imageSize.Height * ratio);
                result.X = (this.panel.ClientSize.Width - result.Width) / 2;
                result.Y = (this.panel.ClientSize.Height - result.Height) / 2;

                //Debug.WriteLine($"result.X = {result.X}, result.Y = {result.Y}");

                this.hWindowControl.Width = result.Width;
                this.hWindowControl.Height = result.Height;

                this.hWindowControl.Location = new Point(result.X, result.Y);
                this.resizeDone = true;

                lock (repaintLock)
                {
                    mView.repaint();
                }
            }
            catch (Exception) { }
        }

        private void FitImageSetPart(int w, int h)
        {
            try
            {
                prevW = w;
                prevH = h;

                Rectangle result = new Rectangle();
                Size imageSize = new Size(w, h);
                float ratio = Math.Min((float)this.panel.ClientSize.Width / (float)imageSize.Width, (float)this.panel.ClientSize.Height / (float)imageSize.Height);
                result.Width = (int)(imageSize.Width * ratio);
                result.Height = (int)(imageSize.Height * ratio);
                result.X = (this.panel.ClientSize.Width - result.Width) / 2;
                result.Y = (this.panel.ClientSize.Height - result.Height) / 2;

                //Debug.WriteLine($"result.X = {result.X}, result.Y = {result.Y}");

                this.hWindowControl.Width = result.Width;
                this.hWindowControl.Height = result.Height;

                this.hWindowControl.Location = new Point(result.X, result.Y);
                this.resizeDone = true;

                lock (repaintLock)
                {
                    mView.repaint();
                }

                double dx = result.X / ratio;
                double dy = result.Y / ratio;

                this.mView.rectMainSetPart = result;
                this.mView.ratioMainSetPart = ratio;
                //this.hWindowControl.HalconWindow.SetPart(-dy, -dx, h + dy, w + dx);

                System.Drawing.Rectangle rect = this.hWindowControl.ImagePart;
                rect.Y = (int)-dy;
                rect.X = (int)-dx;
                rect.Height = (int)(h + 2 * dy);
                rect.Width = (int)(w + 2 * dx);
                this.hWindowControl.ImagePart = rect;

                this.mView.setImagePart(0, 0, h, w);

                lock (repaintLock)
                {
                    mView.repaint();
                }

            }
            catch (Exception ex) { }
        }

        public void DisplayMask(int index = 0)
        {
            DisplayMask(-1, -1, index);
        }

        //private void DisplayMask2(double x, double y)
        //{
        //    HImage image = null;

        //    lock (imgLock)
        //    {
        //        if (imageCamera != null)
        //            image = imageCamera.CopyImage();
        //    }

        //    if (image != null)
        //    {
        //        ArrayList iconicVarList = new ArrayList();

        //        iconicVarList.Add(new Utilities.ObjectToDisplay(image));

        //        HRegion mask = GetMask();

        //        if (mask != null)
        //            iconicVarList.Add(new Utilities.ObjectToDisplay(mask.Clone(), "#FFFF0080", 1) { DrawMode = "fill" });

        //        if (x >= 0 && y >= 0)
        //        {
        //            HRegion circle = new HRegion(y, x, this.brushRubberSize);
        //            if (this.tool == ToolType.Brush)
        //                iconicVarList.Add(new Utilities.ObjectToDisplay(circle, "#FFFF0090", 1) { DrawMode = "fill" });
        //            else if (this.tool == ToolType.Rubber)
        //                iconicVarList.Add(new Utilities.ObjectToDisplay(circle, "#FF000090", 1) { DrawMode = "fill" });
        //        }

        //        Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mView, hWindowControl, repaintLock);
        //    }
        //}

        private void DisplayMask(double x, double y, int index = 0)
        {
            //HImage image = null;

            //lock (imgLock)
            //{
            //    if (imageCamera != null)
            //        image = imageCamera.CopyImage();
            //}

            //if (image != null)
            {
                mView.repaint();

                //mView.changeGraphicSettings(GraphicsContext.GC_DRAWMODE, obj.DrawMode);
                //if (int.TryParse(obj.IconicColor, out int tmp))
                //    mView.changeGraphicSettings(GraphicsContext.GC_COLORED, tmp);
                //else
                //    mView.changeGraphicSettings(GraphicsContext.GC_COLOR, obj.IconicColor);
                //mView.changeGraphicSettings(GraphicsContext.GC_LINEWIDTH, obj.IconicLineWidth);

                //ArrayList iconicVarList = new ArrayList();

                //iconicVarList.Add(new Utilities.ObjectToDisplay(image));

                HRegion mask = GetMask();

                if (mask != null)
                {
                    if (index == 0)
                    {
                        //iconicVarList.Add(new Utilities.ObjectToDisplay(mask.Clone(), "#FFFF0080", 1) { DrawMode = "fill" });

                        hWindowControl.HalconWindow.SetDraw("fill");
                        hWindowControl.HalconWindow.SetColor("#FFFF0080");
                        hWindowControl.HalconWindow.DispObj(mask.Clone());
                    }
                    else if(index == 1)
                    {
                        hWindowControl.HalconWindow.SetDraw("fill");
                        hWindowControl.HalconWindow.SetColor("#FF00FF80");
                        hWindowControl.HalconWindow.DispObj(mask.Clone());
                    } else
                    {
                        hWindowControl.HalconWindow.SetDraw("fill");
                        hWindowControl.HalconWindow.SetColor("#FF888080");
                        hWindowControl.HalconWindow.DispObj(mask.Clone());
                    }
                }

                if (x >= 0 && y >= 0)
                {
                    HRegion circle = new HRegion(y, x, this.brushRubberSize);
                    if (this.tool == ToolType.Brush)
                    {
                        if(index == 0)
                        {
                            //iconicVarList.Add(new Utilities.ObjectToDisplay(circle, "#FFFF0090", 1) { DrawMode = "fill" });

                            hWindowControl.HalconWindow.SetDraw("fill");
                            hWindowControl.HalconWindow.SetColor("#FFFF0090");
                            hWindowControl.HalconWindow.DispObj(circle);
                        } else if(index == 1)
                        {
                            hWindowControl.HalconWindow.SetDraw("fill");
                            hWindowControl.HalconWindow.SetColor("#FF00FF90");
                            hWindowControl.HalconWindow.DispObj(circle);
                        } else
                        {
                            hWindowControl.HalconWindow.SetDraw("fill");
                            hWindowControl.HalconWindow.SetColor("#FF999090");
                            hWindowControl.HalconWindow.DispObj(circle);
                        }
                    }
                    else if (this.tool == ToolType.Rubber)
                    {
                        //iconicVarList.Add(new Utilities.ObjectToDisplay(circle, "#FF000090", 1) { DrawMode = "fill" });

                        hWindowControl.HalconWindow.SetDraw("fill");
                        hWindowControl.HalconWindow.SetColor("#FF000090");
                        hWindowControl.HalconWindow.DispObj(circle);
                    }
                }

                //Utilities.CommonUtility.DisplayRegolazioni(iconicVarList, mView, hWindowControl, repaintLock);
            }
        }

        public void SetRoi(ROI roi, int roiId)
        {
            lock (repaintLock)
            {
                roiController.reset();
                roiController.setROIShape(roi, roiId);
            }
            SetMoveVisible(true);
        }

        public void SetRoiNoReset(ROI roi, int roiId)
        {
            lock (repaintLock)
            {
                roiController.setROIShape(roi, roiId);
            }
            SetMoveVisible(true);
        }
        //public void SetRegionNoReset(HRegion roi, int roiId)
        //{
        //    lock (repaintLock)
        //    {
        //        roiController.setROIShape(roi, roiId);
        //    }
        //    SetMoveVisible(true);
        //}

        public void SetRoiWithValue(ROI roi, int roiId)
        {
            lock (repaintLock)
            {
                roiController.reset();
                roi.setRoiId(roiId);
                this.roiController.ROIList.Add(roi);
            }
            SetMoveVisible(true);
        }

        public void SetRoiWithValueNoReset(ROI roi, int roiId)
        {
            lock (repaintLock)
            {
                roi.setRoiId(roiId);
                this.roiController.ROIList.Add(roi);
            }
            SetMoveVisible(true);
        }

        public ROI GetActiveRoi()
        {
            return roiController.getActiveROI();
        }

        public void ResetRoi()
        {
            roiController.reset();

            SetMoveVisible(false);
        }

        public void ApplyMask()
        {
            lock (repaintLock)
            {
                ROI roi = this.roiController.getActiveROI();
                if (roi != null)
                {
                    HRegion region = roi.getRegion();
                    AddMaskPart(region);
                    region.Dispose();
                    region = null;
                    //roiController.reset();
                }
            }

            DisplayMask(index);
        }

        public void ZoomPiu(double x, double y)
        {
            lock (repaintLock)
            {
                mView.zoomByGUIHandleScaled(0.9, x, y);
                mView.repaint();
            }
        }

        public void ZoomPiu()
        {
            lock (repaintLock)
            {
                mView.zoomByGUIHandleScaled(0.9);
                mView.repaint();
            }
        }

        public void ZoomMeno(double x, double y)
        {
            lock (repaintLock)
            {
                mView.zoomByGUIHandleScaled(1 / 0.9, x, y);
                mView.repaint();
            }
        }

        public void ZoomMeno()
        {
            lock (repaintLock)
            {
                mView.zoomByGUIHandleScaled(1 / 0.9);
                mView.repaint();
            }
        }

        public void Muovi()
        {
            mView.setViewState(HWndCtrl.MODE_VIEW_MOVE);
        }

        public void NessunaModalita()
        {
            mView.setViewState(HWndCtrl.MODE_VIEW_NONE);
        }

        public void ResetZoom()
        {
            lock (repaintLock)
            {
                mView.resetAll();
                //mView.setViewState(HWndCtrl.MODE_VIEW_NONE);
                mView.repaint();
            }
        }

        private Dictionary<int,HRegion> maskRegion = new Dictionary<int, HRegion>();

        public void ClearMask()
        {
            try
            {
                if (maskRegion != null)
                {
                    maskRegion[0].Dispose();
                    maskRegion[1].Dispose();
                    maskRegion[2].Dispose();
                    maskRegion = null;
                }
            } catch { }
        }

        private void AddMaskPart(HRegion region)
        {
            if (!maskRegion.ContainsKey(index))
            {
                maskRegion.Add(index, region.CopyObj(1, -1));
            }
            else
            {
                if(maskRegion[index] == null)
                    maskRegion[index] = region.CopyObj(1, -1);
                else
                    maskRegion[index] = maskRegion[index].Union2(region);
            }
        }

        private void RemoveMaskPart(HRegion region)
        {
            if (maskRegion != null && maskRegion[index] != null)
            {
                maskRegion[index] = maskRegion[index].Difference(region);
            }
        }

        public void ClearMask(HRegion region, int index)
        {
            if (maskRegion != null && maskRegion[index] != null)
            {
                maskRegion[index] = maskRegion[index].Difference(maskRegion[index]);
            }
        }

        public void SetMask(HRegion region)
        {
            try
            {
                maskRegion[index] = region;
            }
            catch
            {
                maskRegion.Add(index, region);
            }
        }

        public void SetMask(HRegion region, int index)
        {
            try
            {
                maskRegion[index] = region;
            }
            catch
            {
                maskRegion.Add(index, region);
            }
        }

        public HRegion GetMask()
        {
            return maskRegion[index];
        }

        public HRegion GetMask(int index)
        {
            return maskRegion[index];
        }

        public HImage GetImage()
        {
            HImage ret = null;
            lock (imgLock)
            {
                if (iconicVarListMemo != null && iconicVarListMemo.Count > 0)
                {
                    ObjectToDisplay obj = (ObjectToDisplay)iconicVarListMemo[0];
                    HImage image = (HImage)(obj.IconicVar);
                    if (image != null)
                        ret = image.CopyImage();


                }
            }
            return ret;
        }

        private void btnZoomPiu_Click(object sender, EventArgs e)
        {
            this.ZoomPiu();
        }

        private void btnZoomMeno_Click(object sender, EventArgs e)
        {
            this.ZoomMeno();
        }

        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            this.ResetZoom();
            //chbMuovi.Checked = false;
        }

        private void chbMuovi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMuovi.Checked)
            {
                // Cursor = Cursors.SizeAll;
                this.Muovi();
            }
            else
            {
                this.NessunaModalita();
            }
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            btnOpenMenu.Visible = true;
        }

        private void chbAnnotazioni_CheckedChanged(object sender, EventArgs e)
        {
            this.mView.ShowOnlyImages = !chbAnnotazioni.Checked;
            this.mView.repaint();
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            //panelMenu.Visible = false;
            //btnOpenMenu.Visible = true;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            HImage img = null;
            try
            {
                img = GetImage();
                if (img != null)
                {
                    DateTime d = DateTime.Now;

                    string path = System.IO.Path.Combine(this.config.PathDatiBase, "IMG_SAVE", "MANUAL");

                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(path);

                    string fileName = System.IO.Path.Combine(path, string.Format("{0}.tif", d.ToString("yyyyMMdd HH mm ss.fff")));

                    img.WriteImage("tiff", 255, fileName);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                img?.Dispose();
            }
        }

        private void btnCommenta_Click(object sender, EventArgs e)
        {
            HImage img = null;
            try
            {
                img = GetImage();
                if (img != null)
                {
                    string path = System.IO.Path.Combine(this.config.PathDatiBase, "IMG_SAVE", "ANNOTAZIONI");
                    FormFeedback formFeedback = new FormFeedback(img, path, this.config, repaintLock);
                    formFeedback.ShowDialog();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                img?.Dispose();
            }
        }

        private void SetMoveVisible(bool state)
        {
            if (state)
            {
                chbMuovi.Visible = true;
            }
            else
            {
                chbMuovi.Checked = true;
                chbMuovi.Visible = false;
            }
        }

        public void SetFeedbackIconVisible()
        {
            this.btnCommenta.Visible = true;
        }
    }
}
