﻿namespace UACSControls
{
    partial class FrmMoreStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMoreStockInfo = new System.Windows.Forms.DataGridView();
            this.STOCK_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAY_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoreStockInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMoreStockInfo
            // 
            this.dgvMoreStockInfo.AllowUserToAddRows = false;
            this.dgvMoreStockInfo.AllowUserToResizeColumns = false;
            this.dgvMoreStockInfo.AllowUserToResizeRows = false;
            this.dgvMoreStockInfo.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMoreStockInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMoreStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoreStockInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STOCK_NO,
            this.MAT_NO,
            this.BAY_NO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMoreStockInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMoreStockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoreStockInfo.EnableHeadersVisualStyles = false;
            this.dgvMoreStockInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvMoreStockInfo.Name = "dgvMoreStockInfo";
            this.dgvMoreStockInfo.RowHeadersVisible = false;
            this.dgvMoreStockInfo.RowTemplate.Height = 23;
            this.dgvMoreStockInfo.Size = new System.Drawing.Size(504, 409);
            this.dgvMoreStockInfo.TabIndex = 26;
            // 
            // STOCK_NO
            // 
            this.STOCK_NO.DataPropertyName = "STOCK_NO";
            this.STOCK_NO.HeaderText = "库位";
            this.STOCK_NO.Name = "STOCK_NO";
            this.STOCK_NO.Width = 200;
            // 
            // MAT_NO
            // 
            this.MAT_NO.DataPropertyName = "MAT_NO";
            this.MAT_NO.HeaderText = "钢卷号";
            this.MAT_NO.Name = "MAT_NO";
            this.MAT_NO.Width = 200;
            // 
            // BAY_NO
            // 
            this.BAY_NO.DataPropertyName = "BAY_NO";
            this.BAY_NO.HeaderText = "跨别";
            this.BAY_NO.Name = "BAY_NO";
            // 
            // FrmMoreStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 409);
            this.Controls.Add(this.dgvMoreStockInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMoreStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多库位报警";
            this.Shown += new System.EventHandler(this.FrmMoreStock_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoreStockInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMoreStockInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOCK_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAY_NO;
    }
}