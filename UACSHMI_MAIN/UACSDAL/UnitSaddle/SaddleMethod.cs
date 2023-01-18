﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
//using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.TagService.Interface;

namespace UACS
{
    public class SaddleMethod
    {

        #region 连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;

        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("zjcangchu");
                    }
                    catch (System.Exception e)
                    {

                    }
                }
                return dbHelper;
            }
        }
        #endregion

        //tag provide 对象的定义
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();


        private string unitNO = "";
        //机组号1
        public string UnitNO
        {
            get { return unitNO; }
            set { unitNO = value; }
        }
        //出入口鞍座区分
        private int flagUnitExit = 1;

        public int FlagUnitExit
        {
            get { return flagUnitExit; }
            set { flagUnitExit = value; }
        }


        /// <summary>
        /// 键字为 L2SaddleName  1，2，3，4，5，6.......
        /// </summary>
        private Dictionary<string, Saddle> dicSaddles = new Dictionary<string, Saddle>();

        public Dictionary<string, Saddle> DicSaddles
        {
            get { return dicSaddles; }
            set { dicSaddles = value; }
        }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SaddleMethod()
        {

        }
        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="unit_no">机组号</param>
        /// <param name="flag_unit_exit">出入口区分</param>
        /// <param name="tagServiceName">tagService名称</param>
        public SaddleMethod(string unit_no, int flag_unit_exit, string tagServiceName)
        {
            try
            {
                unitNO = unit_no;
                flagUnitExit = flag_unit_exit;
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// 获取鞍座的所有信息给类赋值
        /// </summary>
        public void ReadDefintion()
        {
            try
            {
                dicSaddles.Clear();
                string sql = null;
                if (unitNO != "" && flagUnitExit == 1 )   // 出口
                {
                    if (unitNO == "MC1")
                    {
                        sql = @" SELECT b.*,c.COIL_NO,a.MAT_NO FROM
                               UACS_YARDMAP_STOCK_DEFINE a LEFT JOIN UACS_LINE_SADDLE_DEFINE b
                               ON a.STOCK_NO = b.STOCK_NO LEFT JOIN UACS_LINE_EXIT_L2INFO c 
                               ON b.UNIT_NO= c.UNIT_NO AND b.SADDLE_L2NAME=c.SADDLE_L2NAME
                         WHERE a.STOCK_NO like '%" + unitNO + "%' ";
                    }
                    else if (unitNO == "MC2")
                    {
                        sql = @"SELECT b.*, a.MAT_NO COIL_NO FROM
                               UACS_YARDMAP_STOCK_DEFINE a LEFT JOIN UACS_LINE_SADDLE_DEFINE b
                               ON a.STOCK_NO = b.STOCK_NO LEFT JOIN UACS_LINE_EXIT_L2INFO c 
                               ON b.UNIT_NO= c.UNIT_NO AND b.SADDLE_L2NAME=c.SADDLE_L2NAME
                         WHERE a.STOCK_NO like '%" + unitNO + "%' ";
                    }
                    else
                    {
                        sql = @"SELECT A.*,B.COIL_NO FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN
                                UACS_LINE_EXIT_L2INFO B ON A.UNIT_NO = B.UNIT_NO AND A.SADDLE_L2NAME = B.SADDLE_L2NAME ";
                        sql += "WHERE A.UNIT_NO = '" + unitNO + "' AND A.FLAG_UNIT_EXIT = '" + flagUnitExit + "' ORDER BY SADDLE_L2NAME ";
                    }
                    
                }
                else if (unitNO != "" && flagUnitExit == 0 )   // 入口
                {
                    
                   
                        sql = @"SELECT A.*,B.COIL_NO FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN
                                UACS_LINE_ENTRY_L2INFO B ON A.UNIT_NO = B.UNIT_NO AND A.SADDLE_L2NAME = B.SADDLE_L2NAME ";
                        sql += "WHERE A.UNIT_NO = '" + unitNO + "' AND A.FLAG_UNIT_EXIT = '" + flagUnitExit + "' ORDER BY SADDLE_L2NAME ";
                    
                   
                }
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        Saddle theSaddle = new Saddle();
                        if (rdr["STOCK_NO"] != System.DBNull.Value)
                        {
                            theSaddle.SaddleNo = Convert.ToString(rdr["STOCK_NO"]);
                        }
                        else
                        {
                            theSaddle.SaddleNo = string.Empty;
                        }
                        if (rdr["UNIT_NO"] != System.DBNull.Value)
                        {
                            theSaddle.UnitNo = Convert.ToString(rdr["UNIT_NO"]);
                        }
                        else
                        {
                            theSaddle.UnitNo = string.Empty;
                        }
                        if (rdr["FLAG_UNIT_EXIT"] != System.DBNull.Value)
                        {
                            theSaddle.FlagUnitExit = long.Parse(rdr["FLAG_UNIT_EXIT"].ToString());
                        }
                        else
                        {
                            theSaddle.FlagUnitExit = 0;
                        }
                        if (rdr["SADDLE_L2NAME"] != System.DBNull.Value)
                        {
                            theSaddle.SaddleL2Name = Convert.ToString(rdr["SADDLE_L2NAME"]);
                        }
                        else
                        {
                            theSaddle.SaddleL2Name = string.Empty;
                        }
                        if (rdr["FLAG_CHECKDATA"] != System.DBNull.Value)
                        {
                            theSaddle.FlagChcekData = long.Parse(rdr["FLAG_CHECKDATA"].ToString());
                        }
                        else
                        {
                            theSaddle.FlagChcekData = 0;
                        }
                        if (rdr["FLAG_CREATEORDER"] != System.DBNull.Value)
                        {
                            theSaddle.FlagCreateOrder = long.Parse(rdr["FLAG_CREATEORDER"].ToString());
                        }
                        else
                        {
                            theSaddle.FlagCreateOrder = 0;
                        }
                        if (rdr["FLAG_CANAUTOUP"] != System.DBNull.Value)
                        {
                            theSaddle.FlagCanAutoUp = long.Parse(rdr["FLAG_CANAUTOUP"].ToString());
                        }
                        else
                        {
                            theSaddle.FlagCanAutoUp = 0;
                        }
                        if (rdr["FLAG_CANAUTODOWN"] != System.DBNull.Value)
                        {
                            theSaddle.FlagCanAutoDown = long.Parse(rdr["FLAG_CANAUTODOWN"].ToString());
                        }
                        else
                        {
                            theSaddle.FlagCanAutoDown = 0;
                        }
                        if (rdr["TAG_LOCK_REQUEST"] != System.DBNull.Value)
                        {
                            theSaddle.TagAdd_LockRequest = Convert.ToString(rdr["TAG_LOCK_REQUEST"]);
                        }
                        else
                        {
                            theSaddle.TagAdd_LockRequest = string.Empty;
                        }
                        if (rdr["TAG_ISLOCKED"] != System.DBNull.Value)
                        {
                            theSaddle.TagAdd_IsLocked = Convert.ToString(rdr["TAG_ISLOCKED"]);
                        }
                        else
                        {
                            theSaddle.TagAdd_IsLocked = string.Empty;
                        }
                        if (rdr["TAG_ISEMPTY"] != System.DBNull.Value)
                        {
                            theSaddle.TagAdd_IsOccupied = Convert.ToString(rdr["TAG_ISEMPTY"]);
                        }
                        else
                        {
                            theSaddle.TagAdd_IsOccupied = string.Empty;
                        }



                        //if (rdr["COIL_NO"] != System.DBNull.Value)
                        //{
                        //    theSaddle.CoilNO = Convert.ToString(rdr["COIL_NO"]);
                        //}
                        //else
                        //{
                        //    theSaddle.CoilNO = string.Empty;
                        //}

                        if (rdr["MAT_NO"] != System.DBNull.Value)
                        {
                            theSaddle.CoilNO = Convert.ToString(rdr["MAT_NO"]);
                        }
                        else
                        {
                            theSaddle.CoilNO = string.Empty;
                        }

                        dicSaddles[theSaddle.SaddleNo] = theSaddle;
                    }
                }
            }
            catch (Exception er)
            {

                //System.Windows.Forms.MessageBox.Show(er.Message);
            }
        }

        private string[] arrTagAdress;
        /// <summary>
        /// 存储所有tag点的地址
        /// </summary>
        public void getTagNameList()
        {
            try
            {
                List<string> TagNamelist = new List<string>();
                foreach (Saddle theSaddle in dicSaddles.Values)
                {
                    TagNamelist.Add(theSaddle.TagAdd_LockRequest);
                    TagNamelist.Add(theSaddle.TagAdd_IsLocked);
                    TagNamelist.Add(theSaddle.TagAdd_IsOccupied);
                }

                arrTagAdress = TagNamelist.ToArray<string>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// tag点值的map
        /// </summary>
        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        /// <summary>
        /// 遍历tag点获取值
        /// </summary>
        public void getTagValues()
        {
            try
            {
                //清空原来的map
                inDatas.Clear();
                //读所有鞍座tag点的值
                tagDataProvider.GetData(arrTagAdress, out inDatas);

                //为每个鞍座的tag点值属性赋值
                foreach (Saddle theSaddle in dicSaddles.Values)
                {
                    theSaddle.TagVal_IsLocked = get_value_x(theSaddle.TagAdd_IsLocked);
                    theSaddle.TagVal_IsOccupied = get_value_x(theSaddle.TagAdd_IsOccupied);
                    theSaddle.TagVal_LockRequest = get_value_x(theSaddle.TagAdd_LockRequest);
                }

                //arrTagAdress = null;
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 根据tag返回一个值
        /// </summary>
        /// <param name="tagName">tag名称</param>
        /// <returns></returns>
        private long get_value_x(string tagName)
        {
            long theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToInt32(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue;
        }


        /// <summary>
        /// 查询机组鞍座出口鞍座信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="unit_no">第一个机组</param>
        /// <param name="saddle_no">第二个机组</param>
        /// <returns></returns>
        public DataTable getExitSaddleDt(DataTable dt, string unit_no1, string unit_no2 = null)
        {
            // 标记
            bool hasSetColumn = false;
            try
            {
                string sqlText = @"SELECT A.SADDLE_L2NAME,A.STOCK_NO,B.COIL_NO,C.WEIGHT,C.WIDTH,C.INDIA,C.OUTDIA,
                                    CASE
                                        WHEN  C.PACK_FLAG = 1 THEN '已包装'
                                        ELSE '未包装'
                                    END as  PACK_FLAG , ";
                sqlText += "C.FORBIDEN_FLAG,C.DUMMY_COIL_FLAG,C.NEXT_UNIT_NO,C.PACK_CODE,B.WORK_ORDER_NO,B.PRODUCT_DATE ,B.TIME_LAST_CHANGE ";
                sqlText += "FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN UACS_LINE_EXIT_L2INFO B ";
                sqlText += "ON A.UNIT_NO = B.UNIT_NO AND A.SADDLE_L2NAME = B.SADDLE_L2NAME ";
                sqlText += "  LEFT JOIN UACS_YARDMAP_COIL C ON C.COIL_NO = B.COIL_NO ";
                if (unit_no1 != null && unit_no2 == null)                  //只传一个机组号
                {
                    sqlText += " WHERE A.UNIT_NO = '" + unit_no1 + "' AND A.FLAG_UNIT_EXIT = 1  ORDER BY A.STOCK_NO ";
                }
                else if (unit_no1 != null && unit_no2 != null)              //两个机组号
                {
                    sqlText += " WHERE A.UNIT_NO IN ('" + unit_no1 + "','" + unit_no2 + "') AND A.FLAG_UNIT_EXIT = 1  ORDER BY A.STOCK_NO ";
                }
                dt.Clear();
                dt = new DataTable();
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }

                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                //System.Windows.Forms.MessageBox.Show(er.Message);
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("SADDLE_L2NAME", typeof(String));
                dt.Columns.Add("STOCK_NO", typeof(String));
                dt.Columns.Add("COIL_NO", typeof(String));
                dt.Columns.Add("WEIGHT", typeof(String));
                dt.Columns.Add("WIDTH", typeof(String));
                dt.Columns.Add("IN_DIA", typeof(String));
                dt.Columns.Add("OUT_DIA", typeof(String));
                dt.Columns.Add("COIL_OPEN_DIRECTION", typeof(String));
                dt.Columns.Add("SLEEVE_WIDTH", typeof(String));
                dt.Columns.Add("NEXT_UNIT_NO", typeof(String));
                dt.Columns.Add("PACK_CODE", typeof(String));
                dt.Columns.Add("WORK_ORDER_NO", typeof(String));
                dt.Columns.Add("PRODUCT_DATE", typeof(String));
                dt.Columns.Add("TIME_LAST_CHANGE", typeof(String));
                dt.Columns.Add("PACK_FLAG", typeof(String));
            }
            return dt;
        }

        /// <summary>
        /// 查询指定的机组入口鞍座信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="unit_no">机组号</param>
        /// <returns></returns>
        public DataTable getEntrySaddleDt(DataTable dt, string unit_no)
        {
            bool hasSetColumn = false;
            try
            {
                string sqlText = @"SELECT A.STOCK_NO,A.SADDLE_L2NAME, B.COIL_NO, C.WEIGHT, C.WIDTH, C.INDIA,C.OUTDIA,
                                (CASE C.COIL_OPEN_DIRECTION 
                                WHEN 0 THEN '上卷取' 
                                WHEN 1 THEN '下卷取' 
                                else '其他' 
                                end ) COIL_OPEN_DIRECTION
                                , 
                                (CASE C.COIL_STATUS 
                                WHEN 100 THEN '库内' 
                                WHEN 200 THEN '起吊' 
                                WHEN 300 THEN '机组鞍座'
                                WHEN 400 THEN '上开卷机'
                                WHEN 500 THEN '开卷完成' 
                                WHEN 410 THEN '上车辆'
                                WHEN 510 THEN '装车出库' 
                                else '其他' 
                                end ) COIL_STATUS  ";
                sqlText += " FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN UACS_LINE_ENTRY_L2INFO B ON A.UNIT_NO= B.UNIT_NO AND A.SADDLE_L2NAME=B.SADDLE_L2NAME LEFT JOIN UACS_YARDMAP_COIL C  ON C.COIL_NO = B.COIL_NO";
                sqlText += " WHERE A.UNIT_NO= '" + unit_no + "' AND A.FLAG_UNIT_EXIT = 0 ORDER BY A.SADDLE_L2NAME ";
                
                //清除datatable
                dt.Clear();
                dt = new DataTable();
               
                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
              
            }
            finally
            {
                if (hasSetColumn == false)
                {
                    dt.Columns.Add("STOCK_NO", typeof(String));
                    dt.Columns.Add("SADDLE_L2NAME", typeof(String));
                    dt.Columns.Add("COIL_NO", typeof(String));
                    dt.Columns.Add("WEIGHT", typeof(String));
                    dt.Columns.Add("WIDTH", typeof(String));
                    dt.Columns.Add("INDIA", typeof(String));
                    dt.Columns.Add("OUTDIA", typeof(String));
                    dt.Columns.Add("COIL_OPEN_DIRECTION", typeof(String));
                    dt.Columns.Add("COIL_STATUS", typeof(String));
                }
            }       
            return dt;
        }

        /// <summary>
        /// 计划顺序
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getL2DPI(DataTable dt, string unit_no = null)
        {
           // bool hasSetColumn = false;
            try
            {
                string sqlText = null;
                if (unit_no != null)
                {
                    sqlText = @"SELECT PLAN_SEQ , COIL_NO , WEIGHT ,WIDTH ,IN_DIA ,OUT_DIA , PACK_FLAG , 
                               (CASE STATUS
                                WHEN 100 THEN '库内' 
                                WHEN 200 THEN '起吊' 
                                WHEN 300 THEN '机组鞍座'
                                WHEN 400 THEN '上开卷机'
                                WHEN 500 THEN '开卷完成' 
                                WHEN 410 THEN '上车辆'
                                WHEN 510 THEN '装车出库' 
                                else '其他' 
                                end ) STATUS   
                                ,SLEEVE_WIDTH ,
                                (CASE COIL_OPEN_DIRECTION 
                                WHEN 0 THEN '上卷取' 
                                WHEN 1 THEN '下卷取' 
                                else '其他' 
                                end ) COIL_OPEN_DIRECTION,
                                TIME_LAST_CHANGE FROM UACS_LINE_L2PLAN ";
                    sqlText += "WHERE UNIT_NO = '" + unit_no + "' order by PLAN_SEQ";
                }          
                dt.Clear();
                dt = new DataTable();
                dt.Columns.Add("PLAN_SEQ", typeof(String));
                dt.Columns.Add("COIL_NO", typeof(String));
                dt.Columns.Add("WEIGHT", typeof(String));
                dt.Columns.Add("WIDTH", typeof(String));
                dt.Columns.Add("IN_DIA", typeof(String));
                dt.Columns.Add("OUT_DIA", typeof(String));
                dt.Columns.Add("PACK_FLAG", typeof(String));
                dt.Columns.Add("STATUS", typeof(String));
                dt.Columns.Add("SLEEVE_WIDTH", typeof(String));
                dt.Columns.Add("COIL_OPEN_DIRECTION", typeof(String));               
                dt.Columns.Add("TIME_LAST_CHANGE", typeof(String));
                dt.Columns.Add("STOCK_NO", typeof(String));
                dt.Columns.Add("X_CENTER", typeof(String));

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        if (rdr["PLAN_SEQ"] !=  DBNull.Value)                  
                            dr["PLAN_SEQ"] = rdr["PLAN_SEQ"].ToString();
                        else
                            dr["PLAN_SEQ"] = "";

                        if (rdr["COIL_NO"] != DBNull.Value)
                            dr["COIL_NO"] = rdr["COIL_NO"].ToString();
                        else
                            dr["COIL_NO"] = "";

                        if (rdr["WEIGHT"] != DBNull.Value)
                            dr["WEIGHT"] = rdr["WEIGHT"].ToString();
                        else
                            dr["WEIGHT"] = "";

                        if (rdr["WIDTH"] != DBNull.Value)
                            dr["WIDTH"] = rdr["WIDTH"].ToString();
                        else
                            dr["WIDTH"] = "";

                        if (rdr["IN_DIA"] != DBNull.Value)
                            dr["IN_DIA"] = rdr["IN_DIA"].ToString();
                        else
                            dr["IN_DIA"] = "";

                        if (rdr["OUT_DIA"] != DBNull.Value)
                            dr["OUT_DIA"] = rdr["OUT_DIA"].ToString();
                        else
                            dr["OUT_DIA"] = "";

                        if (rdr["PACK_FLAG"] != DBNull.Value)
                            dr["PACK_FLAG"] = rdr["PACK_FLAG"].ToString();
                        else
                            dr["PACK_FLAG"] = "";

                        if (rdr["STATUS"] != DBNull.Value)
                            dr["STATUS"] = rdr["STATUS"].ToString();
                        else
                            dr["STATUS"] = "";

                        if (rdr["SLEEVE_WIDTH"] != DBNull.Value)
                            dr["SLEEVE_WIDTH"] = rdr["SLEEVE_WIDTH"].ToString();
                        else
                            dr["SLEEVE_WIDTH"] = "";

                        if (rdr["COIL_OPEN_DIRECTION"] != DBNull.Value)
                            dr["COIL_OPEN_DIRECTION"] = rdr["COIL_OPEN_DIRECTION"].ToString();
                        else
                            dr["COIL_OPEN_DIRECTION"] = "";

                        if (rdr["TIME_LAST_CHANGE"] != DBNull.Value)
                            dr["TIME_LAST_CHANGE"] = rdr["TIME_LAST_CHANGE"].ToString();
                        else
                            dr["TIME_LAST_CHANGE"] = "";

                        if (rdr["COIL_NO"] != DBNull.Value)
                            dr["STOCK_NO"] =GetDbByStockNo( rdr["COIL_NO"].ToString());
                        else
                            dr["STOCK_NO"] = "";

                        if (rdr["COIL_NO"] != DBNull.Value)
                            dr["X_CENTER"] = GetDbByCenter(rdr["COIL_NO"].ToString());
                        else
                            dr["X_CENTER"] = "";

                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {

            }
            return dt;
        }


        /// <summary>
        /// 更新机组鞍座模式
        /// </summary>
        public void UpSaddleDown(string name)
        {
            if (name == "Bay")  // 本跨卷
            {
                try
                {
                    string sql = @" update UACS_LINE_SADDLE_DEFINE set FLAG_ALL_PASSENGERS_CAN_DOWN = 0 where unit_no = 'D202' ";
                    DBHelper.ExecuteNonQuery(sql);
                    System.Windows.Forms.MessageBox.Show("只收本跨卷切换成功");
                }
                catch (Exception er)
                {

                    //System.Windows.Forms.MessageBox.Show(er.Message);
                }
            }
            else if (name == "AllBay") //全部卷
            {
                try
                {
                    string sql = @" update UACS_LINE_SADDLE_DEFINE set FLAG_ALL_PASSENGERS_CAN_DOWN = 1 where unit_no = 'D202' ";
                    DBHelper.ExecuteNonQuery(sql);
                    System.Windows.Forms.MessageBox.Show("收全部卷切换成功");
                }
                catch (Exception er)
                {

                    //System.Windows.Forms.MessageBox.Show(er.Message);
                }
                
            }
        }

        /// <summary>
        /// 查询当前状态
        /// </summary>
        /// <returns></returns>
        public int GetSaddleDown()
        {
            int num = 0;
            try
            {
                string sql = @" select FLAG_ALL_PASSENGERS_CAN_DOWN from UACS_LINE_SADDLE_DEFINE where UNIT_NO = 'D202' ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["FLAG_ALL_PASSENGERS_CAN_DOWN"] != DBNull.Value)
                        {
                            num = Convert.ToInt32(rdr["FLAG_ALL_PASSENGERS_CAN_DOWN"]);
                        }
                        else
                            num = 0;
                       
                    }
                }
               
            }
            catch (Exception er)
            {
               
            }
            return num;
        }

        /// <summary>
        /// 计划顺序钢卷查询库位状态
        /// </summary>
        /// <param name="coilno"></param>
        /// <returns></returns>
        public int GetStockOrCoil(string coilno)
        {
            int num = 999;
            try
            {
                string sql = @"SELECT LOCK_FLAG FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO = '" + coilno + "' ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["LOCK_FLAG"] != DBNull.Value)
                        {
                            num = Convert.ToInt32(rdr["LOCK_FLAG"]);
                        }
                        else
                            num = 999;
                       
                    }
                }
            }
            catch (Exception er)
            {
                
            }
            return num;
        }

        /// <summary>
        /// 计划顺序钢卷查询钢卷信息确认
        /// </summary>
        /// <param name="coilno"></param>
        /// <returns></returns>
        public int GetCoilConfirm_Flag(string coilno)
        {
            int num = 999;
            try
            {
                string sql = string.Format("SELECT CONFIRM_FLAG FROM UACS_YARDMAP_COIL WHERE COIL_NO = '{0}", coilno);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        num = Convert.ToInt32(rdr["CONFIRM_FLAG"]);
                    }
                }
            }
            catch (Exception er)
            {
                
            }
            return num;
        }



        /// <summary>
        /// 根据机组号查询钢卷,库位
        /// </summary>
        /// <param name="saddleno"></param>
        /// <param name="lbl"></param>
        public void GetCoilLabel(string saddleno, System.Windows.Forms.Label lblCoilNO, System.Windows.Forms.Label lblStockNO )
        {
            try
            {
                string NEXT_COILNO = null;
                string stockNo = null;
                string sql = @"SELECT NEXT_COILNO FROM UACS_LINE_NEXTCOIL WHERE UNIT_NO = '" + saddleno + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["NEXT_COILNO"] != DBNull.Value)
                        {
                            NEXT_COILNO = rdr["NEXT_COILNO"].ToString();
                        }
                        else
                            NEXT_COILNO = null;

                    }
                }

                if (NEXT_COILNO != null)
                {
                    lblCoilNO.Text = NEXT_COILNO;
                    string sqlStock = @"SELECT STOCK_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO = '" + NEXT_COILNO + "'";
                    using (IDataReader rdrStock = DBHelper.ExecuteReader(sqlStock))
                    {
                        while (rdrStock.Read())
                        {
                            if (rdrStock["STOCK_NO"] != DBNull.Value)
                            {
                                stockNo = rdrStock["STOCK_NO"].ToString();
                            }
                            else
                                stockNo = null;

                        }
                    }
                    if (stockNo != null)
                    {
                        lblStockNO.Text = stockNo;
                    }
                    else
                        lblStockNO.Text = "无库位";
                }
                else
                {
                    lblCoilNO.Text = "没有钢卷";
                    lblStockNO.Text = "无库位";
                }





            }
            catch (Exception er)
            {

                //throw;
            }
            finally
            {
                GC.Collect();
            }
        }

        private string GetDbByStockNo(string coil)
        {
            string stockNo = string.Empty;
            try
            {
                string sql = @"select B.STOCK_NO as STOCK_NO from UACS_LINE_L2PLAN  A  inner join  UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO
                               inner join UACS_YARDMAP_SADDLE_STOCK C on C.STOCK_NO = B.STOCK_NO 
                               inner join UACS_YARDMAP_SADDLE_DEFINE D on D.SADDLE_NO = C.SADDLE_NO 
                               WHERE A.COIL_NO = '" + coil + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOCK_NO"] != DBNull.Value)
                        {
                            stockNo = rdr["STOCK_NO"].ToString();
                        }
                        else
                            stockNo = "";
                       
                    }
                }
            }
            catch (Exception er)
            {
                
                //throw;
            }
            return stockNo;
        }

        private string GetDbByCenter(string coil)
        {
            string center = string.Empty;
            try
            {
                string sql = @"select D.X_CENTER as X_CENTER from UACS_LINE_L2PLAN  A  inner join  UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO
                               inner join UACS_YARDMAP_SADDLE_STOCK C on C.STOCK_NO = B.STOCK_NO 
                               inner join UACS_YARDMAP_SADDLE_DEFINE D on D.SADDLE_NO = C.SADDLE_NO 
                               WHERE A.COIL_NO = '" + coil + "'";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["X_CENTER"] != DBNull.Value)
                        {
                            center = rdr["X_CENTER"].ToString();
                        }
                        else
                            center = "";
                        
                    }
                }
            }
            catch (Exception er)
            {

                //throw;
            }
            return center;
        }
      
        /// <summary>
        /// 根据所需的鞍座显示出详细信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dgv"></param>
        public void GetSaddleMessageInDgv(string unitNo,string bayNo , System.Windows.Forms.DataGridView dgv,bool flag = false)
        {
            // 标记
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                
                string sql = @"SELECT a.STOCK_NO,c.COIL_NO FROM
                               UACS_YARDMAP_STOCK_DEFINE a LEFT JOIN UACS_LINE_SADDLE_DEFINE b
                               ON a.STOCK_NO = b.STOCK_NO LEFT JOIN UACS_LINE_ENTRY_L2INFO c 
                               ON b.UNIT_NO= c.UNIT_NO AND b.SADDLE_L2NAME=c.SADDLE_L2NAME";
                if (unitNo != "MC1" && unitNo != "MC2")
                {
                    sql += " WHERE a.STOCK_NO like '" + unitNo + "%' and a.BAY_NO = '" + bayNo + "'";
                }
                else
                {
                    sql += " WHERE a.STOCK_NO like '%" + unitNo + "%' and a.BAY_NO = '" + bayNo + "'";
                }
                //Z33插料信息只需要显示第二鞍座
                if (bayNo == "Z33-1" && flag == true)
                {
                    sql += " and b.SADDLE_L2NAME != '0001'";

                }
                if (unitNo == "D308")
                {
                    sql += " and (c.SADDLE_L2NAME = '0001' or c.SADDLE_L2NAME = '0002')";
                }

                if (unitNo == "D212")
                {
                    sql += " and (c.SADDLE_L2NAME = '0101' or c.SADDLE_L2NAME = '0201' or c.SADDLE_L2NAME = '0102' or c.SADDLE_L2NAME = '0202')";
                }
               
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            if (!hasSetColumn)
                            {
                                DataColumn dc = new DataColumn();
                                dc.ColumnName = rdr.GetName(i);
                                dt.Columns.Add(dc);
                            }
                            dr[i] = rdr[i];
                        }
                        hasSetColumn = true;
                        dt.Rows.Add(dr);
                    }
                }
               
            }
            catch (Exception er)
            {
                
                //throw;
            }
            if (hasSetColumn == false)
            {
                dt.Columns.Add("STOCK_NO", typeof(String));
                dt.Columns.Add("COIL_NO", typeof(String));
            }

            dgv.DataSource = dt;
        }


        /// <summary>
        /// 查询当前机组上料状态
        /// </summary>
        /// <param name="unitNo"></param>
        /// <returns></returns>
        public int GetUnitAutoStatus(string unitNo)
        {
            int Auto_flag = 0;
            try
            {           
                string sql = @"SELECT FLAG_JOIN FROM UACS_LINE_ENTRY_LOAD_ACTOR ";
                sql += "WHERE ACTOR_ID = '" + unitNo + "' ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["FLAG_JOIN"] != DBNull.Value)
                        {
                            Auto_flag = Convert.ToInt32(rdr["FLAG_JOIN"]);
                        }
                        else
                            Auto_flag = 999;

                    }
                }
            }
            catch (Exception er)
            {
                
               // throw;
            }

            return Auto_flag;

            
        }




        // <summary>
        /// 待吊运
        /// </summary>
        /// <returns></returns>
        private string GetActor(string Coordinator_id, string Actor_id)
        {
            string actor = null;
            try
            {
                string sql = @"SELECT NEXT_ACTOR FROM UACS_LINE_ENTRY_LOAD_ACTOR ";
                sql += " WHERE COORDINATOR_ID = '" + Coordinator_id + "' AND ACTOR_ID = '" + Actor_id + "'  ";
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["NEXT_ACTOR"] != DBNull.Value)
                        {
                            actor = rdr["NEXT_ACTOR"].ToString();
                        }
                        else
                            actor = null;
                        
                    }
                }
            }
            catch (Exception er)
            {
                //MessageBox.Show(er.Message);
            }
            return actor;
        }

        /// <summary>
        /// 检查卷是否是封闭卷
        /// </summary>
        /// <param name="coilNo"></param>
        /// <returns></returns>
        public bool isCoilSealingFlag(string coilNo)
        {
            bool flag = false;
            int forbiden = 0;
            try
            {
                string sql = string.Format("SELECT FORBIDEN_FLAG FROM UACS_YARDMAP_COIL WHERE COIL_NO = '{0}'",coilNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        forbiden = Convert.ToInt32(rdr["FORBIDEN_FLAG"]);
                    }
                }

                if (forbiden == 1)
                {
                    flag  =  true;
                }
            }
            catch (Exception er)
            {

                return false;
            }
            return flag;
        }

        /// <summary>
        /// 检查卷是否是验证卷
        /// </summary>
        /// <param name="coilNo"></param>
        /// <returns></returns>
        public bool isCoilVerifyFlag(string coilNo)
        {
            bool flag = false;
            int Verify = 0;
            try
            {
                string sql = string.Format("select PLASTIC_FLAG from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '{0}'", coilNo);
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        Verify = Convert.ToInt32(rdr["PLASTIC_FLAG"]);
                    }
                }

                if (Verify == 2)
                {
                    flag = true;
                }
            }
            catch (Exception er)
            {

                return false;
            }
            return flag;
        }

    }
}
