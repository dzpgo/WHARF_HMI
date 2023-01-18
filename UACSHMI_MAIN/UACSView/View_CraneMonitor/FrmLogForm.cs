using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
//using Baosight.ColdRolling.Utility;
//using Baosight.ColdRolling.LogicLayer;
//using Baosight.iSuperframe.TagService;
using Baosight.iSuperframe.Common;

namespace FORMS_OF_REPOSITORIES
{
    public partial class FrmLogForm : Baosight.iSuperframe.Forms.FormBase
    {
        bool isFalse = false;

        public FrmLogForm()
        {
            InitializeComponent();
        }

        private void MLogForm_Load(object sender, EventArgs e)
        {
            //dataGridView1.ColumnHeadersHeight = 35;
            //dataGridView1.RowTemplate.Height = 35;
            //dataGridView1.AllowUserToResizeRows = false;          //禁止用户改变DataGridView1所有行的行高
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   //居中
            //dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10, FontStyle.Regular);
            //GetFormLogData();
            //ParkClassLibrary.ManagerHelper.DataGridViewInit(dataGridView1);
            this.dateTimeStart.Value = DateTime.Now.Date;
            dateTimeEnd.Text = DateTime.Now.Date.AddDays(1).ToString();
            GetoLogsData(dateTimeStart.Value, dateTimeEnd.Value, "", "");
            this.BackColor = Color.LightSteelBlue;
            Bind_cbxKey1(cbxKey1);       
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetoLogsData(dateTimeStart.Value, dateTimeEnd.Value, cbxKey1.Text.Trim(), "");
        }
        private void GetoLogsData(DateTime start, DateTime end, string key1, string info)
        {
            string strStart = start.ToString("yyyy-MM-dd HH:mm:ss");
            string strEnd = end.ToString("yyyy-MM-dd HH:mm:ss");
            DataTable dt = new DataTable();
            try
            {
                string sql = @"SELECT ROW_NUMBER() OVER() as ROW_INDEX , SEQNO, KEY1, KEY2, LEVEL, INFO, MODULE,CASE
                   WHEN USERID LIKE '%221%' THEN '现场调试电脑（221）'                   
                   ELSE USERID
                END as USERID,TOC FROM UACS_HMI_LOG   WHERE 1 = 1  ";
                sql += " AND TOC  > '" + strStart + "' and TOC <'" + strEnd + "'";

                if (key1 != "" && key1 != "全部")
                {
                    sql += " AND KEY1 = '" + key1 + "' ";
                }
                if (info != "" && info != "全部")
                {
                    sql += " AND INFO LIKE  '%" + info + "%' ";
                }
                if (cmbLevelId.Text.Contains("出错信息"))
                {
                    sql += " AND LEVEL = '" + 3 + "' ";
                }
                else if (cmbLevelId.Text.Contains("普通警告"))
                {
                    sql += " AND LEVEL = '" + 2 + "' ";
                }
                else if (cmbLevelId.Text.Contains("普通信息"))
                {
                    sql += " AND LEVEL = '" + 1 + "' ";
                }
                sql += " ORDER BY TOC DESC ";
                dt.Clear();
                dt = new DataTable();

                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    dt.Load(rdr);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void Bind_cbxKey1(ComboBox cbxKey1)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            dt.Rows.Add("全部", "全部");
            try
            {
                string sqlText = @"SELECT DISTINCT KEY1 as TypeValue FROM UACS_HMI_LOG";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["TypeValue"];                      
                        dt.Rows.Add(dr);                    
                    }
                }               
                //绑定列表下拉框数据             
                cbxKey1.DataSource = dt;
                cbxKey1.DisplayMember = "TypeValue";
                cbxKey1.ValueMember = "TypeValue";
                cbxKey1.SelectedItem = 0;
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
    }
}
