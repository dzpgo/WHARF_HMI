﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.Authorization.Interface;
using ParkClassLibrary;
using ParkingControlLibrary;
using UACSDAL;
using Baosight.iSuperframe.Common;

namespace UACSParking
{
    public partial class TruckStowageInT : Baosight.iSuperframe.Forms.FormBase
    {
        //tag服务
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagProvider_InStock = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
as Baosight.iSuperframe.Authorization.Interface.IAuthorization;
        public TruckStowageInT()
        {
            InitializeComponent();
        }
        public TruckStowageInT(string parkNO)
        {
            InitializeComponent();
            cmbArea.Text = GetOperateArea(parkNO);
            parkingNO = parkNO;
        }
        //bool hasSetColumn_PT = false;
        //bool hasSetColumn_Laser = false;
        //bool hasSetColumn_LoadMap = false;
        ToolTip toolTip1 = new ToolTip();

        //手持
        DataTable dt_PT = new DataTable();
        //激光
        DataTable dt_Laser = new DataTable();
        //配载
        DataTable dt_LoadMap = new DataTable();
        //停车位
        DataTable dt_ParkingStatus = new DataTable();
        //画面刷新
        bool isStowage = false;
        bool hasCar = true;  //车位有车
        //画面跳转
        string parkingNO = "";
        string[] curOrderMatNO = { };
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
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion



        #region 页面加载

        private void TruckStowageInT_Load(object sender, EventArgs e)
        {
            try
            {
                //设置背景色
                //this.lblTitle.BackColor = Color.FromArgb(242, 246, 252);
                //this.panel1.BackColor = Color.FromArgb(242, 246, 252);
                ManagerHelper.DataGridViewInit(dataGridView_LASER);
                ManagerHelper.DataGridViewInit(dataGridView_LaodMap);
                ManagerHelper.DataGridViewInit(dataGridView_PT);
                dataGridView_PT.SelectionMode = DataGridViewSelectionMode.CellSelect;
                ManagerHelper.DataGridViewInit(dgvCraneOder);
                tagProvider_InStock.ServiceName = "iplature";
                tagProvider_InStock.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add("EV_PARKING_HMI_TRUCKSTOWAGEIN", null);
                tagProvider_InStock.Attach(TagValues);
                #region  tooltipshow
                // Create the ToolTip and associate with the Form container.

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 10000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;
                #endregion
                GetComboxOnParking(comb_ParkingNO);
                comb_ParkingNO.Text = "";
                timer_RefrehHMI.Enabled = true;
                comb_ParkingNO.SelectedIndexChanged += comb_ParkingNO_SelectedIndexChanged;
                parkLaserOut1.LabClick += park_LabClick;
                parkLaserOut1.labDoubleClick += parkLaserOut1_labDoubleClick;
                if (parkingNO != "")//画面跳转
                {
                    comb_ParkingNO.Text = parkingNO;
                    //comb_ParkingNO_SelectedIndexChanged_1(null, null);
                }
                bindParkControlEvent();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        void comb_ParkingNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comb_ParkingNO.Text.Trim() != "请选择" && comb_ParkingNO.Text.Trim() != "" && comb_ParkingNO.Text.Trim().Contains('F'))
            {
                isStowage = false;
                hasCar = true;
                RefreshHMI();
                btnOperateStrat.ForeColor = Color.White;
                btnOperatePause.ForeColor = Color.White;
            }
        }
        #endregion

        string treatmentNO = string.Empty;
        int ptCount = 0;
        int laserCount = 0;
        int stowageId = 0;
        string headPosition = string.Empty;

        #region 查询
        private void RefreshHMI()
        {
            if (comb_ParkingNO.Text.Trim().Contains('F'))
            {
                //停车位主体信息查询
                Inq_ParkingStatus();
                //查询作业暂停状态
                GetOperateStatus(comb_ParkingNO.Text.Trim());
                if (!hasCar)
                {
                    hasCar = txt_TreatmentNO.Text.Contains('F');
                    return;
                }
                //刷新指令表
                RefreshOrderDgv(comb_ParkingNO.Text);
                //激光入库扫描信息查询
                Inq_Laser(treatmentNO, laserCount, headPosition);
                //手持扫描信息查询
                Inq_PT(treatmentNO, ptCount);
                //框架配载图信息查询
                Inq_LoadMap(stowageId);
                //刷新配载图像
                isStowage = LoadLaserInfo(comb_ParkingNO.Text, laserCount, headPosition, parkLaserOut1);
                hasCar = txt_TreatmentNO.Text.Contains('F');
                //刷新通道全部车位
                GetParkInfoByBay();
                setCurParkStatus(comb_ParkingNO.Text);
            }
            
        }

        private void ClearHIM()
        {
            parkLaserOut1.ClearbitM();
            treatmentNO = "";
            ptCount = 0;
            laserCount = 0;
            stowageId = 0;
            headPosition = "";
            dt_Laser.Clear();
            dt_LoadMap.Clear();
            dt_ParkingStatus.Clear();
            dt_PT.Clear();
            dataGridView_LASER.DataSource = dt_Laser;
            dataGridView_LaodMap.DataSource = dt_LoadMap;
            dataGridView_PT.DataSource = dt_PT;
        }

