using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACS;
using System.Runtime.InteropServices;

namespace UACSView
{
    public partial class StatForm : FormBase
    {
        private DataBaseHelper m_dbHelper;
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
        public StatForm()
        {
            InitializeComponent();
            this.Load += StatForm_Load;
        }

        void StatForm_Load(object sender, EventArgs e)
        {
            m_dbHelper = new DataBaseHelper();
            m_dbHelper.OpenDB(DBHelper.ConnectionString);
        }
       
       

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_dbHelper == null)
                return;

           // HMILogger.WriteLog("k1","k2","message");


            //选择班组
            string strshift = cmbShift.Text.Trim();
            
            //选择哪一跨的
            string strWare = cmbWare.Text.Trim();

            DateTime dt = dateTimePicker1.Value; ;
            DateTime dt2 = dateTimePicker2.Value;
            string timespan1 = ViewHelper.GenTimeSpanSQL(strshift.Trim(), dt, dt2, "REC_TIME");

            
            string timespan2 = ViewHelper.GenTimeSpanSQL(dt, dt2, "REC_TIME");

            //查询作业总数
            string sql0 = @"select crane_no,cast(count(*) /2 as int) as num  from  UACS_CRANE_ORDER_OPER ";
            if (strshift == "全部")
            {
                sql0 += "  where " + timespan2 ;
            }
            else
            {
                sql0 += "  where " + timespan1;
            }
            //查询出3列
            string sql1 = @"select crane_no,CASE
          WHEN crane_mode = 1 THEN '遥控'
          WHEN crane_mode = 2 THEN '手动'
          WHEN crane_mode = 4 THEN '自动'
      END as mode ,cast(count(*) /2 as int) as num  from  UACS_CRANE_ORDER_OPER ";
            if (strshift == "全部")
            {
                sql1 += "  where " + timespan2;
            }
            else
            {
                sql1 += "  where " + timespan1;
            }

            //增加作业类型，共4列
            string sql2 = @"select CASE
          WHEN order_type = 11 THEN '入库(出口收料)'
          WHEN order_type = 12 THEN '入库(台车收料)'
          WHEN order_type = 13 THEN '入库(车辆卸载)'       
          WHEN order_type = 14 THEN '入库(入口退料)'
          WHEN order_type = 21 THEN '出库(入口上料)'
          WHEN order_type = 22 THEN '出库(台车上料)'
          WHEN order_type = 23 THEN '出库(车辆装载)'
          WHEN order_type = 24 THEN '出库(称重标定)'
          WHEN order_type = 31 THEN '倒垛(库内倒垛)'
          ELSE '其他'
       END as ordertype, crane_no,CASE
          WHEN crane_mode = 1 THEN '遥控'
          WHEN crane_mode = 2 THEN '手动'
          WHEN crane_mode = 4 THEN '自动'
      END as mode ,cast(count(*) /2 as int) as num  from  UACS_CRANE_ORDER_OPER where " + timespan1;

            string sql3 = @"SELECT 
                      CASE
                          
                          WHEN STOCK_NO like 'D102%' THEN '102出口'
                          WHEN STOCK_NO like 'D108%' THEN '108入口'
                          WHEN STOCK_NO like 'D108%' THEN '208入口'
                          WHEN STOCK_NO like 'D108%' THEN '112入口'
                          WHEN STOCK_NO like 'D401WC1A%' THEN 'D401-C'
                       END as stock_no ,
                count(*) as num,
                CASE
                          WHEN order_type = 11 THEN '机组产出'
                          WHEN order_type = 12 THEN '机组回退'
                          WHEN order_type = 13 THEN '框架入库'       
                          WHEN order_type = 14 THEN '包装入库'
                          WHEN order_type = 21 THEN '机组上料' 
                          WHEN order_type = 22 THEN '废品出库'
                          WHEN order_type = 23 THEN '包装出库'
                          WHEN order_type = 24 THEN '转库出库'
                          WHEN order_type = 25 THEN '发货出库'
                          WHEN order_type = 31 THEN '倒剁'
                          ELSE '其他'
                       END as ordertype,
                       crane_no
                       ,CASE
                          WHEN crane_mode = 1 THEN '遥控'
                          WHEN crane_mode = 2 THEN '手动'
                          WHEN crane_mode = 4 THEN '自动'
                      END as mode
                 FROM UACS_CRANE_ORDER_OPER
                 WHERE " + timespan1;

