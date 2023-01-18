﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.ColdRolling.TcmControls;
using UACSPopupForm;

namespace UACS
{
    public partial class CoilPicture : UserControl
    {
        /// <summary>
        /// 钢卷标记，0和-1灰色  1-5有颜色 其他无卷
        /// </summary>
       public int CoilStatus
        {
            get { return skidControl.CoilStatus; }
            set { skidControl.CoilStatus=value; }
        }
        /// <summary>
        /// 鞍座名
        /// </summary>
        public string SkidName
        {
            get { return skidControl.Name; }
            set { skidControl.Name = value; }
        } 
        /// <summary>
        /// 卷号，显示在框中
        /// </summary>
        public string CoilId
        {
            get { return skidControl.CoilIdText; }
            set { skidControl.CoilIdText = value; }
        }
        /// <summary>
        /// 显示的位置名称
        /// </summary>
        public string PosName
        {
            get { return skidControl.PosName; }
            set { skidControl.PosName = value; }
        }
        /// <summary>
        /// 位置号，编程使用
        /// </summary>
        public int PosNo
        {
            get { return skidControl.PosNo; }
            set { skidControl.PosNo = value; }
        }
        /// <summary>
        /// 字体
        /// </summary>
        public Font TextFont
        {
            get { return skidControl.TextFont; }
            set { skidControl.TextFont = value; }
        }
        /// <summary>
        /// 控件方向,默认水平布局 （ Baosight.ColdRolling.TcmControl.Direct）
        /// </summary>
        public Baosight.ColdRolling.TcmControl.Direct Director
        {
            get { return skidControl.Director; }
            set { skidControl.Director = value; }
        }

        /// <summary>
        /// 上按钮
        /// </summary>
        public bool UpEnable
        {
            get { return skidControl.UpEnable; }
            set { skidControl.UpEnable = value; }
        }
        public bool UpVisiable
        {
            get { return skidControl.UpVisiable; }
            set { skidControl.UpVisiable = value; }
        }
        /// <summary>
        /// 下按钮
        /// </summary>
        public bool DownEnable
        {
            get { return skidControl.DownEnable; }
            set { skidControl.DownEnable = value; }
        }
        public bool DownVisiable
        {
            get { return skidControl.DownVisiable; }
            set { skidControl.DownVisiable = value; }
        }

     /// <summary>
     /// 尺寸大小
     /// </summary>
        public Size SkidSize
        {
            get { return skidControl.Size; }
            set { skidControl.Size = value; }
        }

        /// <summary>
        /// 卷号框背景色
        /// </summary>
        public Color CoilBackColor
        {
            get { return skidControl.PosBackColor; }
            set { skidControl.PosBackColor = value; }
        }
        /// <summary>
        /// 卷号框前景色
        /// </summary>
        public Color CoilFontColor
        {
            get { return skidControl.CoilFontColor; }
            set { skidControl.CoilFontColor = value; }
        }
        /// <summary>
        /// 钢卷号长度
        /// </summary>
        public int CoilLength
        {
            get { return skidControl.CoilLength; }
            set { skidControl.CoilLength = value; }
        }
        /// <summary>
        /// 上按钮图片
        /// </summary>
        public Image ButtonDImage
        {
            get { return skidControl.ButtonDImage; }
            set { skidControl.ButtonDImage = value; }
        }
        /// <summary>
        /// 下按钮图片
        /// </summary>
        public Image ButtonUImage
        {
            get { return skidControl.ButtonUImage; }
            set { skidControl.ButtonUImage = value; }
        }

