using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace CSharp_Traning.Models
{
    internal class GeoIpServer : IGeoIpServer
    {
        private readonly HttpClient _httpClient;

        public GeoIpServer(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
        }

        private string GetCurrentIp()
        {
            var response = _httpClient.GetAsync("https://api.ipify.org?format=json").Result;
            response.EnsureSuccessStatusCode();
            var ip = JsonSerializer.Deserialize<CurrentIp>(response.Content.ReadAsStringAsync().Result).Ip;
            return ip;
        }

        private string GetCurrentCountry(string ip)
        {
            var data = new object[] { new {query=ip, fields="countryCode"} };
            var stringContent = new StringContent(JsonSerializer.Serialize(data));
            var response = _httpClient.PostAsync("http://ip-api.com/batch", stringContent).Result;
            response.EnsureSuccessStatusCode();
            var countryCod = JsonSerializer.Deserialize<List<CurrentCountryCode>>(response.Content.ReadAsStringAsync().Result)[0].CountryCode;
            return countryCod;
        }
        
        public CurrentPlace GetCurrentPlace()
        {
            var place = new CurrentPlace();
            var ip = GetCurrentIp();
            var countryCode = GetCurrentCountry(ip);
            place.Ip = ip;
            place.CountryCode = countryCode;
            return place;
        }
    }
}