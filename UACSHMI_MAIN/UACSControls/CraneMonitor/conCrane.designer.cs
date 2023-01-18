namespace UACSControls
{
    partial class conCrane
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelCrane = new System.Windows.Forms.Panel();
            this.panelCrab = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStrip_YardToTard = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_DelCraneOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.设置避让ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小车方向ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行车排水ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矫正高度角度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.角度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登车请求ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.指令配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCrane.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCrane
            // 
            this.panelCrane.BackColor = System.Drawing.Color.Transparent;
            this.panelCrane.BackgroundImage = global::UACSControls.Resource1.行车_Avoid;
            this.panelCrane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCrane.Controls.Add(this.panelCrab);
            this.panelCrane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrane.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelCrane.Location = new System.Drawing.Point(0, 0);
            this.panelCrane.Name = "panelCrane";
            this.panelCrane.Size = new System.Drawing.Size(47, 408);
            this.panelCrane.TabIndex = 3;
            this.panelCrane.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCrane_Paint);
            this.panelCrane.DoubleClick += new System.EventHandler(this.panelCrane_DoubleClick);
            // 
            // panelCrab
            // 
            this.panelCrab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCrab.BackColor = System.Drawing.Color.White;
            this.panelCrab.BackgroundImage = global::UACSControls.Resource1.imgCarCoil;
            this.panelCrab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelCrab.Location = new System.Drawing.Point(0, 194);
            this.panelCrab.Name = "panelCrab";
            this.panelCrab.Size = new System.Drawing.Size(47, 27);
            this.panelCrab.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_YardToTard,
            this.ToolStrip_DelCraneOrder,
            this.设置避让ToolStripMenuItem,
            this.登车ToolStripMenuItem,
            this.小车方向ToolStripMenuItem,
            this.行车排水ToolStripMenuItem,
            this.矫正高度角度ToolStripMenuItem,
            this.登车请求ToolStripMenuItem,
            this.指令配置ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 224);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // ToolStrip_YardToTard
            // 
            this.ToolStrip_YardToTard.Name = "ToolStrip_YardToTard";
            this.ToolStrip_YardToTard.Size = new System.Drawing.Size(153, 22);
            this.ToolStrip_YardToTard.Text = "人工指令";
            this.ToolStrip_YardToTard.Click += new System.EventHandler(this.ToolStrip_YardToTard_Click);
            // 
            // ToolStrip_DelCraneOrder
            // 
            this.ToolStrip_DelCraneOrder.Name = "ToolStrip_DelCraneOrder";
            this.ToolStrip_DelCraneOrder.Size = new System.Drawing.Size(153, 22);
            this.ToolStrip_DelCraneOrder.Text = "清空指令";
            this.ToolStrip_DelCraneOrder.Click += new System.EventHandler(this.ToolStrip_DelCraneOrder_Click);
            // 
            // 设置避让ToolStripMenuItem
            // 
            this.设置避让ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确定ToolStripMenuItem,
            this.取消ToolStripMenuItem});
            this.设置避让ToolStripMenuItem.Name = "设置避让ToolStripMenuItem";
            this.设置避让ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.设置避让ToolStripMenuItem.Text = "设置避让";
            this.设置避让ToolStripMenuItem.Visible = false;
            // 
            // 确定ToolStripMenuItem
            // 
            this.确定ToolStripMenuItem.Name = "确定ToolStripMenuItem";
            this.确定ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.确定ToolStripMenuItem.Text = "确定";
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.取消ToolStripMenuItem.Text = "取消";
            // 
            // 登车ToolStripMenuItem
            // 
            this.登车ToolStripMenuItem.Name = "登车ToolStripMenuItem";
            this.登车ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.登车ToolStripMenuItem.Text = "登车";
            this.登车ToolStripMenuItem.Visible = false;
            this.登车ToolStripMenuItem.Click += new System.EventHandler(this.登车ToolStripMenuItem_Click);
            // 
            // 小车方向ToolStripMenuItem
            // 
            this.小车方向ToolStripMenuItem.Enabled = false;
            this.小车方向ToolStripMenuItem.Name = "小车方向ToolStripMenuItem";
            this.小车方向ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.小车方向ToolStripMenuItem.Text = "连退方向";
            this.小车方向ToolStripMenuItem.Visible = false;
            this.小车方向ToolStripMenuItem.Click += new System.EventHandler(this.小车方向ToolStripMenuItem_Click);
            // 
            // 行车排水ToolStripMenuItem
            // 
            this.行车排水ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.行车排水ToolStripMenuItem.Name = "行车排水ToolStripMenuItem";
            this.行车排水ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.行车排水ToolStripMenuItem.Text = "行车排水";
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开启ToolStripMenuItem.Text = "开启";
            this.开启ToolStripMenuItem.Click += new System.EventHandler(this.开启ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 矫正高度角度ToolStripMenuItem
            // 
            this.矫正高度角度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.高度ToolStripMenuItem,
            this.角度ToolStripMenuItem});
            this.矫正高度角度ToolStripMenuItem.Name = "矫正高度角度ToolStripMenuItem";
            this.矫正高度角度ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.矫正高度角度ToolStripMenuItem.Text = "矫正高度/角度";
            // 
            // 高度ToolStripMenuItem
            // 
            this.高度ToolStripMenuItem.Name = "高度ToolStripMenuItem";
            this.高度ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.高度ToolStripMenuItem.Text = "高度";
            this.高度ToolStripMenuItem.Click += new System.EventHandler(this.高度ToolStripMenuItem_Click);
            // 
            // 角度ToolStripMenuItem
            // 
            this.角度ToolStripMenuItem.Name = "角度ToolStripMenuItem";
            this.角度ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.角度ToolStripMenuItem.Text = "角度";
            this.角度ToolStripMenuItem.Click += new System.EventHandler(this.角度ToolStripMenuItem_Click);
            // 
            // 登车请求ToolStripMenuItem
            // 
            this.登车请求ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem1,
            this.关闭ToolStripMenuItem1});
            this.登车请求ToolStripMenuItem.Name = "登车请求ToolStripMenuItem";
            this.登车请求ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.登车请求ToolStripMenuItem.Text = "登车请求";
            // 
            // 开启ToolStripMenuItem1
            // 
            this.开启ToolStripMenuItem1.Name = "开启ToolStripMenuItem1";
            this.开启ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.开启ToolStripMenuItem1.Text = "开启";
            this.开启ToolStripMenuItem1.Click += new System.EventHandler(this.开启ToolStripMenuItem1_Click);
            // 
            // 关闭ToolStripMenuItem1
            // 
            this.关闭ToolStripMenuItem1.Name = "关闭ToolStripMenuItem1";
            this.关闭ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.关闭ToolStripMenuItem1.Text = "关闭";
            this.关闭ToolStripMenuItem1.Click += new System.EventHandler(this.关闭ToolStripMenuItem1_Click);
            // 
            // 指令配置ToolStripMenuItem
            // 
            this.指令配置ToolStripMenuItem.Name = "指令配置ToolStripMenuItem";
            this.指令配置ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.指令配置ToolStripMenuItem.Text = "行车指令配置";
            this.指令配置ToolStripMenuItem.Click += new System.EventHandler(this.panelCrane_DoubleClick);
            // 
            // conCrane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelCrane);
            this.Name = "conCrane";
            this.Size = new System.Drawing.Size(47, 408);
            this.panelCrane.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCrane;
        private System.Windows.Forms.Panel panelCrab;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_YardToTard;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_DelCraneOrder;
        private System.Windows.Forms.ToolStripMenuItem 设置避让ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登车ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小车方向ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 行车排水ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登车请求ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 矫正高度角度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 角度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指令配置ToolStripMenuItem;


    }
}
