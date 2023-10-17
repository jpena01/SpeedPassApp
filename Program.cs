using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace SpeedPassApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

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
                // Add services to the container
                services.AddControllersWithViews();
            }

            public static void Main(string[] args)
            {
                CreateHostBuilder(args).Build().Run();
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseKestrel(options =>
                        {
                            // Listen on specific IP and port
                            options.Listen(IPAddress.Parse("192.168.1.41"), 5000); // Port 80 for HTTP

                            // Add a binding for partsmaxinc.co
                            options.Listen(IPAddress.Parse("192.168.1.41"), 5000, listenOptions =>
                            {
                                listenOptions.UseConnectionLogging(); // Enable connection logging
                            });
                        })
                        .UseStartup<Startup>();
                    });
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

                   })
                   .UseStartup<Startup>();
        //Kestrel settings here:
    }
}
