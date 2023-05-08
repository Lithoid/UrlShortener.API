using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Dtos
{
    public class UrlDto
    {

        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
    }
}
