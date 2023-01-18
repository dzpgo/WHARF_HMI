﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACS;
using UACSControls;
using UACSPopupForm;

namespace UACSview
{
    public partial class A_B_Trolley : FormBase
    {
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

        private const string tagServiceName = "iplature";
        private const string ABayNo = "A";
        private const string BBayNo = "B";
        private const string SaddleNo = "MC1";
        private const int Flag_Unit_Exit = 1;
        /// <summary>
        /// 公共dataTable
        /// </summary>
        private DataTable SaddleDt = new DataTable();
        /// <summary>
        /// 鞍座控件
        /// </summary>
        private Dictionary<string, UACS.CoilPicture> dicSaddleControls = new Dictionary<string, CoilPicture>();
        /// <summary>
        /// 吊运控件
        /// </summary>
        private Dictionary<UACS.CoilPicture, UACS.CoilCranOrder> dicControl = new Dictionary<UACS.CoilPicture, UACS.CoilCranOrder>();
        /// <summary>
        /// 实例化鞍座出口类
        /// </summary>
        private UACS.SaddleMethod saddleMethod = new SaddleMethod();
        /// <summary>
        /// 根据吊运控件得到指定鞍座号
        /// </summary>
        private Dictionary<string, string> saddleNo = new Dictionary<string, string>();
        /// <summary>
        /// 台车故障
        /// </summary>
        private const string MC_MALFUNCTION = "MC_MALFUNCTION";
        /// <summary>
        /// 安全门
        /// </summary>
        private const string MC_SAFE_DOOR = "MC_SAFE_DOOR";
        /// <summary>
        /// 作业模式
        /// </summary>
        private const string MC_AUTO_MODE = "MC_AUTO_MODE";


