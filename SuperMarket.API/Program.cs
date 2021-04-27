using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SuperMarket.API.Domain.Persistence.Contexts;

namespace SuperMarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host =  CreateHostBuilder(args).Build();
           using (var scope = host.Services.CreateScope())
           using (var context = scope.ServiceProvider.GetService<AppDbContext>())
           {
                //se asegura que exista la base de datos
                //si no esta creada, se crea una tabla 
                context.Database.EnsureCreated();
           }
           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}