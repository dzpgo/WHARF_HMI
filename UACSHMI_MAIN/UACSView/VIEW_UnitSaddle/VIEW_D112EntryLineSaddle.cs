﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UACSPopupForm;
using UACSControls;
using UACSDAL;
using Baosight.iSuperframe.Forms;
using System.Runtime.InteropServices;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;

namespace UACSView
{
    public partial class VIEW_D112EntryLineSaddle : FormBase
    {
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;
        #region -----------------------load加载----------------------------------


        public VIEW_D112EntryLineSaddle()
        {

            InitializeComponent();
            
            //x = this.Width;
            //y = this.Height;
            //setTag(this);

            Type dgvEntrySaddleType = this.dataGridViewSaddleMessage.GetType();
            PropertyInfo pi = dgvEntrySaddleType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridViewSaddleMessage, true, null);

            Type dgvL2PlanType = this.dataGridViewPlanNum.GetType();
            PropertyInfo pi1 = dgvL2PlanType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi1.SetValue(this.dataGridViewPlanNum, true, null);
            this.Load += VIEW_D112EntryLineSaddle_Load;
            dataGridViewPlanNum.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn item in this.dataGridViewPlanNum.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private CraneStatusBase cranePLCStatusBase = new CraneStatusBase();
        private UnitSaddleTagRead lineSaddleTag = new UnitSaddleTagRead();
        private UnitSaddleMethod saddleMethod = null;
        private UnitEntrySaddleInfo entrySaddleInfo = new UnitEntrySaddleInfo();

        private Dictionary<string, CoilUnitSaddle> dicSaddleControls = new Dictionary<string, CoilUnitSaddle>();
        private bool tabActived = true;
        private const string AREA_SAFE_ENTRY_D401 = "AREA_SAFE_D112_ENTRY";

        public long theValue;
        public long thevalue
        {
            get { return theValue; }
            set { thevalue = value; }
        }


        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("zjcangchu");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        void VIEW_D112EntryLineSaddle_Load(object sender, EventArgs e)
        {
            auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
            ucArrow1.Text = " 1\n #\n通\n道";
            ucArrow2.Text = " 2\n #\n通\n道";
            #region 绑定鞍座控件
            dicSaddleControls["D112VR1A01"] = coilUnitSaddle1;
            dicSaddleControls["D112VR1A02"] = coilUnitSaddle3;
            dicSaddleControls["D112VR2A01"] = coilUnitSaddle2;
            dicSaddleControls["D112VR2A02"] = coilUnitSaddle4;
            #endregion

            //实例化机组鞍座处理类
            saddleMethod = new UnitSaddleMethod(constData.UnitNo_2, constData.EntrySaddleDefine, constData.tagServiceName);
            saddleMethod.ReadDefintion();

            coilUnitStatus1.InitTagDataProvide(constData.tagServiceName);
            coilUnitStatus1.MyStatusTagName = AREA_SAFE_ENTRY_D401;

            lineSaddleTag.InitTagDataProvider(constData.tagServiceName);

            coilUnitSaddleButton1.MySaddleNo = "D112VR1A01";
            coilUnitSaddleButton3.MySaddleNo = "D112VR1A02";
            coilUnitSaddleButton2.MySaddleNo = "D112VR2A01";
            coilUnitSaddleButton4.MySaddleNo = "D112VR2A02";

            //conCraneStatus1_2.InitTagDataProvide(constData.tagServiceName);
            //conCraneStatus1_2.CraneNO = "1_2";
            //lstConCraneStatusPanel.Add(conCraneStatus1_2);

            //craneStatusInBay.InitTagDataProvide(constData.tagServiceName);
            //craneStatusInBay.AddCraneNO("1_2");
            //craneStatusInBay.SetReady();

            conEntrySpecAction1.UnitNo = constData.UnitNo_2;
            conEntrySpecAction1.BayNo = "A";

            //把表中的tag名称赋值到控件中
            foreach (Control control in panel2.Controls)
            {
                //添加解锁鞍座控件
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (saddleMethod.DicSaddles.ContainsKey(t.MySaddleNo))
                    {
                        UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[t.MySaddleNo];
                        if (!string.IsNullOrEmpty(theSaddleInfo.TagAdd_LockRequest) && theSaddleInfo.TagAdd_LockRequest != "")
                        {
                            t.MySaddleTagName = theSaddleInfo.TagAdd_LockRequest;
                            lineSaddleTag.AddTagName(theSaddleInfo.TagAdd_LockRequest);
                        }
                    }

                }
            }
            foreach (Control control in panel3.Controls)
            {
                //添加解锁鞍座控件
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (saddleMethod.DicSaddles.ContainsKey(t.MySaddleNo))
                    {
                        UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[t.MySaddleNo];
                        if (!string.IsNullOrEmpty(theSaddleInfo.TagAdd_LockRequest) && theSaddleInfo.TagAdd_LockRequest != "")
                        {
                            t.MySaddleTagName = theSaddleInfo.TagAdd_LockRequest;
                            lineSaddleTag.AddTagName(theSaddleInfo.TagAdd_LockRequest);
                        }
                    }

                }
            }
                foreach (Control control in panel1.Controls)
                {
                    //添加机组状态控件
                    if (control is CoilUnitStatus)
                    {
                        CoilUnitStatus t = (CoilUnitStatus)control;
                        if (!string.IsNullOrEmpty(t.MyStatusTagName) && t.MyStatusTagName != "")
                        {
                            lineSaddleTag.AddTagName(t.MyStatusTagName);
                        }
                    }
                }
                           
