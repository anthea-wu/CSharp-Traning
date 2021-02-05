using System.Text.Json.Serialization;

namespace CSharp_Traning.Models
{
    internal partial class GeoIpServer
    {
        internal class CurrentCountryCode
        {
            [JsonPropertyName("countryCode")]
            public string CountryCode { get; set; }
        }
    }
}