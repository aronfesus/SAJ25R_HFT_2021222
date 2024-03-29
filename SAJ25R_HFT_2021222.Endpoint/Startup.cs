using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SAJ25R_HFT_2021222.Endpoint.Services;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Repository.DbContextFolder;
using SAJ25R_HFT_2021222.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Endpoint
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

            services.AddControllers();


            services.AddTransient<IGunRepository, GunRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IRetailerRepository, RetailerRepositroy>();
            services.AddTransient<IGunLogic, GunLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();
            services.AddTransient<IRetailerLogic, RetailerLogic>();
            services.AddTransient<GunDbContext, GunDbContext>();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAJ25R_HFT_2021222.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAJ25R_HFT_2021222.Endpoint v1"));
            }

            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:48416"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
