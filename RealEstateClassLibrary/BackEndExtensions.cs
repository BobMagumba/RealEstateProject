using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateClassLibrary.BLL;
using RealEstateClassLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary
{
    public static class BackEndExtensions
    {
        public static void AddBackendDependencies(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<RealEstateContext>(options);

            services.AddTransient<IRealEstateServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<RealEstateContext>();

                return new RealEstateServices(context);
            });
            ;
        }

    }
}
