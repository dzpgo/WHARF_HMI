﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace UACSDAL
{

    public class ParkingInfo
    {
        
        private string bayNo = string.Empty;
        /// <summary>
        /// 跨别
        /// </summary>
        public string BayNo
        {
            get { return bayNo; }
        }


        public void conInit(string theBayNo)
        {
            try
            {
                bayNo = theBayNo; 

            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 存储每个鞍座对应的数据（字典）
        /// </summary>
        private Dictionary<string, ParkingBase> dicCarMessage = new Dictionary<string, ParkingBase>();
        public Dictionary<string, ParkingBase> DicCarMessage
        {
            get { return dicCarMessage; }
            set { dicCarMessage = value; }
        }

        public void GetParkingMessage()
        {
            string Park = (bayNo == "FIA"? "FIA%" : "FIB%");
            try
            {
                //string sql = string.Format("select A.*,B.* from UACS_PARKING_STATUS A left join UACS_YARDMAP_PARKINGSITE B on A.PARKING_NO = B.ID where A.PARKING_NO like '{0}%' and B.YARD_NO != '' and B.PARKING_TYPE = '0'", bayNo);
                string sql = string.Format("select A.*,B.* from UACS_PARKING_STATUS A left join UACS_YARDMAP_PARKINGSITE B on A.PARKING_NO = B.ID where A.PARKING_NO like '"+Park+"' and B.PARKING_TYPE = '0'");
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        ParkingBase parkingInfo = new ParkingBase();
                        if (rdr["PARKING_NO"] != DBNull.Value)
                        {
                            parkingInfo.ParkingName = rdr["PARKING_NO"].ToString();
                        }
                        if (rdr["X_START"] != DBNull.Value)
                        {
                            parkingInfo.X_START = Convert.ToInt32(rdr["X_START"]);
                        }
                        if (rdr["X_END"] != DBNull.Value)
                        {
                            parkingInfo.X_END = Convert.ToInt32(rdr["X_END"]);
                        }
                        if (rdr["Y_START"] != DBNull.Value)
                        {
                            parkingInfo.Y_START = Convert.ToInt32(rdr["Y_START"]);
                        }
                        if (rdr["Y_END"] != DBNull.Value)
                        {
                            parkingInfo.Y_END = Convert.ToInt32(rdr["Y_END"]);
                        }
                        if (rdr["X_CENTER"] != DBNull.Value)
                        {
                            parkingInfo.X_CENTER = Convert.ToInt32(rdr["X_CENTER"]);
                        }
                        if (rdr["Y_CENTER"] != DBNull.Value)
                        {
                            parkingInfo.Y_CENTER = Convert.ToInt32(rdr["Y_CENTER"]);
                        }
                        if (rdr["X_LENGTH"] != DBNull.Value)
                        {
                            parkingInfo.X_LENGTH = Convert.ToInt32(rdr["X_LENGTH"]);
                        }
                        if (rdr["Y_LENGTH"] != DBNull.Value)
                        {
                            parkingInfo.Y_LENGTH = Convert.ToInt32(rdr["Y_LENGTH"]);
                        }
                        if (rdr["ISLOADED"] != DBNull.Value)
                        {
                            parkingInfo.IsLoaded = Convert.ToInt32(rdr["ISLOADED"]);
                        }
                        if (rdr["HEAD_POSTION"] != DBNull.Value)
                        {
                            parkingInfo.HeadPostion = rdr["HEAD_POSTION"].ToString();
                        }
                        if (rdr["PARKING_STATUS"] != DBNull.Value)
                        {
                            parkingInfo.PackingStatus = Convert.ToInt32(rdr["PARKING_STATUS"]);
                        }
                        if (rdr["CAR_NO"] != DBNull.Value)
                        {
                            parkingInfo.Car_No = rdr["CAR_NO"].ToString();
                        }
                        if (rdr["TREATMENT_NO"] != DBNull.Value)
                        {
                            parkingInfo.TREATMENT_NO = rdr["TREATMENT_NO"].ToString();
                        }
                        if (rdr["STOWAGE_ID"] != DBNull.Value)
                        {
                            parkingInfo.STOWAGE_ID = Convert.ToInt32(rdr["STOWAGE_ID"]);
                        }
                        parkingInfo.CarLength = parkingInfo.Y_END - parkingInfo.Y_START;
                        parkingInfo.CarWidth = parkingInfo.X_END - parkingInfo.X_START;
                        dicCarMessage[parkingInfo.ParkingName] = parkingInfo;
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        /// <summary>
        /// 获得框架配载图指令
        /// </summary>
        public static void dgvStowageOrder(string theParkNO, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                string sql = " SELECT C.GROOVEID, C.MAT_NO,B.BAY_NO,B.FROM_STOCK_NO ,B.TO_STOCK_NO FROM UACS_TRUCK_STOWAGE_DETAIL C ";
                sql += " RIGHT JOIN UACS_CRANE_ORDER_CURRENT B ON C.MAT_NO = B.MAT_NO ";
                sql += " WHERE C.STOWAGE_ID IN (SELECT STOWAGE_ID FROM UACS_PARKING_STATUS WHERE PARKING_NO ='{0}') ORDER BY  C.GROOVEID ";
                sql = string.Format(sql, theParkNO);
                using (IDataReader odrIn = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(odrIn);
                }
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {}
        }

        /// <summary>
        ///  获得框架配载图信息
        /// </summary>
        /// <param name="theStowageId"></param>
        /// <param name="dgv"></param>
        public static void dgvStowageMessage(int theStowageId, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {

                string sql = @"SELECT  A.GROOVEID , A.MAT_NO, A.POS_ON_FRAME, A.X_CENTER, A.Y_CENTER, A.Z_CENTER, C.STOCK_NO,A.PACKAGE_STATUS, 
                                        CASE
                                        WHEN  A.STATUS = 0 THEN '初始化'
                                        WHEN  A.STATUS = 100 THEN '执行完'
                                        WHEN  A.STATUS = 30 THEN '已暂停'
                                        ELSE '其他'
                                    END as  STATUS 
                        , D.WEIGHT, D.OUTDIA ,D.WIDTH  FROM UACS_TRUCK_STOWAGE_DETAIL A  ";
                sql += " LEFT JOIN  UACS_YARDMAP_COIL D ON A.MAT_NO = D.COIL_NO ";
                sql += "LEFT JOIN UACS_YARDMAP_STOCK_DEFINE C ON A.MAT_NO = C.MAT_NO";
                sql += " LEFT JOIN UACS_TRUCK_STOWAGE B ON A.STOWAGE_ID = B.STOWAGE_ID WHERE 1=1 ";                
                sql += " AND B.STOWAGE_ID = '" + theStowageId + "' ORDER BY A.POS_ON_FRAME ";

                using (IDataReader odrIn = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(odrIn);
                }
                dgv.DataSource = dt;
            }
            catch (Exception er)
            {}
        }

        /// <summary>
        /// 获取停车位车辆的类别
        /// </summary>
        /// <param name="theStowageId"></param>
        /// <returns></returns>
        public static string getStowageCarType(int theStowageId)
        {
            string carType = "未知";
            try
            {
                string sql = @"SELECT  CASE
                                        WHEN CAR_TYPE = 100 THEN '框架'
                                        WHEN CAR_TYPE = 101 THEN '一般社会车辆'
                                        WHEN CAR_TYPE = 102 THEN '大头娃娃车'
                                        WHEN CAR_TYPE = 103 THEN '较低社会车辆'
                                        ELSE '其他'
                                    END as CAR_TYPE  FROM UACS_TRUCK_STOWAGE WHERE STOWAGE_ID = " + theStowageId+"";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        carType = rdr["CAR_TYPE"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                return carType;
            }
            return carType;
        }
    }
}
