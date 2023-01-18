﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using UACSControls;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;
namespace UACSView
{
    public partial class VIEW_D102ExitLineSaddle : FormBase
    {
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;
        public VIEW_D102ExitLineSaddle()
        {
            InitializeComponent();
            //反射获取双缓存
            Type dgvType = this.dgvExitSaddleInfo.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvExitSaddleInfo, true, null);

            this.Load += VIEW_D102ExitLineSaddle_Load;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        private UnitSaddleTagRead lineSaddleTag = new UnitSaddleTagRead();
        private UnitSaddleMethod saddleMethod = null;
        private UnitExitSaddleInfo exitSaddleInfo = new UnitExitSaddleInfo();

        private Dictionary<string, CoilUnitSaddle> dicSaddleControls = new Dictionary<string, CoilUnitSaddle>();      
        private bool tabActived = true;

        private const string AREA_SAFE_EXIT_D102 = "AREA_SAFE_D102_EXIT";

        public long theValue;
        public long thevalue
        {
            get { return theValue; }
            set { thevalue = value; }
        }

        void VIEW_D102ExitLineSaddle_Load(object sender, EventArgs e)
        {
            auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
            tagDataProvider.ServiceName = "iplature";
            //绑定鞍座控件
            dicSaddleControls["D102WC1A08"] = coilUnitSaddle12;
            dicSaddleControls["D102WC1A09"] = coilUnitSaddle13;
            dicSaddleControls["D102WC1A10"] = coilUnitSaddle14;
            dicSaddleControls["D102WC1A11"] = coilUnitSaddle15;
            dicSaddleControls["D102WC1A14"] = coilUnitSaddle16;
            dicSaddleControls["D102WC1A15"] = coilUnitSaddle17;
            dicSaddleControls["D102WC1A16"] = coilUnitSaddle18;
            dicSaddleControls["D102WC1A17"] = coilUnitSaddle19;

            coilUnitStatus1.InitTagDataProvide(constData.tagServiceName);
            coilUnitStatus1.MyStatusTagName = AREA_SAFE_EXIT_D102;

            //实例化机组鞍座处理类
            saddleMethod = new UnitSaddleMethod(constData.UnitNo_1,constData.ExitSaddleDefine,constData.tagServiceName);
            saddleMethod.ReadDefintion();
            
            lineSaddleTag.InitTagDataProvider(constData.tagServiceName);

            coilUnitSaddleButton1.MySaddleNo = "D102WC1A08";
            coilUnitSaddleButton2.MySaddleNo = "D102EXIT0013";
            coilUnitSaddleButton3.MySaddleNo = "D102EXIT0014";
            //coilUnitSaddleButton4.MySaddleNo = "D102EXIT0019";
            coilUnitSaddleButton5.MySaddleNo = "D102EXIT0020";
            coilUnitSaddleButton6.MySaddleNo = "D102EXIT0021";
            coilUnitSaddleButton7.MySaddleNo = "D102WC1A17";
            //coilUnitSaddleButton8.MySaddleNo = "D102EXIT0015";

            

            //coilUnitSaddleButton0.MySaddleTagName = "D401_EXIT_00_LOCK_REQUEST";

            //把表中的tag名称赋值到控件中
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                //添加解锁鞍座控件
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (saddleMethod.DicSaddles.ContainsKey(t.MySaddleNo))
                    {
                        UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[t.MySaddleNo];
                        if (!string.IsNullOrEmpty(theSaddleInfo.TagAdd_LockRequest) && theSaddleInfo.TagAdd_LockRequest != "")
                        {
                            t.MySaddleTagName = theSaddleInfo.TagAdd_LockRequest;
                            lineSaddleTag.AddTagName(theSaddleInfo.TagAdd_LockRequest);
                            
                        }
                    }
                }
                //添加机组状态控件
                if (control is CoilUnitStatus)
                {
                    CoilUnitStatus t = (CoilUnitStatus)control;
                    if (!string.IsNullOrEmpty(t.MyStatusTagName) && t.MyStatusTagName != "")
                    {
                        lineSaddleTag.AddTagName(t.MyStatusTagName);
                    }
                }
            }

