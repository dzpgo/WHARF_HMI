namespace UACSview
{
    partial class A_B_Trolley
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_B_Trolley));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnInsertB = new System.Windows.Forms.Button();
            this.txtCoilNoB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnInsertA = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCoilNoA = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.conEntrySpecActionB = new UACS.conEntrySpecAction();
            this.coilPictureB = new UACS.CoilPicture();
            this.coilCranOrderB = new UACS.CoilCranOrder();
            this.conTrolleyTagB = new UACS.ConTrolleyTag();
            this.coilUnitStatus3 = new UACSControls.CoilUnitStatus();
            this.coilUnitStatus2 = new UACSControls.CoilUnitStatus();
            this.coilUnitStatus1 = new UACSControls.CoilUnitStatus();
            this.conEntrySpecActionA = new UACS.conEntrySpecAction();
            this.coilPictureA = new UACS.CoilPicture();
            this.coilCranOrderA = new UACS.CoilCranOrder();
            this.conTrolleyTagA = new UACS.ConTrolleyTag();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 4000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 269;
            this.label1.Text = "故障信号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(66, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 271;
            this.label2.Text = "安全门";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(66, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 273;
            this.label3.Text = "自动";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1370, 749);
            this.tableLayoutPanel1.TabIndex = 274;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnInsertB);
            this.panel2.Controls.Add(this.txtCoilNoB);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.conEntrySpecActionB);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.coilPictureB);
            this.panel2.Controls.Add(this.coilCranOrderB);
            this.panel2.Controls.Add(this.conTrolleyTagB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(688, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 741);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(519, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 30);
            this.button4.TabIndex = 285;
            this.button4.Text = "清除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnInsertB
            // 
            this.btnInsertB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsertB.Location = new System.Drawing.Point(459, 245);
            this.btnInsertB.Name = "btnInsertB";
            this.btnInsertB.Size = new System.Drawing.Size(60, 30);
            this.btnInsertB.TabIndex = 283;
            this.btnInsertB.Text = "确定";
            this.btnInsertB.UseVisualStyleBackColor = true;
            this.btnInsertB.Click += new System.EventHandler(this.btnInsertB_Click);
            // 
            // txtCoilNoB
            // 
            this.txtCoilNoB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCoilNoB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCoilNoB.Location = new System.Drawing.Point(268, 245);
            this.txtCoilNoB.Multiline = true;
            this.txtCoilNoB.Name = "txtCoilNoB";
            this.txtCoilNoB.Size = new System.Drawing.Size(187, 30);
            this.txtCoilNoB.TabIndex = 283;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(188, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 283;
            this.label7.Text = "钢卷号：";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(459, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 60);
            this.button2.TabIndex = 280;
            this.button2.Text = "镀锌跨选卷";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(382, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 39);
            this.label5.TabIndex = 275;
            this.label5.Text = "镀锌跨";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnInsertA);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCoilNoA);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.coilUnitStatus3);
            this.panel1.Controls.Add(this.coilUnitStatus2);
            this.panel1.Controls.Add(this.coilUnitStatus1);
            this.panel1.Controls.Add(this.conEntrySpecActionA);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.coilPictureA);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.coilCranOrderA);
            this.panel1.Controls.Add(this.conTrolleyTagA);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 741);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(486, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 30);
            this.button3.TabIndex = 284;
            this.button3.Text = "清除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnInsertA
            // 
            this.btnInsertA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertA.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsertA.Location = new System.Drawing.Point(426, 245);
            this.btnInsertA.Name = "btnInsertA";
            this.btnInsertA.Size = new System.Drawing.Size(60, 30);
            this.btnInsertA.TabIndex = 282;
            this.btnInsertA.Text = "确定";
            this.btnInsertA.UseVisualStyleBackColor = true;
            this.btnInsertA.Click += new System.EventHandler(this.btnInsertA_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(153, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 281;
            this.label6.Text = "钢卷号：";
            // 
            // txtCoilNoA
            // 
            this.txtCoilNoA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCoilNoA.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCoilNoA.Location = new System.Drawing.Point(233, 245);
            this.txtCoilNoA.Multiline = true;
            this.txtCoilNoA.Name = "txtCoilNoA";
            this.txtCoilNoA.Size = new System.Drawing.Size(187, 30);
            this.txtCoilNoA.TabIndex = 280;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(426, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 60);
            this.button1.TabIndex = 279;
            this.button1.Text = "连退跨选卷";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(360, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 39);
            this.label4.TabIndex = 274;
            this.label4.Text = "连退跨";
            // 
            // conEntrySpecActionB
            // 
            this.conEntrySpecActionB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.conEntrySpecActionB.BayNo = null;
            this.conEntrySpecActionB.Location = new System.Drawing.Point(145, 276);
            this.conEntrySpecActionB.Name = "conEntrySpecActionB";
            this.conEntrySpecActionB.Size = new System.Drawing.Size(419, 196);
            this.conEntrySpecActionB.TabIndex = 276;
            this.conEntrySpecActionB.UnitNo = null;
            this.conEntrySpecActionB.Visible = false;
            // 
            // coilPictureB
            // 
            this.coilPictureB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coilPictureB.ButtonDImage = ((System.Drawing.Image)(resources.GetObject("coilPictureB.ButtonDImage")));
            this.coilPictureB.ButtonUImage = ((System.Drawing.Image)(resources.GetObject("coilPictureB.ButtonUImage")));
            this.coilPictureB.CoilBackColor = System.Drawing.Color.White;
            this.coilPictureB.CoilFontColor = System.Drawing.Color.Black;
            this.coilPictureB.CoilId = "AAAAAAAAAA0";
            this.coilPictureB.CoilLength = 16;
            this.coilPictureB.CoilStatus = -1;
            this.coilPictureB.Director = Baosight.ColdRolling.TcmControl.Direct.Horizontal;
            this.coilPictureB.DownEnable = true;
            this.coilPictureB.DownVisiable = false;
            this.coilPictureB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coilPictureB.Location = new System.Drawing.Point(268, 60);
            this.coilPictureB.Name = "coilPictureB";
            this.coilPictureB.PosName = "B过跨台车鞍座";
            this.coilPictureB.PosNo = 1;
            this.coilPictureB.Saddle_no = null;
            this.coilPictureB.Size = new System.Drawing.Size(215, 115);
            this.coilPictureB.SkidName = "skidControl";
            this.coilPictureB.SkidSize = new System.Drawing.Size(215, 115);
            this.coilPictureB.TabIndex = 87;
            this.coilPictureB.TextFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coilPictureB.Unit_no = null;
            this.coilPictureB.UpEnable = true;
            this.coilPictureB.UpVisiable = false;
            // 
            // coilCranOrderB
            // 
            this.coilCranOrderB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coilCranOrderB.Location = new System.Drawing.Point(268, 172);
            this.coilCranOrderB.Name = "coilCranOrderB";
            this.coilCranOrderB.SaddleNo = null;
            this.coilCranOrderB.Size = new System.Drawing.Size(187, 67);
            this.coilCranOrderB.TabIndex = 88;
            // 
            // conTrolleyTagB
            // 
            this.conTrolleyTagB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.conTrolleyTagB.BayNO = null;
            this.conTrolleyTagB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conTrolleyTagB.Location = new System.Drawing.Point(174, 521);
            this.conTrolleyTagB.Name = "conTrolleyTagB";
            this.conTrolleyTagB.Size = new System.Drawing.Size(357, 266);
            this.conTrolleyTagB.TabIndex = 3;
            // 
            // coilUnitStatus3
            // 
            this.coilUnitStatus3.Location = new System.Drawing.Point(36, 267);
            this.coilUnitStatus3.MyStatusTagName = "";
            this.coilUnitStatus3.Name = "coilUnitStatus3";
            this.coilUnitStatus3.Size = new System.Drawing.Size(24, 23);
            this.coilUnitStatus3.TabIndex = 278;
            // 
            // coilUnitStatus2
            // 
            this.coilUnitStatus2.Location = new System.Drawing.Point(36, 225);
            this.coilUnitStatus2.MyStatusTagName = "";
            this.coilUnitStatus2.Name = "coilUnitStatus2";
            this.coilUnitStatus2.Size = new System.Drawing.Size(24, 23);
            this.coilUnitStatus2.TabIndex = 277;
            // 
            // coilUnitStatus1
            // 
            this.coilUnitStatus1.Location = new System.Drawing.Point(36, 181);
            this.coilUnitStatus1.MyStatusTagName = "";
            this.coilUnitStatus1.Name = "coilUnitStatus1";
            this.coilUnitStatus1.Size = new System.Drawing.Size(24, 23);
            this.coilUnitStatus1.TabIndex = 276;
            // 
            // conEntrySpecActionA
            // 
            this.conEntrySpecActionA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.conEntrySpecActionA.BayNo = null;
            this.conEntrySpecActionA.Location = new System.Drawing.Point(133, 276);
            this.conEntrySpecActionA.Name = "conEntrySpecActionA";
            this.conEntrySpecActionA.Size = new System.Drawing.Size(383, 196);
            this.conEntrySpecActionA.TabIndex = 275;
            this.conEntrySpecActionA.UnitNo = null;
            this.conEntrySpecActionA.Visible = false;
            // 
            // coilPictureA
            // 
            this.coilPictureA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coilPictureA.ButtonDImage = ((System.Drawing.Image)(resources.GetObject("coilPictureA.ButtonDImage")));
            this.coilPictureA.ButtonUImage = ((System.Drawing.Image)(resources.GetObject("coilPictureA.ButtonUImage")));
            this.coilPictureA.CoilBackColor = System.Drawing.Color.White;
            this.coilPictureA.CoilFontColor = System.Drawing.Color.Black;
            this.coilPictureA.CoilId = "AAAAAAAAAA0";
            this.coilPictureA.CoilLength = 16;
            this.coilPictureA.CoilStatus = -1;
            this.coilPictureA.Director = Baosight.ColdRolling.TcmControl.Direct.Horizontal;
            this.coilPictureA.DownEnable = true;
            this.coilPictureA.DownVisiable = false;
            this.coilPictureA.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coilPictureA.Location = new System.Drawing.Point(233, 61);
            this.coilPictureA.Name = "coilPictureA";
            this.coilPictureA.PosName = "A过跨台车鞍座";
            this.coilPictureA.PosNo = 1;
            this.coilPictureA.Saddle_no = null;
            this.coilPictureA.Size = new System.Drawing.Size(215, 114);
            this.coilPictureA.SkidName = "skidControl";
            this.coilPictureA.SkidSize = new System.Drawing.Size(215, 115);
            this.coilPictureA.TabIndex = 85;
            this.coilPictureA.TextFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coilPictureA.Unit_no = null;
            this.coilPictureA.UpEnable = true;
            this.coilPictureA.UpVisiable = false;
            // 
            // coilCranOrderA
            // 
            this.coilCranOrderA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coilCranOrderA.Location = new System.Drawing.Point(233, 172);
            this.coilCranOrderA.Name = "coilCranOrderA";
            this.coilCranOrderA.SaddleNo = null;
            this.coilCranOrderA.Size = new System.Drawing.Size(187, 67);
            this.coilCranOrderA.TabIndex = 86;
            // 
            // conTrolleyTagA
            // 
            this.conTrolleyTagA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.conTrolleyTagA.BayNO = null;
            this.conTrolleyTagA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.conTrolleyTagA.Location = new System.Drawing.Point(145, 521);
            this.conTrolleyTagA.Name = "conTrolleyTagA";
            this.conTrolleyTagA.Size = new System.Drawing.Size(357, 266);
            this.conTrolleyTagA.TabIndex = 2;
            // 
            // A_B_Trolley
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "A_B_Trolley";
            this.Text = "过跨台车";
            this.TabActivated += new System.EventHandler(this.MyTabActivated);
            this.TabDeactivated += new System.EventHandler(this.MyTabDeactivated);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private UACS.ConTrolleyTag conTrolleyTagA;
        private UACS.ConTrolleyTag conTrolleyTagB;
        private UACS.CoilCranOrder coilCranOrderA;
        private UACS.CoilPicture coilPictureA;
        private UACS.CoilCranOrder coilCranOrderB;
        private UACS.CoilPicture coilPictureB;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        //private UACS.CoilStatus coilStatus1;
        private System.Windows.Forms.Label label2;
        //private UACS.CoilStatus coilStatus2;
        private System.Windows.Forms.Label label3;
        //private UACS.CoilStatus coilStatus3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private UACS.conEntrySpecAction conEntrySpecActionB;
        private UACS.conEntrySpecAction conEntrySpecActionA;
        private UACSControls.CoilUnitStatus coilUnitStatus3;
        private UACSControls.CoilUnitStatus coilUnitStatus2;
        private UACSControls.CoilUnitStatus coilUnitStatus1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInsertB;
        private System.Windows.Forms.TextBox txtCoilNoB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInsertA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCoilNoA;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}