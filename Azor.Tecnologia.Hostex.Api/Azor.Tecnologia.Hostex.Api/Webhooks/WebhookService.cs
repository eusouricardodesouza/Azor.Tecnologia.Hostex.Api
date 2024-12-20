using Azor.Tecnologia.Hostex.Api.Webhooks.Events;
using Newtonsoft.Json;

namespace Azor.Tecnologia.Hostex.Api.Webhooks
{
    public class WebhookService
    {// Define delegados para os eventos
        public delegate void ReservationCreatedEventHandler(object sender, ReservationCreatedEvent args);
        public delegate void PropertyAvailabilityUpdatedEventHandler(object sender, PropertyAvailabilityUpdatedEvent args);

        // Declara os eventos
        public event ReservationCreatedEventHandler OnReservationCreated;
        public event PropertyAvailabilityUpdatedEventHandler OnPropertyAvailabilityUpdated;

        // Método para processar o webhook recebido
        public void ProcessWebhook(string eventType, string payload)
        {
            switch (eventType)
            {
                case "reservation_created":
                    var reservationEvent = JsonConvert.DeserializeObject<ReservationCreatedEvent>(payload);
                    OnReservationCreated?.Invoke(this, reservationEvent);
                    break;

                case "property_availability_updated":
                    var availabilityEvent = JsonConvert.DeserializeObject<PropertyAvailabilityUpdatedEvent>(payload);
                    OnPropertyAvailabilityUpdated?.Invoke(this, availabilityEvent);
                    break;

                default:
                    // Tratar outros eventos ou eventos desconhecidos
                    break;
            }
        }
    }
}
