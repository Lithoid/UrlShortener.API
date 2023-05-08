namespace UrlShortener.API.Models.Requests
{
    public class GetUrlRequest
    {
        public const string Route = "{urlId}";
        public Guid UrlId { get; init; }
    }
}
