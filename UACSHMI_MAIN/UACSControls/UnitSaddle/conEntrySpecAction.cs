﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.TagService;

namespace UACS
{
    public partial class conEntrySpecAction : UserControl
    {
        public conEntrySpecAction()
        {
            InitializeComponent();
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

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private const string tagServiceName = "iplature";

        FrmRetStockMessage frmStockMessage;
        FrmInsertCoilMessage frmInsertMessage;

        SaddleMethod saddleMethof = new SaddleMethod();
        /// <summary>
        /// 退料
        /// </summary>
        private const string line_To_Yard = "LINE_TO_YARD";

        /// <summary>
        /// 插料
        /// </summary>
        private const string yard_To_Line = "YARD_TO_LINE";

        /// <summary>
        /// 倒鞍座
        /// </summary>
        private const string line_To_Line = "LINE_TO_LINE";

        /// <summary>
        /// 指令为空
        /// </summary>
        private const string STATUS_EMPTY="EMPTY";
        /// <summary>
        /// 指令确认中
        /// </summary>
        private const string STATUS_WMS_ORDER_CREATED="WMS_ORDER_CREATED";
        /// <summary>
        /// 指令执行中
        /// </summary>
        private const string STATUS_ORDER_SELECTED_BY_CRANE="ORDER_SELECTED_BY_CRANE";

        private string unitNo =  null;
        /// <summary>
        /// 机组号
        /// </summary>
        public string UnitNo
        {
            get { return unitNo; }
            set 
            {
                unitNo = value;
                AnalyButtonTxt();
            }
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


        private void AnalyButtonTxt()
        {
            if (unitNo == "MC1")
            {
                btnRetStock.Text = "下车";
                btnInsertCoil.Text = "上车";
            }
            if (unitNo == "D212")
            {
                btnInsertCoil.Text = "";
                btnInsertCoil.Enabled = false;
                button4.Enabled = false;
            }
        }
        /// <summary>
        /// 读取当前动作信息
        /// </summary>
        public void conGetAction(string bayNo = null)
        {
            if (unitNo != null)
            {
                try
                {
                    string sql = string.Format("SELECT * FROM UACS_LINE_ENTRY_SPEC_ACTION WHERE UNIT_NO = '{0}'",unitNo);
                    using (IDataReader rdr = DBHelper.ExecuteReader(sql))
                    {
                        while (rdr.Read())
                        {
                            if (rdr["ACTION"] != DBNull.Value)
                            {
                                if (!string.IsNullOrEmpty(rdr["ACTION"].ToString()))
                                {

                                    if (rdr["STOCK_NO"] != DBNull.Value)
                                    {
                                        lblSaddleNo.Text = rdr["STOCK_NO"].ToString();
                                    }
                                    else
                                        lblSaddleNo.Text = "无"; 

                                    if ( rdr["COIL_NO"] != DBNull.Value)
                                    {
                                        lblCoilNo.Text = rdr["COIL_NO"].ToString();
                                    }
                                    else
                                    {
                                        lblCoilNo.Text = "无";
                                    }
                                    lblAction.Text = AnalysisAction(rdr["ACTION"].ToString(),bayNo);

                                    if (rdr["STATUS"] != DBNull.Value)
                                    {
                                        lblStatus.Text =AnalysisStatus(rdr["STATUS"].ToString());
                                    }
                                    else
                                        lblStatus.Text = "无";
                                   
                                }
                                else
                                {
                                    TxtIsNull();
                                }
                            }
                            else
                            {
                                TxtIsNull();
                            }
                        } 
                    }
                }
                catch (Exception er)
                {
                    
                    //throw;
                }
                finally 
                {
                    if (bayNo != null)
                    {
                        if (lblSaddleNo.Text != "无")
                        {
                            if (lblSaddleNo.Text.IndexOf(bayNo) < -1)
                                 TxtIsNull();
                        }
                    }

                }
            }
        }

        private void TxtIsNull()
        {
            lblSaddleNo.Text = "无";
            lblCoilNo.Text = "无";
            lblAction.Text = "无";
            lblStatus.Text = "无";
        }

        /// <summary>
        /// 转换当前指令类型
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private string AnalysisAction(string action,string bayNo = null)
        {
            string Action = string.Empty;
            switch (action)
            {
                case line_To_Yard:
                    if (bayNo != null)
                        Action = "下车";
                    else
                        Action = "退料";
                    break;
                case yard_To_Line:
                    if (bayNo != null)
                        Action = "上车";
                    else
                        Action = "插料";
                    break;
                case line_To_Line:
                    Action = "倒鞍座";
                    break;
                default:
                    Action = "待定";
                    break;
            }
            return Action;
        }

        /// <summary>
        /// 转换当前指令状态
        /// </summary>
        /// <returns></returns>
        private string AnalysisStatus(string status)
        {
            string Status = string.Empty;
            switch (status)
            {
                case STATUS_EMPTY:
                    Status = "指令为空";
                    break;
                case STATUS_WMS_ORDER_CREATED:
                    Status = "指令确认中";
                    break;
                case STATUS_ORDER_SELECTED_BY_CRANE:
                    Status = "指令执行中";
                    break;
                default:
                    Status = "待定";
                    break;
            }
            return Status;

        }
        /// <summary>
        /// 钢卷回退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetStock_Click(object sender, EventArgs e)
        {
            if (saddleMethof.GetUnitAutoStatus(unitNo) == 1)
            {
                MessageBox.Show(unitNo + "自动上料停止才可以退料");
                return;
            }
            if (frmStockMessage == null || frmStockMessage.IsDisposed)
            {
                frmStockMessage = new FrmRetStockMessage();
                frmStockMessage.UnitNo = unitNo;
                frmStockMessage.BayNo = bayNo;
                frmStockMessage.Show();
            }
            else
            {
                frmStockMessage.WindowState = FormWindowState.Normal;
                frmStockMessage.Activate();
            }
           
        }
        /// <summary>
        /// 取消指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                tagDP.ServiceName = tagServiceName;
                tagDP.AutoRegist = true;
                TagValues.Clear();
                TagValues.Add(unitNo + "_SPEC_ACTION", null);
                tagDP.Attach(TagValues);

                StringBuilder sb = new StringBuilder();
                sb.Append("RESET");
                sb.Append(",");
                sb.Append("999999");
                sb.Append(",");
                sb.Append("999999");
                sb.Append(",");
                if (unitNo == "MC1" || unitNo == "MC2")
                {
                    sb.Append("999999");
                }
                else
                {
                    sb.Append("999999");
                }
                //sb.Append("999999");
                

                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要取消插料/退料指令操作吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        tagDP.SetData(unitNo + "_SPEC_ACTION", sb.ToString());
                        MessageBox.Show("指令已清除！");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                                                                            
                }
            }
            catch (Exception er)
            { 

            }

            
        }
        /// <summary>
        /// 插料指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertCoil_Click(object sender, EventArgs e)
        {
            if (unitNo == "D212")
            {
                MessageBox.Show("D212入口暂时不提供插料功能");
                return;
            }
            if (saddleMethof.GetUnitAutoStatus(unitNo) == 1)
            {
                MessageBox.Show(unitNo + "自动上料停止才可以插料");
                return;
            }
            if (frmInsertMessage == null || frmInsertMessage.IsDisposed)
            {
                frmInsertMessage = new FrmInsertCoilMessage();
                frmInsertMessage.UnitNo = unitNo;
                frmInsertMessage.BayNo = bayNo;
                frmInsertMessage.Show();
            }
            else
            {
                frmInsertMessage.WindowState = FormWindowState.Normal;
                frmInsertMessage.Activate();
            }
        }


    }
}
