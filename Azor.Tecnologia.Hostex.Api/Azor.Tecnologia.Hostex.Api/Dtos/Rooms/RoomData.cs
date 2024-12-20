using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos.Rooms
{
    public class RoomData
    {
        [JsonPropertyName("room_types")]
        public List<RoomType> RoomTypes { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
