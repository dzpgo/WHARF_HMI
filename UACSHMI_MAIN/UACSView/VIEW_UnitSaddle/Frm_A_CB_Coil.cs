using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACSControls;
using UACSDAL;
using UACS;

namespace UACSView
{
    public partial class Frm_A_CB_Coil : FormBase
    {
        public Frm_A_CB_Coil()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint, true);
            this.Load += Frm_A_CB_Coil_Load;
        }
        #region  -----------------------------连接数据库--------------------------------
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

        #region  -----------------------------方法字段--------------------------------
        private const string BayNo = "A";
        private const string AreaNo_A = "Z03-D";
        //private const string AreaNo_A = "Z02-P1";
        //private const string AreaNo_B = "Z02-P2";
        private const string SubAreaNo_A = "21";
        private const string SubAreaNo_B = "22";
        private const string D401UnitNo = "D102";
        private string CB_Coil_Falg = "CB";
        bool pressed = true;
        bool press = true;
        
        //private const string D212UnitNo = "D212";
        /// <summary>
        /// 鞍座控件
        /// </summary>
        private Dictionary<string, CoilPicture> dicSaddleControls = new Dictionary<string, CoilPicture>();
        private Dictionary<CoilPicture, conOffLinePackingSaddleInfo>
            dicControl = new Dictionary<CoilPicture, conOffLinePackingSaddleInfo>();
        private OffinePackingSaddleInBay offineSaddle = new OffinePackingSaddleInBay();
        private List<string> listUnit = new List<string>();
        private OffinePackingUrgentStop craneStop;

        #endregion

        #region -----------------------------初始加载--------------------------------

        void Frm_A_CB_Coil_Load(object sender, EventArgs e)
        {
            dicSaddleControls["Z0302021"] = Z51BayParkingArea_1;
            Z51BayParkingArea_1.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_1).Key;
            dicSaddleControls["Z0303021"] = Z51BayParkingArea_2;
            Z51BayParkingArea_2.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_2).Key;
            dicSaddleControls["Z0304021"] = Z51BayParkingArea_3;
            Z51BayParkingArea_3.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_3).Key;
            dicSaddleControls["Z0305021"] = Z51BayParkingArea_4;
            Z51BayParkingArea_4.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_4).Key;
            dicSaddleControls["Z0306021"] = Z51BayParkingArea_5;
            Z51BayParkingArea_5.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_5).Key;
            dicSaddleControls["Z0307021"] = Z51BayParkingArea_6;
            Z51BayParkingArea_6.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_6).Key;
            dicSaddleControls["Z0308021"] = Z51BayParkingArea_7;
            Z51BayParkingArea_7.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_7).Key;
            dicSaddleControls["Z0302011"] = Z51BayParkingArea_11;
            Z51BayParkingArea_11.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_11).Key;
            dicSaddleControls["Z0303011"] = Z51BayParkingArea_12;
            Z51BayParkingArea_12.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_12).Key;
            dicSaddleControls["Z0304011"] = Z51BayParkingArea_13;
            Z51BayParkingArea_13.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_13).Key;
            dicSaddleControls["Z0305011"] = Z51BayParkingArea_14;
            Z51BayParkingArea_14.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_14).Key;
            dicSaddleControls["Z0306011"] = Z51BayParkingArea_15;
            Z51BayParkingArea_15.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_15).Key;
            dicSaddleControls["Z0307011"] = Z51BayParkingArea_16;
            Z51BayParkingArea_16.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_16).Key;
            dicSaddleControls["Z0308011"] = Z51BayParkingArea_17;
            Z51BayParkingArea_17.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == Z51BayParkingArea_17).Key;

            //this.dgvOffLineSaddleInfo.AutoGenerateColumns = false;     


            //conOffinePackingStatusSwitchover1.AreaNo = AreaNo_A;
            //conOffinePackingStatusSwitchover1.SubAreaNO = SubAreaNo_A;

            //conOffinePackingStatusSwitchover2.AreaNo = AreaNo_B;
            //conOffinePackingStatusSwitchover2.SubAreaNO = SubAreaNo_B;

            //craneStop = new OffinePackingUrgentStop("A", "3_1");

            timer1.Enabled = true;
            timer1.Interval = 2500;
        } 
        #endregion

        #region  -----------------------------画面刷新--------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabActived == false)
            {
                return; 
            }
            try
            {
                string tmp = AreaNo_A;                
                for (int i = 0; i < 2; i++)
                {
                    //string s = string.Format("{0}{1}",tmp,i == 0? "1":"2");
                    string s = tmp;
                    offineSaddle.ReadDefintion(s);
                    foreach (string theSaddleName in dicSaddleControls.Keys)
                    {
                        if (offineSaddle.DicSaddles.ContainsKey(theSaddleName))
                        {
                            CoilPicture conSaddle = dicSaddleControls[theSaddleName];
                            // 获取钢卷号
                            OffinePackingSaddle theSaddleInfo = offineSaddle.DicSaddles[theSaddleName];

                            //conOffLinePackingSaddleInfo coil = dicControl[conSaddle];

                            //conOffLinePackingSaddleInfo.DelegatePackingSaddleInfo info = new
                            //    conOffLinePackingSaddleInfo.DelegatePackingSaddleInfo(coil.UpPackingSaddleInfo);
                            //info(dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key);
                            if (theSaddleInfo.CONFIRM_FLAG == 110)
                            {
                                conSaddle.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key + "(吊入)";
                                conSaddle.CoilBackColor = Color.Cyan;
                                //coil.BackColor = Color.Cyan;
                                conSaddle.CoilId = theSaddleInfo.Coil;
                            }
                            //else if (theSaddleInfo.CONFIRM_FLAG == 20)
                            //{
                            //    conSaddle.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key + "(包装)";
                            //    conSaddle.CoilBackColor = Color.Pink;
                            //   // coil.BackColor = Color.Pink;
                            //}
                            else if (theSaddleInfo.CONFIRM_FLAG == 130)
                            {
                                conSaddle.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key + "(吊离)";
                                conSaddle.CoilBackColor = Color.Yellow;
                                //coil.BackColor = Color.Yellow;
                            }
                            //else if (theSaddleInfo.CONFIRM_FLAG == 40)
                            //{
                            //    conSaddle.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key + "(待包卷吊入)";
                            //    conSaddle.CoilBackColor = Color.PaleGreen;
                            //    //coil.BackColor = Color.PaleGreen;
                            //}
                            else
                            {
                                conSaddle.PosName = dicSaddleControls.FirstOrDefault(p => p.Value == conSaddle).Key;
                                conSaddle.CoilBackColor = Color.SkyBlue;
                               // coil.BackColor = Color.SkyBlue;
                            }

                            if (checkBox_Show.Checked)
                            {
                                if (theSaddleInfo.SaddleStatus == 2 && theSaddleInfo.LockFlag == 0)                        //有卷可用
                                {
                                    if (theSaddleInfo.CoilWeight > 15000)
                                        conSaddle.CoilStatus = -2;
                                    else
                                        conSaddle.CoilStatus = 2;
                                    conSaddle.CoilId = theSaddleInfo.Coil;
                                }
                                else if (theSaddleInfo.SaddleStatus == 0 && theSaddleInfo.LockFlag == 0)                   //无卷可用
                                {
                                    //conSaddle.CoilId = "";
                                    conSaddle.CoilStatus = -10;
                                }
                                else                                                                                       //库位状态不明
                                {
                                    conSaddle.CoilStatus = 5;
                                    conSaddle.CoilId = theSaddleInfo.Coil;
                                }
                            }
                            else
                            {
                                if (theSaddleInfo.SaddleStatus == 2 && theSaddleInfo.LockFlag == 0)                        //有卷可用
                                {
                                    if (theSaddleInfo.CoilWeight > 15000)
                                        conSaddle.CoilStatus = -2;
                                    else
                                        conSaddle.CoilStatus = 2;
                                    conSaddle.CoilId = theSaddleInfo.Coil;
                                }
                                else                                                                                       //库位状态不明
                                {
                                    conSaddle.CoilId = "";
                                    conSaddle.CoilStatus = -10;
                                }
                            }
                        }
                    }
                }
                    

               

                //conOffinePackingStatusSwitchover1.RefreshOffinePackingStatus();
                //conOffinePackingStatusSwitchover2.RefreshOffinePackingStatus();
               // offineSaddle.GetOffLinePackingByUnitSaddleInfo(D401UnitNo, BayNo, dgvD401UnitSaddleInfo);
                if (pressed)
                {
                    //offineSaddle.GetOffLinePackingByUnitSaddleInfo(D401UnitNo, BayNo, dgvD401UnitSaddleInfo);
                    //ChangeDGVColorByPackCode(dgvD401UnitSaddleInfo);
                }

                if(press)
                {
                    //offineSaddle.GetOffLinePackingByZ34034Info(dgvOffLineSaddleInfo, "Z0200");
                    //ChangeDGVColorByPackCode(dgvOffLineSaddleInfo);
                }
                


                //if (conOffinePackingStatusSwitchover1.AreaStatus != "自动吊运")
                //{
                //    pl_5111.BackColor = Color.MistyRose;
                //}
                //else
                //{
                //    pl_5111.BackColor = Color.FloralWhite;
                //}
                //if (conOffinePackingStatusSwitchover2.AreaStatus != "自动吊运")
                //{
                //    pl_5112.BackColor = Color.MistyRose;
                //}
                //else
                //{
                //    pl_5112.BackColor = Color.FloralWhite;
                //}

                GC.Collect();
            }
            catch (Exception er)
            {

                throw;
            }
        }

        private void ChangeDGVColorByPackCode(params DataGridView[] _dgv)
        {
            for (int i = 0; i < _dgv.Length; i++)
            {
                for (int j = 0; j < _dgv[i].RowCount; j++)
                {
                    if (_dgv[i].Rows[j].Cells[8].Value != DBNull.Value)
                    {
                        string packCode = _dgv[i].Rows[j].Cells[8].Value.ToString();
                        if (!packCode.Contains("1"))
                        {
                            _dgv[i].Rows[j].DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
            }

        }
        #endregion

        #region -----------------------------画面切换--------------------------------
        private bool tabActived = true;
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }
        #endregion
      
        private void btnCraneStop_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要紧停离线包装上方的自动行车吗？", "操作提示", btn);
            if (dr == DialogResult.OK)
            {
                craneStop.isUrgentStop();
            }
        }

        
        private void dgvD401UnitSaddleInfo_Scroll(object sender, ScrollEventArgs e)
        {
            pressed = false;
            
        }

        private void dgvD401UnitSaddleInfo_MouseLeave(object sender, EventArgs e)
        {
            pressed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!(MessageBox.Show("确定要吊离拆包区所有卷吗？","吊离提示",MessageBoxButtons.OKCancel)==DialogResult.OK))
            {
                return;
            }
            try
            {              
                string sql1 = @"UPDATE UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE SET CONFIRM_FLAG = 130 WHERE STOCK_NO IN (SELECT STOCK_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE MAT_NO != 'NULL' AND STOCK_STATUS = 2 AND LOCK_FLAG = 0 AND STOCK_NO IN (SELECT STOCK_NO FROM UACS_OFFLINE_PACKING_AREA_STOCK_DEFINE WHERE AREA_ID = '"+ AreaNo_A + "'))";
                DBHelper.ExecuteNonQuery(sql1);
                MessageBox.Show("已执行拆包区所有卷吊离！");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dgvOffLineSaddleInfo_MouseLeave(object sender, EventArgs e)
        {
            press = true;
        }

        private void dgvOffLineSaddleInfo_Scroll(object sender, ScrollEventArgs e)
        {
            press = false;
        }
    }
}
