using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using CsvOperationsHelper.Mapping.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CsvOperationsHelper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Mapper());

            services.AddSwaggerGen(SwaggerSetupAction);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "CSV Operations Helper"));
        }

        private static void SwaggerSetupAction(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "CSV Operations Helper API", Version = "v1", Description = "Thanks For https://joshclose.github.io/CsvHelper/" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            options.IncludeXmlComments(xmlPath);
        }

        private static IMapper Mapper()
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            return mappingConfig.CreateMapper();
        }
    }
}
