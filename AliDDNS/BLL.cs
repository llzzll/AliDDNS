using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Xml;


namespace AliDDNS
{
    static class BLL
    {
        public static string getCurIP()
        {
            try
            {
                WebClient client = new WebClient();
                string response = client.DownloadString("https://ipv4.jsonip.com/");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<String, String> dic = serializer.Deserialize<Dictionary<String, String>>(response);
                return dic["ip"];
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                return "获取失败，请检查网络：" + ex.Message;
            }
        }


        public static AlibabaCloud.SDK.Alidns20150109.Client CreateClient()
        {
            Aliyun.Credentials.Client credential = new Aliyun.Credentials.Client();
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                Credential = credential,
            };
            config.Endpoint = "alidns.aliyuncs.com";
            return new AlibabaCloud.SDK.Alidns20150109.Client(config);
        }


        public static string updateDDNS()
        {
            try
            {
                if (string.IsNullOrEmpty(SystemConfig.AccessKeyId) || string.IsNullOrEmpty(SystemConfig.AccessKeySecret) || string.IsNullOrEmpty(SystemConfig.Domain))
                {
                    FormSetDDNS frm = new FormSetDDNS();
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return "【请输入正确配置】";
                    }
                }
                Dictionary<string, string> parameters;
                List<string> typeARecordIdList = new List<string>();
                string updateIP = getCurIP();
                List<XmlNode> typeANodeList = DomainRequestHelper.getTypeAList(ref typeARecordIdList);
                if (typeARecordIdList.Count >= 0)
                {
                    if (typeARecordIdList.Count == 1)
                    {
                        XmlNode node = typeANodeList[0];
                        XmlNode valueNode = node.SelectSingleNode("Value");
                        if (valueNode.InnerText.Equals(updateIP))
                        {
                            return "";
                        }
                        else
                        {
                            parameters = new Dictionary<string, string>()
                            {
                                {"Action", "UpdateDomainRecord"},
                                {"RecordId", typeARecordIdList[0]},
                                {"RR", "www"},
                                {"Type", "A"},
                                {"Value", updateIP},
                            };
                            DomainRequestHelper.requestAliyun(parameters);
                        }
                    }
                    else if (typeARecordIdList.Count > 0)
                    {
                        foreach (string recordId in typeARecordIdList)
                        {
                            parameters = new Dictionary<string, string>()
                            {
                                {"Action", "DeleteDomainRecord"},
                                {"RecordId", recordId},
                            };
                            DomainRequestHelper.requestAliyun(parameters);
                        }
                    }
                }
                else
                {
                    // 添加记录
                    parameters = new Dictionary<string, string>()
                    {
                        {"Action", "AddDomainRecord"},
                        {"DomainName", SystemConfig.Domain},
                        {"RR", SystemConfig.Prefix},
                        {"Type", "A"},
                        {"Value", updateIP},
                    };
                    DomainRequestHelper.requestAliyun(parameters);
                }

                // 验证
                typeANodeList = DomainRequestHelper.getTypeAList(ref typeARecordIdList);
                if (typeANodeList.Count > 1 || typeANodeList.Count == 0)
                {
                    updateDDNS();
                }
                else
                {
                    XmlNode node = typeANodeList[0];
                    XmlNode valueNode = node.SelectSingleNode("Value");
                    if (!valueNode.InnerText.Equals(updateIP))
                    {
                        updateDDNS();
                    }
                }
                if (SystemConfig.SendMessageToServerChan)
                {
                    sendMsgToServerChan("DDNS已更新（" + updateIP + "）");
                }
                return updateIP;
            }
            catch(Exception ex)
            {
                Console.Write(ex.StackTrace);
                return "error:" + ex.Message;
            }

        }

        public static string getDDNSIP()
        {
            try
            {
                if (string.IsNullOrEmpty(SystemConfig.AccessKeyId) || string.IsNullOrEmpty(SystemConfig.AccessKeySecret) || string.IsNullOrEmpty(SystemConfig.Domain))
                {
                    return "无可用配置";
                }
                List<string> typeARecordId = new List<string>();
                List<XmlNode> typeANodeList = DomainRequestHelper.getTypeAList(ref typeARecordId);
                if (typeANodeList.Count > 0)
                {
                    XmlNode node = typeANodeList[0];
                    XmlNode valueNode = node.SelectSingleNode("Value");
                    return valueNode.InnerText;
                }
            }
            catch (Exception)
            {

                return "连接失败";
            }
            return "";
        }

        public static bool CheckConfig(Dictionary<string, string> parameters, string accessKeyId, string accessKeySecret)
        {
            try
            {
                string domain = "alidns.aliyuncs.com";
                DomainRequestHelper requestHelper = new DomainRequestHelper(parameters);
                requestHelper.AccessKeyId = accessKeyId;
                requestHelper.AccessKeySecret = accessKeySecret;
                string url = requestHelper.GetUrl(domain);
                WebRequest request = request = HttpWebRequest.Create(url);
                request.Timeout = 10 * 1000;
                Stream responseStream = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                string recordsXML = reader.ReadToEnd();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(recordsXML);
                if (xml.SelectNodes("//Error").Count > 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static void sendMsgToServerChan(string data)
        {
            try
            {
                WebRequest request = request = HttpWebRequest.Create("https://sc.ftqq.com/" + SystemConfig.ServerChanKey + ".send?text=" + data);
                request.GetResponse();
            }
            catch (Exception)
            {

                return;
            }
        }


    }
}
