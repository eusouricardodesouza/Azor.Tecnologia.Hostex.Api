namespace AzorHostexApi.Clients
{
    public class BaseApiClient
    {
        public dynamic Error(Exception exception)
        {
            return new { error = exception.Message };
        }
    }
}