            lineSaddleTag.SetReady();
            //把实例化后的机组tag处理类装备每个控件
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    t.InitUnitSaddle(lineSaddleTag);
                }
            }

            exitSaddleInfo.getExitSaddleDt(dgvExitSaddleInfo,constData.UnitNo_1);
            //是否开启定时器
            timer_LineSaddleControl.Enabled = true;
            //设定刷新时间
            timer_LineSaddleControl.Interval = 3000;
            GetFirstArea();
        }

        private void timer_LineSaddleControl_Tick(object sender, EventArgs e)
        {
            //不在当前页面停止刷新
            if (tabActived == false)
            {
                return;
            }

            coilUnitStatus1.RefreshControl();
            //if (thevalue == 1)
            //{
            //    this.panel1.BackColor = Color.Transparent;
            //}
            //else
            //{
            //    this.panel1.BackColor = Color.Red;
            //}
            lineSaddleTag.readTags();
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    if (!string.IsNullOrEmpty(t.MySaddleTagName) && t.MySaddleTagName != "")
                    {
                        CoilUnitSaddleButton.delRefresh_Button_Light del = t.refresh_Button_Light;
                        del(lineSaddleTag.getTagValue(t.MySaddleTagName));
                    }                         
                }
            }
            foreach (Control control in panel2.Controls)
            {
                if (control is CoilUnitStatus)
                {
                    CoilUnitStatus t = (CoilUnitStatus)control;
                    if (!string.IsNullOrEmpty(t.MyStatusTagName) && t.MyStatusTagName != "")
                    {
                        CoilUnitStatus.delSetColor del = t.SetColor;
                        del(lineSaddleTag.getTagValue(t.MyStatusTagName));
                    }
                }
            }

            exitSaddleInfo.getExitSaddleDt(dgvExitSaddleInfo, constData.UnitNo_1);

            getSaddleMessage();
            GetFirstArea();
            GetNextUnit();
        }


        private void getSaddleMessage()
        {
            saddleMethod.ReadDefintion();
            saddleMethod.getTagNameList();
            saddleMethod.getTagValues();

            foreach (string theL2SaddleName in dicSaddleControls.Keys)
            {
                if (saddleMethod.DicSaddles.ContainsKey(theL2SaddleName))
                {
                    CoilUnitSaddle conSaddle = dicSaddleControls[theL2SaddleName];
                    //CoilUnitSaddleButton SaddleButton = dicUnitSaddleButton[theL2SaddleName];
                    UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[theL2SaddleName];
                    //鞍座反馈
                    if (theSaddleInfo.TagVal_IsLocked == 1)
                        conSaddle.UpVisiable = true;                   
                    else
                        conSaddle.UpVisiable = false;

                    //鞍座占位
                    if (theSaddleInfo.TagVal_IsOccupied == 1)
                        conSaddle.CoilBackColor = Color.Green;
                    else
                        conSaddle.CoilBackColor = Color.LightGray;
                        

                    //钢卷号
                    if (theSaddleInfo.CoilNO != string.Empty)
                    {
                        conSaddle.CoilId = theSaddleInfo.CoilNO;
                        conSaddle.CoilStatus = 2;
                    }
                    else
                    {
                        conSaddle.CoilId = "";
                        conSaddle.CoilStatus = -10;
                    }
                }

            }
        }

        //需要引用formbase
        void MyTabActivated(object sender, EventArgs e)
        {
            tabActived = true;
        }
        void MyTabDeactivated(object sender, EventArgs e)
        {
            tabActived = false;
        }


        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

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

        private string SelectNextUnio;
        private void selectUnio()
        {
            SelectNextUnio = string.Empty;
            if (checkBoxAll.Checked == true)
            {
                SelectNextUnio += "ALL";
                SelectNextUnio += ",";
            }
            if (checkBoxD122.Checked==true)
            {
                SelectNextUnio += "D122";
                SelectNextUnio += ",";
            }
            if(checkBoxD212.Checked == true)
            {
                SelectNextUnio += "D212";
                SelectNextUnio += ",";
            }
            if(checkBoxD112.Checked == true)
            {
                SelectNextUnio += "D112";
                SelectNextUnio += ",";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectUnio();
            inDatas["D102EXIT_TO_B_NEXT_UNIT_NO"] = SelectNextUnio;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已选择下道机组！");
            checkBoxD122.Checked = false;
            checkBoxD212.Checked = false;
            checkBoxD112.Checked = false;
            checkBoxAll.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectNextUnio = "";
            inDatas["D102EXIT_TO_B_NEXT_UNIT_NO"] = SelectNextUnio;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已清空下道机组！");
            checkBoxD122.Checked = false;
            checkBoxD212.Checked = false;
            checkBoxD112.Checked = false;
            checkBoxAll.Checked = false;
        }

        //获取当前选择的下道机组
        private void GetNextUnit()
        {
            List<string> lstAdress = new List<string>();
            lstAdress.Clear();
            lstAdress.Add("D102EXIT_TO_B_NEXT_UNIT_NO");
            arrTagAdress = lstAdress.ToArray<string>();
            readTags();
            labelNextUnit.Text = get_value("D102EXIT_TO_B_NEXT_UNIT_NO");
            if (labelNextUnit.Text.Contains("ALL"))
            {
                labelNextUnit.Text = "全部机组";
            }
        }

        private void GetFirstArea()
        {
            try
            {
                List<string> lstAdress = new List<string>();
                lstAdress.Clear();
                lstAdress.Add("D102EXIT_B_TO_Z04_OR_Z05");
                lstAdress.Add("D102EXIT_B_TO_Z02_OR_Z03");
                arrTagAdress = lstAdress.ToArray<string>();
                readTags();
                string firstArea = get_value("D102EXIT_B_TO_Z04_OR_Z05");
                string firstArea1 = get_value("D102EXIT_B_TO_Z02_OR_Z03");
                if (firstArea == "Z04")
                {
                    btnZ04.Enabled = false;
                    btnZ05.Enabled = true;
                    btnZ04.BackColor = Color.Green;
                    btnZ05.BackColor = Color.Gray;
                }
                else if (firstArea == "Z05")
                {
                    btnZ05.Enabled = false;
                    btnZ04.Enabled = true;
                    btnZ05.BackColor = Color.Green;
                    btnZ04.BackColor = Color.Gray;
                }
                else
                {
                    btnZ05.Enabled = true;
                    btnZ04.Enabled = true;
                    btnZ05.BackColor = Color.Gray;
                    btnZ04.BackColor = Color.Gray;
                }

                if (firstArea1 == "Z02")
                {
                    btnZ02.Enabled = false;
                    btnZ03.Enabled = true;
                    btnZ02.BackColor = Color.Green;
                    btnZ03.BackColor = Color.Gray;
                }
                else if (firstArea1 == "Z03")
                {
                    btnZ03.Enabled = false;
                    btnZ02.Enabled = true;
                    btnZ03.BackColor = Color.Green;
                    btnZ02.BackColor = Color.Gray;
                }
                else
                {
                    btnZ02.Enabled = true;
                    btnZ03.Enabled = true;
                    btnZ02.BackColor = Color.Gray;
                    btnZ03.BackColor = Color.Gray;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnZ02_Click(object sender, EventArgs e)
        {
            string firstArea = "Z02";
            inDatas["D102EXIT_B_TO_Z02_OR_Z03"] = firstArea;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已选择优先库区Z02！");
        }

        private void btnZ03_Click(object sender, EventArgs e)
        {
            string firstArea = "Z03";
            inDatas["D102EXIT_B_TO_Z02_OR_Z03"] = firstArea;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已选择优先库区Z03！");
        }
        
        private void btnZ04_Click(object sender, EventArgs e)
        {
            string firstArea = "Z04";
            inDatas["D102EXIT_B_TO_Z04_OR_Z05"] = firstArea;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已选择优先库区Z04！");
        }

        private void btnZ05_Click(object sender, EventArgs e)
        {
            string firstArea = "Z05";
            inDatas["D102EXIT_B_TO_Z04_OR_Z05"] = firstArea;
            tagDataProvider.Write2Level1(inDatas, 1);
            MessageBox.Show("已选择优先库区Z05！");
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxD122.Checked = false;
            checkBoxD212.Checked = false;
            checkBoxD112.Checked = false;
        }

        private void checkBoxD112_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAll.Checked = false;
        }

        private void checkBoxD122_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAll.Checked = false;
        }

        private void checkBoxD212_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAll.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            auth.OpenForm("04 B跨监控");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            auth.OpenForm("03 A跨监控");
        }

        

        
    }
}