        private void Inq_ParkingStatus()
        {
            try
            {
                string PARKING_NO = comb_ParkingNO.Text.ToString().Trim();     //停车位

                treatmentNO = string.Empty;
                ptCount = 0;
                laserCount = 0;
                stowageId = 0;

                //停车位主体信息
                string sqlText_ParkingStatus = @"SELECT TREATMENT_NO, STOWAGE_ID, CAR_NO, ISLOADED, HEAD_POSTION, PARKING_STATUS, LASER_ACTION_COUNT, PT_ACTION_COUNT FROM UACS_PARKING_STATUS ";

                //                string sqlText_ParkingStatus = @"SELECT TREATMENT_NO, STOWAGE_ID, CAR_NO, CASE WHEN ISLOADED = 0 THEN '空车' ELSE '重车' END AS ISLOADED, 
                //                                                 DECODE (HEAD_POSTION, 'S', '南', 'N', '北', 'E', '东', 'W', '西') AS HEAD_POSTION, 
                //                                                 DECODE (PARKING_STATUS, '05', '无车', '10', '有车到达', '110', '入库激光扫描开始', '120', '入库激光扫描完成', '130', '入库手持扫描完成', '210', '出库激光扫描开始', '220', '出库激光扫描完成') 
                //                                                 AS PARKING_STATUS, LASER_ACTION_COUNT, PT_ACTION_COUNT FROM UACS_PARKING_STATUS ";
                if (PARKING_NO != "")
                {
                    sqlText_ParkingStatus += " WHERE PARKING_NO = '" + PARKING_NO + "' ";
                }

                //初始化停车位信息
                Clear_ParkingStatus();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_ParkingStatus))
                {
                    while (rdr.Read())
                    {
                        if (rdr["TREATMENT_NO"] != System.DBNull.Value)
                        {
                            txt_TreatmentNO.Text = Convert.ToString(rdr["TREATMENT_NO"]);
                            treatmentNO = Convert.ToString(rdr["TREATMENT_NO"]);
                        }
                        if (rdr["CAR_NO"] != System.DBNull.Value)
                        {
                            txt_CarNO.Text = Convert.ToString(rdr["CAR_NO"]);
                        }
                        if (rdr["STOWAGE_ID"] != System.DBNull.Value)
                        {
                            txt_LoadMapID.Text = Convert.ToString(rdr["STOWAGE_ID"]);

                            stowageId = Convert.ToInt32(rdr["STOWAGE_ID"]);
                        }

                        if (rdr["ISLOADED"] != System.DBNull.Value)
                        {
                            //txt_ISLoaded.Text =   Convert.ToString(rdr["ISLOADED"]);

                            if (Convert.ToString(rdr["ISLOADED"]) == "0")
                            {
                                txt_ISLoaded.Text = "空车";
                            }
                            else if (Convert.ToString(rdr["ISLOADED"]) == "1")
                            {
                                txt_ISLoaded.Text = "重车";
                            }

                        }

                        if (rdr["HEAD_POSTION"] != System.DBNull.Value)
                        {
                            //txt_HeadPos.Text = Convert.ToString(rdr["HEAD_POSTION"]);
                            switch (Convert.ToString(rdr["HEAD_POSTION"]))
                            {
                                case "E":
                                    txt_HeadPos.Text = "东";
                                    break;
                                case "W":
                                    txt_HeadPos.Text = "西";
                                    break;
                                case "S":
                                    txt_HeadPos.Text = "南";
                                    break;
                                case "N":
                                    txt_HeadPos.Text = "北";
                                    break;
                                default:
                                    txt_HeadPos.Text = "无";
                                    break;
                            }

                            headPosition = Convert.ToString(rdr["HEAD_POSTION"]);
                        }
                        if (rdr["PARKING_STATUS"] != System.DBNull.Value)
                        {
                            //txt_ParkingStatus.Text = Convert.ToString(rdr["PARKING_STATUS"]);

                            switch (Convert.ToString(rdr["PARKING_STATUS"]))
                            {
                                case "5":
                                    txt_ParkingStatus.Text = "无车";
                                    break;
                                case "10":
                                    txt_ParkingStatus.Text = "有车到达";
                                    break;
                                case "110":
                                    txt_ParkingStatus.Text = "激光扫描开始";
                                    break;
                                case "120":
                                    txt_ParkingStatus.Text = "入库激光扫描完成";
                                    break;
                                case "130":
                                    txt_ParkingStatus.Text = "入库手持扫描完成";
                                    break;
                                case "140":
                                    txt_ParkingStatus.Text = "入库计划生成";
                                    break;
                                case "170":
                                    txt_ParkingStatus.Text = "入库暂停";
                                    break;
                                case "210":
                                    txt_ParkingStatus.Text = "出库激光扫描开始";
                                    break;
                                case "220":
                                    txt_ParkingStatus.Text = "出库激光扫描完成";
                                    break;
                                case "240":
                                    txt_ParkingStatus.Text = "出库计划生成";
                                    break;
                                case "270":
                                    txt_ParkingStatus.Text = "出库暂停";
                                    break;
                                default:
                                    break;
                            }
                            if (txt_ParkingStatus.Text.Contains("暂停"))
                            {
                                txt_ParkingStatus.ForeColor = Color.Orange;
                            }
                            else
                            {
                                txt_ParkingStatus.ForeColor = Color.Silver;
                            }
                        }
                        if (rdr["LASER_ACTION_COUNT"] != System.DBNull.Value)
                        {
                            txt_LASER_ACTION_COUNT.Text = Convert.ToString(rdr["LASER_ACTION_COUNT"]);
                            laserCount = Convert.ToInt32(rdr["LASER_ACTION_COUNT"]);
                        }
                        if (rdr["PT_ACTION_COUNT"] != System.DBNull.Value)
                        {
                            txt_PT_ACTION_COUNT.Text = Convert.ToString(rdr["PT_ACTION_COUNT"]);
                            ptCount = Convert.ToInt32(rdr["PT_ACTION_COUNT"]);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void Inq_PT(string theTreatmentNO, int theCount)
        {
            try
            {
                //手持扫描信息
                string sqlText_PT = @"SELECT PORTABLE_ID, PT_ACTION_COUNT, COIL_POSITION_7, MAT_NO, MAT_DIRECTION, SLEEVE_LENGTH, PACKAGE_STATUS, INDEX_Y, POS_IN_GROOVE FROM UACS_PDA_SCAN WHERE 1=1 ";
                sqlText_PT += " AND PROCESS_NO = '" + theTreatmentNO + "' AND PT_ACTION_COUNT = '" + theCount + "' ";
                sqlText_PT += " ORDER BY COIL_POSITION_7 ";

                //初始化
                //dt_PT.Clear();
                dt_PT = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_PT))
                {
                    //while (rdr.Read())
                    //{
                    //    DataRow dr = dt_PT.NewRow();
                    //    for (int i = 0; i < rdr.FieldCount; i++)
                    //    {
                    //        if (!hasSetColumn_PT)
                    //        {
                    //            DataColumn dc = new DataColumn();
                    //            dc.ColumnName = rdr.GetName(i);
                    //            dt_PT.Columns.Add(dc);
                    //        }
                    //        dr[i] = rdr[i];
                    //    }
                    //    hasSetColumn_PT = true;
                    //    dt_PT.Rows.Add(dr);
                    //}
                    dt_PT.Load(rdr);
                }
                //hasSetColumn_PT = false;

                ////初始化grid数据
                //if (dataGridView_PT.DataSource != null)
                //{
                //    ((DataTable)dataGridView_PT.DataSource).Rows.Clear();
                //}
                //if (dt_PT.Rows.Count == dt_PT.Columns.Count && dt_PT.Rows.Count == 0)
                //{

                //}
                //else
                {
                    dataGridView_PT.DataSource = dt_PT;
                    txtPTcount.Text = dt_PT.Rows.Count.ToString();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void Inq_Laser(string theTreatmentNO, int theCount, string theheadPosition)
        {
            try
            {
                //激光扫描信息
                string sqlText_Laser = @"SELECT LASER_ID, LASER_ACTION_COUNT, X_ACT_CENTER, Y_ACT_CENTER, Z_ACT_CENTER, STEELWIDE, STEELDIAMETER, INDEX_Y, POS_IN_GROOVE FROM UACS_LASER_IN WHERE 1=1 ";

                sqlText_Laser += " AND TREATMENT_NO = '" + theTreatmentNO + "' AND LASER_ACTION_COUNT = '" + theCount + "' ";

                if (theheadPosition == "E")
                {
                    sqlText_Laser += " ORDER BY Y_ACT_CENTER DESC ";
                }
                if (theheadPosition == "W")
                {
                    sqlText_Laser += " ORDER BY Y_ACT_CENTER ";
                }

                //初始化
                dt_Laser.Clear();
                //dt_Laser = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Laser))
                {
                    dt_Laser.Load(rdr);
                }

                    dataGridView_LASER.DataSource = dt_Laser;
                    txtLaserCount.Text = dt_Laser.Rows.Count.ToString();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void Inq_LoadMap(int thestowageId)
        {
            try
            {
                //框架配载图信息
                string sqlText_LoadMap = @"SELECT  A.GROOVEID , A.MAT_NO, A.POS_ON_FRAME, A.X_CENTER, A.Y_CENTER, A.Z_CENTER, A.SLEEVE_LENGTH, A.PACKAGE_STATUS, A.STATUS, C.STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL A  ";
                sqlText_LoadMap += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON A.MAT_NO = C.MAT_NO ";
                sqlText_LoadMap += " LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID WHERE 1=1 ";
                sqlText_LoadMap += " AND B.STOWAGE_ID = '" + stowageId + "' ORDER BY A.POS_ON_FRAME ";

                //初始化
                dt_LoadMap.Clear();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_LoadMap))
                {
                    dt_LoadMap.Load(rdr);
                }
                dataGridView_LaodMap.DataSource = dt_LoadMap;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        #endregion

        #region 激光扫描完
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Baosight.iSuperframe.TagService.DataCollection<object> TagValues2 = new DataCollection<object>();

                //入库激光扫描完成(停车位编号|框架车号|处理号|单车内激光扫描次数)	
                //跳转画面
                TagLaserInEnd form = new TagLaserInEnd(comb_ParkingNO.Text.Trim(), txt_CarNO.Text.Trim(), txt_TreatmentNO.Text.Trim(), txt_LASER_ACTION_COUNT.Text.Trim());
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();

                string PARKING_NO = form.TAG_PARKING_NO;
                string CAR_NO = form.TAG_CAR_NO;
                string TREATMENT_NO = form.TAG_TREATMENT_NO;
                string LASER_ACTION_COUNT = form.TAG_LASER_ACTION_COUNT;
                bool cancelFlag = form.CANCEL_FLAG;

                if (cancelFlag == false)
                {
                    //平台配置
                    tagProvider_InStock.ServiceName = "iplature";
                    tagProvider_InStock.AutoRegist = true;

                    //添加tag点到数组
                    TagValues2.Add("EV_PARKING_IN_LASEREND", null);
                    //Laser.Attach(TagValues);
                    tagProvider_InStock.SetData("EV_PARKING_IN_LASEREND", PARKING_NO + "|" + CAR_NO + "|" + TREATMENT_NO + "|" + LASER_ACTION_COUNT);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 手持扫描完   注释了
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Baosight.iSuperframe.TagService.DataCollection<object> TagValues1 = new DataCollection<object>();

                ////跳转画面
                //TagPTInEnd form = new TagPTInEnd(comb_ParkingNO.Text.Trim());
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.ShowDialog();

                //string parkingNO = form.TAG_PARKING_NO;
                //bool cancelFlag = form.CANCEL_FLAG;

                //if (cancelFlag == false)
                //{
                //    //平台配置
                //    tagProvider_InStock.ServiceName = "iplature";
                //    tagProvider_InStock.AutoRegist = true;

                //    //添加tag点到数组
                //    TagValues1.Add("EV_PARKING_IN_PORTABLEEND", null);
                //    tagProvider_InStock.SetData("EV_PARKING_IN_PORTABLEEND", parkingNO);
                //}
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 车到位  
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_TreatmentNO.Text.Length>3)
                {
                    MessageBox.Show("车位已经有车！", "提示");
                    return;
                }
                Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();

                //有车到达  
                string theOperator = "HMI";
                //string date = "20170220155300";
                string date= DateTime.Now.ToString("yyyyMMddHHmmss");  //24小时制
                string shift = "1";
                string crew = "2";
                string pullAbility = "1";
                string equno = "101";

                ////跳转画面
                //string HeadPos = txt_HeadPos.Text.Trim();
                //switch (HeadPos)
                //{
                //    case "东":
                //        HeadPos = "E";
                //        break;
                //    case "西":
                //        HeadPos = "W";
                //        break;
                //    case "南":
                //        HeadPos = "S";
                //        break;
                //    case "北":
                //        HeadPos = "N";
                //        break;
                //    default:
                //        break;
                //}

                //string ISLoaded = txt_ISLoaded.Text.Trim();
                //switch (ISLoaded)
                //{
                //    case "空车":
                //        ISLoaded = "0";
                //        break;
                //    case "重车":
                //        ISLoaded = "1";
                //        break;
                //    default:
                //        break;
                //}

                if (!comb_ParkingNO.Text.Trim().Contains('F'))
                {
                    MessageBox.Show("请选择停车位！", "提示");
                    return;
                }
                //TagCarArrive form = new TagCarArrive(comb_ParkingNO.Text.Trim(), txt_CarNO.Text.Trim(), HeadPos, ISLoaded);
                TagCarArrive form = new TagCarArrive(comb_ParkingNO.Text.Trim());
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();

                string parkingNO = form.TAG_PARKING_NO;
                string carNO = form.TAG_CAR_NO;
                string isLoaded = form.TAG_ISLOADED;     //1为空，2为满(我们自己0 是空，1是满，要转换)
                string headPostion = form.TAG_HEAD_POSTION;
                string cartype = form.TAG_CAR_TYPE;
                string parkingype = form.TAG_PARKING_TYPE;
                bool cancelFlag = form.CANCEL_FLAG;

                if (cancelFlag == false)
                {
                    //平台配置
                    tagProvider_InStock.ServiceName = "iplature";
                    tagProvider_InStock.AutoRegist = true;

                    //添加tag点到数组
                    TagValues.Add("EV_PARKING_CARARRIVE", null);
                    //tagProvider_CarArrive.Attach(TagValues);
                    string tagCarInStosk = "";
                    tagCarInStosk = theOperator + "|" + date + "|" + shift + "|" + crew + "|" + parkingNO + "|" + carNO + "|" + isLoaded + "|" + headPostion + "|" + pullAbility + "|" + equno + "|" + cartype + "|" + parkingype;
                    //debug
                    //DialogResult dr = MessageBox.Show(string.Format("发送的Tag的myValue 的值：\n{0}\n", tagCarInStosk), "提示", MessageBoxButtons.YesNo);
                    //if (dr != DialogResult.Yes)
                    //{
                    //    return;
                    //}

                    //debug
                   // tagProvider_InStock.SetData("EV_NEW_PARKING_CARARRIVE", theOperator + "|" + date + "|" + shift + "|" + crew + "|" + parkingNO + "|" + carNO + "|" + isLoaded + "|" + headPostion + "|" + pullAbility + "|" + equno + "|" + cartype + "|" + parkingype);
                    tagProvider_InStock.SetData("EV_NEW_PARKING_CARARRIVE", tagCarInStosk);
                    ParkClassLibrary.HMILogger.WriteLog(cmd_CarArrive.Text, "车到位：" + tagCarInStosk, ParkClassLibrary.LogLevel.Info, this.Text);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 车离开  
        private void cmd_CarLeave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( !comb_ParkingNO.Text.Contains('F'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (GetParkStatus(comb_ParkingNO.Text.Trim())=="5"||txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不需要车离。");
                    btnRefresh_Click(null, null);
                    return;
                }
                if (!JudgeCraneOrder(comb_ParkingNO.Text))
                {
                    MessageBox.Show("行车已生成指令，不能车离！");
                    return;
                }
                int coilsNotComplete = checkParkingIsWorking(stowageId);
                if (coilsNotComplete > 0)
                {
                    MessageBox.Show("车位还有（" + coilsNotComplete + " )个卷没有完成!", "提示");
                }
                string coilManual = GetCoilManual(int.Parse(txt_LoadMapID.Text));
                {
                    if (txt_LoadMapID.Text != "" && coilManual != "")
                    {
                        MessageBox.Show("该车钢卷" + coilManual + "为人工吊运！", "提示");
                    }
                }
                if (comb_ParkingNO.Text.Trim() != "请选择" || comb_ParkingNO.Text.Trim() != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要对" + comb_ParkingNO.Text.Trim() + "跨进行车离位吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        tagProvider_InStock.SetData("EV_NEW_PARKING_CARLEAVE", comb_ParkingNO.Text.Trim());
                        MessageBox.Show("已通知" + comb_ParkingNO.Text.Trim() + "跨车离开");
                        //刷新开启
                        isStowage = false;
                        dt_Laser.Clear();
                        dataGridView_LASER.DataSource = dt_Laser;
                        dt_LoadMap.Clear();
                        dataGridView_LaodMap.DataSource = dt_LoadMap;
                        ParkClassLibrary.HMILogger.WriteLog(cmd_CarLeave.Text, "车离开：" + comb_ParkingNO.Text, ParkClassLibrary.LogLevel.Info, this.Text);

                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        private string GetParkStatus(string parkingNO)
        {
            string ret = "";
            if (!parkingNO.Contains('F'))
            {
                return ret;
            }
            try
            {
                string sqlText = @"SELECT PARKING_STATUS FROM UACS_PARKING_STATUS WHERE PARKING_NO = '" + parkingNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        ret = ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["PARKING_STATUS"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }
        #endregion

        #region 初始化方法
        private void Clear_ParkingStatus()
        {
            txt_TreatmentNO.Text = "";
            txt_CarNO.Text = "";
            txt_LoadMapID.Text = "";
            txt_ISLoaded.Text = "";
            txt_HeadPos.Text = "";
            txt_ParkingStatus.Text = "";
            txt_LASER_ACTION_COUNT.Text = "";
            txt_PT_ACTION_COUNT.Text = "";

             treatmentNO = string.Empty;
             ptCount = 0;
             laserCount = 0;
             stowageId = 0;
             headPosition = string.Empty;
        }
        #endregion

        #region tag变化刷新画面查询事件
        private void tagProvider_InStock_DataChangedEvent(object sender, Baosight.iSuperframe.TagService.Interface.DataChangedEventArgs e)
        {
            try
            {
                //停车位主体信息查询
                Inq_ParkingStatus();

                //手持扫描信息查询
                Inq_PT(treatmentNO, ptCount);

                //激光入库扫描信息查询
                Inq_Laser(treatmentNO, laserCount, headPosition);

                //框架配载图信息查询
                Inq_LoadMap(stowageId);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        #region 启动激光扫描  注释
        private void cmd_LaserINStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Baosight.iSuperframe.TagService.DataCollection<object> TagValuesStart = new DataCollection<object>();

                ////跳转画面
                //TagLaserInStart form = new TagLaserInStart(comb_ParkingNO.Text.Trim());
                //form.StartPosition = FormStartPosition.CenterScreen;
                //form.ShowDialog();

                //string parkingNO = form.TAG_PARKING_NO;
                //bool cancelFlag = form.CANCEL_FLAG;

                //if (cancelFlag == false)
                //{
                //    //平台配置
                //    tagProvider_InStock.ServiceName = "iplature";
                //    tagProvider_InStock.AutoRegist = true;

                //    //添加tag点到数组
                //    TagValuesStart.Add("EV_PARKING_LASERSTART", null);
                //    tagProvider_InStock.SetData("EV_PARKING_LASERSTART", parkingNO);
                //}
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion

        private void timer_RefrehHMI_Tick(object sender, EventArgs e)
        {
            if (!comb_ParkingNO.Text.Trim().Contains('F'))
            {
                GetParkInfoByBay();
                return; 
            }
            if (isStowage)
            {
                RefreshOrderDgv(comb_ParkingNO.Text);
                reflreshParkingCoilstate(comb_ParkingNO.Text.Trim());
                getCurCranesOrder();
                setCurParkStatus(comb_ParkingNO.Text);
            }
            //if (dataGridView_LaodMap.Rows.Count>1 && ((DataTable)dataGridView_LaodMap.DataSource).Rows.Count > 0)
            //{
            //    isStowage = true;
            //    txtDebug.Text = isStowage.ToString();
            //    return;
            //}
            if (dataGridView_LaodMap.DataSource != null && ((DataTable)dataGridView_LaodMap.DataSource).Rows.Count > 0)
            {
                isStowage = true;
                return;
            }
            else
            {
                isStowage = false;
                txtDebug.Text = isStowage.ToString();
            }
            RefreshHMI();
        }
        /// <summary>
        /// 绑定停车位信息
        /// </summary>
        private void GetComboxOnParking(ComboBox comBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string str1 = "";
                string str2 = "";
                
                if (cmbArea.Text.Contains("A"))
                {
                    str1 = "FIA";
                    //str2 = "B";
                }
                else if (cmbArea.Text.Contains("B"))
                {
                    str1 = "FIB";
                    //str2 = "C";
                }
                //else if (cmbArea.Text.Contains("6"))
                //{
                //    str1 = "Z11";
                //    str2 = "A";
                //}
                //else if (cmbArea.Text.Contains("7"))
                //{
                //    str1 = "Z11";
                //    str2 = "B";
                //}
                else
                {
                    
                }
                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();

                        if (rdr["TypeName"].ToString().Contains(str1) )
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }
                    }
                }
            
                //绑定列表下拉框数据
                comBox.DataSource = dt;
                comBox.DisplayMember = "TypeName";
                comBox.ValueMember = "TypeValue";
                comBox.SelectedItem = 0;
                //comBox.Text = "请选择";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private string GetOperateArea(string parkNO)
        {
            string area = "";
            try
            {
                if (parkNO.Contains("FIA"))
                {
                    area = "A跨";
                }
                else if (parkNO.Contains("FIB"))
                {
                    area = "B跨";
                }
                
                //else if (parkNO.Contains("Z12") && parkNO.Contains("B"))
                //{
                //    area = "1-4通道";
                //}
                //else if (parkNO.Contains("Z12") && parkNO.Contains("C"))
                //{
                //    area = "1-5通道";
                //}
                else
                { 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return area;
        }
        private string GetOperateAreaByBay(string parkNO)
        {
            string area = "";
            try
            {
                if (parkNO.Contains("Z53"))
                {
                    area = "成品-Z53跨";
                }
                else if (parkNO.Contains("Z52"))
                {
                    area = "成品-Z51跨";
                }
                else if (parkNO.Contains("Z51"))
                {
                    area = "成品-Z51跨";
                }
                else
                {
                    area = "轧后库";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return area;
        }
        #region 指令表信息
        /// <summary>
        /// 刷新指令表
        /// </summary>
        private void RefreshOrderDgv(string parkNO)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                string SQLOder = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                //SQLOder += " LEFT JOIN UACS_CRANE_ORDER_Z32_Z33 B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " RIGHT JOIN UACS_CRANE_ORDER_CURRENT B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}') ORDER BY  C.GROOVEID ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dt.Load(odrIn);
                }
                dgvCraneOder.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }

        } 
        #endregion

        #region 配载图
        /// <summary>
        /// 车上钢卷绑定激光数据
        /// </summary>
        /// <param name="strParkNo"></param>
        private bool LoadLaserInfo(string strParkNo, int laserActionCount, string carHeardDrection, ParkLaserOut park)
        {
            DataTable dtLaserData = new DataTable();
            DataTable dtParksize = new DataTable();
            //DataTable dtStowageData = new DataTable();
            bool ret = false;
            try
            {
                if (!strParkNo.Contains('F') || isStowage)
                {
                    return ret;
                }

                dtParksize.Clear();
                dtLaserData.Clear();
                park.ClearbitM();
                //停车位
                //string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}' ", strParkNo, cmbArea.Text.Substring(0, 1));
                string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}' ", strParkNo, comb_ParkingNO.Text.Substring(0, 3));
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlPark))
                {
                    dtParksize.Load(rdr);
                }
                //初始化停车位信息
                int XStart, XEnd, YStart, YEnd, XLength, YLength;

                XStart = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["X_START"]);
                XEnd = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["X_END"]);
                YStart = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["Y_START"]);
                YEnd = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["Y_END"]);
                XLength = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["X_LENGTH"]);
                YLength = ManagerHelper.JudgeIntNull(dtParksize.Rows[0]["Y_LENGTH"]);
                //初始化
                park.InitializeXY(park.Size.Width - 10, park.Size.Height - 10);
                //生成车位
                //宽增加0.5m、长度增加1.5m
                //park.CreatePassageWayArea(XStart - 500, YEnd + 1500, 5200, 16000);
                park.CreatePassageWayArea(XStart - 500, YEnd + 0, 5200, 17000); //2021-5-14 YEnd + 1500 改为 YEnd + 0
                park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart, carHeardDrection);
                //激光
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX, CAR_X_BORDER_MIN, CAR_Y_BORDER_MAX, CAR_Y_BORDER_MIN, X_ACT_CENTER, Y_ACT_CENTER, Z_ACT_CENTER, STEELWIDE, STEELDIAMETER,   "; 
                sqlLaser += " INDEX_Y FROM UACS_LASER_IN WHERE TREATMENT_NO IN ";
                sqlLaser += " (SELECT UACS_PARKING_STATUS.TREATMENT_NO FROM UACS_PARKING_STATUS WHERE UACS_PARKING_STATUS.PARKING_NO='" + strParkNo + "' AND LASER_ACTION_COUNT = '" + laserActionCount + "') ";

                if (carHeardDrection == "N" || carHeardDrection == "W")
                {
                    sqlLaser += "  ORDER BY Y_ACT_CENTER ASC ";
                }
                else if (carHeardDrection == "S" || carHeardDrection == "E")
                {
                    sqlLaser += "  ORDER BY Y_ACT_CENTER DESC ";                    
                }             
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                //车边框  没有
                park.HasCarSize = false;
                bool hasScan = false;
                //生成激光扫描结果--卷
                if (dtLaserData.Rows.Count > 0)
                {
                    foreach (DataRow item in dtLaserData.Rows)
                    {
                        int X1 = ManagerHelper.JudgeIntNull(item["X_ACT_CENTER"]);
                        int Y1 = ManagerHelper.JudgeIntNull(item["Y_ACT_CENTER"]);
                        int Z1 = ManagerHelper.JudgeIntNull(item["Z_ACT_CENTER"]);
                        int n1 = ManagerHelper.JudgeIntNull(item["STEELWIDE"]);    //宽度
                        int n2 = ManagerHelper.JudgeIntNull(item["STEELDIAMETER"]); //外径
                        string ID = ManagerHelper.JudgeStrNull(item["INDEX_Y"]);
                        //park.CreateCoilSize(X1, Y1, n1, n2, ID, true, ID, toolTip1);
                        park.CreateCoilSize(X1, Y1, n1, n2, ID, true, Y1.ToString(), toolTip1); //Y1
                    }
                    hasScan = true;
                }
                ////手持机扫
                //if (hasScan && dt_PT.Rows.Count > 0)
                //{
                //    Inq_PT(treatmentNO, ptCount);
                //    foreach (DataRow dTitem in dt_PT.Rows)
                //    {
                //        //string groIndex = ManagerHelper.JudgeStrNull(dTitem["INDEX_Y"]);
                //        string groIndex = ManagerHelper.JudgeStrNull(dTitem["COIL_POSITION_7"]).Substring(5, 1);
                //        string GroID = ManagerHelper.JudgeStrNull(dTitem["COIL_POSITION_7"]).Substring(5, 1);  //这句存在缺陷
                //        string matNO = ManagerHelper.JudgeStrNull(dTitem["MAT_NO"]);
                //        park.SetCoilsNmae(groIndex, GroID, matNO, toolTip1);
                //    }
                //    ret = true;
                //}

                //没手持机扫
                if (hasScan && dt_LoadMap.Rows.Count > 1)
                {
                    foreach (DataRow dTitem in dt_LoadMap.Rows)
                    {
                        string groX = ManagerHelper.JudgeStrNull(dTitem["Y_CENTER"]); //X_CENTER
                        string GroID = ManagerHelper.JudgeStrNull(dTitem["GROOVEID"]);
                        string matNO = ManagerHelper.JudgeStrNull(dTitem["MAT_NO"]);
                        park.SetCoilsNmae(groX, GroID, matNO, toolTip1);
                    }
                    ret = true;
                }
                return ret;
            }
            catch (Exception er)
            {
                //MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                LogManager.WriteProgramLog(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                LogManager.WriteProgramLog("--------------------------------------------------------------------------------------------------------");
                return ret;
            }
        }
        /// <summary>
        /// 单击钢卷事件
        /// </summary>
        /// <param name="matNO"></param>
        void park_LabClick(string matNO)
        {
            SelectDataGridViewRow(dataGridView_LaodMap, matNO, "Column1");
        }
        /// <summary>
        /// 定位到指定的行
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="searchString"></param>
        /// <param name="columnName"></param>
        private void SelectDataGridViewRow(DataGridView dgv, string searchString, string columnName)
        {
            try
            {
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.Cells[columnName].Value != null)
                    {
                        if (dgvRow.Cells[columnName].Value.ToString() == searchString)
                        {
                            dgv.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                            dgvRow.Cells[columnName].Selected = true;
                            dgv.CurrentCell = dgvRow.Cells[columnName];
                            return;
                        }
                    }
                }
                MessageBox.Show(string.Format("没有找到指定的钢卷：{0}", searchString));
            }

            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }
        }
        private bool reflreshParkingCoilstate(string parkNO)
        {
            DataTable dtStowage = new DataTable();
            bool ret = false;
            string matNO;
            string coilStatus;
            try
            {
                string sqlStowage = @" SELECT C.MAT_NO,C.STATUS FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                //sqlStowage += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                //sqlStowage += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                sqlStowage += " WHERE  CAR_NO IN ( SELECT CAR_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}')) ORDER BY GROOVEID ";
                sqlStowage = string.Format(sqlStowage, parkNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowage.Load(rdr);
                }
                if (dtStowage.Rows.Count > 0)
                {
                    foreach (DataRow item in dtStowage.Rows)
                    {
                        matNO = ManagerHelper.JudgeStrNull(item["MAT_NO"]);
                        coilStatus = ManagerHelper.JudgeStrNull(item["STATUS"]);
                        //parkLaserOut1.ChangeCoilState(matNO, coilStatus, "1");
                        parkLaserOut1.ChangeCoilState(matNO, coilStatus, false, false);
                        ret = true;
                    }
                }
                return ret;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                return ret;
            }

        } 
        #endregion
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            hasCar = true;
            isStowage = false;
            RefreshHMI();
        }

