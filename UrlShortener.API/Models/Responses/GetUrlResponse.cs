using UrlShortener.Domain.Dtos;

namespace UrlShortener.API.Models.Responses
{
    public class GetUrlResponse
    {
        public UrlDto Url { get; set; }
    }
}
