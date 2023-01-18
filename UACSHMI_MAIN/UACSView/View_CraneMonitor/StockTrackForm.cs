using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACS;

namespace UACS_CRANETASK
{
    public partial class StockTrackForm : FormBase
    {
        private static Baosight.iSuperframe.Common.IDBHelper dBHelper = null;
        public StockTrackForm()
        {
            InitializeComponent();
            dBHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("zjcangchu");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value; ;
            string timespan1 = ViewHelper.GenTimeSpanSQL( dt, "REC_TIME");

            DateTime dt2 = dateTimePicker2.Value;
            string timespan2 = ViewHelper.GenTimeSpanSQL(dt, dt2, "REC_TIME");
            try
            {
                string sql = "select * from FV_STOCKHISVIEW where " + timespan2 + " order by REC_TIME desc";

                ViewHelper.GenDataGridViewData(dBHelper, dataGridView1, sql, false, "STOCK_NO", cmbStockNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
