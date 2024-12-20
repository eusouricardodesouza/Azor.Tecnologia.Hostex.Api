namespace Azor.Tecnologia.Hostex.Api.Webhooks.Events
{
    public class ReservationCreatedEvent
    {
        public string ReservationCode { get; set; }
        public string StayCode { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
