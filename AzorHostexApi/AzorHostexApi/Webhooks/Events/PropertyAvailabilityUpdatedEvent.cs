using AzorHostexApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzorHostexApi.Webhooks.Events
{
    public class PropertyAvailabilityUpdatedEvent
    {
        public int PropertyId { get; set; }
        public List<Availability> Availabilities { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
