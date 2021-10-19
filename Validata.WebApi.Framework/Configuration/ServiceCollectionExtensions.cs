using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;
using Microsoft.EntityFrameworkCore;


namespace Validata.WebApi.Framework.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContextCustom(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceBoundedContextCommand>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


            });

           
        }
    }
}
