using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;
using VO1BAB_HFT_20231.Endpoint.Services;

namespace VO1BAB_HFT_20231.Endpoint
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
            services.AddTransient<MyDBContext>();

            services.AddTransient<IRepository<Cars>, CarsRepository>();
            services.AddTransient<IRepository<CarBrand>, CarBrandRepository>();
            services.AddTransient<IRepository<Rents>, RentsRepository>();


            services.AddTransient<ICarLogic, CarsLogic>();
            services.AddTransient<ICarBrandLogic, CarBrandLogic>();
            services.AddTransient<IRentsLogic, RentsLogic>();
            services.AddControllers();
            services.AddCors();
            services.AddCors(x =>
            {
                x.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://127.0.0.1:5500");
                    policy.WithOrigins("http://localhost:4784");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                });
            });

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VO1BAB_HFT_20231.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VO1BAB_HFT_20231.Endpoint v1"));
            }

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });

            //app.UseCors(t => t
            //.WithOrigins("http://127.0.0.1:5500")
            //.AllowAnyHeader()
            //.AllowCredentials()
            //.AllowAnyMethod());


          

        }
    }
}
