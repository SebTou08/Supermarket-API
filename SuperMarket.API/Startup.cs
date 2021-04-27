using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SuperMarket.API.Domain.Persistence.Contexts;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Persistence.Repositories;
using SuperMarket.API.Services;

namespace SuperMarket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //!dbContect configuration
            //TODO: do this on your proyect
            

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            // ! Dependency Injection Configuration 
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IProductTagRepository, ProductTagRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProductTagServices, ProductTagService>();
            
            //!Endpoint case conventions Configurations

            //los endpoints deben estar totalmente en minuscula. 
            services.AddRouting(options => options.LowercaseUrls = true);
            
            //! Automapper initialization 
            
            services.AddAutoMapper(typeof(Startup));
            
            //! FINISHED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SuperMarket.API", Version = "v1"});
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperMarket.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}