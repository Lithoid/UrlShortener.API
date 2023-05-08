using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Dtos;
using UrlShortener.API.Models.Requests;

namespace  UrlShortener.API.MapperProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<AddUrlRequest, UrlDto>();
        }
    }

}
