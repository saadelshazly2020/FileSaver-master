using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelFileReader.Core.Interfaces;
using ExcelFileReader.Core.Services;
using ExcelFileReader.Core.Services.Interfaces;
using ExcelFileReader.Infrastructure;
using ExcelFileReader.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace ExcelFileReader
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container(DI service)
        public void ConfigureServices(IServiceCollection services)
        {
            //register service and repo in DI 
            //AddTransient:  each time the service is requested, a new instance is created.
            //AddSingleton:  one instance for all requested.  
            //AddScopped:  one instance per web request.
            services.AddTransient<IFileSaverRepository, FileSaverRepository>();
            services.AddTransient<IFileSaverService, FileSaverService>();
            //inject the required DBContext in the Service IoC container
            services.AddDbContext<FileContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FileDB"));
            });
           //this adds the MVC Controller services that are common to both Web API and MVC, but also adds the services required for rendering Razor views.
           services.AddControllersWithViews();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //manage logging 
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                /* when the browser receives HSTS policy:
                   1. it stores configuration for the domain that prevents sending any communication over HTTP. The browser forces all communication over HTTPS.
                   2. prevents the user from using untrusted or invalid certificates. The browser disables prompts that allow a user to temporarily trust such a certificate. 
                   */
                app.UseHsts();
            }
            //The HTTPS Redirection Middleware(UseHttpsRedirection) to redirect all HTTP requests to HTTPS
            app.UseHttpsRedirection();
            //serve static files such as images, js, css, etc...
            app.UseStaticFiles();
            //Matches request to an endpoint.

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            // use authorization middleware
            //app.UseAuthorization();
            app.UseAuthorization();
            //Execute the matched endpoint.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