        private void txtPTcount_TextChanged(object sender, EventArgs e)
        {
            if (!txtPTcount.Text.Equals(txtLaserCount.Text))
            {
                txtPTcount.BackColor = Color.Yellow;
            }
            else
            {
                txtPTcount.BackColor = Color.White;
            }
        }

        private void txtLaserCount_TextChanged(object sender, EventArgs e)
        {
            if (!txtPTcount.Text.Equals(txtLaserCount.Text))
            {
                txtPTcount.BackColor = Color.Yellow;
            }
            else
            {
                txtPTcount.BackColor = Color.White;
            }
        }

        #region 作业开始
        private void btnOperateStrat_Click(object sender, EventArgs e)
        {
            string parkNO = comb_ParkingNO.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('F'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (parkNO != "请选择" || parkNO != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对" + parkNO + "作业开始？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagProvider_InStock.SetData("EV_PARKING_JOB_RESUME", parkNO);
                        tagProvider_InStock.SetData("EV_NEW_PARKING_JOB_RESUME", parkNO);
                        btnOperateStrat.ForeColor = Color.Green;
                        btnOperatePause.ForeColor = Color.White;
                        ParkClassLibrary.HMILogger.WriteLog(btnOperateStrat.Text, "作业开始：" + parkNO, ParkClassLibrary.LogLevel.Info, this.Text);

                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        /// <summary>
        /// 获取车位是否是暂停状态
        /// </summary>
        /// <param name="parkNO"></param>
        /// <returns></returns>
        private bool GetOperateStatus(string parkNO)
        {
            bool ret = false;
            try
            {
                string SQLOder = "  SELECT PARKING_STATUS FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}' ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(SQLOder))
                {
                    while (rdr.Read())
                    {
                        int status = 0;
                        status = ParkClassLibrary.ManagerHelper.JudgeIntNull(rdr["PARKING_STATUS"]);
                        if (status == 170) //暂停
                        {
                            ret = true;
                            break;
                        }
                    }
                }
                if (ret) //开始
                {
                    btnOperateStrat.ForeColor = Color.White;
                    btnOperatePause.ForeColor = Color.Orange;
                }
                else
                {
                    btnOperatePause.ForeColor = Color.White;
                    btnOperateStrat.ForeColor = Color.White;
                }
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return ret;
            }
            //
        } 
        #endregion

        #region 作业暂停
        private void btnOperatePause_Click(object sender, EventArgs e)
        {
            string parkNO = comb_ParkingNO.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('F'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txt_CarNO.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能开始。");
                    return;
                }

                if (parkNO != "请选择" || parkNO != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对" + parkNO + "作业暂停？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        //tagProvider_InStock.SetData("EV_PARKING_JOB_PAUSE", parkNO);
                        tagProvider_InStock.SetData("EV_NEW_PARKING_JOB_PAUSE", parkNO);
                        ParkClassLibrary.HMILogger.WriteLog(btnOperatePause.Text, "作业暂停：" + parkNO, ParkClassLibrary.LogLevel.Info, this.Text);
                        btnOperateStrat.ForeColor = Color.White;
                        btnOperatePause.ForeColor = Color.Orange;
                    }

                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        } 
        #endregion

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComboxOnParking(comb_ParkingNO);
        }

        #region 画面跳转
        private bool JumpToOtherForm(string currPark)
        {
            bool ret = false;
            Int16 carType = -1;
            string strStatus = GetParkStatus(currPark, out carType);
            if (strStatus == "")
            {
                return ret;
            }
            //if (strStatus.Substring(0, 1) == "2" && (carType != 101 && carType != 103)) //框架出库
            //{
            //    if (auth.IsOpen("成品库框架车出库"))
            //    {
            //        auth.CloseForm("成品库框架车出库");
            //    }
            //    auth.OpenForm("成品库框架车出库", currPark);
            //    ret = true;
            //}
            //else if (strStatus.Substring(0, 1) == "2" && (carType != 100 && carType != 102)) //社车出库
            //{
            //    if (auth.IsOpen("成品库社会车出库"))
            //    {
            //        auth.CloseForm("成品库社会车出库");
            //    }
            //    auth.OpenForm("成品库社会车出库", currPark);
            //    ret = true;
            //}
            if (strStatus.Substring(0, 1) == "2" )
            {
                if (auth.IsOpen("02 车辆出库"))
                {
                    auth.CloseForm("02 车辆出库");
                }
                auth.OpenForm("02 车辆出库", currPark);
                
                ret = true;
            }
            return ret;
        }
        /// <summary>
        /// 返回车位状态
        /// </summary>
        /// <param name="parkingNO"></param>
        /// <returns></returns>
        private string GetParkStatus(string parkingNO, out Int16 carType)
        {
            string ret = "";
            carType = -1;
            if (!parkingNO.Contains('F'))
            {
                return ret;
            }
            try
            {
                string sqlText = " SELECT C.PARKING_STATUS,A.CAR_TYPE FROM UACS_PARKING_STATUS  C ";
                sqlText += " LEFT JOIN UACS_TRUCK_STOWAGE A ON C.STOWAGE_ID = A.STOWAGE_ID ";
                sqlText += " WHERE PARKING_NO = '" + parkingNO + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        ret = ManagerHelper.JudgeStrNull(rdr["PARKING_STATUS"]);
                        carType = (Int16)ManagerHelper.JudgeIntNull(rdr["CAR_TYPE"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }
        #endregion
        private int checkParkingIsWorking(int stowageID)
        {
            int count = -1;
            try
            {
                string sqlText = " SELECT COUNT (*) COUNT FROM  UACS_TRUCK_STOWAGE_DETAIL WHERE STOWAGE_ID ='" + stowageID + "'  AND STATUS IN(0,30) ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        count = ManagerHelper.JudgeIntNull(rdr["COUNT"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return count;
        }
        private void TruckStowageInT_TabActivated(object sender, EventArgs e)
        {
            timer_RefrehHMI.Enabled = true; ;
        }

        private void TruckStowageInT_TabDeactivated(object sender, EventArgs e)
        {
            timer_RefrehHMI.Enabled = false; 
        }

        private void TruckStowageInT_Resize(object sender, EventArgs e)
        {
            if (this.Height == 0)
            { timer_RefrehHMI.Enabled = false; }
            else
            { timer_RefrehHMI.Enabled = true; }
        }

        private void comb_ParkingNO_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            JumpToOtherForm(comb_ParkingNO.Text);
        }

        private bool JudgeCraneOrder(string ParkingNo)
        {
            int count = 0;
            string fromStockNo = String.Empty;
            string toStockNo = String.Empty;
            try
            {
                string sql = "select * from UACS_CRANE_ORDER_CURRENT ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["FROM_STOCK_NO"] != DBNull.Value && rdr["TO_STOCK_NO"] != DBNull.Value)
                        {
                            fromStockNo = rdr["FROM_STOCK_NO"].ToString();
                            toStockNo = rdr["TO_STOCK_NO"].ToString();
                            if (fromStockNo.Contains(ParkingNo) || toStockNo.Contains(ParkingNo))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void parkLaserOut1_labDoubleClick(string matNO)
        {

            string status = GetCoilStatus(txt_LoadMapID.Text.Trim(), matNO);
            if (status == "101")
            {
                DialogResult dr = MessageBox.Show("是否将卷： " + matNO + "设为自动吊运？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    setCoilByMan(txt_LoadMapID.Text.Trim(), matNO, "100");
                    ParkClassLibrary.HMILogger.WriteLog("设置自动吊运", "设为自动吊运：" + matNO, ParkClassLibrary.LogLevel.Warn, this.Text, ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName());
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("是否将卷： " + matNO + "设为人工吊运？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    setCoilByMan(txt_LoadMapID.Text.Trim(), matNO, "101");
                    ParkClassLibrary.HMILogger.WriteLog("设置人工吊运", "设为人工吊运：" + matNO, ParkClassLibrary.LogLevel.Warn, this.Text, ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName());
                }
            }        

        }

        #region 获取钢卷吊运状态
        private string GetCoilStatus(string stowageID, string matNO)
        {
            string CoilStatus = "";
            try
            {
                string sql = " SELECT STATUS FROM UACS_TRUCK_STOWAGE_DETAIL WHERE MAT_NO = '" + matNO + "' AND STOWAGE_ID = '" + stowageID + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        CoilStatus = ManagerHelper.JudgeStrNull(rdr["STATUS"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return CoilStatus;
        }
        #endregion

        #region 设置为人工（自动）吊运
        private void setCoilByMan(string stowageID, string matNO, string status)
        {
            try
            {
                string sql = " UPDATE UACS_TRUCK_STOWAGE_DETAIL SET STATUS = '" + status + "'";
                sql += " WHERE MAT_NO = '" + matNO + "'";
                sql += " AND STOWAGE_ID = '" + stowageID + "'";
                DBHelper.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        #endregion

        private void dataGridView_LaodMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                if (dataGridView_LaodMap.Columns[e.ColumnIndex].Name.Equals("STATUS")
                    && dataGridView_LaodMap.Rows[e.RowIndex].Cells["Column1"].Value != null
                     && dataGridView_LaodMap.Rows[e.RowIndex].Cells["STATUS"].Value != null)
                {
                    string matNO = dataGridView_LaodMap.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    if (curOrderMatNO.Contains(matNO))
                    {
                        e.Value = "吊入中";
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else if (e.Value.ToString() == "0")
                    {
                        e.Value = "待吊入";
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                    else if (e.Value.ToString() == "100")
                    {
                        e.Value = "已吊入";
                        e.CellStyle.BackColor = Color.White;
                    }
                    else if (e.Value.ToString() == "101")
                    {
                        e.Value = "人工吊入";
                        e.CellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private bool getCurCranesOrder()
        {
            bool ret = false;
            List<string> lstTemp = new List<string>();
            try
            {
                string sqlText = @" SELECT MAT_NO FROM UACS_CRANE_ORDER_CURRENT WHERE CRANE_NO  IN('1','2','3','7','8') ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        lstTemp.Add(ParkClassLibrary.ManagerHelper.JudgeStrNull(rdr["MAT_NO"]));
                        ret = true;
                    }
                }
                curOrderMatNO = lstTemp.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }

        private string JudgeStrNull(object item)
        {
            string str = "";
            if (item == DBNull.Value)
            {
                return str;
            }
            else
            {
                str = item.ToString();
            }
            return str;
        }

        #region 车位状态显示

        /// <summary>
        /// 读取停车位状态
        /// </summary>
         private bool GetParkInfoByBay()
        {
            try
            {
                string sql = @"select A.PARKING_NO,A.ISLOADED,A.PARKING_STATUS,A.CAR_NO , B.CAR_TYPE from UACS_PARKING_STATUS A
                                LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID ";
                bool ret = true;
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {

                        if (cmbArea.Text.Contains("A"))
                        {

                            if (rdr["PARKING_NO"].ToString().Trim() == "FIA01")
                            {
                                park1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));

                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIA02")
                            {
                                park2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIA03")
                            {
                                park3.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));                              
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIA04")
                            {
                                park4.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                                //parkZ12B2.SetPark("", "", "", "", "");
                                //parkZ12B3.SetPark("", "", "", "", "");
                                //parkZ12B4.SetPark("", "", "", "", "");
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIA05")
                            {
                                park5.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIA06")
                            {
                                park6.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }                           
                        }
                        else if(cmbArea.Text.Contains("B"))
                        {
                            if (rdr["PARKING_NO"].ToString().Trim() == "FIB01")
                            {
                                park1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIB02")
                            {
                                park2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIB03")
                            {
                                park3.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIB04")
                            {
                                park4.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));                            
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIB05")
                            {
                                park5.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "FIB06")
                            {
                                park6.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }                           
                        }
                    }
                }
                
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return false;
            }
        }
        #endregion


         private void bindParkControlEvent()
         {
             foreach (var item in tabPanelParkArea.Controls)
             {
                 if (item is ParkingState)
                 {
                     ((ParkingState)item).sendMember += PorductMatManage_sendMember;
                 }
             }
         }

         void PorductMatManage_sendMember(string parkName)
         {
             if (!JumpToOtherForm(parkName))
             {
                 comb_ParkingNO.Text = parkName;
                 comb_ParkingNO_SelectedIndexChanged(null, null);
                 setCurParkStatus(parkName);
             }
         }

         private void setCurParkStatus(string parkName)
         {
             foreach (var item in tabPanelParkArea.Controls)
             {
                 if (item is ParkingState)
                 {
                     if (((ParkingState)item).ParkName == parkName)
                     {
                         ((ParkingState)item).setControilBackColor(Color.LightBlue);
                     }
                     else
                     {
                         ((ParkingState)item).setControilBackColor(SystemColors.InactiveCaption);
                     }
                 }
             }
         }

         private string GetCoilManual(int stowageID)
         {
             string matNo;
             string matNoList = "";
             List<string> lstTemp = new List<string>();
             try
             {
                 string sqlText = @"SELECT MAT_NO FROM UACS_TRUCK_STOWAGE_DETAIL  WHERE STOWAGE_ID ='" + stowageID + "' AND STATUS = '101'";
                 using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                 {
                     while (rdr.Read())
                     {
                         matNo = ManagerHelper.JudgeStrNull(rdr["MAT_NO"]);
                         lstTemp.Add(matNo);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
             }
             matNoList = String.Join(",", lstTemp.ToArray());
             return matNoList;
         }
    }
}
