﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.TagService;
using FORMS_OF_REPOSITORIES;
using UACSView.View_CraneMonitor;

namespace UACSView.View_CraneMonitor
{
    public partial class Recondition : Form
    {
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        private A_library_Monitor ALM;
        public Recondition()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加一个构造函数
        /// </summary>
        /// <param name="form"></param>
        public Recondition(A_library_Monitor form) : this()
        {
            ALM = form;
        }
        private string bayNO = "";
        public string BayNO
        {
            get { return bayNO; }
            set { bayNO = value; }
        }

        private string recondition = "";
        private void Recondition_Load(object sender, EventArgs e)
        {
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add(recondition, null);
            tagDP.Attach(TagValues);
            BindCraneNO(cmCraneNO);
        }

        private void BindCraneNO(ComboBox cmbBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");

            DataRow dr;

            if(bayNO == "A")
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "1";
                dr["TypeName"] = "1#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "2";
                dr["TypeName"] = "2#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "3";
                dr["TypeName"] = "3#车";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["TypeValue"] = "4";
                dr["TypeName"] = "4#车";
                dt.Rows.Add(dr);
            }

            if(bayNO == "C")
            {
                dr = dt.NewRow();
                dr["TypeValue"] = "7";
                dr["TypeName"] = "7#车";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["TypeValue"] = "8";
                dr["TypeName"] = "8#车";
                dt.Rows.Add(dr);
            }
            cmbBox.DataSource = dt;
            cmbBox.DisplayMember = "TypeName";
            cmbBox.ValueMember = "TypeValue";

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmCraneNO.Text != "" && txt_Act_X.Text != "" && Convert.ToInt32(txt_Act_X.Text) > 0 && Convert.ToInt32(txt_Act_X.Text) < 330000)
            {
                recondition = cmCraneNO.SelectedValue.ToString().Trim() + "_CraneStop";
                DialogResult dr = MessageBox.Show("是否开始检修？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    tagDP.SetData(recondition, txt_Act_X.Text);

                    #region 检修时更改行车背景颜色
                    if (bayNO.Equals("A"))
                    {
                        ALM.UpdataCrane(cmCraneNO.SelectedValue.ToString().Trim());
                    }
                    else if (bayNO.Equals("C"))
                    {
                        ALM.UpdataCrane(cmCraneNO.SelectedValue.ToString().Trim());
                    }
                    #endregion
                }
                else
                {
                    return;
                }
                //UACSUtility.HMILogger.WriteLog(btnConfirm.Text, cmCraneNO.Text+"确认检修", UACSUtility.LogLevel.Info, this.Text);
            }
            else
            {
                MessageBox.Show("请填写完整！");
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (cmCraneNO.Text != "")
            {
                recondition = cmCraneNO.SelectedValue.ToString().Trim() + "_CraneStop";
                DialogResult dr = MessageBox.Show("确认检修完成？", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.OK)
                {
                    tagDP.SetData(recondition, "0");

                    #region 检修完成时更改行车背景颜色
                    if (bayNO.Equals("A"))
                    {
                        ALM.OutCrane(cmCraneNO.SelectedValue.ToString().Trim());
                    }
                    else if (bayNO.Equals("C"))
                    {
                        ALM.OutCrane(cmCraneNO.SelectedValue.ToString().Trim());
                    }
                    #endregion
                }
                else
                {
                    return;
                }   
                //UACSUtility.HMILogger.WriteLog(btnConfirm.Text, cmCraneNO.Text + "检修完成", UACSUtility.LogLevel.Info, this.Text);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
