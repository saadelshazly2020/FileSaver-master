using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryServicePatternDemo.Core;
using RepositoryServicePatternDemo.Core.Repositories;
using RepositoryServicePatternDemo.Core.Repositories.Interfaces;
using RepositoryServicePatternDemo.Core.Services;
using RepositoryServicePatternDemo.Core.Services.Interfaces;

namespace RepositoryServicePatternDemo
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
            services.AddTransient<IFileSaverRepository, FileSaverRepository>();
            services.AddTransient<IFileSaverService, FileSaverService>();
            //inject the required DBContext in the Service IoC container
            services.AddDbContext<FileContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FileDB"));
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                //app.UseHsts();
            }
            //The HTTPS Redirection Middleware(UseHttpsRedirection) to redirect all HTTP requests to HTTPS
            //app.UseHttpsRedirection();
            //serve static files such as images, js, css, etc...
            app.UseStaticFiles();
            app.UseRouting();
            // use authorization middleware
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
