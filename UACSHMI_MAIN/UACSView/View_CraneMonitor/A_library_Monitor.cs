using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACSControls;
using UACSDAL;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using UACSView.View_CraneMonitor;


namespace UACSView.View_CraneMonitor
{
    public partial class A_library_Monitor : FormBase
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        private conAreaModel AreaInStockZ12;
        private List<conCraneStatus> lstConCraneStatusPanel = new List<conCraneStatus>();
        private List<conCrane> listConCraneDisplay = new List<conCrane>();
        private List<conCrane> listConCraneDisplayB = new List<conCrane>();
        private List<string> listCraneNo = new List<string>();

        private FrmMoreStock form;
        private conAreaModel areaModel;
        private conUnitSaddleModel unitSaddleModel;
        private conParkingCarModel parkingCarModel;
        private CraneStatusInBay craneStatusInBay;

        private static FrmSeekCoil frmSeekCoil;
        private conStockSaddleModel saddleInStock_Z11_Z12;

        private bool isShowCurrentBayXY = false;    //是否显示鼠标位置的XY
        private bool tabActived = true;             //是否在当前画面显示
        private string craneNo_1_1 = "1";
        private string craneNo_1_2 = "2";
        private string craneNo_1_3 = "3";
        private string craneNo_1_4 = "4";

        //private const string D401EXIT = "D401-WC";
        //private const string D401ENTRY = "D401-WR";
        private const string D112ENTRY = "D112-WR";
        private const string D102EXIT = "D102-WCA";

        public A_library_Monitor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.Load += A_library_Monitor_Load;

