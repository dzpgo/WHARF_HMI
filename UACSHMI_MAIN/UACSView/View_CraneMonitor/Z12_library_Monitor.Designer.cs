namespace UACSView.View_CraneMonitor
{
    partial class Z12_library_Monitor
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
            this.panelZ11_Z12Bay = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.Label();
            this.conCrane1_4 = new UACSControls.conCrane();
            this.conCrane1_3 = new UACSControls.conCrane();
            this.conCrane1_2 = new UACSControls.conCrane();
            this.conCrane1_1 = new UACSControls.conCrane();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.timerCrane = new System.Windows.Forms.Timer(this.components);
            this.timerArea = new System.Windows.Forms.Timer(this.components);
            this.timerUnit = new System.Windows.Forms.Timer(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.timer_ShowXY = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.conCraneStatus1_4 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_3 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_2 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_1 = new UACSControls.conCraneStatus();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCrane_4_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_3_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_2_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_1_WaterStatus = new System.Windows.Forms.Button();
            this.btnSeekCoil = new System.Windows.Forms.Button();
            this.btnShowXY = new System.Windows.Forms.Button();
            this.btnShowCrane = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelZ53BayS = new System.Windows.Forms.Panel();
            this.timer_InitializeLoad = new System.Windows.Forms.Timer(this.components);
            this.panelZ11_Z12Bay.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelZ53BayS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelZ11_Z12Bay
            // 
            this.panelZ11_Z12Bay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelZ11_Z12Bay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZ11_Z12Bay.Controls.Add(this.panel4);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_4);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_3);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_2);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_1);
            this.panelZ11_Z12Bay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZ11_Z12Bay.Location = new System.Drawing.Point(0, 0);
            this.panelZ11_Z12Bay.Name = "panelZ11_Z12Bay";
            this.panelZ11_Z12Bay.Size = new System.Drawing.Size(1314, 424);
            this.panelZ11_Z12Bay.TabIndex = 6;
            this.panelZ11_Z12Bay.Paint += new System.Windows.Forms.PaintEventHandler(this.panelZ11_Z22Bay_Paint_1);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtY);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtX);
            this.panel4.Location = new System.Drawing.Point(1214, 358);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 66);
            this.panel4.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "X:";
            // 
            // txtY
            // 
            this.txtY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtY.AutoSize = true;
            this.txtY.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtY.ForeColor = System.Drawing.Color.White;
            this.txtY.Location = new System.Drawing.Point(36, 37);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(50, 17);
            this.txtY.TabIndex = 15;
            this.txtY.Text = "999999";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Y:";
            // 
            // txtX
            // 
            this.txtX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtX.AutoSize = true;
            this.txtX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtX.ForeColor = System.Drawing.Color.White;
            this.txtX.Location = new System.Drawing.Point(36, 5);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(50, 17);
            this.txtX.TabIndex = 14;
            this.txtX.Text = "999999";
            // 
            // conCrane1_4
            // 
            this.conCrane1_4.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_4.CraneNO = null;
            this.conCrane1_4.Location = new System.Drawing.Point(714, 22);
            this.conCrane1_4.Name = "conCrane1_4";
            this.conCrane1_4.Size = new System.Drawing.Size(47, 408);
            this.conCrane1_4.TabIndex = 3;
            this.conCrane1_4.Visible = false;
            // 
            // conCrane1_3
            // 
            this.conCrane1_3.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_3.CraneNO = null;
            this.conCrane1_3.Location = new System.Drawing.Point(514, 22);
            this.conCrane1_3.Name = "conCrane1_3";
            this.conCrane1_3.Size = new System.Drawing.Size(47, 408);
            this.conCrane1_3.TabIndex = 2;
            // 
            // conCrane1_2
            // 
            this.conCrane1_2.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_2.CraneNO = null;
            this.conCrane1_2.Location = new System.Drawing.Point(317, 22);
            this.conCrane1_2.Name = "conCrane1_2";
            this.conCrane1_2.Size = new System.Drawing.Size(47, 408);
            this.conCrane1_2.TabIndex = 1;
            // 
            // conCrane1_1
            // 
            this.conCrane1_1.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_1.CraneNO = null;
            this.conCrane1_1.Location = new System.Drawing.Point(936, 22);
            this.conCrane1_1.Name = "conCrane1_1";
            this.conCrane1_1.Size = new System.Drawing.Size(47, 408);
            this.conCrane1_1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(929, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "预定不安全";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Blue;
            this.panel6.Location = new System.Drawing.Point(901, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(22, 19);
            this.panel6.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(839, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "预定安全";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Yellow;
            this.panel5.Location = new System.Drawing.Point(811, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(22, 19);
            this.panel5.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1075, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "注意：自动行车不进入红色区域(安全门没关)";
            // 
            // timerCrane
            // 
            this.timerCrane.Interval = 1000;
            this.timerCrane.Tick += new System.EventHandler(this.timerCrane_Tick);
            // 
            // timerArea
            // 
            this.timerArea.Tick += new System.EventHandler(this.timerArea_Tick);
            // 
            // timerUnit
            // 
            this.timerUnit.Interval = 8000;
            this.timerUnit.Tick += new System.EventHandler(this.timerUnit_Tick);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 100000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // timer_ShowXY
            // 
            this.timer_ShowXY.Tick += new System.EventHandler(this.timer_ShowXY_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1332, 749);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_1, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 515);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 231);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // conCraneStatus1_4
            // 
            this.conCraneStatus1_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_4.CraneNO = "";
            this.conCraneStatus1_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_4.Location = new System.Drawing.Point(3, 3);
            this.conCraneStatus1_4.Name = "conCraneStatus1_4";
            this.conCraneStatus1_4.Size = new System.Drawing.Size(325, 225);
            this.conCraneStatus1_4.TabIndex = 0;
            this.conCraneStatus1_4.Visible = false;
            // 
            // conCraneStatus1_3
            // 
            this.conCraneStatus1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_3.CraneNO = "";
            this.conCraneStatus1_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_3.Location = new System.Drawing.Point(334, 3);
            this.conCraneStatus1_3.Name = "conCraneStatus1_3";
            this.conCraneStatus1_3.Size = new System.Drawing.Size(325, 225);
            this.conCraneStatus1_3.TabIndex = 1;
            // 
            // conCraneStatus1_2
            // 
            this.conCraneStatus1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_2.CraneNO = "";
            this.conCraneStatus1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_2.Location = new System.Drawing.Point(665, 3);
            this.conCraneStatus1_2.Name = "conCraneStatus1_2";
            this.conCraneStatus1_2.Size = new System.Drawing.Size(325, 225);
            this.conCraneStatus1_2.TabIndex = 2;
            // 
            // conCraneStatus1_1
            // 
            this.conCraneStatus1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_1.CraneNO = "";
            this.conCraneStatus1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_1.Location = new System.Drawing.Point(996, 3);
            this.conCraneStatus1_1.Name = "conCraneStatus1_1";
            this.conCraneStatus1_1.Size = new System.Drawing.Size(327, 225);
            this.conCraneStatus1_1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 64);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCrane_4_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_3_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_2_WaterStatus);
            this.panel2.Controls.Add(this.btnCrane_1_WaterStatus);
            this.panel2.Controls.Add(this.btnSeekCoil);
            this.panel2.Controls.Add(this.btnShowXY);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnShowCrane);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1326, 64);
            this.panel2.TabIndex = 5;
            // 
            // btnCrane_4_WaterStatus
            // 
            this.btnCrane_4_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_4_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_4_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_4_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_4_WaterStatus.Location = new System.Drawing.Point(363, 26);
            this.btnCrane_4_WaterStatus.Name = "btnCrane_4_WaterStatus";
            this.btnCrane_4_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_4_WaterStatus.TabIndex = 36;
            this.btnCrane_4_WaterStatus.Text = "4#空调水排放";
            this.btnCrane_4_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_3_WaterStatus
            // 
            this.btnCrane_3_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_3_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_3_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_3_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_3_WaterStatus.Location = new System.Drawing.Point(243, 26);
            this.btnCrane_3_WaterStatus.Name = "btnCrane_3_WaterStatus";
            this.btnCrane_3_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_3_WaterStatus.TabIndex = 35;
            this.btnCrane_3_WaterStatus.Text = "3#空调水排放";
            this.btnCrane_3_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_2_WaterStatus
            // 
            this.btnCrane_2_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_2_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_2_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_2_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_2_WaterStatus.Location = new System.Drawing.Point(123, 26);
            this.btnCrane_2_WaterStatus.Name = "btnCrane_2_WaterStatus";
            this.btnCrane_2_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_2_WaterStatus.TabIndex = 34;
            this.btnCrane_2_WaterStatus.Text = "2#空调水排放";
            this.btnCrane_2_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnCrane_1_WaterStatus
            // 
            this.btnCrane_1_WaterStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCrane_1_WaterStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCrane_1_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_1_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrane_1_WaterStatus.Location = new System.Drawing.Point(3, 26);
            this.btnCrane_1_WaterStatus.Name = "btnCrane_1_WaterStatus";
            this.btnCrane_1_WaterStatus.Size = new System.Drawing.Size(114, 35);
            this.btnCrane_1_WaterStatus.TabIndex = 33;
            this.btnCrane_1_WaterStatus.Text = "1#空调水排放";
            this.btnCrane_1_WaterStatus.UseVisualStyleBackColor = false;
            // 
            // btnSeekCoil
            // 
            this.btnSeekCoil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeekCoil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeekCoil.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeekCoil.ForeColor = System.Drawing.Color.White;
            this.btnSeekCoil.Location = new System.Drawing.Point(1083, 35);
            this.btnSeekCoil.Name = "btnSeekCoil";
            this.btnSeekCoil.Size = new System.Drawing.Size(75, 23);
            this.btnSeekCoil.TabIndex = 29;
            this.btnSeekCoil.Text = "库区找卷";
            this.btnSeekCoil.UseVisualStyleBackColor = true;
            this.btnSeekCoil.Click += new System.EventHandler(this.btnSeekCoil_Click);
            // 
            // btnShowXY
            // 
            this.btnShowXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowXY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowXY.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowXY.ForeColor = System.Drawing.Color.White;
            this.btnShowXY.Location = new System.Drawing.Point(1164, 35);
            this.btnShowXY.Name = "btnShowXY";
            this.btnShowXY.Size = new System.Drawing.Size(75, 23);
            this.btnShowXY.TabIndex = 28;
            this.btnShowXY.Text = "显示XY";
            this.btnShowXY.UseVisualStyleBackColor = true;
            this.btnShowXY.Click += new System.EventHandler(this.btnShowXY_Click);
            // 
            // btnShowCrane
            // 
            this.btnShowCrane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCrane.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowCrane.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowCrane.ForeColor = System.Drawing.Color.White;
            this.btnShowCrane.Location = new System.Drawing.Point(1245, 35);
            this.btnShowCrane.Name = "btnShowCrane";
            this.btnShowCrane.Size = new System.Drawing.Size(75, 23);
            this.btnShowCrane.TabIndex = 9;
            this.btnShowCrane.Text = "隐藏行车";
            this.btnShowCrane.UseVisualStyleBackColor = true;
            this.btnShowCrane.Click += new System.EventHandler(this.btnShowCrane_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(637, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Z12-Z11库";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panelZ53BayS);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1326, 436);
            this.panel3.TabIndex = 4;
            // 
            // panelZ53BayS
            // 
            this.panelZ53BayS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZ53BayS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelZ53BayS.Controls.Add(this.panelZ11_Z12Bay);
            this.panelZ53BayS.Location = new System.Drawing.Point(6, 6);
            this.panelZ53BayS.Name = "panelZ53BayS";
            this.panelZ53BayS.Size = new System.Drawing.Size(1314, 424);
            this.panelZ53BayS.TabIndex = 0;
            // 
            // timer_InitializeLoad
            // 
            this.timer_InitializeLoad.Tick += new System.EventHandler(this.timer_InitializeLoad_Tick);
            // 
            // Z12_library_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Z12_library_Monitor";
            this.Text = "Z12_library_Monitor";
            this.panelZ11_Z12Bay.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelZ53BayS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelZ11_Z12Bay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerCrane;
        private System.Windows.Forms.Timer timerArea;
        private System.Windows.Forms.Timer timerUnit;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Timer timer_ShowXY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowCrane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelZ53BayS;
        private System.Windows.Forms.Timer timer_InitializeLoad;
        private UACSControls.conCraneStatus conCraneStatus1_4;
        private UACSControls.conCraneStatus conCraneStatus1_3;
        private UACSControls.conCraneStatus conCraneStatus1_2;
        private UACSControls.conCraneStatus conCraneStatus1_1;
        private UACSControls.conCrane conCrane1_4;
        private UACSControls.conCrane conCrane1_3;
        private UACSControls.conCrane conCrane1_2;
        private UACSControls.conCrane conCrane1_1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtX;
        private System.Windows.Forms.Button btnShowXY;
        private System.Windows.Forms.Button btnSeekCoil;
        private System.Windows.Forms.Button btnCrane_4_WaterStatus;
        private System.Windows.Forms.Button btnCrane_3_WaterStatus;
        private System.Windows.Forms.Button btnCrane_2_WaterStatus;
        private System.Windows.Forms.Button btnCrane_1_WaterStatus;
    }
}