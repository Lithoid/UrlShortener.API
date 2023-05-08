using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataContex.Abstract;
using UrlShortener.DataContex.Generic;
using UrlShortener.Domain.Entities;

namespace UrlShortener.DataContex.Repositories
{
    public class UrlRepository : DbRepository<Url>, IUrlRepository
    {
        public UrlRepository(AppDataContext context) : base(context)
        {
        }
    }
}
