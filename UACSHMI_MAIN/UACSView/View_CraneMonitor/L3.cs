using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.Common;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HMI_OF_REPOSITORIES
{
    public partial class L3 : FormBase
    {
        public L3()
        {
            InitializeComponent();

            Type dgvL3Type = this.dgvL3.GetType();
            PropertyInfo pi = dgvL3Type.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvL3, true, null);

            this.dgvL3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;

        }

        #region 连接数据库
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

        DataTable dt;

        /// <summary>
        /// 按照日期和跨别查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                dt = new DataTable();
                bool all = this.radioButton1.Checked;
                bool A = this.radioButton2.Checked;
                bool B = this.radioButton3.Checked;

                string recTime1;
                string recTime2;
                if (cmbShift.Text.Trim() == "全部")
                {
                    recTime1 = this.dtp1.Value.ToString("yyyyMMdd080000");
                    recTime2 = this.dtp2.Value.AddDays(1).ToString("yyyyMMdd080000");
                }
                else if (cmbShift.Text.Trim() == "早班")
                {
                    recTime1 = this.dtp1.Value.ToString("yyyyMMdd080000");
                    recTime2 = this.dtp1.Value.ToString("yyyyMMdd200000");
                }
                else if (cmbShift.Text.Trim() == "晚班")
                {
                    recTime1 = this.dtp1.Value.ToString("yyyyMMdd200000");
                    recTime2 = this.dtp1.Value.AddDays(1).ToString("yyyyMMdd080000");
                }
                else
                {
                    MessageBox.Show("班次错误");
                    return;
                }
               // string  recTime1 = this.dtp1.Value.ToString("yyyyMMdd000000");
               // string  recTime2 = this.dtp2.Value.ToString("yyyyMMdd235959");

                //string sqlTime = @"select P.MAT_NO as 钢卷号, P.STOCK_NO as 鞍座号, P.RES_FLAG as 判定状态 , P.MESSAGE as 信息 ,L.TIME as 时间  from UACS_L3_IN_STOCK L , UACS_PLAN_MATINSTOCK_ACK P 
                                            // where L.COIL_NO=P.MAT_NO and L.STOCK_NO=P.STOCK_NO and
                                            // L.TIME >='{0}'and L.TIME <='{1}' and P.RES_FLAG=1  and P.MAT_NO not in 
                                             //(select P.MAT_NO from UACS_L3_IN_STOCK L, UACS_PLAN_MATINSTOCK_ACK P where L.COIL_NO = P.MAT_NO and L.STOCK_NO = P.STOCK_NO
                                            // and L.TIME >= '{2}' and L.TIME <= '{3}'
                                            // and P.RES_FLAG = 0)";
              
                    //  select* from UACS_L3_IN_STOCK L, UACS_PLAN_MATINSTOCK_ACK P
                    //   where L.COIL_NO = P.MAT_NO and L.STOCK_NO = P.STOCK_NO
                    //and L.TIME < '2019-06-12 10:00:00' and L.TIME > '2019-06-12 0:00:00'
                    //and P.RES_FLAG = 1 and P.MAT_NO not in 
                    //(select P.MAT_NO from UACS_L3_IN_STOCK L, UACS_PLAN_MATINSTOCK_ACK P where L.COIL_NO = P.MAT_NO and L.STOCK_NO = P.STOCK_NO
                    //and L.TIME < '2019-06-12 10:00:00' and L.TIME > '2019-06-12 0:00:00'
                    //and P.RES_FLAG = 0)

//                string sqlTime = @"select ROW_NUMBER() OVER() AS 序号 ,P.MAT_NO as 材料号, P.STOCK_NO as 库位号, C.WIDTH as 宽度,C.WEIGHT as 重量,C.PACK_CODE as 包装代码, P.RES_FLAG as 判定状态 ,L.TIME as 时间,P.EQU_NO as 操作者, P.MESSAGE as 异常报错信息  
//                                     from UACS_L3_IN_STOCK L left join UACS_PLAN_MATINSTOCK_ACK P on  L.COIL_NO=P.MAT_NO and L.STOCK_NO=P.STOCK_NO   left join UACS_YARDMAP_COIL C on  P.MAT_NO = C.COIL_NO
//                                     where L.TIME >='{0}'and L.TIME <='{1}' ";
                string sqlTime = @"select ROW_NUMBER() OVER() AS 序号 ,P.MAT_NO as 材料号, C.WIDTH as 宽度,C.WEIGHT as 重量,C.PACK_CODE as 包装代码, P.ACK_FLAG as 判定状态 ,P.REC_TIME as 时间, P.MESSAGE as 异常报错信息  
                                     from  UACS_PLAN_CRANPLAN_OPERACK P left join UACS_YARDMAP_COIL C on  P.MAT_NO = C.COIL_NO
                                     where  P.REC_TIME >='{0}'and P.REC_TIME <='{1}' ";

                sqlTime = string.Format(sqlTime,recTime1, recTime2, recTime1, recTime2);
                if (all == false && A == false && B == false)
                {
                    sqlTime = string.Format(sqlTime);
                    //dtData(dt);
                 //   return;
                }
                else if (all == true)
                {
                    sqlTime = string.Format(sqlTime);
                    // dtData(dt);
                    //  return;
                }
                else if (A == true)
                {
                    //sqlTime = string.Format("{0} and L.STOCK_NO like '{1}%' or L.STOCK_NO like '{2}%'", sqlTime, "Z02", "Z03");
                }
                else if (B == true)
                {
                    //sqlTime = string.Format("{0} and L.STOCK_NO like '{1}%' OR L.STOCK_NO like '{2}%'", sqlTime, "Z04", "Z05");
                }
                //else if (Z53 == true)
                //{
                //    sqlTime = string.Format("{0} and P.STOCK_NO like '{1}%'", sqlTime, "Z53");
                //}
                //if (checkBox1.Checked)
                //    sqlTime = string.Format("{0} and P.EQU_NO like '{1}%'", sqlTime, "AUTO");

                sqlTime += " order by P.REC_TIME ASC" ;//order by 字段名 desc倒叙
                DataTable dt_T = new DataTable();

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTime))
                {
                    dt_T.Load(rdr);
                }
                dgvL3.DataSource = dt_T;

                //ShiftInStockStatus();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
        }

        private void ShiftInStockStatus()
        {
            try
            {
                //自动入库件数
                double autoNum = 0;
                double manuNum = 0;
                double num = 0;    // 总数
                for (int i = 0; i < dgvL3.RowCount; i++)
                {
                    if (dgvL3.Rows[i].Cells["判定状态"].Value != DBNull.Value && dgvL3.Rows[i].Cells["操作者"].Value != DBNull.Value)
                    {
                        if (dgvL3.Rows[i].Cells["判定状态"].Value.ToString() == "0")
                        {
                            dgvL3.Rows[i].Cells["异常报错信息"].Value = "入库成功";
                        }
                       
                        num++;
                        //自动入库成功
                        if (dgvL3.Rows[i].Cells["判定状态"].Value.ToString() == "0" && dgvL3.Rows[i].Cells["操作者"].Value.ToString() == "AUTO")
                        {
                            autoNum++;
                        }
                        //手动入库成功
                        if (dgvL3.Rows[i].Cells["判定状态"].Value.ToString() == "0" && dgvL3.Rows[i].Cells["操作者"].Value.ToString() != "AUTO")
                        {
                            manuNum++;
                        }
                    }                
                }

                lblautoInStockNum.Text = autoNum.ToString();
                lblmanuInStockNum.Text = manuNum.ToString();
                lblerrrorNum.Text = (num - autoNum - manuNum).ToString();
                string aaa = ((autoNum / num) * 100).ToString();
                if (aaa.Length >= 4)
                {
                    lblAuto.Text = aaa.Substring(0, 4) + "%";
                }
                else if (aaa.Length == 3 || aaa.Length == 2  || aaa.Length == 1)
                {
                    lblAuto.Text = aaa + "%";
                }
                else
                {
                    lblAuto.Text = "999";
                }

                


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }        
        }


        ///// <summary>
        ///// 当单选按钮选中All后者都不点时 查全部
        ///// </summary>
        ///// <param name="dt"></param>
        //private void dtData(DataTable dt)
        //{
        //    dt.Columns.Add("CRANE_NO", typeof(String));
        //    dt.Columns.Add("STOCK_NO", typeof(String));
        //    dt.Columns.Add("RES_FLAG", typeof(String));
        //    dt.Columns.Add("MESSAGE", typeof(String));
        //}

        /// <summary>
        /// 按照钢卷号模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try {
