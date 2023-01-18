using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using UACSPopupForm;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
using Baosight.iSuperframe.TagService;
using Microsoft.VisualBasic;

namespace UACSControls
{
    public partial class conCrane : UserControl
    {
       // private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = null;
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth = null;
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        public conCrane()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲   
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
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
        private  Label lblCraneNo = new Label();
        private bool isCraneLbl = false;
        private CraneStatusBase cranePLCStatusBase = new CraneStatusBase();

        Baosight.iSuperframe.TagService.DataCollection<object> inDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();

        private string[] arrTagAdress;
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

        private string get_value(string tagName)
        {
            string theValue = string.Empty;
            object valueObject = null;
            try
            {
                valueObject = inDatas[tagName];
                theValue = Convert.ToString(valueObject);
            }
            catch
            {
                valueObject = null;
            }
            return theValue; ;
        }

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


        private string craneNO = string.Empty;
        //step2
        public string CraneNO
        {
            get { return craneNO; }
            set
            {
                craneNO = value;
                this.ContextMenuStrip = contextMenuStrip1;
            }
        }

        //step3
        public delegate void RefreshControlInvoke(CraneStatusBase _cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, long craneWith, Panel panel);

        public void RefreshControl(CraneStatusBase _cranePLCStatusBase, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown,long craneWith,Panel panel)
        {
            try
            {
                cranePLCStatusBase = _cranePLCStatusBase;
                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth) / Convert.ToDouble(baySpaceX);

                //计算控件行车中心X，区分为X坐标轴向左或者向右
                double X = 0;
                double location_Crane_X = 0;
                double location_Crab_X = 0;
                if (xAxisRight == true)
                {
                    X = Convert.ToDouble(_cranePLCStatusBase.XAct) * xScale;
                    //location_Crane_X = Convert.ToDouble(_cranePLCStatusBase.XAct - craneWith / 2) * xScale;
                    location_Crane_X = Convert.ToDouble(X - (craneWith / 2) * xScale);
                    location_Crab_X = 0;//在行车panel内，所以永远为0
                }
                else
                {
                    X = (Convert.ToDouble(baySpaceX) - Convert.ToDouble(_cranePLCStatusBase.XAct)) * xScale;
                    //location_Crane_X = Convert.ToDouble(_cranePLCStatusBase.XAct + craneWith / 2) * xScale;
                    location_Crane_X = Convert.ToDouble(X - (craneWith / 2) * xScale);
                    location_Crab_X = 0;//在行车panel内，所以永远为0
                }

                //计算Y方向的比例关系
                double yScale = Convert.ToDouble(panelHeight) / Convert.ToDouble(baySpaceY);

                //计算行车中心Y 区分Y坐标轴向上或者向下
                double Y = 0;
                double location_Crane_Y = 0;
                double location_Crab_Y = 0;
                if (yAxisDown == true)
                {
                    Y = Convert.ToDouble(_cranePLCStatusBase.YAct) * yScale;
                    location_Crane_Y = 0;
                    location_Crab_Y = Y - panelCrab.Height / 2;
                }
                else
                {
                    Y = (Convert.ToDouble(baySpaceY) - Convert.ToDouble(_cranePLCStatusBase.YAct)) * yScale;
                    location_Crane_Y = 0;
                    location_Crab_Y = Y - panelCrab.Height / 2;
                }




                //修改行车大车控件的宽度和高度
                this.Width = Convert.ToInt32(craneWith * xScale);
                this.Height = panelHeight;//大车的高度直接等于panel的高度

                //定位大车的坐标
                this.Location = new Point(Convert.ToInt32(location_Crane_X), Convert.ToInt32(location_Crane_Y));               


                //修改小车的宽度
                panelCrab.Width = this.Width;

                //定位小车的坐标
                panelCrab.Location = new Point(Convert.ToInt32(location_Crab_X), Convert.ToInt32(location_Crab_Y));
                panelCrab.BringToFront();

                //无卷显示无卷标记
                if (_cranePLCStatusBase.HasCoil == 0)
                {
                    this.panelCrab.BackgroundImage = global::UACSControls.Resource1.imgCarNoCoil;
                }
                //有卷显示有卷标记
                else if (_cranePLCStatusBase.HasCoil == 1)
                {
                    this.panelCrab.BackgroundImage = global::UACSControls.Resource1.imgCarCoil;
                }

                this.BringToFront();
            }
            catch (Exception ex)
            {
                LogManager.WriteProgramLog(ex.Message);
                LogManager.WriteProgramLog(ex.StackTrace);
            }
        }

