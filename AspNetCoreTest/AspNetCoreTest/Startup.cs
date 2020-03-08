using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTest.ConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCoreTest
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
            services.AddResponseCaching();
            services.AddMvc();// .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string str = Configuration.GetSection("MyAppSettings:Setting").Value; // accessing value from appsetting.json
            services.Configure<MyAppSettings>(Configuration.GetSection("MyAppSettings")); //loading MyAppSettings section it a class as a service.

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // give the and error stack trace, query paramaters, cookies and headers.
            }
            else
            {
                //app.UseExceptionHandler("/api/Error");// redirect to api/Error GET request which send 500 error incase of unhandled exception.
                app.UseHsts();
            }
            app.UseStatusCodePages();   // return status code as pages for 4XX and 5XX error with no body.
            app.UseHttpsRedirection();  // middle ware to make http calls as https
            app.UseStaticFiles();       // middle ware to access static files

            app.UseResponseCaching();
            app.
            /* middle ware to access static files with custom changes*/
            /*app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            });
            */
            app.UseMvc();               //middle ware which include mvc based routing.
        }
    }

}
