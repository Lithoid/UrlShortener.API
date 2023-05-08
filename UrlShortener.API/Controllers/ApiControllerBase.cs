using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.API.Controllers
{
    
    public abstract class ApiControllerBase<T> : ControllerBase
    {
        protected ApiControllerBase(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected ApiControllerBase(IMapper mapper, ILogger<T> logger)
            : this(mapper)
        {
            Logger = logger;
        }

        public IMapper Mapper { get; }

        protected ILogger<T> Logger { get; }
    }
}
