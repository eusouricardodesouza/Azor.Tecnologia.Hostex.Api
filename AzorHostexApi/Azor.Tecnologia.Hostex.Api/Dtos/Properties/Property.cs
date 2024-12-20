using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos.Properties.Properties
{
    public class Property
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("channels")]
        public List<Channel> Channels { get; set; }

        [JsonPropertyName("cover")]
        public object Cover { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
    }
}