        public A_B_Trolley()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            this.Load += A_B_Trolley_Load;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        void A_B_Trolley_Load(object sender, EventArgs e)
        {
            // 根据指定值附鞍座控件
            dicSaddleControls["AMC10A01"] = coilPictureA;
            dicSaddleControls["BMC10A01"] = coilPictureB;
          
            // 根据鞍座附吊运控件
            dicControl[coilPictureB] = coilCranOrderB;
            dicControl[coilPictureA] = coilCranOrderA;
            // 加载初始化
            saddleMethod = new UACS.SaddleMethod(SaddleNo, Flag_Unit_Exit, tagServiceName);

            CoilMessage();

            //-----------------------------故障------------------------------
            coilUnitStatus1.InitTagDataProvide(tagServiceName);
            coilUnitStatus1.MyStatusTagName = MC_MALFUNCTION;

            //-----------------------------安全门------------------------------
            coilUnitStatus2.InitTagDataProvide(tagServiceName);
            coilUnitStatus2.MyStatusTagName = MC_SAFE_DOOR;
            //-----------------------------作业模式------------------------------
            coilUnitStatus3.InitTagDataProvide(tagServiceName);
            coilUnitStatus3.MyStatusTagName = MC_AUTO_MODE;

            coilPictureA.ContextMenuStrip.Enabled = false;
            coilPictureB.ContextMenuStrip.Enabled = false;

            //
            conTrolleyTagA.BayNO = ABayNo;
            conTrolleyTagA.InitTagDataProvide(tagServiceName);


            conTrolleyTagB.BayNO = BBayNo;
            conTrolleyTagB.InitTagDataProvide(tagServiceName);


            conEntrySpecActionA.UnitNo = "MC1";
            conEntrySpecActionA.BayNo = "A";

            conEntrySpecActionB.UnitNo = "MC1";
            conEntrySpecActionB.BayNo = "B";

            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        /// <summary>
        /// 查询鞍座信息
        /// </summary>
        private void CoilMessage()
        {
            System.GC.Collect();

            saddleMethod.ReadDefintion();
            saddleMethod.getTagNameList();
            saddleMethod.getTagValues();

            // 鞍座信息
            //dataGridViewSaddleMessage.DataSource = saddleMethod.getExitSaddleDt(SaddleDt, SaddleNo);

            foreach (string theL2SaddleName in dicSaddleControls.Keys)
            {
                if (saddleMethod.DicSaddles.ContainsKey(theL2SaddleName))
                {
                    // 找到指定的鞍座
                    UACS.CoilPicture conSaddle = dicSaddleControls[theL2SaddleName];
                    // 获取钢卷号
                    Saddle theSaddleInfo = saddleMethod.DicSaddles[theL2SaddleName];
                    
                    // 给吊运控件赋值
                    UACS.CoilCranOrder coil = dicControl[conSaddle];

                    // 锁定反馈
                    if (theSaddleInfo.TagVal_IsLocked == 1)
                    {
                        conSaddle.UpVisiable = true;
                    }
                    else
                    {
                        conSaddle.UpVisiable = false;
                    }


                    if (theL2SaddleName == "AMC10A01")
                    {
                        // 占位
                        if (theSaddleInfo.TagVal_IsOccupied == 1 && conTrolleyTagB.pTrolleyATInt == 0)
                            conSaddle.CoilBackColor = Color.Green;
                        else
                            conSaddle.CoilBackColor = Color.LightGray;
                    }
                    else if (theL2SaddleName == "BMC10A01")
                    {
                        if (theSaddleInfo.TagVal_IsOccupied == 1 && conTrolleyTagA.pTrolleyATInt == 0)
                            conSaddle.CoilBackColor = Color.Green;
                        else
                            conSaddle.CoilBackColor = Color.LightGray;
                    }
                    else
                    {
                        if (theSaddleInfo.TagVal_IsOccupied == 0)
                            conSaddle.CoilBackColor = Color.Green;
                        else
                            conSaddle.CoilBackColor = Color.LightGray;
                    }

                    // 有无钢卷号
                    if (theSaddleInfo.CoilNO != string.Empty)
                    {
                        conSaddle.CoilId = theSaddleInfo.CoilNO;
                        conSaddle.CoilStatus = 2;
                    }
                    else
                    {
                        conSaddle.CoilId = "";
                        conSaddle.CoilStatus = -10;
                    }

                    CoilCranOrder.CoilNoDelegate del = new CoilCranOrder.CoilNoDelegate(coil.EntryStatusOrCoil);
                    del(theSaddleInfo.CoilNO);
                }
            }
            this.Refresh();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            long a, b;
            try
            {
                if (tabActived == false)
                {
                    return;
                }
                 conTrolleyTagA.SetReadyA_B();
                 conTrolleyTagA.RefreshControlA_B(out a, out b);

                 conTrolleyTagB.SetReadyA_B();
                 conTrolleyTagB.RefreshControlA_B(out a, out b);

                 coilUnitStatus1.RefreshControl();
                 coilUnitStatus2.RefreshControl();
                 coilUnitStatus3.RefreshControl();

                 System.GC.Collect();
                 System.GC.WaitForPendingFinalizers();
                 
            }
            catch (Exception er)
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tabActived == false)
                {
                    return;
                }
                CoilMessage();
                conEntrySpecActionA.conGetAction("A");
                conEntrySpecActionB.conGetAction("B");

                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

            }
            catch (Exception er)
            {

                this.timer2.Enabled = false;
            }
           
        }

        #region --------------------------画面切换-------------------------------
        bool tabActived = true;
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            long arrival, occupied;
            conTrolleyTagA.SetReadyA_B();
            conTrolleyTagA.RefreshControlA_B(out arrival, out occupied);
            if(arrival != 1 || occupied == 1)
            {
                MessageBox.Show("台车未到位或台车上有卷！");
                return;
            }
            else
            {
                TrolleyFrmYardToYardRequest frm = new TrolleyFrmYardToYardRequest();
                frm.BayNo = "A";
                frm.Show();
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long arrival, occupied;
            conTrolleyTagB.SetReadyA_B();
            conTrolleyTagB.RefreshControlA_B(out arrival, out occupied);
            if(arrival != 1 || occupied == 1)
            {
                MessageBox.Show("台车未到位或台车上有卷！");
                return;
            }
            else
            {
                TrolleyFrmYardToYardRequest frm = new TrolleyFrmYardToYardRequest();
                frm.BayNo = "B";
                frm.Show();
            }
            
        }

