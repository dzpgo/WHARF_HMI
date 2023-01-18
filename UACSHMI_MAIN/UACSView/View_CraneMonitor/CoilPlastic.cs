using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace UACSView.View_CraneMonitor
{
    public partial class CoilPlastic : FormBase
    {
        public CoilPlastic()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        bool hasSetColumn;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Area_NO = comboBox1.Text.ToString().Trim();
            string sqlText = @"SELECT 0 AS CHECK_COLUMN,A.COIL_NO,B.STOCK_NO,A.WEIGHT,A.OUTDIA,A.WIDTH,A.INDIA,CASE
                                        WHEN C.PLASTIC_FLAG = 1 THEN '已套袋'
                                        ELSE '未套袋'
                                    END as  PLASTIC_FLAG,B.BAY_NO";
            sqlText += " FROM UACS_YARDMAP_COIL A";
            sqlText += " LEFT JOIN UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO ";
            sqlText += " LEFT JOIN UACS_YARDMAP_COIL_PLASTIC C ON A.COIL_NO = C.COIL_NO ";
            sqlText += " WHERE B.MAT_NO != 'NULL' AND B.STOCK_NO LIKE '" + Area_NO + "%' ORDER BY B.STOCK_NO";

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
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
            this.dataGridView1.DataSource = dt;
        
        }

        private void btnCoilSelect_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("请选择库区！");
                return;
            }
            string strStockNO = txtSaddleNO.Text.ToString().Trim();
            string coilNO = CoilNO.Text.ToString().Trim();
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (dgvRow.Cells["STOCK_NO"].Value != null)
                {
                    if (dgvRow.Cells["STOCK_NO"].Value.ToString() == strStockNO)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                        dgvRow.Cells["STOCK_NO"].Selected = true;
                        //dgvRow.Cells["CHECK_COLUMN"].Value = true;
                        dataGridView1.CurrentCell = dgvRow.Cells["STOCK_NO"];
                    }
                    if (dgvRow.Cells["COIL_NO"].Value.ToString() == coilNO)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = dgvRow.Index;
                        dgvRow.Cells["COIL_NO"].Selected = true;
                        //dgvRow.Cells["CHECK_COLUMN"].Value = true;
                        dataGridView1.CurrentCell = dgvRow.Cells["COIL_NO"];
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            for(int i=0; i<dataGridView1.RowCount; i++)
            {
                bool isChoosed = (bool)dataGridView1.Rows[i].Cells[0].FormattedValue;
                string MAT_NO = dataGridView1.Rows[i].Cells["COIL_NO"].Value.ToString().Trim();
                if(isChoosed)
                {
                    bool flag = false;
                    try
                    {
                        string sql1 = "select * from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '" + MAT_NO + "'";

                        using (IDataReader rdr = DBHelper.ExecuteReader(sql1))
                        {
                            while (rdr.Read())
                            {
                                flag = true;
                                string sql2 = @"UPDATE UACS_YARDMAP_COIL_PLASTIC SET PLASTIC_FLAG = 1,PLASTIC_TIME = current timestamp  WHERE COIL_NO = '" + MAT_NO + "' ";
                                DBHelper.ExecuteNonQuery(sql2);
                            }
                        }
                        if (!flag)
                        {
                            string sql2 = @"insert into UACS_YARDMAP_COIL_PLASTIC(COIL_NO,PLASTIC_FLAG,PLASTIC_TIME)  values ( '" + MAT_NO + "',1,current timestamp )";
                            DBHelper.ExecuteNonQuery(sql2);
                        }
                        count += 1;
                    }
                    catch(Exception)
                    {
                        throw;
                    }
                }
            }
            if(count != 0)
            {

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Cells["CHECK_COLUMN"].Value = 0;
                }
                MessageBox.Show("提交成功！");
            }
            else
            {
                MessageBox.Show("请选择钢卷！");
                return;
            }          
                
            
           
        }
    }
}
