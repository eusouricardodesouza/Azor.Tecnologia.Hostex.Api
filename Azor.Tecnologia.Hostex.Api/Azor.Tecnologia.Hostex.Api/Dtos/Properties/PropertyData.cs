using Azor.Tecnologia.Hostex.Api.Dtos.Properties.Properties;
using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos.Properties
{
    public class PropertyData
    {
        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
