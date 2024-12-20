using System.Text.Json.Serialization;

namespace Azor.Tecnologia.Hostex.Api.Dtos.Rooms
{
    public class RoomResponse
    {
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }

        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("error_msg")]
        public string ErrorMsg { get; set; }

        [JsonPropertyName("data")]
        public RoomData Data { get; set; }
    }
}
