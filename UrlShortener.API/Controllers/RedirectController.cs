using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.API.Controllers
{

    [Route("r")]
    public class RedirectController : ApiControllerBase<UrlController>
    {
        private readonly IUrlService urlService;

        public RedirectController(IMapper mapper,
            ILogger<UrlController> logger,
            IUrlService urlService)
            : base(mapper, logger)
        {
            this.urlService = urlService;
        }


        [HttpGet("{shortUrl}")]
        [ProducesResponseType(typeof(UrlDto), 201)]
        public async Task<IActionResult> GetUrl(string shortUrl)
        {
            var url = await urlService.GetUrlByShortAsync(shortUrl);
            return new RedirectResult(url);
            //return new GetUrlResponse
            //{
            //    Url = url
            //};
        }
    }
}
