using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSControls
{
    public partial class FrmMoreStock : Form
    {
        public FrmMoreStock()
        {
            InitializeComponent();
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

        //private string myLibrary;

        //public string MyLibrary
        //{
        //    get { return myLibrary; }
        //    set { myLibrary = value; }
        //}
        

        private void FrmMoreStock_Shown(object sender, EventArgs e)
        {
            GetMoreStockData(dgvMoreStockInfo);
            shiftDgvByColor();
        }

        private void GetMoreStockData(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            bool hasSetColumn = false;
            try
            {
                
                string sql = @" select STOCK_NO,MAT_NO,BAY_NO from UACS_YARDMAP_STOCK_DEFINE where MAT_NO in (select MAT_NO from UACS_YARDMAP_STOCK_DEFINE group by MAT_NO
                               having count(*)>1) ";
                //if (myLibrary == "A")
                //{
                //    sql += " and (BAY_NO = 'A' or BAY_NO = 'B')";
                //}
                //else if (myLibrary == "B")
                //{
                //    sql += " and (BAY_NO = 'A' or BAY_NO = 'B') ";
                //}
                //else
                //{
                //    return;
                //}
                //
                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    dt.Clear();
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
                dgv.DataSource = dt;

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message,er.StackTrace);
            }
        }


        private void shiftDgvByColor()
        {
            if (dgvMoreStockInfo.RowCount > 0)
            {
                int i = 0;
                bool flag = true;
                do
                {
                    if (flag)
                    {
                        dgvMoreStockInfo.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        if (i + 1 < dgvMoreStockInfo.RowCount)
                        {
                            dgvMoreStockInfo.Rows[i + 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        }
                        
                        flag = false;
                    }
                    else
                    {
                        dgvMoreStockInfo.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        if (i + 1 < dgvMoreStockInfo.RowCount)
                        {
                            dgvMoreStockInfo.Rows[i + 1].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        
                        flag = true;
                    }
                    i= i + 2;
                } while (i < dgvMoreStockInfo.RowCount);
            }

            
        }



    }
}
