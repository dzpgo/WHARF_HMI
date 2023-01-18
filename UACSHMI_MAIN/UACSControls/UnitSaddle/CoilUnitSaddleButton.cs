﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;

namespace UACSControls
{
    public partial class CoilUnitSaddleButton : UserControl
    {

        public CoilUnitSaddleButton()
        {
            InitializeComponent();
        }

        private UnitSaddleTagRead lineSaddleTag = null;
        private string error = string.Empty;
        private SaddleBase theSaddle = null;

        public void InitUnitSaddle(UnitSaddleTagRead _lineSaddleTag)
        {
            lineSaddleTag = _lineSaddleTag;
        }

        private string mySaddleNo = "";
        [Description("对应鞍座的名称")]
        public string MySaddleNo
        {
            get { return mySaddleNo; }
            set { mySaddleNo = value; }
        }

        private string mySaddleTagName = "";
        [Description("对应鞍座的tag名")]
        public string MySaddleTagName
        {
            get { return mySaddleTagName; }
            set { mySaddleTagName = value; }
        }

        //public Color SaddleBackColor
        //{
        //    get { return btnLock.BackColor; }
        //    set { btnLock.BackColor = value; }
        //}     

        private void btnLock_Click(object sender, EventArgs e)
        {
            //当前鞍座没有锁定
            if (btnLock.BackColor == Color.White)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要进行对" + mySaddleNo + "锁定操作吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    if (lineSaddleTag != null && mySaddleTagName != "")
                    {
                        lineSaddleTag.setTagValue(this.mySaddleTagName, 1, out error);
                        ParkClassLibrary.HMILogger.WriteLog("机组鞍座锁定", "锁定" + mySaddleNo + "鞍座", ParkClassLibrary.LogLevel.Info, "机组鞍座");
                    }
                    if (error != string.Empty)
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            //当前鞍座已经锁定
            if (btnUnlock.BackColor == Color.White)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要进行对" + mySaddleNo + "解锁操作吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    if (lineSaddleTag != null && mySaddleTagName != "")
                    {
                        lineSaddleTag.setTagValue(this.mySaddleTagName, 0, out error);
                        ParkClassLibrary.HMILogger.WriteLog("机组鞍座解锁", "解锁" + mySaddleNo + "鞍座", ParkClassLibrary.LogLevel.Info, "机组鞍座");
                    }
                    if (error != string.Empty)
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }
        public delegate void delRefresh_Button_Light(long theValue);

        /// <summary>
        /// 按钮颜色显示方法
        /// </summary>
        /// <param name="theValue"></param>
        public void refresh_Button_Light(long theValue)
        {

            if (theValue == 1 )
            {
                btnLock.BackColor = Color.LightGreen;               
                btnUnlock.BackColor = Color.White;
            }
            else
            {
                btnLock.BackColor = Color.White;
                btnUnlock.BackColor = Color.LightGreen;
            }


        }
    }
}
