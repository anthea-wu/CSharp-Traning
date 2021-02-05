using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using CSharp_Traning.Models;

namespace CSharp_Traning.Models
{
    internal partial class GeoIpServer : IGeoIpServer
    {
        private readonly HttpClient _httpClient;

        public GeoIpServer(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        public string GetCurrentIP()
        {
            var response = _httpClient.GetAsync("https://api.ipify.org?format=json").Result;
            response.EnsureSuccessStatusCode();
            var ip = JsonSerializer.Deserialize<CurrentIp>(response.Content.ReadAsStringAsync().Result).Ip;
            return ip;
        }

        public string GetCurrentCountry(string ip)
        {
            var data = new object[] { new {query=ip, fields="countryCode"} };
            var stringContent = new StringContent(JsonSerializer.Serialize(data));
            var response = _httpClient.PostAsync("http://ip-api.com/batch", stringContent).Result;
            response.EnsureSuccessStatusCode();
            var countryCod = JsonSerializer.Deserialize<List<CurrentCountryCode>>(response.Content.ReadAsStringAsync().Result)[0].CountryCode;
            return countryCod;
        }
    }
}