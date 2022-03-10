using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;



namespace QADemoProject.SupportClasses
{

    //Rest Api methods can be used for API testing
    public class ApiCallsHelper
    {
        #region XML
        //POST method For XML
        public static IRestResponse PostCreateXml<T>(string url, string userName, string password, string resource, T content)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.Timeout = 30000;
            string xml;
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(content.GetType());
                XmlSerializerNamespaces xmlnamespace = new XmlSerializerNamespaces();
                xmlnamespace.Add("", "http://transunion.com/dc/extsvc");
                serializer.Serialize(stringWriter, content, xmlnamespace);
                xml = stringWriter.ToString();
                xml = xml.Replace("&gt;", ">").Replace("&lt;", "<");
                xml = xml.Replace("\r\n", "");
                xml = xml.Replace("q1:", "");
            }
            request.AddParameter("Content-Type", "application/xml; charset=utf-8");
            request.AddParameter("application/xml", xml, ParameterType.RequestBody);

            return client.Execute(request);

        }

        //POST method For XML with client certificate
        public static IRestResponse PostCreateXmlCCMStage<T>(string url, string userName, string password, string resource, T content, string certFile, string certUser, string certPassword)
        {


            var x509Certificate = new X509Certificate2(System.IO.File.ReadAllBytes(certFile)
                                   , certPassword
                                   , X509KeyStorageFlags.MachineKeySet |
                                     X509KeyStorageFlags.PersistKeySet |
                                     X509KeyStorageFlags.Exportable);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(url);
            client.ClientCertificates = new X509CertificateCollection();
            client.ClientCertificates.Add(x509Certificate);
            client.Authenticator = new HttpBasicAuthenticator(certUser, certPassword);
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("CLIENT-USER", userName);
            request.AddHeader("CLIENT-PASSWORD", password);
            request.RequestFormat = DataFormat.Xml;
            request.Timeout = 30000;
            string xml;
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(content.GetType());
                XmlSerializerNamespaces xmlnamespace = new XmlSerializerNamespaces();
                xmlnamespace.Add("", "http://www.transunion.com/namespace");
                serializer.Serialize(stringWriter, content, xmlnamespace);
                xml = stringWriter.ToString();
                xml = xml.Replace("&gt;", ">").Replace("&lt;", "<");


            }
            request.AddParameter("Content-Type", "application/xml; charset=utf-8");
            request.AddParameter("application/xml", xml, ParameterType.RequestBody);
            return client.Execute(request);

        }

        //Converts request to string format
        public static string ConvertRequestIntoString<T>(T content)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(content.GetType());
                XmlSerializerNamespaces xmlnamespace = new XmlSerializerNamespaces();
                xmlnamespace.Add("", "");
                serializer.Serialize(stringWriter, content, xmlnamespace);
                string applicationdatastructure = stringWriter.ToString();
                applicationdatastructure = applicationdatastructure.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Trim();
                applicationdatastructure = applicationdatastructure.Replace("q1:", "");
                applicationdatastructure = applicationdatastructure.Replace("xmlns:q1=\"http://transunion.com/dc/extsvc\"", "");
                applicationdatastructure = string.Concat("<![CDATA[", applicationdatastructure, "]]>");
                return applicationdatastructure;
            }
        }

        //POST method For Json
        public static IRestResponse PostCreateJSON<T>(string url, string userName, string password, string resource, T content)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator("USCellularSystemStage", "Pass12345");

            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 30000;
            string json;
            using (var stringWriter = new StringWriter())
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(stringWriter, content);
                json = stringWriter.ToString();

            }
            request.AddParameter("Content-Type", "application/json; charset=utf-8");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.DownloadData(request);
            return client.Execute(request);

        }
        public static string ViewApplicationJSON(string url, string userName, string password, string resource)
        {

            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes("USCellularSystemStage" + ":" + "Pass123"));
            client.Headers.Add("Authorization", "Basic " + encoded);
            client.Proxy = null;
            string viewAppResponse = client.DownloadString(url);
            client.Dispose();
            return viewAppResponse;

        }



        // XML Deserialization      
        public static T DeserializeXmlResponse<T>(IRestResponse response) where T : new()
        {
            var content = response.Content;
            T deserializedResponse;


            using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                deserializedResponse = (T)serializer.Deserialize(memStream);
            }

            return deserializedResponse;
        }
        #endregion

        #region JSON
        //GET
        public static IRestResponse GetResponse(string url, string resource, string authJson = null, List<Parameter> parameters = null)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 30000;

            request.AddHeader("Accept", "application/json");
            if (authJson != null)
                request.AddHeader("Authorization", authJson);

            request.Parameters.Clear();
            if (parameters != null)
                foreach (Parameter parameter in parameters)
                    request.AddParameter(parameter);

            return client.Execute(request);
        }

        //POST
        public static IRestResponse PostCreate<T>(string url, string resource, string authJson, T content, List<Parameter> parameters = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.Timeout = 30000;

            request.AddHeader("Accept", "application/json");
            // request.AddHeader("Authorization", authJson);

            request.Parameters.Clear();
            if (content != null)
            {
                var jBody = JsonConvert.SerializeObject(content);
                request.AddParameter("application/json", jBody, ParameterType.RequestBody);
            }

            if (parameters != null)
                foreach (Parameter parameter in parameters)
                    request.AddParameter(parameter);

            return client.Execute(request);
        }

        public static IRestResponse PostCreate(string url, string resource, string authJson, List<Parameter> parameters)
        {
            return PostCreate(url, resource, authJson, "", parameters);
        }

        //PUT
        public static IRestResponse UpdateApplication(string url, string resource, string authJson, List<Parameter> parameters = null)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.PUT)
            {
                RequestFormat = DataFormat.Json,
                Timeout = 30000
            };

            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddHeader("Authorization", authJson);

            if (parameters != null)
                foreach (Parameter parameter in parameters)
                    request.AddParameter(parameter);

            return client.Execute(request);
        }

        public static T DeserializeContent<T>(IRestResponse response) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
        #endregion

        //VERIFY
        public static bool Is200OkResponse(IRestResponse response)
        {
            return response.IsSuccessful;
        }

        //ToDo - Combine 200 & 201; Same response; Needs to be readable.
        public static bool Is201CreatedResponse(IRestResponse response)
        {
            return response.IsSuccessful;
        }
        public static T DeserializeXmlResponseInStringFormat<T>(string response) where T : new()
        {
            var content = response;
            T deserializedResponse;


            using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                deserializedResponse = (T)serializer.Deserialize(memStream);
            }

            return deserializedResponse;
        }

    }
}