using System.Collections.Generic;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.API.Models.Responses
{
    public class GetAllUrlResponse
    {
        public IEnumerable<UrlDto> Urls { get; set; }
    }
}
