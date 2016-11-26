using PloteusTR.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PloteusTR.Client
{
    public class PloteusWebClient
    {
        string _userName, _password;

        public PloteusWebClient(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public async Task<UploadResult> uploadLearningOpportunitiesXml(string xml)
        {
            using (var client = getClient())
            {
                using (var message = getMessage(HttpMethod.Post, getUri("uploadLearningOpportunitiesXml")))
                {
                    var body = Encoding.UTF8.GetBytes(xml);
                    using (var content = new ByteArrayContent(body))
                    {
                        message.Content = content;
                        var response = await client.SendAsync(message);
                        var responseAsString = await response.Content.ReadAsStringAsync();

                        return deserializeFromXml< UploadResult >(responseAsString);
                    }
                }
            }
        }

        public async Task<UploadResult> uploadQualificationsXml(string xml)
        {
            using (var client = getClient())
            {
                using (var message = getMessage(HttpMethod.Post, getUri("uploadQualificationsXml")))
                {
                    var body = Encoding.UTF8.GetBytes(xml);
                    using (var content = new ByteArrayContent(body))
                    {
                        message.Content = content;
                        var response = await client.SendAsync(message);
                        var responseAsString = await response.Content.ReadAsStringAsync();

                        return deserializeFromXml<UploadResult>(responseAsString);
                    }
                }
            }
        }

        public async Task<JobResult> getXmlStatus(string requestId)
        {
            using (var client = getClient())
            { 
                string uri = getUri($"getXmlStatus?requestId={requestId}");
                using (var message = getMessage(HttpMethod.Get, getUri($"getXmlStatus?requestId={requestId}")))
                {
                    var response = await client.SendAsync(message);
                    var responseAsString = await response.Content.ReadAsStringAsync();
                    return deserializeFromXml<JobResult>(responseAsString);
                }
            }
        }

        private string getUri(string path)
        {
            return String.Concat("https://ploteus.iskur.gov.tr/api/Ploteus/", path);
        }

        private T deserializeFromXml<T>(string xml)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var bytes = Encoding.UTF8.GetBytes(xml);
            using (var ms = new MemoryStream(bytes))
            {
                return (T)serializer.ReadObject(ms);
            }
        }

        private HttpClient getClient()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(10);

            return client;
        }

        private HttpRequestMessage getMessage(HttpMethod method, string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage(method, uri);
            if (message.Headers.Contains("user-agent") == false)
            {
                message.Headers.Add("user-agent", "ploteus-tr-dotnet-client");
            }
            var userNameAndPassword = $"{_userName}:{_password}";
            var userNameAndPasswordBytes = Encoding.UTF8.GetBytes(userNameAndPassword);
            var userNameAndPasswordAsBase64 = Convert.ToBase64String(userNameAndPasswordBytes);
            message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("basic", userNameAndPasswordAsBase64);
            message.Headers.Add("Accept", "application/xml");

            return message;
        }
    }
}
