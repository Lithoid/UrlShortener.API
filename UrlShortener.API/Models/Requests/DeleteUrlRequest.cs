namespace UrlShortener.API.Models.Requests
{
    public class DeleteUrlRequest
    {
        public const string Route = "{urlId}";
        public Guid UrlId { get; init; }
    }
}
