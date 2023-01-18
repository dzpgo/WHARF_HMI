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
using Baosight.iSuperframe.Common;
using UACSDAL;
using ParkingControlLibrary;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class PorductMatManage : FormBase
    {
        IAuthorization auth = Baosight.iSuperframe.Common.FrameContext.Instance.GetPlugin<Baosight.iSuperframe.Authorization.Interface.IAuthorization>()
        as Baosight.iSuperframe.Authorization.Interface.IAuthorization;

        #region iPlature配置
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = null;
        public Baosight.iSuperframe.TagService.Controls.TagDataProvider TagDP
        {
            get
            {
                if (tagDP == null)
                {
                    try
                    {
                        tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
                        tagDP.ServiceName = "iplature";
                        tagDP.AutoRegist = true;
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return tagDP;
            }
            //set { tagDP = value; }
        }
        #endregion

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
        //datagridview1
        DataTable dt = new DataTable();
        DataTable dt_selected = new DataTable();
        DataTable dt_Laser = new DataTable();
        DataTable dtNull = new DataTable();
        ToolTip toolTip1 = new ToolTip();
        string carHearDrection = "";

        //
        bool hasSetColumn = false;
        bool hasParkSize = false;
        bool isStowage = false;
        bool hasCar = true;  //车位无车
        Int16 curCarType;  //当前车辆类型

        int coilsWeight = 0;   //添加材料重量
        //当前停车位，画面跳转
        string parkingNO = "";
        string[] curOrderMatNO = { };
        //
        string[] dgvColumnsName = { "GROOVEID", "MAT_NO", "FROM_STOCK_NO", "TO_STOCK_NO", "BAY_NO" };
        string[] dgvHeaderText = { "槽号", "材料号", "起卷库位", "落卷库位", "跨别" };
        //配载时间显示
        //private DateTime dtimeLaserEnd;
        bool isReadTime = false;
        string strLaserTime = "";
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        public PorductMatManage()
        {
            InitializeComponent();
            this.Load += PorductMatManage_Load;
        }
        public PorductMatManage(string parkNO)
        {
            InitializeComponent();
            this.Load += PorductMatManage_Load;
            //cmbArea.Text = GetOperateArea(parkNO);
            cmbArea.Text = GetOperateAreaByBay(parkNO);
            parkingNO = parkNO;
        }


        void PorductMatManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
        //tag点事件处理
        void tagDP_DataChangedEvent(object sender, Baosight.iSuperframe.TagService.Interface.DataChangedEventArgs e)
        {
            if (isStowage == true)
            {
                if (cbbPacking.Text.Contains('F'))
                {
                    reflreshParkingCoilstate(cbbPacking.Text.Trim());
                    RefreshOrderDgv(cbbPacking.Text.Trim());
                    return;
                }
            }
            RefreshHMI();
        }

        void PorductMatManage_Load(object sender, EventArgs e)
        {
            this.FormClosed += PorductMatManage_FormClosed;
            dataGridView2.CellFormatting += dataGridView2_CellFormatting;
            TagDP.DataChangedEvent += tagDP_DataChangedEvent;

            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dt_selected.Columns.Add(dataGridView2.Columns[i].Name);
            }
            //tagDP.ServiceName = "iplature";
            //tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("EV_NEW_PARKING_CARLEAVE", null);
            TagValues.Add("EV_NEW_PARKING_MDL_OUT_CAL_JUDGE", null);
            TagDP.Attach(TagValues);

            //初始化dataGridview属性
            ManagerHelper.DataGridViewInit(dataGridView2);
            ManagerHelper.DataGridViewInit(dataGridView_LASER);

            ManagerHelper.DataGridViewInit(dgvOrder);
            CreatDgvHeader(dgvOrder, dgvColumnsName, dgvHeaderText);
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GetComboxOnParkingByBay();
            cbbPacking.Text = "";
            cbbPacking.SelectedIndexChanged += cbbPacking_SelectedIndexChanged;
            //开启定时器、
            timer1.Enabled = true;
            #region  tooltipshow
            // Create the ToolTip and associate with the Form container.

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            #endregion

            parkLaserOut1.LabClick += parkLaserOut1_LabClick;
            parkLaserOut1.labDoubleClick += parkLaserOut1_labDoubleClick;
            if (parkingNO != "")//画面跳转
            {
                cbbPacking.Text = parkingNO;
            }
            //绑定双击事件
            bindParkControlEvent();
        }


        void cbbPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('F'))
            {
                isStowage = false;
                hasCar = true;
                hasParkSize = false;
                RefreshHMI();
                btnOperateStrat.ForeColor = Color.White;
                btnOperatePause.ForeColor = Color.White;
            }
            //
            isReadTime = false;
        }

        private string GetOperateArea(string parkNO)
        {
            string area = "";
            try
            {
                if (parkNO.Contains("Z11") && parkNO.Contains("A"))
                {
                    area = "1-6通道";
                }
                else if (parkNO.Contains("Z11") && parkNO.Contains("B"))
                {
                    area = "1-7通道";
                }

                else if (parkNO.Contains("Z12") && parkNO.Contains("B"))
                {
                    area = "1-4通道";
                }
                else if (parkNO.Contains("Z12") && parkNO.Contains("C"))
                {
                    area = "1-5通道";
                }
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
                if (parkNO.Contains("FIA"))
                {
                    area = "A跨";
                }
                else if (parkNO.Contains("FIB"))
                {
                    area = "B跨";
                }
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

        #region -----------------------------调用方法-------------------------------------
        /// <summary>
        /// 绑定停车位信息
        /// </summary>
        private void GetComboxOnParking()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            //准备数据
            try
            {
                string str1 = "";
                string str2 = "";

                if (cmbArea.Text.Contains("2"))
                {
                    str1 = "Z03";
                    str2 = "A";
                }
                else if (cmbArea.Text.Contains("3"))
                {
                    str1 = "Z03";
                    str2 = "B";
                }
                else if (cmbArea.Text.Contains("5"))
                {
                    str1 = "Z04";
                    str2 = "A";
                }
                else
                {

                }
                string sqlText = @"SELECT DISTINCT ID as TypeValue,NAME as TypeName FROM UACS_YARDMAP_PARKINGSITE ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();

                        if (rdr["TypeName"].ToString().Contains(str1) && rdr["TypeName"].ToString().Contains(str2) || cmbArea.Text.Trim() == "")
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            //绑定列表下拉框数据
            this.cbbPacking.DataSource = dt;
            this.cbbPacking.DisplayMember = "TypeName";
            this.cbbPacking.ValueMember = "TypeValue";
            cbbPacking.SelectedItem = 0;
            //cbbPacking.Text = "请选择";           //
        }
        private void GetComboxOnParkingByBay()
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
                    //str2 = "A";
                }
                else if (cmbArea.Text.Contains("B"))
                {
                    str1 = "FIB";
                    //str2 = "B";
                }
                //else if (cmbArea.Text.Contains("5"))
                //{
                //    str1 = "Z04";
                //    str2 = "A";
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
                        if (rdr["TypeName"].ToString().Contains(str1))
                        //if (rdr["TypeName"].ToString().Contains(str1) && rdr["TypeName"].ToString().Contains(str2) || cmbArea.Text.Trim() == "")
                        {
                            dr["TypeValue"] = rdr["TypeValue"];
                            dr["TypeName"] = rdr["TypeName"];
                            dt.Rows.Add(dr);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            //绑定列表下拉框数据
            this.cbbPacking.DataSource = dt;
            this.cbbPacking.DisplayMember = "TypeName";
            this.cbbPacking.ValueMember = "TypeValue";
            cbbPacking.SelectedItem = 0;
            //cbbPacking.Text = "请选择";           //
        }
        /// <summary>
        /// 查询车号
        /// </summary>
        /// <param name="parking">停车位</param>
        private string GetTextOnCar(string parking)
        {
            try
            {
                string str = "";
                //txtCarNo.Text = "";
                string sql = string.Format("select CAR_NO,HEAD_POSTION ,TREATMENT_NO,STOWAGE_ID ,LASER_ACTION_COUNT from UACS_PARKING_STATUS where PARKING_NO = '{0}' ", parking);

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        txtTeratmentNO.Text = JudgeStrNull(rdr["TREATMENT_NO"]);
                        txtLaserCount.Text = JudgeStrNull(rdr["LASER_ACTION_COUNT"]);
                        txtStowageID.Text = JudgeStrNull(rdr["STOWAGE_ID"]);
                        if (rdr["CAR_NO"] != DBNull.Value)
                        {
                            str = rdr["CAR_NO"].ToString();
                        }
                        else
                        {
                            str = "";
                        }

                        if (rdr["HEAD_POSTION"] != DBNull.Value)
                        {
                            if (rdr["HEAD_POSTION"].ToString() == "E")
                            {
                                txtCarHeadToward.Text = "东";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "W")
                            {
                                txtCarHeadToward.Text = "西";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "S")
                            {
                                txtCarHeadToward.Text = "南";
                            }
                            else if (rdr["HEAD_POSTION"].ToString() == "N")
                            {
                                txtCarHeadToward.Text = "北";
                            }
                            carHearDrection = rdr["HEAD_POSTION"].ToString();
                        }
                        else
                        {
                            txtCarHeadToward.Text = "";
                            carHearDrection = "";
                        }
                    }
                    txtCarNo.Text = str;
                    return str;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return "";
            }
        }

        /// <summary>
        /// 获得配载ID
        /// </summary>
        /// <param name="parking"></param>
        /// <returns></returns>
        private string GetStowageID(string parking, string carNo)
        {
            try
            {
                string str = "";
                string sql = string.Format(" select STOWAGE_ID from UACS_TRUCK_STOWAGE where rownum<=1 And FRAME_LOCATION='{0}' AND FRAME_NO = '{1}' order by STOWAGE_ID desc", parking, carNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOWAGE_ID"] != DBNull.Value)
                        {
                            str = rdr["STOWAGE_ID"].ToString();
                        }
                    }
                }
                return str;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return "";
            }
        }
        /// <summary>
        /// 获取配载信息
        /// </summary>
        /// <param name="stowageID"></param>
        /// <returns></returns>
        private bool GetStowageDetail()
        {
            bool retu = false;
            try
            {
                //查询是车位状态
                string carNo = GetTextOnCar(cbbPacking.Text.Trim());
                if (carNo != "" && cbbPacking.Text.Contains('F') && cbbPacking.Text.Trim() != "请选择")
                {
                    string strStowageID = GetStowageID(cbbPacking.Text.Trim(), carNo); //"1451";// 
                    if (strStowageID != "")
                    {
                        string sql = @"select C.GROOVEID,C.MAT_NO as COIL_NO2,A.LOT_NO as LOT_NO,C.X_CENTER as GROOVE_ACT_X ,C.Y_CENTER  AS GROOVE_ACT_Y,C.Z_CENTER AS GROOVE_ACT_Z, B.WEIGHT, B.WIDTH,B.INDIA ,B.OUTDIA ,D.STOCK_NO, D.LOCK_FLAG,B.PACK_FLAG ,C.STATUS from UACS_TRUCK_STOWAGE_DETAIL C ";
                        sql += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
                        sql += " LEFT JOIN  UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                        sql += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE D ON C.MAT_NO = D.MAT_NO ";
                        sql += string.Format(" where STOWAGE_ID = '{0}' order by C.GROOVEID", strStowageID);
                        DataGridViewBindingSource(dataGridView2, sql);
                        //没找到数据，返回
                        if (((DataTable)dataGridView2.DataSource).Rows.Count == 0)
                        {
                            return retu;
                        }
                        retu = true;
                        return retu;
                    }
                }
                dtNull.Clear();
                dataGridView2.DataSource = dtNull;
                //isStowage = true;
                return retu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
                return retu;
            }
        }

        /// <summary>
        /// 绑定材料位置信息
        /// </summary>
        private void BindMatStock(string packing, string planNo = null)
        {
            if (!packing.Contains('F') || packing.Trim() == "")
            {
                return;
            }
            dt.Clear();

            //if (this.cbbPacking.SelectedValue == null)
            //{
            //    return;
            //}


            //string pickNo = this.cbbPacking.SelectedValue.ToString();

            //发货(根据库位状态和封锁标记只查出可吊的钢卷)
            //string sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO, A.PICK_NO as PLAN_NO,A.DESTINATION, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, J.X_CENTER, J.Y_CENTER, J.Z_CENTER ,";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_PLAN_L3PICK A ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK I ON I.STOCK_NO = C.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE J ON J.SADDLE_NO = I.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";

            //string sqlText = @"SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PICK_NO as PLAN_NO, A.DESTINATION, C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, C.X_CENTER, C.Y_CENTER, C.Z_CENTER ,";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
            //sqlText += "WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
            //sqlText += "AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL";
            //sqlText += " order by C.STOCK_NO DESC";

            //dataGridView1.Columns["PACK_FLAG"].Visible = false; xx
            //dataGridView1.Columns["SLEEVE_WIDTH"].Visible = false; xxx
            //dataGridView1.Columns["COIL_OPEN_DIRECTION"].Visible = false; xxx
            //dataGridView1.Columns["NEXT_UNIT_NO"].Visible = false; xxx
            //dataGridView1.Columns["STEEL_GRANDID"].Visible = false;   xx
            //dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            //dataGridView1.Columns["ACT_WIDTH"].Visible = false;
            //dataGridView1.Columns["DESTINATION"].Visible = false; xx

            string sqlText_All = @"  SELECT 0 AS CHECK_COLUMN, C.MAT_NO AS COIL_NO, A.PICK_NO as PLAN_NO,  C.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA,";
            sqlText_All += "    D.X_CENTER, D.Y_CENTER, C.Z_CENTER ,";
            sqlText_All += " B.ACT_WEIGHT, B.ACT_WIDTH FROM UACS_YARDMAP_STOCK_DEFINE C ";
            sqlText_All += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_PLAN_L3PICK A ON C.MAT_NO = A.COIL_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_STOCK E ON C.STOCK_NO = E.STOCK_NO ";
            sqlText_All += " LEFT JOIN  UACS_YARDMAP_SADDLE_DEFINE D  ON E.SADDLE_NO = D.SADDLE_NO ";

            if (planNo == null)
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }
            else if (planNo.Trim().Length > 4)
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND A.PICK_NO  like '" + "%" + planNo + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }
            else
            {
                sqlText_All += " WHERE  C.BAY_NO  like '" + packing.Substring(0, 3) + "%' ";
                sqlText_All += " AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 AND C.MAT_NO IS NOT NULL  ";
                sqlText_All += " order by C.STOCK_NO DESC ";
            }

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_All))
            {
                while (rdr.Read())
                {
                    if (!hasSetColumn)
                    {
                        setDataColumn(dt, rdr);
                    }
                    hasSetColumn = true;
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        dr[i] = rdr[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            #region 转库计划
            //转库(根据库位状态和封锁标记只查出可吊的钢卷)
            //sqlText = @"SELECT 0 AS CHECK_COLUMN, A.COIL_NO,A.PLAN_NO, G.BAY_NO, C.STOCK_NO, B.WEIGHT, B.WIDTH, B.INDIA, B.OUTDIA, ";
            //sqlText += "B.PACK_FLAG, B.SLEEVE_WIDTH, B.COIL_OPEN_DIRECTION, B.NEXT_UNIT_NO, B.STEEL_GRANDID, ";
            //sqlText += "B.ACT_WEIGHT, B.ACT_WIDTH, C.X_CENTER, C.Y_CENTER, C.Z_CENTER FROM UACS_PLAN_L3TRANS A ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_COIL B ON A.COIL_NO = B.COIL_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON C.MAT_NO = A.COIL_NO AND C.STOCK_STATUS = 2 AND C.LOCK_FLAG = 0 ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_STOCK D ON C.STOCK_NO = D.STOCK_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_SADDLE_DEFINE E ON D.SADDLE_NO = E.SADDLE_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE F ON E.COL_ROW_NO = F.COL_ROW_NO ";
            //sqlText += "LEFT JOIN UACS_YARDMAP_AREA_DEFINE G ON F.AREA_NO = G.AREA_NO ";
            //sqlText += "WHERE A.PLAN_NO = '{0}' ";
            //sqlText = string.Format(sqlText, pickNo);
            //using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            //{
            //    while (rdr.Read())
            //    {
            //        if (!hasSetColumn)
            //        {
            //            setDataColumn(dt, rdr);
            //        }
            //        hasSetColumn = true;
            //        DataRow dr = dt.NewRow();
            //        for (int i = 0; i < rdr.FieldCount; i++)
            //        {
            //            dr[i] = rdr[i];
            //        }
            //        dt.Rows.Add(dr);
            //    }
            // } 
            #endregion

            //this.dataGridView1.DataSource = dt;
            //隐藏列
            //dataGridView1.Columns["PACK_FLAG"].Visible = false;
            //dataGridView1.Columns["SLEEVE_WIDTH"].Visible = false;
            //dataGridView1.Columns["COIL_OPEN_DIRECTION"].Visible = false;
            //dataGridView1.Columns["NEXT_UNIT_NO"].Visible = false;
            //dataGridView1.Columns["STEEL_GRANDID"].Visible = false;
            //dataGridView1.Columns["ACT_WEIGHT"].Visible = false;
            //dataGridView1.Columns["ACT_WIDTH"].Visible = false;
            //dataGridView1.Columns["DESTINATION"].Visible = false; 
        }
        /// <summary>
        /// 设置table的列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rdr"></param>
        private void setDataColumn(DataTable dt, IDataReader rdr)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = rdr.GetName(i);
                dt.Columns.Add(dc);
            }
            //

        }

        /// <summary>
        /// 激光扫描数据
        /// </summary>
        /// <returns></returns>
        private bool RefreshHMILaserOutData()
        {
            bool bResut = false;
            try
            {
                string parkingNo = "";
                string TREATMENT_NO = "";
                long LASER_ACTION_COUNT = 0;

                // 读取车牌数据
                string truckNo = txtCarNo.Text.Trim();      //车号
                if (truckNo == "")
                {
                    return bResut;
                }

                // 车号对应的停车位数据
                string sqlText = @"SELECT PARKING_NO FROM UACS_PARKING_STATUS WHERE CAR_NO = '{0}'";
                sqlText = string.Format(sqlText, truckNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    if (rdr.Read())
                    {
                        parkingNo = rdr["PARKING_NO"].ToString();
                    }
                }
                // this.lbParkingNo.Text = parkingNo;

                //先获取车头方向配置表里的车长方向坐标轴和趋势
                string AXES_CAR_LENGTH = "";
                string TREND_TO_TAIL = "";
                string sqlText_head = @"SELECT AXES_CAR_LENGTH, TREND_TO_TAIL FROM UACS_HEAD_POSITION_CONFIG WHERE HEAD_POSTION IN ";
                sqlText_head += "(SELECT HEAD_POSTION FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{0}') AND PARKING_NO = '{0}'";
                sqlText_head = string.Format(sqlText_head, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_head))
                {
                    if (rdr.Read())
                    {
                        AXES_CAR_LENGTH = rdr["AXES_CAR_LENGTH"].ToString();
                        TREND_TO_TAIL = rdr["TREND_TO_TAIL"].ToString();
                    }
                }

                string sqlorder = "";
                if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "INC")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_X ";
                }
                else if (AXES_CAR_LENGTH == "X" && TREND_TO_TAIL == "DES")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_X DESC";
                }
                else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "INC")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_Y ";
                }
                else if (AXES_CAR_LENGTH == "Y" && TREND_TO_TAIL == "DES")
                {
                    sqlorder = "ORDER BY GROOVE_ACT_Y DESC";

                }

                //从停车位表里取出处理号和激光扫描次数
                sqlText = @"SELECT TREATMENT_NO, LASER_ACTION_COUNT FROM UACS_PARKING_STATUS WHERE PARKING_NO='{0}' ";
                sqlText = string.Format(sqlText, parkingNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        TREATMENT_NO = rdr["TREATMENT_NO"].ToString();
                        LASER_ACTION_COUNT = Convert.ToInt64(rdr["LASER_ACTION_COUNT"].ToString());
                    }
                }

                //string GROOVE_ACT_X = "";
                //string GROOVE_ACT_Y = "";
                //string GROOVE_ACT_Z = "";
                //string GROOVEID = "";
                dt_selected.Clear();

                //从出库激光表里取出激光扫描数据
                sqlText = @"SELECT GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVEID FROM UACS_LASER_OUT ";
                sqlText += "WHERE TREATMENT_NO = '{0}' AND LASER_ACTION_COUNT = '{1}' ";
                sqlText += sqlorder;
                sqlText = string.Format(sqlText, TREATMENT_NO, LASER_ACTION_COUNT);

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    //while (rdr.Read())
                    //{
                    //    GROOVE_ACT_X = rdr["GROOVE_ACT_X"].ToString();
                    //    GROOVE_ACT_Y = rdr["GROOVE_ACT_Y"].ToString();
                    //    GROOVE_ACT_Z = rdr["GROOVE_ACT_Z"].ToString();
                    //    GROOVEID = rdr["GROOVEID"].ToString();
                    //    dt_selected.Rows.Add(GROOVEID, "", "", "", "", GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z);
                    //}
                    dt_selected.Load(rdr);
                }
                this.dataGridView2.DataSource = dt_selected;

                bResut = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

            return bResut;
        }

        /// <summary>
        /// 与配载信息匹配
        /// </summary>
        /// <param name="treatmentNo"></param>
        /// <param name="LASER_ACTION_COUNT"></param>
        /// <returns></returns>
        private bool CheckWithLaserOutData(string treatmentNo, long LASER_ACTION_COUNT)
        {
            bool bResult = false;
            string sqlText;

            try
            {
                // 获取最新激光扫描数据（从出库激光表里取出激光扫描数据）
                Dictionary<string, LASER_OUT_DATA> dictGrooveIDLaserOut = new Dictionary<string, LASER_OUT_DATA>();
                sqlText = @"SELECT GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z, GROOVEID FROM UACS_LASER_OUT ";
                sqlText += "WHERE TREATMENT_NO = '{0}' AND LASER_ACTION_COUNT = '{1}' ";
                sqlText = string.Format(sqlText, treatmentNo, LASER_ACTION_COUNT);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        LASER_OUT_DATA laseroutData;
                        laseroutData.GROOVE_ACT_X = rdr["GROOVE_ACT_X"].ToString();
                        laseroutData.GROOVE_ACT_Y = rdr["GROOVE_ACT_Y"].ToString();
                        laseroutData.GROOVE_ACT_Z = rdr["GROOVE_ACT_Z"].ToString();
                        laseroutData.GROOVEID = rdr["GROOVEID"].ToString();

                        dictGrooveIDLaserOut[laseroutData.GROOVEID] = laseroutData;
                    }
                }

                // 与画面选定的配载信息比对
                int nCountCoil = 0;
                int nCountChecked = 0;
                for (int i = 0; i < dt_selected.Rows.Count; i++)
                {
                    if (i < 30)
                    {
                        string coilNO = dt_selected.Rows[i]["COIL_NO2"].ToString().Trim();
                        if (coilNO.Length != 0)
                        {
                            nCountCoil++;

                            // 配过卷的
                            string GROOVEID = dt_selected.Rows[i]["GROOVEID"].ToString();
                            string GROOVE_X = dt_selected.Rows[i]["GROOVE_ACT_X"].ToString();
                            string GROOVE_Y = dt_selected.Rows[i]["GROOVE_ACT_Y"].ToString();
                            string GROOVE_Z = dt_selected.Rows[i]["GROOVE_ACT_Z"].ToString();

                            if (dictGrooveIDLaserOut.ContainsKey(GROOVEID))
                            {
                                LASER_OUT_DATA laserout = dictGrooveIDLaserOut[GROOVEID];

                                // 画面数据与选择数据匹配
                                if (laserout.GROOVE_ACT_X == GROOVE_X &&
                                    laserout.GROOVE_ACT_Y == GROOVE_Y &&
                                    laserout.GROOVE_ACT_Z == GROOVE_Z)
                                {
                                    nCountChecked++;
                                }
                            }
                        }
                    }
                }
                // 数据与后台均匹配
                if (nCountChecked == nCountCoil && nCountCoil != 0)
                    bResult = true;
            }
            catch (Exception er)
            {
                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

            return bResult;
        }
        #endregion



        #region -----------------------------控件事件-------------------------------------




        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isStowage = false;
            hasCar = true;
            hasParkSize = false;
            RefreshHMI();
        }
        /// <summary>
        /// 刷新画面
        /// </summary>
        private void RefreshHMI()
        {
            bool stopRefresh = false;
            if (isStowage)
            {
                return;
            }
            if (cbbPacking.Text.Trim().Contains('F'))
            {
                //刷新车位信息
                string temp = GetTextOnCar(cbbPacking.Text.Trim());
                if (temp != "")
                {
                    GetParkStatus(cbbPacking.Text, out curCarType);
                }
                //框架车获取车身信息
                //if (curCarType == 100 || curCarType == 102) //车辆类型（100：框架 101：社会车辆 102：大头娃娃车 103：17m社会车辆）
                {
                    getCarBorderSize(txtLaserCount.Text, txtTeratmentNO.Text);
                    GetCurrentCarInfo(cbbPacking.Text);
                }
                //查询车位状态,是否是暂停状态
                GetOperateStatus(cbbPacking.Text.Trim());
                //string strPacking = cbbPacking.Text.Trim().Substring(0, 3);
                //StringBuilder sbb = new StringBuilder(strPacking);
                //sbb.Append("-1");
                //BindMatStock(sbb.ToString());

                //刷新通道全部车位
                // GetParkInfo();
                GetParkInfoByBay();
                if (!hasCar)
                {
                    stopRefresh = txtTeratmentNO.Text.Contains('F');
                    hasCar = stopRefresh;
                    return;
                }
                //刷新指令表
                RefreshOrderDgv(cbbPacking.Text.Trim());
                //刷新激光图像配载数据
                LoadLaserInfo(cbbPacking.Text.Trim(), parkLaserOut1);
                //刷新激光数据
                Inq_Laser(txtTeratmentNO.Text, txtLaserCount.Text);

                //获得配载数据
                GetStowageDetail();

                //计算重量
                CalculteWeight();
                //刷新车上卷状态
                reflreshParkingCoilstate(cbbPacking.Text.Trim());

                stopRefresh = txtTeratmentNO.Text.Contains('F');
                hasCar = stopRefresh;
                //txtDebug.Text = hasCar.ToString();//没车只刷一次
                setCurParkStatus(cbbPacking.Text.Trim());

                displayStowageTime(labTime, txtStowageID.Text.Trim()); // //显示配载生成后的时间差
            }
        }
        private void CalculteWeight()
        {
            txtCoilsWeight.Text = "";
            if (txtCoilsWeight.Text == "" && dataGridView2.Rows.Count != 0)
            {
                int n1 = 0;
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if (item.Cells["WEIGHT2"].Value != null)
                    {
                        n1 += JudgeIntNull(item.Cells["WEIGHT2"].Value);
                    }
                }
                txtCoilsWeight.Text = string.Format("{0} /公斤", n1.ToString());
                if (n1 > 500000)
                    txtCoilsWeight.BackColor = Color.Red;
                else
                    txtCoilsWeight.BackColor = Color.White;
            }

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





        /// <summary>
        /// 停车位变化刷新激光数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCarNo_TextChanged(object sender, EventArgs e)
        {
            //改在车位刷新
            if (txtCarNo.Text.Trim().Length > 2)
            {
                //判断是否已经配载
                if (cbbPacking.Text.Trim().Contains('F'))
                {
                    if (!GetStowageDetail())
                    {
                        //RefreshHMILaserOutData();
                    }
                }
            }

        }

        #region 车到达
        /// <summary>
        /// 车到达
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarEnter_Click(object sender, EventArgs e)
        {

            if (!cbbPacking.Text.Trim().Contains('F'))
            {
                MessageBox.Show("请选择停车位！", "提示");
                return;
            }
            else if (txtTeratmentNO.Text.Trim() != "")
            {
                MessageBox.Show("车位已经有车！", "警告");
            }
            //if (GetTextOnCar(cbbPacking.Text.Trim()) == "")
            else
            {
                FrmCarEntry frm = new FrmCarEntry();
                frm.PackingNo = cbbPacking.Text.Trim();
                //frm.CarType = "社会车";
                frm.CarType = "ALL";
                frm.ShowDialog();
                curCarType = frm.CarTypeValue1550 != 0 ? frm.CarTypeValue1550 : curCarType;
                if (curCarType == 100 || curCarType == 101 || curCarType == 102 || curCarType == 103)
                {
                    btnSeleceByMat.Enabled = true;
                }
                else
                {
                    btnSeleceByMat.Enabled = false;
                }
            }
        }
        #endregion

        #region 车离

        /// <summary>
        /// 车离开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarFrom_Click(object sender, EventArgs e)
        {
            if (!cbbPacking.Text.Contains('F'))
            {
                MessageBox.Show("请选择停车位。");
                return;
            }
            if (GetParkStatus(cbbPacking.Text.Trim()) == "5")
            {
                MessageBox.Show("车位无车，不需要车离。");
                btnRefresh_Click(null, null);
                return;
            }
            if (!JudgeCraneOrder(cbbPacking.Text))
            {
                MessageBox.Show("行车已生成指令，不能车离！");
                return;
            }
            int coilsNotComplete = checkParkingIsWorking(int.Parse(txtStowageID.Text));
            if (txtStowageID.Text != "" && coilsNotComplete > 0)
            {
                MessageBox.Show("车位还有（" + coilsNotComplete + " )个卷没有完成!", "提示");
            }
            string coilManual = GetCoilManual(int.Parse(txtStowageID.Text));
            {
                if (txtStowageID.Text != "" && coilManual != "")
                {
                    MessageBox.Show("该车钢卷" + coilManual + "为人工吊运！", "提示");
                }
            }
            if (cbbPacking.Text.Contains('F'))
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要对" + cbbPacking.Text.Trim() + "跨进行车离位吗？", "操作提示", btn, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    TagDP.SetData("EV_NEW_PARKING_CARLEAVE", cbbPacking.Text.Trim());
                    //画面清空
                    dt_selected.Clear();
                    dataGridView2.DataSource = dt_selected;
                    //重量清空
                    coilsWeight = 0;
                    txtCoilsWeight.Text = string.Format("{0}/吨", coilsWeight);
                    txtCoilsWeight.BackColor = Color.White;
                    txtSelectGoove.Text = "";
                    ParkClassLibrary.HMILogger.WriteLog(btnCarFrom.Text, "车离：" + cbbPacking.Text, ParkClassLibrary.LogLevel.Info, this.Text);
                }
                isStowage = false;
                hasParkSize = false;
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
        #endregion



        #region 车位状态显示

        /// <summary>
        /// 读取停车位状态
        /// </summary>
        private bool GetParkInfo()
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
                        //Z3
                        if (cbbPacking.Text.Contains("Z3"))
                        {
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z32A1")
                            {
                                park1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z33A1")
                            {
                                park2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                        }
                        else if (cbbPacking.Text.Contains("Z5") && cmbArea.Text.Trim().Contains("7-1"))
                        {
                            //Z5 7-1
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z51A1")
                            {
                                park5.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));

                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z51A2")
                            {
                                park6.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52A1")
                            {
                                park3.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52A2")
                            {
                                park4.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53A1")
                            {
                                park1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53A2")
                            {
                                park2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                        }

                        else if (cbbPacking.Text.Contains("Z5") && cmbArea.Text.Trim().Contains("7-2"))
                        {
                            //Z5 7-2
                            if (rdr["PARKING_NO"].ToString().Trim() == "Z51B1")
                            {
                                park5.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));

                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z51B2")
                            {
                                park6.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52B1")
                            {
                                park3.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z52B2")
                            {
                                park4.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53B1")
                            {
                                park1.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                            else if (rdr["PARKING_NO"].ToString().Trim() == "Z53B2")
                            {
                                park2.SetPark(JudgeStrNull(rdr["PARKING_NO"]), JudgeStrNull(rdr["ISLOADED"]), JudgeStrNull(rdr["PARKING_STATUS"]), JudgeStrNull(rdr["CAR_NO"]), JudgeStrNull(rdr["CAR_TYPE"]));
                            }
                        }


                        // if (rdr["CAR_NO"] != DBNull.Value)

                    }

                }

                string treatmentNO = txtTeratmentNO.Text;
                string laserCount = txtLaserCount.Text;
                string sqlTextTotal = @"SELECT COUNT(distinct(LASER_ID)) AS IDTOTAL  FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlTextTotal += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextTotal))
                {
                    while (rdr.Read())
                    {
                        if (rdr["IDTOTAL"] != System.DBNull.Value)
                        {
                            //txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                            if (Convert.ToInt16(rdr["IDTOTAL"]) == 0 && txtCarNo.Text.Equals(""))
                            {
                                txtSelectGoove.Text = "";
                                txtSelectGoove.BackColor = SystemColors.Control;
                            }
                            else if (curCarType == 100)
                            {
                                txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                                txtSelectGoove.BackColor = txtSelectGoove.Text == txtGrooveNum.Text ? SystemColors.Control : txtSelectGoove.BackColor = Color.Red; ;
                            }
                            else
                            {
                                txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                                txtSelectGoove.BackColor = SystemColors.Control;
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

                string treatmentNO = txtTeratmentNO.Text;
                string laserCount = txtLaserCount.Text;
                string sqlTextTotal = @"SELECT COUNT(distinct(LASER_ID)) AS IDTOTAL  FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlTextTotal += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextTotal))
                {
                    while (rdr.Read())
                    {
                        if (rdr["IDTOTAL"] != System.DBNull.Value)
                        {
                            //txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                            if (Convert.ToInt16(rdr["IDTOTAL"]) == 0 && txtCarNo.Text.Equals(""))
                            {
                                txtSelectGoove.Text = "";
                                txtSelectGoove.BackColor = SystemColors.Control;
                            }
                            else if (curCarType == 100)
                            {
                                txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                                txtSelectGoove.BackColor = txtSelectGoove.Text == txtGrooveNum.Text ? SystemColors.Control : txtSelectGoove.BackColor = Color.Red; ;
                            }
                            else
                            {
                                txtSelectGoove.Text = Convert.ToString(rdr["IDTOTAL"]);
                                txtSelectGoove.BackColor = SystemColors.Control;
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

        #region 方法
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
        private int JudgeIntNull(object item)
        {
            int ret = 0;
            if (item == DBNull.Value)
            {
                return ret;
            }
            else
            {
                ret = Convert.ToInt32(item);
            }
            return ret;
        }
        ///// <summary>
        ///// 用于DataGridView初始化一般属性
        ///// </summary>
        ///// <param name="dataGridView"></param>
        ///// <returns></returns>
        //public static string DataGridViewInit(DataGridView dataGridView)
        //{
        //    dataGridView.ReadOnly = true;
        //    //foreach (DataGridViewColumn c in dataGridView.Columns)
        //    //    if (c.Index != 0) c.ReadOnly = true;
        //    //列标题属性
        //    dataGridView.AutoGenerateColumns = false;
        //    dataGridView.EnableHeadersVisualStyles = false;
        //    dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;//标题背景颜色

        //    //设置列高
        //    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //    dataGridView.ColumnHeadersHeight = 35;
        //    //设置标题内容居中显示;  
        //    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


        //    dataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DodgerBlue;
        //    dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //设置行属性
        //    dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dataGridView.RowHeadersVisible = false;  //隐藏行标题
        //    //禁止用户改变DataGridView1所有行的行高  
        //    dataGridView.AllowUserToResizeRows = false;
        //    dataGridView.RowTemplate.Height = 30;

        //    dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
        //    dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
        //    return "";
        //}
        public static bool DataGridViewBindingSource(DataGridView dataGridView, string sql)
        {
            DataTable dt = new DataTable();
            using (IDataReader odrIn = DBHelper.ExecuteReader(sql))
            {
                try
                {
                    dt.Load(odrIn);
                    dataGridView.DataSource = dt;
                    foreach (DataGridViewColumn item in dataGridView.Columns)
                    {
                        if (item.Name == "Index")
                        {
                            for (int y = 0; y < dataGridView.Rows.Count - 1; y++)
                            {
                                dataGridView.Rows[y].Cells["Index"].Value = y;
                            }
                            break;
                        }
                    }

                }
                catch (Exception meg)
                {
                    MessageBox.Show(string.Format("调用函数DataGridViewBindingSource出错：{0}", meg));
                }
                odrIn.Close();
                return true;
            }
        }
        private bool CreatDgvHeader(DataGridView dataGridView, string[] columnsName, string[] headerText)
        {
            bool isFirst = false;
            if (!isFirst)
            {
                //dataGridView.Columns.Add("Index", "序号");
                //DataGridViewColumn columnIndex = new DataGridViewTextBoxColumn();
                //columnIndex.Width = 50;
                //columnIndex.DataPropertyName = "Index";
                //columnIndex.Name = "Index";
                //columnIndex.HeaderText = "序号";
                //dataGridView.Columns.Add(columnIndex);
                for (int i = 0; i < headerText.Count(); i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = columnsName[i];
                    column.Name = columnsName[i];
                    column.HeaderText = headerText[i];
                    if (i > 0)
                    {
                        column.Width = 150;
                    }

                    int index = dataGridView.Columns.Add(column);
                    dataGridView.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                isFirst = true;
                return isFirst;
            }
            else
                return isFirst;
        }
        void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0)
                                && dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value != null
                                 && dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value.ToString() != "")
                {
                    if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("LOCK_FLAG")
                        || dataGridView2.Columns[e.ColumnIndex].Name.Equals("STOCK_NO"))
                    {
                        if (e.Value == null || e.Value.ToString() == "")
                        {
                            e.Value = "";
                            e.CellStyle.BackColor = Color.Red;
                            return;
                        }
                        if (e.Value.Equals(0))
                            e.Value = "可用";
                        else if (e.Value.Equals(1))
                        {
                            e.Value = "待判";
                            e.CellStyle.BackColor = Color.Yellow;
                        }
                        else if (e.Value.Equals(2))
                        {
                            e.Value = "封锁";
                            e.CellStyle.BackColor = Color.Red;
                        }
                    }
                }

                if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("STATUS")
                      && dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value != null
                    && dataGridView2.Rows[e.RowIndex].Cells["STATUS"].Value != null)
                {
                    string matNO = dataGridView2.Rows[e.RowIndex].Cells["COIL_NO2"].Value.ToString();

                    if (curOrderMatNO.Contains(matNO))//judgeOrderIsLive(matNO))
                    {
                        e.Value = "吊出中";
                        e.CellStyle.BackColor = Color.Yellow;
                    }
                    else if (e.Value.ToString() == "0")
                    {
                        e.Value = "待吊出";
                        e.CellStyle.BackColor = Color.White;
                    }
                    else if (e.Value.ToString() == "100")
                    {
                        e.Value = "已吊出";
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                    else if (e.Value.ToString() == "101")
                    {
                        e.Value = "人工吊出";
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        #endregion
        #region 指令信息显示

        /// <summary>
        /// 刷新指令表
        /// </summary>
        private void RefreshOrderDgv(string parkNO)
        {
            DataTable dtOrder = new DataTable();
            dtOrder.Clear();
            try
            {
                //string sql = string.Format("select BAY_NO,MAT_NO,FROM_STOCK_NO,TO_STOCK_NO from UACS_CRANE_ORDER_Z32_Z33 WHERE BAY_NO ='{0}' AND ORDER_TYPE = '12' ", parkNO);  //社会车？？框架车23
                string SQLOder = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                SQLOder += " RIGHT JOIN UACS_CRANE_ORDER_CURRENT B ON C.MAT_NO = B.MAT_NO ";
                SQLOder += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                SQLOder += " WHERE PARKING_NO ='{0}') ORDER BY C.GROOVEID ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dtOrder.Load(odrIn);
                }
                dgvOrder.DataSource = dtOrder;

                //DataGridViewBindingSource(dgvOrder, SQLOder);



            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }

        }
        #endregion

        private void CreatCarSize(string strParkNo, ParkLaserOut park)
        {
            DataTable dtLaserData = new DataTable();
            dtLaserData.Clear();
            try
            {
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT  ";
                sqlLaser = string.Format("{0}  WHERE TREATMENT_NO  IN (SELECT TREATMENT_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{1}')", sqlLaser, strParkNo); //strParkNo:Z53A1
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                //生成车位置
                ////获取车位坐标XMin, XMax, YMin, YMax
                int XMin, XMax, YMin, YMax;
                int XVehicleLength, YVehicleLength;
                XMin = XMax = YMin = YMax = XVehicleLength = YVehicleLength = 0;
                //SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID FROM UACS_LASER_OUT 
                if (dtLaserData.Rows.Count != 0)
                {
                    XMin = Convert.ToInt32(dtLaserData.Rows[0]["CAR_X_BORDER_MIN"]);
                    XMax = Convert.ToInt32(dtLaserData.Rows[0]["CAR_X_BORDER_MAX"]);
                    YMin = Convert.ToInt32(dtLaserData.Rows[0]["CAR_Y_BORDER_MIN"]);
                    YMax = Convert.ToInt32(dtLaserData.Rows[0]["CAR_Y_BORDER_MAX"]);
                    XVehicleLength = XMax - XMin;
                    YVehicleLength = YMax - YMin;
                    //画面显示
                    park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 0, "E");
                }
                //生成钢卷位置
                foreach (DataRow item in dtLaserData.Rows)
                {
                    int n1 = JudgeIntNull(item["GROOVE_ACT_X"]);
                    int n2 = JudgeIntNull(item["GROOVE_ACT_Y"]);
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    if (n1 != 0 && n2 != 0)
                    {
                        park.CreateCoilSize(n1, n2, 1200, 1200, strID, false);
                    }
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
            }

        }
        #region 配载图显示
        /// <summary>
        /// 车位绑定激光数据
        /// </summary>
        /// <param name="strParkNo"></param>
        private void LoadLaserInfo(string strParkNo, ParkLaserOut park)
        {
            if (!strParkNo.Contains('F'))
            {
                return;
            }
            DataTable dtLaserData = new DataTable();
            DataTable dtParksize = new DataTable();
            DataTable dtStowageData = new DataTable();
            dtParksize.Clear();
            dtLaserData.Clear();
            dtStowageData.Clear();
            park.ClearbitM();
            try
            {
                string sqlLaser = @"SELECT CAR_X_BORDER_MAX,CAR_X_BORDER_MIN,CAR_Y_BORDER_MAX,CAR_Y_BORDER_MIN,GROOVE_ACT_X,GROOVE_ACT_Y,GROOVE_ACT_Z,GROOVEID,TIME_CREATED FROM UACS_LASER_OUT  ";
                sqlLaser = string.Format("{0}  WHERE TREATMENT_NO  IN (SELECT TREATMENT_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO = '{1}')", sqlLaser, strParkNo); //strParkNo:Z53A1
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlLaser))
                {
                    dtLaserData.Load(rdr);
                }
                //string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}'", strParkNo,cmbArea.Text.Substring(0,1));
                string sqlPark = string.Format("SELECT * FROM UACS_YARDMAP_PARKINGSITE WHERE NAME ='{0}' AND YARD_NO = '{1}'", strParkNo,cbbPacking.Text.Substring(0,3));
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlPark))
                {
                    dtParksize.Load(rdr);
                }
                string sqlStowage = @" SELECT C.MAT_NO,C.X_CENTER,C.Y_CENTER ,C.GROOVEID, B.OUTDIA ,B.WIDTH ,A.STOCK_NO,A.LOCK_FLAG  FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_COIL B ON C.MAT_NO = B.COIL_NO ";
                sqlStowage += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE A ON C.MAT_NO = A.MAT_NO ";
                sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                sqlStowage += " WHERE PARKING_NO ='{0}')  ORDER BY GROOVEID ASC ";
                sqlStowage = string.Format(sqlStowage, cbbPacking.Text.Trim());
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowageData.Load(rdr);
                }
                //初始化停车位信息
                int XStart, XEnd, YStart, YEnd, XLength, YLength;
                XStart = JudgeIntNull(dtParksize.Rows[0]["X_START"]);
                XEnd = JudgeIntNull(dtParksize.Rows[0]["X_END"]);
                YStart = JudgeIntNull(dtParksize.Rows[0]["Y_START"]);
                YEnd = JudgeIntNull(dtParksize.Rows[0]["Y_END"]);
                XLength = JudgeIntNull(dtParksize.Rows[0]["X_LENGTH"]);
                YLength = JudgeIntNull(dtParksize.Rows[0]["Y_LENGTH"]);
                //画面显示
                park.InitializeXY(park.Size.Width - 10, park.Size.Height - 10);

                //生成车位
                //宽增加0.5m、长度增加1.5m
                //park.CreatePassageWayArea(XStart - 500, YEnd + 1800, 5200, 17000);
                park.CreatePassageWayArea(XStart - 500, YEnd , 5200, 17000);
                if (curCarType == 100 || curCarType == 102) //有车边框
                {
                    //park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart);
                    park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart, carHearDrection);
                    //生成车位置
                    ////获取车位坐标XMin, XMax, YMin, YMax
                    int XMin, XMax, YMin, YMax;
                    int XVehicleLength, YVehicleLength;
                    // int XView, YView;
                    XMin = XMax = YMin = YMax = XVehicleLength = YVehicleLength = 0;
                    if (dtLaserData.Rows.Count != 0)
                    {
                        XMin = JudgeIntNull(dtLaserData.Rows[0]["CAR_X_BORDER_MIN"]);
                        XMax = JudgeIntNull(dtLaserData.Rows[0]["CAR_X_BORDER_MAX"]);
                        YMin = JudgeIntNull(dtLaserData.Rows[0]["CAR_Y_BORDER_MIN"]);
                        YMax = JudgeIntNull(dtLaserData.Rows[0]["CAR_Y_BORDER_MAX"]);
                        XVehicleLength = XMax - XMin;
                        YVehicleLength = YMax - YMin;
                        //画面显示
                        //if (txtCarHeadToward.Text == "西")
                        //{
                        //    park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 1, "W"); //框架车类型不一样1，社会车0
                        //}
                        //else
                        park.CreateCarSize(XMin, YMax, XVehicleLength, YVehicleLength, 1, ""); //框架车类型不一样1，社会车0
                        //
                    }
                    else
                    {
                        park.ClearbitM();
                        return;
                    }
                }
                else  //无车边框
                {
                    if (!hasParkSize)
                    {
                        //park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart);
                        park.DrawParksize(XStart, YEnd, XEnd - XStart, YEnd - YStart, carHearDrection); //old
                        if (carHearDrection != "")
                        {
                            hasParkSize = true;
                        }
                    }
                    park.HasCarSize = false;
                }
                //生成钢卷位置
                foreach (DataRow item in dtStowageData.Rows)
                {
                    int n1 = JudgeIntNull(item["X_CENTER"]);
                    int n2 = JudgeIntNull(item["Y_CENTER"]);
                    int n3 = JudgeIntNull(item["OUTDIA"]);  //外径
                    int n4 = JudgeIntNull(item["WIDTH"]);  //宽度
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    string strMat = JudgeStrNull(item["MAT_NO"]);
                    int flag1 = 3;  //封锁标记(0:可用 1:待判 2:封锁)
                    if (item["LOCK_FLAG"] == DBNull.Value)
                    {
                        flag1 = 3;
                    }
                    else
                    {
                        flag1 = Convert.ToInt32(item["LOCK_FLAG"]);
                    }
                    if (n1 != 0 && n2 != 0)
                    {
                        //park.CreateCoilSize(n1, n2, n4, n3, strID, true);
                        //park.CreateCoilSize(n1, n2, n4, n3, strID, true,strMat, toolTip1 );
                        park.CreateCoilSize(n1, n2, n4, n3, strID, false, strMat, toolTip1, flag1);
                        //park.CreateLaserLocation(n1, n2, 4000, 120);
                    }
                }
                //生成激光位置
                foreach (DataRow item in dtLaserData.Rows)
                {
                    int n1 = JudgeIntNull(item["GROOVE_ACT_X"]);
                    int n2 = JudgeIntNull(item["GROOVE_ACT_Y"]);
                    string strID = JudgeStrNull(item["GROOVEID"]);
                    if (n1 != 0 && n2 != 0)
                    {
                        //park.CreateCoilSize(n1, n2, 4000, 120,strID,false);
                        park.CreateLaserLocation(n1, n2, 4000, 120);
                        //有卷测试
                        //park.CreateCoilSize(n1, n2, 1200, 1200, strID, true);
                    }
                }

            }
            catch (Exception er)
            {

                //MessageBox.Show(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                LogManager.WriteProgramLog(string.Format("{0} {1}", er.TargetSite, er.ToString()));
                LogManager.WriteProgramLog("--------------------------------------------------------------------------------------------------------");
            }



        }
        void parkLaserOut1_LabClick(string matNO)
        {
            SelectDataGridViewRow(dataGridView2, matNO, "COIL_NO2");
        }
        private bool reflreshParkingCoilstate(string parkNO)
        {
            DataTable dtStowage = new DataTable();
            bool ret = false;
            string matNO;
            string coilStatus;
            string stowageID = txtStowageID.Text.Trim();
            if (!parkNO.Contains('F') || stowageID.Length < 2)
            {
                return ret;
            }
            try
            {
                string sqlStowage = @" SELECT C.MAT_NO,C.STATUS FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sqlStowage += " WHERE C.STOWAGE_ID = " + stowageID + " ORDER BY GROOVEID ";
                //sqlStowage += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS  ";
                //sqlStowage += " WHERE  CAR_NO IN ( SELECT CAR_NO FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}')) ORDER BY GROOVEID ";
                //sqlStowage = string.Format(sqlStowage, parkNO);
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlStowage))
                {
                    dtStowage.Load(rdr);
                }
                if (dtStowage.Rows.Count > 0)
                {
                    foreach (DataRow item in dtStowage.Rows)
                    {
                        matNO = JudgeStrNull(item["MAT_NO"]);
                        coilStatus = JudgeStrNull(item["STATUS"]);
                        if (curCarType == 100 || curCarType == 102)
                        {
                            parkLaserOut1.ChangeCoilState(matNO, coilStatus, "1");
                        }
                        else
                        {
                            parkLaserOut1.ChangeCoilState(matNO, coilStatus, "0");
                        }

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

        #region 激光数据显示
        private void Inq_Laser(string theTreatmentNO, string theCount)
        {
            try
            {
                if (theTreatmentNO == "" || theCount == "")
                {
                    dt_Laser.Clear();
                    dataGridView_LASER.DataSource = dt_Laser;
                    return;
                }
                //出库激光扫描信息
                string sqlText_Laser = @"SELECT  GROOVEID, GROOVE_ACT_X, GROOVE_ACT_Y, GROOVE_ACT_Z FROM UACS_LASER_OUT WHERE 1=1 ";
                sqlText_Laser += " AND TREATMENT_NO = '" + theTreatmentNO + "' AND LASER_ACTION_COUNT = '" + theCount + "' ";
                sqlText_Laser += " ORDER BY GROOVEID, GROOVE_ACT_Y ";


                //初始化grid
                if (dataGridView_LASER.DataSource != null)
                {
                    dt_Laser.Clear();
                }
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Laser))
                {
                    dt_Laser.Load(rdr);
                }
                dataGridView_LASER.DataSource = dt_Laser;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }
        #endregion
        /// <summary>
        /// 每10秒刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //DateTime myDateTime = DateTime.ParseExact(laserTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);

            if (isStowage == true)
            {
                if (cbbPacking.Text.Contains('F'))
                {
                    getCurCranesOrder();
                    reflreshParkingCoilstate(cbbPacking.Text.Trim());
                    RefreshOrderDgv(cbbPacking.Text.Trim());
                    setCurParkStatus(cbbPacking.Text.Trim());
                    displayStowageTime(labTime, txtStowageID.Text.Trim()); // //显示配载生成后的时间差
                }
            }

            if (dataGridView2.DataSource != null && ((DataTable)dataGridView2.DataSource).Rows.Count > 0)
            {
                isStowage = true;
                return;
            }
            isStowage = false;
            if (!cbbPacking.Text.Contains('F'))
            {
                //GetParkInfo();
                GetParkInfoByBay();
                return;
            }
            RefreshHMI();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GetStowageDetail())
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            }
            if (curCarType == 100)
            {
                goto kuangjiache;
            }
            SelectCoilForm selectCoilF = new SelectCoilForm();
            selectCoilF.TransferValue += selectCoilF_TransferValue;
            selectCoilF.CarType = "社会车";
            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('F'))
            {
                selectCoilF.ParkNO = cbbPacking.Text.Trim();
                if (txtCarNo.Text.Trim().Length > 3)
                    selectCoilF.CarNO = txtCarNo.Text.Trim();
                else
                {
                    MessageBox.Show("车牌号信息不正确！");
                    return;
                }
                selectCoilF.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位信息不正确！");
            }
            return;
        kuangjiache:
            {
                if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('F'))
                {
                    string parkNO = cbbPacking.Text;
                    string GrooveNum = txtSelectGoove.Text;
                    if (auth.IsOpen("框架车出库材料选择"))
                    {
                        auth.CloseForm("框架车出库材料选择");
                        auth.OpenForm("框架车出库材料选择", parkNO, GrooveNum);
                    }
                    else
                        auth.OpenForm("框架车出库材料选择", parkNO, GrooveNum);
                }
                else
                {
                    MessageBox.Show("车位号信息不正确！");
                }
            }


        }

        void selectCoilF_TransferValue(string weight, bool isLoad)
        {
            if (weight != "")
            {
                if (Convert.ToInt32(weight) > 50000)
                    txtCoilsWeight.BackColor = Color.Red;
                else
                    txtCoilsWeight.BackColor = Color.White;
            }
            RefreshHMI();
            txtCoilsWeight.Text = string.Format("{0} /公斤", weight);
            isStowage = isLoad;
        }

        #region 作业开始
        private void btnOperateStrat_Click(object sender, EventArgs e)
        {
            string parkNO = cbbPacking.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('F'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txtCarNo.Text.Equals(""))
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
                        TagDP.SetData("EV_NEW_PARKING_JOB_RESUME", parkNO);
                        ParkClassLibrary.HMILogger.WriteLog(btnOperateStrat.Text, "作业开始：" + cbbPacking.Text, ParkClassLibrary.LogLevel.Info, this.Text);
                        btnOperateStrat.ForeColor = Color.Green;
                        btnOperatePause.ForeColor = Color.White;
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
                        status = JudgeIntNull(rdr["PARKING_STATUS"]);
                        if (status == 270) //暂停
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
            string parkNO = cbbPacking.Text.Trim();
            try
            {
                if (parkNO == "" || !parkNO.Contains('F'))
                {
                    MessageBox.Show("请选择停车位。");
                    return;
                }
                if (txtCarNo.Text.Equals(""))
                {
                    MessageBox.Show("车位无车，不能暂停。");
                    return;
                }

                if (parkNO != "请选择" || parkNO != "")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("是否对" + parkNO + "作业暂停？", "提示", btn, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.OK)
                    {
                        TagDP.SetData("EV_NEW_PARKING_JOB_PAUSE", parkNO);
                        //TagDP.SetData("EV_NEW_PARKING_Z32_CRANE_ALLOW", parkNO);
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
            if (strStatus.Substring(0, 1) == "1" && strStatus.Length == 3) //入库
            {
                if (auth.IsOpen("01 车辆入库"))
                {
                    auth.CloseForm("01 车辆入库");
                }
                auth.OpenForm("01 车辆入库", currPark);
                ret = true;
            }
            //else if (strStatus.Substring(0, 1) == "2" && (carType != 101 && carType != 103)) //框架出库
            //{
            //    if (auth.IsOpen("成品库框架车出库"))
            //    {
            //        auth.CloseForm("成品库框架车出库");
            //    }
            //    auth.OpenForm("成品库框架车出库", currPark);
            //    ret = true;
            //}
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
                    if (carType == 100 || carType == 101 || carType == 102 || carType == 103)
                    {
                        btnSeleceByMat.Enabled = true;
                    }
                    else
                    { btnSeleceByMat.Enabled = false; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return ret;
        }
        #endregion
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetComboxOnParking();
            GetComboxOnParkingByBay();
            if (cmbArea.Text.Contains("后"))
            {
                labTips.Text = "";
            }
            else
            {
                labTips.Text = "  -->\r\n库后区\r\n方向";
            }

        }

        private void getCarBorderSize(string laserCount, string treatmentNO)
        {
            //出库激光车边框信息
            string sqlText_Border = @"SELECT CAR_X_BORDER_MAX, CAR_X_BORDER_MIN, CAR_Y_BORDER_MAX, CAR_Y_BORDER_MIN FROM UACS_LASER_OUT WHERE 1=1 ";

            sqlText_Border += " AND LASER_ACTION_COUNT = '" + laserCount + "' AND TREATMENT_NO = '" + treatmentNO + "' FETCH FIRST 1 ROWS ONLY ";

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText_Border))
            {
                if (rdr.Read())
                {
                    if (rdr["CAR_X_BORDER_MAX"] != System.DBNull.Value)
                    {
                        txt_CAR_X_BORDER_MAX.Text = Convert.ToString(rdr["CAR_X_BORDER_MAX"]);
                    }
                    if (rdr["CAR_X_BORDER_MIN"] != System.DBNull.Value)
                    {
                        txt_CAR_X_BORDER_MIN.Text = Convert.ToString(rdr["CAR_X_BORDER_MIN"]);
                    }
                    if (rdr["CAR_Y_BORDER_MAX"] != System.DBNull.Value)
                    {
                        txt_CAR_Y_BORDER_MAX.Text = Convert.ToString(rdr["CAR_Y_BORDER_MAX"]);
                    }
                    if (rdr["CAR_Y_BORDER_MIN"] != System.DBNull.Value)
                    {
                        txt_CAR_Y_BORDER_MIN.Text = Convert.ToString(rdr["CAR_Y_BORDER_MIN"]);
                    }
                }
                else
                {
                    txt_CAR_X_BORDER_MAX.Text = "";
                    txt_CAR_X_BORDER_MIN.Text = "";
                    txt_CAR_Y_BORDER_MAX.Text = "";
                    txt_CAR_Y_BORDER_MIN.Text = "";
                }
            }
        }
        /// <summary>
        /// 获得当前车信息
        /// </summary>
        private void GetCurrentCarInfo(string parkNO)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                string SQLOder = " SELECT A.LENGTH,A.WIDTH,A.HEIGHT,A.LOAD_CAPACITY,A.SADDLE_NUM,A.SADDLE_INTERVAL,A.DISTANCE_HEAD,A.DISTANCE_LEFT,A.DISTANCE_RIGHT";
                SQLOder += " FROM UACS_TRUCK_FRAME_DEFINE A WHERE FRAME_TYPE_NO IN ( SELECT  CAR_NO FROM UACS_PARKING_STATUS B WHERE B.PARKING_NO ='{0}') ";
                SQLOder = string.Format(SQLOder, parkNO);
                using (IDataReader odrIn = DBHelper.ExecuteReader(SQLOder))
                {
                    dt.Load(odrIn);
                }
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        txtCarL.Text = JudgeStrNull(item["LENGTH"]);
                        txtCarW.Text = JudgeStrNull(item["WIDTH"]);
                        txtCarH.Text = JudgeStrNull(item["HEIGHT"]);
                        txtGrooveDist.Text = JudgeStrNull(item["SADDLE_INTERVAL"]);
                        txtGrooveNum.Text = JudgeStrNull(item["SADDLE_NUM"]);
                        txtHeadDist.Text = JudgeStrNull(item["DISTANCE_HEAD"]);
                        txtsideDist.Text = JudgeStrNull(item["DISTANCE_LEFT"]);
                    }
                }
                else
                {
                    txtCarL.Text = "";
                    txtCarW.Text = "";
                    txtCarH.Text = "";
                    txtGrooveDist.Text = "";
                    txtGrooveNum.Text = "";
                    txtHeadDist.Text = "";
                    txtsideDist.Text = "";
                }

                //添加激光状态显示
                SQLOder = "";
                SQLOder = " SELECT LASER_STATUS FROM UACS_PARKING_STATUS WHERE PARKING_NO = '" + parkNO + "'";
                string laserStatus = "";
                using (IDataReader rdr = DBHelper.ExecuteReader(SQLOder))
                {
                    if (rdr.Read())
                    {
                        laserStatus = ManagerHelper.JudgeStrNull(rdr["LASER_STATUS"]);
                        int index = laserStatus.IndexOf("::");
                        if (index != -1)
                        {
                            laserStatus = laserStatus.Substring(index + 2);
                        }
                        txtLaserStatus.Text = laserStatus;
                    }

                }
                //if (laserStatus.Contains("start"))
                //{
                //    txtLaserStatus.Text = "激光没开始！";
                //}
                //else if (laserStatus.Contains("send data begin"))
                //{
                //    txtLaserStatus.Text = "激光发送数据！";
                //}
                //else if (laserStatus.Contains("scan strat"))
                //{
                //    txtLaserStatus.Text = "扫描开始"; 
                //}
                //else if (laserStatus.Contains("scan end"))
                //{

                //}
                //else if (laserStatus.Contains("receive scan event"))
                //{

                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }

        private void btnSeleceByMat_Click(object sender, EventArgs e)
        {
            if (GetStowageDetail())
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            }
            SelectCoilForm selectCoilF = new SelectCoilForm();
            //selectCoilF.CarType = curCarType.ToString();
            string sqltext = @"select CAR_TYPE from UACS_TRUCK_STOWAGE where STOWAGE_ID = '" + txtStowageID.Text.Trim() + "'";
            using (IDataReader rdr = DBHelper.ExecuteReader(sqltext))
            {
                if (rdr.Read())
                {
                    selectCoilF.CarType = rdr["CAR_TYPE"].ToString();
                }
            }

            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('F'))
            {
                selectCoilF.ParkNO = cbbPacking.Text.Trim();
                selectCoilF.TransferValue += selectCoilF_TransferValue;
                selectCoilF.GrooveNum = txtGrooveNum.Text.Trim();
                selectCoilF.GrooveTotal = txtSelectGoove.Text.Trim();

                if (txtCarNo.Text.Trim().Length > 3)
                    selectCoilF.CarNO = txtCarNo.Text.Trim();
                else
                {
                    MessageBox.Show("车牌号信息不正确！");
                    return;
                }
                selectCoilF.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位号信息不正确！");
            }
        }
        private int checkParkingIsWorking(int stowageID)
        {
            int count = -1;
            try
            {
                string sqlText = " SELECT COUNT (*) COUNT FROM  UACS_TRUCK_STOWAGE_DETAIL WHERE STOWAGE_ID ='" + stowageID + "'   AND STATUS IN(0,30)";

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
                cbbPacking.Text = parkName;
                cbbPacking_SelectedIndexChanged(null, null);
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

        #region 配载时间显示

        private void displayStowageTime(Label labTime, string stowageID)
        {
            if (stowageID == "")
            {
                return;
            }
            //显示配载生成后的时间差

            if (!isReadTime)
            {
                strLaserTime = getStowageCreatTime(stowageID);
                isReadTime = true;
            }
            if (strLaserTime.Length >= 15)
            {
                DateTime dtimeLaserEnd = DateTime.Parse(strLaserTime); //DateTime.ParseExact(strLaserTime, "yyyy/MM/ddHH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                labTime.Text = "配载已生成：" + caculateTimeExpend(dtimeLaserEnd);
            }
            else
                labTime.Text = "---";
        }
        private string getStowageCreatTime(string stowageID)
        {
            string retStr = "";
            try
            {
                string SQLOder = "  SELECT REC_TIME FROM UACS_TRUCK_STOWAGE WHERE STOWAGE_ID ='" + stowageID + "' ";
                using (IDataReader rdr = DBHelper.ExecuteReader(SQLOder))
                {
                    if (rdr.Read())
                    {
                        retStr = JudgeStrNull(rdr["REC_TIME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
            return retStr;
        }


        private string caculateTimeExpend(DateTime timeStart)
        {
            string strTime = "";
            try
            {
                TimeSpan timeExpend = TimeSpan.MinValue;
                timeExpend = DateTime.Now - timeStart;
                strTime = timeExpend.Hours.ToString() + "时" + timeExpend.Minutes.ToString() + "分" + timeExpend.Seconds.ToString() + "秒";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return strTime;
        }
        #endregion

        #region 物流提升，重L3获取配载
        private void btnGetStowage_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button_L3Stowage_Click(object sender, EventArgs e)
        {
            if (GetStowageDetail())
            {
                MessageBox.Show("车辆已经配载材料，请先做车离。");
                return;
            }
            SelectCoilByL3Form selectCoilF = new SelectCoilByL3Form();
            selectCoilF.CarType = curCarType == 100 ? "框架车" : "社会车";
            if (cbbPacking.Text.Trim() != "请选择" && cbbPacking.Text.Trim() != "" && cbbPacking.Text.Trim().Contains('F'))
            {
                selectCoilF.ParkNO = cbbPacking.Text.Trim();
                selectCoilF.TransferValue += selectCoilF_TransferValue;

                if (txtCarNo.Text.Trim().Length > 3)
                    selectCoilF.CarNO = txtCarNo.Text.Trim();
                else
                {
                    MessageBox.Show("车牌号信息不正确！");
                    return;
                }
                selectCoilF.ShowDialog();
            }
            else
            {
                MessageBox.Show("车位号信息不正确！");
            }
        }

        private void cbbPacking_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            JumpToOtherForm(cbbPacking.Text);
        }

        private void cbbPacking_TextChanged(object sender, EventArgs e)
        {

            if (cbbPacking.Text.Contains("FIA"))
            {
                cmbArea.SelectedItem = "A跨";
            }
            else if (cbbPacking.Text.Contains("FIB"))
            {
                cmbArea.SelectedItem = "B跨";
            }
            else
            {

            }
        }

        //行车指令判断
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

        private bool getCurCranesOrder()
        {
            bool ret = false;
            List<string> lstTemp = new List<string>();
            try
            {
                string sqlText = @" SELECT MAT_NO FROM UACS_CRANE_ORDER_CURRENT WHERE CRANE_NO  IN('1','2','3','4') ";
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

        private void parkLaserOut1_labDoubleClick(string matNO)
        {
            string status = GetCoilStatus(txtStowageID.Text.Trim(), matNO);
            if (status == "101")
            {
                DialogResult dr = MessageBox.Show("是否将卷： " + matNO + "设为自动吊运？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    setCoilByMan(txtStowageID.Text.Trim(), matNO, "100");
                    ParkClassLibrary.HMILogger.WriteLog("设置自动吊运", "设为自动吊运：" + matNO, ParkClassLibrary.LogLevel.Warn, this.Text, ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName());
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("是否将卷： " + matNO + "设为人工吊运？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    setCoilByMan(txtStowageID.Text.Trim(), matNO, "101");
                    ParkClassLibrary.HMILogger.WriteLog("设置人工吊运", "设为人工吊运：" + matNO, ParkClassLibrary.LogLevel.Warn, this.Text, ((IAuthorization)FrameContext.Instance.GetPlugin<IAuthorization>()).GetUserName());
                }
            }

        }

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
    }

}
