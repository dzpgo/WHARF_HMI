using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.TagService;

namespace UACSControls
{
    public partial class InitForm_babyCar : Form
    {
        private Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDataProvider = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new DataCollection<object>();
        private static ManualResetEvent mre = new ManualResetEvent(false);


        private string craneNO = string.Empty;
        public string CraneNO
        {
            get { return craneNO; }
            set { craneNO = value; }
        }

        public InitForm_babyCar()
        {
            InitializeComponent();
        }
        public InitForm_babyCar(string str)
        {
            try
            {
                InitializeComponent();
                label1.Text = string.Format("{0}{1}", str, label1.Text);
                //this.TopMost = true;
                this.Load += InitForm_babyCar_Load;
            }
            catch (System.Threading.ThreadInterruptedException ex)
            {
               
            }

        }

        void InitForm_babyCar_Load(object sender, EventArgs e)
        {
            this.Shown += InitForm_babyCar_Shown;
            label1.Click += label1_Click;
        }

        void InitForm_babyCar_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0.7; 
        }

        void label1_Click(object sender, EventArgs e)
        {
            tagDataProvider.ServiceName = "iplature";
            tagDataProvider.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("BABY_CAR_STOP_" + craneNO, null);
            tagDataProvider.Attach(TagValues);

            tagDataProvider.SetData("BABY_CAR_STOP_" + CraneNO, "0");
            this.Close();
        }
        delegate void queryTimer_TickDelegate1();

        public void Form1_Closedelegate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new queryTimer_TickDelegate1(Form1_Closedelegate), new object[] { });
                return;
            }
            this.Close();
        }
        
    }
}
