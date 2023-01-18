﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using UACSPopupForm;

namespace UACSControls
{
    public partial class conParkingCar : UserControl
    {
        public conParkingCar()
        {
            InitializeComponent();
            this.SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }



        private SaddleBase mySaddleInfo = new SaddleBase();
        private ParkingBase parkingInfo = new ParkingBase();

        public void conInit(Panel thePanelBay, string theSaddleNO, string tagServiceName)
        {
            try
            {
                this.MouseDown += new MouseEventHandler(conSaddle_visual_MouseUp);

            }
            catch (Exception ex)
            {
            }
        }

        void conSaddle_visual_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    
                }
                else
                {
                    FrmParkingDetail frm = new FrmParkingDetail();
                    frm.PackingInfo = parkingInfo;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }



        public delegate void carRefreshInvoke(ParkingBase theParkingBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown);

        public void refreshControl(ParkingBase theParkingBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown)
        {
            try
            {

                parkingInfo = theParkingBase;
                //取这块小区的大小
                //double X_Width = theArea.X_End - theArea.X_Start;

                //double Y_Height = theArea.Y_End - theArea.Y_Start;

                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth) / Convert.ToDouble(baySpaceX);

                //计算控件行车中心X，区分为X坐标轴向左或者向右
                double location_X = 0;
                if (xAxisRight == true)
                {
                    //location_X = Convert.ToDouble((theSaddle.X_Center - theSaddle.CarWidth / 2) - theArea.X_Start) * xScale;
                    location_X = Convert.ToDouble(theParkingBase.X_START) * xScale;
                }
                else
                {
                    //location_X = Convert.ToDouble(X_Width - (theSaddle.X_Center + theSaddle.SaddleLength / 2)) * xScale;
                    location_X = Convert.ToDouble(Convert.ToDouble(baySpaceX) - theParkingBase.X_START - theParkingBase.CarWidth) * xScale;
                }


                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelHeight) / Convert.ToDouble(baySpaceY);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                double location_Y = 0;
                if (yAxisDown == true)
                {
                    //location_Y = ((theSaddle.Y_Center - theSaddle.CarLength / 2) - theArea.Y_Start) * yScale;
                    location_Y = Convert.ToDouble(theParkingBase.Y_START) * yScale;
                }
                else
                {
                     //location_Y = (Y_Height - (theSaddle.Y_Center + theSaddle.SaddleWidth / 2)) * yScale;
                    location_Y = Convert.ToDouble(theParkingBase.Y_START) * yScale;
                   // location_Y = Convert.ToDouble(Convert.ToDouble(baySpaceY) - theParkingBase.Y_START) * yScale;
                }

                //修改鞍座控件的宽度和高度
                this.Width = Convert.ToInt32(theParkingBase.CarWidth * xScale);
                this.Height = Convert.ToInt32(theParkingBase.CarLength * yScale);

                //定位库位鞍座的坐标
                this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));

                ///5： 无车
                ///10：有车到达
                ///110：激光扫描开始
                ///120：入库激光扫描完成
                ///130：入库手持扫描完成
                ///210：出库激光扫描开始
                ///220：出库激光扫描完成
                ///东：E 西：W
                if (theParkingBase.PackingStatus == 5)
                {
                    this.Visible = false;
                }
                else if (theParkingBase.PackingStatus != 5 && theParkingBase.HeadPostion == "E" && theParkingBase.IsLoaded == 0)
                {
                    this.Visible = true;
                    this.BackgroundImage = global::UACSControls.Resource1.NCarEmpty;
                }
                else if (theParkingBase.PackingStatus != 5 && theParkingBase.HeadPostion == "W" && theParkingBase.IsLoaded == 0)
                {
                    this.Visible = true;
                    this.BackgroundImage = global::UACSControls.Resource1.SCarEmpty;
                }
                else if (theParkingBase.PackingStatus != 5 && theParkingBase.HeadPostion == "E" && theParkingBase.IsLoaded == 1)
                {
                    this.Visible = true;
                    this.BackgroundImage = global::UACSControls.Resource1.NCarWeight;
                }
                else if (theParkingBase.PackingStatus != 5 && theParkingBase.HeadPostion == "W" && theParkingBase.IsLoaded == 1)
                {
                    this.Visible = true;
                    this.BackgroundImage = global::UACSControls.Resource1.SCarWeight;
                }
                else
                { }

                toolTip1.IsBalloon = true;
                toolTip1.ReshowDelay = 0;
                toolTip1.SetToolTip(this,"停车位："+ theParkingBase.ParkingName + "\n"+
                                         "状态：" + theParkingBase.PackingStatusDesc() + "\n" +
                                         "车号："+ theParkingBase.Car_No
                    );

            }
            catch (Exception er)
            {

                throw;
            }
        }


       
    }
}
