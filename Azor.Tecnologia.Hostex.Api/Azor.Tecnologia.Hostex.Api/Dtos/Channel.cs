using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos
{
    public class Channel
    {
        [JsonPropertyName("channel_type")]
        public string ChannelType { get; set; }

        [JsonPropertyName("listing_id")]
        public string ListingId { get; set; }
    }
}
