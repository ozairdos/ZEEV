using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Gerenciador.Servico.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseStartup<Startup>();
                    webBuilder
                        .ConfigureLogging((ctx, builder) =>
                         {
                             builder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                             builder.AddFile(o => o.RootPath = ctx.HostingEnvironment.ContentRootPath);
                         })
                        .UseStartup<Startup>();
                });
    }
}
