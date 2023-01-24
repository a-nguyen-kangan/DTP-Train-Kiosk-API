using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace KioskLib
{
    public abstract class Fetch
    {
        protected string devid;
        protected string devkey;
        protected string ApiServer = "http://timetableapi.ptv.vic.gov.au";
        protected async Task<string> Request(string url)
        {
            url = url.Replace(" ", "%20");
            url = ApiServer + url + SignData(url, devkey);
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            return response;
        }
        protected void init()
        {
            var appConfig = new ConfigurationBuilder()
            .AddUserSecrets<Fetch>()
            .Build();
            devid = appConfig["devid"];
            devkey = appConfig["devkey"];
        }
        public string SignData(string request, string key)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] requestBytes = encoding.GetBytes(request);
            using (var hmacsha1 = new HMACSHA1(keyBytes))
            {
                var Signature = hmacsha1.ComputeHash(requestBytes);
                return $"&signature={Convert.ToHexString(Signature).ToUpper()}";
            }
        }
    }
}