//                string sqlCOIL_NO = @"select  P.MAT_NO as 钢卷号, P.STOCK_NO as 鞍座号, P.RES_FLAG as 判定状态 ,P.EQU_NO as 操作者, P.MESSAGE as 信息  from  UACS_PLAN_MATINSTOCK_ACK P 
//                                               where  P.MAT_NO = '" +textBox1.Text.Trim()+"'";
                string sqlCOIL_NO = @"select ROW_NUMBER() OVER() AS 序号 ,MAT_NO as 钢卷号,  ACK_FLAG as 判定状态 , MESSAGE as 信息  from  UACS_PLAN_CRANPLAN_OPERACK  where  MAT_NO = '" + textBox1.Text.Trim() + "'";
            DataTable dt_NO = new DataTable();

            using (IDataReader rdr = DBHelper.ExecuteReader(sqlCOIL_NO))
            {
                dt_NO.Load(rdr);
            }
            dgvL3.DataSource = dt_NO;
            }
            catch 
            {
                MessageBox.Show("请输入正确的钢卷号!");
            }

            lblAuto.Text = "999";
            lblautoInStockNum.Text = "999";
            lblerrrorNum.Text = "999";
            lblmanuInStockNum.Text = "999";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();

                this.Invoke(new MethodInvoker(delegate()
                {

                    Export2Excel(dgvL3, saveFileDialog1.FileName);

                }));
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
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
