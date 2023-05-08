using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Interfaces;
using UrlShortener.DataContex.Generic;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Implementations
{
    public class UrlService : IUrlService
    {

        private readonly IUrlRepository urlRepository;
        private readonly IMapper mapper;

        private const string localUrl = "https://localhost:7117";

        public UrlService(
            IUrlRepository urlRepository,
            IMapper mapper)
        {
            this.urlRepository = urlRepository;
            this.mapper = mapper;
        }
        public async Task<UrlDto> GetUrlAsync(Guid id)
        {
            var urlEntitie = await urlRepository.GetItemAsync(u=>u.Id==id);
            var url = mapper.Map<UrlDto>(urlEntitie);

            return url;
        }

        public async Task<string> GetUrlByShortAsync(string shortUrl)
        {

            var fullUrl = localUrl + "/r/" + shortUrl;

            var urlEntitie = await urlRepository.GetItemAsync(u => u.ShortUrl == fullUrl);
            var url = mapper.Map<UrlDto>(urlEntitie);

            return url.OriginalUrl;
        }

        public async Task<UrlDto> AddUrlAsync(UrlDto url)
        {
            var urlEntity = mapper.Map<Url>(url);

            urlEntity.CreatedDate= DateTime.Now;
            urlEntity.OriginalUrl = url.OriginalUrl;

            var shortUrl = new UrlShortener().ShortenUrl(url.OriginalUrl);
            var fullUrl = localUrl + "/r/" + shortUrl;
            urlEntity.ShortUrl = fullUrl;


            urlEntity.UserId = Guid.NewGuid();

            var createdUrl = await urlRepository.AddItemAsync(urlEntity);
            await urlRepository.SaveChangesAsync();

            return mapper.Map<UrlDto>(createdUrl);
        }

        public async Task UpdateUrlAsync(UrlDto url)
        {
            var urlEntity = mapper.Map<Url>(url);
            await urlRepository.ChangeItemAsync(urlEntity);
            await urlRepository.SaveChangesAsync();

        }
        public async Task DeleteUrlAsync(Guid id)
        {
            await urlRepository.DeleteItemAsync(id);
            await urlRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UrlDto>> GetAllUrlsAsync()
        {
            var urlEntities = await urlRepository.GetAllItemsAsync();
            var urls = mapper.Map<IEnumerable<UrlDto>>(urlEntities);

            return urls;
        }
    }
}
