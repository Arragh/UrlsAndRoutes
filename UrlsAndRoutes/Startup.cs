using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                //app.UseMvc();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                /*
                // набрав http://localhost:XXXX/Shop/AdminAction попадем на метод Index контроллера Admin
                endpoints.MapControllerRoute(null, "Shop/AdminAction", defaults: new { controller = "Admin", action = "Index" });
                // набрав http://localhost:XXXX/Shop попадём на метод List контроллера Customer
                endpoints.MapControllerRoute(null, "Shop/{action=List}", defaults: new { controller = "Customer" });
                endpoints.MapControllerRoute(null, "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(null, "Public/{controller}/{action}");
                */

                endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id=DefaultId}");
                endpoints.MapControllerRoute("TestRoute", "{controller=Home}/{action=Index}/{identify=xaxaxa}");
            });
        }
    }
}
