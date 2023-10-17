using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.Extensions.Hosting;

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
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                   .UseKestrel(options =>
                   {
                       // Listen on specific IP and port
                       options.Listen(IPAddress.Parse("192.168.1.41"), 5000); // Port 80 for HTTP

                       // Add a binding for partsmaxinc.co
                       options.Listen(IPAddress.Parse("192.168.1.41"), 5000, listenOptions =>
                       {
                           listenOptions.UseConnectionLogging(); // Enable connection logging
                       });
                   })
                   .UseStartup<IStartup>();
        //Kestrel settings here:
    }
    }
