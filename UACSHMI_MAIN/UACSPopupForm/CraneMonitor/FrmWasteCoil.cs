using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;

namespace UACSPopupForm.CraneMonitor
{
    public partial class FrmWasteCoil : Form
    {
        public FrmWasteCoil()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlText = @"SELECT ROW_NUMBER() OVER() as ROW_INDEX, A.COIL_NO, B.STOCK_NO FROM UACS_YARDMAP_COIL A LEFT JOIN UACS_YARDMAP_STOCK_DEFINE B ON A.COIL_NO = B.MAT_NO A.SCRAP_MAT_FLAG = 1 ORDER BY STOCK_NO ASC ";
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
