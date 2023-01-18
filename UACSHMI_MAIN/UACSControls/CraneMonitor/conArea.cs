using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
using UACSControls;

namespace UACSControls
{
    public partial class conArea : UserControl
    {
        //跳转画面
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;
        private Label lbl = new Label();
        private AreaInfo areaInfo = new AreaInfo();
        private AreaBase areaBase = new AreaBase();
        private AreaRowInfo rowInfo = new AreaRowInfo();
        private static FrmSaddleShow frmSaddleShow = null;
        private bool isCreateLbl = false;
        private string lblRuler;


        public conArea()
        {
            InitializeComponent();
            this.Load += conArea_Load;
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
        void conArea_Load(object sender, EventArgs e)
        {
            auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
        }



        public delegate void areaRefreshInvoke(AreaBase theSaddle, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, conArea _conArea);

        public void refreshControl(AreaBase theSaddle, long baySpaceX, long baySpaceY, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, conArea _conArea)
        {
            try
            {
                areaBase = theSaddle;

                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth) / Convert.ToDouble(baySpaceX);

                double location_X = 0;
                if (xAxisRight == true)
                {
                    location_X = Convert.ToDouble(theSaddle.X_Start) * xScale;
                }
                else
                {
                    location_X = Convert.ToDouble(baySpaceX - (theSaddle.X_End)) * xScale;
                }
                //计算y方向上的比例关系
                double yScale = Convert.ToDouble(panelHeight) / Convert.ToDouble(baySpaceY);

                double location_Y = 0;
                if (yAxisDown == true)
                {
                    location_Y = Convert.ToDouble(theSaddle.Y_Start) * yScale;
                }
                else
                {
                    location_Y = Convert.ToDouble(baySpaceY - (theSaddle.Y_End)) * yScale;
                }
                if (location_Y < 0)
                {
                    location_Y = 0;
                }

                //定位库区的坐标
                this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));

                //设置鞍座控件的宽度
                this.Width = Convert.ToInt32((theSaddle.X_End - theSaddle.X_Start) * xScale);
                //设置鞍座控件的高度
                this.Height = Convert.ToInt32((theSaddle.Y_End - theSaddle.Y_Start) * yScale);


