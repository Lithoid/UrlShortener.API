using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Entities
{
    [Table("Urls")]
    public class Url:DbEntity
    {

       
        [Column("OriginalUrl")]
        [MaxLength(100)]
        public string OriginalUrl { get; set; }
        [Column("ShortUrl")]
        public string ShortUrl { get; set; }
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [Column("UserId")]
        public Guid UserId { get; set; }
     

    }
}
