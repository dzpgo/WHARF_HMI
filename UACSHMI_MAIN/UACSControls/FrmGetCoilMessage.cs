﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACSDAL;
using Baosight.iSuperframe.TagService;

namespace UACSControls
{
    public partial class FrmGetCoilMessage : FormBase
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public FrmGetCoilMessage()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmGetCoilMessage_KeyDown);
            

        }

        public FrmGetCoilMessage(string coil)
        {
            InitializeComponent();
            txtCoilNo.Text = coil;
            CoilMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoilMessage();
        }

        private void CoilMessage()
        {
            CoilMessage coilMessage = new CoilMessage();
            coilMessage.GetCoilMessageByCoil(dgvCoilMessage, txtCoilNo.Text.Trim());
        }

        private void FrmGetCoilMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.button1_Click(sender, e);//触发button事件
            }
        }

        private void FrmGetCoilMessage_Load(object sender, EventArgs e)
        {
            //CoilMessage();
        }

        private string strCoil = string.Empty;
        private void button2_Click(object sender, EventArgs e)
        {
            strCoil = txtCoilNo.Text.Trim().ToString();
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("MatInfQuery", null);
            tagDP.Attach(TagValues);

            if(strCoil.Length > 10)
            {
                tagDP.SetData("MatInfQuery", strCoil);
                MessageBox.Show("已申请！");
            }
            else
            {
                MessageBox.Show("请输入正确的钢卷号！");
            }
            
        }
    }
}
