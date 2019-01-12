using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AliDDNS
{
    public partial class FormSetDDNS : Form
    {

        public FormSetDDNS()
        {
            InitializeComponent();
            this.textPrefix.Text = SystemConfig.Prefix;
            this.textDomain.Text = SystemConfig.Domain;
            this.textAccID.Text = SystemConfig.AccessKeyId;
            this.textAccSecret.Text = SystemConfig.AccessKeySecret;
            this.textUpdateCycle.Text = SystemConfig.UpdateCycle;
            this.textServerChanKey.Text = SystemConfig.ServerChanKey;
            this.chkSendMessageToServerChan.Checked = SystemConfig.SendMessageToServerChan;
            this.checkStartOnBoot.Checked = SystemConfig.StartOnBoot;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"Action", "DescribeDomainRecords"},
                {"DomainName", this.textDomain.Text},
                {"RRKeyWord", this.textPrefix.Text},
            };
            string domain = "alidns.aliyuncs.com";
            DomainRequestHelper requestHelper = new DomainRequestHelper(parameters);
            requestHelper.AccessKeyId = this.textAccID.Text;
            requestHelper.AccessKeySecret = this.textAccSecret.Text;
            string url = requestHelper.GetUrl(domain);
            WebRequest request = request = HttpWebRequest.Create(url);
            request.Timeout = 10 * 1000;
            Stream responseStream = null;
            try
            {
                responseStream = request.GetResponse().GetResponseStream();
            }
            catch
            {
                MessageBox.Show("验证失败");
                return;
            }
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string recordsXML = reader.ReadToEnd();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(recordsXML);
            if (xml.SelectNodes("//Error").Count > 0)
            {
                MessageBox.Show("验证失败");
                return;
            }

            SystemConfig.Domain = this.textDomain.Text;
            SystemConfig.AccessKeyId = this.textAccID.Text;
            SystemConfig.AccessKeySecret = this.textAccSecret.Text;
            SystemConfig.UpdateCycle = this.textUpdateCycle.Text;
            SystemConfig.ServerChanKey = this.textServerChanKey.Text;
            SystemConfig.SendMessageToServerChan = this.chkSendMessageToServerChan.Checked;
            if (!string.IsNullOrEmpty(SystemConfig.UpdateCycle))
            {
                int cycleTime = Int32.Parse(SystemConfig.UpdateCycle) * 60 * 1000;
                SystemConfig.ThreadTimer.Change(0, cycleTime);
            }
            else
            {
                SystemConfig.ThreadTimer.Change(-1, 0);
            }

           SystemConfig.StartOnBoot = this.checkStartOnBoot.Checked;

            SystemConfig.saveConfig();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
