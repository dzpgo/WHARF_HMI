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

namespace UACSControls
{
    public partial class conStockSaddle : UserControl
    {
        public conStockSaddle()
        {
            InitializeComponent();
            this.SetStyle(
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.ResizeRedraw |
               ControlStyles.AllPaintingInWmPaint, true);
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
        private SaddleBase mySaddleInfo = new SaddleBase();
        private Label lblRowNo = new Label();
        private Label lblColNo = new Label();      
        private Graphics gr;
        public delegate void EventHandler_Saddle_Selected(SaddleBase theSaddleInfo);
        public event EventHandler_Saddle_Selected Saddle_Selected;
        public void conInit()
        {
            try
            {
                this.panel1.MouseDown += new MouseEventHandler(conSaddle_visual_MouseUp);

            }
            catch (Exception ex)
            {
            }
        }

        void conSaddle_visual_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (Saddle_Selected != null)
                    {
                        Saddle_Selected(mySaddleInfo.Clone());
                    }
                }
                else
                {
                    FrmSaddleMetail FrmSaddleDetail = new FrmSaddleMetail();
                    FrmSaddleDetail.SaddleInfo = this.mySaddleInfo;
                    FrmSaddleDetail.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public delegate void saddlesRefreshInvoke(SaddleBase theSaddle, double X_Width, double Y_Height, AreaBase theArea, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, List<int> list = null);
        private AreaBase myArea;
        private Panel MyPanel;
        private bool isCreateRowLbl = false;
        private bool isCreateColLbl = false;
        private double location_x;
        private double location_y;
        private double xMax_7_1;
        private int height;

        private bool Coil_PlasticFlag = false;
        private void Get_Coil_PlasticFlag(string COIL_NO)
        {
            string sql = @"SELECT COIL_NO FROM UACS_YARDMAP_COIL_PLASTIC WHERE PLASTIC_FLAG = 1";
            using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
            {
                while (rdr.Read())
                {
                    if (COIL_NO == rdr["COIL_NO"].ToString().Trim())
                    {
                        Coil_PlasticFlag = true;
                    }
                }
            }
        }
        public void refreshControl(SaddleBase theSaddle, double X_Width, double Y_Height, AreaBase theArea, int panelWidth, int panelHeight, bool xAxisRight, bool yAxisDown, Panel panel, List<int> list = null)
        {
            try
            {
                //附对象
                mySaddleInfo = theSaddle;
                myArea = theArea;
                MyPanel = panel;
                height = panelHeight;

                //钢卷是否套袋
                Coil_PlasticFlag = false;

                //计算X方向上的比例关系
                double xScale = Convert.ToDouble(panelWidth - 40) / Convert.ToDouble(X_Width);
                double location_X = 0;
                if (xAxisRight == true)
                {
                    location_X = Convert.ToDouble((theSaddle.X_Center - theSaddle.SaddleWidth / 2) - theArea.X_Start) * xScale;
                }
                else
                {
                    location_X = Convert.ToDouble(theArea.X_End - (theSaddle.X_Center - theSaddle.SaddleWidth / 2)) * xScale;
                }

                //计算Y方向的比例关系
                //double yScale = Convert.ToDouble(panelHeight - 40) / Convert.ToDouble(Y_Height);     
                double yScale = Convert.ToDouble(panelHeight ) / Convert.ToDouble(Y_Height);
                double location_Y = 0;
                if (yAxisDown == true)
                {
                    location_Y = ((theSaddle.Y_Center  ) - theArea.Y_Start) * yScale;

                }
                else
                {
                    location_Y = (Y_Height - ((theSaddle.Y_Center + theSaddle.SaddleLength / 2) - theArea.Y_Start)) * yScale;
                }



                if (theSaddle.Stock_Status == 0 && theSaddle.Lock_Flag == 0) //无卷可用
                    this.BackColor = Color.White;
                else if (theSaddle.Stock_Status == 2 && theSaddle.Lock_Flag == 0) //有卷可用
                {
                    //区分机组
                    if (theSaddle.Next_Unit_No == "D108")
                        this.BackColor = Color.Blue;
                    else if (theSaddle.Next_Unit_No == "D208")
                        this.BackColor = Color.Purple;
                    else if (theSaddle.Next_Unit_No == "D112")
                        this.BackColor = Color.Green;
                    else
                        this.BackColor = Color.Black;

                    //套袋颜色显示
                    Get_Coil_PlasticFlag(theSaddle.Mat_No);
                    //if (Coil_PlasticFlag)
                    //{
                    //    this.BackColor = Color.Blue;
                    //}
                    if (Coil_PlasticFlag)
                    {
                        label1.Visible = true;
                        //label1.Location = new Point(this.Size.Width / 2, this.Size.Height / 2);
                        //label1.Text = "套";
                    }
                    else
                    {
                        label1.Visible = false;
                        //label1.Text = "";
                    }
                }

                else
                {
                    label1.Visible = false;
                    this.BackColor = Color.Red;
                }


                //修改鞍座控件的宽度和高度
                if (theArea.AreaNo.Contains("FIB8-C") || theArea.AreaNo.Contains("FIB8-B") || theArea.AreaNo.Contains("FIB8-E"))
                {
                    //this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.8);
                    //this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.7);
                    if (theSaddle.Layer_Num == 2)
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.6);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.45);
                    }
                    else
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.8);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.5);
                    }
                }
                else if (theArea.AreaNo.Contains("FIB8-D"))
                {
                    //this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.6);
                    //this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.7);
                    if (theSaddle.Layer_Num == 2)
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.4);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.4);
                    }
                    else
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.6);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.5);
                    }
                }
                else
                {
                    
                    //this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.5);
                    
                    if (theSaddle.Layer_Num == 2)
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale * 0.7);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.25);
                    }
                    else
                    {
                        this.Width = Convert.ToInt32(theSaddle.SaddleWidth * xScale);
                        this.Height = Convert.ToInt32(theSaddle.SaddleLength * yScale * 0.3);
                    }
                }              
                

                //定位库位鞍座的坐标
                if (theSaddle.Layer_Num == 2)
                {
                    this.Location = new Point(Convert.ToInt32(location_X + 3 ), Convert.ToInt32(location_Y) + 1);
                }
                else
                {
                    this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));
                }
                //this.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y));

                this.BringToFront();

                //if (theSaddle.SaddleNo.Substring(Convert.ToInt32(theSaddle.SaddleNo.Length.ToString()) - 1, 1) == "2")
                //    this.BorderStyle = BorderStyle.Fixed3D;
                //else
                this.BorderStyle = BorderStyle.None;

                gr = panel.CreateGraphics();
                panel.Paint += panel_Paint;
                this.panel1.Paint += conStockSaddle_Paint;

                toolTip1.IsBalloon = true;
                toolTip1.ReshowDelay = 0;
                toolTip1.SetToolTip(this.panel1, "材料号：" + theSaddle.Mat_No + "\r"
                                    + "库位：    " + theSaddle.SaddleNo.ToString()
                                    + "\r" + theSaddle.Row_No.ToString() + "行" + "-" + theSaddle.Col_No.ToString() + "列，" + "\r"
                                    + "坐标：" + "\r"
                                    + "X = " + theSaddle.X_Center + "\r"
                                    + "Y = " + theSaddle.Y_Center + "\r"
                                    + "Z = " + theSaddle.Z_Center + "\r"
                                    + "下道机组： " + theSaddle.Next_Unit_No + "\r"
                                   );


                //if (list != null)
                //{
                //    //给每行添加行展示
                //    if (theSaddle.SaddleNo.Count() == 8)
                //    {
                //        bool isIndex = false;
                //        bool isSpecialArea = false;
                //        string index = theSaddle.SaddleNo.Substring(theSaddle.SaddleNo.Count() - 2, 2);
                //        if (theSaddle.SaddleNo.Contains("FF"))
                //        {
                //            if (index == "01")
                //            {
                //                isIndex = true;
                //            }
                //        }
                //        else
                //        {
                //            if (index == "01" || (index == "10" && Convert.ToInt32(theSaddle.SaddleNo.Substring(3, 2)) < 32) && theSaddle.SaddleNo != "Z0514101" && theSaddle.SaddleNo != "Z0515101" || theSaddle.SaddleNo == "Z0514081" || theSaddle.SaddleNo == "Z0515081")
                //            {
                //                isIndex = true;
                //            }
                //        }


                //        foreach (var item in list)
                //        {

                //            if (isIndex)
                //            {
                //                if (!isCreateColLbl)
                //                {
                //                    lblColNo.AutoSize = true;
                //                    lblColNo.BackColor = SystemColors.Control;
                //                    lblColNo.SendToBack();
                //                    lblRowNo.Size = new System.Drawing.Size(24, 13);
                //                    lblRowNo.Name = theSaddle.SaddleNo + "Row";
                //                    //lblRowNo.Text = theSaddle.Row_No.ToString();
                //                    lblRowNo.Text = theSaddle.SaddleNo.Substring(4, 2);
                //                    lblRowNo.ForeColor = Color.Red;
                //                    lblRowNo.Font = new System.Drawing.Font("微软雅黑", 7F);
                //                    panel.Controls.Add(lblRowNo);                                  
                //                    isCreateColLbl = true;
                //                }
                //                //lblColNo.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y + this.Height - 1));
                //                //if (theSaddle.SaddleNo == "Z0507101" || theSaddle.SaddleNo == "Z0508101" || theSaddle.SaddleNo == "Z0509101")
                //                //{
                //                //    lblRowNo.Location = new Point(Convert.ToInt32(location_X - 20), Convert.ToInt32(location_Y + 20));
                //                //}
                //                //else
                //                //{
                //                    lblRowNo.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y + 25));
                //                //}


                //            }
                //        }
                //    }



                    //if (list[0] == 999)
                    //{
                    //    bool isIndex = false;
                    //    string index = theSaddle.SaddleNo.Substring(theSaddle.SaddleNo.Count() - 3, 1);
                    //    if (index == "1")
                    //    {
                    //        isIndex = true;
                    //    }
                    //    //给每行添加列展示
                    //    foreach (var item in list)
                    //    {

                    //        //if (item == theSaddle.Row_No)
                    //        //if (isIndex)
                    //        //{
                    //            if (!isCreateColLbl)
                    //            {
                    //                //lblColNo.AutoSize = true;
                    //                //lblColNo.BackColor = SystemColors.Control;
                    //                //lblColNo.SendToBack();
                    //                lblColNo.Size = new System.Drawing.Size(50, 13);
                    //                lblColNo.Name = theSaddle.SaddleNo + "Col";
                    //                //lblColNo.Text = theSaddle.Col_No.ToString();
                    //                lblColNo.Text = theSaddle.SaddleNo.Substring(6, 2);
                    //                lblColNo.ForeColor = Color.Blue;
                    //                lblColNo.Font = new System.Drawing.Font("微软雅黑", 7F);
                    //                panel.Controls.Add(lblColNo);
                    //                isCreateColLbl = true;
                    //            }
                    //            //lblColNo.Location = new Point(Convert.ToInt32(location_X), Convert.ToInt32(location_Y + this.Height - 1));
                    //            lblColNo.Location = new Point(Convert.ToInt32(location_X) - 20, Convert.ToInt32(location_Y));

                    //        //}
                    //    }
                    //}
                    //else if (list[0] == 999)
                    //{
                    //    gr = panel.CreateGraphics();
                location_x = location_X;
                location_y = location_Y;
                    //    //xMax_7_1 = XMax_7_1;
                    //    panel.Paint += panel_Paint;
                    //}
                    //else
                    //{ }
                //}
                //lblColNo.BringToFront();
                //this.BringToFront();
            }
            catch (Exception er)
            {
                throw;
            }
        }


        /// <summary>
        /// 写横坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void panel_Paint(object sender, PaintEventArgs e)
        {

            try
            {
                if (mySaddleInfo != null)
                {
                    Pen p1 = new Pen(Color.Blue, 1);

                    if (mySaddleInfo.SaddleNo.Substring(6, 2) == "01")
                    {
                        string row;
                        
                            row = mySaddleInfo.SaddleNo.Substring(4, 2);
                            gr.DrawString(row, new Font("微软雅黑", 12, FontStyle.Bold), Brushes.Green,
                                new Point(Convert.ToInt32(location_x), height - 25));                                           
                    }

                }
            }
            catch (Exception er)
            {

                LogManager.WriteProgramLog(er.Message, er.StackTrace);
            }
        }


        /// <summary>
        /// 写纵坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conStockSaddle_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                string col = mySaddleInfo.SaddleNo.Substring(6, 2);
                Graphics gr = this.CreateGraphics();
                StringFormat str = new StringFormat();
                str.Alignment = StringAlignment.Center; //居中
                Rectangle 矩形 = new Rectangle(0, 0, this.panel1.Width, this.panel1.Height);
                Font size = new Font("微软雅黑", 6F, FontStyle.Bold);
                Brush br = Brushes.Green;
                gr.DrawString(col, size, br, 矩形, str);
            }
            catch (Exception er)
            {
                LogManager.WriteProgramLog(er.Message, er.StackTrace);
            }
            
        }
    }
}
