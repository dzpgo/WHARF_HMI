﻿using Baosight.iSuperframe.TagService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACS
{
    public partial class FrmRetStockMessage : Form
    {

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private const string tagServiceName = "iplature";
        SaddleMethod method = new SaddleMethod();
        private string unitNo = null;
        /// <summary>
        /// 机组号
        /// </summary>
        public string UnitNo
        {
            get { return unitNo; }
            set { unitNo = value; }
        }


        private string bayNo = null;
        /// <summary>
        /// 跨别号
        /// </summary>
        public string BayNo
        {
            get { return bayNo; }
            set { bayNo = value; }
        }

        public FrmRetStockMessage()
        {
            InitializeComponent();
            this.Load += FrmRetStockMessage_Load;
        }

        void FrmRetStockMessage_Load(object sender, EventArgs e) 
        {
            //窗体固定大小
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            tagDP.ServiceName = tagServiceName;
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add( unitNo +"_SPEC_ACTION", null);
            tagDP.Attach(TagValues);


            if (unitNo == "MC1" || unitNo == "MC2")
            {
                this.Text = "吊过跨台车钢卷下车";
                btnOk.Text = "钢卷下车";
            }
            else
            {
                label2.Visible = false;
                lblStockNo.Visible = false;
                btnStockSelect.Visible = false;
            }


            method.GetSaddleMessageInDgv(unitNo, bayNo, dataGridView1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (unitNo == "MC1" || unitNo == "MC2")
            {
                if (lblStockNo.Text == "999999")
                {
                    MessageBox.Show("卸下过跨台车的钢卷必须有空库位");
                    return;
                }
            }


            int index = 0;
            int saddleIndex = 999;
            string coilNo = string.Empty;
            string stockNo = string.Empty;         
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["Column1"].EditedFormattedValue == true)
                {
                    index++;
                    saddleIndex = i;
                }
            }
            if (saddleIndex == 999)
            {
                MessageBox.Show("请选择一个鞍座进行退料");
                return;
            }

            if (index > 1)
            {
                MessageBox.Show("不能选择多个鞍座进行退料");
                return;
            }

            if (dataGridView1.Rows[saddleIndex].Cells["COIL_NO"].Value != DBNull.Value)
            {
                coilNo = dataGridView1.Rows[saddleIndex].Cells["COIL_NO"].Value.ToString().Trim();
            }
            if (dataGridView1.Rows[saddleIndex].Cells["STOCK_NO"].Value != DBNull.Value)
            {
                stockNo = dataGridView1.Rows[saddleIndex].Cells["STOCK_NO"].Value.ToString();
            }

            //if (unitNo == "D308")
            //{
            //    if (stockNo == "D308WR1A01" || stockNo == "D308WR1A02")
            //    {
                    
            //    }
            //    else
            //    {
            //        MessageBox.Show("热镀锌自动退料只能回退D308WR1A01、D308WR1A02鞍座！");
            //        return;
            //    }
            //}

            //if (unitNo == "D212")
            //{
            //    if (stockNo != "D212VR1A01" || stockNo != "D212VR2A01")
            //    {
            //        MessageBox.Show("连退入口自动退料只能回退D212VR1A01、D212VR2A01鞍座！");
            //        return;
            //    }
            //}

            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要进行钢卷回退库区操作吗？", "操作提示", btn);
            if (dr == DialogResult.OK)
            {           
                if (!string.IsNullOrEmpty(coilNo))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("LINE_TO_YARD");
                    sb.Append(",");
                    sb.Append(coilNo);
                    sb.Append(",");
                    sb.Append(stockNo);
                    sb.Append(",");
                    
                    if (unitNo == "MC1" || unitNo == "MC2")
                    {
                        sb.Append(lblStockNo.Text);
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                    

                    tagDP.SetData(unitNo + "_SPEC_ACTION", sb.ToString());
                    MessageBox.Show("行车已准备对" + stockNo + "退料");
                    ParkClassLibrary.HMILogger.WriteLog(unitNo + "退料", stockNo + "鞍座退料", ParkClassLibrary.LogLevel.Info, unitNo + "机组");
                    this.Close();
                }
                else
                    MessageBox.Show(stockNo +"没有钢卷号，无法退料");
            }
        }

        private void btnStockSelect_Click(object sender, EventArgs e)
        {
            FrmStcokNoCoil frm = new FrmStcokNoCoil();
            frm.BayNo = bayNo;
            frm.TransfEvent += frm_TransfEvent;
            frm.ShowDialog();
        }
        void frm_TransfEvent(String stockNo)
        {
            lblStockNo.Text = stockNo;
        }
    }
}
