using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Entities;
using AutoMapper;

namespace UrlShortener.DataContex.MapperProfiles
{
    public class AppProfiles : Profile
    {

        public AppProfiles()
        {
            CreateMap<Url, UrlDto>().ReverseMap();
           
        }
    }
}
