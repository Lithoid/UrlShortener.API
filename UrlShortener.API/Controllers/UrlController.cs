using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.Models.Requests;
using UrlShortener.API.Models.Responses;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Dtos;

namespace UrlShortener.API.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class UrlController : ApiControllerBase<UrlController>
    {
        private readonly IUrlService urlService;

        public UrlController(IMapper mapper,
            ILogger<UrlController> logger,
            IUrlService urlService)
            : base(mapper, logger)
        {
            this.urlService = urlService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(GetAllUrlResponse), 201)]
        public async Task<IActionResult> GetAllUrls()
        {
            var urls = await urlService.GetAllUrlsAsync();


            var urlList = Mapper.Map<IEnumerable<UrlDto>>(urls);

            return Ok(urlList);

            //return new GetAllUrlResponse
            //{
            //    Urls = urlList
            //};
        }


        [HttpGet("{urlId:Guid}")]
        [ProducesResponseType(typeof(UrlDto), 201)]
        public async Task<UrlDto> GetUrl([FromRoute]Guid urlId)
        {
            var url = await urlService.GetUrlAsync(urlId);
            return url;
            //return new GetUrlResponse
            //{
            //    Url = url
            //};
        }

        [HttpPost]
        [ProducesResponseType(typeof(UrlDto), 201)]
        public async Task<IActionResult> AddUrl([FromBody] AddUrlRequest request)
        {
            var url = Mapper.Map<UrlDto>(request);
            var createdUrl = await urlService.AddUrlAsync(url);
            return Ok(createdUrl);

            //return new AddUrlResponse
            //{
            //    Url = createdUrl
            //};
        }

        [HttpDelete("{urlId:Guid}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<bool> DeleteNote([FromRoute] Guid urlId)
        {
            await urlService.DeleteUrlAsync(urlId);
            return true; 

            //return new DeleteUrlResponse
            //{
            //    IsSuccess = true
            //};
        }

        [HttpPut]
        [ProducesResponseType(typeof(UrlDto), 201)]
        public async Task<IActionResult> UpdateUrl([FromBody] UrlDto request)
        {
            var url = Mapper.Map<UrlDto>(request);
            await urlService.UpdateUrlAsync(url);
            return Ok(url);
        }


    }
}
