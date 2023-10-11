using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SpeedPassApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

                        services.AddRazorPages();
                    });

                    webBuilder.Configure((app) =>
                    {
                        app.UseRouting();

                        app.UseStaticFiles(); // Add this line to serve static files from the wwwroot folder
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapRazorPages();
                        });
                    });
                });
        
    }
}