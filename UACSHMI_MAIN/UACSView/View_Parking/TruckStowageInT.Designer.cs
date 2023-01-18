﻿namespace UACSParking
{
    partial class TruckStowageInT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TruckStowageInT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLaserStatus = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPTcount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLaserCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_PT_ACTION_COUNT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_LASER_ACTION_COUNT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ParkingStatus = new System.Windows.Forms.TextBox();
            this.txt_ISLoaded = new System.Windows.Forms.TextBox();
            this.txt_TreatmentNO = new System.Windows.Forms.TextBox();
            this.txt_HeadPos = new System.Windows.Forms.TextBox();
            this.txt_LoadMapID = new System.Windows.Forms.TextBox();
            this.txt_CarNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comb_ParkingNO = new System.Windows.Forms.ComboBox();
            this.timer_RefrehHMI = new System.Windows.Forms.Timer(this.components);
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOperatePause = new System.Windows.Forms.Button();
            this.btnOperateStrat = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmd_PTINEnd = new System.Windows.Forms.Button();
            this.cmd_LaserINEnd = new System.Windows.Forms.Button();
            this.cmd_LaserINStart = new System.Windows.Forms.Button();
            this.cmd_CarLeave = new System.Windows.Forms.Button();
            this.cmd_CarArrive = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_LaodMap = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvCraneOder = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FROM_STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TO_STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_PT = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.parkLaserOut1 = new ParkingControlLibrary.ParkLaserOut();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_LASER = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPanelParkArea = new System.Windows.Forms.TableLayoutPanel();
            this.park1 = new ParkingControlLibrary.ParkingState();
            this.park2 = new ParkingControlLibrary.ParkingState();
            this.park3 = new ParkingControlLibrary.ParkingState();
            this.park6 = new ParkingControlLibrary.ParkingState();
            this.park4 = new ParkingControlLibrary.ParkingState();
            this.park5 = new ParkingControlLibrary.ParkingState();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.labTips = new System.Windows.Forms.Label();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LaodMap)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCraneOder)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PT)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LASER)).BeginInit();
            this.tabPanelParkArea.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblTitle.Size = new System.Drawing.Size(1276, 46);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "车辆入库";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtLaserStatus);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtPTcount);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtLaserCount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_PT_ACTION_COUNT);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_LASER_ACTION_COUNT);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_ParkingStatus);
            this.panel1.Controls.Add(this.txt_ISLoaded);
            this.panel1.Controls.Add(this.txt_TreatmentNO);
            this.panel1.Controls.Add(this.txt_HeadPos);
            this.panel1.Controls.Add(this.txt_LoadMapID);
            this.panel1.Controls.Add(this.txt_CarNO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comb_ParkingNO);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 72);
            this.panel1.TabIndex = 2;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(1001, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(110, 21);
            this.label25.TabIndex = 110;
            this.label25.Text = "激光扫描状态:";
            // 
            // txtLaserStatus
            // 
            this.txtLaserStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtLaserStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLaserStatus.ForeColor = System.Drawing.Color.Black;
            this.txtLaserStatus.Location = new System.Drawing.Point(1113, 40);
            this.txtLaserStatus.Name = "txtLaserStatus";
            this.txtLaserStatus.ReadOnly = true;
            this.txtLaserStatus.Size = new System.Drawing.Size(154, 29);
            this.txtLaserStatus.TabIndex = 109;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(806, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 21);
            this.label11.TabIndex = 37;
            this.label11.Text = "手持扫描卷数:";
            // 
            // txtPTcount
            // 
            this.txtPTcount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPTcount.ForeColor = System.Drawing.Color.Silver;
            this.txtPTcount.Location = new System.Drawing.Point(931, 40);
            this.txtPTcount.Name = "txtPTcount";
            this.txtPTcount.ReadOnly = true;
            this.txtPTcount.Size = new System.Drawing.Size(57, 29);
            this.txtPTcount.TabIndex = 36;
            this.txtPTcount.TextChanged += new System.EventHandler(this.txtPTcount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(806, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 21);
            this.label12.TabIndex = 35;
            this.label12.Text = "激光扫描卷数:";
            // 
            // txtLaserCount
            // 
            this.txtLaserCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLaserCount.ForeColor = System.Drawing.Color.Silver;
            this.txtLaserCount.Location = new System.Drawing.Point(931, 5);
            this.txtLaserCount.Name = "txtLaserCount";
            this.txtLaserCount.ReadOnly = true;
            this.txtLaserCount.Size = new System.Drawing.Size(57, 29);
            this.txtLaserCount.TabIndex = 34;
            this.txtLaserCount.TextChanged += new System.EventHandler(this.txtLaserCount_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(619, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 21);
            this.label9.TabIndex = 32;
            this.label9.Text = "手持扫描次数:";
            // 
            // txt_PT_ACTION_COUNT
            // 
            this.txt_PT_ACTION_COUNT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PT_ACTION_COUNT.ForeColor = System.Drawing.Color.Silver;
            this.txt_PT_ACTION_COUNT.Location = new System.Drawing.Point(744, 40);
            this.txt_PT_ACTION_COUNT.Name = "txt_PT_ACTION_COUNT";
            this.txt_PT_ACTION_COUNT.ReadOnly = true;
            this.txt_PT_ACTION_COUNT.Size = new System.Drawing.Size(56, 29);
            this.txt_PT_ACTION_COUNT.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(619, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 21);
            this.label8.TabIndex = 30;
            this.label8.Text = "激光扫描次数:";
            // 
            // txt_LASER_ACTION_COUNT
            // 
            this.txt_LASER_ACTION_COUNT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LASER_ACTION_COUNT.ForeColor = System.Drawing.Color.Silver;
            this.txt_LASER_ACTION_COUNT.Location = new System.Drawing.Point(744, 5);
            this.txt_LASER_ACTION_COUNT.Name = "txt_LASER_ACTION_COUNT";
            this.txt_LASER_ACTION_COUNT.ReadOnly = true;
            this.txt_LASER_ACTION_COUNT.Size = new System.Drawing.Size(56, 29);
            this.txt_LASER_ACTION_COUNT.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1022, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 21);
            this.label7.TabIndex = 28;
            this.label7.Text = "车位状态:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(214, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "空重标记:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(217, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "车头朝向:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(387, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 25;
            this.label4.Text = "配载图号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(407, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "处理号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "车号:";
            // 
            // txt_ParkingStatus
            // 
            this.txt_ParkingStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ParkingStatus.ForeColor = System.Drawing.Color.Silver;
            this.txt_ParkingStatus.Location = new System.Drawing.Point(1113, 5);
            this.txt_ParkingStatus.Name = "txt_ParkingStatus";
            this.txt_ParkingStatus.ReadOnly = true;
            this.txt_ParkingStatus.Size = new System.Drawing.Size(154, 29);
            this.txt_ParkingStatus.TabIndex = 22;
            // 
            // txt_ISLoaded
            // 
            this.txt_ISLoaded.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ISLoaded.ForeColor = System.Drawing.Color.Silver;
            this.txt_ISLoaded.Location = new System.Drawing.Point(302, 40);
            this.txt_ISLoaded.Name = "txt_ISLoaded";
            this.txt_ISLoaded.ReadOnly = true;
            this.txt_ISLoaded.Size = new System.Drawing.Size(76, 29);
            this.txt_ISLoaded.TabIndex = 21;
            // 
            // txt_TreatmentNO
            // 
            this.txt_TreatmentNO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_TreatmentNO.ForeColor = System.Drawing.Color.Silver;
            this.txt_TreatmentNO.Location = new System.Drawing.Point(471, 5);
            this.txt_TreatmentNO.Name = "txt_TreatmentNO";
            this.txt_TreatmentNO.ReadOnly = true;
            this.txt_TreatmentNO.Size = new System.Drawing.Size(118, 29);
            this.txt_TreatmentNO.TabIndex = 20;
            // 
            // txt_HeadPos
            // 
            this.txt_HeadPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_HeadPos.ForeColor = System.Drawing.Color.Silver;
            this.txt_HeadPos.Location = new System.Drawing.Point(302, 5);
            this.txt_HeadPos.Name = "txt_HeadPos";
            this.txt_HeadPos.ReadOnly = true;
            this.txt_HeadPos.Size = new System.Drawing.Size(76, 29);
            this.txt_HeadPos.TabIndex = 19;
            // 
            // txt_LoadMapID
            // 
            this.txt_LoadMapID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_LoadMapID.ForeColor = System.Drawing.Color.Silver;
            this.txt_LoadMapID.Location = new System.Drawing.Point(471, 40);
            this.txt_LoadMapID.Name = "txt_LoadMapID";
            this.txt_LoadMapID.ReadOnly = true;
            this.txt_LoadMapID.Size = new System.Drawing.Size(118, 29);
            this.txt_LoadMapID.TabIndex = 18;
            // 
            // txt_CarNO
            // 
            this.txt_CarNO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_CarNO.ForeColor = System.Drawing.Color.Silver;
            this.txt_CarNO.Location = new System.Drawing.Point(93, 40);
            this.txt_CarNO.Name = "txt_CarNO";
            this.txt_CarNO.ReadOnly = true;
            this.txt_CarNO.Size = new System.Drawing.Size(118, 29);
            this.txt_CarNO.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(19, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "停车位:";
            // 
            // comb_ParkingNO
            // 
            this.comb_ParkingNO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comb_ParkingNO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comb_ParkingNO.FormattingEnabled = true;
            this.comb_ParkingNO.Location = new System.Drawing.Point(93, 5);
            this.comb_ParkingNO.Name = "comb_ParkingNO";
            this.comb_ParkingNO.Size = new System.Drawing.Size(118, 30);
            this.comb_ParkingNO.TabIndex = 15;
            this.comb_ParkingNO.SelectedIndexChanged += new System.EventHandler(this.comb_ParkingNO_SelectedIndexChanged_1);
            // 
            // timer_RefrehHMI
            // 
            this.timer_RefrehHMI.Interval = 5000;
            this.timer_RefrehHMI.Tick += new System.EventHandler(this.timer_RefrehHMI_Tick);
            // 
            // txtDebug
            // 
            this.txtDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDebug.ForeColor = System.Drawing.Color.Silver;
            this.txtDebug.Location = new System.Drawing.Point(757, 11);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(63, 29);
            this.txtDebug.TabIndex = 37;
            this.txtDebug.Visible = false;
            // 
            // cmbArea
            // 
            this.cmbArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.cmbArea.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbArea.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "A跨",
            "B跨"});
            this.cmbArea.Location = new System.Drawing.Point(93, 10);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(118, 29);
            this.cmbArea.TabIndex = 81;
            this.cmbArea.Text = "A跨";
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label22.Location = new System.Drawing.Point(14, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 21);
            this.label22.TabIndex = 82;
            this.label22.Text = "作业区域";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tabPanelParkArea, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 118);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1276, 544);
            this.tableLayoutPanel3.TabIndex = 83;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 441);
            this.tableLayoutPanel1.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnOperatePause);
            this.panel3.Controls.Add(this.btnOperateStrat);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.cmd_PTINEnd);
            this.panel3.Controls.Add(this.cmd_LaserINEnd);
            this.panel3.Controls.Add(this.cmd_LaserINStart);
            this.panel3.Controls.Add(this.cmd_CarLeave);
            this.panel3.Controls.Add(this.cmd_CarArrive);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1151, 3);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(116, 435);
            this.panel3.TabIndex = 37;
            // 
            // btnOperatePause
            // 
            this.btnOperatePause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOperatePause.BackgroundImage")));
            this.btnOperatePause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOperatePause.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOperatePause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOperatePause.Location = new System.Drawing.Point(9, 91);
            this.btnOperatePause.Name = "btnOperatePause";
            this.btnOperatePause.Size = new System.Drawing.Size(101, 38);
            this.btnOperatePause.TabIndex = 38;
            this.btnOperatePause.Text = "作业暂停";
            this.btnOperatePause.UseVisualStyleBackColor = true;
            this.btnOperatePause.Click += new System.EventHandler(this.btnOperatePause_Click);
            // 
            // btnOperateStrat
            // 
            this.btnOperateStrat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOperateStrat.BackgroundImage")));
            this.btnOperateStrat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOperateStrat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOperateStrat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOperateStrat.Location = new System.Drawing.Point(9, 47);
            this.btnOperateStrat.Name = "btnOperateStrat";
            this.btnOperateStrat.Size = new System.Drawing.Size(101, 38);
            this.btnOperateStrat.TabIndex = 37;
            this.btnOperateStrat.Text = "作业开始";
            this.btnOperateStrat.UseVisualStyleBackColor = true;
            this.btnOperateStrat.Click += new System.EventHandler(this.btnOperateStrat_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Location = new System.Drawing.Point(9, 179);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 38);
            this.btnRefresh.TabIndex = 36;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmd_PTINEnd
            // 
            this.cmd_PTINEnd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_PTINEnd.BackgroundImage")));
            this.cmd_PTINEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_PTINEnd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmd_PTINEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_PTINEnd.Location = new System.Drawing.Point(9, 354);
            this.cmd_PTINEnd.Name = "cmd_PTINEnd";
            this.cmd_PTINEnd.Size = new System.Drawing.Size(97, 39);
            this.cmd_PTINEnd.TabIndex = 31;
            this.cmd_PTINEnd.Text = "手持扫描完成";
            this.cmd_PTINEnd.UseVisualStyleBackColor = true;
            this.cmd_PTINEnd.Visible = false;
            // 
            // cmd_LaserINEnd
            // 
            this.cmd_LaserINEnd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_LaserINEnd.BackgroundImage")));
            this.cmd_LaserINEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_LaserINEnd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmd_LaserINEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_LaserINEnd.Location = new System.Drawing.Point(9, 313);
            this.cmd_LaserINEnd.Name = "cmd_LaserINEnd";
            this.cmd_LaserINEnd.Size = new System.Drawing.Size(97, 35);
            this.cmd_LaserINEnd.TabIndex = 32;
            this.cmd_LaserINEnd.Text = "激光扫描完成";
            this.cmd_LaserINEnd.UseVisualStyleBackColor = true;
            this.cmd_LaserINEnd.Visible = false;
            // 
            // cmd_LaserINStart
            // 
            this.cmd_LaserINStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_LaserINStart.BackgroundImage")));
            this.cmd_LaserINStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_LaserINStart.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmd_LaserINStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_LaserINStart.Location = new System.Drawing.Point(9, 272);
            this.cmd_LaserINStart.Name = "cmd_LaserINStart";
            this.cmd_LaserINStart.Size = new System.Drawing.Size(97, 35);
            this.cmd_LaserINStart.TabIndex = 35;
            this.cmd_LaserINStart.Text = "启动激光扫描";
            this.cmd_LaserINStart.UseVisualStyleBackColor = true;
            this.cmd_LaserINStart.Visible = false;
            // 
            // cmd_CarLeave
            // 
            this.cmd_CarLeave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_CarLeave.BackgroundImage")));
            this.cmd_CarLeave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_CarLeave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmd_CarLeave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_CarLeave.Location = new System.Drawing.Point(9, 135);
            this.cmd_CarLeave.Name = "cmd_CarLeave";
            this.cmd_CarLeave.Size = new System.Drawing.Size(101, 38);
            this.cmd_CarLeave.TabIndex = 34;
            this.cmd_CarLeave.Text = "车离开";
            this.cmd_CarLeave.UseVisualStyleBackColor = true;
            this.cmd_CarLeave.Click += new System.EventHandler(this.cmd_CarLeave_Click);
            // 
            // cmd_CarArrive
            // 
            this.cmd_CarArrive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmd_CarArrive.BackgroundImage")));
            this.cmd_CarArrive.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmd_CarArrive.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmd_CarArrive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_CarArrive.Location = new System.Drawing.Point(9, 3);
            this.cmd_CarArrive.Name = "cmd_CarArrive";
            this.cmd_CarArrive.Size = new System.Drawing.Size(101, 38);
            this.cmd_CarArrive.TabIndex = 33;
            this.cmd_CarArrive.Text = "车到位";
            this.cmd_CarArrive.UseVisualStyleBackColor = true;
            this.cmd_CarArrive.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_LaodMap);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(503, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(642, 214);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "配载图信息";
            // 
            // dataGridView_LaodMap
            // 
            this.dataGridView_LaodMap.AllowUserToDeleteRows = false;
            this.dataGridView_LaodMap.AllowUserToResizeRows = false;
            this.dataGridView_LaodMap.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_LaodMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_LaodMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LaodMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column20,
            this.Column1,
            this.Column3,
            this.STOCK_NO,
            this.Column4,
            this.Column7,
            this.Column8,
            this.STATUS,
            this.Column9,
            this.Column10});
            this.dataGridView_LaodMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LaodMap.Location = new System.Drawing.Point(3, 25);
            this.dataGridView_LaodMap.Name = "dataGridView_LaodMap";
            this.dataGridView_LaodMap.RowHeadersVisible = false;
            this.dataGridView_LaodMap.RowTemplate.Height = 23;
            this.dataGridView_LaodMap.Size = new System.Drawing.Size(636, 186);
            this.dataGridView_LaodMap.TabIndex = 7;
            this.dataGridView_LaodMap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_LaodMap_CellFormatting);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvCraneOder);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(503, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(642, 215);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "行车入库指令信息";
            // 
            // dgvCraneOder
            // 
            this.dgvCraneOder.AllowUserToResizeRows = false;
            this.dgvCraneOder.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCraneOder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCraneOder.ColumnHeadersHeight = 30;
            this.dgvCraneOder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.MAT_NO,
            this.FROM_STOCK_NO,
            this.TO_STOCK_NO,
            this.BAY_NO});
            this.dgvCraneOder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCraneOder.Location = new System.Drawing.Point(3, 25);
            this.dgvCraneOder.Name = "dgvCraneOder";
            this.dgvCraneOder.RowHeadersVisible = false;
            this.dgvCraneOder.RowTemplate.Height = 23;
            this.dgvCraneOder.Size = new System.Drawing.Size(636, 187);
            this.dgvCraneOder.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "GROOVEID";
            this.dataGridViewTextBoxColumn3.HeaderText = "槽号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // MAT_NO
            // 
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.HeaderText = "材料号";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAT_NO.Width = 150;
            // 
            // FROM_STOCK_NO
            // 
            this.FROM_STOCK_NO.DataPropertyName = "FROM_STOCK_NO";
            this.FROM_STOCK_NO.HeaderText = "起卷位置";
            this.FROM_STOCK_NO.Name = "FROM_STOCK_NO";
            this.FROM_STOCK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FROM_STOCK_NO.Width = 150;
            // 
            // TO_STOCK_NO
            // 
            this.TO_STOCK_NO.DataPropertyName = "TO_STOCK_NO";
            this.TO_STOCK_NO.HeaderText = "落卷位置";
            this.TO_STOCK_NO.Name = "TO_STOCK_NO";
            this.TO_STOCK_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TO_STOCK_NO.Width = 150;
            // 
            // BAY_NO
            // 
            this.BAY_NO.DataPropertyName = "BAY_NO";
            this.BAY_NO.HeaderText = "跨别";
            this.BAY_NO.Name = "BAY_NO";
            this.BAY_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 435);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_PT);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 154);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手持扫描信息";
            // 
            // dataGridView_PT
            // 
            this.dataGridView_PT.AllowUserToDeleteRows = false;
            this.dataGridView_PT.AllowUserToResizeRows = false;
            this.dataGridView_PT.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_PT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_PT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn17,
            this.Column6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.Column18,
            this.Column19});
            this.dataGridView_PT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_PT.Location = new System.Drawing.Point(3, 25);
            this.dataGridView_PT.Name = "dataGridView_PT";
            this.dataGridView_PT.RowHeadersVisible = false;
            this.dataGridView_PT.RowTemplate.Height = 23;
            this.dataGridView_PT.Size = new System.Drawing.Size(482, 126);
            this.dataGridView_PT.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PORTABLE_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 52;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "PT_ACTION_COUNT";
            this.dataGridViewTextBoxColumn17.HeaderText = "扫描次数";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 99;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "COIL_POSITION_7";
            this.Column6.HeaderText = "7位码";
            this.Column6.Name = "Column6";
            this.Column6.Width = 76;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MAT_NO";
            this.dataGridViewTextBoxColumn2.HeaderText = "材料号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 83;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MAT_DIRECTION";
            this.dataGridViewTextBoxColumn9.HeaderText = "开卷方向";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 99;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SLEEVE_LENGTH";
            this.dataGridViewTextBoxColumn10.HeaderText = "套筒长度";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 99;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PACKAGE_STATUS";
            this.dataGridViewTextBoxColumn11.HeaderText = "包装状态";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 99;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column18.DataPropertyName = "INDEX_Y";
            this.Column18.HeaderText = "INDEX_Y";
            this.Column18.Name = "Column18";
            this.Column18.Width = 101;
            // 
            // Column19
            // 
            this.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column19.DataPropertyName = "POS_IN_GROOVE";
            this.Column19.HeaderText = "槽内位置";
            this.Column19.Name = "Column19";
            this.Column19.Width = 99;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 269);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.parkLaserOut1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(480, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "配载图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // parkLaserOut1
            // 
            this.parkLaserOut1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parkLaserOut1.HasCarSize = true;
            this.parkLaserOut1.Location = new System.Drawing.Point(3, 3);
            this.parkLaserOut1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.parkLaserOut1.Name = "parkLaserOut1";
            this.parkLaserOut1.Size = new System.Drawing.Size(474, 229);
            this.parkLaserOut1.TabIndex = 39;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_LASER);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(480, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "激光扫描数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_LASER
            // 
            this.dataGridView_LASER.AllowUserToDeleteRows = false;
            this.dataGridView_LASER.AllowUserToResizeRows = false;
            this.dataGridView_LASER.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView_LASER.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LASER.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column5});
            this.dataGridView_LASER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LASER.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_LASER.Name = "dataGridView_LASER";
            this.dataGridView_LASER.RowHeadersVisible = false;
            this.dataGridView_LASER.RowTemplate.Height = 23;
            this.dataGridView_LASER.Size = new System.Drawing.Size(474, 229);
            this.dataGridView_LASER.TabIndex = 6;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "LASER_ID";
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Width = 52;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.DataPropertyName = "X_ACT_CENTER";
            this.Column11.HeaderText = "钢卷X轴";
            this.Column11.Name = "Column11";
            this.Column11.Width = 93;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column12.DataPropertyName = "Y_ACT_CENTER";
            this.Column12.HeaderText = "钢卷Y轴";
            this.Column12.Name = "Column12";
            this.Column12.Width = 93;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column13.DataPropertyName = "Z_ACT_CENTER";
            this.Column13.HeaderText = "钢卷Z轴";
            this.Column13.Name = "Column13";
            this.Column13.Width = 93;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column14.DataPropertyName = "STEELWIDE";
            this.Column14.HeaderText = "宽度";
            this.Column14.Name = "Column14";
            this.Column14.Width = 67;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column15.DataPropertyName = "STEELDIAMETER";
            this.Column15.HeaderText = "直径";
            this.Column15.Name = "Column15";
            this.Column15.Width = 67;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column16.DataPropertyName = "INDEX_Y";
            this.Column16.HeaderText = "INDEX_Y";
            this.Column16.Name = "Column16";
            this.Column16.Width = 101;
            // 
            // Column17
            // 
            this.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column17.DataPropertyName = "POS_IN_GROOVE";
            this.Column17.HeaderText = "槽内位置";
            this.Column17.Name = "Column17";
            this.Column17.Width = 99;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "LASER_ACTION_COUNT";
            this.Column5.HeaderText = "激光扫描次数";
            this.Column5.Name = "Column5";
            this.Column5.Width = 131;
            // 
            // tabPanelParkArea
            // 
            this.tabPanelParkArea.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPanelParkArea.ColumnCount = 13;
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tabPanelParkArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tabPanelParkArea.Controls.Add(this.park1, 1, 0);
            this.tabPanelParkArea.Controls.Add(this.park2, 3, 0);
            this.tabPanelParkArea.Controls.Add(this.park3, 5, 0);
            this.tabPanelParkArea.Controls.Add(this.park6, 11, 0);
            this.tabPanelParkArea.Controls.Add(this.park4, 7, 0);
            this.tabPanelParkArea.Controls.Add(this.park5, 9, 0);
            this.tabPanelParkArea.Controls.Add(this.panel4, 0, 0);
            this.tabPanelParkArea.Controls.Add(this.labTips, 12, 0);
            this.tabPanelParkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanelParkArea.Location = new System.Drawing.Point(3, 3);
            this.tabPanelParkArea.Name = "tabPanelParkArea";
            this.tabPanelParkArea.RowCount = 1;
            this.tabPanelParkArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPanelParkArea.Size = new System.Drawing.Size(1270, 91);
            this.tabPanelParkArea.TabIndex = 75;
            // 
            // park1
            // 
            this.park1.BackColor = System.Drawing.SystemColors.Control;
            this.park1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park1.Location = new System.Drawing.Point(96, 3);
            this.park1.Name = "park1";
            this.park1.Size = new System.Drawing.Size(165, 85);
            this.park1.TabIndex = 33;
            // 
            // park2
            // 
            this.park2.BackColor = System.Drawing.SystemColors.Control;
            this.park2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park2.Location = new System.Drawing.Point(277, 3);
            this.park2.Name = "park2";
            this.park2.Size = new System.Drawing.Size(165, 85);
            this.park2.TabIndex = 34;
            // 
            // park3
            // 
            this.park3.BackColor = System.Drawing.SystemColors.Control;
            this.park3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park3.Location = new System.Drawing.Point(458, 3);
            this.park3.Name = "park3";
            this.park3.Size = new System.Drawing.Size(165, 85);
            this.park3.TabIndex = 35;
            // 
            // park6
            // 
            this.park6.BackColor = System.Drawing.SystemColors.Control;
            this.park6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park6.Location = new System.Drawing.Point(990, 3);
            this.park6.Name = "park6";
            this.park6.Size = new System.Drawing.Size(154, 85);
            this.park6.TabIndex = 38;
            // 
            // park4
            // 
            this.park4.BackColor = System.Drawing.SystemColors.Control;
            this.park4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park4.Location = new System.Drawing.Point(639, 3);
            this.park4.Name = "park4";
            this.park4.Size = new System.Drawing.Size(165, 85);
            this.park4.TabIndex = 36;
            // 
            // park5
            // 
            this.park5.BackColor = System.Drawing.SystemColors.Control;
            this.park5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.park5.Location = new System.Drawing.Point(820, 3);
            this.park5.Name = "park5";
            this.park5.Size = new System.Drawing.Size(154, 85);
            this.park5.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(87, 85);
            this.panel4.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label10.Location = new System.Drawing.Point(7, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 30);
            this.label10.TabIndex = 72;
            this.label10.Text = "车位状态";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label13.Location = new System.Drawing.Point(6, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 30);
            this.label13.TabIndex = 73;
            this.label13.Text = "扫描状态";
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labTips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTips.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTips.Location = new System.Drawing.Point(1150, 0);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(117, 91);
            this.labTips.TabIndex = 40;
            this.labTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labTips.Visible = false;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "GROOVEID";
            this.Column20.Frozen = true;
            this.Column20.HeaderText = "槽号";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MAT_NO";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "材料号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "POS_ON_FRAME";
            this.Column3.HeaderText = "车上位置";
            this.Column3.Name = "Column3";
            this.Column3.Width = 77;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            this.STOCK_NO.HeaderText = "库位号";
            this.STOCK_NO.Name = "STOCK_NO";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "X_CENTER";
            this.Column4.HeaderText = "X坐标";
            this.Column4.Name = "Column4";
            this.Column4.Width = 71;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "Y_CENTER";
            this.Column7.HeaderText = "Y坐标";
            this.Column7.Name = "Column7";
            this.Column7.Width = 71;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "Z_CENTER";
            this.Column8.HeaderText = "Z坐标";
            this.Column8.Name = "Column8";
            this.Column8.Width = 71;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "车上状态";
            this.STATUS.Name = "STATUS";
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.DataPropertyName = "SLEEVE_LENGTH";
            this.Column9.HeaderText = "套筒长度";
            this.Column9.Name = "Column9";
            this.Column9.Width = 77;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.DataPropertyName = "PACKAGE_STATUS";
            this.Column10.HeaderText = "包装状态";
            this.Column10.Name = "Column10";
            this.Column10.Width = 77;
            // 
            // TruckStowageInT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1276, 662);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "TruckStowageInT";
            this.Text = "入库测试画面";
            this.TabActivated += new System.EventHandler(this.TruckStowageInT_TabActivated);
            this.TabDeactivated += new System.EventHandler(this.TruckStowageInT_TabDeactivated);
            this.Load += new System.EventHandler(this.TruckStowageInT_Load);
            this.Resize += new System.EventHandler(this.TruckStowageInT_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LaodMap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCraneOder)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PT)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LASER)).EndInit();
            this.tabPanelParkArea.ResumeLayout(false);
            this.tabPanelParkArea.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ParkingStatus;
        private System.Windows.Forms.TextBox txt_ISLoaded;
        private System.Windows.Forms.TextBox txt_TreatmentNO;
        private System.Windows.Forms.TextBox txt_HeadPos;
        private System.Windows.Forms.TextBox txt_LoadMapID;
        private System.Windows.Forms.TextBox txt_CarNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comb_ParkingNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_PT_ACTION_COUNT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_LASER_ACTION_COUNT;
        private System.Windows.Forms.Timer timer_RefrehHMI;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPTcount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLaserCount;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLaserStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_LaodMap;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvCraneOder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FROM_STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TO_STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_PT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ParkingControlLibrary.ParkLaserOut parkLaserOut1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_LASER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TableLayoutPanel tabPanelParkArea;
        private ParkingControlLibrary.ParkingState park1;
        private ParkingControlLibrary.ParkingState park2;
        private ParkingControlLibrary.ParkingState park3;
        private ParkingControlLibrary.ParkingState park6;
        private ParkingControlLibrary.ParkingState park4;
        private ParkingControlLibrary.ParkingState park5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labTips;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOperatePause;
        private System.Windows.Forms.Button btnOperateStrat;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button cmd_PTINEnd;
        private System.Windows.Forms.Button cmd_LaserINEnd;
        private System.Windows.Forms.Button cmd_LaserINStart;
        private System.Windows.Forms.Button cmd_CarLeave;
        private System.Windows.Forms.Button cmd_CarArrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}