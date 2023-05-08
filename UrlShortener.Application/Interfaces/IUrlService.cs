using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.Application.Interfaces
{
    public interface IUrlService
    {
        Task<UrlDto> GetUrlAsync(Guid id);
        Task<string> GetUrlByShortAsync(string shortUrl);

        Task<IEnumerable<UrlDto>> GetAllUrlsAsync();
        Task<UrlDto> AddUrlAsync(UrlDto url);
        Task DeleteUrlAsync(Guid id);

        Task UpdateUrlAsync(UrlDto url);
    }
}
