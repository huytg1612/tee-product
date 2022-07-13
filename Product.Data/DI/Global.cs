using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Data.Models;
using Product.Data.Repositories;
using Product.Data.Services;
using Product.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.DI
{
    public class Global
    {
        public static void ServiceIoC(IServiceCollection services)
        {
            services.AddScoped<DbContext, ProductDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<CategoryServices>();
            services.AddScoped<ProductService>();
        }
    }
}
