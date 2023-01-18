using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace UACSDAL
{
    /// <summary>
    /// 小区处理数据类
    /// </summary>
    public class AreaInfo
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        /// <summary>
        /// tag点值的map
        /// </summary>
        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
        public enum AreaType
        {
            /// <summary>
            /// 全部类别
            /// </summary>
            AllType,
            /// <summary>
            /// 库内库区
            /// </summary>
            StockArea,
            /// <summary>
            /// 机组库区
            /// </summary>
            UnitArea,
            /// <summary>
            /// 卡车
            /// </summary>
            CarArea,
            /// <summary>
            /// 除了库区不显示其他都显示
            /// </summary>
            NoStockAndRestsType
        }

        /// <summary>
        /// 行车水位
        /// </summary>
        public const string tag_3_1_waterLevel_Flag = "3_1_h_water";
        public const string tag_3_2_waterLevel_Flag = "3_2_h_water";
        public const string tag_3_3_waterLevel_Flag = "3_3_h_water";
        public const string tag_3_4_waterLevel_Flag = "3_4_h_water";
        public const string tag_3_5_waterLevel_Flag = "3_5_h_water";
        public const string tag_1_waterLevel_Flag = "1_waterLevel_Flag";
        public const string tag_2_waterLevel_Flag = "2_waterLevel_Flag";
        public const string tag_3_waterLevel_Flag = "3_waterLevel_Flag";
        public const string tag_4_waterLevel_Flag = "4_waterLevel_Flag";
        public const string tag_5_waterLevel_Flag = "3_5_l_water";
        public const string tag_1_DownLoadWater = "3_1_DownLoadWater";
        public const string tag_2_DownLoadWater = "3_2_DownLoadWater";
        public const string tag_3_DownLoadWater = "3_3_DownLoadWater";
        public const string tag_4_DownLoadWater = "3_4_DownLoadWater";
        public const string tag_5_DownLoadWater = "3_5_DownLoadWater";


        private string bayNo = string.Empty;
        /// <summary>
        /// 跨别
        /// </summary>
        public string BayNo
        {
            get { return bayNo; }
        }

        private AreaType areaTypeS;
        /// <summary>
        /// 显示库区类别
        /// </summary>
        public AreaType AreaTypeS
        {
            get { return areaTypeS; }
        }

        public void conInit(string theBayNo,AreaType _areaType)
        {
            try
            {
                bayNo = theBayNo;
                areaTypeS = _areaType;

                tagDataProvider.ServiceName = "iplature";

            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 存储每个鞍座对应的数据（字典）
        /// </summary>
        private Dictionary<string, AreaBase> dicSaddles = new Dictionary<string, AreaBase>();
        public Dictionary<string, AreaBase> DicSaddles
        {
            get { return dicSaddles; }
            set { dicSaddles = value; }
        }

        /// <summary>
        /// 查找部分对应数据(不包括小区)
        /// </summary>
        public void getPortionAreaData(string _bayno)
        {

            string sql = null;

            try
            {
                // 标记用于区分小区类别
                sql = "SELECT AREA_NO,X_START,X_END,Y_START,Y_END,AREA_TYPE,AREA_NAME FROM UACS_YARDMAP_AREA_DEFINE";

                if (areaTypeS == AreaType.CarArea)
                {
                    sql += " WHERE BAY_NO LIKE '"+_bayno+"%'  and AREA_TYPE = 1";
                }
                else if (areaTypeS == AreaType.StockArea)
                {
                    sql += " WHERE BAY_NO LIKE '" + _bayno + "%'  and AREA_TYPE = 0";
                }
                else if (areaTypeS == AreaType.UnitArea)
                {
                    sql += " WHERE BAY_NO LIKE '" + _bayno + "%'  and AREA_TYPE in (4,5)";  //机组出入口
                }
                else if (areaTypeS == AreaType.NoStockAndRestsType)
                {
                    sql += " WHERE BAY_NO LIKE '" + _bayno + "%'  and AREA_TYPE != 0";
                }
                else
                {
                    sql += " WHERE BAY_NO LIKE '" + _bayno + "%' ";
                }

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["AREA_NO"] != System.DBNull.Value)
                        {
                            AreaBase theArea = new AreaBase();
                            if (rdr["AREA_NO"] != System.DBNull.Value)
                            {
                                theArea.AreaNo = Convert.ToString(rdr["AREA_NO"]);
                            }
                            if (rdr["X_START"] != System.DBNull.Value)
                            {
                                theArea.X_Start = Convert.ToInt32(rdr["X_START"]) - 1000 ;
                            }
                            if (rdr["X_END"] != System.DBNull.Value)
                            {
                                theArea.X_End = Convert.ToInt32(rdr["X_END"]);
                            }
                            if (rdr["Y_START"] != System.DBNull.Value)
                            {
                                theArea.Y_Start = Convert.ToInt32(rdr["Y_START"]) ;
                            }
                            if (rdr["Y_END"] != System.DBNull.Value)
                            {
                                theArea.Y_End = Convert.ToInt32(rdr["Y_END"]) ;
                            }
                            if (rdr["AREA_TYPE"] != System.DBNull.Value)
                            {
                                theArea.AreaType = Convert.ToInt32(rdr["AREA_TYPE"]);
                            }
                            if (rdr["AREA_NAME"] != System.DBNull.Value)
                            {
                                theArea.Area_Name = Convert.ToString(rdr["AREA_NAME"]);
                            }

                            if (theArea.AreaType == 0)
                            {
                                theArea.SaddleNum = getAreaSaddleNum(theArea.AreaNo);
                                theArea.SaddleNoCoilNum = getAreaSaddleNoCoilNum(theArea.AreaNo);
                                theArea.SaddleCoilNum = getAreaSaddleCoilNum(theArea.AreaNo);

                                //theArea.TBayNO = theArea.AreaNo.Substring(0, 3);
                                theArea.TAreaNo = theArea.AreaNo.Substring(5);

                                //StringBuilder sbTagName_Safe = new StringBuilder("AREA_SAFE_");
                                //sbTagName_Safe.Append(theArea.TBayNO);
                                //sbTagName_Safe.Append("_");
                                //sbTagName_Safe.Append(theArea.TAreaNo);
                                //theArea.AreaDoorSefeName = sbTagName_Safe.ToString();

                                //StringBuilder sbTagName_Reserve = new StringBuilder("AREA_RESERVE_");
                                //sbTagName_Reserve.Append(theArea.TBayNO);
                                //sbTagName_Reserve.Append("_");
                                //sbTagName_Reserve.Append(theArea.TAreaNo);
                                //theArea.AreaDoorReserveName = sbTagName_Reserve.ToString();
                                if(theArea.AreaNo.Contains("FIA"))
                                {
                                    switch (theArea.TAreaNo)
                                    {
                                        case "E":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_1#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_1#";
                                            break;
                                        case "D":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_2#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_2#";
                                            break;
                                        case "C":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_3#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_3#";
                                            break;
                                        case "B":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_4#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_4#";
                                            break;
                                        case "A":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_5#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_5#";
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (theArea.AreaNo.Contains("FIB"))
                                {
                                    switch (theArea.TAreaNo)
                                    {
                                        case "E":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_6#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_6#";
                                            break;
                                        case "D":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_7#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_7#";
                                            break;
                                        case "C":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_8#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_8#";
                                            break;
                                        case "B":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_9#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_9#";
                                            break;
                                        case "A":
                                            theArea.AreaDoorSefeName = "AREA_SAFE_10#";
                                            theArea.AreaDoorReserveName = "AREA_RESERVE_10#";
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                //if (theArea.TBayNO.Contains("Z1"))
                                //{
                                //    if (theArea.TAreaNo == "A" || theArea.TAreaNo == "B")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z11_AB";
                                //    }
                                //    else if (theArea.TAreaNo == "C" || theArea.TAreaNo == "D")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z11_CD";
                                //    }
                                //    else
                                //    {
                                //        StringBuilder sbTagName_Safe = new StringBuilder("AREA_SAFE_");
                                //        sbTagName_Safe.Append(theArea.TBayNO);
                                //        sbTagName_Safe.Append("_");
                                //        sbTagName_Safe.Append(theArea.TAreaNo);

                                //        theArea.AreaDoorSefeName = sbTagName_Safe.ToString();
                                //    }

                                //    StringBuilder sbTagName_Reserve = new StringBuilder("AREA_RESERVE_");
                                //    sbTagName_Reserve.Append(theArea.TBayNO);
                                //    sbTagName_Reserve.Append("_");
                                //    sbTagName_Reserve.Append(theArea.TAreaNo);

                                //    theArea.AreaDoorReserveName = sbTagName_Reserve.ToString();
                                //}
                                //else
                                //{
                                //    if (theArea.AreaNo == "PACK-01")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_PA1";
                                //        theArea.AreaDoorReserveName = "AREA_RESERVE_Z12_PA1";
                                //    }
                                //    if (theArea.AreaNo == "PACK-02")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_PA2";
                                //        theArea.AreaDoorReserveName = "AREA_RESERVE_Z12_PA2";
                                //    }
                                //    if (theArea.AreaNo == "PACK-03")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_PA3";
                                //        theArea.AreaDoorReserveName = "AREA_RESERVE_Z12_PA3";
                                //    }
                                //    if (theArea.AreaNo == "END-PACK-01")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_EPA1";
                                //    }
                                //    if (theArea.AreaNo == "END-PACK-02")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_EPA2";
                                //    }
                                //    if (theArea.AreaNo == "END-PACK-03")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_EPA3";
                                //    }
                                //    if (theArea.AreaNo == "END-STOCK-01")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_EST1";
                                //    }
                                //    if (theArea.AreaNo == "END-STOCK-02")
                                //    {
                                //        theArea.AreaDoorSefeName = "AREA_SAFE_Z12_EST2";
                                //    }
                                //}

                            }
                            dicSaddles[theArea.AreaNo] = theArea;
                        }                     
                    }
                }
            }
            catch (Exception er)
            {
                
                throw;
            } 
            
        }
        private string areaNo = string.Empty;
        public string AreaNo
        {
            get { return areaNo; }
        }
        private bool Flag = false;
        public void conInit(string theAreaNo, string tagServiceName, bool flag)
        {
            try
            {
                areaNo = theAreaNo;
                Flag = flag;
                //初始化Tag
                tagDataProvider.ServiceName = tagServiceName;
                //tagDP.AutoRegist = true;
                getTagNameList();
            }
            catch (Exception ex)
            {
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
                foreach (AreaBase item in dicSaddles.Values)
                {
                    if (item.AreaType == 0)
                    {
                        TagNamelist.Add(item.AreaDoorReserveName);
                        TagNamelist.Add(item.AreaDoorSefeName);
                    }
                    TagNamelist.Add(tag_1_waterLevel_Flag);
                    TagNamelist.Add(tag_2_waterLevel_Flag);
                    TagNamelist.Add(tag_3_waterLevel_Flag);
                    TagNamelist.Add(tag_4_waterLevel_Flag);
                    TagNamelist.Add("BY1");
                    TagNamelist.Add("BY2");
                    TagNamelist.Add("BY3");
                    TagNamelist.Add("BY4");                   

                }
                
                arrTagAdress = TagNamelist.ToArray<string>();
                readTags();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                throw;
            }
        }

        private void readTags()
        {
            try
            {
                inDatas.Clear(); 
                tagDataProvider.GetData(arrTagAdress, out inDatas);
            }
            catch (Exception ex)
            {
            }
        }

        

        /// <summary>
        /// 遍历tag点获取值
        /// </summary>
        public void getTagValues()
        {
            //string t = "";
            try
            {
                //清空原来的map
                inDatas.Clear();
                //读所有鞍座tag点的值
                tagDataProvider.GetData(arrTagAdress, out inDatas);


                //为每个鞍座的tag点值属性赋值
                foreach (AreaBase item in dicSaddles.Values)
                {
                    if (item.AreaType == 0)
                    {
                        item.AreaDoorSefeValue = get_value_x(item.AreaDoorSefeName);
                        //t = item.AreaDoorSefeName;
                        item.AreaDoorReserveValue = get_value_x(item.AreaDoorReserveName);
                       // t += ", " + item.AreaDoorReserveName;
                    }

                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(t + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);

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
        /// 读小区全部鞍座数量
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleNum(string _AreaNo)
        {
            int saddlenum = 0;
            try
            {
                string sql= string.Empty;
                //查询所有有鞍座坐标的鞍座数量
                sql = @"SELECT COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE A left join UACS_YARDMAP_SADDLE_STOCK B on A.STOCK_NO = B.STOCK_NO  
                            left join UACS_YARDMAP_SADDLE_DEFINE C on B.SADDLE_NO = C.SADDLE_NO 
                            LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE D ON D.COL_ROW_NO = C.COL_ROW_NO
                            WHERE D.AREA_NO like '" + _AreaNo + "%' and C.X_CENTER > 0 ";
                           
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddlenum = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                return 0;
            }
            return saddlenum;
        }

        /// <summary>
        /// 读小区白库位数量
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleNoCoilNum(string _AreaNo)
        {
            int saddleNoCoil = 0;
            try
            {
                string sql = string.Empty;
                sql = @"SELECT  COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE A left join UACS_YARDMAP_SADDLE_STOCK B on A.STOCK_NO = B.STOCK_NO  
                            left join UACS_YARDMAP_SADDLE_DEFINE C on B.SADDLE_NO = C.SADDLE_NO 
                             LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE D ON D.COL_ROW_NO = C.COL_ROW_NO
                            WHERE D.AREA_NO like '" + _AreaNo + "%' and C.X_CENTER > 0 AND A.STOCK_STATUS = 0 AND A.LOCK_FLAG = 0";
                    
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddleNoCoil = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                return 0;
            }
            return saddleNoCoil;
        }

        /// <summary>
        /// 读小区黑库位数量
        /// </summary>
        /// <param name="_AreaNo"></param>
        /// <returns></returns>
        public int getAreaSaddleCoilNum(string _AreaNo)
        {
            int saddleCoil = 0;
            try
            {
                string sql = string.Empty;
                sql = @"SELECT  COUNT(*) as num FROM UACS_YARDMAP_STOCK_DEFINE A left join UACS_YARDMAP_SADDLE_STOCK B on A.STOCK_NO = B.STOCK_NO  
                            left join UACS_YARDMAP_SADDLE_DEFINE C on B.SADDLE_NO = C.SADDLE_NO 
                             LEFT JOIN UACS_YARDMAP_ROWCOL_DEFINE D ON D.COL_ROW_NO = C.COL_ROW_NO
                            WHERE D.AREA_NO like '" + _AreaNo + "%' and C.X_CENTER > 0 AND  A.STOCK_STATUS = 2 AND A.LOCK_FLAG = 0";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                            saddleCoil = Convert.ToInt32(rdr["num"]);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            return saddleCoil;
        }

        /// <summary>
        /// 行车水位状态
        /// </summary>
        /// <param name="crane"></param>
        /// <returns></returns>
        public bool getCraneWaterLevelStatus(string crane)
        {
            bool ret = false;
            switch (crane)
            {
                case "1":
                    ret = GetDaoZhaState(tag_1_waterLevel_Flag);
                    break;
                case "2":
                    ret = GetDaoZhaState(tag_2_waterLevel_Flag);
                    break;
                case "3":
                    ret = GetDaoZhaState(tag_3_waterLevel_Flag);
                    break;
                case "4":
                    ret = GetDaoZhaState(tag_4_waterLevel_Flag);
                    break;
                //case "5":
                //    ret = GetDaoZhaState(tag_5_waterLevel_Flag);
                //    break;              
                //case "_1":
                //    ret = GetDaoZhaState(tag_1_DownLoadWater);
                //    break;
                //case "_2":
                //    ret = GetDaoZhaState(tag_2_DownLoadWater);
                //    break;
                //case "_3":
                //    ret = GetDaoZhaState(tag_3_DownLoadWater);
                //    break;
                //case "_4":
                //    ret = GetDaoZhaState(tag_4_DownLoadWater);
                //    break;
                //case "_5":
                //    ret = GetDaoZhaState(tag_5_DownLoadWater);
                //    break;  
                default:
                    break;
            }
            return ret;
        }

        /// <summary>
        /// tag点value为1是为true
        /// </summary>
        /// <param name="gate"></param>
        /// <returns></returns>
        public bool GetDaoZhaState(string gate)
        {
            bool ret = false;
            string tagName = gate;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                if (valueObject != null && valueObject.ToString() == "1")
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            return ret;
        }

        /// <summary>
        /// 获取光电门状态 0：开，1：关
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool getPhotogateStatus(string area)
        {
            bool ret = false;
            switch (area)
            {
                case "BC":
                    ret = GetDaoZhaState("BY1");
                    break;
                case "CD":
                    ret = GetDaoZhaState("BY2");
                    break;
                case "B-BC":
                    ret = GetDaoZhaState("BY3");
                    break;
                case "B-CD":
                    ret = GetDaoZhaState("BY4");
                    break;               
                default:
                    break;
            }
            return ret;
        }
    }
}