        public CoilPicture()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            CoilPictureInit();
            Load += Init;
        }
         Baosight.ColdRolling.TcmControls.SkidControl skidControl = new Baosight.ColdRolling.TcmControls.SkidControl();
         protected override void WndProc(ref Message m)
         {

             if (m.Msg == 0x0014) // 禁掉清除背景消息

                 return;

             base.WndProc(ref m);

         }
         protected override CreateParams CreateParams
         {
             get
             {
                 var parms = base.CreateParams;
                 parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                 return parms;
             }
         }    
        private void Init(object sender, EventArgs e)
        {
            Controls.Add(skidControl);
        }
        void CoilPictureInit()
        {
            skidControl.Anchor = AnchorStyles.None;
            //skidControl.ButtonDImage=coilBtnImg.greenPoint;
            skidControl.ButtonUImage = UACSControls. Resource1.unlock;
            //unlock.Image = global::UACSControls.Properties.Resources._unlock;
         
            skidControl.Margin = new Padding(14, 9, 14, 9);
            skidControl.Size = new Size(215, 120);
            skidControl.TextFont = new Font("微软雅黑", 15f);
            skidControl.BtnClearVisiable = false;
            //  skidControl.ButtonDImage = 
            //skidControl.ButtonDImage = Image(resource);
            //skidControl.ButtonUImage = Resource.right;
            skidControl.CaptionMarginSpace = 2;
            skidControl.CheckType = Baosight.ColdRolling.TcmControl.CheckType.Status;
            skidControl.CoilBackColor = Color.White; 
            skidControl.CoilFontColor = Color.Black;
            skidControl.CoilLength = 16;
            skidControl.ColSub = Color.White;     //颜色设定
            skidControl.ColMain = Color.White; //卷颜色设定  
        
            skidControl.ColSch = Color.Gray;    //颜色设定 -1
            skidControl.ColLoad = Color.Black;  //颜色设定 0
            skidControl.ColConfirm = Color.OrangeRed;
            skidControl.ColBook = Color.Blue;
            
            skidControl.ColNoWeight = Color.LightYellow;
            skidControl.ColReject = Color.Green;
            skidControl.ColWeight = Color.LightGreen;
            skidControl.ColSend = Color.Red;
           
            skidControl.Director = Baosight.ColdRolling.TcmControl.Direct.Horizontal;
            skidControl.DownEnable = true;
            skidControl.DownVisiable = true;
            skidControl.InnerId = 0;
            skidControl.IRate = 0.9D;
            skidControl.IsVisiblePicture = false;
            skidControl.Name = "skidControl";
            skidControl.PosBackColor = Color.SkyBlue;
            skidControl.PosFontColor = Color.Black;
            skidControl.PosNo = 1;
            skidControl.poxImage = null;
            skidControl.RadiusInner = 8;
            skidControl.SkType = 0;
            skidControl.UpEnable = true;
            skidControl.UpVisiable = true;
            skidControl.MoveUpEvent += new EventHandler<ClickEventAgrs>(this.skidControl_MoveUpEvent);
            skidControl.MoveDownEvent += new EventHandler<ClickEventAgrs>(this.skidControl_MoveDownEvent);
        }
        
        public delegate void SkidEventHandl();
        /// <summary>
        /// 下按钮事件
        /// </summary>
        public event SkidEventHandl SkidDownEvent;
        /// <summary>
        /// 上按钮事件
        /// </summary>
        public event SkidEventHandl SkidUpEvent;
        //抛事件
        void skidControl_MoveUpEvent(object sr, ClickEventAgrs e)
        {
            if (SkidUpEvent != null)
            {
                SkidUpEvent();
            }
        }

        void skidControl_MoveDownEvent(object sr, ClickEventAgrs e)
        {
            if (SkidDownEvent != null)
                SkidDownEvent();
        }

        private string unit_no;

        public string Unit_no
        {
            get { return unit_no; }
            set { unit_no = value; }
        }

        private string saddle_no;

        public string Saddle_no
        {
            get { return saddle_no; }
            set { saddle_no = value; }
        }

        private string coil_Flag;

        public string Coil_Flag
        {
            get { return coil_Flag; }
            set { coil_Flag = value; }
        }
        //#region 刷新函数
        //public void ReInq(Dictionary<string, UACS.Saddle> dicSaddles)
        //{
        //    try
        //    {
        //        UACS.Saddle theSaddle = dicSaddles[Saddle_no];

        //        if (theSaddle.Saddle_no != null)
        //        {                  
        //            skidControl.CoilIdText = theSaddle.Coil_no.ToString();
        //        }
        //        else
        //        {
        //            skidControl.CoilIdText = "没有钢卷信息";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //#endregion


        #region 临时代码
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

