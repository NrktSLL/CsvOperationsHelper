using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CsvOperationsHelper.DependencyResolvers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CsvOperationsHelper
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(Configure)
                .UseSerilog()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(ConfigureDelegate);

        private static void Configure(IWebHostBuilder webBuilder) => webBuilder.UseStartup<Startup>();
        private static void ConfigureDelegate(ContainerBuilder builder) => builder.RegisterModule(new AutofacBussinessModule());
    }
}