        private string strStockA = string.Empty;
        private string strSaddle_L2NameA = string.Empty;
        private string strStockB = string.Empty;
        private string strSaddle_L2NameB = string.Empty;
        private void btnInsertA_Click(object sender, EventArgs e)
        {
            strStockA = "AMC10A01";
            strSaddle_L2NameA = "MC1_A";
            strStockB = "BMC10A01";
            strSaddle_L2NameB = "MC1_B";

            string sql1 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 2,MAT_NO = '{0}'WHERE STOCK_NO = '{1}'", txtCoilNoA.Text.Trim(), strStockA);
            string sql2 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 1,COIL_NO = '{0}'WHERE SADDLE_L2NAME = '{1}'", txtCoilNoA.Text.Trim(), strSaddle_L2NameA);
            string sql3 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,MAT_NO = ''WHERE STOCK_NO = '{0}'", strStockB);
            string sql4 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 0,COIL_NO = '' WHERE SADDLE_L2NAME = '{0}'", strSaddle_L2NameB);
            try
            {
                if (txtCoilNoA.Text.Trim().Length != 11)
                {
                    MessageBox.Show("输入的卷号不正确，请重新输入！");
                    txtCoilNoA.Clear();
                    txtCoilNoA.Focus();
                    return;
                }
                if (MessageBox.Show("确定是否修改台车鞍座状态？", "修改提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DBHelper.ExecuteNonQuery(sql1);
                    DBHelper.ExecuteNonQuery(sql2);
                    DBHelper.ExecuteNonQuery(sql3);
                    DBHelper.ExecuteNonQuery(sql4);
                    MessageBox.Show("修改成功", "修改提示");
                    txtCoilNoA.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnInsertB_Click(object sender, EventArgs e)
        {
            strStockA = "AMC10A01";
            strSaddle_L2NameA = "MC1_A";
            strStockB = "BMC10A01";
            strSaddle_L2NameB = "MC1_B";

            string sql1 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 2,MAT_NO = '{0}' WHERE STOCK_NO = '{1}'", txtCoilNoB.Text.Trim(), strStockB);
            string sql2 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 1,COIL_NO = '{0}' WHERE SADDLE_L2NAME = '{1}'", txtCoilNoB.Text.Trim(), strSaddle_L2NameB);
            string sql3 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,MAT_NO = '' WHERE STOCK_NO = '{0}'", strStockA);
            string sql4 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 0,COIL_NO = '' WHERE SADDLE_L2NAME = '{0}'", strSaddle_L2NameA);

            try
            {
                if (txtCoilNoB.Text.Trim().Length != 11)
                {
                    MessageBox.Show("输入的卷号不正确，请重新输入！");
                    txtCoilNoB.Clear();
                    txtCoilNoB.Focus();
                    return;
                }
                if (MessageBox.Show("确定是否修改台车鞍座状态？", "修改提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DBHelper.ExecuteNonQuery(sql1);
                    DBHelper.ExecuteNonQuery(sql2);
                    DBHelper.ExecuteNonQuery(sql3);
                    DBHelper.ExecuteNonQuery(sql4);
                    MessageBox.Show("修改成功","修改提示");
                    txtCoilNoB.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            strStockA = "AMC10A01";
            strSaddle_L2NameA = "MC1_A";
            strStockB = "BMC10A01";
            strSaddle_L2NameB = "MC1_B";
            string sql1 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,MAT_NO = '' WHERE STOCK_NO = '{0}'", strStockA);
            string sql2 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 0,COIL_NO = '' WHERE SADDLE_L2NAME = '{0}'", strSaddle_L2NameA);
            try
            {

                if (MessageBox.Show("确定是否修改台车鞍座状态？", "清除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DBHelper.ExecuteNonQuery(sql1);
                    DBHelper.ExecuteNonQuery(sql2);
                    MessageBox.Show("清除成功", "清除提示");
                    txtCoilNoB.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            strStockA = "AMC10A01";
            strSaddle_L2NameA = "MC1_A";
            strStockB = "BMC10A01";
            strSaddle_L2NameB = "MC1_B";
            string sql1 = string.Format("UPDATE UACS_YARDMAP_STOCK_DEFINE SET STOCK_STATUS = 0,MAT_NO = ''WHERE STOCK_NO = '{0}'", strStockB);
            string sql2 = string.Format("UPDATE UACS_LINE_EXIT_L2INFO SET HAS_COIL = 0,COIL_NO = '' WHERE SADDLE_L2NAME = '{0}'", strSaddle_L2NameB);
            try
            {

                if (MessageBox.Show("确定是否修改台车鞍座状态？", "清除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    DBHelper.ExecuteNonQuery(sql1);
                    DBHelper.ExecuteNonQuery(sql2);
                    MessageBox.Show("清除成功", "清除提示");
                    txtCoilNoB.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
