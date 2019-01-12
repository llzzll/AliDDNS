namespace AliDDNS
{
    partial class FormSetDDNS
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
            this.label1 = new System.Windows.Forms.Label();
            this.textDomain = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.checkMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textAccID = new System.Windows.Forms.TextBox();
            this.textAccSecret = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textUpdateCycle = new System.Windows.Forms.TextBox();
            this.textPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textServerChanKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSendMessageToServerChan = new System.Windows.Forms.CheckBox();
            this.checkStartOnBoot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "域名:";
            // 
            // textDomain
            // 
            this.textDomain.Location = new System.Drawing.Point(147, 37);
            this.textDomain.Name = "textDomain";
            this.textDomain.Size = new System.Drawing.Size(141, 21);
            this.textDomain.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(311, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 48);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // checkMsg
            // 
            this.checkMsg.AutoSize = true;
            this.checkMsg.ForeColor = System.Drawing.Color.Red;
            this.checkMsg.Location = new System.Drawing.Point(24, 73);
            this.checkMsg.Name = "checkMsg";
            this.checkMsg.Size = new System.Drawing.Size(0, 12);
            this.checkMsg.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "AccessKey ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Access Key Secret:";
            // 
            // textAccID
            // 
            this.textAccID.Location = new System.Drawing.Point(147, 65);
            this.textAccID.Name = "textAccID";
            this.textAccID.Size = new System.Drawing.Size(141, 21);
            this.textAccID.TabIndex = 2;
            // 
            // textAccSecret
            // 
            this.textAccSecret.Location = new System.Drawing.Point(147, 93);
            this.textAccSecret.Name = "textAccSecret";
            this.textAccSecret.Size = new System.Drawing.Size(141, 21);
            this.textAccSecret.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "更新周期（分钟）:";
            // 
            // textUpdateCycle
            // 
            this.textUpdateCycle.Location = new System.Drawing.Point(147, 120);
            this.textUpdateCycle.Name = "textUpdateCycle";
            this.textUpdateCycle.Size = new System.Drawing.Size(141, 21);
            this.textUpdateCycle.TabIndex = 4;
            // 
            // textPrefix
            // 
            this.textPrefix.Location = new System.Drawing.Point(147, 10);
            this.textPrefix.Name = "textPrefix";
            this.textPrefix.Size = new System.Drawing.Size(141, 21);
            this.textPrefix.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "前缀:";
            // 
            // textServerChanKey
            // 
            this.textServerChanKey.Location = new System.Drawing.Point(147, 147);
            this.textServerChanKey.Name = "textServerChanKey";
            this.textServerChanKey.Size = new System.Drawing.Size(141, 21);
            this.textServerChanKey.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "serverChan KEY:";
            // 
            // chkSendMessageToServerChan
            // 
            this.chkSendMessageToServerChan.AutoSize = true;
            this.chkSendMessageToServerChan.Location = new System.Drawing.Point(311, 149);
            this.chkSendMessageToServerChan.Name = "chkSendMessageToServerChan";
            this.chkSendMessageToServerChan.Size = new System.Drawing.Size(72, 16);
            this.chkSendMessageToServerChan.TabIndex = 15;
            this.chkSendMessageToServerChan.Text = "发送消息";
            this.chkSendMessageToServerChan.UseVisualStyleBackColor = true;
            // 
            // checkStartOnBoot
            // 
            this.checkStartOnBoot.AutoSize = true;
            this.checkStartOnBoot.Location = new System.Drawing.Point(311, 123);
            this.checkStartOnBoot.Name = "checkStartOnBoot";
            this.checkStartOnBoot.Size = new System.Drawing.Size(72, 16);
            this.checkStartOnBoot.TabIndex = 16;
            this.checkStartOnBoot.Text = "开机启动";
            this.checkStartOnBoot.UseVisualStyleBackColor = true;
            // 
            // FormSetDDNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 179);
            this.Controls.Add(this.checkStartOnBoot);
            this.Controls.Add(this.chkSendMessageToServerChan);
            this.Controls.Add(this.textServerChanKey);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textUpdateCycle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textAccSecret);
            this.Controls.Add(this.textAccID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkMsg);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.textDomain);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSetDDNS";
            this.Text = "设置DDNS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDomain;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label checkMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAccID;
        private System.Windows.Forms.TextBox textAccSecret;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textUpdateCycle;
        private System.Windows.Forms.TextBox textPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textServerChanKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSendMessageToServerChan;
        private System.Windows.Forms.CheckBox checkStartOnBoot;
    }
}