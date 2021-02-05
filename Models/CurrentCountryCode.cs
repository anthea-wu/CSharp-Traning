using System.Text.Json.Serialization;

namespace CSharp_Traning.Models
{
    
        internal class CurrentCountryCode
        {
            [JsonPropertyName("countryCode")]
            public string CountryCode { get; set; }
        }

        
    }
