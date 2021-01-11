using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint)));

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
                endpoints.MapControllerRoute("myroute", "{controller=Home}/{action=Index}/{id?}");

                /*
                // ������ http://localhost:XXXX/Shop/AdminAction ������� �� ����� Index ����������� Admin
                endpoints.MapControllerRoute(null, "Shop/AdminAction", defaults: new { controller = "Admin", action = "Index" });
                // ������ http://localhost:XXXX/Shop ������ �� ����� List ����������� Customer
                endpoints.MapControllerRoute(null, "Shop/{action=List}", defaults: new { controller = "Customer" });
                endpoints.MapControllerRoute(null, "Public/{controller}/{action}");
                */

                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id=DefaultId}");
                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id?}/{*catchall}");
                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id:range(10,20)?}");
                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id:alpha:minlength(6)?}");

                // ������� � id ��������� ������ � ������ ������������ id ������ �� ��������� �� ������ � WeekDayConstraint.cs
                //endpoints.MapControllerRoute("MyRoute", "{controller=Home}/{action=Index}/{id?}", constraints: new { id = new WeekDayConstraint() });
            });
        }
    }
}
