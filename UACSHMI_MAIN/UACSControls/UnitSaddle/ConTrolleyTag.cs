﻿ using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace UACS
{
    public partial class ConTrolleyTag : UserControl
    {
        public ConTrolleyTag()
        {
            InitializeComponent();
        }

        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        //step1
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

        private int PTrolleyATInt;
        /// <summary>
        /// 过跨台车到位信号（1:到位 0:没到位）
        /// </summary>
        public int pTrolleyATInt
        {
            get { return GetPTrollerAt(); }
        }


        private int GetPTrollerAt()
        {
            if (pTrolleyAT.BackColor == Color.LawnGreen)
            {
                return 1;
            }
            else
                return 0;
        }


        private string bayNO;
        /// <summary>
        /// 跨别
        /// </summary>
        public string BayNO
        {
            get { return bayNO; }
            set 
            {
                bayNO = value;
                ShiftMove();
            }
        }

        /// <summary>
        /// 根据跨别转换按钮属性
        /// </summary>
        private void ShiftMove()
        {
            if (bayNO == "A")
            {
                btnMove.Text = "去镀锌";
            }
            else if (bayNO == "B")
            {
                btnMove.Text = "去连退";
            }
            else if (bayNO == "Z33")
            {
                btnMove.Text = "去碳钢";
            }
            else if (bayNO == "Z32")
            {
                 btnMove.Text = "去硅钢";
            }
            else if (bayNO == "Z51")
            {
                btnMove.Text = "去Z52";
            }
            else if (bayNO == "Z52")
            {
                btnMove.Text = "去Z51";
            }
            else
            { 
                btnMove.Text = "";
            }
        }



        private string[] arrTagAdress;
        public void SetReadyA_B()
        {
            try
            {
                lblBayNo.Text = bayNO + "台车信号";
                List<string> lstAdress = new List<string>();
                lstAdress.Add("MC_" + bayNO + "_ARRIVAL");        //位置
                lstAdress.Add("MC_LOCKED");    //锁定状态
                lstAdress.Add("MC_LOCK_REQUEST_SET");  //锁定请求
                lstAdress.Add("MC_OCCUPIED");                //占位
                lstAdress.Add("MC_BACK");           //动车信号
                lstAdress.Add("MC_FORWARD");           //动车信号
                lstAdress.Add("MC_AUTO_MODE");                    //作业模式
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception er)
            {

            }
        }

        public void SetReadyZ52_51()
        {
            try
            {
                lblBayNo.Text = bayNO + "台车信号";
                List<string> lstAdress = new List<string>();
                lstAdress.Add("TROLLEY_Z51_52_AT_" + bayNO + "");        //位置
                lstAdress.Add("TROLLEY_Z51_52_LOCKED_" + bayNO + "");    //锁定状态
                lstAdress.Add("TROLLEY_Z51_52_LOCK_REQ_" + bayNO + "");  //锁定请求
                lstAdress.Add("TROLLEY_Z51_52_OCCUPIED");                //占位
                lstAdress.Add("TROLLEY_Z51_52_CMD_MOVE2_Z51");           //动车信号
                lstAdress.Add("TROLLEY_Z51_52_CMD_MOVE2_Z52");           //动车信号
                lstAdress.Add("TROLLEY_Z51_52_MODE");                    //作业模式
                arrTagAdress = lstAdress.ToArray<string>();
            }
            catch (Exception er)
            {

            }
        }


        public  void RefreshControlA_B(out long arrival, out long occupied)
        {
            long a = 0;
            long b = 0;
            try
            {
                readTags();   
                refresh_Panel_Light(pTrolleyAT, get_value_x("MC_" + bayNO + "_ARRIVAL"));
                refresh_Panel_Light(pTrolleyLOCKED, get_value_x("MC_LOCKED"));
                refresh_Panel_Light(pTrolleyLOCK_REQ, get_value_x("MC_LOCK_REQUEST_SET"));
                //占位
                if (get_value_x("MC_OCCUPIED") == 1)
                {
                    pTrolleyOCCUPIED.BackColor = Color.LawnGreen;
                }
                else
                    pTrolleyOCCUPIED.BackColor = Color.White;

                //锁定
                if (get_value_x("MC_LOCKED") == 1)
                {
                    btnLocked.Text = "解锁";
                }
                else
                {
                    btnLocked.Text = "锁定";
                }
                 a = get_value_x("MC_" + bayNO + "_ARRIVAL");
                 b = get_value_x("MC_OCCUPIED");
                 
            }
            catch (Exception er)
            {

            }
            arrival = a;
            occupied = b;
        }
        public void RefreshControlZ52_51()
        {
            try
            {
                readTags();
                refresh_Panel_Light(pTrolleyAT, get_value_x("TROLLEY_Z51_52_AT_" + bayNO + ""));
                refresh_Panel_Light(pTrolleyLOCKED, get_value_x("TROLLEY_Z51_52_LOCKED_" + bayNO + ""));
                refresh_Panel_Light(pTrolleyLOCK_REQ, get_value_x("TROLLEY_Z51_52_LOCK_REQ_" + bayNO + ""));
                //占位
                if (get_value_x("TROLLEY_Z51_52_OCCUPIED") == 0)
                {
                    pTrolleyOCCUPIED.BackColor = Color.LawnGreen;
                }
                else
                    pTrolleyOCCUPIED.BackColor = Color.White;

                //锁定
                if (get_value_x("TROLLEY_Z51_52_LOCKED_" + bayNO + "") == 1)
                {
                    btnLocked.Text = "解锁";
                }
                else
                {
                    btnLocked.Text = "锁定";
                }

            }
            catch (Exception er)
            {

            }
        }


        /// <summary>
        /// 根据tag值改变颜色
        /// </summary>
        /// <param name="theTextBox"></param>
        /// <param name="theValue"></param>
        private static void refresh_Panel_Light(Panel theTextBox, long theValue)
        {
            try
            {

                if (theValue == 1)
                {
                    theTextBox.BackColor = Color.LawnGreen;
                }
                else
                {
                    theTextBox.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
            }
        }



        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
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
        /// <summary>
        /// 取tag值
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        private long get_value_x(string tagName)
        {
            long theValue = 0;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToInt32(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {           
           
                if (btnMove.Text == "去连退")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要过跨台车去连退吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["MC_FORWARD"] = 1;
                        tagDataProvider.Write2Level1(inDatas, 1);
                        ParkClassLibrary.HMILogger.WriteLog(btnMove.Text, "过跨台车" + btnMove.Text, ParkClassLibrary.LogLevel.Info, "过跨台车画面");
                    }
                }
                else if (btnMove.Text == "去镀锌")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要过跨台车去镀锌吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["MC_BACK"] = 1;
                        tagDataProvider.Write2Level1(inDatas, 1);
                        ParkClassLibrary.HMILogger.WriteLog(btnMove.Text, "过跨台车" + btnMove.Text, ParkClassLibrary.LogLevel.Info, "过跨台车画面");
                    }
                }
            
                      
            timer1.Enabled = true;
            
        }

        private void btnLocked_Click(object sender, EventArgs e)
        {
            readTags();
            if (bayNO == "A" || bayNO == "B")
            {
                if (get_value_x("MC_AUTO_MODE") == 0)
                {
                    MessageBox.Show("手动模式无法发送请求");
                    return;
                }

                if (btnLocked.Text == "解锁")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要解锁过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        //TROLLEY_Z32_33_LOCK_REQ_Z32 
                        inDatas["MC_LOCK_REQUEST_SET"] = 0;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
                else if (btnLocked.Text == "锁定")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要锁定过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["MC_LOCK_REQUEST_SET"] = 1;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
            }
            else if (bayNO == "Z32" || bayNO == "Z33" )
            {
                if (get_value_x("TROLLEY_Z32_33_MODE") == 0)
                {
                    MessageBox.Show("手动模式无法发送请求");
                    return;
                }

                if (btnLocked.Text == "解锁")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要解锁过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        //TROLLEY_Z32_33_LOCK_REQ_Z32 
                        inDatas["TROLLEY_Z32_33_LOCK_REQ_" + bayNO + ""] = 0;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
                else if (btnLocked.Text == "锁定")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要锁定过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["TROLLEY_Z32_33_LOCK_REQ_" + bayNO + ""] = 1;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
            }
            else if (bayNO == "Z52" || bayNO == "Z51")
            {
                if (get_value_x("TROLLEY_Z51_52_MODE") == 0)
                {
                    MessageBox.Show("手动模式无法发送请求");
                    return;
                }

                if (btnLocked.Text == "解锁")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要解锁过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["TROLLEY_Z51_52_LOCK_REQ_" + bayNO + ""] = 0;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
                else if (btnLocked.Text == "锁定")
                {
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show("确定要锁定过跨台车吗？", "操作提示", btn);
                    if (dr == DialogResult.OK)
                    {
                        inDatas["TROLLEY_Z51_52_LOCK_REQ_" + bayNO + ""] = 1;
                        tagDataProvider.Write2Level1(inDatas, 1);
                    }
                }
            }

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btnMove.Text == "去连退")
            {
                inDatas["MC_FORWARD"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
            if (btnMove.Text == "去镀锌")
            {
                inDatas["MC_BACK"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
            if (btnMove.Text == "去碳钢")
            {
                inDatas["TROLLEY_Z32_33_CMD_MOVE2_Z32"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
            else if (btnMove.Text == "去硅钢")
            {
                inDatas["TROLLEY_Z32_33_CMD_MOVE2_Z33"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
            else if (btnMove.Text == "去Z52")
            {
                inDatas["TROLLEY_Z51_52_CMD_MOVE2_Z52"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
            else if (btnMove.Text == "去Z51")
            {
                inDatas["TROLLEY_Z51_52_CMD_MOVE2_Z51"] = 0;
                tagDataProvider.Write2Level1(inDatas, 1);
            }
           
            timer1.Enabled = false;
        }
    }
}
