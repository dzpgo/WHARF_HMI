using UACSDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSPopupForm
{
    /// <summary>
    /// 修改范围配置权限确认
    /// </summary>
    public partial class FrmCraneConfigAuthority : Form
    {
        public event EventHandler<DataReturnedEventArgs> DataReturned; // 声明事件
        private string actualUserName = "686517"; // 你的实际用户
        private string actualPassword = "686517"; // 你的实际密码
        public FrmCraneConfigAuthority()
        {
            InitializeComponent();
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            string inputUserName = txtUserName.Text.Trim();
            string inputUserPwd = txtUserPwd.Text.Trim();

            if (inputUserName.Equals(actualUserName) && inputUserPwd.Equals(actualPassword))
            {
                //MessageBox.Show("密码正确！", "确认成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // 触发事件，将数据传递给父窗体
                DataReturned?.Invoke(this, new DataReturnedEventArgs(true));
                this.Close(); // 如果密码正确，关闭窗口
            }
            else
            {
                MessageBox.Show("密码错误！", "确认失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class DataReturnedEventArgs : EventArgs
    {
        /// <summary>
        /// 授权成功
        /// </summary>
        public bool IsAuthority { get; } = false;

        public DataReturnedEventArgs(bool data)
        {
            IsAuthority = data;
        }
    }
}
