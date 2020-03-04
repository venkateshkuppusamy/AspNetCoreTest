using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            /* User specified configuration for web host */
            /*
                var host = new WebHostBuilder()
                .UseKestrel()
                .UseWebRoot("StaticFiles")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
                return host;
            */
            // CreateDefaultBuilder method provides default standard Host eg use Kesterl server, setting the content path, default port etc.
            return WebHost.CreateDefaultBuilder(args).UseWebRoot("StaticFiles")
              .UseStartup<Startup>();
            
        }
    }
}
