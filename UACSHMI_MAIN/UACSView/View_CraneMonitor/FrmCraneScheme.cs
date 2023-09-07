﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;
using UACSDAL;
using UACSPopupForm;

namespace HMI_OF_CRANEORDERCONFIG
{
    public partial class FrmCraneScheme : FormBase
    {
        public FrmCraneScheme()
        {
            InitializeComponent();
            this.Load += FrmCraneScheme_Load;
        }

        #region 事件

        #region 初始加载

        void FrmCraneScheme_Load(object sender, EventArgs e)
        {
            ShiftCraneByBay();
            GetAreaToYrad(cbbCraneNo.Text.Trim());
            GetCarToYard(cbbCraneNo.Text.Trim());
            GetYradToCar(cbbCraneNo.Text.Trim());
            GetCurrentTypeMessage();
            ShiftDgvColorByFlag();
        }
        #endregion

        #region comBobox切换

        private void cbbBayNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShiftCraneByBay();
        }


        private void cbbCraneNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAreaToYrad(cbbCraneNo.Text.Trim());
            GetCarToYard(cbbCraneNo.Text.Trim());
            GetYradToCar(cbbCraneNo.Text.Trim());
            GetCurrentTypeMessage();
            ShiftDgvColorByFlag();
        }
        #endregion

        #region 类型切换
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim());
            ShiftDgvColorByFlag();
        }
        /// <summary>
        /// 离线包装入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim(), 1);
            ShiftDgvColorByFlag();
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim(), 2);
            ShiftDgvColorByFlag();
        }
        /// <summary>
        /// 自动包装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim(), 3);
            ShiftDgvColorByFlag();
        }
        /// <summary>
        /// 小卷区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim(), 4);
            ShiftDgvColorByFlag();
        }
        /// <summary>
        /// 机组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                GetAreaToYrad(cbbCraneNo.Text.Trim(), 5);
            ShiftDgvColorByFlag();
        }
        #endregion

        #region 点击查询区域信息
        private void dgvAreaToYard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvAreaToYard.Rows[e.RowIndex].Cells["AREA_ID"].Value != DBNull.Value)
                {
                    GetArea(dgvAreaToYard.Rows[e.RowIndex].Cells["AREA_ID"].Value.ToString());
                }
            }
        }

        private void dgvCarToYard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int CarToYardID, ID, CarToYardAreaID;
            if (e.RowIndex >= 0)
            {
                if (dgvCarToYard.Rows[e.RowIndex].Cells["carToYard_ID"].Value != DBNull.Value)
                {
                    //找出对应的行车信息
                    CarToYardID = Convert.ToInt32(dgvCarToYard.Rows[e.RowIndex].Cells["carToYard_ID"].Value.ToString());
                    for (int i = 0; i < dgvAreaToYard.RowCount; i++)
                    {
                        dgvAreaToYard.Rows[i].Selected = false;
                        ID = Convert.ToInt32(dgvAreaToYard.Rows[i].Cells["ID"].Value.ToString());
                        if (CarToYardID == ID)
                        {
                            dgvAreaToYard.FirstDisplayedScrollingRowIndex = i;
                            dgvAreaToYard.Rows[i].Selected = true;
                            dgvAreaToYard.CurrentCell = dgvAreaToYard.Rows[i].Cells["ID"];
                        }
                    }
                }
                if (dgvCarToYard.Rows[e.RowIndex].Cells["carToYard_AREA_ID"].Value != DBNull.Value)
                {
                    //找出停车位信息
                    CarToYardAreaID = Convert.ToInt32(dgvCarToYard.Rows[e.RowIndex].Cells["carToYard_AREA_ID"].Value.ToString());

                    GetArea(CarToYardAreaID.ToString());
                }
            }
        }
        #endregion

        #region 修改范围配置
        /// <summary>
        /// 授权成功 
        /// </summary>
        private bool IsAuthority = false;
        private void ChildForm_DataReturned(object sender, DataReturnedEventArgs e)
        {
            IsAuthority = e.IsAuthority;
            //MessageBox.Show("从子窗体返回的数据：" + IsAuthority, "数据返回", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AreaToYardUpConfig_Click(object sender, EventArgs e)
        {
            IsAuthority = false;
            FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
            childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
            childForm.ShowDialog();
            if (IsAuthority)
            {
                if (cbbCraneNo.Text.Trim() != "")
                {
                    int index = dgvAreaToYard.CurrentRow.Index;
                    if (index < 0)
                        return;

                    FrmCraneConfig frm = new FrmCraneConfig();
                    frm.ID = Convert.ToInt32(dgvAreaToYard.Rows[index].Cells["SADDLE_STRATEGY_ID"].Value.ToString());
                    frm.CraneNo = dgvAreaToYard.Rows[index].Cells["CRANE_NO"].Value.ToString();
                    frm.Xmin = Convert.ToInt32(dgvAreaToYard.Rows[index].Cells["X_MIN"].Value.ToString());
                    frm.Xmax = Convert.ToInt32(dgvAreaToYard.Rows[index].Cells["X_MAX"].Value.ToString());
                    frm.Ymin = Convert.ToInt32(dgvAreaToYard.Rows[index].Cells["Y_MIN"].Value.ToString());
                    frm.Ymax = Convert.ToInt32(dgvAreaToYard.Rows[index].Cells["Y_MAX"].Value.ToString());
                    frm.Xdir = dgvAreaToYard.Rows[index].Cells["X_DIR"].Value.ToString();
                    frm.MyCraneConfig = FrmCraneConfig.CraneConfig.CarToYard;
                    DialogResult ret = frm.ShowDialog();
                    if (ret == System.Windows.Forms.DialogResult.OK)
                    {
                        //暂时关闭这个修改范围的功能
                        GetCurrentTypeMessage();
                        ShiftDgvColorByFlag();
                    }
                }
            }
        }

        private void YardToCarUpConfig_Click(object sender, EventArgs e)
        {
            IsAuthority = false;
            FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
            childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
            childForm.ShowDialog();
            if (IsAuthority)
            {
                if (cbbCraneNo.Text.Trim() != "")
                {
                    int index = dgvYardToCar.CurrentRow.Index;
                    if (index < 0)
                        return;

                    FrmCraneConfig frm = new FrmCraneConfig();
                    frm.ID = Convert.ToInt32(dgvYardToCar.Rows[index].Cells["yardToCar_COIL_STRATEGY_ID"].Value.ToString());
                    frm.CraneNo = dgvYardToCar.Rows[index].Cells["yardToCar_CRANE_NO"].Value.ToString();
                    frm.Xmin = Convert.ToInt32(dgvYardToCar.Rows[index].Cells["yardToCar_X_MIN"].Value.ToString());
                    frm.Xmax = Convert.ToInt32(dgvYardToCar.Rows[index].Cells["yardToCar_X_MAX"].Value.ToString());
                    frm.Ymin = Convert.ToInt32(dgvYardToCar.Rows[index].Cells["yardToCar_Y_MIN"].Value.ToString());
                    frm.Ymax = Convert.ToInt32(dgvYardToCar.Rows[index].Cells["yardToCar_Y_MAX"].Value.ToString());
                    frm.Xdir = dgvYardToCar.Rows[index].Cells["yardToCar_X_DIR"].Value.ToString();
                    frm.MyCraneConfig = FrmCraneConfig.CraneConfig.YardToCar;
                    DialogResult ret = frm.ShowDialog();
                    if (ret == System.Windows.Forms.DialogResult.OK)
                    {
                        //暂时关闭这个修改范围的功能
                        GetYradToCar(cbbCraneNo.Text.Trim());
                    }
                }
            }
        }
        #endregion

        #region 打开关闭所有配置
        private void btnCloseFlag_Click(object sender, EventArgs e)
        {
            try
            {
                IsAuthority = false;
                FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
                childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
                childForm.ShowDialog();
                if (IsAuthority)
                {
                    for (int i = 0; i < dgvAreaToYard.Rows.Count; i++)
                    {
                        if (dgvAreaToYard.Rows[i].Cells["ID"].Value != DBNull.Value)
                        {
                            string id = dgvAreaToYard.Rows[i].Cells["ID"].Value.ToString();
                            bool flag = UpAreaToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), false);
                        }
                    }
                    GetCurrentTypeMessage();
                    ShiftDgvColorByFlag();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void btnOpenFlag_Click(object sender, EventArgs e)
        {
            try
            {
                IsAuthority = false;
                FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
                childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
                childForm.ShowDialog();
                if (IsAuthority)
                {
                    for (int i = 0; i < dgvAreaToYard.Rows.Count; i++)
                    {
                        if (dgvAreaToYard.Rows[i].Cells["ID"].Value != DBNull.Value)
                        {
                            string id = dgvAreaToYard.Rows[i].Cells["ID"].Value.ToString();
                            bool flag = UpAreaToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), true);
                        }
                    }
                    GetCurrentTypeMessage();
                    ShiftDgvColorByFlag();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 根据跨别对应行车号
        /// </summary>
        private void ShiftCraneByBay()
        {
            if (cbbBayNo.Text == "A")
            {
                cbbCraneNo.Items.Clear();
                cbbCraneNo.Text = "1";
                cbbCraneNo.Items.Add("1");
                cbbCraneNo.Items.Add("2");
            }
            else if (cbbBayNo.Text == "B")
            {
                cbbCraneNo.Items.Clear();
                cbbCraneNo.Text = "3";
                cbbCraneNo.Items.Add("3");
                cbbCraneNo.Items.Add("4");
            }
            else
                MessageBox.Show("不符合要求");
        }

        /// <summary>
        /// 根据行车号找所有的库位配置
        /// <para>STRATEGY_AREA_TO_YARD</para>
        /// <para>YARD_TO_YARD_FIND_SADDLE_STRATEGY</para>
        /// <para>区分类别 1：离线包装   2：停车位入库</para> 
        /// </summary>
        /// <param name="_CraneNO">行车号</param>
        /// <param name="_type">类别</param>
        private void GetAreaToYrad(string _CraneNO, int _type = 999)
        {
            string sql = @"select a.ID,a.CRANE_NO,a.AREA_ID,a.SADDLE_STRATEGY_ID,
                           CASE
                              WHEN a.FLAG_ENABLED = 1 THEN '启用'
                              WHEN a.FLAG_ENABLED = 0 THEN '不启用'
                              ELSE '其他'
                           END as FLAG_ENABLED,
                           a.SEQ,b.DESC,b.BAY_NO,b.X_MIN,b.X_MAX,b.Y_MIN,b.Y_MAX,b.X_DIR,
                           CASE
                              WHEN a.FLOW_TO  = 'AUTO_PACK_FLOW2_MANU_PACK_COIL_NORMAL' THEN '自动包装到离线包装的正常卷'
                              WHEN a.FLOW_TO  = 'AUTO_PACK_FLOW2_YARD_COIL_BIG' THEN '自动包装到库区的大卷'
                              WHEN a.FLOW_TO  = 'AUTO_PACK_FLOW2_YARD_COIL_NORMAL' THEN '自动包装到库区的正常卷'
                              WHEN a.FLOW_TO  = 'AUTO_PACK_FLOW2_MANU_PACK_COIL_BIG' THEN '自动包装到离线包装的大卷'
                              WHEN a.FLOW_TO  = 'ATUO_PACK_FLOW2_FORBIDDENED_COIL_BIG' THEN '自动包装封闭大卷'
                              WHEN a.FLOW_TO  = 'AUTO_PACK_FLOW2_FORBIDDENED_COIL_NORMAL' THEN '自动包装封闭正常卷'
                              WHEN a.FLOW_TO  = 'MANU_PACK_FLOW2_YARD_COIL_BIG' THEN '离线包装到库区的大卷'
                              WHEN a.FLOW_TO  = 'CAR_TO_YARD' THEN '入库'
                              WHEN a.FLOW_TO  = 'MANU_PACK_FLOW2_YARD_COIL_NORMAL' THEN '离线包装到库区的正常卷'
                              ELSE a.FLOW_TO
                           END as FLOW_TO 
                         from STRATEGY_AREA_TO_YARD a,YARD_TO_YARD_FIND_SADDLE_STRATEGY b,STRATEGY_AREA_SPECIAL c where 
                           a.AREA_ID = c.AREA_ID and a.SADDLE_STRATEGY_ID = b.ID and a.AREA_ID ";
            if (_type == 999) // 全部
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL) ";
            }
            else if (_type == 1) // 离线包装
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL where TYPE = 1) ";
            }
            else if (_type == 2) //停车位
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL where TYPE = 2) ";
            }
            else if (_type == 3) //自动包装
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL where TYPE = 3) ";
            }
            else if (_type == 4) //小卷区
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL where TYPE = 4) ";
            }
            else if (_type == 5) //机组
            {
                sql += " in(select AREA_ID from STRATEGY_AREA_SPECIAL where TYPE = 5) ";
            }
            sql += " and a.CRANE_NO = '" + _CraneNO + "' ";
            sql += " order by  a.AREA_ID,a.FLOW_TO,a.SEQ";
            dgvAreaToYard.Rows.Clear();
            using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
            {
                while (rdr.Read())
                {
                    dgvAreaToYard.Rows.Add();
                    DataGridViewRow theRow = dgvAreaToYard.Rows[dgvAreaToYard.Rows.Count - 1];
                    if (rdr["ID"] != System.DBNull.Value)
                        theRow.Cells["ID"].Value = Convert.ToString(rdr["ID"]);
                    if (rdr["CRANE_NO"] != System.DBNull.Value)
                        theRow.Cells["CRANE_NO"].Value = Convert.ToString(rdr["CRANE_NO"]);
                    if (rdr["AREA_ID"] != System.DBNull.Value)
                        theRow.Cells["AREA_ID"].Value = Convert.ToString(rdr["AREA_ID"]);
                    if (rdr["SADDLE_STRATEGY_ID"] != System.DBNull.Value)
                        theRow.Cells["SADDLE_STRATEGY_ID"].Value = Convert.ToString(rdr["SADDLE_STRATEGY_ID"]);
                    if (rdr["FLAG_ENABLED"] != System.DBNull.Value)
                        theRow.Cells["FLAG_ENABLED"].Value = Convert.ToString(rdr["FLAG_ENABLED"]);
                    if (rdr["SEQ"] != System.DBNull.Value)
                        theRow.Cells["SEQ"].Value = Convert.ToString(rdr["SEQ"]);
                    if (rdr["DESC"] != System.DBNull.Value)
                        theRow.Cells["DESC"].Value = Convert.ToString(rdr["DESC"]);
                    if (rdr["X_MIN"] != System.DBNull.Value)
                        theRow.Cells["X_MIN"].Value = Convert.ToString(rdr["X_MIN"]);
                    if (rdr["X_MAX"] != System.DBNull.Value)
                        theRow.Cells["X_MAX"].Value = Convert.ToString(rdr["X_MAX"]);
                    if (rdr["Y_MIN"] != System.DBNull.Value)
                        theRow.Cells["Y_MIN"].Value = Convert.ToString(rdr["Y_MIN"]);
                    if (rdr["Y_MAX"] != System.DBNull.Value)
                        theRow.Cells["Y_MAX"].Value = Convert.ToString(rdr["Y_MAX"]);
                    if (rdr["X_DIR"] != System.DBNull.Value)
                        theRow.Cells["X_DIR"].Value = Convert.ToString(rdr["X_DIR"]);
                    if (rdr["FLOW_TO"] != System.DBNull.Value)
                        theRow.Cells["FLOW_TO"].Value = Convert.ToString(rdr["FLOW_TO"]);
                }
            }

        }

        /// <summary>
        /// 根据区域号找区域配置
        /// <para>STRATEGY_AREA_SPECIAL</para>
        /// </summary>
        /// <param name="_areaNo"></param>
        private void GetArea(string _areaNo)
        {
            try
            {
                string sql = string.Format("SELECT * FROM STRATEGY_AREA_SPECIAL WHERE AREA_ID = '{0}'", _areaNo);

                dgvArea.Rows.Clear();
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        dgvArea.Rows.Add();
                        DataGridViewRow theRow = dgvArea.Rows[dgvArea.Rows.Count - 1];
                        if (rdr["AREA_ID"] != System.DBNull.Value)
                            theRow.Cells["area_AREA_ID"].Value = Convert.ToString(rdr["AREA_ID"]);
                        if (rdr["DESC"] != System.DBNull.Value)
                            theRow.Cells["area_DESC"].Value = Convert.ToString(rdr["DESC"]);
                        if (rdr["BAY_NO"] != System.DBNull.Value)
                            theRow.Cells["area_BAY_NO"].Value = Convert.ToString(rdr["BAY_NO"]);
                        if (rdr["X_MIN"] != System.DBNull.Value)
                            theRow.Cells["area_X_MIN"].Value = Convert.ToString(rdr["X_MIN"]);
                        if (rdr["X_MAX"] != System.DBNull.Value)
                            theRow.Cells["area_X_MAX"].Value = Convert.ToString(rdr["X_MAX"]);
                        if (rdr["Y_MIN"] != System.DBNull.Value)
                            theRow.Cells["area_Y_MIN"].Value = Convert.ToString(rdr["Y_MIN"]);
                        if (rdr["Y_MAX"] != System.DBNull.Value)
                            theRow.Cells["area_Y_MAX"].Value = Convert.ToString(rdr["Y_MAX"]);
                        if (rdr["TYPE"] != System.DBNull.Value)
                            theRow.Cells["area_TYPE"].Value = Convert.ToString(rdr["TYPE"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据行车号找入库配置
        /// <para>CAR_TO_YARD_CRANE_STRAEGY</para>
        /// </summary>
        /// <param name="_craneNo"></param>
        private void GetCarToYard(string _craneNo)
        {
            try
            {
                string sql = @"SELECT CRANE_NO,ID,AREA_ID,
                           CASE
                              WHEN FLAG_MY_DYUTY = 1 THEN '本职'
                              WHEN FLAG_MY_DYUTY = 0 THEN '副业'
                              ELSE '其他'
                           END as FLAG_MY_DYUTY ,
                           CASE
                              WHEN FLAG_ENABLED = 1 THEN '生效'
                              WHEN FLAG_ENABLED = 0 THEN '不生效'
                              ELSE '其他'
                           END as FLAG_ENABLED,SEQ FROM CAR_TO_YARD_CRANE_STRAEGY WHERE CRANE_NO = '" + _craneNo + "' ";
                sql += " ORDER BY SEQ";
                dgvCarToYard.Rows.Clear();
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        dgvCarToYard.Rows.Add();
                        DataGridViewRow theRow = dgvCarToYard.Rows[dgvCarToYard.Rows.Count - 1];
                        if (rdr["CRANE_NO"] != System.DBNull.Value)
                            theRow.Cells["carToYard_CRANE_NO"].Value = Convert.ToString(rdr["CRANE_NO"]);
                        if (rdr["ID"] != System.DBNull.Value)
                            theRow.Cells["carToYard_ID"].Value = Convert.ToString(rdr["ID"]);
                        if (rdr["AREA_ID"] != System.DBNull.Value)
                            theRow.Cells["carToYard_AREA_ID"].Value = Convert.ToString(rdr["AREA_ID"]);
                        if (rdr["FLAG_MY_DYUTY"] != System.DBNull.Value)
                            theRow.Cells["carToYard_FLAG_MY_DYUTY"].Value = Convert.ToString(rdr["FLAG_MY_DYUTY"]);
                        if (rdr["FLAG_ENABLED"] != System.DBNull.Value)
                            theRow.Cells["carToYard_FLAG_ENABLED"].Value = Convert.ToString(rdr["FLAG_ENABLED"]);
                        if (rdr["SEQ"] != System.DBNull.Value)
                            theRow.Cells["carToYard_SEQ"].Value = Convert.ToString(rdr["SEQ"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 根据行车号找出库配置
        /// <para>YARD_TO_CAR_CRANE_STRAEGY</para>
        /// <para>YARD_TO_YARD_FIND_COIL_STRATEGY</para>
        /// </summary>
        /// <param name="_craneNo"></param>
        private void GetYradToCar(string _craneNo)
        {
            try
            {
                string sql = @"SELECT a.CRANE_NO,a.ID,a.AREA_ID,a.COIL_STRATEGY_ID,
                           CASE
                              WHEN a.FLAG_MY_DYUTY = 1 THEN '本职'
                              WHEN a.FLAG_MY_DYUTY = 0 THEN '副业'
                              ELSE '其他'
                           END as FLAG_MY_DYUTY ,
                           CASE
                              WHEN a.FLAG_ENABLED = 1 THEN '生效'
                              WHEN a.FLAG_ENABLED = 0 THEN '不生效'
                              ELSE '其他'
                           END as FLAG_ENABLED,a.SEQ,b.DESC,b.X_MIN,b.X_MAX,b.Y_MIN,b.Y_MAX,b.X_DIR FROM ";
                sql += " YARD_TO_CAR_CRANE_STRAEGY a,YARD_TO_YARD_FIND_COIL_STRATEGY b ";
                sql += " WHERE a.COIL_STRATEGY_ID = b.ID and CRANE_NO = '" + _craneNo + "'";
                sql += " ORDER BY a.SEQ";
                dgvYardToCar.Rows.Clear();
                using (IDataReader rdr = DB2Connect.DBHelper.ExecuteReader(sql))
                {
                    while (rdr.Read())
                    {
                        dgvYardToCar.Rows.Add();
                        DataGridViewRow theRow = dgvYardToCar.Rows[dgvYardToCar.Rows.Count - 1];
                        if (rdr["CRANE_NO"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_CRANE_NO"].Value = Convert.ToString(rdr["CRANE_NO"]);
                        if (rdr["ID"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_ID"].Value = Convert.ToString(rdr["ID"]);
                        if (rdr["AREA_ID"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_AREA_ID"].Value = Convert.ToString(rdr["AREA_ID"]);
                        if (rdr["COIL_STRATEGY_ID"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_COIL_STRATEGY_ID"].Value = Convert.ToString(rdr["COIL_STRATEGY_ID"]);
                        if (rdr["FLAG_MY_DYUTY"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_FLAG_MY_DYUTY"].Value = Convert.ToString(rdr["FLAG_MY_DYUTY"]);
                        if (rdr["FLAG_ENABLED"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_FLAG_ENABLED"].Value = Convert.ToString(rdr["FLAG_ENABLED"]);
                        if (rdr["SEQ"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_SEQ"].Value = Convert.ToString(rdr["SEQ"]);
                        if (rdr["DESC"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_DESC"].Value = Convert.ToString(rdr["DESC"]);
                        if (rdr["X_MIN"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_X_MIN"].Value = Convert.ToString(rdr["X_MIN"]);
                        if (rdr["X_MAX"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_X_MAX"].Value = Convert.ToString(rdr["X_MAX"]);
                        if (rdr["Y_MIN"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_Y_MIN"].Value = Convert.ToString(rdr["Y_MIN"]);
                        if (rdr["Y_MAX"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_Y_MAX"].Value = Convert.ToString(rdr["Y_MAX"]);
                        if (rdr["X_DIR"] != System.DBNull.Value)
                            theRow.Cells["yardToCar_X_DIR"].Value = Convert.ToString(rdr["X_DIR"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 更新CAR_TO_YARD_CRANE_STRAEGY的启用标记
        /// <para>_isFlag ---true 启用    ---false 停止</para>
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        private bool UpCarToYardByFlag(string _craneNo, string _id, bool _isFlag)
        {
            string sql = string.Empty;
            try
            {
                if (_isFlag)
                    sql = string.Format("UPDATE CAR_TO_YARD_CRANE_STRAEGY SET FLAG_ENABLED = 1 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                else
                    sql = string.Format("UPDATE CAR_TO_YARD_CRANE_STRAEGY SET FLAG_ENABLED = 0 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更新STRATEGY_AREA_TO_YARD的启用标记
        /// <para>_isFlag ---true 启用    ---false 停止</para>
        /// </summary>
        /// <returns></returns>
        private bool UpAreaToYardByFlag(string _craneNo, string _id, bool _isFlag)
        {
            string sql = string.Empty;
            try
            {
                if (_isFlag)
                    sql = string.Format("UPDATE STRATEGY_AREA_TO_YARD SET FLAG_ENABLED = 1 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                else
                    sql = string.Format("UPDATE STRATEGY_AREA_TO_YARD SET FLAG_ENABLED = 0 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更新YARD_TO_CAR_CRANE_STRAEGY的启用标记
        /// <para>_isFlag ---true 启用    ---false 停止</para>
        /// </summary>
        /// <returns></returns>
        private bool UpYardToCarByFlag(string _craneNo, string _id, bool _isFlag)
        {
            string sql = string.Empty;
            try
            {
                if (_isFlag)
                    sql = string.Format("UPDATE YARD_TO_CAR_CRANE_STRAEGY SET FLAG_ENABLED = 1 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                else
                    sql = string.Format("UPDATE YARD_TO_CAR_CRANE_STRAEGY SET FLAG_ENABLED = 0 WHERE CRANE_NO = '{0}' and ID = {1} ", _craneNo, _id);
                DB2Connect.DBHelper.ExecuteNonQuery(sql);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取当前类型的信息
        /// </summary>
        private void GetCurrentTypeMessage()
        {
            try
            {
                if (radioButton1.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim());
                if (radioButton2.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim(), 1);
                if (radioButton3.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim(), 2);
                if (radioButton4.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim(), 3);
                if (radioButton5.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim(), 4);
                if (radioButton6.Checked)
                    GetAreaToYrad(cbbCraneNo.Text.Trim(), 5);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        /// <summary>
        /// 改变是否启用状态的颜色
        /// </summary>
        private void ShiftDgvColorByFlag()
        {
            for (int i = 0; i < dgvAreaToYard.Rows.Count; i++)
            {
                if (dgvAreaToYard.Rows[i].Cells["FLAG_ENABLED"].Value != DBNull.Value)
                {
                    string flag = dgvAreaToYard.Rows[i].Cells["FLAG_ENABLED"].Value.ToString();
                    if (flag == "启用")
                    {
                        dgvAreaToYard.Rows[i].Cells["FLAG_ENABLED"].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvAreaToYard.Rows[i].Cells["FLAG_ENABLED"].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        #endregion

        #region 配置ID状态切换
        private void AreaToYardByStop_Click(object sender, EventArgs e)
        {
            IsAuthority = false;
            FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
            childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
            childForm.ShowDialog();
            if (IsAuthority)
            {
                if (cbbCraneNo.Text.Trim() != "")
                {
                    int index = dgvAreaToYard.CurrentRow.Index;
                    if (index < 0)
                        return;
                    string id = dgvAreaToYard.Rows[index].Cells["ID"].Value.ToString();
                    bool flag = UpAreaToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), false);
                    if (flag)
                        MessageBox.Show(id + "配载方案停止成功");
                    else
                        MessageBox.Show(id + "配载方案停止失败");

                    GetCurrentTypeMessage();
                    ShiftDgvColorByFlag();
                }
            }
        }

        private void AreaToYardByOpen_Click(object sender, EventArgs e)
        {
            IsAuthority = false;
            FrmCraneConfigAuthority childForm = new FrmCraneConfigAuthority();
            childForm.DataReturned += ChildForm_DataReturned; // 订阅子窗体的事件
            childForm.ShowDialog();
            if (IsAuthority)
            {
                if (cbbCraneNo.Text.Trim() != "")
                {
                    int index = dgvAreaToYard.CurrentRow.Index;
                    if (index < 0)
                        return;
                    string id = dgvAreaToYard.Rows[index].Cells["ID"].Value.ToString();
                    bool flag = UpAreaToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), true);
                    if (flag)
                        MessageBox.Show(id + "配载方案打开成功");
                    else
                        MessageBox.Show(id + "配载方案打开失败");

                    GetCurrentTypeMessage();
                    ShiftDgvColorByFlag();
                }
            }
        }

        private void CarToYardByStop_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {

                int index = dgvCarToYard.CurrentRow.Index;
                if (index < 0)
                    return;
                string id = dgvCarToYard.Rows[index].Cells["carToYard_ID"].Value.ToString();
                bool flag = UpCarToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), false);
                if (flag)
                    MessageBox.Show(id + "配载方案停止成功");
                else
                    MessageBox.Show(id + "配载方案停止失败");

                GetCarToYard(cbbCraneNo.Text.Trim());
            }
        }

        private void CarToYardByOpen_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {

                int index = dgvCarToYard.CurrentRow.Index;
                if (index < 0)
                    return;
                string id = dgvCarToYard.Rows[index].Cells["carToYard_ID"].Value.ToString();
                bool flag = UpCarToYardByFlag(cbbCraneNo.Text.Trim(), id.ToString(), true);
                if (flag)
                    MessageBox.Show(id + "配载方案打开成功");
                else
                    MessageBox.Show(id + "配载方案打开失败");

                GetCarToYard(cbbCraneNo.Text.Trim());
            }
        }

        private void YardToCarByStop_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {
                int index = dgvYardToCar.CurrentRow.Index;
                if (index < 0)
                    return;
                string id = dgvYardToCar.Rows[index].Cells["yardToCar_ID"].Value.ToString();
                bool flag = UpYardToCarByFlag(cbbCraneNo.Text.Trim(), id.ToString(), false);
                if (flag)
                    MessageBox.Show(id + "配载方案停止成功");
                else
                    MessageBox.Show(id + "配载方案停止失败");

                GetYradToCar(cbbCraneNo.Text.Trim());
            }
        }

        private void YardToCarByOpen_Click(object sender, EventArgs e)
        {
            if (cbbCraneNo.Text.Trim() != "")
            {
                int index = dgvYardToCar.CurrentRow.Index;
                if (index < 0)
                    return;
                string id = dgvYardToCar.Rows[index].Cells["yardToCar_ID"].Value.ToString();
                bool flag = UpYardToCarByFlag(cbbCraneNo.Text.Trim(), id.ToString(), true);
                if (flag)
                    MessageBox.Show(id + "配载方案打开成功");
                else
                    MessageBox.Show(id + "配载方案打开失败");

                GetYradToCar(cbbCraneNo.Text.Trim());
            }
        }

        #endregion

        private void cbbCraneNo_TextChanged(object sender, EventArgs e)
        {
            GetAreaToYrad(cbbCraneNo.Text.Trim());
            GetCarToYard(cbbCraneNo.Text.Trim());
            GetYradToCar(cbbCraneNo.Text.Trim());
            GetCurrentTypeMessage();
            ShiftDgvColorByFlag();
        }

    }
}
