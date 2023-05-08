using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataContex.Abstract;
using UrlShortener.Domain.Entities;

namespace UrlShortener.DataContex.Generic
{

    public interface IUrlRepository : IDbRepository<Url> { 


    }
}
