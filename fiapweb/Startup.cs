using fiapweb.core.Contexts;
using fiapweb.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fiapweb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            //services.AddControllers();
            services.AddControllersWithViews();

            services.AddAuthentication("app")
                .AddCookie("app", 
                o =>
                {
                    o.LoginPath = "/account/index";
                    o.AccessDeniedPath = "/account/denied";
                
                });

            services.AddDataProtection()
                .SetApplicationName("fiap-web")
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\Rodolfof\Desktop"));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMeuMiddleware();

            //app.UseMiddleware<MeuMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //localhost:5001/produtos/oferta/teclados
                //endpoints.MapControllerRoute(
                //   name: "alunos",
                //   pattern: "alunos/{action=Index}/{id?}",
                //   //pattern: "{controller}/{action}/{id?}",
                //   defaults: new { controller = "Secretaria" }
                //   );

                //endpoints.MapControllerRoute(
                // name: "categoriadeprodutos",
                // pattern: "produtos/oferta/{categoria}/{id?}",
                // //pattern: "{controller}/{action}/{id?}",
                // defaults: new { controller = "Oferta", action ="Index" }
                // );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    //pattern: "{controller}/{action}/{id?}",
                    //defaults: new {controller="Home", action = "Index"}
                    );



            });


            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Boa noite o/");
            //});



            //app.Use(async (context, next) =>
            //{
            //    //logica antes
            //    await next.Invoke();
            //    //logica depois

            //});

            //app.Use(async (context, next) =>
            //{
            //    //logica antes
            //    await next.Invoke();
            //    //logica depois

            //});

            //app.Map("/admin", mapMy =>
            //{
            //    mapMy.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("admin");
            //    });
            //});

            //app.MapWhen(
            //    context => 
            //    context.Request.Query.ContainsKey("queryTeste"), 
            //    mapApp => {
            //        mapApp.Run(async context =>
            //        {
            //            await context.Response.WriteAsync("aqui tinha a querystring");
            //        }
            //    );
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Boa noite");

            //});
        }
    }

    public static class MiddlwareExtensions
    {
        public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }

    }
}