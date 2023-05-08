
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.DataContex.Generic;
using UrlShortener.DataContex.Repositories;

namespace UrlShortener.DataContex
{
    public static class DependencyInjection
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DataConnection")));

            services.AddScoped<IUrlRepository, UrlRepository>();

        }
        public static void AddAspIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDataContext>()
                .AddDefaultTokenProviders();

        }
       
    }
}
