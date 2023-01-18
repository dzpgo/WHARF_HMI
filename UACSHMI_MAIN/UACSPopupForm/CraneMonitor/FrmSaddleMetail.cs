using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
using ParkClassLibrary;

namespace UACSPopupForm
{
    public partial class FrmSaddleMetail : Form
    {
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;

        private SaddleBase saddleInfo = new SaddleBase();

        public SaddleBase SaddleInfo
        {
            get { return saddleInfo; }
            set { saddleInfo = value; }
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

        private const string strPassWord = "123123";

        public FrmSaddleMetail()
        {
            InitializeComponent();
            this.Load += FrmSaddleMetail_Load;
        }

        void FrmSaddleMetail_Load(object sender, EventArgs e)
        {
            auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
            this.Deactivate += new EventHandler(frmSaddleDetail_Deactivate);
            txtSaddleNo.Text = saddleInfo.SaddleNo;
            txtSaddleName.Text = saddleInfo.SaddleName;
            txtCoilNo.Text = saddleInfo.Mat_No;
            txtXCenter.Text = saddleInfo.X_Center.ToString();
            txtYCenter.Text = saddleInfo.Y_Center.ToString();
            txtZCenter.Text = saddleInfo.Z_Center.ToString();
            label6.Text = saddleInfo.Row_No.ToString() + "-" + saddleInfo.Col_No.ToString();
            txtThick.Text = saddleInfo.Thick;
            txtAddress.Text = saddleInfo.Addres;
            txtStrap.Text = saddleInfo.Strap;

            #region 转换状态（垃圾）
            switch (saddleInfo.Stock_Status)
            {
                case 0:
                    txtStatus.Text = "无卷";
                    break;
                case 1:
                    txtStatus.Text = "预定";
                    break;
                case 2:
                    txtStatus.Text = "占用";
                    break;
                default:
                    txtStatus.Text = "无";
                    break;
            }
            switch (saddleInfo.Lock_Flag)
            {
                case 0:
                    txtflag.Text = "可用";
                    break;
                case 1:
                    txtflag.Text = "待判";
                    break;
                case 2:
                    txtflag.Text = "封锁";
                    break;
                default:
                    txtflag.Text = "无";
                    break;
            }
            #endregion

            AuthorityManagement authority = new AuthorityManagement();
            if (authority.isUserJudgeEqual("D308", "D202", "scal", "D212"))
            {
                btnCoilMessage.Visible = false;
                txtMatNo.Visible = false;
                btnUpStockByCoil.Visible = false;
                btnByNoCoil.Visible = false;
                btnByReserve.Visible = false;
                btnByOccupy.Visible = false;
                btnNoCoilByUsable.Visible = false;
                btnByUsable.Visible = false;
                btnByStay.Visible = false;
                btnByBlock.Visible = false;
                label7.Visible = false;
                txtPassWord.Visible = false;
                txtPopupMessage.Visible = false;
            }

        }

        void frmSaddleDetail_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 更新钢卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpStockByCoil_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string coilNo = txtMatNo.Text.Trim();
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET MAT_NO = '" + coilNo + "',STOCK_STATUS = 2,LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "已添加钢卷" + coilNo;
                    ParkClassLibrary.HMILogger.WriteLog(btnUpStockByCoil.Text, "鞍座：" + saddleInfo.SaddleNo + "设置钢卷号为：" + coilNo, ParkClassLibrary.LogLevel.Info, this.Text);
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位无卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByNoCoil_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已无卷";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位预定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 1,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已预定";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位占用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByOccupy_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 2,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "状态已占用";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";

            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位可用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByUsable_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);                    
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已可用";
                    ParkClassLibrary.HMILogger.WriteLog(btnByUsable.Text, "鞍座：" + saddleInfo.SaddleNo + "设为库位可用", ParkClassLibrary.LogLevel.Info, this.Text);
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";
            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }

        /// <summary>
        /// 库位待判
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByStay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 1,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已待判";
                    ParkClassLibrary.HMILogger.WriteLog(btnByStay.Text, "鞍座：" + saddleInfo.SaddleNo + "设为库位待判", ParkClassLibrary.LogLevel.Info, this.Text);
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";

            }
            catch (Exception er)
            {

                txtPopupMessage.Text = er.Message;
            }
        }
        /// <summary>
        /// 库位封锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnByBlock_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET LOCK_FLAG = 2,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "标记已封锁";
                    ParkClassLibrary.HMILogger.WriteLog(btnByBlock.Text, "鞍座：" + saddleInfo.SaddleNo + "设为库位封锁", ParkClassLibrary.LogLevel.Info, this.Text);
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";

            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }
        }

        private void btnNoCoilByUsable_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text == strPassWord)
                {
                    string coilNo = txtMatNo.Text.Trim();
                    string sql = @"UPDATE UACS_YARDMAP_STOCK_DEFINE SET MAT_NO = NULL,STOCK_STATUS = 0,LOCK_FLAG = 0,EVENT_ID= 888888 WHERE STOCK_NO = '" + saddleInfo.SaddleNo + "' ";
                    DBHelper.ExecuteNonQuery(sql);
                    txtPopupMessage.Text = "库位" + saddleInfo.SaddleNo + "已无卷可用";
                }
                else
                    txtPopupMessage.Text = "输入密码错误！！！";


            }
            catch (Exception er)
            {
                txtPopupMessage.Text = er.Message;
            }

        }

        private string strCoil = string.Empty;
        private void btnCoilMessage_Click(object sender, EventArgs e)
        {


            strCoil = txtCoilNo.Text.Trim().ToString();

            if (auth.IsOpen("03 钢卷信息"))
            {
                auth.CloseForm("03 钢卷信息");

                if (strCoil.Count() > 0)
                {
                    auth.OpenForm("03 钢卷信息", strCoil);
                }
                else
                    auth.OpenForm("03 钢卷信息");
            }
            else
            {
                if (strCoil.Count() > 0)
                {
                    auth.OpenForm("03 钢卷信息", strCoil);
                }
                else
                    auth.OpenForm("03 钢卷信息");
            }

        }

        private void btnCoilPlastic_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                if (txtCoilNo.Text.Trim() != "")
                {
                    //if (!(MessageBox.Show("确定要将该钢卷改成套袋状态吗？", "套袋提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    //{
                    //    return;
                    //}
                    string coilNo = txtCoilNo.Text.Trim();
                    string sql1 = "select * from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '" + coilNo + "'";

                    using (IDataReader rdr = DBHelper.ExecuteReader(sql1))
                    {
                        while (rdr.Read())
                        {
                            flag = true;
                            string sql2 = @"UPDATE UACS_YARDMAP_COIL_PLASTIC SET PLASTIC_FLAG = 1,PLASTIC_TIME = current timestamp  WHERE COIL_NO = '" + coilNo + "' ";
                            DBHelper.ExecuteNonQuery(sql2);
                        }
                    }
                    if (!flag)
                    {
                        string sql2 = @"insert into UACS_YARDMAP_COIL_PLASTIC(COIL_NO,PLASTIC_FLAG,PLASTIC_TIME)  values ( '" + coilNo + "',1,current timestamp )";
                        DBHelper.ExecuteNonQuery(sql2);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnNoCoilPlastic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCoilNo.Text.Trim() != "")
                {
                    //if (!(MessageBox.Show("确定要将该钢卷改成无套袋状态吗？", "套袋提示", MessageBoxButtons.OKCancel) == DialogResult.OK))
                    //{
                    //    return;
                    //}
                    string coilNo = txtCoilNo.Text.Trim();
                    string sql1 = "select * from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '" + coilNo + "'";

                    using (IDataReader rdr = DBHelper.ExecuteReader(sql1))
                    {
                        while (rdr.Read())
                        {
                            string sql2 = @"UPDATE UACS_YARDMAP_COIL_PLASTIC SET PLASTIC_FLAG = 0,PLASTIC_TIME = current timestamp  WHERE COIL_NO = '" + coilNo + "' ";
                            DBHelper.ExecuteNonQuery(sql2);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
