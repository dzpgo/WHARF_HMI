using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;


namespace UACSControls.UnitSaddle
{
    public partial class CoilUnitSaddleModel : UserControl
    {
        private Dictionary<string, CoilUnitSaddle> dicSaddleControls = new Dictionary<string, CoilUnitSaddle>();
        public Dictionary<string, CoilUnitSaddle> DicSaddleControls
        {
            get { return dicSaddleControls; }
            set { dicSaddleControls = value; }
        }
        private UnitSaddleTagRead lineSaddleTag = new UnitSaddleTagRead();
        private UnitSaddleMethod saddleMethod = null;
        public CoilUnitSaddleModel()
        {
            InitializeComponent();
        }
        #region Tag点读写方法
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
        #endregion

        public void init(string unitNo, int ExitEntrySaddleDefine ,bool flag)
        {
            //实例化机组鞍座处理类
            saddleMethod = new UnitSaddleMethod(unitNo, ExitEntrySaddleDefine, constData.tagServiceName);
            saddleMethod.ReadDefintion();
            lineSaddleTag.InitTagDataProvider(constData.tagServiceName);
            ArrayList arrayUnitSaddleNo = new ArrayList();
            UnitEntrySaddleInfo getUnitEntrySaddleInfo = new UnitEntrySaddleInfo();
            UnitExitSaddleInfo getUnitExitSaddleInfo = new UnitExitSaddleInfo();
            //入口值为0，获取入口鞍座
            if (ExitEntrySaddleDefine == 0)
            {
                getUnitEntrySaddleInfo.getEntrySaddleNO(unitNo, arrayUnitSaddleNo);
            }
            //出口值为1，获取出口鞍座
            else if (ExitEntrySaddleDefine == 1)
            {
                getUnitExitSaddleInfo.getExitSaddleNO(unitNo, arrayUnitSaddleNo);
            }
            int i = 1;
            int coilUnitSaddleLocationADD = 180;
            foreach (string saddleNo in arrayUnitSaddleNo)
            {
                //添加机组鞍座信息显示控件
                CoilUnitSaddle coilUnitSaddle = new CoilUnitSaddle();
                //coilUnitSaddle.ButtonDImage = null;
                //coilUnitSaddle.ButtonUImage = UACSControls.Resource1.lock_Red;
                //coilUnitSaddle.CoilBackColor = System.Drawing.Color.SkyBlue;
                //coilUnitSaddle.CoilFontColor = System.Drawing.Color.Black;
                //coilUnitSaddle.CoilId = "";
                //coilUnitSaddle.CoilLength = 16;
                //coilUnitSaddle.CoilStatus = -10;
                //coilUnitSaddle.Director = Baosight.ColdRolling.TcmControl.Direct.Horizontal;
                //coilUnitSaddle.DownEnable = true;
                //coilUnitSaddle.DownVisiable = false;
                coilUnitSaddle.Location = new System.Drawing.Point(6 + (coilUnitSaddleLocationADD * (i - 1)), 6);
                coilUnitSaddle.Name = "coilUnitSaddle" + i.ToString();
                coilUnitSaddle.PosName = saddleNo;
                //coilUnitSaddle.PosNo = i;
                coilUnitSaddle.Size = new System.Drawing.Size(120, 137);
                //coilUnitSaddle.SkidName = "skidControl";
                coilUnitSaddle.SkidSize = new System.Drawing.Size(150, 120);
                coilUnitSaddle.TextFont = new System.Drawing.Font("微软雅黑", 12F);
                //coilUnitSaddle.UpEnable = true;
                //coilUnitSaddle.UpVisiable = false;
                dicSaddleControls[coilUnitSaddle.PosName] = coilUnitSaddle;
                this.Controls.Add(coilUnitSaddle);

                //添加机组鞍座锁定/解锁按钮控件
                CoilUnitSaddleButton coilUnitSaddleButton = new CoilUnitSaddleButton();
                coilUnitSaddleButton.Location = new System.Drawing.Point(6 + (coilUnitSaddleLocationADD * (i - 1)), 150);
                coilUnitSaddleButton.MySaddleNo = "";
                coilUnitSaddleButton.MySaddleTagName = "";
                coilUnitSaddleButton.Name = "coilUnitSaddleButton" + i.ToString();
                coilUnitSaddleButton.Size = new System.Drawing.Size(120, 35);
                coilUnitSaddleButton.MySaddleNo = saddleNo;
                this.Controls.Add(coilUnitSaddleButton);

                i++;
            }

            setTagToCoilUnitSaddleButton();

            if (flag)
            {
                timer1.Enabled = true;
            }      
        }
        private void setTagToCoilUnitSaddleButton()
        {
            //把表中的tag名称赋值到控件中
            foreach (Control control in this.Controls)
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
            }
            lineSaddleTag.SetReady();
            //把实例化后的机组tag处理类装备每个控件
            foreach (Control control in this.Controls)
            {
                if (control is CoilUnitSaddleButton)
                {
                    CoilUnitSaddleButton t = (CoilUnitSaddleButton)control;
                    t.InitUnitSaddle(lineSaddleTag);
                }
            }
        }

        private void refreshCoilUnitSaddleButton()
        {
            lineSaddleTag.readTags();

            foreach (Control control in this.Controls)
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
        }


        private void getSaddleMessage()
        {
            saddleMethod.ReadDefintion();
            saddleMethod.getTagNameList();
            saddleMethod.getTagValues();
            foreach (Control control in this.Controls)
            {
                if (control is CoilUnitSaddle)
                {
                    CoilUnitSaddle conSaddle = (CoilUnitSaddle)control;
                    UnitSaddleBase theSaddleInfo = saddleMethod.DicSaddles[conSaddle.PosName];
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshCoilUnitSaddleButton();
            getSaddleMessage();
        }
    }
}