        private void panelCrane_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawString(cranePLCStatusBase.CraneNO.ToString(), 
                new Font("微软雅黑", 7, FontStyle.Bold), 
                Brushes.White, new Point(8, this.Height - 13));

        }

        private void ToolStrip_DelCraneOrder_Click(object sender, EventArgs e)
        {
            if (cranePLCStatusBase.HasCoil == 1)
            {
                MessageBox.Show("行车有卷状态禁止清除指令");
                return;
            }
            if(cranePLCStatusBase.CraneStatus == 40 && cranePLCStatusBase.ControlMode == 4)
            {
                MessageBox.Show("自动模式空钩下降状态禁止清除指令");
                return;
            }
             
            DialogResult ret = MessageBox.Show("确定要清空" + craneNO + "行车的指令吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.Cancel)
                return;

            if (CreateManuOrder.isDelCraneOrder(craneNO))
            {
                MessageBox.Show(craneNO + "指令已清空");
                ParkClassLibrary.HMILogger.WriteLog("清空指令", craneNO + "行车清空指令", ParkClassLibrary.LogLevel.Info, "主监控画面");
            }
            else
            {
                MessageBox.Show(craneNO + "指令清空失败");
            }


        }

        private void panelCrane_DoubleClick(object sender, EventArgs e)
        {
            if ( craneNO != string.Empty)
            {
                auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
                
                    string bayno = null;
                    switch (craneNO)
                    {                       
                        case "1":
                        case "2":
                            bayno = "A跨";
                            break;
                        case "4":
                        case "3":
                            bayno = "B跨";
                            break;
                        default:
                            bayno = null; ;
                            break;
                    }
                    if (bayno != null)
                    {
                        if (auth.IsOpen("01 行车指令配置"))
                        {
                            auth.CloseForm("01 行车指令配置");

                            auth.OpenForm("01 行车指令配置", true, bayno, craneNO);
                        }
                        else
                        {
                            auth.OpenForm("01 行车指令配置", true, bayno, craneNO);
                        }
                    }
                
            }
        }

        private void ToolStrip_YardToTard_Click(object sender, EventArgs e)
        {
           FrmYardToYardRequest yard = new FrmYardToYardRequest();
            yard.CraneNo = craneNO;
            yard.Show();
        }

        private void 登车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult ret = MessageBox.Show("确定要" + craneNO + "行车回登车位吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (ret == DialogResult.Cancel)
            {
                return;
            }

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("BOARDING_" + craneNO, null);
            tagDP.Attach(TagValues);
          
            tagDP.SetData("BOARDING_" + craneNO, "1");
            ParkClassLibrary.HMILogger.WriteLog("登车", craneNO + "行车登车", ParkClassLibrary.LogLevel.Info, "主监控画面");
        }
       

        private void 小车方向ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要切换3-2小车方向吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(ret == DialogResult.Cancel)
            {
                return;
            }

            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("BOARDING_" + craneNO, null);
            tagDP.Attach(TagValues);

            if(小车方向ToolStripMenuItem.Text.Contains ("连退"))
            {
                tagDP.SetData("STOP_DIRECTION_3_2", "1");
                this.小车方向ToolStripMenuItem.Text = this.小车方向ToolStripMenuItem.Text.Replace("连退方向", "镀锌方向");
                MessageBox.Show("小车已切换到镀锌方向");
                ParkClassLibrary.HMILogger.WriteLog("切换小车方向", craneNO + "行车小车切换到镀锌方向", ParkClassLibrary.LogLevel.Info, "主监控画面");
            }
            else
            {
                tagDP.SetData("STOP_DIRECTION_3_2", "0");
                this.小车方向ToolStripMenuItem.Text = this.小车方向ToolStripMenuItem.Text.Replace("镀锌方向", "连退方向");
                MessageBox.Show("小车已切换到连退方向");
                ParkClassLibrary.HMILogger.WriteLog("切换小车方向", craneNO + "行车小车切换到连退方向", ParkClassLibrary.LogLevel.Info, "主监控画面");
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(craneNO != "3_2")
            {
                this.小车方向ToolStripMenuItem.Visible = false;
            }

            List<string> lstAdress = new List<string>();
            lstAdress.Clear();
            lstAdress.Add("STOP_DIRECTION_3_2");
            arrTagAdress = lstAdress.ToArray<string>();
            readTags();
            string Dir = get_value("STOP_DIRECTION_3_2");
            if(Dir == "1")
            {
                this.小车方向ToolStripMenuItem.Text = "镀锌方向";
            }
            else
            {
                this.小车方向ToolStripMenuItem.Text = "连退方向";
            }
        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要行车排水开启吗？", "操作提示", btn);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                string sql = @"update CRANE_PIPI set STATUS = 'TO_BE_START',TYPE = '0' ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show(craneNO + "行车排水开启");
                ParkClassLibrary.HMILogger.WriteLog("行车排水", "排水开启：" + craneNO, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要行车排水关闭吗？", "操作提示", btn);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                string sql = @"update CRANE_PIPI set STATUS = 'TO_BE_END',TYPE = '0' ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show(craneNO + "行车排水关闭");
                ParkClassLibrary.HMILogger.WriteLog("行车排水", "排水关闭：" + craneNO, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 开启ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要登机请求开启吗？", "操作提示", btn);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                string sql = @"update CRANE_PIPI set STATUS = 'TO_BE_START',TYPE = '1' ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show(craneNO + "登机请求开启");
                ParkClassLibrary.HMILogger.WriteLog("登机请求", "登机请求：" + craneNO, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void 关闭ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要登机请求关闭吗？", "操作提示", btn);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                string sql = @"update CRANE_PIPI set STATUS = 'TO_BE_END',TYPE = '1' ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show(craneNO + "登机请求关闭");
                ParkClassLibrary.HMILogger.WriteLog("登机请求", "登机关闭：" + craneNO, ParkClassLibrary.LogLevel.Info, this.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT STATUS,TYPE FROM CRANE_PIPI ";
                sql += " WHERE CRANE_NO = '" + craneNO + "'";
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        if (rdr["TYPE"].ToString() == "1")
                        {
                            this.行车排水ToolStripMenuItem.Text = "行车排水：已关";
                            if (rdr["STATUS"].ToString() == "ENDED" || rdr["STATUS"].ToString() == "TO_BE_END")
                            {
                                this.登车请求ToolStripMenuItem.Text = "登机请求：已关";
                                this.开启ToolStripMenuItem.Enabled = true;
                                this.关闭ToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                this.登车请求ToolStripMenuItem.Text = "登机请求：已开";
                                this.开启ToolStripMenuItem.Enabled = false;
                                this.关闭ToolStripMenuItem.Enabled = false;
                            }
                        }
                        else
                        {
                            this.登车请求ToolStripMenuItem.Text = "登机请求：已关";
                            if (rdr["STATUS"].ToString() == "ENDED" || rdr["STATUS"].ToString() == "TO_BE_END")
                            {
                                this.行车排水ToolStripMenuItem.Text = "行车排水：已关";
                                this.开启ToolStripMenuItem1.Enabled = true;
                                this.关闭ToolStripMenuItem1.Enabled = true;
                            }
                            else
                            {
                                this.行车排水ToolStripMenuItem.Text = "行车排水：已开";
                                this.开启ToolStripMenuItem1.Enabled = false;
                                this.关闭ToolStripMenuItem1.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void 高度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                //必须输对密码才能进行查看信息
                FrmYordToYordConfPassword password = new FrmYordToYordConfPassword();
                //password.Remark = "修正行车高度/角度";
                password.CraneNO = craneNO;
                DialogResult ret = password.ShowDialog();
                if (ret != DialogResult.Cancel)
                {
                    if (ret == DialogResult.OK)
                    {
                        string s = Interaction.InputBox("输入高度编码值（单位mm）", craneNO + "行车高度矫正", "", -1, -1);
                        if (string.IsNullOrEmpty(s))
                            return;
                        //行车号,高度值,高度确认,角度值,角度确认,0,0,0（后三个备用点）;
                        string tagValue = craneNO + "|" + s ;
                        Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                        wirteDatas[craneNO + "_DownLoadOrder_Z"] = tagValue;
                        tagDataProvider.SetData(craneNO + "_DownLoadOrder_Z", tagValue);
                        ParkClassLibrary.HMILogger.WriteLog("矫正高度", "矫正高度：" + craneNO + "，修改高度值：" + s, ParkClassLibrary.LogLevel.Info, this.Text);
                    }
                    else
                    {
                        MessageBox.Show("验证码错误！");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void 角度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                //必须输对密码才能进行查看信息
                FrmYordToYordConfPassword password = new FrmYordToYordConfPassword();
                //password.Remark = "修正行车高度/角度";
                password.CraneNO = craneNO;
                DialogResult ret = password.ShowDialog();
                if (ret != DialogResult.Cancel)
                {
                    if (ret == DialogResult.OK)
                    {
                        string s = Interaction.InputBox("输入角度编码值", craneNO + "行车角度矫正", "", -1, -1);
                        if (string.IsNullOrEmpty(s))
                            return;
                        //行车号,高度值,高度确认,角度值,角度确认,0,0,0（后三个备用点）;
                        string tagValue = craneNO + ",0,0," + s + ",1,0,0,0";
                        Baosight.iSuperframe.TagService.DataCollection<object> wirteDatas = new Baosight.iSuperframe.TagService.DataCollection<object>();
                        wirteDatas["RESET_CRANE_Z"] = tagValue;
                        tagDataProvider.SetData("RESET_CRANE_Z", tagValue);
                        ParkClassLibrary.HMILogger.WriteLog("矫正角度", "矫正角度：" + craneNO + "，修改角度值：" + s, ParkClassLibrary.LogLevel.Info, this.Text);
                    }
                    else
                    {
                        MessageBox.Show("验证码错误！");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

       

       
    }
}