            btnCrane_1_WaterStatus.Name = craneNo_1_1;
            btnCrane_2_WaterStatus.Name = craneNo_1_2;
            btnCrane_3_WaterStatus.Name = craneNo_1_3;

        }

        void btnCrane_1_WaterStatus_Click(object sender, EventArgs e)
        {
            //检查
            Button btn = (Button)sender;
            //if (!AreaInStockZ12.updataCraneWaterLevel(btn.Name))
            //{
            //    MessageBoxButtons btn1 = MessageBoxButtons.OKCancel;
            //    DialogResult dr = MessageBox.Show(btn.Name + "#行车水位没有到达报警值，不能进行放水!", "提示", btn1, MessageBoxIcon.Asterisk);
            //    return;
            //}
            SubFrmLetOutWater frm = new SubFrmLetOutWater(btn.Name);
            frm.ShowDialog();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        void A_library_Monitor_Load(object sender, EventArgs e)
        {
            tagDataProvider.ServiceName = "iplature";
            label2.Text = "A\n跨";
            label2.Location = new Point(4,this.panelZ11_Z12Bay.Height/3);
            label10.Text = "B\n跨";
            label10.Location = new Point(4, this.panelBBay.Height/3);
            areaModel = new conAreaModel();
            unitSaddleModel = new conUnitSaddleModel();
            parkingCarModel = new conParkingCarModel();
            craneStatusInBay = new CraneStatusInBay();

            AreaInStockZ12 = new conAreaModel();

            btnCrane_1_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_2_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_3_WaterStatus.Click += btnCrane_1_WaterStatus_Click;

            //行车显示控件配置
            conCrane1_1.InitTagDataProvide(constData.tagServiceName);
            conCrane1_1.CraneNO = craneNo_1_1;
            listConCraneDisplay.Add(conCrane1_1);

            conCrane1_2.InitTagDataProvide(constData.tagServiceName);
            conCrane1_2.CraneNO = craneNo_1_2;
            listConCraneDisplay.Add(conCrane1_2);

            conCrane1_3.InitTagDataProvide(constData.tagServiceName);
            conCrane1_3.CraneNO = craneNo_1_3;
            listConCraneDisplayB.Add(conCrane1_3);

            conCrane1_4.InitTagDataProvide(constData.tagServiceName);
            conCrane1_4.CraneNO = craneNo_1_4;
            listConCraneDisplayB.Add(conCrane1_4);



            //---------------------行车状态控件配置-------------------------------
            conCraneStatus1_1.InitTagDataProvide(constData.tagServiceName);
            conCraneStatus1_1.CraneNO = craneNo_1_1;
            lstConCraneStatusPanel.Add(conCraneStatus1_1);

            conCraneStatus1_2.InitTagDataProvide(constData.tagServiceName);
            conCraneStatus1_2.CraneNO = craneNo_1_2;
            lstConCraneStatusPanel.Add(conCraneStatus1_2);

            conCraneStatus1_3.InitTagDataProvide(constData.tagServiceName);
            conCraneStatus1_3.CraneNO = craneNo_1_3;
            lstConCraneStatusPanel.Add(conCraneStatus1_3);

            conCraneStatus1_4.InitTagDataProvide(constData.tagServiceName);
            conCraneStatus1_4.CraneNO = craneNo_1_4;
            lstConCraneStatusPanel.Add(conCraneStatus1_4);


            //---------------------行车tag配置--------------------------------
            craneStatusInBay.InitTagDataProvide(constData.tagServiceName);
            craneStatusInBay.AddCraneNO(craneNo_1_1);
            craneStatusInBay.AddCraneNO(craneNo_1_2);
            craneStatusInBay.AddCraneNO(craneNo_1_3);
            craneStatusInBay.AddCraneNO(craneNo_1_4);
            craneStatusInBay.SetReady();


            this.panelZ11_Z12Bay.Paint += panelZ11_Z22Bay_Paint;
            this.panelBBay.Paint += panelZ11_Z22Bay_Paint;

            //预先加载
            timer_InitializeLoad.Enabled = true;
            timer_InitializeLoad.Interval = 1500;
        }

        private void LoadAreaInfo()
        {
            AreaInStockZ12.conInit(panelZ11_Z12Bay,
                constData.bayNo_A,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown,
                 AreaInfo.AreaType.AllType);

            areaModel.conInit(panelBBay,
                constData.bayNo_B,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelBBay.Width,
                panelBBay.Height,
                constData.xAxisRight,
                constData.yBxisDown,
                 AreaInfo.AreaType.AllType);
        }

        private void LoadUnitInfo()
        {
            //unitSaddleModel.conInit(panelZ11_Z12Bay,
            //    D112ENTRY, 
            //    constData.tagServiceName,
            //    constData.Z11_Z12BaySpaceX,
            //    constData.Z11_Z12BaySpaceY,
            //    panelZ11_Z12Bay.Width,
            //    panelZ11_Z12Bay.Height,
            //    constData.xAxisRight,
            //    constData.yAxisDown,
            //    constData.bayNo_A);

            //unitSaddleModel.conInit(panelZ11_Z12Bay,
            //    D102EXIT,
            //    constData.tagServiceName,
            //    constData.Z11_Z12BaySpaceX,
            //    constData.Z11_Z12BaySpaceY,
            //    panelZ11_Z12Bay.Width,
            //    panelZ11_Z12Bay.Height,
            //    constData.xAxisRight,
            //    constData.yAxisDown,
            //    constData.bayNo_A);

            //unitSaddleModel.conInit(panelZ11_Z12Bay,
            //   "MC1-WCA",
            //   constData.tagServiceName,
            //   constData.Z11_Z12BaySpaceX,
            //   constData.Z11_Z12BaySpaceY,
            //   panelZ11_Z12Bay.Width,
            //   panelZ11_Z12Bay.Height,
            //   constData.xAxisRight,
            //   constData.yAxisDown,
            //   constData.bayNo_A);
        }

        private void LoadParkingCarInfo()
        {
            parkingCarModel.conInit(panelZ11_Z12Bay,
                constData.bayNo_A,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown);

            parkingCarModel.conInit(panelBBay,
                constData.bayNo_B,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelBBay.Width,
                panelBBay.Height,
                constData.xAxisRight,
                constData.yBxisDown);
        }


        private void timer_InitializeLoad_Tick(object sender, EventArgs e)
        {

            LoadUnitInfo();
            LoadParkingCarInfo();
            LoadAreaInfo();

            Thread.Sleep(500);
            timerCrane.Enabled = true;
            timerArea.Enabled = true;
            timerUnit.Enabled = true;

            timerCrane.Interval = 1500;
            timerArea.Interval = 1500;
            timerUnit.Interval = 1500;

            timer_InitializeLoad.Enabled = false;

        }
        private void timerCrane_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return;
            }

            craneStatusInBay.getAllPLCStatusInBay(craneStatusInBay.lstCraneNO);

            if (this.Height < 10)
            {
                return;
            }

            try
            {

                //AreaInStockZ12.conInit(panelZ11_Z12Bay, constData.bayNo_A, SaddleBase.tagServiceName,
                //       constData.Z11_Z12BaySpaceX, constData.Z11_Z12BaySpaceY, panelZ11_Z12Bay.Width, panelZ11_Z12Bay.Height,
                //       constData.xAxisRight, constData.yAxisDown, AreaInfo.AreaType.StockArea);

                //AreaInStockZ12.conInit(panelBBay, constData.bayNo_B, SaddleBase.tagServiceName,
                //       constData.Z11_Z12BaySpaceX, constData.Z11_Z12BaySpaceY, panelZ11_Z12Bay.Width, panelZ11_Z12Bay.Height,
                //       constData.xAxisRight, constData.yAxisDown, AreaInfo.AreaType.StockArea);
                //-------------------------行车排水状态------------------------------------------               
                //getWaterStatus("3_1");
                //getWaterStatus("3_2");
                //getWaterStatus("3_3");//先不用

                //conCrane1_1.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_1) ? Color.Orange : SystemColors.Control;
                //conCrane1_2.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_2) ? Color.Orange : SystemColors.Control;
                //conCrane1_3.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_3) ? Color.Orange : SystemColors.Control;
                //conCrane1_4.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_4) ? Color.Orange : SystemColors.Control;
                //-------------------------行车水位报警------------------------------------------
                //btnCrane_1_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_1) ? Color.Red : (AreaInStockZ12.updataCraneWaterLevel(craneNo_1_1.Substring(2, 1)) ? SystemColors.Highlight : Color.LightSteelBlue);
                //btnCrane_2_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_2) ? Color.Red : AreaInStockZ12.updataCraneWaterLevel(craneNo_1_2.Substring(2, 1)) ? SystemColors.Highlight : Color.LightSteelBlue;
                //btnCrane_3_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_3) ? Color.Red : AreaInStockZ12.updataCraneWaterLevel(craneNo_1_3.Substring(2, 1)) ? SystemColors.Highlight : Color.LightSteelBlue;

                //btnCrane_1_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_1) ? Color.Red : Color.LightSteelBlue;
                //btnCrane_2_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_2) ? Color.Red : Color.LightSteelBlue;
                //btnCrane_3_WaterStatus.BackColor = AreaInStockZ12.updataCraneWaterLevel(craneNo_1_3) ? Color.Red : Color.LightSteelBlue;//先不用

                //--------------------------行车指令控件刷新------------------------------------------
                foreach (conCraneStatus conCraneStatusPanel in lstConCraneStatusPanel)
                {
                    conCraneStatus.RefreshControlInvoke ConCraneStatusPanel_Invoke = new conCraneStatus.RefreshControlInvoke(conCraneStatusPanel.RefreshControl);
                    conCraneStatusPanel.BeginInvoke(ConCraneStatusPanel_Invoke, new Object[] { craneStatusInBay.DicCranePLCStatusBase[conCraneStatusPanel.CraneNO].Clone() });
                }
                //--------------------------行车状态控件刷新-------------------------------------------
                foreach (conCrane conCraneVisual in listConCraneDisplay)
                {
                    conCrane.RefreshControlInvoke ConCraneVisual_Invoke = new conCrane.RefreshControlInvoke(conCraneVisual.RefreshControl);
                    conCraneVisual.BeginInvoke(ConCraneVisual_Invoke, new Object[] 
                    { craneStatusInBay.DicCranePLCStatusBase[conCraneVisual.CraneNO].Clone(), 
                         constData.Z11_Z12BaySpaceX,
                         constData.Z11_Z12BaySpaceY,
                         panelZ11_Z12Bay.Width,
                         panelZ11_Z12Bay.Height,
                         constData.xAxisRight,
                         constData.yAxisDown,
                         4560,         
                         panelZ11_Z12Bay 
                    });
                }

                foreach (conCrane conCraneVisual in listConCraneDisplayB)
                {
                    conCrane.RefreshControlInvoke ConCraneVisual_Invoke = new conCrane.RefreshControlInvoke(conCraneVisual.RefreshControl);
                    conCraneVisual.BeginInvoke(ConCraneVisual_Invoke, new Object[] 
                    { craneStatusInBay.DicCranePLCStatusBase[conCraneVisual.CraneNO].Clone(), 
                         constData.Z11_Z12BaySpaceX,
                         constData.Z11_Z12BaySpaceY,
                         panelBBay.Width,
                         panelBBay.Height,
                         constData.xAxisRight,
                         constData.yBxisDown,
                         4560,         
                         panelBBay 
                    });
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0},{1}", er.Message, er.Source));
                timerCrane.Enabled = false;
            }

        }

        private void timerArea_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return;
            }
            if (this.Height < 10)
            {
                return;
            }

            LoadAreaInfo();  
                    
            //-------------------------行车水位报警------------------------------------------
            foreach(conCrane conCraneVisual in listConCraneDisplay)
            {
                if (updataCraneWaterStatus(conCraneVisual.CraneNO))
                {
                    conCraneVisual.BackColor = Color.Orange;
                }
                else if (areaModel.updataCraneWaterLevel(conCraneVisual.CraneNO))
                {
                    conCraneVisual.BackColor = Color.Red;
                }
                else
                {
                    conCraneVisual.BackColor = SystemColors.Control;
                }
            }

            foreach (conCrane conCraneVisual in listConCraneDisplayB)
            {
                if (updataCraneWaterStatus(conCraneVisual.CraneNO))
                {
                    conCraneVisual.BackColor = Color.Orange;
                }
                else if (areaModel.updataCraneWaterLevel(conCraneVisual.CraneNO))
                {
                    conCraneVisual.BackColor = Color.Red;
                }
                else
                {
                    conCraneVisual.BackColor = SystemColors.Control;
                }
            }           
            //-------------------------光电门------------------------------------------------
            //btnCrane_1_WaterStatus.Text = areaModel.getPhotogateStatus("BC") ? "A跨BC区光电门：关" : "A跨BC区光电门：开";
            //btnCrane_1_WaterStatus.BackColor = areaModel.getPhotogateStatus("BC") ? Color.AliceBlue : Color.Red;
            //btnCrane_2_WaterStatus.Text = areaModel.getPhotogateStatus("CD") ? "A跨CD区光电门：关" : "A跨CD区光电门：开";
            //btnCrane_2_WaterStatus.BackColor = areaModel.getPhotogateStatus("CD") ? Color.AliceBlue : Color.Red;
            //btnCrane_3_WaterStatus.Text = areaModel.getPhotogateStatus("B-BC") ? "B跨BC区光电门：关" : "B跨BC区光电门：开";
            //btnCrane_3_WaterStatus.BackColor = areaModel.getPhotogateStatus("B-BC") ? Color.AliceBlue : Color.Red;
            //btnCrane_4_WaterStatus.Text = areaModel.getPhotogateStatus("B-CD") ? "B跨CD区光电门：关" : "B跨CD区光电门：开";
            //btnCrane_4_WaterStatus.BackColor = areaModel.getPhotogateStatus("B-CD") ? Color.AliceBlue : Color.Red;

        }

        private void timerUnit_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return;
            }
            if (this.Height < 10)
            {
                return;
            }

            //LoadUnitInfo();
            LoadParkingCarInfo();

        }

        private void timerClear_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return;
            }
            try
            {
                ClearMemory();
            }
            catch (Exception er)
            {
            }
        }

        private void timer_ShowXY_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return;
            }
            if (this.Height < 10)
            {
                return;
            }
            if (isShowCurrentBayXY)
            {
                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelZ11_Z12Bay.Width) / Convert.ToDouble(constData.Z11_Z12BaySpaceX);
                double xScaleB = Convert.ToDouble(panelBBay.Width) / Convert.ToDouble(constData.Z11_Z12BaySpaceX);
                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelZ11_Z12Bay.Height) / Convert.ToDouble(constData.Z11_Z12BaySpaceY);
                double yScaleB = Convert.ToDouble(panelBBay.Height) / Convert.ToDouble(constData.Z11_Z12BaySpaceY);

                Point p = this.panelZ11_Z12Bay.PointToClient(Control.MousePosition);
                Point pB = this.panelBBay.PointToClient(Control.MousePosition);
                //if (!(p.X <= this.panelZ11_Z12Bay.Location.X || p.X >= this.panelZ11_Z12Bay.Location.X + this.panelZ11_Z12Bay.Width ||
                //    p.Y < this.panelZ11_Z12Bay.Location.Y || p.Y >= this.panelZ11_Z12Bay.Location.Y + this.panelZ11_Z12Bay.Height))
                if (!(pB.X <= this.panelBBay.Location.X || pB.X >= this.panelBBay.Location.X + this.panelBBay.Width ||
                    pB.Y < this.panelBBay.Location.Y || pB.Y >= this.panelBBay.Location.Y + this.panelBBay.Height))
                {
                    //return;
                    //txtX.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(p.X) / xScale));
                    //txtY.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelZ11_Z12Bay.Height) - Convert.ToDouble(p.Y)) / yScale));
                    panel4.Visible = true;
                    txtXAB.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelBBay.Width) - Convert.ToDouble(pB.X)) / xScaleB));
                    txtYAB.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(pB.Y)) / yScaleB));
                }               
                //else if (!(pB.X <= panelBBay.Location.X || pB.X >= panelBBay.Location.X + this.panelBBay.Width || pB.Y < 0 || pB.Y >= this.panelBBay.Height))
                else if (!(p.X <= panelZ11_Z12Bay.Location.X || p.X >= panelZ11_Z12Bay.Location.X + this.panelZ11_Z12Bay.Width || p.Y < 0 || p.Y >= this.panelZ11_Z12Bay.Height))
                {
                    //return;
                    //txtXB.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(pB.X) / xScaleB));
                    //txtYB.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelBBay.Height) - Convert.ToDouble(pB.Y)) / yScaleB));
                    panel4.Visible = true;
                    txtXAB.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelZ11_Z12Bay.Width) - Convert.ToDouble(p.X)) / xScale));
                    txtYAB.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelZ11_Z12Bay.Height) - Convert.ToDouble(p.Y)) / yScale));
                }
                else
                {
                    panel4.Visible = false;
                }

            }

        }

        //绘图
        void panelZ11_Z22Bay_Paint(object sender, PaintEventArgs e)
        {
            #region 引用对象
            Graphics gr = e.Graphics;
            #endregion

            #region 比例换算
            //计算X方向上的比例关系
            double xScale = Convert.ToDouble(panelZ11_Z12Bay.Width) / Convert.ToDouble(constData.Z11_Z12BaySpaceX);
            //计算Y方向的比例关系
            double yScale = Convert.ToDouble(panelZ11_Z12Bay.Height) / Convert.ToDouble(constData.Z11_Z12BaySpaceY);
            #endregion

            HatchBrush mybrush1 = new HatchBrush(
                          HatchStyle.HorizontalBrick,
                           Color.Black,
                           Color.Silver);
            //gr.FillRectangle(mybrush1, Convert.ToInt32(Convert.ToDouble(265450) * xScale), 0, 
            //    Convert.ToInt32(Convert.ToDouble(268500-265450) * xScale), this.panelZ11_Z12Bay.Height);
            //gr.DrawString("9999", new Font("微软雅黑", 10, FontStyle.Bold), Brushes.White, new Point(Convert.ToInt32(Convert.ToDouble(265450) * xScale), 10));

        }



        #region -----------------------------画面切换--------------------------------
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }
        #endregion


        #region  -----------------------------内存回收--------------------------------
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                A_library_Monitor.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void btnShowXY_Click(object sender, EventArgs e)
        {
            if (!isShowCurrentBayXY)
            {
                isShowCurrentBayXY = true;
                btnShowXY.Text = "取消显示";

                timer_ShowXY.Enabled = true;
                timer_ShowXY.Interval = 1500;
            }
            else
            {
                isShowCurrentBayXY = false;
                btnShowXY.Text = "显示XY";
                timer_ShowXY.Enabled = false;

            }
        }

        private void btnShowCrane_Click(object sender, EventArgs e)
        {
            if (btnShowCrane.Text == "隐藏行车")
            {
                conCrane1_1.Visible = false;
                conCrane1_2.Visible = false;
                conCrane1_3.Visible = false;
                conCrane1_4.Visible = false;

                btnShowCrane.Text = "显示行车";
            }
            else
            {
                conCrane1_1.Visible = true;
                conCrane1_2.Visible = true;
                conCrane1_3.Visible = true;
                conCrane1_4.Visible = true;

                btnShowCrane.Text = "隐藏行车";
            }
        }

        private void panelZ11_Z22Bay_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnSeekCoil_Click(object sender, EventArgs e)
        {
            if (frmSeekCoil == null || frmSeekCoil.IsDisposed)
            {
                frmSeekCoil = new FrmSeekCoil();
                frmSeekCoil.saddleInStock_Z11_Z12 = saddleInStock_Z11_Z12;
                frmSeekCoil.Z11_Z12Panel = panelZ11_Z12Bay;
                frmSeekCoil.Z11_Z12_Width = panelZ11_Z12Bay.Width;
                frmSeekCoil.Z11_Z12_Height = panelZ11_Z12Bay.Height;
                frmSeekCoil.BayNo = constData.bayNo_A;
                frmSeekCoil.Show();
            }
            else
            {
                frmSeekCoil.WindowState = FormWindowState.Normal;
                frmSeekCoil.Activate();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (form == null || form.IsDisposed)
            {
                form = new FrmMoreStock();
                //form.MyLibrary = "A";
                form.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (DialogResult.OK == MessageBox.Show("注意，所有行车切自动！", "warning", MessageBoxButtons.OK))
            //{
            SendShortCmd("1", CraneStatusBase.SHORT_CMD_ASK_COMPUTER_AUTO);
            SendShortCmd("2", CraneStatusBase.SHORT_CMD_ASK_COMPUTER_AUTO);
            SendShortCmd("3", CraneStatusBase.SHORT_CMD_ASK_COMPUTER_AUTO);
            SendShortCmd("4", CraneStatusBase.SHORT_CMD_ASK_COMPUTER_AUTO);
            //}
            picture form = new picture();
            form.Show();
        }

        private void SendShortCmd(string theCraneNO, long cmdFlag)
        {
            try
            {
                //tagDataProvider.ServiceName = "iplature";
                string messageBuffer = string.Empty;

                messageBuffer = theCraneNO + "," + cmdFlag.ToString();
                //DownLoadShortCommand
                Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                wirteDatas[theCraneNO + "_DownLoadShortCommand"] = messageBuffer;
                tagDataProvider.SetData(theCraneNO + "_DownLoadShortCommand", messageBuffer);
            }
            catch (Exception ex)
            { }
        }

        private void btnCrane_1_WaterStatus_Click_1(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("关"))
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show("是否关闭A跨BC区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDataProvider.SetData("RESET1", "1");
                ParkClassLibrary.HMILogger.WriteLog(btnCrane_1_WaterStatus.Text, "关闭A跨BC区光电门", ParkClassLibrary.LogLevel.Info, this.Text);
            }
        }

        private void btnCrane_2_WaterStatus_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("关"))
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show("是否关闭A跨CD区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDataProvider.SetData("RESET2", "1");
                ParkClassLibrary.HMILogger.WriteLog(btnCrane_2_WaterStatus.Text, "关闭A跨CD区光电门", ParkClassLibrary.LogLevel.Info, this.Text);
            }
        }

        private void btnCrane_3_WaterStatus_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("关"))
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show("是否关闭B跨BC区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDataProvider.SetData("RESET3", "1");
                ParkClassLibrary.HMILogger.WriteLog(btnCrane_3_WaterStatus.Text, "关闭B跨BC区光电门", ParkClassLibrary.LogLevel.Info, this.Text);
            }
        }

        private void btnCrane_4_WaterStatus_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Contains("关"))
            {
                MessageBox.Show("光电门已经处于关闭状态", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            DialogResult dr = MessageBox.Show("是否关闭B跨CD区光电门？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                tagDataProvider.SetData("RESET4", "1");
                ParkClassLibrary.HMILogger.WriteLog(btnCrane_4_WaterStatus.Text, "关闭B跨CD区光电门", ParkClassLibrary.LogLevel.Info, this.Text);
            }
        }

        public bool updataCraneWaterStatus(string craneNO)
        {
            bool ret = false;
            try
            {
                string sql = @"SELECT STATUS,TYPE FROM CRANE_PIPI ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["TYPE"].ToString() == "0")
                        {
                            if (rdr["STATUS"].ToString() == "TO_BE_START" || rdr["STATUS"].ToString() == "STARTED")
                            {
                                ret = true;
                            }
                        }
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return ret;
        }

        #region 检修时更改行车背景颜色

        /// <summary>
        /// 检修
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnbtnRecondition_Click(object sender, EventArgs e)
        {
            Recondition frm = new Recondition(this);
            frm.BayNO = "A";
            frm.ShowDialog();
        }        
        /// <summary>
        /// 更新行车背景颜色
        /// </summary>
        /// <param name="CraneNO">行车号</param>
        public void UpdataCrane(string CraneNO)
        {
            if (CraneNO.Equals("1"))
            {
                this.conCrane1_1.BackColor = System.Drawing.Color.Red;
            }
            else if (CraneNO.Equals("2"))
            {
                this.conCrane1_2.BackColor = System.Drawing.Color.Red;
            }
            else if (CraneNO.Equals("3"))
            {
                this.conCrane1_3.BackColor = System.Drawing.Color.Red;
            }
            else if (CraneNO.Equals("4"))
            {
                this.conCrane1_4.BackColor = System.Drawing.Color.Red;
            }
        }
        /// <summary>
        /// 取消行车背景颜色
        /// </summary>
        /// <returns></returns>
        public void OutCrane(string CraneNO)
        {
            if (CraneNO.Equals("1"))
            {
                this.conCrane1_1.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (CraneNO.Equals("2"))
            {
                this.conCrane1_2.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (CraneNO.Equals("3"))
            {
                this.conCrane1_3.BackColor = System.Drawing.SystemColors.Control;
            }
            else if (CraneNO.Equals("4"))
            {
                this.conCrane1_3.BackColor = System.Drawing.SystemColors.Control;
            }
        }
        #endregion
    }
}
