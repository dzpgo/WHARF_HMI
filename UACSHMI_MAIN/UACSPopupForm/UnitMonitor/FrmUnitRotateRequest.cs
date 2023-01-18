using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UACSPopupForm
{
    public partial class FrmUnitRotateRequest : Form
    {
        public string UintNo { get; set; }
        public string CoilNo { get; set; }
        public string FromStock { get; set; }
        public string ToStock{ get; set; }

        private string craneNo = string.Empty;
        private string unitNo = string.Empty;
        private string coilNo = string.Empty;
        private string strFrom = string.Empty;
        private string strTo = string.Empty;

        private int manuValue;

        
        public FrmUnitRotateRequest()
        {
            InitializeComponent();
            this.Load += FrmYardToYardRequest_Load;
        }

        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("zjcangchu");//平台连接数据库的Text
                    }
                    catch (System.Exception e)
                    {
                        //throw e;
                    }
                }
                return dbHelper;
            }
        }
        #endregion

        void FrmYardToYardRequest_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            txtCoilno.Text = CoilNo;
            cbbFromStock.Text = FromStock;
            cbbToStock.Text = ToStock;
            unitNo = UintNo;
            bindcbb();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if(cbbCraneNo.Text == "" || cbbFromStock.Text == "" ||txtCoilno.Text == "")
            {
                MessageBox.Show("请选择行车号和起卷位！");
                return;
            }
            bool flag = false;
            try
            {
                craneNo = cbbCraneNo.Text.Trim();
                coilNo = txtCoilno.Text.Trim();
                manuValue = 0;

                string sql1 = string.Format("UPDATE UACS_YARDMAP_COIL SET MANU_VALUE = '{0}' WHERE COIL_NO = '{1}'", manuValue, coilNo);
                DBHelper.ExecuteNonQuery(sql1);

                string sql = @"update UACS_CRANE_MANU_ORDER set COIL_NO = null,FROM_STOCK = null,TO_STOCK = null,STATUS = 'EMPTY' ";
                sql += " WHERE CRANE_NO = '" + craneNo + "'";
                DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("已取消指令！");
            }
            catch (Exception er)
            {
                flag = true;
                MessageBox.Show(er.Message);
            }

            if (!flag)
            {
                Thread.Sleep(500);
                this.Close();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string status;
            string sqlText = @"SELECT STATUS FROM UACS_CRANE_MANU_ORDER WHERE CRANE_NO = '{0}'";
            sqlText = String.Format(sqlText, cbbCraneNo.Text.Trim());
            using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
            {
                rdr.Read();
                status = rdr["STATUS"].ToString().Trim();
                if (status != "EMPTY" && status != "NULL")
                {
                    MessageBox.Show("行车已有指令！");
                    return;
                }

            }

            if (txtCoilno.Text.Trim() == "" || cbbFromStock.Text.Trim() == "" || cbbToStock.Text.Trim() == "")
            {
                MessageBox.Show("请输入完整");
                return;
            }


            bool flag = false;
            try
            {
                craneNo = cbbCraneNo.Text.Trim();
                coilNo = txtCoilno.Text.Trim();
                strFrom = cbbFromStock.Text.Trim();
                strTo = cbbToStock.Text.Trim();
                if (cbbRotate.Text.Trim() == "旋转")
                {
                    manuValue = 1;
                }
                else
                {
                    manuValue = 0;
                }

                string sql1 = string.Format("UPDATE UACS_YARDMAP_COIL SET MANU_VALUE = '{0}' WHERE COIL_NO = '{1}'", manuValue, coilNo);
                DBHelper.ExecuteNonQuery(sql1);

                string sql = @"update UACS_CRANE_MANU_ORDER  set COIL_NO = '" + coilNo + "',FROM_STOCK = '" + strFrom + "',TO_STOCK = '" + strTo + "',STATUS = 'INIT' ";
                sql += " WHERE CRANE_NO = '" + craneNo + "'";
                DBHelper.ExecuteNonQuery(sql);
                MessageBox.Show("已下达指令！");
            }
            catch (Exception er)
            {
                flag = true;
                MessageBox.Show(er.Message);
            }

            if (!flag)
            {
                Thread.Sleep(500);
                this.Close();
            }
           
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindcbb()
        {
            cbbCraneNo.Items.Clear();
            cbbFromStock.Items.Clear();
            cbbToStock.Items.Clear();

            if (unitNo=="D112")
            {
                cbbCraneNo.Items.Add("3_1");
                cbbCraneNo.Items.Add("3_2");
                cbbCraneNo.Items.Add("3_3");

                cbbFromStock.Items.Add("D112VR1A01");
                cbbFromStock.Items.Add("D112VR1A02");
                cbbFromStock.Items.Add("D112VR2A01");
                cbbFromStock.Items.Add("D112VR2A02");

                cbbToStock.Items.Add("D112VR1A01");
                cbbToStock.Items.Add("D112VR1A02");
                cbbToStock.Items.Add("D112VR2A01");
                cbbToStock.Items.Add("D112VR2A02");
            }
            else if (unitNo == "D108")
            {
                cbbCraneNo.Items.Add("3_4");
                cbbCraneNo.Items.Add("3_5");

                cbbFromStock.Items.Add("D108WR1A01");
                cbbFromStock.Items.Add("D108WR1A02");
                cbbFromStock.Items.Add("D108WR1A03");
                cbbFromStock.Items.Add("D108WR1A04");
                cbbFromStock.Items.Add("D108WR1A05");
                cbbFromStock.Items.Add("D108WR1A06");

                cbbToStock.Items.Add("D108WR1A01");
                cbbToStock.Items.Add("D108WR1A02");
                cbbToStock.Items.Add("D108WR1A03");
                cbbToStock.Items.Add("D108WR1A04");
                cbbToStock.Items.Add("D108WR1A05");
                cbbToStock.Items.Add("D108WR1A06");
            }
            else if (unitNo == "D208")
            {
                cbbCraneNo.Items.Add("3_4");
                cbbCraneNo.Items.Add("3_5");

                cbbFromStock.Items.Add("D208WR1A01");
                cbbFromStock.Items.Add("D208WR1A02");
                cbbFromStock.Items.Add("D208WR1A03");
                cbbFromStock.Items.Add("D208WR1A04");
                cbbFromStock.Items.Add("D208WR1A05");
                cbbFromStock.Items.Add("D208WR1A06");

                cbbToStock.Items.Add("D208WR1A01");
                cbbToStock.Items.Add("D208WR1A02");
                cbbToStock.Items.Add("D208WR1A03");
                cbbToStock.Items.Add("D208WR1A04");
                cbbToStock.Items.Add("D208WR1A05");
                cbbToStock.Items.Add("D208WR1A06");
            }
            else
            {
                cbbCraneNo.Items.Add("3_1");
                cbbCraneNo.Items.Add("3_2");
                cbbCraneNo.Items.Add("3_3");
                cbbCraneNo.Items.Add("3_4");
                cbbCraneNo.Items.Add("3_5");
            }
        }

        private void cbbFromStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string sql = @"SELECT MAT_NO FROM UACS_YARDMAP_STOCK_DEFINE WHERE STOCK_NO = '{0}'";
            sql = String.Format(sql, cbbFromStock.Text.Trim());
            using (IDataReader rdr = DBHelper.ExecuteReader(sql))
            {
                rdr.Read();
                txtCoilno.Text = rdr["MAT_NO"].ToString().Trim();

            }
        }
    }
}
