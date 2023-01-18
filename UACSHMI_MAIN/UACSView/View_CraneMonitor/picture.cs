using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSView.View_CraneMonitor
{
    public partial class picture : Form
    {
        public picture()
        {
            InitializeComponent();
        }      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picture_Load(object sender, EventArgs e)
        {
            Rectangle ret = Screen.GetWorkingArea(this);
            this.pictureBox1.ClientSize = new Size(ret.Width, ret.Height);
        }
    }
}