            sql3 += " and (STOCK_NO like 'D108%' or STOCK_NO like 'D112%' or STOCK_NO like 'D102%' or STOCK_NO like 'D208%') ";
            //sql3 += " and (STOCK_NO like 'D401%' ) ";
            //sql3 += " and ( crane_no='4_1' or crane_no='4_2' or crane_no='4_3') ";
            sql3 += " and ( crane_no='3_1' or crane_no='3_2' or crane_no='3_3' or crane_no='3_4' or crane_no='3_5') ";
            sql3 += "and crane_no in ('3_1','3_2','3_3','3_4','3_5')";


            if (strWare == "A跨")
            {
                sql0 += " and ( crane_no='1' or crane_no='2' )";
                sql1 += " and ( crane_no='1' or crane_no='2' )";
                sql2 += " and ( crane_no='1' or crane_no='2' )";
            }
            else if (strWare == "B跨")
            {
                sql0 += " and  crane_no in ('3','4')";
                sql1 += " and  crane_no in ('3','4')";
                sql2 += " and  crane_no in ('3','4')";

            }
             if (strWare == "全部")
            {
                sql0 += "and crane_no in ('1','2','3','4')";
                sql1 += "and crane_no in ('1','2','3','4')";
                sql2 += "and crane_no in ('1','2','3','4')";
            }
            sql0 += " group by crane_no";
            sql1 += " group by crane_no,crane_mode";
            sql2 += " group by order_type,crane_no,crane_mode";
            sql3 += " group by stock_no,crane_mode,crane_no,order_type";

            //查询吊运总数
            DataTable data0 = null;
            string error = "";
            // DBHelper.ReadTable
            data0 = m_dbHelper.ReadData(sql0, out error);

            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            //计算百分比
            if (data0 != null)
            {
                foreach (DataRow dr in data0.Rows)
                {                  
                   int tmp =(int)dr[1];
                   myDictionary.Add((string)dr[0], tmp);
                }
            }
            DataTable data1 = null;
            data1 = m_dbHelper.ReadData(sql1, out error);

                 

            //计算百分比
            if (data1 != null)
            {
                data1.Columns.Add("PERCENT", Type.GetType("System.Single"));
                dataGridView1.Rows.Clear();   

                foreach(DataRow dr in data1.Rows)
                {
                    string str = (string)dr[0];
                    int count = myDictionary[str];
                    if (count!=0)
                    {
                        float temp = (float)((int)dr[2] * 100 / (float)count);
                        dr[3] = float.Parse(temp.ToString("#0.00"));
                    }
                     else
                        dr[3] = 0.0;
                    // myDictionary[str];
                }
            }

            ViewHelper.SetDataGridViewData(dataGridView1, data1, true);

            DataTable data2 = null;

            data2 = m_dbHelper.ReadData(sql2, out error);

            dataGridView2.Rows.Clear();
            ViewHelper.SetDataGridViewData(dataGridView2, data2, true);

            GetDatagridview(timespan1);
            VisibleColumn(dataGridView3);
            //DataTable data3 = null;

            //data3 = m_dbHelper.ReadData(sql3, out error);




            //dataGridView3.Rows.Clear();
            //ViewHelper.SetDataGridViewData(dataGridView3, data3, true);


