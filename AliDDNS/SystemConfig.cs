using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AliDDNS
{
    public static class SystemConfig
    {

        private static string prefix = "";
        public static string Prefix
        {
            get { return SystemConfig.prefix; }

            set { SystemConfig.prefix = value; }
        }

        private static string domain = "";
        public static string Domain
        {
            get { return SystemConfig.domain; }
            set { SystemConfig.domain = value; }
        }

        private static string accessKeyId = "";
        public static string AccessKeyId
        {
            get { return SystemConfig.accessKeyId; }
            set { SystemConfig.accessKeyId = value; }
        }

        private static string accessKeySecret = "";
        public static string AccessKeySecret
        {
            get { return SystemConfig.accessKeySecret; }
            set { SystemConfig.accessKeySecret = value; }
        }

        private static string updateCycle = "";
        public static string UpdateCycle
        {
            get { return SystemConfig.updateCycle; }
            set { SystemConfig.updateCycle = value; }
        }

        private static string serverChanKey = "";
        public static string ServerChanKey
        {
            get { return SystemConfig.serverChanKey; }
            set { SystemConfig.serverChanKey = value; }
        }

        private static bool sendMessageToServerChan = false;
        public static bool SendMessageToServerChan
        {
            get { return SystemConfig.sendMessageToServerChan; }
            set { SystemConfig.sendMessageToServerChan = value; }
        }

        private static bool startOnBoot = false;
        public static bool StartOnBoot
        {
            get { return SystemConfig.startOnBoot; }
            set { SystemConfig.startOnBoot = value; }
        }

        private static System.Threading.Timer threadTimer = null;

        public static System.Threading.Timer ThreadTimer
        {
            get { return SystemConfig.threadTimer; }
            set { SystemConfig.threadTimer = value; }
        }

        private static string startupPath = Application.StartupPath;




        public static void saveConfig()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("Config");
            doc.AppendChild(root);
            XmlElement node = doc.CreateElement("Domain");
            node.SetAttribute("value", SystemConfig.Domain);
            root.AppendChild(node);
            node = doc.CreateElement("Prefix");
            node.SetAttribute("value", SystemConfig.Prefix);
            root.AppendChild(node);
            node = doc.CreateElement("AccessKeyId");
            node.SetAttribute("value", SystemConfig.AccessKeyId);
            root.AppendChild(node);
            node = doc.CreateElement("AccessKeySecret");
            node.SetAttribute("value", SystemConfig.AccessKeySecret);
            root.AppendChild(node);
            node = doc.CreateElement("UpdateCycle");
            node.SetAttribute("value", SystemConfig.UpdateCycle);
            root.AppendChild(node);
            node = doc.CreateElement("ServerChanKey");
            node.SetAttribute("value", SystemConfig.ServerChanKey);
            root.AppendChild(node);
            node = doc.CreateElement("SendMessageToServerChan");
            node.SetAttribute("value", SystemConfig.SendMessageToServerChan ? "yes" : "no");
            root.AppendChild(node);
            doc.Save(startupPath + @"\SystemConfig.xml");

            if (SystemConfig.StartOnBoot)
            {
                SystemConfig.AddOnBootConfig();
            }
            else
            {
                SystemConfig.DeleteOnBootConfig();
            }
        }

        public static void loadConfig()
        {
            
            if (File.Exists(startupPath + @"\SystemConfig.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(startupPath + @"\SystemConfig.xml");
                SystemConfig.Domain = doc.SelectSingleNode("//Domain").Attributes["value"].Value;
                SystemConfig.AccessKeyId = doc.SelectSingleNode("//AccessKeyId").Attributes["value"].Value;
                SystemConfig.AccessKeySecret = doc.SelectSingleNode("//AccessKeySecret").Attributes["value"].Value;
                SystemConfig.UpdateCycle = doc.SelectSingleNode("//UpdateCycle").Attributes["value"].Value;
                SystemConfig.Prefix = doc.SelectSingleNode("//Prefix").Attributes["value"].Value;
                SystemConfig.ServerChanKey = doc.SelectSingleNode("//ServerChanKey").Attributes["value"].Value;
                SystemConfig.SendMessageToServerChan = "yes".Equals(doc.SelectSingleNode("//SendMessageToServerChan").Attributes["value"].Value) ? true : false;
            }
            getOnBootConfig();
        }

        private static void getOnBootConfig()
        {
            RegistryKey reg = Registry.CurrentUser;
            RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (run.GetValue("AliDDNS") != null)
            {
                SystemConfig.StartOnBoot = true;
            }
        }

        public static void AddOnBootConfig()
        {
            string localPath = Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser;
            RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (run.GetValue("AliDDNS") == null)
            {
                try
                {
                    run.SetValue("AliDDNS", localPath);
                    reg.Close();
                }
                catch
                {
                }
            }
            SystemConfig.StartOnBoot = true;
        }
        public static void DeleteOnBootConfig()
        {
            string localPath = Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser;
            RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (run.GetValue("AliDDNS") != null)
            {
                try
                {
                    run.DeleteValue("AliDDNS");
                    reg.Close();
                }
                catch
                {
                }
            }
            SystemConfig.StartOnBoot = false;
        }
    }
}
