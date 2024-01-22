using System;
using HalconDotNet;

namespace ViewROI
{
    /// <summary>
    /// This class demonstrates one of the possible implementations for a 
    /// circular ROI. ROICircle inherits from the base class ROI and 
    /// implements (besides other auxiliary methods) all virtual methods 
    /// defined in ROI.cs.
    /// </summary>
    public class ROIBulleye : ROI
    {

        private const int MULT_DISEGNI = 2;

        private double radius1 = 50;
        private double radius2 = 60;
        private double row1, col1;  // first handle
        private double row2, col2;  // first handle
        private double midR, midC;  // second handle


        public ROIBulleye()
        {
            NumHandles = 3; // one at corner of circle + midpoint
            activeHandleIdx = 0;
        }



        /// <summary>Creates a new ROI instance at the mouse position</summary>
        public override void createROI(double midX, double midY)
        {
            midR = midY;
            midC = midX;

            radius1 = 50;
            radius2 = 100;

            row1 = midR;
            col1 = midC + radius1;
            row2 = midR;
            col2 = midC + radius2;
        }

        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window)
        {
            window.DispCircle(midR, midC, radius1);
            window.DispCircle(midR, midC, radius2);
            window.DispRectangle2(row1, col1, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
            window.DispRectangle2(row2, col2, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
            window.DispRectangle2(midR, midC, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
        }

        /// <summary> 
        /// Returns the distance of the ROI handle being
        /// closest to the image point(x,y)
        /// </summary>
        public override double distToClosestHandle(double x, double y)
        {
            double max = 10000;
            double[] val = new double[NumHandles];

            val[0] = HMisc.DistancePp(y, x, midR, midC); // midpoint 
            val[1] = HMisc.DistancePp(y, x, row1, col1); // border handle 1
            val[2] = HMisc.DistancePp(y, x, row2, col2); // border handle 2

            for (int i = 0; i < NumHandles; i++)
            {
                if (val[i] < max)
                {
                    max = val[i];
                    activeHandleIdx = i;
                }
            }// end of for 
            return val[activeHandleIdx];
        }

        /// <summary> 
        /// Paints the active handle of the ROI object into the supplied window 
        /// </summary>
        public override void displayActive(HalconDotNet.HWindow window)
        {

            switch (activeHandleIdx)
            {
                case 0:
                    window.DispRectangle2(midR, midC, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
                    break;
                case 1:
                    window.DispRectangle2(row1, col1, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
                    break;
                case 2:
                    window.DispRectangle2(row2, col2, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
                    break;
            }
        }

        /// <summary>Gets the HALCON region described by the ROI</summary>
        public override HRegion getRegion()
        {
            HRegion region1 = new HRegion();
            region1.GenCircle(midR, midC, radius1);

            HRegion region2 = new HRegion();
            region2.GenCircle(midR, midC, radius2);

            HRegion region = new HRegion();

            if (radius1 > radius2)
                region = region1.Difference(region2);
            else
                region = region2.Difference(region1);

            return region;
        }

        /// <summary>
        /// Gets the model information described by 
        /// the  ROI
        /// </summary> 
        public override HTuple getModelData()
        {
            return new HTuple(new double[] { midR, midC, radius1, radius2 });
        }

        /// <summary>
        /// Set the model information described by 
        /// the  ROI
        /// </summary> 
        public override void setModelData(HTuple data)
        {
            if (data.DArr.Length >= 4)
            {
                midR = data.DArr[0];
                midC = data.DArr[1];
                radius1 = data.DArr[2];
                radius2 = data.DArr[3];

                row1 = midR;
                col1 = midC + radius1;
                row2 = midR;
                col2 = midC + radius2;

            }
        }

        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        public override void moveByHandle(double newX, double newY)
        {
            HTuple distance;
            double shiftX, shiftY;

            switch (activeHandleIdx)
            {
                case 0: // midpoint 

                    shiftY = midR - newY;
                    shiftX = midC - newX;

                    midR = newY;
                    midC = newX;

                    row1 -= shiftY;
                    col1 -= shiftX;

                    row2 -= shiftY;
                    col2 -= shiftX;

                    break;
                case 1: // handle at circle border 1

                    row1 = newY;
                    col1 = newX;
                    HOperatorSet.DistancePp(new HTuple(row1), new HTuple(col1),
                                            new HTuple(midR), new HTuple(midC),
                                            out distance);

                    radius1 = distance[0].D;

                    break;
                case 2: // handle at circle border 2

                    row2 = newY;
                    col2 = newX;
                    HOperatorSet.DistancePp(new HTuple(row2), new HTuple(col2),
                                            new HTuple(midR), new HTuple(midC),
                                            out distance);

                    radius2 = distance[0].D;

                    break;
            }
        }
    }//end of class
}//end of namespace
