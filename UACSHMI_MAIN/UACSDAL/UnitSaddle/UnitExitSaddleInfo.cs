using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSDAL
{
    public class UnitExitSaddleInfo
    {
        /// <summary>
        /// 查询机组鞍座出口鞍座信息
        /// </summary>
        public void getExitSaddleDt(DataGridView _dgv, string _unitNo)
        {
            bool hasSetColumn = false;
            DataTable dt = new DataTable();
            try
            {
                string sqlText = @"SELECT A.SADDLE_L2NAME,A.STOCK_NO,B.COIL_NO,C.WEIGHT,C.WIDTH,C.INDIA,C.OUTDIA,
                                    CASE
                                        WHEN  C.PACK_FLAG = 1 THEN '已包装'
                                        ELSE '未包装'
                                    END as  PACK_FLAG , ";
                sqlText += "C.FORBIDEN_FLAG,C.DUMMY_COIL_FLAG,C.NEXT_UNIT_NO,C.PACK_CODE ";
                sqlText += ",B.WORK_ORDER_NO,B.PRODUCT_DATE ,B.TIME_LAST_CHANGE ";
                sqlText += "FROM UACS_LINE_SADDLE_DEFINE A LEFT JOIN UACS_LINE_EXIT_L2INFO B ";
                sqlText += "ON A.UNIT_NO = B.UNIT_NO AND A.SADDLE_L2NAME = B.SADDLE_L2NAME ";
                sqlText += "  LEFT JOIN UACS_YARDMAP_COIL C ON C.COIL_NO = B.COIL_NO ";
                if (_unitNo != null) 
                {
                    sqlText += " WHERE A.UNIT_NO = '" + _unitNo + "' AND A.FLAG_UNIT_EXIT = 1  ORDER BY A.STOCK_NO ";
                }
                else
                    return;
               
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
            _dgv.DataSource = dt;
        }
        public void getExitSaddleNO(string unitNo, ArrayList stockNo)
        {
            try
            {

                string sql = @"SELECT STOCK_NO FROM UACS_LINE_SADDLE_DEFINE ";
                sql += "WHERE UNIT_NO = '" + unitNo + "'  AND STOCK_NO LIKE '%C%'";

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
