using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Common;
using UACSDAL;

namespace UACSView
{
    public partial class FrmWasteCoil : Baosight.iSuperframe.Forms.FormBase
    {
        public FrmWasteCoil()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlText = @"SELECT ROW_NUMBER() OVER() as ROW_INDEX, A.COIL_NO, A.WEIGHT, B.STOCK_NO FROM UACS_YARDMAP_COIL A LEFT JOIN UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO WHERE A.SCRAP_MAT_FLAG = 1 AND B.STOCK_NO IS NOT NULL ORDER BY STOCK_NO ASC ";
            dt.Clear();
            dt = new DataTable();

            using(IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sqlText))
            {
                dt.Load(rdr);
            }
            dataGridView1.DataSource = dt;
        }

        private void FrmWasteCoil_Load(object sender, EventArgs e)
        {
            UACS.ViewHelper.DataGridViewInit(dataGridView1);
        }
    }
}
