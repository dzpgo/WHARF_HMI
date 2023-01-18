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


namespace UACSView.View_CraneMonitor
{
    public partial class Z12_library_Monitor : FormBase
    {
        private conAreaModel AreaInStockZ12;
        private List<conCraneStatus> lstConCraneStatusPanel = new List<conCraneStatus>();
        private List<conCrane> listConCraneDisplay = new List<conCrane>();
        private List<string> listCraneNo = new List<string>();


        private conAreaModel areaModel;
        private conUnitSaddleModel unitSaddleModel;
        private conParkingCarModel parkingCarModel;
        private CraneStatusInBay craneStatusInBay;

        private static FrmSeekCoil frmSeekCoil;
        private conStockSaddleModel saddleInStock_Z11_Z12;

        private bool isShowCurrentBayXY = false;    //是否显示鼠标位置的XY
        private bool tabActived = true;             //是否在当前画面显示

        private string craneNo_1_1 = "3_1";
        private string craneNo_1_2 = "3_2";
        private string craneNo_1_3 = "3_3";
        private string craneNo_1_4 = "";
        private const string D401EXIT = "D401-WC";
        private const string D401ENTRY = "D401-WR";

        public Z12_library_Monitor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.Load += Z12_library_Monitor_Load;

            btnCrane_1_WaterStatus.Name = craneNo_1_1;
            btnCrane_2_WaterStatus.Name = craneNo_1_2;
            btnCrane_3_WaterStatus.Name = craneNo_1_3;
            btnCrane_4_WaterStatus.Name = craneNo_1_4;
        }

        void btnCrane_1_WaterStatus_Click(object sender, EventArgs e)
        {
            //检查
            Button btn = (Button)sender;
            if (!AreaInStockZ12.updataCraneWaterLevel(btn.Name))
            {
                MessageBoxButtons btn1 = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show(btn.Name + "#行车水位没有到达报警值，不能进行放水!", "提示", btn1, MessageBoxIcon.Asterisk);
                return;
            }
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
        void Z12_library_Monitor_Load(object sender, EventArgs e)
        {
            areaModel = new conAreaModel();
            unitSaddleModel = new conUnitSaddleModel();
            parkingCarModel = new conParkingCarModel();
            craneStatusInBay = new CraneStatusInBay();

            AreaInStockZ12 = new conAreaModel();

            btnCrane_1_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_2_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_3_WaterStatus.Click += btnCrane_1_WaterStatus_Click;
            btnCrane_4_WaterStatus.Click += btnCrane_1_WaterStatus_Click;

            //行车显示控件配置
            conCrane1_1.InitTagDataProvide(constData.tagServiceName);
            conCrane1_1.CraneNO = craneNo_1_1;
            listConCraneDisplay.Add(conCrane1_1);

            conCrane1_2.InitTagDataProvide(constData.tagServiceName);
            conCrane1_2.CraneNO = craneNo_1_2;
            listConCraneDisplay.Add(conCrane1_2);

            conCrane1_3.InitTagDataProvide(constData.tagServiceName);
            conCrane1_3.CraneNO = craneNo_1_3;
            listConCraneDisplay.Add(conCrane1_3);

            conCrane1_4.InitTagDataProvide(constData.tagServiceName);
            conCrane1_4.CraneNO = craneNo_1_4;
            listConCraneDisplay.Add(conCrane1_4);


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

            //预先加载
            timer_InitializeLoad.Enabled = true;
            timer_InitializeLoad.Interval = 100;
        }

        private void LoadAreaInfo()
        {
            areaModel.conInit(panelZ11_Z12Bay,
                constData.bayNo,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown,
                 AreaInfo.AreaType.AllType);
        }

        private void LoadUnitInfo()
        {
            unitSaddleModel.conInit(panelZ11_Z12Bay,
                D401EXIT, 
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown,
                constData.bayNo);

            unitSaddleModel.conInit(panelZ11_Z12Bay,
                D401ENTRY,
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown,
                constData.bayNo);
        }

        private void LoadParkingCarInfo()
        {
            parkingCarModel.conInit(panelZ11_Z12Bay, 
                constData.bayNo, 
                constData.tagServiceName,
                constData.Z11_Z12BaySpaceX,
                constData.Z11_Z12BaySpaceY,
                panelZ11_Z12Bay.Width,
                panelZ11_Z12Bay.Height,
                constData.xAxisRight,
                constData.yAxisDown);
        }


        private void timer_InitializeLoad_Tick(object sender, EventArgs e)
        {

            LoadUnitInfo();

            LoadAreaInfo();

            Thread.Sleep(500);
            timerCrane.Enabled = true;
            timerArea.Enabled = true;
            timerUnit.Enabled = true;

            timerCrane.Interval = 1500;
            timerArea.Interval = 10000;
            timerUnit.Interval = 10000;

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

                AreaInStockZ12.conInit(panelZ11_Z12Bay, constData.bayNo, SaddleBase.tagServiceName,
                       constData.Z11_Z12BaySpaceX, constData.Z11_Z12BaySpaceY, panelZ11_Z12Bay.Width, panelZ11_Z12Bay.Height,
                       constData.xAxisRight, constData.yAxisDown, AreaInfo.AreaType.StockArea);

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
                         8000,         
                         panelZ11_Z12Bay 
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

            LoadUnitInfo();

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
                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelZ11_Z12Bay.Height) / Convert.ToDouble(constData.Z11_Z12BaySpaceY);

                Point p = this.panelZ11_Z12Bay.PointToClient(Control.MousePosition);
                if (p.X <= this.panelZ11_Z12Bay.Location.X || p.X >= this.panelZ11_Z12Bay.Location.X + this.panelZ11_Z12Bay.Width ||
                    p.Y < this.panelZ11_Z12Bay.Location.Y || p.Y >= this.panelZ11_Z12Bay.Location.Y + this.panelZ11_Z12Bay.Height)
                {
                    return;
                }
                txtX.Text = Convert.ToString(Convert.ToInt32(Convert.ToDouble(p.X) / xScale));
                txtY.Text = Convert.ToString(Convert.ToInt32((Convert.ToDouble(panelZ11_Z12Bay.Height)-Convert.ToDouble(p.Y)) / yScale));
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
            gr.FillRectangle(mybrush1, Convert.ToInt32(Convert.ToDouble(265450) * xScale), 0, 
                Convert.ToInt32(Convert.ToDouble(268500-265450) * xScale), this.panelZ11_Z12Bay.Height);
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
                Z12_library_Monitor.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
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
                timer_ShowXY.Interval = 1000;
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
                frmSeekCoil.BayNo = constData.bayNo;
                frmSeekCoil.Show();
            }
            else
            {
                frmSeekCoil.WindowState = FormWindowState.Normal;
                frmSeekCoil.Activate();
            }
        }

       

       

       
    }
}
