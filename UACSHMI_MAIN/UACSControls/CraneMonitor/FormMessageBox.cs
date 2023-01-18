﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UACSControls
{
    public partial class FormMessageBox : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);


        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记该标记
        private const int AW_CENTER = 0x0010;//若应用了AW_HIDE标记,则使窗口向内重叠;不然向外扩大
        private const int AW_HIDE = 0x10000;//隐蔽窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口,在应用了AW_HIDE标记后不要应用这个标记
        private const int AW_SLIDE = 0x40000;//应用滑动类型动画结果,默认为迁移转变动画类型,当应用AW_CENTER标记时,这个标记就被忽视
        private const int AW_BLEND = 0x80000;//应用淡入淡出结果


        private int messsageBoxFlag;
        /// <summary>
        ///  1  机组有请求没锁定
        ///  2  行车心跳中断
        /// </summary>
        public int MesssageBoxFlag
        {
            get { return messsageBoxFlag; }
            set { messsageBoxFlag = value; }
        }


        private string messsageBoxInfo;
        /// <summary>
        /// 弹出信息
        /// </summary>
        public string MesssageBoxInfo
        {
            get { return messsageBoxInfo; }
            set { messsageBoxInfo = value; }
        }
        
        
        public FormMessageBox()
        {
            InitializeComponent();
            this.Load += FormMessageBox_Load;
           // textBox1.Text = messageBoxInfo;
        }

        void FormMessageBox_Load(object sender, EventArgs e)
        {
            if (messsageBoxFlag == 1)
            {
                this.Text = "机组未锁定警告";
            }
            else if (messsageBoxFlag == 2)
            {
                this.Text = "行车心跳中断警告";
            }
            textBox1.Text = messsageBoxInfo;

            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
            //timer1.Enabled = true;
        }
        int countTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            countTime += 1;
            if (countTime == 10)
            {
                this.Close();
            }
        }


    }
}
