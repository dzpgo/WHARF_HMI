﻿namespace HMI_OF_CRANEORDERCONFIG
{
    partial class FrmCraneScheme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenFlag = new System.Windows.Forms.Button();
            this.btnCloseFlag = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbCraneNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbBayNo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAreaToYard = new System.Windows.Forms.DataGridView();
            this.DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AREA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SADDLE_STRATEGY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLAG_ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_DIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FLOW_TO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTMS_dgvAreaToYard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AreaToYardByStop = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaToYardByOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.AreaToYardUpConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.area_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_AREA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_BAY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_X_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_X_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_Y_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_Y_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvCarToYard = new System.Windows.Forms.DataGridView();
            this.carToYard_CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carToYard_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carToYard_AREA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carToYard_FLAG_MY_DYUTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carToYard_FLAG_ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carToYard_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTMS_dgvCarToYard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CarToYardByStop = new System.Windows.Forms.ToolStripMenuItem();
            this.CarToYardByOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvYardToCar = new System.Windows.Forms.DataGridView();
            this.yardToCar_DESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_AREA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_FLAG_MY_DYUTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_FLAG_ENABLED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_COIL_STRATEGY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_X_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_X_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_Y_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_Y_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yardToCar_X_DIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTMS_dgvYardToCar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.YardToCarByStop = new System.Windows.Forms.ToolStripMenuItem();
            this.YardToCarByOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.YardToCarUpConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaToYard)).BeginInit();
            this.CTMS_dgvAreaToYard.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarToYard)).BeginInit();
            this.CTMS_dgvCarToYard.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYardToCar)).BeginInit();
            this.CTMS_dgvYardToCar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenFlag);
            this.panel1.Controls.Add(this.btnCloseFlag);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 117);
            this.panel1.TabIndex = 0;
            // 
            // btnOpenFlag
            // 
            this.btnOpenFlag.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnOpenFlag.BackColor = System.Drawing.Color.Wheat;
            this.btnOpenFlag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFlag.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenFlag.Location = new System.Drawing.Point(1511, 70);
            this.btnOpenFlag.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenFlag.Name = "btnOpenFlag";
            this.btnOpenFlag.Size = new System.Drawing.Size(147, 29);
            this.btnOpenFlag.TabIndex = 6;
            this.btnOpenFlag.Text = "打开所有方案";
            this.btnOpenFlag.UseVisualStyleBackColor = false;
            this.btnOpenFlag.Click += new System.EventHandler(this.btnOpenFlag_Click);
            // 
            // btnCloseFlag
            // 
            this.btnCloseFlag.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCloseFlag.BackColor = System.Drawing.Color.Wheat;
            this.btnCloseFlag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseFlag.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseFlag.Location = new System.Drawing.Point(1511, 33);
            this.btnCloseFlag.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseFlag.Name = "btnCloseFlag";
            this.btnCloseFlag.Size = new System.Drawing.Size(147, 29);
            this.btnCloseFlag.TabIndex = 5;
            this.btnCloseFlag.Text = "关闭所有方案";
            this.btnCloseFlag.UseVisualStyleBackColor = false;
            this.btnCloseFlag.Click += new System.EventHandler(this.btnCloseFlag_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(711, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(759, 117);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "类型选项";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton6.Location = new System.Drawing.Point(673, 46);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(60, 23);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "机组";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton5.Location = new System.Drawing.Point(564, 46);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(75, 23);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "小卷区";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(439, 46);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 23);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "自动包装";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(175, 46);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(120, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "离线包装入库";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(67, 46);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全部";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(344, 46);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 23);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "入库";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbCraneNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbBayNo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(711, 117);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "行车号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(375, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "行车号：";
            // 
            // cbbCraneNo
            // 
            this.cbbCraneNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbCraneNo.FormattingEnabled = true;
            this.cbbCraneNo.Location = new System.Drawing.Point(479, 41);
            this.cbbCraneNo.Margin = new System.Windows.Forms.Padding(4);
            this.cbbCraneNo.Name = "cbbCraneNo";
            this.cbbCraneNo.Size = new System.Drawing.Size(181, 31);
            this.cbbCraneNo.TabIndex = 6;
            this.cbbCraneNo.Text = "6_1";
            this.cbbCraneNo.SelectedIndexChanged += new System.EventHandler(this.cbbCraneNo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "跨别：";
            // 
            // cbbBayNo
            // 
            this.cbbBayNo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbBayNo.FormattingEnabled = true;
            this.cbbBayNo.Items.AddRange(new object[] {
            "Z72-1",
            "Z71-1"});
            this.cbbBayNo.Location = new System.Drawing.Point(111, 41);
            this.cbbBayNo.Margin = new System.Windows.Forms.Padding(4);
            this.cbbBayNo.Name = "cbbBayNo";
            this.cbbBayNo.Size = new System.Drawing.Size(181, 31);
            this.cbbBayNo.TabIndex = 4;
            this.cbbBayNo.Text = "Z71-1";
            this.cbbBayNo.SelectedIndexChanged += new System.EventHandler(this.cbbBayNo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAreaToYard);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(4, 129);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1688, 199);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "行车方案配置";
            // 
            // dgvAreaToYard
            // 
            this.dgvAreaToYard.AllowUserToAddRows = false;
            this.dgvAreaToYard.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAreaToYard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAreaToYard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreaToYard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DESC,
            this.ID,
            this.CRANE_NO,
            this.AREA_ID,
            this.SADDLE_STRATEGY_ID,
            this.FLAG_ENABLED,
            this.SEQ,
            this.X_MAX,
            this.X_MIN,
            this.Y_MAX,
            this.Y_MIN,
            this.X_DIR,
            this.FLOW_TO});
            this.dgvAreaToYard.ContextMenuStrip = this.CTMS_dgvAreaToYard;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAreaToYard.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAreaToYard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAreaToYard.EnableHeadersVisualStyles = false;
            this.dgvAreaToYard.Location = new System.Drawing.Point(4, 28);
            this.dgvAreaToYard.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAreaToYard.Name = "dgvAreaToYard";
            this.dgvAreaToYard.ReadOnly = true;
            this.dgvAreaToYard.RowTemplate.Height = 23;
            this.dgvAreaToYard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAreaToYard.Size = new System.Drawing.Size(1680, 167);
            this.dgvAreaToYard.TabIndex = 1;
            this.dgvAreaToYard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAreaToYard_CellClick);
            // 
            // DESC
            // 
            this.DESC.HeaderText = "描述";
            this.DESC.Name = "DESC";
            this.DESC.ReadOnly = true;
            this.DESC.Width = 200;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // CRANE_NO
            // 
            this.CRANE_NO.HeaderText = "行车号";
            this.CRANE_NO.Name = "CRANE_NO";
            this.CRANE_NO.ReadOnly = true;
            // 
            // AREA_ID
            // 
            this.AREA_ID.HeaderText = "区域";
            this.AREA_ID.Name = "AREA_ID";
            this.AREA_ID.ReadOnly = true;
            // 
            // SADDLE_STRATEGY_ID
            // 
            this.SADDLE_STRATEGY_ID.HeaderText = "鞍座编号";
            this.SADDLE_STRATEGY_ID.Name = "SADDLE_STRATEGY_ID";
            this.SADDLE_STRATEGY_ID.ReadOnly = true;
            // 
            // FLAG_ENABLED
            // 
            this.FLAG_ENABLED.HeaderText = "是否生效";
            this.FLAG_ENABLED.Name = "FLAG_ENABLED";
            this.FLAG_ENABLED.ReadOnly = true;
            // 
            // SEQ
            // 
            this.SEQ.HeaderText = "序号";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            // 
            // X_MAX
            // 
            this.X_MAX.HeaderText = "X最大";
            this.X_MAX.Name = "X_MAX";
            this.X_MAX.ReadOnly = true;
            // 
            // X_MIN
            // 
            this.X_MIN.HeaderText = "X最小";
            this.X_MIN.Name = "X_MIN";
            this.X_MIN.ReadOnly = true;
            // 
            // Y_MAX
            // 
            this.Y_MAX.HeaderText = "Y最大";
            this.Y_MAX.Name = "Y_MAX";
            this.Y_MAX.ReadOnly = true;
            // 
            // Y_MIN
            // 
            this.Y_MIN.HeaderText = "Y最小";
            this.Y_MIN.Name = "Y_MIN";
            this.Y_MIN.ReadOnly = true;
            // 
            // X_DIR
            // 
            this.X_DIR.HeaderText = "X方向";
            this.X_DIR.Name = "X_DIR";
            this.X_DIR.ReadOnly = true;
            // 
            // FLOW_TO
            // 
            this.FLOW_TO.HeaderText = "流向";
            this.FLOW_TO.Name = "FLOW_TO";
            this.FLOW_TO.ReadOnly = true;
            this.FLOW_TO.Width = 300;
            // 
            // CTMS_dgvAreaToYard
            // 
            this.CTMS_dgvAreaToYard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CTMS_dgvAreaToYard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AreaToYardByStop,
            this.AreaToYardByOpen,
            this.AreaToYardUpConfig});
            this.CTMS_dgvAreaToYard.Name = "CTMS_dgvAreaToYard";
            this.CTMS_dgvAreaToYard.Size = new System.Drawing.Size(139, 76);
            // 
            // AreaToYardByStop
            // 
            this.AreaToYardByStop.Name = "AreaToYardByStop";
            this.AreaToYardByStop.Size = new System.Drawing.Size(138, 24);
            this.AreaToYardByStop.Text = "停止方案";
            this.AreaToYardByStop.Click += new System.EventHandler(this.AreaToYardByStop_Click);
            // 
            // AreaToYardByOpen
            // 
            this.AreaToYardByOpen.Name = "AreaToYardByOpen";
            this.AreaToYardByOpen.Size = new System.Drawing.Size(138, 24);
            this.AreaToYardByOpen.Text = "打开方案";
            this.AreaToYardByOpen.Click += new System.EventHandler(this.AreaToYardByOpen_Click);
            // 
            // AreaToYardUpConfig
            // 
            this.AreaToYardUpConfig.Name = "AreaToYardUpConfig";
            this.AreaToYardUpConfig.Size = new System.Drawing.Size(138, 24);
            this.AreaToYardUpConfig.Text = "修改配置";
            this.AreaToYardUpConfig.Click += new System.EventHandler(this.AreaToYardUpConfig_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvArea);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(4, 336);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1688, 199);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "区域信息";
            // 
            // dgvArea
            // 
            this.dgvArea.AllowUserToAddRows = false;
            this.dgvArea.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArea.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.area_DESC,
            this.area_AREA_ID,
            this.area_BAY_NO,
            this.area_X_MIN,
            this.area_X_MAX,
            this.area_Y_MIN,
            this.area_Y_MAX,
            this.area_TYPE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArea.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArea.EnableHeadersVisualStyles = false;
            this.dgvArea.Location = new System.Drawing.Point(4, 28);
            this.dgvArea.Margin = new System.Windows.Forms.Padding(4);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.ReadOnly = true;
            this.dgvArea.RowTemplate.Height = 23;
            this.dgvArea.Size = new System.Drawing.Size(1680, 167);
            this.dgvArea.TabIndex = 2;
            // 
            // area_DESC
            // 
            this.area_DESC.HeaderText = "描述";
            this.area_DESC.Name = "area_DESC";
            this.area_DESC.ReadOnly = true;
            this.area_DESC.Width = 200;
            // 
            // area_AREA_ID
            // 
            this.area_AREA_ID.HeaderText = "区域号";
            this.area_AREA_ID.Name = "area_AREA_ID";
            this.area_AREA_ID.ReadOnly = true;
            // 
            // area_BAY_NO
            // 
            this.area_BAY_NO.HeaderText = "跨别";
            this.area_BAY_NO.Name = "area_BAY_NO";
            this.area_BAY_NO.ReadOnly = true;
            // 
            // area_X_MIN
            // 
            this.area_X_MIN.HeaderText = "X最小";
            this.area_X_MIN.Name = "area_X_MIN";
            this.area_X_MIN.ReadOnly = true;
            // 
            // area_X_MAX
            // 
            this.area_X_MAX.HeaderText = "X最大";
            this.area_X_MAX.Name = "area_X_MAX";
            this.area_X_MAX.ReadOnly = true;
            // 
            // area_Y_MIN
            // 
            this.area_Y_MIN.HeaderText = "Y最小";
            this.area_Y_MIN.Name = "area_Y_MIN";
            this.area_Y_MIN.ReadOnly = true;
            // 
            // area_Y_MAX
            // 
            this.area_Y_MAX.HeaderText = "Y最大";
            this.area_Y_MAX.Name = "area_Y_MAX";
            this.area_Y_MAX.ReadOnly = true;
            // 
            // area_TYPE
            // 
            this.area_TYPE.HeaderText = "类别";
            this.area_TYPE.Name = "area_TYPE";
            this.area_TYPE.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvCarToYard);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(4, 543);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(1688, 199);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "行车入库方案配置";
            // 
            // dgvCarToYard
            // 
            this.dgvCarToYard.AllowUserToAddRows = false;
            this.dgvCarToYard.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarToYard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCarToYard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarToYard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carToYard_CRANE_NO,
            this.carToYard_ID,
            this.carToYard_AREA_ID,
            this.carToYard_FLAG_MY_DYUTY,
            this.carToYard_FLAG_ENABLED,
            this.carToYard_SEQ});
            this.dgvCarToYard.ContextMenuStrip = this.CTMS_dgvCarToYard;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarToYard.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCarToYard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarToYard.EnableHeadersVisualStyles = false;
            this.dgvCarToYard.Location = new System.Drawing.Point(4, 28);
            this.dgvCarToYard.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCarToYard.Name = "dgvCarToYard";
            this.dgvCarToYard.ReadOnly = true;
            this.dgvCarToYard.RowTemplate.Height = 23;
            this.dgvCarToYard.Size = new System.Drawing.Size(1680, 167);
            this.dgvCarToYard.TabIndex = 3;
            this.dgvCarToYard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarToYard_CellClick);
            // 
            // carToYard_CRANE_NO
            // 
            this.carToYard_CRANE_NO.HeaderText = "行车号";
            this.carToYard_CRANE_NO.Name = "carToYard_CRANE_NO";
            this.carToYard_CRANE_NO.ReadOnly = true;
            // 
            // carToYard_ID
            // 
            this.carToYard_ID.HeaderText = "ID";
            this.carToYard_ID.Name = "carToYard_ID";
            this.carToYard_ID.ReadOnly = true;
            // 
            // carToYard_AREA_ID
            // 
            this.carToYard_AREA_ID.HeaderText = "停车位号";
            this.carToYard_AREA_ID.Name = "carToYard_AREA_ID";
            this.carToYard_AREA_ID.ReadOnly = true;
            // 
            // carToYard_FLAG_MY_DYUTY
            // 
            this.carToYard_FLAG_MY_DYUTY.HeaderText = "工作类型";
            this.carToYard_FLAG_MY_DYUTY.Name = "carToYard_FLAG_MY_DYUTY";
            this.carToYard_FLAG_MY_DYUTY.ReadOnly = true;
            // 
            // carToYard_FLAG_ENABLED
            // 
            this.carToYard_FLAG_ENABLED.HeaderText = "是否生效";
            this.carToYard_FLAG_ENABLED.Name = "carToYard_FLAG_ENABLED";
            this.carToYard_FLAG_ENABLED.ReadOnly = true;
            // 
            // carToYard_SEQ
            // 
            this.carToYard_SEQ.HeaderText = "执行顺序";
            this.carToYard_SEQ.Name = "carToYard_SEQ";
            this.carToYard_SEQ.ReadOnly = true;
            // 
            // CTMS_dgvCarToYard
            // 
            this.CTMS_dgvCarToYard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CTMS_dgvCarToYard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarToYardByStop,
            this.CarToYardByOpen});
            this.CTMS_dgvCarToYard.Name = "CTMS_dgvAreaToYard";
            this.CTMS_dgvCarToYard.Size = new System.Drawing.Size(139, 52);
            // 
            // CarToYardByStop
            // 
            this.CarToYardByStop.Name = "CarToYardByStop";
            this.CarToYardByStop.Size = new System.Drawing.Size(138, 24);
            this.CarToYardByStop.Text = "停止方案";
            this.CarToYardByStop.Click += new System.EventHandler(this.CarToYardByStop_Click);
            // 
            // CarToYardByOpen
            // 
            this.CarToYardByOpen.Name = "CarToYardByOpen";
            this.CarToYardByOpen.Size = new System.Drawing.Size(138, 24);
            this.CarToYardByOpen.Text = "打开方案";
            this.CarToYardByOpen.Click += new System.EventHandler(this.CarToYardByOpen_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvYardToCar);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(4, 750);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(1688, 201);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "行车出库方案配置";
            // 
            // dgvYardToCar
            // 
            this.dgvYardToCar.AllowUserToAddRows = false;
            this.dgvYardToCar.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvYardToCar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvYardToCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYardToCar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yardToCar_DESC,
            this.yardToCar_CRANE_NO,
            this.yardToCar_ID,
            this.yardToCar_AREA_ID,
            this.yardToCar_FLAG_MY_DYUTY,
            this.yardToCar_FLAG_ENABLED,
            this.yardToCar_SEQ,
            this.yardToCar_COIL_STRATEGY_ID,
            this.yardToCar_X_MIN,
            this.yardToCar_X_MAX,
            this.yardToCar_Y_MIN,
            this.yardToCar_Y_MAX,
            this.yardToCar_X_DIR});
            this.dgvYardToCar.ContextMenuStrip = this.CTMS_dgvYardToCar;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvYardToCar.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvYardToCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYardToCar.EnableHeadersVisualStyles = false;
            this.dgvYardToCar.Location = new System.Drawing.Point(4, 28);
            this.dgvYardToCar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvYardToCar.Name = "dgvYardToCar";
            this.dgvYardToCar.ReadOnly = true;
            this.dgvYardToCar.RowTemplate.Height = 23;
            this.dgvYardToCar.Size = new System.Drawing.Size(1680, 169);
            this.dgvYardToCar.TabIndex = 3;
            // 
            // yardToCar_DESC
            // 
            this.yardToCar_DESC.HeaderText = "描述";
            this.yardToCar_DESC.Name = "yardToCar_DESC";
            this.yardToCar_DESC.ReadOnly = true;
            this.yardToCar_DESC.Width = 200;
            // 
            // yardToCar_CRANE_NO
            // 
            this.yardToCar_CRANE_NO.HeaderText = "行车号";
            this.yardToCar_CRANE_NO.Name = "yardToCar_CRANE_NO";
            this.yardToCar_CRANE_NO.ReadOnly = true;
            // 
            // yardToCar_ID
            // 
            this.yardToCar_ID.HeaderText = "ID";
            this.yardToCar_ID.Name = "yardToCar_ID";
            this.yardToCar_ID.ReadOnly = true;
            // 
            // yardToCar_AREA_ID
            // 
            this.yardToCar_AREA_ID.HeaderText = "停车位号";
            this.yardToCar_AREA_ID.Name = "yardToCar_AREA_ID";
            this.yardToCar_AREA_ID.ReadOnly = true;
            // 
            // yardToCar_FLAG_MY_DYUTY
            // 
            this.yardToCar_FLAG_MY_DYUTY.HeaderText = "工作类型";
            this.yardToCar_FLAG_MY_DYUTY.Name = "yardToCar_FLAG_MY_DYUTY";
            this.yardToCar_FLAG_MY_DYUTY.ReadOnly = true;
            // 
            // yardToCar_FLAG_ENABLED
            // 
            this.yardToCar_FLAG_ENABLED.HeaderText = "是否生效";
            this.yardToCar_FLAG_ENABLED.Name = "yardToCar_FLAG_ENABLED";
            this.yardToCar_FLAG_ENABLED.ReadOnly = true;
            // 
            // yardToCar_SEQ
            // 
            this.yardToCar_SEQ.HeaderText = "执行顺序";
            this.yardToCar_SEQ.Name = "yardToCar_SEQ";
            this.yardToCar_SEQ.ReadOnly = true;
            // 
            // yardToCar_COIL_STRATEGY_ID
            // 
            this.yardToCar_COIL_STRATEGY_ID.HeaderText = "找卷ID";
            this.yardToCar_COIL_STRATEGY_ID.Name = "yardToCar_COIL_STRATEGY_ID";
            this.yardToCar_COIL_STRATEGY_ID.ReadOnly = true;
            // 
            // yardToCar_X_MIN
            // 
            this.yardToCar_X_MIN.HeaderText = "X最小";
            this.yardToCar_X_MIN.Name = "yardToCar_X_MIN";
            this.yardToCar_X_MIN.ReadOnly = true;
            // 
            // yardToCar_X_MAX
            // 
            this.yardToCar_X_MAX.HeaderText = "X最大";
            this.yardToCar_X_MAX.Name = "yardToCar_X_MAX";
            this.yardToCar_X_MAX.ReadOnly = true;
            // 
            // yardToCar_Y_MIN
            // 
            this.yardToCar_Y_MIN.HeaderText = "Y最小";
            this.yardToCar_Y_MIN.Name = "yardToCar_Y_MIN";
            this.yardToCar_Y_MIN.ReadOnly = true;
            // 
            // yardToCar_Y_MAX
            // 
            this.yardToCar_Y_MAX.HeaderText = "Y最大";
            this.yardToCar_Y_MAX.Name = "yardToCar_Y_MAX";
            this.yardToCar_Y_MAX.ReadOnly = true;
            // 
            // yardToCar_X_DIR
            // 
            this.yardToCar_X_DIR.HeaderText = "寻找方向";
            this.yardToCar_X_DIR.Name = "yardToCar_X_DIR";
            this.yardToCar_X_DIR.ReadOnly = true;
            // 
            // CTMS_dgvYardToCar
            // 
            this.CTMS_dgvYardToCar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CTMS_dgvYardToCar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.YardToCarByStop,
            this.YardToCarByOpen,
            this.YardToCarUpConfig});
            this.CTMS_dgvYardToCar.Name = "CTMS_dgvAreaToYard";
            this.CTMS_dgvYardToCar.Size = new System.Drawing.Size(139, 76);
            // 
            // YardToCarByStop
            // 
            this.YardToCarByStop.Name = "YardToCarByStop";
            this.YardToCarByStop.Size = new System.Drawing.Size(138, 24);
            this.YardToCarByStop.Text = "停止方案";
            this.YardToCarByStop.Click += new System.EventHandler(this.YardToCarByStop_Click);
            // 
            // YardToCarByOpen
            // 
            this.YardToCarByOpen.Name = "YardToCarByOpen";
            this.YardToCarByOpen.Size = new System.Drawing.Size(138, 24);
            this.YardToCarByOpen.Text = "打开方案";
            this.YardToCarByOpen.Click += new System.EventHandler(this.YardToCarByOpen_Click);
            // 
            // YardToCarUpConfig
            // 
            this.YardToCarUpConfig.Name = "YardToCarUpConfig";
            this.YardToCarUpConfig.Size = new System.Drawing.Size(138, 24);
            this.YardToCarUpConfig.Text = "修改配置";
            this.YardToCarUpConfig.Click += new System.EventHandler(this.YardToCarUpConfig_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1696, 955);
            this.panel2.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1696, 955);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FrmCraneScheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1696, 955);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmCraneScheme";
            this.Text = "FrmCraneScheme";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreaToYard)).EndInit();
            this.CTMS_dgvAreaToYard.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarToYard)).EndInit();
            this.CTMS_dgvCarToYard.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYardToCar)).EndInit();
            this.CTMS_dgvYardToCar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbCraneNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbBayNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAreaToYard;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvCarToYard;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvYardToCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_AREA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_FLAG_MY_DYUTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_FLAG_ENABLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn carToYard_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_AREA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_BAY_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_X_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_X_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_Y_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_Y_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn area_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_AREA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_FLAG_MY_DYUTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_FLAG_ENABLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_COIL_STRATEGY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_X_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_X_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_Y_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_Y_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn yardToCar_X_DIR;
        private System.Windows.Forms.ContextMenuStrip CTMS_dgvAreaToYard;
        private System.Windows.Forms.ToolStripMenuItem AreaToYardByStop;
        private System.Windows.Forms.ToolStripMenuItem AreaToYardByOpen;
        private System.Windows.Forms.ContextMenuStrip CTMS_dgvCarToYard;
        private System.Windows.Forms.ToolStripMenuItem CarToYardByStop;
        private System.Windows.Forms.ToolStripMenuItem CarToYardByOpen;
        private System.Windows.Forms.ContextMenuStrip CTMS_dgvYardToCar;
        private System.Windows.Forms.ToolStripMenuItem YardToCarByStop;
        private System.Windows.Forms.ToolStripMenuItem YardToCarByOpen;
        private System.Windows.Forms.ToolStripMenuItem AreaToYardUpConfig;
        private System.Windows.Forms.ToolStripMenuItem YardToCarUpConfig;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Button btnCloseFlag;
        private System.Windows.Forms.Button btnOpenFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AREA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SADDLE_STRATEGY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLAG_ENABLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_DIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FLOW_TO;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}