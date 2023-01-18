using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSDAL
{
    public class UnitEntrySaddleInfo
    {
        /// <summary>
        /// 查询指定的机组入口鞍座信息
        /// </summary>
        public void getEntrySaddleDt(DataGridView _dgv, string unit_no)
        {
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
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
                sqlText += " FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN UACS_LINE_ENTRY_L2INFO B ON A.UNIT_NO= B.UNIT_NO ";
                sqlText += " AND A.SADDLE_L2NAME=B.SADDLE_L2NAME LEFT JOIN UACS_YARDMAP_COIL C  ON C.COIL_NO = B.COIL_NO  ";
                sqlText += " WHERE A.UNIT_NO= '" + unit_no + "' AND A.FLAG_UNIT_EXIT = 0 ORDER BY A.SADDLE_L2NAME ";

                //清除datatable
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sqlText))
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
            {}
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
            _dgv.DataSource = dt;
        }

        /// <summary>
        /// 计划顺序
        /// </summary>
        public void getL2PlanByUnitNo(DataGridView _dgv, string _unit_no)
        {
            DataTable dt = new DataTable();
            try
            {
                string sqlText = null;
                sqlText = @"SELECT PLAN_SEQ,COIL_NO,WEIGHT,WIDTH,IN_DIA,OUT_DIA,PACK_FLAG,     
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
                sqlText += "WHERE UNIT_NO = '" + _unit_no + "' order by PLAN_SEQ";
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
                dt.Columns.Add("PLASTIC_FLAG", typeof(String));
                dt.Columns.Add("X_CENTER", typeof(String));

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        if (rdr["PLAN_SEQ"] != DBNull.Value)
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
                        {
                            dr["STOCK_NO"] = getStockByCoilNo(rdr["COIL_NO"].ToString());
                            dr["X_CENTER"] = getXCenterByCoilNo(rdr["COIL_NO"].ToString());
                            if(getCoil_PLASTIC_FLAG(rdr["COIL_NO"].ToString())!=null)
                            {
                                dr["PLASTIC_FLAG"] = getCoil_PLASTIC_FLAG(rdr["COIL_NO"].ToString());
                            }
                            else
                            {
                                dr["PLASTIC_FLAG"] = "未知";
                            }
                        }                         
                        else
                        {
                            dr["STOCK_NO"] = "";
                            dr["X_CENTER"] = "";
                            dr["PLASTIC_FLAG"]= "";
                        }   
                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception er)
            {
                return;
            }
            _dgv.DataSource = dt;
        }

        /// <summary>
        /// 根据机组号查询钢卷
        /// </summary>
        public string getCoilByUnitNo(string _unitNO)
        {
            string coilNo = null;
            try
            {           
                string sql = @"SELECT NEXT_COILNO FROM UACS_LINE_NEXTCOIL WHERE UNIT_NO = '" + _unitNO + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["NEXT_COILNO"] != DBNull.Value)
                        {
                            coilNo = rdr["NEXT_COILNO"].ToString();
                        }
                        else
                            coilNo = null;
                    }
                }
            }
            catch (Exception er)
            {
                return coilNo;
            }
            return coilNo;
        }

        /// <summary>
        /// 根据钢卷号查询库位
        /// </summary>
        /// <param name="coil"></param>
        /// <returns></returns>
        private string getStockByCoilNo(string coilNo)
        {
            string stockNo = null;
            try
            {
                string sql = @"SELECT STOCK_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO = '" + coilNo + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOCK_NO"] != DBNull.Value)
                        {
                            stockNo = rdr["STOCK_NO"].ToString();
                        }
                        else
                            stockNo = null;
                    }
                }
            }
            catch (Exception er)
            {
                return stockNo;
            }
            return stockNo;
        }

        private string getCoil_PLASTIC_FLAG(string coilNo)
        {
            string PLASTIC_FLAG = null;
            try
            {
                string sql = @"SELECT 
                             (CASE PLASTIC_FLAG
                             WHEN 1 THEN '套袋' 
                             WHEN 0 THEN '无套袋' 
                             else '未知' 
                             end ) PLASTIC_FLAG 
                             FROM UACS_YARDMAP_COIL_PLASTIC WHERE COIL_NO = '" + coilNo + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["PLASTIC_FLAG"] != DBNull.Value)
                        {
                            PLASTIC_FLAG = rdr["PLASTIC_FLAG"].ToString();
                        }
                        else
                            PLASTIC_FLAG = null;
                    }
                }
            }
            catch (Exception er)
            {
                return PLASTIC_FLAG;
            }
            return PLASTIC_FLAG;
        }

        /// <summary>
        /// 根据钢卷号查询X中心点
        /// </summary>
        /// <param name="coil"></param>
        /// <returns></returns>
        private string getXCenterByCoilNo(string coil)
        {
            string xCenter = "";
            try
            {
                string sql = @"select D.X_CENTER as X_CENTER from UACS_LINE_L2PLAN  A  inner join  UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO
                               inner join UACS_YARDMAP_SADDLE_STOCK C on C.STOCK_NO = B.STOCK_NO 
                               inner join UACS_YARDMAP_SADDLE_DEFINE D on D.SADDLE_NO = C.SADDLE_NO 
                               WHERE A.COIL_NO = '" + coil + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["X_CENTER"] != DBNull.Value)
                            xCenter = rdr["X_CENTER"].ToString();
                    }
                }
            }
            catch (Exception er)
            {
                return xCenter;
            }
            return xCenter;
        }


        /// <summary>
        /// 获取机组入口上料状态
        /// </summary>
        /// <param name="unitNo"></param>
        /// <returns></returns>
        public int getEntryMode(string unitNo)
        {
            int Auto_flag = 999;
            try
            {               
                    string sql = @"SELECT FLAG_JOIN FROM UACS_LINE_ENTRY_LOAD_ACTOR ";
                    sql += "WHERE ACTOR_ID = '" + unitNo + "' ";
                    //sql += "WHERE ACTOR_ID LIKE '" + unitNo + "%' ";

                    using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                    {
                        while (rdr.Read())
                        {
                            if (rdr["FLAG_JOIN"] != DBNull.Value)
                            {
                                Auto_flag = Convert.ToInt32(rdr["FLAG_JOIN"]);
                            }                    
                        }
                    }
            }
            catch (Exception er)
            {

                return Auto_flag;
            }
            return Auto_flag;
        }



        /// <summary>
        /// 设置入口自动上料开始、停止状态
        /// </summary>
        /// <param name="unitNo">机组</param>
        /// <param name="flag">开始：1  停止：0</param>
        /// <returns></returns>
        public bool setEntryMode(string unitNo,int flag)
        {
            try
            {
                string sql = @"UPDATE UACS_LINE_ENTRY_LOAD_ACTOR SET FLAG_JOIN = " + flag + " WHERE ACTOR_ID LIKE '" + unitNo + "' ";
                 DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception )
            {

                return false;
            }
            return true;
        }

        public void getEntrySaddleNO(string unitNo ,ArrayList stockNo)
        {
            try
            {

                string sql = @"SELECT STOCK_NO FROM UACS_LINE_SADDLE_DEFINE ";
                sql += "WHERE UNIT_NO = '" + unitNo + "'  AND STOCK_NO LIKE '%R%'";

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["STOCK_NO"] != DBNull.Value)
                        {
                            stockNo.Add((rdr["STOCK_NO"]).ToString());
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}
