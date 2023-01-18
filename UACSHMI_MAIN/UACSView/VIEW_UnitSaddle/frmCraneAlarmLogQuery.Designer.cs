namespace Crane_Alarm_Log
{
    partial class frmCraneAlarmLogQuery
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlarmCode = new System.Windows.Forms.TextBox();
            this.comboBox_ShipLotNo = new System.Windows.Forms.ComboBox();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GridAlarmLog = new System.Windows.Forms.DataGridView();
            this.CRANE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_INFO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALARM_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_ACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_ACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z_ACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HAS_COIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLAMP_WIDTH_ACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTROL_MODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRANE_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAlarmLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAlarmCode);
            this.panel1.Controls.Add(this.comboBox_ShipLotNo);
            this.panel1.Controls.Add(this.cmdQuery);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dateTimePicker_End);
            this.panel1.Controls.Add(this.dateTimePicker_Start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 70);
            this.panel1.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDown.BackgroundImage = global::UACSView.Properties.Resources.bg_btn;
            this.btnDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.Location = new System.Drawing.Point(1263, 20);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(101, 38);
            this.btnDown.TabIndex = 26;
            this.btnDown.Text = "向下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUp.BackgroundImage = global::UACSView.Properties.Resources.bg_btn;
            this.btnUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUp.Location = new System.Drawing.Point(1158, 20);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(101, 38);
            this.btnUp.TabIndex = 25;
            this.btnUp.Text = "向上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(938, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 24;
            this.label2.Text = "报警号";
            // 
            // txtAlarmCode
            // 
            this.txtAlarmCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtAlarmCode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtAlarmCode.Location = new System.Drawing.Point(1001, 24);
            this.txtAlarmCode.Name = "txtAlarmCode";
            this.txtAlarmCode.Size = new System.Drawing.Size(145, 29);
            this.txtAlarmCode.TabIndex = 23;
            // 
            // comboBox_ShipLotNo
            // 
            this.comboBox_ShipLotNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_ShipLotNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_ShipLotNo.FormattingEnabled = true;
            this.comboBox_ShipLotNo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_ShipLotNo.Location = new System.Drawing.Point(616, 23);
            this.comboBox_ShipLotNo.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_ShipLotNo.Name = "comboBox_ShipLotNo";
            this.comboBox_ShipLotNo.Size = new System.Drawing.Size(92, 29);
            this.comboBox_ShipLotNo.TabIndex = 22;
            // 
            // cmdQuery
            // 
            this.cmdQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdQuery.BackgroundImage = global::UACSView.Properties.Resources.bg_btn;
            this.cmdQuery.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmdQuery.Location = new System.Drawing.Point(720, 20);
            this.cmdQuery.Margin = new System.Windows.Forms.Padding(2);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(101, 38);
            this.cmdQuery.TabIndex = 21;
            this.cmdQuery.Text = "查    询";
            this.cmdQuery.UseVisualStyleBackColor = true;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "开始时间";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(571, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "行车";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(292, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "结束时间";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_End.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_End.Location = new System.Drawing.Point(369, 23);
            this.dateTimePicker_End.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(190, 29);
            this.dateTimePicker_End.TabIndex = 17;
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker_Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Start.Location = new System.Drawing.Point(86, 23);
            this.dateTimePicker_Start.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(194, 29);
            this.dateTimePicker_Start.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GridAlarmLog);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1370, 679);
            this.panel3.TabIndex = 2;
            // 
            // GridAlarmLog
            // 
            this.GridAlarmLog.AllowUserToAddRows = false;
            this.GridAlarmLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.Moccasin;
            this.GridAlarmLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.GridAlarmLog.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridAlarmLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.GridAlarmLog.ColumnHeadersHeight = 30;
            this.GridAlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridAlarmLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CRANE_NO,
            this.ALARM_CODE,
            this.ALARM_INFO,
            this.ALARM_CLASS,
            this.ALARM_TIME,
            this.X_ACT,
            this.Y_ACT,
            this.Z_ACT,
            this.HAS_COIL,
            this.CLAMP_WIDTH_ACT,
            this.CONTROL_MODE,
            this.CRANE_STATUS,
            this.ORDER_ID});
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridAlarmLog.DefaultCellStyle = dataGridViewCellStyle34;
            this.GridAlarmLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridAlarmLog.EnableHeadersVisualStyles = false;
            this.GridAlarmLog.Location = new System.Drawing.Point(0, 0);
            this.GridAlarmLog.Margin = new System.Windows.Forms.Padding(2);
            this.GridAlarmLog.Name = "GridAlarmLog";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridAlarmLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.GridAlarmLog.RowHeadersVisible = false;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GridAlarmLog.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.GridAlarmLog.RowTemplate.Height = 45;
            this.GridAlarmLog.RowTemplate.ReadOnly = true;
            this.GridAlarmLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridAlarmLog.Size = new System.Drawing.Size(1370, 679);
            this.GridAlarmLog.TabIndex = 86;
            // 
            // CRANE_NO
            // 
            this.CRANE_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CRANE_NO.FillWeight = 15F;
            this.CRANE_NO.HeaderText = "行车号";
            this.CRANE_NO.Name = "CRANE_NO";
            this.CRANE_NO.ReadOnly = true;
            this.CRANE_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ALARM_CODE
            // 
            this.ALARM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ALARM_CODE.FillWeight = 15F;
            this.ALARM_CODE.HeaderText = "报警代码";
            this.ALARM_CODE.MinimumWidth = 130;
            this.ALARM_CODE.Name = "ALARM_CODE";
            this.ALARM_CODE.ReadOnly = true;
            this.ALARM_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALARM_CODE.Width = 130;
            // 
            // ALARM_INFO
            // 
            this.ALARM_INFO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ALARM_INFO.DefaultCellStyle = dataGridViewCellStyle33;
            this.ALARM_INFO.FillWeight = 15F;
            this.ALARM_INFO.HeaderText = "描述";
            this.ALARM_INFO.Name = "ALARM_INFO";
            this.ALARM_INFO.ReadOnly = true;
            this.ALARM_INFO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALARM_INFO.Width = 250;
            // 
            // ALARM_CLASS
            // 
            this.ALARM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ALARM_CLASS.FillWeight = 20F;
            this.ALARM_CLASS.HeaderText = "等级";
            this.ALARM_CLASS.Name = "ALARM_CLASS";
            this.ALARM_CLASS.ReadOnly = true;
            this.ALARM_CLASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ALARM_TIME
            // 
            this.ALARM_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ALARM_TIME.FillWeight = 20F;
            this.ALARM_TIME.HeaderText = "记录时刻";
            this.ALARM_TIME.Name = "ALARM_TIME";
            this.ALARM_TIME.ReadOnly = true;
            this.ALARM_TIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ALARM_TIME.Width = 200;
            // 
            // X_ACT
            // 
            this.X_ACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.X_ACT.FillWeight = 5F;
            this.X_ACT.HeaderText = "X";
            this.X_ACT.Name = "X_ACT";
            this.X_ACT.ReadOnly = true;
            this.X_ACT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.X_ACT.Width = 80;
            // 
            // Y_ACT
            // 
            this.Y_ACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Y_ACT.FillWeight = 5F;
            this.Y_ACT.HeaderText = "Y";
            this.Y_ACT.Name = "Y_ACT";
            this.Y_ACT.ReadOnly = true;
            this.Y_ACT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Y_ACT.Width = 80;
            // 
            // Z_ACT
            // 
            this.Z_ACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Z_ACT.FillWeight = 5F;
            this.Z_ACT.HeaderText = "Z";
            this.Z_ACT.Name = "Z_ACT";
            this.Z_ACT.ReadOnly = true;
            this.Z_ACT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Z_ACT.Width = 80;
            // 
            // HAS_COIL
            // 
            this.HAS_COIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HAS_COIL.FillWeight = 5F;
            this.HAS_COIL.HeaderText = "有卷";
            this.HAS_COIL.Name = "HAS_COIL";
            this.HAS_COIL.ReadOnly = true;
            this.HAS_COIL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HAS_COIL.Width = 50;
            // 
            // CLAMP_WIDTH_ACT
            // 
            this.CLAMP_WIDTH_ACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CLAMP_WIDTH_ACT.FillWeight = 5F;
            this.CLAMP_WIDTH_ACT.HeaderText = "夹钳开度";
            this.CLAMP_WIDTH_ACT.Name = "CLAMP_WIDTH_ACT";
            this.CLAMP_WIDTH_ACT.ReadOnly = true;
            this.CLAMP_WIDTH_ACT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CLAMP_WIDTH_ACT.Visible = false;
            this.CLAMP_WIDTH_ACT.Width = 75;
            // 
            // CONTROL_MODE
            // 
            this.CONTROL_MODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CONTROL_MODE.HeaderText = "控制模式";
            this.CONTROL_MODE.Name = "CONTROL_MODE";
            // 
            // CRANE_STATUS
            // 
            this.CRANE_STATUS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CRANE_STATUS.HeaderText = "行车状态";
            this.CRANE_STATUS.Name = "CRANE_STATUS";
            // 
            // ORDER_ID
            // 
            this.ORDER_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ORDER_ID.HeaderText = "指令号";
            this.ORDER_ID.Name = "ORDER_ID";
            // 
            // frmCraneAlarmLogQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmCraneAlarmLogQuery";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridAlarmLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox_ShipLotNo;
        private System.Windows.Forms.Button cmdQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DataGridView GridAlarmLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlarmCode;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_INFO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALARM_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_ACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_ACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z_ACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAS_COIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAMP_WIDTH_ACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTROL_MODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRANE_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_ID;
    }
}