        private UACS.SaddleMethod saddleMethod = new SaddleMethod();
        #endregion
        //封闭卷 
        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.CoilId.ToString().Trim() == "")
                {
                    MessageBox.Show("没有卷号，无法进行封闭操作");
                    return;
                }
                if (saddleMethod.isCoilVerifyFlag(this.CoilId.ToString().Substring(0, 11)))
                {
                    MessageBox.Show(this.CoilId.ToString().Substring(0, 11)+ "已验证，无法封闭");
                    return;
                }
               

                string sql = @" UPDATE UACS_YARDMAP_COIL SET FORBIDEN_FLAG = 1 WHERE COIL_NO = '"+ this.CoilId.ToString().Substring(0, 11) + "'";
                DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("卷号【"+ this.CoilId.ToString().Substring(0, 11) + "】已确定封闭");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CoilId.ToString().Trim() == "")
                {
                    MessageBox.Show("没有卷号，无法取消封闭操作");
                    return;
                }
                string sql = @" UPDATE UACS_YARDMAP_COIL SET FORBIDEN_FLAG = 0 WHERE COIL_NO = '" + this.CoilId.ToString().Substring(0, 11) + "'";
                DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("卷号【" + this.CoilId.ToString().Substring(0, 11) + "】已取消封闭");

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        //验证卷
        private void 确定ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            bool flag = false;
            try
            {
                if (this.CoilId.ToString().Trim() != "")
                {



                    string coilNo = this.CoilId.ToString().Trim().Substring(0,11) ;

                    if (saddleMethod.isCoilSealingFlag(coilNo))
                    {
                        MessageBox.Show(this.CoilId.ToString().Substring(0, 11) + "已封闭，无法验证");
                        return;
                    }

                    string sql1 = "select * from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '" + coilNo + "'";

                    using (IDataReader rdr = DBHelper.ExecuteReader(sql1))
                    {
                        while (rdr.Read())
                        {
                            flag = true;
                            int iflag = Convert.ToInt32( rdr["PLASTIC_FLAG"]);
                            if (iflag == 2) //套袋标记2   等于验证卷
                            {
                                MessageBox.Show("卷号【"+ coilNo + "】已为验证卷");
                            }
                            else
                            {
                                string sql2 = @"UPDATE UACS_YARDMAP_COIL_PLASTIC SET PLASTIC_FLAG = 2,PLASTIC_TIME = current timestamp  WHERE COIL_NO = '" + coilNo + "' ";
                                DBHelper.ExecuteNonQuery(sql2);
                                MessageBox.Show("卷号【" + coilNo + "】已修改为验证卷");
                            }    
                        }
                    }
                   
                    if (!flag)
                    {
                        string sql3 = @"insert into UACS_YARDMAP_COIL_PLASTIC(COIL_NO,PLASTIC_FLAG,PLASTIC_TIME)  values ( '" + coilNo + "',2,current timestamp )";
                        DBHelper.ExecuteNonQuery(sql3);
                        MessageBox.Show("卷号【" + coilNo + "】已添加为验证卷");
                    }

                }
                else
                {
                    MessageBox.Show("没有卷号，无法验证操作");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 取消ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                if (this.CoilId.ToString().Trim() != "")
                {
                    string coilNo = this.CoilId.ToString().Trim().Substring(0, 11);
                    string sql1 = "select * from UACS_YARDMAP_COIL_PLASTIC where COIL_NO = '" + coilNo + "'";

                    using (IDataReader rdr = DBHelper.ExecuteReader(sql1))
                    {
                        while (rdr.Read())
                        {
                            flag = true;
                            string sql2 = @"UPDATE UACS_YARDMAP_COIL_PLASTIC SET PLASTIC_FLAG = 0,PLASTIC_TIME = current timestamp  WHERE COIL_NO = '" + coilNo + "' ";
                            DBHelper.ExecuteNonQuery(sql2);
                            MessageBox.Show("卷号【" + coilNo + "】已取消为验证卷");
                        }
                    }

                    if (!flag)
                    {
                        MessageBox.Show("卷号【" + coilNo + "】不是验证卷");
                    }
                }
                else
                {
                    MessageBox.Show("没有卷号，无法取消验证操作");
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
        }

        private void 吊入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OffLineFrmYardToYardRequest frm = new OffLineFrmYardToYardRequest();
            frm.txtSaddle = this.PosName.Substring(0,8);
            frm.CoilFlag = coil_Flag;
            frm.ShowDialog();
        }

        private void 吊离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoilAway frm = new CoilAway();
            frm.saddleNO = this.PosName.Substring(0, 8);
            frm.coilNO = this.CoilId.Trim();
            frm.CoilFlag = coil_Flag;
            frm.ShowDialog();
        }

        private void 删除确认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要删除确认吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.Cancel)
            {
                return;
            }
            string saddleNO = this.PosName.Substring(0, 8);
            string sql = @"UPDATE UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE SET CONFIRM_FLAG = NULL WHERE STOCK_NO = '" + saddleNO + "'";
            DBHelper.ExecuteNonQuery(sql);
            MessageBox.Show("删除确认成功！");
        }
    }
}
