using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSPopupForm
{
    public partial class PopAlarmCurrent : Form
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();       

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();       

        private string[] arrTagAdress;
        private string[] arrTagAdress1;

        private string crane_No = null;

        private string TagName = null;
        private string TagName1 = null;
        private string TagName2 = null;

        /// <summary>
        /// 存解析出来的报警代码
        /// </summary>
        private List<int> listAlarm = new List<int>();
        private List<int> listAlarm1 = new List<int>();
        private List<int> listAlarm2 = new List<int>();
        /// <summary>
        /// 行车号
        /// </summary>
        public string Crane_No
        {
            get { return crane_No; }
            set
            {
                crane_No = value;
            }
        }

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
                        //throw e;
                    }

                }
                return dbHelper;
            }
        }

        public void InitTagDataProvide(string tagServiceName)
        {
            try
            {
                tagDataProvider.ServiceName = tagServiceName;
            }
            catch (Exception ex)
            {
            }
        }
        
        public PopAlarmCurrent()
        {
            InitializeComponent();
            this.Load += PopAlarmCurrent_Load;
        }

        void PopAlarmCurrent_Load(object sender, EventArgs e)
        {
            if (Crane_No != null)
            {
                tagDataProvider.ServiceName = "iplature";         
                TagName = Crane_No + "_ALARM_CURRENT";
                TagName1 = Crane_No + "_fangyao_alarm_list";
                TagName2 = Crane_No + "_WMS_ALARM_CURRENT";
                lblCraneNo.Text = Crane_No + " 报警";

                List<string> lstAdress = new List<string>();
                lstAdress.Add(TagName);
                lstAdress.Add(TagName1);
                lstAdress.Add(TagName2);
                arrTagAdress = lstAdress.ToArray<string>();              
                readTags();               

                string value = get_value_string(TagName).Trim();               
                string[] sArray = value.Split(',');
                listAlarm.Clear();
                foreach (string i in sArray)
                {
                    if (String.IsNullOrEmpty(value.Trim()))
                    {                      
                        break;
                    }
                    int values = Convert.ToInt32(i.ToString());
                    listAlarm.Add(values);
                }
                GetDgvMessage(listAlarm,dataGridView1);


                string value1 = get_value_string(TagName1).Trim();               
                string[] sArray1 = value1.Split(',');
                listAlarm1.Clear();
                foreach (string i in sArray1)
                {
                    if (value1.Trim() == "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0")
                    {                      
                        break;
                    }
                    int values = Convert.ToInt32(i.ToString());
                    listAlarm1.Add(values);
                }               
                GetDgvMessage1(listAlarm1);

                string value2 = get_value_string(TagName2).Trim();                
                string[] sArray2 = value2.Split(',');
                listAlarm2.Clear();
                foreach (string i in sArray2)
                {
                    if (String.IsNullOrEmpty(value2.Trim()))
                    {
                        break;
                    }
                    int values = Convert.ToInt32(i.ToString());
                    listAlarm2.Add(values);
                }
                GetDgvMessage(listAlarm2,dataGridView3);


                if(dataGridView1.Rows.Count != 0)
                {
                    this.tabControl1.SelectedTab = this.tabPage1;
                }
                else if (dataGridView2.Rows.Count != 0)
                {
                    this.tabControl1.SelectedTab = this.tabPage2;
                }
                else
                {
                    this.tabControl1.SelectedTab = this.tabPage3;
                }
            }
            
        }


        private void GetDgvMessage(List<int> list,DataGridView datagridview)
        {
            DataTable dt = new DataTable();
            bool hasSetColumn = false;

            try
            {
               
                string sql = @"SELECT * FROM UACS_CRANE_ALARM_CODE_DEFINE ";
                sql += " WHERE ALARM_CODE IN (";
                foreach (int item in list)
                {
                    sql += "" + item + ",";
                }
                sql = sql.Substring(0,sql.Length -1);
                sql += ");";

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
                if (hasSetColumn == false)
                {
                    dt.Columns.Add("ALARM_CODE", typeof(String));
                    dt.Columns.Add("ALARM_INFO", typeof(String));
                    dt.Columns.Add("ALARM_CLASS", typeof(String));
                }

            }
            catch (Exception er)
            {
                
            }

            datagridview.DataSource = dt;
        }

        private void GetDgvMessage1(List<int> list)
        {
            DataTable dt = new DataTable();
            bool hasSetColumn = false;
            int alarmCode = 0;
            
            try
            {
                for(int i = 0; i < list.Count; i++)
                {
                    alarmCode += Convert.ToInt32(list[i] * Math.Pow(2, i));
                }
                string sql = @"SELECT * FROM UACS_CRANE_ALARM_CODE_DEFINE ";
                sql += " WHERE ALARM_CODE = " + alarmCode;               

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
                if (hasSetColumn == false)
                {
                    dt.Columns.Add("ALARM_CODE", typeof(String));
                    dt.Columns.Add("ALARM_INFO", typeof(String));
                    dt.Columns.Add("ALARM_CLASS", typeof(String));
                }

            }
            catch (Exception er)
            {

            }

            dataGridView2.DataSource = dt;
        }

        #region read tag

        public void SetReady(string tagName)
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Add(tagName);
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception er)
            {

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
      

        private string get_value_string(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString((valueObject));
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }
       
        #endregion
    
    }
}
