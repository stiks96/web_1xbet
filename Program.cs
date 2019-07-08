using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Web1xbet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("DefaultConnection", "Server=localhost;Port=5432;User ID=postgres;Password=admin;Database=Web1xbet;")
                .UseKestrel()
                .UseStartup<Startup>();
    }
}
