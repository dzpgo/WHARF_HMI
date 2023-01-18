namespace UACSView.View_CraneMonitor
{
    partial class A_library_Monitor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRecondition = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtYAB = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtXAB = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSeekCoil = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowXY = new System.Windows.Forms.Button();
            this.btnShowCrane = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelZ11_Z12Bay = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.conCrane1_2 = new UACSControls.conCrane();
            this.conCrane1_1 = new UACSControls.conCrane();
            this.panelBBay = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCrane_4_WaterStatus = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYB = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtXB = new System.Windows.Forms.Label();
            this.conCrane1_3 = new UACSControls.conCrane();
            this.conCrane1_4 = new UACSControls.conCrane();
            this.btnCrane_1_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_3_WaterStatus = new System.Windows.Forms.Button();
            this.btnCrane_2_WaterStatus = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.conCraneStatus1_3 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_2 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_1 = new UACSControls.conCraneStatus();
            this.conCraneStatus1_4 = new UACSControls.conCraneStatus();
            this.timer_InitializeLoad = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelZ11_Z12Bay.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelBBay.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(560, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 28);
            this.label6.TabIndex = 27;
            this.label6.Text = "预定不安全";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Blue;
            this.panel6.Location = new System.Drawing.Point(520, 63);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(30, 30);
            this.panel6.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(414, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 28);
            this.label5.TabIndex = 25;
            this.label5.Text = "预定安全";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Yellow;
            this.panel5.Location = new System.Drawing.Point(375, 63);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(30, 30);
            this.panel5.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(369, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(427, 28);
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
            this.timerArea.Interval = 1000;
            this.timerArea.Tick += new System.EventHandler(this.timerArea_Tick);
            // 
            // timerUnit
            // 
            this.timerUnit.Interval = 1000;
            this.timerUnit.Tick += new System.EventHandler(this.timerUnit_Tick);
            // 
            // timerClear
            // 
            this.timerClear.Interval = 100000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // timer_ShowXY
            // 
            this.timer_ShowXY.Interval = 1000;
            this.timer_ShowXY.Tick += new System.EventHandler(this.timer_ShowXY_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1998, 1124);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1990, 97);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRecondition);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.btnSeekCoil);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnShowXY);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnShowCrane);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1990, 97);
            this.panel2.TabIndex = 5;
            // 
            // btnRecondition
            // 
            this.btnRecondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecondition.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecondition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnRecondition.Location = new System.Drawing.Point(1363, 17);
            this.btnRecondition.Name = "btnRecondition";
            this.btnRecondition.Size = new System.Drawing.Size(156, 63);
            this.btnRecondition.TabIndex = 40;
            this.btnRecondition.Text = "检修";
            this.btnRecondition.UseVisualStyleBackColor = false;
            this.btnRecondition.Click += new System.EventHandler(this.btnbtnRecondition_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtYAB);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txtXAB);
            this.panel4.Location = new System.Drawing.Point(1535, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(148, 86);
            this.panel4.TabIndex = 39;
            this.panel4.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(20, 10);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 25);
            this.label11.TabIndex = 11;
            this.label11.Text = "X:";
            // 
            // txtYAB
            // 
            this.txtYAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYAB.AutoSize = true;
            this.txtYAB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYAB.ForeColor = System.Drawing.Color.White;
            this.txtYAB.Location = new System.Drawing.Point(54, 48);
            this.txtYAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtYAB.Name = "txtYAB";
            this.txtYAB.Size = new System.Drawing.Size(78, 25);
            this.txtYAB.TabIndex = 15;
            this.txtYAB.Text = "999999";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "Y:";
            // 
            // txtXAB
            // 
            this.txtXAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXAB.AutoSize = true;
            this.txtXAB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXAB.ForeColor = System.Drawing.Color.White;
            this.txtXAB.Location = new System.Drawing.Point(54, 10);
            this.txtXAB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtXAB.Name = "txtXAB";
            this.txtXAB.Size = new System.Drawing.Size(78, 25);
            this.txtXAB.TabIndex = 14;
            this.txtXAB.Text = "999999";
            // 
            // panel7
            // 
            this.panel7.BackgroundImage = global::UACSView.Properties.Resources.宝信_LOGO蓝色;
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel7.Controls.Add(this.button3);
            this.panel7.Location = new System.Drawing.Point(3, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(360, 96);
            this.panel7.TabIndex = 37;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Green;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(2, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(372, 87);
            this.button3.TabIndex = 40;
            this.button3.Text = "一键自动";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSeekCoil
            // 
            this.btnSeekCoil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeekCoil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeekCoil.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSeekCoil.ForeColor = System.Drawing.Color.White;
            this.btnSeekCoil.Location = new System.Drawing.Point(1695, 57);
            this.btnSeekCoil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeekCoil.Name = "btnSeekCoil";
            this.btnSeekCoil.Size = new System.Drawing.Size(141, 38);
            this.btnSeekCoil.TabIndex = 29;
            this.btnSeekCoil.Text = "库区找卷";
            this.btnSeekCoil.UseVisualStyleBackColor = true;
            this.btnSeekCoil.Click += new System.EventHandler(this.btnSeekCoil_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1695, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 38);
            this.button1.TabIndex = 36;
            this.button1.Text = "多库位报警";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowXY
            // 
            this.btnShowXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowXY.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowXY.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnShowXY.ForeColor = System.Drawing.Color.White;
            this.btnShowXY.Location = new System.Drawing.Point(1845, 57);
            this.btnShowXY.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowXY.Name = "btnShowXY";
            this.btnShowXY.Size = new System.Drawing.Size(141, 38);
            this.btnShowXY.TabIndex = 28;
            this.btnShowXY.Text = "显示XY";
            this.btnShowXY.UseVisualStyleBackColor = true;
            this.btnShowXY.Click += new System.EventHandler(this.btnShowXY_Click);
            // 
            // btnShowCrane
            // 
            this.btnShowCrane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCrane.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowCrane.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnShowCrane.ForeColor = System.Drawing.Color.White;
            this.btnShowCrane.Location = new System.Drawing.Point(1845, 4);
            this.btnShowCrane.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowCrane.Name = "btnShowCrane";
            this.btnShowCrane.Size = new System.Drawing.Size(141, 38);
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
            this.label1.Location = new System.Drawing.Point(957, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 64);
            this.label1.TabIndex = 3;
            this.label1.Text = "智能成品车间";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 109);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1990, 665);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelZ11_Z12Bay, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panelBBay, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1990, 665);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panelZ11_Z12Bay
            // 
            this.panelZ11_Z12Bay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelZ11_Z12Bay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZ11_Z12Bay.Controls.Add(this.label2);
            this.panelZ11_Z12Bay.Controls.Add(this.panel8);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_2);
            this.panelZ11_Z12Bay.Controls.Add(this.conCrane1_1);
            this.panelZ11_Z12Bay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZ11_Z12Bay.Location = new System.Drawing.Point(4, 336);
            this.panelZ11_Z12Bay.Margin = new System.Windows.Forms.Padding(4);
            this.panelZ11_Z12Bay.Name = "panelZ11_Z12Bay";
            this.panelZ11_Z12Bay.Size = new System.Drawing.Size(1982, 325);
            this.panelZ11_Z12Bay.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 52);
            this.label2.TabIndex = 18;
            this.label2.Text = "A跨";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Teal;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Location = new System.Drawing.Point(1833, 227);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(148, 97);
            this.panel8.TabIndex = 17;
            this.panel8.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "X:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(54, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "999999";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(20, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 25);
            this.label12.TabIndex = 13;
            this.label12.Text = "Y:";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(54, 8);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 25);
            this.label14.TabIndex = 14;
            this.label14.Text = "999999";
            // 
            // conCrane1_2
            // 
            this.conCrane1_2.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_2.CraneNO = null;
            this.conCrane1_2.Location = new System.Drawing.Point(614, -3);
            this.conCrane1_2.Margin = new System.Windows.Forms.Padding(6);
            this.conCrane1_2.Name = "conCrane1_2";
            this.conCrane1_2.Size = new System.Drawing.Size(70, 320);
            this.conCrane1_2.TabIndex = 1;
            // 
            // conCrane1_1
            // 
            this.conCrane1_1.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_1.CraneNO = null;
            this.conCrane1_1.Location = new System.Drawing.Point(957, -2);
            this.conCrane1_1.Margin = new System.Windows.Forms.Padding(6);
            this.conCrane1_1.Name = "conCrane1_1";
            this.conCrane1_1.Size = new System.Drawing.Size(70, 320);
            this.conCrane1_1.TabIndex = 0;
            // 
            // panelBBay
            // 
            this.panelBBay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelBBay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBBay.Controls.Add(this.label10);
            this.panelBBay.Controls.Add(this.btnCrane_4_WaterStatus);
            this.panelBBay.Controls.Add(this.panel9);
            this.panelBBay.Controls.Add(this.conCrane1_3);
            this.panelBBay.Controls.Add(this.conCrane1_4);
            this.panelBBay.Controls.Add(this.btnCrane_1_WaterStatus);
            this.panelBBay.Controls.Add(this.btnCrane_3_WaterStatus);
            this.panelBBay.Controls.Add(this.btnCrane_2_WaterStatus);
            this.panelBBay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBBay.Location = new System.Drawing.Point(4, 4);
            this.panelBBay.Margin = new System.Windows.Forms.Padding(4);
            this.panelBBay.Name = "panelBBay";
            this.panelBBay.Size = new System.Drawing.Size(1982, 324);
            this.panelBBay.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(9, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 52);
            this.label10.TabIndex = 18;
            this.label10.Text = "B跨";
            // 
            // btnCrane_4_WaterStatus
            // 
            this.btnCrane_4_WaterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrane_4_WaterStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCrane_4_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_4_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrane_4_WaterStatus.ForeColor = System.Drawing.Color.White;
            this.btnCrane_4_WaterStatus.Location = new System.Drawing.Point(1777, 57);
            this.btnCrane_4_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_4_WaterStatus.Name = "btnCrane_4_WaterStatus";
            this.btnCrane_4_WaterStatus.Size = new System.Drawing.Size(204, 38);
            this.btnCrane_4_WaterStatus.TabIndex = 38;
            this.btnCrane_4_WaterStatus.Text = "B跨CD区光电门：开";
            this.btnCrane_4_WaterStatus.UseVisualStyleBackColor = false;
            this.btnCrane_4_WaterStatus.Visible = false;
            this.btnCrane_4_WaterStatus.Click += new System.EventHandler(this.btnCrane_4_WaterStatus_Click);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.Teal;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.txtYB);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.txtXB);
            this.panel9.Location = new System.Drawing.Point(1833, 226);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(148, 97);
            this.panel9.TabIndex = 17;
            this.panel9.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "X:";
            // 
            // txtYB
            // 
            this.txtYB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYB.AutoSize = true;
            this.txtYB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYB.ForeColor = System.Drawing.Color.White;
            this.txtYB.Location = new System.Drawing.Point(54, 56);
            this.txtYB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtYB.Name = "txtYB";
            this.txtYB.Size = new System.Drawing.Size(78, 25);
            this.txtYB.TabIndex = 15;
            this.txtYB.Text = "999999";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Y:";
            // 
            // txtXB
            // 
            this.txtXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtXB.AutoSize = true;
            this.txtXB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXB.ForeColor = System.Drawing.Color.White;
            this.txtXB.Location = new System.Drawing.Point(54, 8);
            this.txtXB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtXB.Name = "txtXB";
            this.txtXB.Size = new System.Drawing.Size(78, 25);
            this.txtXB.TabIndex = 14;
            this.txtXB.Text = "999999";
            // 
            // conCrane1_3
            // 
            this.conCrane1_3.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_3.CraneNO = null;
            this.conCrane1_3.Location = new System.Drawing.Point(614, -2);
            this.conCrane1_3.Margin = new System.Windows.Forms.Padding(6);
            this.conCrane1_3.Name = "conCrane1_3";
            this.conCrane1_3.Size = new System.Drawing.Size(70, 320);
            this.conCrane1_3.TabIndex = 2;
            // 
            // conCrane1_4
            // 
            this.conCrane1_4.BackColor = System.Drawing.SystemColors.Control;
            this.conCrane1_4.CraneNO = null;
            this.conCrane1_4.Location = new System.Drawing.Point(957, -2);
            this.conCrane1_4.Margin = new System.Windows.Forms.Padding(6);
            this.conCrane1_4.Name = "conCrane1_4";
            this.conCrane1_4.Size = new System.Drawing.Size(70, 318);
            this.conCrane1_4.TabIndex = 0;
            // 
            // btnCrane_1_WaterStatus
            // 
            this.btnCrane_1_WaterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrane_1_WaterStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCrane_1_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_1_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrane_1_WaterStatus.ForeColor = System.Drawing.Color.White;
            this.btnCrane_1_WaterStatus.Location = new System.Drawing.Point(1559, 4);
            this.btnCrane_1_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_1_WaterStatus.Name = "btnCrane_1_WaterStatus";
            this.btnCrane_1_WaterStatus.Size = new System.Drawing.Size(210, 38);
            this.btnCrane_1_WaterStatus.TabIndex = 33;
            this.btnCrane_1_WaterStatus.Text = "A跨AB区光电门：开";
            this.btnCrane_1_WaterStatus.UseVisualStyleBackColor = false;
            this.btnCrane_1_WaterStatus.Visible = false;
            this.btnCrane_1_WaterStatus.Click += new System.EventHandler(this.btnCrane_1_WaterStatus_Click_1);
            // 
            // btnCrane_3_WaterStatus
            // 
            this.btnCrane_3_WaterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrane_3_WaterStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCrane_3_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_3_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrane_3_WaterStatus.ForeColor = System.Drawing.Color.White;
            this.btnCrane_3_WaterStatus.Location = new System.Drawing.Point(1776, 4);
            this.btnCrane_3_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_3_WaterStatus.Name = "btnCrane_3_WaterStatus";
            this.btnCrane_3_WaterStatus.Size = new System.Drawing.Size(204, 38);
            this.btnCrane_3_WaterStatus.TabIndex = 35;
            this.btnCrane_3_WaterStatus.Text = "B跨AB区光电门：开";
            this.btnCrane_3_WaterStatus.UseVisualStyleBackColor = false;
            this.btnCrane_3_WaterStatus.Visible = false;
            this.btnCrane_3_WaterStatus.Click += new System.EventHandler(this.btnCrane_3_WaterStatus_Click);
            // 
            // btnCrane_2_WaterStatus
            // 
            this.btnCrane_2_WaterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrane_2_WaterStatus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCrane_2_WaterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCrane_2_WaterStatus.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrane_2_WaterStatus.ForeColor = System.Drawing.Color.White;
            this.btnCrane_2_WaterStatus.Location = new System.Drawing.Point(1559, 57);
            this.btnCrane_2_WaterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrane_2_WaterStatus.Name = "btnCrane_2_WaterStatus";
            this.btnCrane_2_WaterStatus.Size = new System.Drawing.Size(210, 38);
            this.btnCrane_2_WaterStatus.TabIndex = 34;
            this.btnCrane_2_WaterStatus.Text = "A跨CD区光电门：开";
            this.btnCrane_2_WaterStatus.UseVisualStyleBackColor = false;
            this.btnCrane_2_WaterStatus.Visible = false;
            this.btnCrane_2_WaterStatus.Click += new System.EventHandler(this.btnCrane_2_WaterStatus_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.conCraneStatus1_4, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 782);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1990, 338);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // conCraneStatus1_3
            // 
            this.conCraneStatus1_3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.conCraneStatus1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_3.CraneNO = "";
            this.conCraneStatus1_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_3.Location = new System.Drawing.Point(1000, 6);
            this.conCraneStatus1_3.Margin = new System.Windows.Forms.Padding(6);
            this.conCraneStatus1_3.Name = "conCraneStatus1_3";
            this.conCraneStatus1_3.Size = new System.Drawing.Size(485, 326);
            this.conCraneStatus1_3.TabIndex = 4;
            // 
            // conCraneStatus1_2
            // 
            this.conCraneStatus1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_2.CraneNO = "";
            this.conCraneStatus1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_2.Location = new System.Drawing.Point(503, 6);
            this.conCraneStatus1_2.Margin = new System.Windows.Forms.Padding(6);
            this.conCraneStatus1_2.Name = "conCraneStatus1_2";
            this.conCraneStatus1_2.Size = new System.Drawing.Size(485, 326);
            this.conCraneStatus1_2.TabIndex = 3;
            // 
            // conCraneStatus1_1
            // 
            this.conCraneStatus1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_1.CraneNO = "";
            this.conCraneStatus1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_1.Location = new System.Drawing.Point(6, 6);
            this.conCraneStatus1_1.Margin = new System.Windows.Forms.Padding(6);
            this.conCraneStatus1_1.Name = "conCraneStatus1_1";
            this.conCraneStatus1_1.Size = new System.Drawing.Size(485, 326);
            this.conCraneStatus1_1.TabIndex = 2;
            // 
            // conCraneStatus1_4
            // 
            this.conCraneStatus1_4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.conCraneStatus1_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conCraneStatus1_4.CraneNO = "";
            this.conCraneStatus1_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conCraneStatus1_4.Location = new System.Drawing.Point(1497, 6);
            this.conCraneStatus1_4.Margin = new System.Windows.Forms.Padding(6);
            this.conCraneStatus1_4.Name = "conCraneStatus1_4";
            this.conCraneStatus1_4.Size = new System.Drawing.Size(487, 326);
            this.conCraneStatus1_4.TabIndex = 1;
            // 
            // timer_InitializeLoad
            // 
            this.timer_InitializeLoad.Tick += new System.EventHandler(this.timer_InitializeLoad_Tick);
            // 
            // A_library_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1998, 1124);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "A_library_Monitor";
            this.Text = "Z12_library_Monitor";
            this.TabActivated += new System.EventHandler(this.MyTabActivated);
            this.TabDeactivated += new System.EventHandler(this.MyTabDeactivated);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelZ11_Z12Bay.ResumeLayout(false);
            this.panelZ11_Z12Bay.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelBBay.ResumeLayout(false);
            this.panelBBay.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowCrane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer_InitializeLoad;
        private System.Windows.Forms.Button btnShowXY;
        private System.Windows.Forms.Button btnSeekCoil;
        private System.Windows.Forms.Button btnCrane_3_WaterStatus;
        private System.Windows.Forms.Button btnCrane_2_WaterStatus;
        private System.Windows.Forms.Button btnCrane_1_WaterStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UACSControls.conCraneStatus conCraneStatus1_3;
        private UACSControls.conCraneStatus conCraneStatus1_2;
        private UACSControls.conCraneStatus conCraneStatus1_1;
        private UACSControls.conCraneStatus conCraneStatus1_4;
        private System.Windows.Forms.Button btnCrane_4_WaterStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtYAB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtXAB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelBBay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtYB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtXB;
        private UACSControls.conCrane conCrane1_3;
        private UACSControls.conCrane conCrane1_4;
        private System.Windows.Forms.Panel panelZ11_Z12Bay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private UACSControls.conCrane conCrane1_2;
        private UACSControls.conCrane conCrane1_1;
        private System.Windows.Forms.Button btnRecondition;
    }
}