            dataGridViewColor(); 
        }

        private void StatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_dbHelper.CloseDB();
        }

        

        private void dataGridViewColor()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               // CraneMode1
                if (dataGridView1.Rows[i].Cells["CraneMode1"].Value != System.DBNull.Value)
                {
                    if (dataGridView1.Rows[i].Cells["CraneMode1"].Value.ToString().Trim() == "自动")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["CraneMode2"].Value != System.DBNull.Value)
                {
                    if (dataGridView2.Rows[i].Cells["CraneMode2"].Value.ToString().Trim() == "自动")
                    {
                        //dataGridView2.Rows[i].Cells["CraneMode2"].Style.BackColor = Color.Blue;
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }


            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Cells["CraneMode3"].Value != System.DBNull.Value)
                {
                    if (dataGridView3.Rows[i].Cells["CraneMode3"].Value.ToString().Trim() == "自动")
                    {
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }



        private void GetDatagridview(string time)
        {
            dataGridView3.Rows.Clear();
            dataGridView3.Rows.Add(12);
            dataGridView3.Rows[0].Cells[0].Value = "D102";
            dataGridView3.Rows[0].Cells[1].Value = GetNUM(time, 21, "D102", 4);  //自动上料D212
            dataGridView3.Rows[0].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[0].Cells[3].Value = "自动";

            dataGridView3.Rows[1].Cells[0].Value = "D102";
            dataGridView3.Rows[1].Cells[1].Value = GetNUM(time, 21, "D102", 2);  //手动上料D212
            dataGridView3.Rows[1].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[1].Cells[3].Value = "手动";

            dataGridView3.Rows[2].Cells[0].Value = "D102";
            dataGridView3.Rows[2].Cells[1].Value = GetNUM(time, 14, "D401WR", 4);  //自动退料D212
            dataGridView3.Rows[2].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[2].Cells[3].Value = "自动";

            dataGridView3.Rows[3].Cells[0].Value = "D102";
            dataGridView3.Rows[3].Cells[1].Value = GetNUM(time, 14, "D102", 2);  //手动退料D212
            dataGridView3.Rows[3].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[3].Cells[3].Value = "手动";

            dataGridView3.Rows[4].Cells[0].Value = "D102";
            dataGridView3.Rows[4].Cells[1].Value = GetNUM(time, 21, "D102", 1);  //遥控上料D212
            dataGridView3.Rows[4].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[4].Cells[3].Value = "遥控";

            dataGridView3.Rows[5].Cells[0].Value = "D102";
            dataGridView3.Rows[5].Cells[1].Value = GetNUM(time, 14, "D102", 1);  //遥控退料D212
            dataGridView3.Rows[5].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[5].Cells[3].Value = "遥控";

            dataGridView3.Rows[6].Cells[0].Value = "D108";
            dataGridView3.Rows[6].Cells[1].Value = GetNUM(time, 24, "D401WC", 4);  //自动上料D308
            dataGridView3.Rows[6].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[6].Cells[3].Value = "自动";

            dataGridView3.Rows[7].Cells[0].Value = "D108";
            dataGridView3.Rows[7].Cells[1].Value = GetNUM(time, 24, "D401WC", 2);  //手动上料D308
            dataGridView3.Rows[7].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[7].Cells[3].Value = "手动";

            dataGridView3.Rows[8].Cells[0].Value = "D108";
            dataGridView3.Rows[8].Cells[1].Value = GetNUM(time, 11, "D108", 4);  //自动退料D308
            dataGridView3.Rows[8].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[8].Cells[3].Value = "自动";

            dataGridView3.Rows[9].Cells[0].Value = "D108";
            dataGridView3.Rows[9].Cells[1].Value = GetNUM(time, 11, "D108", 2);  //手动退料D308
            dataGridView3.Rows[9].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[9].Cells[3].Value = "手动";


            dataGridView3.Rows[10].Cells[0].Value = "D108";
            dataGridView3.Rows[10].Cells[1].Value = GetNUM(time, 24, "D108", 1);  //遥控上料D308
            dataGridView3.Rows[10].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[10].Cells[3].Value = "遥控";

            dataGridView3.Rows[11].Cells[0].Value = "D108";
            dataGridView3.Rows[11].Cells[1].Value = GetNUM(time, 11, "D108", 1);  //遥控退料D308
            dataGridView3.Rows[11].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[11].Cells[3].Value = "遥控";

            dataGridView3.Rows[6].Cells[0].Value = "D208";
            dataGridView3.Rows[6].Cells[1].Value = GetNUM(time, 24, "D208", 4);
            dataGridView3.Rows[6].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[6].Cells[3].Value = "自动";

            dataGridView3.Rows[7].Cells[0].Value = "D208";
            dataGridView3.Rows[7].Cells[1].Value = GetNUM(time, 24, "D208", 2);
            dataGridView3.Rows[7].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[7].Cells[3].Value = "手动";

            dataGridView3.Rows[8].Cells[0].Value = "D208";
            dataGridView3.Rows[8].Cells[1].Value = GetNUM(time, 11, "D208", 4); 
            dataGridView3.Rows[8].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[8].Cells[3].Value = "自动";

            dataGridView3.Rows[9].Cells[0].Value = "D208";
            dataGridView3.Rows[9].Cells[1].Value = GetNUM(time, 11, "D208", 2); 
            dataGridView3.Rows[9].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[9].Cells[3].Value = "手动";


            dataGridView3.Rows[10].Cells[0].Value = "D208";
            dataGridView3.Rows[10].Cells[1].Value = GetNUM(time, 24, "D208", 1);
            dataGridView3.Rows[10].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[10].Cells[3].Value = "遥控";

            dataGridView3.Rows[11].Cells[0].Value = "D208";
            dataGridView3.Rows[11].Cells[1].Value = GetNUM(time, 11, "D208", 1);
            dataGridView3.Rows[11].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[11].Cells[3].Value = "遥控";

            dataGridView3.Rows[6].Cells[0].Value = "D112";
            dataGridView3.Rows[6].Cells[1].Value = GetNUM(time, 24, "D112", 4);
            dataGridView3.Rows[6].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[6].Cells[3].Value = "自动";

            dataGridView3.Rows[7].Cells[0].Value = "D112";
            dataGridView3.Rows[7].Cells[1].Value = GetNUM(time, 24, "D112", 2);
            dataGridView3.Rows[7].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[7].Cells[3].Value = "手动";

            dataGridView3.Rows[8].Cells[0].Value = "D112";
            dataGridView3.Rows[8].Cells[1].Value = GetNUM(time, 11, "D112", 4);
            dataGridView3.Rows[8].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[8].Cells[3].Value = "自动";

            dataGridView3.Rows[9].Cells[0].Value = "D112";
            dataGridView3.Rows[9].Cells[1].Value = GetNUM(time, 11, "D112", 2);
            dataGridView3.Rows[9].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[9].Cells[3].Value = "手动";


            dataGridView3.Rows[10].Cells[0].Value = "D112";
            dataGridView3.Rows[10].Cells[1].Value = GetNUM(time, 24, "D112", 1);
            dataGridView3.Rows[10].Cells[2].Value = "出库(入口上料)";
            dataGridView3.Rows[10].Cells[3].Value = "遥控";

            dataGridView3.Rows[11].Cells[0].Value = "D112";
            dataGridView3.Rows[11].Cells[1].Value = GetNUM(time, 11, "D112", 1);
            dataGridView3.Rows[11].Cells[2].Value = "入库(入口退料)";
            dataGridView3.Rows[11].Cells[3].Value = "遥控";
            
        }
        /// <summary>
        /// 获取具体数量
        /// orderType 分为
        /// 机组回退（14）
        /// 机组上料（21）
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="orderType">类别</param>
        /// <param name="stockNo">机组号</param>
        /// <param name="mode">行车模式</param>
        /// <returns></returns>
        private string GetNUM(string time,int orderType,string unitNo,int mode)
        {
            string num = "0";
            try
            {
                string sql = @" SELECT  count(*) as num  FROM UACS_CRANE_ORDER_OPER ";
                sql += " WHERE " + time;
                sql += " and (crane_no='3_1' or crane_no = '3_2' or crane_no = '3_3' or crane_no = '3_4' or crane_no = '3_5')  and ORDER_TYPE = " + orderType + " ";
                sql += " and STOCK_NO like '" + unitNo + "%' ";
                sql += " and crane_mode = " + mode + " ";

                using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["num"] != DBNull.Value)
                        {
                            num =rdr["num"].ToString();
                        }
                        else
                        {
                            num = "0";
                        }
                       
                    }
                }

                return num;
 
            }
            catch (Exception er)
            {
                return "0";
            }
        }


        private void VisibleColumn(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["num"].Value != System.DBNull.Value)
                {
                    if (dgv.Rows[i].Cells["num"].Value.ToString().Trim() == "0")
                    {
                        dgv.Rows[i].Visible = false;
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {

               DialogResult ret = saveFileDialog1.ShowDialog();
                if(ret == DialogResult.Cancel )
                {
                    return;
                }
                this.Invoke(new MethodInvoker(delegate()
                {

                    Export2Excel(dataGridView1, saveFileDialog1.FileName);

                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 导出到Excel
        /// <summary>
        /// 初始化一个工作薄
        /// </summary>
        /// <param name="path">工作薄的路径</param>
        /// 
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        public void Export2Excel(DataGridView gridView, string fileName)
        {
            System.Reflection.Missing miss = System.Reflection.Missing.Value; //创建EXCEL对象appExcel,Workbook对象,Worksheet对象,Range对象
            Microsoft.Office.Interop.Excel.Application appExcel;
            appExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookData;
            Microsoft.Office.Interop.Excel.Worksheet worksheetData;
            Microsoft.Office.Interop.Excel.Range rangedata; //设置对象不可见
            appExcel.Visible = false;
            /* 在调用Excel应用程序，或创建Excel工作簿之前，记着加上下面的两行代码 * 这是因为Excel有一个Bug，如果你的操作系统的环境不是英文的，而Excel就会在执行下面的代码时，报异常。 */
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture; System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            workbookData = appExcel.Workbooks.Add(miss);
            worksheetData = (Microsoft.Office.Interop.Excel.Worksheet)workbookData.Worksheets.Add(miss, miss, miss, miss); //给工作表赋名称
            worksheetData.Name = "UACS"; //清零计数并开始计数

            for (int i = 0; i < gridView.ColumnCount; i++)
            {
                worksheetData.Cells[1, i + 1] = gridView.Columns[i].HeaderText.ToString();
            } //先给Range对象一个范围为A2开始，Range对象可以给一个CELL的范围，也可以给例如A1到H10这样的范围 //因为第一行已经写了表头，所以所有数据都应该从A2开始
            rangedata = worksheetData.get_Range("A2", miss);
            Microsoft.Office.Interop.Excel.Range xlRang = null; //iRowCount为实际行数，最大行
            int iRowCount = gridView.RowCount;
            int iParstedRow = 0,
            iCurrSize = 0; //iEachSize为每次写行的数值，可以自己设置，每次写1000行和每次写2000行大家可以自己测试下效率
            int iEachSize = 1000; //iColumnAccount为实际列数，最大列数
            int iColumnAccount = gridView.ColumnCount; //在内存中声明一个iEachSize×iColumnAccount的数组，iEachSize是每次最大存　　储的行数，iColumnAccount就是存储的实际列数
            object[,] objVal = new object[iEachSize, iColumnAccount];
            try
            {

                iCurrSize = iEachSize;
                while (iParstedRow < iRowCount)
                {
                    if ((iRowCount - iParstedRow) < iEachSize)
                        iCurrSize = iRowCount - iParstedRow; //用FOR循环给数组赋值
                    for (int i = 0; i < iCurrSize; i++)
                    {
                        for (int j = 0; j < iColumnAccount; j++)
                            objVal[i, j] = gridView[j, i + iParstedRow].Value.ToString();

                        System.Windows.Forms.Application.DoEvents();
                    }
                    xlRang = worksheetData.get_Range("A" + ((int)(iParstedRow + 2)).ToString(), ((char)('A' + iColumnAccount - 1)).ToString() + ((int)(iParstedRow + iCurrSize + 1)).ToString()); // 调用Range的Value2属性，把内存中的值赋给Excel
                    xlRang.Value2 = objVal;
                    iParstedRow = iParstedRow + iCurrSize;
                } //保存工作表
                worksheetData.SaveAs(fileName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss); System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRang);
                xlRang = null;
                //关闭EXCEL进程，大家可以试下不用的话如果程序不关闭在进程里一直会有EXCEL.EXE这个进程并锁定你的EXCEL表格

                if (appExcel != null)
                {

                    int lpdwProcessId;
                    GetWindowThreadProcessId(new IntPtr(appExcel.Hwnd), out lpdwProcessId);
                    System.Diagnostics.Process.GetProcessById(lpdwProcessId).Kill();

                }

                MessageBox.Show("数据已经成功导出到：" + fileName, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion


    }
}
