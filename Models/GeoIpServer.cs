using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using CSharp_Traning.Models;

namespace CSharp_Traning.Models
{
    internal partial class GeoIpServer : IGeoIpServer
    {
        public string GetCurrentIP()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://api.ipify.org?format=json").Result;
            response.EnsureSuccessStatusCode();
            var ip = JsonSerializer.Deserialize<CurrentIp>(response.Content.ReadAsStringAsync().Result).Ip;
            return ip;
        }

        public string GetCurrentCountry(string ip)
        {
            var httpClient = new HttpClient();
            var data = new object[] { new {query=ip, fields="countryCode"} };
            var stringContent = new StringContent(JsonSerializer.Serialize(data));
            var response = httpClient.PostAsync("http://ip-api.com/batch", stringContent).Result;
            response.EnsureSuccessStatusCode();
            var countryCod = JsonSerializer.Deserialize<List<CurrentCountryCode>>(response.Content.ReadAsStringAsync().Result)[0].CountryCode;
            return countryCod;
        }
    }
}