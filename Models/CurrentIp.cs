using System.Text.Json.Serialization;

namespace CSharp_Traning.Models
{
    internal class CurrentIp
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; }
    }
}