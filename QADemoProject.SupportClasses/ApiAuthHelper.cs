using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using RestSharp;

namespace QADemoProject.SupportClasses
{
    //Note - Not used in this demo. Teams do use this. Your auth header might be different.
    public class ApiAuthHelper
    {
        public static IRestResponse GetUtcServerTime(string url, string resource)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.GET);

            Console.WriteLine(request);

            // execute the request
            return client.Execute(request);
        }

        public static string GetSecurityToken(string partnerId, string securityKey, string serverTime)
        {
            // Concatenate the partnerId and the serverTime
            var inputString = partnerId + serverTime;

            // Convert security key into ASCII bytes using utf8 encoding 
            var securityKeyBytes = Encoding.ASCII.GetBytes(securityKey);

            // Create an HMACSHA1 hashing object that has been seeded with the security key bytes 
            var hasher = new HMACSHA1(securityKeyBytes);

            // Convert input string into ASCII bytes using utf8 encoding 
            var inputBytes = Encoding.ASCII.GetBytes(inputString.ToCharArray());

            // Compute the has value 
            var hash = hasher.ComputeHash(inputBytes);

            // Convert back to a base 64 string 
            return Convert.ToBase64String(hash);
        }


    }
}
