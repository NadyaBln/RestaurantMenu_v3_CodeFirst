using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RestaurantMenu_v3_CodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                //AutoFac  set up  (IOC container)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
