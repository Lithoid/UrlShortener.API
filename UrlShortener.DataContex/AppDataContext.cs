using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace UrlShortener.DataContex
{
    public class AppDataContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Url> Urls { get; set; }
        public AppDataContext(DbContextOptions<AppDataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Url>()
                .HasIndex(u => u.OriginalUrl)
                .IsUnique();



            base.OnModelCreating(modelBuilder);


        }
    }
}
