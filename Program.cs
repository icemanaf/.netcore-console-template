using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Configuration;
using Serilog;
using Serilog.Sinks.File;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TemplateApp
{ 
    class Program
    {
        static void Main(string[] args)
        {
            
            var servicecollection = new ServiceCollection();

            ConfigureServices(servicecollection);

            var serviceprovider = servicecollection.BuildServiceProvider();

            serviceprovider.GetService<App>().Run();

        }


        private static void ConfigureServices(IServiceCollection servicecollection)
        {
            servicecollection.AddSingleton<App>();

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",false).Build();

            servicecollection.Configure<CustomConfig>(configuration.GetSection("CustomConfig"));

            var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            servicecollection.AddLogging((builder) =>
            {
                builder.AddSerilog(logger, true);
            });

           
            
        }
    }
}
