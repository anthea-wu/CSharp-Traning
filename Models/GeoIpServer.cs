using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharp_Traning.Models;

namespace CSharp_Traning.Models
{
    internal class GeoIpServer
    {
        public static string GetCurrentIP()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://api.ipify.org?format=json").Result;
            response.EnsureSuccessStatusCode();
            var ip = JsonSerializer.Deserialize<CurrentIp>(response.Content.ReadAsByteArrayAsync().Result).Ip;
            return ip;
        }
    }
}