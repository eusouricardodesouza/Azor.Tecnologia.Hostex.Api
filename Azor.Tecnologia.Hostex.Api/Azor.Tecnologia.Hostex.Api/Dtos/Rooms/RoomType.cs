using Azor.Tecnologia.Hostex.Api.Dtos.Properties.Properties;
using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos.Rooms
{
    public class RoomType
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("properties")]
        public List<Property> Properties { get; set; }

        [JsonPropertyName("channels")]
        public List<object> Channels { get; set; }
    }
}
