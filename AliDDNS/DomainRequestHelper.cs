using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace AliDDNS
{
    public class DomainRequestHelper
    {
        /// <summary>
        /// 返回值的类型，支持JSON与XML。默认为XML
        /// </summary>
        private string format = "XML";

        private string Format
        {
            get { return format; }
            set { format = value; }
        }

        /// <summary>
        /// API版本号，为日期形式：YYYY-MM-DD，本版本对应为2015-01-09
        /// </summary>
        private string Version { get { return "2015-01-09"; } }

        /// <summary>
        /// 签名结果串
        /// </summary>
        private string Signature { get; set; }

        /// <summary>
        /// 签名方式，目前支持HMAC-SHA1
        /// </summary>
        private string SignatureMethod { get { return "HMAC-SHA1"; } }

        /// <summary>
        /// 签名算法版本，目前版本是1.0
        /// </summary>
        private string SignatureVersion { get { return "1.0"; } }

        private string accessKeyId = SystemConfig.AccessKeyId;
        public string AccessKeyId
        {
            get { return accessKeyId; }
            set { accessKeyId = value; }
        }

        private string accessKeySecret = SystemConfig.AccessKeySecret;
        public string AccessKeySecret
        {
            get { return accessKeySecret; }
            set { accessKeySecret = value; }
        }

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<string, string> _parameters;

        public DomainRequestHelper(Dictionary<string, string> parameters)
        {
            _parameters = parameters;
        }

        private void BuildParameters()
        {
            _parameters["Format"] = Format.ToUpper();
            _parameters["Version"] = Version;
            _parameters["AccessKeyId"] = accessKeyId;
            _parameters["SignatureVersion"] = SignatureVersion;
            _parameters["SignatureMethod"] = SignatureMethod;
            _parameters["SignatureNonce"] = Guid.NewGuid().ToString();
            _parameters["Timestamp"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        private void computeSignature()
        {
            BuildParameters();
            var canonicalizedQueryString = string.Join("&",
                _parameters.OrderBy(x => x.Key)
                .Select(x => percentEncode(x.Key) + "=" + percentEncode(x.Value)));

            var stringToSign = "GET" + "&%2F&" + percentEncode(canonicalizedQueryString);

            var keyBytes = Encoding.UTF8.GetBytes(accessKeySecret + "&");
            var hmac = new HMACSHA1(keyBytes);
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
            Signature = Convert.ToBase64String(hashBytes);
            _parameters["Signature"] = Signature;
        }

        private string percentEncode(string value)
        {
            return UpperCaseUrlEncode(value)
                .Replace("+", "%20")
                .Replace("*", "%2A")
                .Replace("%7E", "~");
        }

        private static string UpperCaseUrlEncode(string s)
        {
            char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
            for (int i = 0; i < temp.Length - 2; i++)
            {
                if (temp[i] == '%')
                {
                    temp[i + 1] = char.ToUpper(temp[i + 1]);
                    temp[i + 2] = char.ToUpper(temp[i + 2]);
                }
            }
            return new string(temp);
        }

        public string GetUrl(string url)
        {
            computeSignature();
            return "http://" + url + "/?" +
                string.Join("&", _parameters.Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value)));
        }

        public static List<XmlNode> getTypeAList(ref List<string> typeARecordId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"Action", "DescribeDomainRecords"},
                {"DomainName", SystemConfig.Domain},
                {"TypeKeyWord", "A"},
                {"RRKeyWord", SystemConfig.Prefix},
            };
            string recordsXML = requestAli(parameters);
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(recordsXML);
            XmlNodeList nodelist = xml.SelectNodes("//Record");
            List<XmlNode> typeANodeList = new List<XmlNode>();
            foreach (XmlNode node in nodelist)
            {
                XmlNode idNode = node.SelectSingleNode("RecordId");
                string recordId = idNode.InnerText;
                typeARecordId.Add(recordId);
                typeANodeList.Add(node);
            }
            return typeANodeList;
        }

        public static string requestAli(Dictionary<string, string> parameters)
        {
            Thread.Sleep(1000);
            string domain = "alidns.aliyuncs.com";
            DomainRequestHelper requestHelper = new DomainRequestHelper(parameters);
            string url = requestHelper.GetUrl(domain);
            WebRequest request = request = HttpWebRequest.Create(url);
            request.Timeout = 10 * 1000;
            Stream responseStream = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