                //当控件的宽小于1时 不显示控件
                if (this.Width < 1)
                {
                    this.Visible = false;
                }
                if (theSaddle.AreaType == 0)
                {
                    int saddleNum = areaInfo.getAreaSaddleNum(areaBase.AreaNo);
                    int saddleNoCoilNum = areaInfo.getAreaSaddleNoCoilNum(areaBase.AreaNo);
                    int saddleCoilNum = areaInfo.getAreaSaddleCoilNum(areaBase.AreaNo);

                    if (theSaddle.AreaNo.Contains("FIA7-A") || theSaddle.AreaNo.Contains("FIA7-E") || theSaddle.AreaNo.Contains("FIB8-A") || theSaddle.AreaNo.Contains("FIB8-E"))
                    {
                        this.SendToBack();
                    }

                    if (theSaddle.AreaNo.Contains("PACK"))
                    {                        
                        this.BackColor = Color.Red;
                    }

                    if (!theSaddle.AreaNo.Contains("PACK"))
                    {                       
                        if (theSaddle.AreaDoorSefeValue == 1 && theSaddle.AreaDoorReserveValue == 0)
                            this.BackColor = System.Drawing.Color.Red;
                        else if (theSaddle.AreaDoorSefeValue == 1 && theSaddle.AreaDoorReserveValue == 1)
                            this.BackColor = System.Drawing.Color.Blue;
                        else if (theSaddle.AreaDoorSefeValue == 0 && theSaddle.AreaDoorReserveValue == 1)
                            this.BackColor = System.Drawing.Color.Yellow;
                        else   
                            this.BackColor = System.Drawing.Color.MediumAquamarine;
                    }


                    if (!isCreateLbl)
                    {
                        lbl.Name = theSaddle.AreaNo;
                        lbl.BackColor = Color.MediumAquamarine;
                        lbl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        lbl.Width = 95;
                        lbl.Height = 100;
                        lbl.ForeColor = Color.Black;
                        if (!areaBase.AreaNo.Contains("Z02-F") && !areaBase.AreaNo.Contains("PACK") && !areaBase.AreaNo.Contains("Z03-C") && !areaBase.AreaNo.Contains("Z03-D"))
                        {
                            _conArea.Controls.Add(lbl);
                        }

                        List<string> list = rowInfo.getAreaNoRow(areaBase.AreaNo) as List<string>;
                        lblRuler = rowInfo.getAreaRowsInfo(list);
                        //foreach (int i in rowInfo.getRowColListByAreaNO(areaBase.AreaNo))
                        //{
                        //    LogManager.WriteProgramLog("RowColList>>>>>>>>" + i);
                        //}

                        isCreateLbl = true;

                    }

                    if (panel.Width < 1400)
                    {
                        lbl.Width = 60;
                        lbl.Height = 20;
                        lbl.Text = lblRuler;
                    }
                    else
                    {
                        lbl.Width = 95;
                        lbl.Height = 100;

                        lbl.Text = "鞍座总数：" + saddleNum + "\n"
                          + "白库位：   " + saddleNoCoilNum + "\n"
                          + "黑库位：   " + saddleCoilNum + "\n"
                          + "红库位：   " + (saddleNum - saddleNoCoilNum - saddleCoilNum) + "\n"
                          + lblRuler;

                        //if (!areaBase.AreaNo.Contains("Z02-P") && !areaBase.AreaNo.Contains("Z03-C") && !areaBase.AreaNo.Contains("Z03-D") && !areaBase.AreaNo.Contains("Z02-F"))
                        //{
                        //    int RowNum = getRowNum(areaBase.AreaNo);
                        //    label1.Visible = false;
                        //    if (saddleNoCoilNum < (RowNum + 3))
                        //    {
                        //        label1.Visible = true;
                        //        label1.Text = "当前白库位过少，请及时转库！";
                        //        label1.Location = new Point(this.Width / 2 - 90, this.Height - 20);
                        //    }

                        //}

                    }
                    //设置显示的颜色
                    //this.BackColor = Color.MediumAquamarine;

                    lbl.Location = new Point(this.Width / 2 - 30, this.Height / 2 - 20);
                    lbl.BackColor = this.BackColor;
                }
                else if (theSaddle.AreaType == 1)
                {
                    //this.BackColor = Color.CadetBlue;
                    this.BackColor = Color.LightSlateGray;
                }
                else
                {
                    //this.BackColor = Color.Beige;
                    this.BackColor = Color.MediumSlateBlue;
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteProgramLog(ex.Message);
                LogManager.WriteProgramLog(ex.StackTrace);
            }
        }
        public delegate void EventHandler_Saddle_Selected(AreaBase theSaddleInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;


        private void conArea_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                Graphics gr = e.Graphics;
                Pen p = new Pen(Color.Orange, 2);

                if (areaBase.AreaType == 0)
                {
                    if (!areaBase.AreaNo.Contains("PACK"))
                    {
                        if (areaBase.AreaNo.Contains("Z02-F"))
                        {
                            string tmp = "";
                            for (int i = 0; i < areaBase.Area_Name.Length; i++)
                            {
                                tmp += areaBase.Area_Name[i] + "\r\n";
                            }
                            gr.DrawString(tmp,
                                   new Font("微软雅黑", 9, FontStyle.Bold), Brushes.Black, new Point(5, this.Height / 2 - 20));

                            //        //创建矩形对象                左上角度座标                 宽   高  
                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                            gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                        }
                        else if (areaBase.AreaNo.Contains("Z03-C"))
                        {
                            //string tmp = "";
                            //for (int i = 0; i < areaBase.Area_Name.Length; i++)
                            //{
                            //    tmp += areaBase.Area_Name[i] + "\r\n";
                            //}
                            gr.DrawString(areaBase.Area_Name,
                                   new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Black, new Point(this.Width / 2 - 15, this.Height / 2 - 40), new StringFormat(StringFormatFlags.DirectionVertical));

                            //        //创建矩形对象                左上角度座标                 宽   高  
                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                            gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                        }
                        else if (areaBase.AreaNo.Contains("Z03-B"))
                        {
                            gr.DrawString(areaBase.Area_Name,
                               new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Black, new Point(this.Width / 2 - 40, 50));

                            //        //创建矩形对象                左上角度座标                 宽   高  
                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                            gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                        }
                        else
                        {
                            gr.DrawString(areaBase.Area_Name,
                               new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Black, new Point(this.Width / 2 - 30, 20));

                            //        //创建矩形对象                左上角度座标                 宽   高  
                            Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                            gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                        }

                    }
                    else if (areaBase.AreaNo.Contains("END-PACK"))
                    {
                        string tmp = "";
                        for (int i = 0; i < areaBase.Area_Name.Length; i++)
                        {
                            tmp += areaBase.Area_Name[i] + "\r\n";
                        }
                        gr.DrawString(tmp,
                               new Font("微软雅黑", 9, FontStyle.Bold), Brushes.Black, new Point(12, 5));

                        //        //创建矩形对象                左上角度座标                 宽   高  
                        Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                        gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                    }
                    else
                    {
                        //string tmp = "";
                        //for (int i = 0; i < areaBase.Area_Name.Length; i++)
                        //{
                        //    tmp += areaBase.Area_Name[i] + "\r\n";
                        //}
                        //gr.DrawString(tmp,
                        //       new Font("微软雅黑", 10, FontStyle.Bold), Brushes.Black, new Point(13, this.Height / 2));

                        //        //创建矩形对象                左上角度座标                 宽   高  
                        Rectangle rec = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
                        gr.DrawRectangle(new Pen(Color.Orange, 2), rec);
                    }
                }
                if (areaBase.AreaType == 1)
                {
                    if (areaBase.AreaNo.Contains("FIA"))
                    {
                        e.Graphics.DrawString(areaBase.Area_Name, new Font("微软雅黑", 10, FontStyle.Regular),
                        new SolidBrush(Color.White), 1, this.Height - 20);
                    }
                    else
                    {
                        e.Graphics.DrawString(areaBase.Area_Name, new Font("微软雅黑", 10, FontStyle.Regular),
                        new SolidBrush(Color.White), 1, 1);
                    }

                }
                else if (areaBase.AreaType == 4 || areaBase.AreaType == 5)
                {
                    if (areaBase.AreaNo.Contains("MC1"))
                    {
                        gr.DrawString(areaBase.Area_Name,
                        new Font("微软雅黑", 7F, FontStyle.Bold), Brushes.Black, new Point(0, 0));

                    }
                    else if (areaBase.AreaNo.Contains("D208"))
                    {
                        gr.DrawString(areaBase.Area_Name,
                        new Font("微软雅黑", 8F, FontStyle.Bold), Brushes.Black, new Point(this.Width, 0), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                    }
                    else if (areaBase.AreaNo.Contains("D108"))
                    {
                        gr.DrawString(areaBase.Area_Name,
                        new Font("微软雅黑", 8F, FontStyle.Bold), Brushes.Black, new Point(0, 0));
                    }

                    else
                    {
                        e.Graphics.DrawString(areaBase.Area_Name, new Font("微软雅黑", 9, FontStyle.Bold),
                        new SolidBrush(Color.Black), 0, 0, new StringFormat(StringFormatFlags.DirectionVertical));
                    }

                }

            }
            catch (Exception er)
            {

            }
        }

