using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.App;

namespace WineCorp.Api
{
    public static class ApiConfiguration
    {
        public static WebApplication Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;
        }

        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddMediatRApp();
            services.AddEndpointsApiExplorer(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WineCorp API", Version = "v1" });
            });

            return services;
        }
    }
}
