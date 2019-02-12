namespace AliDDNS
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelCurIP = new System.Windows.Forms.Label();
            this.btnGetCurIP = new System.Windows.Forms.Button();
            this.labelDDNSIP = new System.Windows.Forms.Label();
            this.btnSetDDNS = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetDDNSIP = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.NotifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCurIP
            // 
            this.labelCurIP.AutoSize = true;
            this.labelCurIP.Location = new System.Drawing.Point(109, 17);
            this.labelCurIP.Name = "labelCurIP";
            this.labelCurIP.Size = new System.Drawing.Size(71, 12);
            this.labelCurIP.TabIndex = 0;
            this.labelCurIP.Text = "正在获取...";
            // 
            // btnGetCurIP
            // 
            this.btnGetCurIP.Location = new System.Drawing.Point(250, 12);
            this.btnGetCurIP.Name = "btnGetCurIP";
            this.btnGetCurIP.Size = new System.Drawing.Size(75, 23);
            this.btnGetCurIP.TabIndex = 1;
            this.btnGetCurIP.Text = "获取当前IP";
            this.btnGetCurIP.UseVisualStyleBackColor = true;
            this.btnGetCurIP.Click += new System.EventHandler(this.btnGetCurIP_Click);
            // 
            // labelDDNSIP
            // 
            this.labelDDNSIP.AutoSize = true;
            this.labelDDNSIP.Location = new System.Drawing.Point(109, 47);
            this.labelDDNSIP.Name = "labelDDNSIP";
            this.labelDDNSIP.Size = new System.Drawing.Size(71, 12);
            this.labelDDNSIP.TabIndex = 4;
            this.labelDDNSIP.Text = "正在获取...";
            // 
            // btnSetDDNS
            // 
            this.btnSetDDNS.Location = new System.Drawing.Point(343, 12);
            this.btnSetDDNS.Name = "btnSetDDNS";
            this.btnSetDDNS.Size = new System.Drawing.Size(75, 23);
            this.btnSetDDNS.TabIndex = 5;
            this.btnSetDDNS.Text = "设置";
            this.btnSetDDNS.UseVisualStyleBackColor = true;
            this.btnSetDDNS.Click += new System.EventHandler(this.btnSetDDNS_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(343, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 24);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "立即更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.NotifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "阿里DDNS";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.开机启动ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.Size = new System.Drawing.Size(125, 70);
            this.NotifyMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyMenu_Opening);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 开机启动ToolStripMenuItem
            // 
            this.开机启动ToolStripMenuItem.Name = "开机启动ToolStripMenuItem";
            this.开机启动ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开机启动ToolStripMenuItem.Text = "开机启动";
            this.开机启动ToolStripMenuItem.Click += new System.EventHandler(this.开机启动ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "DDNSIP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "当前外网IP：";
            // 
            // btnGetDDNSIP
            // 
            this.btnGetDDNSIP.Location = new System.Drawing.Point(250, 42);
            this.btnGetDDNSIP.Name = "btnGetDDNSIP";
            this.btnGetDDNSIP.Size = new System.Drawing.Size(75, 23);
            this.btnGetDDNSIP.TabIndex = 10;
            this.btnGetDDNSIP.Text = "获取DDNSIP";
            this.btnGetDDNSIP.UseVisualStyleBackColor = true;
            this.btnGetDDNSIP.Click += new System.EventHandler(this.btnGetDDNSIP_Click);
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(12, 78);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(77, 12);
            this.labelLog.TabIndex = 11;
            this.labelLog.Text = "【软件启动】";
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.Location = new System.Drawing.Point(12, 98);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(77, 12);
            this.labelLastUpdate.TabIndex = 12;
            this.labelLastUpdate.Text = "【软件启动】";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 119);
            this.Controls.Add(this.labelLastUpdate);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.btnGetDDNSIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSetDDNS);
            this.Controls.Add(this.labelDDNSIP);
            this.Controls.Add(this.btnGetCurIP);
            this.Controls.Add(this.labelCurIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(547, 158);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "阿里DDNS";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.NotifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurIP;
        private System.Windows.Forms.Button btnGetCurIP;
        private System.Windows.Forms.Label labelDDNSIP;
        private System.Windows.Forms.Button btnSetDDNS;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetDDNSIP;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.ToolStripMenuItem 开机启动ToolStripMenuItem;
        private System.Windows.Forms.Label labelLastUpdate;
    }
}