        private void conArea_Click(object sender, EventArgs e)
        {
            if (areaBase.AreaNo.IndexOf("D112") > -1 && areaBase.AreaType == 4)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要切换到D112机组入口跟踪画面吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    auth.OpenForm("08 D112机组入口");
                }
            }
            if (areaBase.AreaNo.IndexOf("D108") > -1 && areaBase.AreaType == 4)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要切换到D108机组入口跟踪画面吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    auth.OpenForm("06 D108机组入口");
                }
            }
            if (areaBase.AreaNo.IndexOf("D102") > -1 && areaBase.AreaType == 5)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要切换到D102机组出口跟踪画面吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    auth.OpenForm("05 D102机组出口");
                }
            }
            if (areaBase.AreaNo.IndexOf("D208") > -1 && areaBase.AreaType == 4)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要切换到D208机组入口跟踪画面吗？", "操作提示", btn);
                if (dr == DialogResult.OK)
                {
                    auth.OpenForm("07 D208机组入口");
                }
            }

            if (areaBase.AreaType == 0 && !areaBase.AreaNo.Contains("PACK"))
            {
                if (frmSaddleShow == null || frmSaddleShow.IsDisposed)
                {
                    frmSaddleShow = new FrmSaddleShow();
                    frmSaddleShow.AreaBase = areaBase;
                    frmSaddleShow.Show();
                }
                else
                {
                    frmSaddleShow.WindowState = FormWindowState.Normal;
                    frmSaddleShow.Activate();
                }
            }
        }

        public int getRowNum(string _AreaNo)
        {
            int RowNum = 0;
            switch (areaBase.AreaNo)
            {
                case "Z02-A":
                    RowNum = 19;
                    break;
                case "Z02-B":
                    RowNum = 19;
                    break;
                case "Z03-A":
                    RowNum = 30;
                    break;
                case "Z03-B":
                    RowNum = 30;
                    break;
                case "Z03-C":
                    RowNum = 4;
                    break;
                case "Z04-A":
                    RowNum = 19;
                    break;
                case "Z04-B":
                    RowNum = 19;
                    break;
                case "Z05-A":
                    RowNum = 27;
                    break;
                case "Z05-B":
                    RowNum = 27;
                    break;
                default:
                    break;

            }
            return RowNum;
        }
    }
}
