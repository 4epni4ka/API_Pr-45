using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Леготкин
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = "Руководство для использования запросов",

                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",

                    Title = "Руководство для использования запросов",

                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                c.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",

                    Title = "Руководство для использования запросов",

                    Description = "Полное руководство для использования запросов находящихся в проекте"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "API_Леготкин.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Запросы GET");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Запросы POST");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "Запросы PUT");
            });
        }
    }
}