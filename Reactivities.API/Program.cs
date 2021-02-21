using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reactivities.Persistence;

namespace Reactivities.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();//.Run();
            using var scope=host.Services.CreateScope();
            var services=scope.ServiceProvider;

            try
            {
                var context= services.GetRequiredService<DataContext>();
                context.Database.MigrateAsync();
                await Seed.SeedData(context);
            }
            catch (System.Exception ex)
            {
                 // TODO
                 var logger=services.GetRequiredService<ILogger<Program>>();
                 logger.LogError(ex,"An error occured during the migration");
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