            lineSaddleTag.SetReady();
            //把实例化后的机组tag处理类装备每个控件
            foreach (Control control in panel1.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    t.InitUnitSaddle(lineSaddleTag);
                }
            }

            entrySaddleInfo.getEntrySaddleDt(dataGridViewSaddleMessage, constData.UnitNo_2);
            //是否开启定时器
            timer1.Enabled = true;
            //设定刷新时间
            timer1.Interval = 5000;
            dgvColor();
        }
        #endregion

        #region -----------------------钢卷信息----------------------------------
        private void timer_LineSaddleControl_Tick(object sender, EventArgs e)
        {
            //不在当前页面停止刷新
            if (tabActived == false)
            {
                return;
            }

            //if (thevalue == 1)
            //{
            //    this.tableLayoutPanel2.BackColor = Color.Transparent;
            //}
            //else
            //{
            //    this.tableLayoutPanel2.BackColor = Color.Red;
            //}

            lineSaddleTag.readTags();

            foreach (Control control in panel2.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (!string.IsNullOrEmpty(t.MySaddleTagName) && t.MySaddleTagName != "")
                    {
                        CoilUnitSaddleButton.delRefresh_Button_Light del = t.refresh_Button_Light;
                        del(lineSaddleTag.getTagValue(t.MySaddleTagName));
                    }
                }
            }
            foreach (Control control in panel3.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (!string.IsNullOrEmpty(t.MySaddleTagName) && t.MySaddleTagName != "")
                    {
                        CoilUnitSaddleButton.delRefresh_Button_Light del = t.refresh_Button_Light;
                        del(lineSaddleTag.getTagValue(t.MySaddleTagName));
                    }
                }
            }
            foreach (Control control in panel1.Controls)
            {
                if (control is CoilUnitStatus)
                {
                    CoilUnitStatus t = (CoilUnitStatus)control;
                    if (!string.IsNullOrEmpty(t.MyStatusTagName) && t.MyStatusTagName != "")
                    {
                        CoilUnitStatus.delSetColor del = t.SetColor;
                        del(lineSaddleTag.getTagValue(t.MyStatusTagName));
                    }
                }
            }

            entrySaddleInfo.getEntrySaddleDt(dataGridViewSaddleMessage, constData.UnitNo_2);

            getSaddleMessage();
            getStatus1();
            getStatus2();
            //dgvColor();
        }

        private void getStatus1()
        {
            string status;
            string sql = @"select STATUS from UACS_LINE_ENTRY_LOAD_ACTOR where ACTOR_ID =  'D112_1' ";
            using (IDataReader rdr = DBHelper.ExecuteReader(sql))
            {
                while (rdr.Read())
                {
                    if (rdr["STATUS"] != System.DBNull.Value)
                    {
                        status = rdr["STATUS"].ToString();

                        if (status == "1")
                        {
                            ucArrow1.ArrowColor = Color.Green;
                        }
                        else
                        {
                            ucArrow1.ArrowColor = Color.LightGray;
                        }
                    }

                }
            }
        }

        private void getStatus2()
        {
            string status;
            string sql = @"select STATUS from UACS_LINE_ENTRY_LOAD_ACTOR where ACTOR_ID = 'D112_2' ";
            using (IDataReader rdr = DBHelper.ExecuteReader(sql))
            {
                while (rdr.Read())
                {
                    if (rdr["STATUS"] != System.DBNull.Value)
                    {
                        status = rdr["STATUS"].ToString();

                        if (status == "1")
                        {
                            ucArrow2.ArrowColor = Color.Green;
                        }
                        else
                        {
                            ucArrow2.ArrowColor = Color.LightGray;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 上料计划
        /// </summary>
        private void CoilPlan()
        {
            entrySaddleInfo.getL2PlanByUnitNo(dataGridViewPlanNum, constData.UnitNo_2);

            dgvColor();
        }
        private void getSaddleMessage()
        {
            saddleMethod.ReadDefintion();
            saddleMethod.getTagNameList();
            saddleMethod.getTagValues();

            foreach (string theL2SaddleName in dicSaddleControls.Keys)
            {
                if (saddleMethod.DicSaddles.ContainsKey(theL2SaddleName))
                {
                    CoilUnitSaddle conSaddle = dicSaddleControls[theL2SaddleName];

                    UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[theL2SaddleName];
                    //鞍座反馈
                    if (theSaddleInfo.TagVal_IsLocked == 1)
                        conSaddle.UpVisiable = true;
                    else
                        conSaddle.UpVisiable = false;

                    //鞍座占位
                    if (theSaddleInfo.TagVal_IsOccupied == 1)
                        conSaddle.CoilBackColor = Color.Green;
                    else
                        conSaddle.CoilBackColor = Color.LightGray;

                    //钢卷号
                    if (theSaddleInfo.CoilNO != string.Empty)
                    {
                        conSaddle.CoilId = theSaddleInfo.CoilNO;
                        conSaddle.CoilStatus = 2;
                    }
                    else
                    {
                        conSaddle.CoilId = "";
                        conSaddle.CoilStatus = -10;
                    }
                }

            }
        }
        #endregion

        #region -----------------------刷新事件----------------------------------

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabActived == false)
                {
                    return;
                }

                getSaddleMessage();

                if (!isControlPlan)
                {
                    CoilPlan();
                }

                coilEntryMode1.UnitNO = "D112_1";
                coilEntryMode2.UnitNO = "D112_2";

                conEntrySpecAction1.conGetAction();

                //if (conCraneStatus_4_2.ToStockNo.Contains(SaddleNo))
                //{
                //    if (lblNextCoil.Text.Trim() != conCraneStatus_4_2.NextCoilNo.Trim())
                //    {
                //        conCraneStatus_4_2.CheckNextCoil();
                //        lblNextCoil.BackColor = Color.Red;
                //    }
                //    else
                //    {
                //        lblNextCoil.BackColor = System.Drawing.SystemColors.Control;
                //    }
                //}
                //else
                //{
                //    lblNextCoil.BackColor = System.Drawing.SystemColors.Control;
                //}

                ClearMemory();
                //System.GC.Collect();
                //System.GC.WaitForPendingFinalizers();
            }
            catch (Exception er)
            {

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabActived == false)
                {
                    return;
                }

                saddleMethod.GetCoilLabel(constData.UnitNo_2, lblNextCoil, label2);

                if (label2.Text.Trim().IndexOf("Z33") > -1)
                {
                    label2.BackColor = Color.Red;
                }
                else
                    label2.BackColor = System.Drawing.SystemColors.Control;

                //coilStatus1.RefreshControl();
                //coilStatus2.RefreshControl();
                //coilStatus3.RefreshControl();
                //coilStatus4.RefreshControl();
                //
                //coilButton1.RefreshControl();
                //coilButton2.RefreshControl();
               
                craneStatusInBay.getAllPLCStatusInBay(craneStatusInBay.lstCraneNO);

                foreach (conCraneStatus conCraneStatusPanel in lstConCraneStatusPanel)
                {
                    conCraneStatus.RefreshControlInvoke ConCraneStatusPanel_Invoke = new conCraneStatus.RefreshControlInvoke(conCraneStatusPanel.RefreshControl);
                    conCraneStatusPanel.BeginInvoke(ConCraneStatusPanel_Invoke, new Object[] { craneStatusInBay.DicCranePLCStatusBase[conCraneStatusPanel.CraneNO].Clone() });
                }

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region  -----------------------内存回收----------------------------------
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
                VIEW_D112EntryLineSaddle.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        #region -----------------------字段变量----------------------------------
        /// <summary>
        /// 公共dataTable
        /// </summary>
        private DataTable SaddleDt = new DataTable();
        /// <summary>
        /// 鞍座控件
        /// </summary>
        //private Dictionary<string, UACS.CoilPicture> dicSaddleControls = new Dictionary<string, CoilPicture>();
        /// <summary>
        /// 吊运控件
        /// </summary>
        //private Dictionary<UACS.CoilPicture, UACS.CoilCranOrder> dicControl = new Dictionary<UACS.CoilPicture, UACS.CoilCranOrder>();
        /// <summary>
        /// 实例化鞍座出口类
        /// </summary>
        //private UACS.SaddleMethod saddleMethod = null;
        /// <summary>
        ///  控件名称
        /// </summary>
        //private string ControlNo;
        /// <summary>
        /// 管理计划顺序是否刷新
        /// </summary>
        private bool isControlPlan = false;


        private CraneStatusInBay craneStatusInBay = new CraneStatusInBay();

        private List<conCraneStatus> lstConCraneStatusPanel = new List<conCraneStatus>();
        /// <summary>
        /// 平台tag配置名称
        /// </summary>
        private const int Flag_Unit_Exit = 0;

        /// <summary>
        /// 根据吊运控件得到指定鞍座号
        /// </summary>
        private Dictionary<string, string> saddleNo = new Dictionary<string, string>();


        private List<string> listSaddleNo = new List<string>();
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if(ucArrow1.ArrowColor == Color.Green)
            {
                DialogResult ret = MessageBox.Show("2#通道开始上料？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(ret == DialogResult.OK)
                {
                    string sql = @"update UACS_LINE_ENTRY_LOAD_ACTOR set STATUS = 0 where  ACTOR_ID =  'D112_1' ";
                    DBHelper.ExecuteReader(sql);
                    string sq2 = @"update UACS_LINE_ENTRY_LOAD_ACTOR set STATUS = 1 where  ACTOR_ID =  'D112_2'";
                    DBHelper.ExecuteReader(sq2);
                    ParkClassLibrary.HMILogger.WriteLog("切换通道", "D112机组切换2#通道上料", ParkClassLibrary.LogLevel.Info, this.Name);
                }
                else
                {
                    return;
                }
            }
            else if (ucArrow2.ArrowColor == Color.Green)
            {
                DialogResult ret = MessageBox.Show("1#通道开始上料？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (ret == DialogResult.OK)
                {
                    string sql = @"update UACS_LINE_ENTRY_LOAD_ACTOR set STATUS = 0 where  ACTOR_ID =  'D112_2' ";
                    DBHelper.ExecuteReader(sql);
                    string sq2 = @"update UACS_LINE_ENTRY_LOAD_ACTOR set STATUS = 1 where  ACTOR_ID =  'D112_1'";
                    DBHelper.ExecuteReader(sq2);
                    ParkClassLibrary.HMILogger.WriteLog("切换通道", "D112机组切换1#通道上料", ParkClassLibrary.LogLevel.Info, this.Name);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("目前没有机组上料！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            auth.OpenForm("03 A跨监控");
        }

        private void dgvColor()
        {
            foreach (DataGridViewRow dgvRows in dataGridViewPlanNum.Rows)
            {
                string stockNO = dgvRows.Cells["Column15"].Value.ToString();
                string ststus = dgvRows.Cells["Column18"].Value.ToString();
                //if (ststus == "库内" && stockNO != "" && (stockNO.Substring(0, 3) == "Z03" || stockNO.Substring(0, 3) == "Z02"))
                //{
                //    if (stockNO.Substring(0, 3) == "Z03")
                //    {
                //        dgvRows.DefaultCellStyle.BackColor = Color.White;
                //    }
                //    else if (stockNO.Substring(0, 3) == "Z02")
                //    {
                //        dgvRows.DefaultCellStyle.BackColor = Color.Green;
                //    }
                //    else
                //    {
                //        dgvRows.DefaultCellStyle.BackColor = Color.Red;
                //    }

                //}
                //else
                //{
                //    dgvRows.DefaultCellStyle.BackColor = Color.Red;
                //}

                if ((stockNO == "" || stockNO.Substring(0, 3) == "Z04" || stockNO.Substring(0, 3) == "Z05") && ststus != "机组鞍座")
                {
                    dgvRows.DefaultCellStyle.BackColor = Color.Red;

                }
                else
                {
                    dgvRows.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUnitRotateRequest unitRotate = new FrmUnitRotateRequest();
            unitRotate.UintNo = "D112";
            unitRotate.ShowDialog();
        }
    }
}
