
using Azor.Tecnologia.Hostex.Api.Dtos.Properties;
using Azor.Tecnologia.Hostex.Api.Dtos.Rooms;

namespace Azor.Tecnologia.Hostex.Api.Clients
{
    public class HostexApiClient : BaseApiClient
    {
        public HostexApiClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {
        }

        public async Task<PropertyResponse> GetProperties(int offset = 0, int limit = 20)
        {
            try
            {
                var properties = await GetAsync<PropertyResponse>($"properties?offset={offset}&limit={limit}");
                return properties;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Tipos de Quartos
        public async Task<RoomResponse> GetRoomTypes(int offset = 0, int limit = 20)
        {
            try
            {
                var roomTypes = await GetAsync<RoomResponse>($"room_types?offset={offset}&limit={limit}");
                return roomTypes;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Reservas
        public async Task<dynamic> GetReservations()
        {
            try
            {
                var reservations = await GetAsync<object>("reservations");
                return reservations;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> CreateReservation(object reservationData)
        {
            try
            {
                var response = await PostAsync<object>("reservations", reservationData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> CancelReservation(string id)
        {
            try
            {
                // Endpoint esperado para cancelar uma reserva.
                var response = await PostAsync<object>($"reservations/{id}/cancel", new { });
                return new { message = "Reserva cancelada com sucesso.", data = response };
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Disponibilidades
        public async Task<dynamic> GetAvailabilities(string propertyIds, DateTime startDate, DateTime endDate)
        {
            try
            {
                var availabilities = await GetAsync<object>($"availabilities?property_ids={propertyIds}&start_date={startDate}&end_date={endDate}");
                return availabilities;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> UpdateAvailabilities(object availabilityData)
        {
            try
            {
                var response = await PostAsync<object>("availabilities", availabilityData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Calendário de Listagens
        public async Task<dynamic> GetListingCalendars(object calendarRequest)
        {
            try
            {
                var calendars = await PostAsync<object>("listings/calendar", calendarRequest);
                return calendars;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex); 
            }
        }

        public async Task<dynamic> UpdateListingInventories(object inventoryData)
        {
            try
            {
                var response = await PostAsync<object>("listings/inventories", inventoryData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> UpdateListingPrices(object priceData)
        {
            try
            {
                var response = await PostAsync<object>("listings/prices", priceData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> UpdateListingRestrictions(object restrictionData)
        {
            try
            {
                var response = await PostAsync<object>("listings/restrictions", restrictionData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Mensagens
        public async Task<dynamic> GetConversations(int offset = 0, int limit = 20)
        {
            try
            {
                var conversations = await GetAsync<object>($"conversations?offset={offset}&limit={limit}");
                return conversations;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> GetConversationDetails(string conversationId)
        {
            try
            {
                var conversationDetails = await GetAsync<object>($"conversations/{conversationId}");
                return conversationDetails;
            }
            catch (HttpRequestException ex)
            {
                return new { error = ex.Message };
            }
        }

        public async Task<dynamic> SendMessage(object messageData)
        {
            try
            {
                var response = await PostAsync<object>("conversations", messageData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        // Avaliações
        public async Task<dynamic> GetReviews(int offset = 0, int limit = 20,
                                                    string reservationCode = "",
                                                    int propertyId = 0,
                                                    string reviewStatus = "",
                                                    DateTime? startCheckOutDate = null,
                                                    DateTime? endCheckOutDate = null)
        {
            try
            {
                var url = $"reviews?offset={offset}&limit={limit}";
                if (!string.IsNullOrEmpty(reservationCode))
                {
                    url += $"&reservation_code={reservationCode}";
                }

                if (propertyId > 0)
                {
                    url += $"&property_id={propertyId}";
                }

                if (!string.IsNullOrEmpty(reviewStatus))
                {
                    url += $"&review_status={reviewStatus}";
                }

                if (startCheckOutDate.HasValue && startCheckOutDate > DateTime.MinValue)
                {
                    url += $"&start_check_out_date={startCheckOutDate}";
                }

                if (startCheckOutDate.HasValue && startCheckOutDate > DateTime.MinValue)
                {
                    url += $"&end_check_out_date={reservationCode}";
                }

                var reviews = await GetAsync<object>(url);
                return reviews;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

        public async Task<dynamic> CreateReview(object reviewData)
        {
            try
            {
                var response = await PostAsync<object>("reviews", reviewData);
                return response;
            }
            catch (HttpRequestException ex)
            {
                return Error(ex);
            }
        }

    }
}
