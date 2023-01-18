using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UACSDAL;
using Baosight.iSuperframe.Common;
using Baosight.iSuperframe.Authorization.Interface;

namespace UACSPopupForm
{
    public partial class FrmParkingDetail : Form
    {
        private Baosight.iSuperframe.Authorization.Interface.IAuthorization auth;
        public FrmParkingDetail()
        {
            InitializeComponent();
        }

        private ParkingBase packingInfo;
        public ParkingBase PackingInfo
        {
            get { return packingInfo; }
            set { packingInfo = value; }
        }

        private void FrmParkingDetail_Load(object sender, EventArgs e)
        {
            lblCarNo.Text = packingInfo.Car_No;
            lblCarStatus.Text = packingInfo.PackingStatusDesc();
            lblPacking.Text = packingInfo.ParkingName;
            lblCarType.Text = ParkingInfo.getStowageCarType(packingInfo.STOWAGE_ID);
            ParkingInfo.dgvStowageMessage(packingInfo.STOWAGE_ID, dgvStowageMessage);
            ParkingInfo.dgvStowageOrder(packingInfo.ParkingName, dgvCraneOder);
            ShiftStowageMessage();
            this.Deactivate += new EventHandler(frmSaddleDetail_Deactivate);
        }
        void frmSaddleDetail_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }
        private void ShiftStowageMessage()
        {
            for (int i = 0; i < dgvStowageMessage.Rows.Count; i++)
            {
                dgvStowageMessage.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (dgvStowageMessage.Rows[i].Cells["STATUS"].Value != DBNull.Value)
                {
                    if (dgvStowageMessage.Rows[i].Cells["STATUS"].Value.ToString() == "执行完")
                    {
                        dgvStowageMessage.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth = FrameContext.Instance.GetPlugin<IAuthorization>() as IAuthorization;
            int load = packingInfo.IsLoaded;
            if (lblPacking.Text.Contains("F"))
            {
                string bayno = null;
                switch (lblPacking.Text)
                {
                    case "FIA01":
                    case "FIA02":
                    case "FIA03":
                    case "FIA04":
                    case "FIA05":
                    case "FIA06":
                        bayno = "A跨";
                        break;
                    case "FIB01":
                    case "FIB02":
                    case "FIB03":
                    case "FIB04":
                    case "FIB05":
                    case "FIB06":
                        bayno = "B跨";
                        break;                   
                    default:
                        bayno = null; ;
                        break;
                }
                if (load == 0)
                {
                    if (auth.IsOpen("02 车辆出库"))
                    {
                        auth.CloseForm("02 车辆出库");
                        //auth.OpenForm("02 车辆出库", true, bayno, lblPacking.Text);
                        auth.OpenForm("02 车辆出库", lblPacking.Text);
                    }
                    else
                    {
                        //auth.OpenForm("02 车辆出库", true, bayno, lblPacking.Text);
                        auth.OpenForm("02 车辆出库", lblPacking.Text);
                    }
                    this.Close();
                }
                else if (load == 1)
                {
                    if (auth.IsOpen("01 车辆入库"))
                    {
                        auth.CloseForm("01 车辆入库");
                        auth.OpenForm("01 车辆入库", lblPacking.Text);
                    }
                    else
                    {
                        auth.OpenForm("01 车辆入库", lblPacking.Text);
                    }
                    this.Close();
                }
            }
        }
        
    }
}
