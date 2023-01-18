using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
namespace UACSControls
{
    public partial class CoilEntryMode : UserControl
    {
        public CoilEntryMode()
        {
            InitializeComponent();
        }
        private UnitEntrySaddleInfo entrySaddleInfo = new UnitEntrySaddleInfo();

        private string unitNO = null;
        public string UnitNO
        {
            get { return unitNO; }
            set
            {
                unitNO = value;
                AutoOrSaddleNo(unitNO);
            }
        }

        /// <summary>
        /// 显示的当前模式
        /// </summary>
        public string LblAutoMode
        {
            get { return lblAutoMode.Text; }
            set { lblAutoMode.Text = value; }

        }


        public void AutoOrSaddleNo(string unitNo)
        {
            if (unitNO != null)
            {
                int entryMode = entrySaddleInfo.getEntryMode(unitNo);

                if (entryMode == 0)
                {
                    lblAutoMode.Text = unitNO + "自动上料停止";
                    btnAutoStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
                }
                else if (entryMode == 1)
                {
                    lblAutoMode.Text = unitNO + "自动上料开始";
                    btnAutoStart.BackColor = Color.LightSalmon;
                }
                else
                {
                    lblAutoMode.Text = unitNO + "上料错误";
                }
            }
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            entrySaddleInfo.setEntryMode(unitNO,1);
            AutoOrSaddleNo(unitNO);
            ParkClassLibrary.HMILogger.WriteLog("机组上料", unitNO + "机组开始上料", ParkClassLibrary.LogLevel.Info, unitNO + "机组");
        }

        private void btnAutoStop_Click(object sender, EventArgs e)
        {
            entrySaddleInfo.setEntryMode(unitNO, 0);
            AutoOrSaddleNo(unitNO);
            ParkClassLibrary.HMILogger.WriteLog("机组上料", unitNO + "机组停止上料", ParkClassLibrary.LogLevel.Info, unitNO + "机组");
        }

        



    }
}
