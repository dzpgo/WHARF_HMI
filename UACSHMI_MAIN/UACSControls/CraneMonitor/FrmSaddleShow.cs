
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;

namespace UACSControls
{
    public partial class FrmSaddleShow : Form
    {
        public FrmSaddleShow()
        {
            InitializeComponent();
            this.Load += FrmSaddleShow_Load;
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
        private AreaBase areaBase = new AreaBase();
        public AreaBase AreaBase
        {
            get { return areaBase; }
            set { areaBase = value; }
        }
        conStockSaddleModel stockSaddleModel = null;



        void FrmSaddleShow_Load(object sender, EventArgs e)
        {
            //窗体固定大小
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            lblArea.Text = areaBase.AreaNo + "库位详细信息";
            if (areaBase.AreaNo == "Z02-F")
            {
                btnKillStock.Visible = true;
                btnResetStock.Visible = true;
            }
            this.Shown += FrmSaddleShow_Shown;
            //GDIPant();

        }

        void FrmSaddleShow_Shown(object sender, EventArgs e)
        {
            stockSaddleModel = new conStockSaddleModel();
            if (areaBase.AreaNo.Contains("FIA"))
            {
                stockSaddleModel.conInit(panel2, areaBase, constData.tagServiceName, panel2.Width, panel2.Height, constData.xAxisRight, constData.yAxisDown, 999);
            }
            else
            {
                stockSaddleModel.conInit(panel2, areaBase, constData.tagServiceName, panel2.Width, panel2.Height, constData.xAxisRight, constData.yBxisDown, 999);
            }
            

        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdata_Click(object sender, EventArgs e)
        {
            if (areaBase.AreaNo.Contains("FIA"))
            {
                stockSaddleModel.conInit(panel2, areaBase, constData.tagServiceName, panel2.Width, panel2.Height, constData.xAxisRight, constData.yAxisDown, 800);
            }
            else
            {
                stockSaddleModel.conInit(panel2, areaBase, constData.tagServiceName, panel2.Width, panel2.Height, constData.xAxisRight, constData.yBxisDown, 800);
            }
        }

        private void btnKillStock_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要全部杀红小尾卷鞍座吗？", "操作提示", btn);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 1, EVENT_ID = 888888 WHERE LOCK_FLAG != 2 AND STOCK_NO IN(SELECT SADDLE_NO FROM UACS_YARDMAP_SADDLE_DEFINE WHERE COL_ROW_NO LIKE '%" + areaBase.AreaNo + "%')";
                DBHelper.ExecuteNonQuery(sql);
                ParkClassLibrary.HMILogger.WriteLog("全部杀红", "全部杀红：" + areaBase.AreaNo, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        private void btnResetStock_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要全部放白小尾卷鞍座吗？", "操作提示", btn);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,LOCK_FLAG = 0,MAT_NO = NULL,EVENT_ID= 888888 WHERE LOCK_FLAG != 2 AND STOCK_NO IN(SELECT SADDLE_NO FROM UACS_YARDMAP_SADDLE_DEFINE WHERE COL_ROW_NO LIKE '%" + areaBase.AreaNo + "%')";
                DBHelper.ExecuteNonQuery(sql);
                ParkClassLibrary.HMILogger.WriteLog("全部放白", "全部放白：" + areaBase.AreaNo, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }

        //画图对象
        //Graphics g;
        //private void GDIPant()
        //{
        //    g = panelSaddle.CreateGraphics();
        //    Pen p = new Pen(Color.Blue, 2);
        //    //画竖坐标线

        //    g.DrawLine(p, 40, 0, 40, panelSaddle.Height);

        //    g.DrawLine(p, panelSaddle.Width - 40, 0, panelSaddle.Width - 40, panelSaddle.Height);
        //    //画横坐标线
        //    g.DrawLine(p, 0, 30, panelSaddle.Width, 30);

        //    g.DrawLine(p, 0, panelSaddle.Height - 30, panelSaddle.Width, panelSaddle.Height - 30);

        //    Pen pen = new Pen(Color.FromArgb(255, 0, 0), 5);
        //    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;//虚线的样式
        //    pen.DashPattern = new float[] { 2, 2 };//设置虚线中实点和空白区域之间的间隔
        //    g.DrawLine(pen, 0, 0, 0, 0);
        //}


    }
}
