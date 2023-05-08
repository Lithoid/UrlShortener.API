using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain
{
    public interface IDbEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
