using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO1BAB_HFT_202231.Logic;
using VO1BAB_HFT_202231.Models;
using VO1BAB_HFT_202231.Repository;

namespace VO1BAB_HFT_202231.Endpoint
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MyDBContext>();

            services.AddTransient<IRepository<Cars>,CarsRepository>();
            services.AddTransient<IRepository<CarBrand>,CarBrandRepository>();
            services.AddTransient<IRepository<Rents>, RentsRepository>();


            services.AddTransient<ICarLogic, CarsLogic>();
            services.AddTransient<ICarBrandLogic, CarBrandLogic>();
            services.AddTransient<IRentsLogic, RentsLogic>();

            services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VO1BAB_UMHFT", Version = "v1" });
            //});


        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
