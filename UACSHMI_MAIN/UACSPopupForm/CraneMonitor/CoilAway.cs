using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Baosight.iSuperframe.Forms;

namespace UACSPopupForm
{
    public partial class CoilAway : Form
    {
        public string saddleNO = string.Empty;
        public string saddleno
        {
            get { return saddleNO; }
            set { saddleno = value; }
        }

        public string coilNO = string.Empty;
        public string coilno
        {
            get { return coilNO; }
            set { coilno = value; }
        }
        private string coilFlag = string.Empty;
        public string CoilFlag
        {
            get { return coilFlag; }
            set { coilFlag = value; }
        }
        public CoilAway()
        {
            InitializeComponent();
        }

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要吊离吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.Cancel)
            {
                return;
            }
            if (txtCoilNO.Text == "")
            {
                MessageBox.Show("请输入卷号！");
            }
            else
            {
                string sqlText = @"select * from UACS_YARDMAP_STOCK_DEFINE where STOCK_NO = '" + txtSaddle.Text +"'";
                using(IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while(rdr.Read())
                    {
                        if(Convert.ToInt32(rdr["STOCK_STATUS"].ToString()) != 2 ||Convert.ToInt32(rdr["LOCK_FLAG"].ToString()) != 0 || (rdr["MAT_NO"].ToString() == ""))
                        {
                            string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 2, LOCK_FLAG = 0 , MAT_NO = '" + txtCoilNO.Text + "'WHERE STOCK_NO = '" + txtSaddle.Text + "'";
                            DBHelper.ExecuteNonQuery(sql);
                        }
                        string sql1;
                        if (coilFlag == "CB")
                        {
                            sql1 = @"UPDATE UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE SET CONFIRM_FLAG = 130,COIL_NO = '" + txtCoilNO.Text + "' WHERE STOCK_NO = '" + txtSaddle.Text + "'";
                        }
                        else
                        {
                            sql1 = @"UPDATE UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE SET CONFIRM_FLAG = 30,COIL_NO = '" + txtCoilNO.Text + "' WHERE STOCK_NO = '" + txtSaddle.Text + "'";
                        }
                        //string sql1 = @"UPDATE UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE SET CONFIRM_FLAG = 30,COIL_NO = '" + txtCoilNO.Text +"' WHERE STOCK_NO = '" + txtSaddle.Text + "'";
                        DBHelper.ExecuteNonQuery(sql1);
                        MessageBox.Show("确认吊离成功！");
                        this.Close();
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CoilAway_Load(object sender, EventArgs e)
        {
            txtSaddle.Text = saddleno;
            txtCoilNO.Text = coilno;
        }
    }
}
