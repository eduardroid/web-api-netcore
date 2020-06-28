using AutoMapper;
using dev.eduardroid.services.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Reflection;

namespace dev.eduardroid.services
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServiceContext>( conf =>
            {
                conf.UseSqlServer(_config.GetConnectionString("DbServices"));
            });

            services.AddTransient<ServiceSeeder>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //used for view models

            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", 
                    "{controller}/{action}/{id?}",
                    new { controller= "App",  Action ="Index"});
            });
        }
    }
}
