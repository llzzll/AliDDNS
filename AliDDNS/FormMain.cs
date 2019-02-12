using System;
using System.Threading;
using System.Windows.Forms;


namespace AliDDNS
{
    public partial class FormMain : Form
    {
        delegate void CallBackHandle1();
        private const int WM_QUERYENDSESSION = 0x0011;

        public FormMain()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(SystemConfig.UpdateCycle))
            {
                int cycleTime = Int32.Parse(SystemConfig.UpdateCycle) * 60 * 1000;
                SystemConfig.ThreadTimer = new System.Threading.Timer(new TimerCallback(updateDDNSCycle), null, 0, cycleTime);
            }
            else
            {
                SystemConfig.ThreadTimer = new System.Threading.Timer(new TimerCallback(updateDDNSCycle), null, -1, 0);
                this.labelCurIP.Text = BLL.getCurIP();
                this.labelDDNSIP.Text = BLL.getDDNSIP();
            }
        }

        private void updateDDNSCycle(object data)
        {
            string curIp = BLL.getCurIP();
            string updateIP = BLL.updateDDNS();
            string ddnsIp = BLL.getDDNSIP();
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            CallBackHandle1 c = () =>
            {
                this.labelCurIP.Text = curIp;
                if (string.IsNullOrEmpty(updateIP))
                {
                    this.labelLog.Text = "【" + nowTime + "】：keep";
                }
                else if ("error".Equals(updateIP))
                {
                    this.labelLog.Text = "【" + nowTime + "】：error";
                }
                else
                {
                    this.labelLog.Text = "【" + nowTime + "】：success（" + updateIP + "）";
                    this.labelLastUpdate.Text = "【" + nowTime + "】：lastUpdate（" + updateIP + "）";
                }
                this.labelDDNSIP.Text = ddnsIp;
            };
            Invoke(c, new object[] { });
        }

        #region 窗体事件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //图标显示在托盘区
                this.notifyIcon.Visible = true;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                this.notifyIcon.Visible = true;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            //激活窗体并给予它焦点
            this.Activate();
            //任务栏区显示图标
            this.ShowInTaskbar = true;
            //托盘区图标隐藏
            notifyIcon.Visible = false;
        }

        private void 开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemConfig.StartOnBoot)
            {
                SystemConfig.DeleteOnBootConfig();
                this.开机启动ToolStripMenuItem.Checked = false;
            }
            else
            {
                SystemConfig.AddOnBootConfig();
                this.开机启动ToolStripMenuItem.Checked = true;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCurIP_Click(object sender, EventArgs e)
        {
            this.labelCurIP.Text = "正在获取...";
            Application.DoEvents();
            this.labelCurIP.Text = BLL.getCurIP();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.labelCurIP.Text = "正在获取...";
            this.labelLog.Text = "正在获取...";
            this.labelDDNSIP.Text = "正在获取...";
            Application.DoEvents();
            this.labelCurIP.Text = BLL.getCurIP();
            Application.DoEvents();
            this.Refresh();
            string updateIP = BLL.updateDDNS();
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (string.IsNullOrEmpty(updateIP))
            {
                this.labelLog.Text = "【" + nowTime + "】：keep";
            }
            else if ("error".Equals(updateIP))
            {
                this.labelLog.Text = "【" + nowTime + "】：error";
            }
            else
            {
                this.labelLog.Text = "【" + nowTime + "】：success（" + updateIP + "）";
                this.labelLastUpdate.Text = "【" + nowTime + "】：lastUpdate（" + updateIP + "）";
            }
            Application.DoEvents();
            this.Refresh();
            this.labelDDNSIP.Text = BLL.getDDNSIP();
        }


        private void btnGetDDNSIP_Click(object sender, EventArgs e)
        {
            this.labelDDNSIP.Text = "正在获取...";
            Application.DoEvents();
            this.labelDDNSIP.Text = BLL.getDDNSIP();
        }

        private void btnSetDDNS_Click(object sender, EventArgs e)
        {
            FormSetDDNS frm = new FormSetDDNS();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void NotifyMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.开机启动ToolStripMenuItem.Checked = SystemConfig.StartOnBoot;
        }


        #endregion

        /// <summary>
        /// 窗口过程的回调函数
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //此消息在OnFormClosing之前
                case WM_QUERYENDSESSION:
                    this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
                    this.Close();
                    this.Dispose();
                    Application.Exit();
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

    }
}
