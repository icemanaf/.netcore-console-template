using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TemplateApp
{
    public class App
    {
        private readonly ILogger _logger;

        private readonly CustomConfig _config;

        public App(ILogger<App> logger,IOptions<CustomConfig> config)
        {
            _logger = logger;

            _config = config.Value;
        }

        public void Run()
        {

            _logger.LogInformation("test");

            _logger.LogError("error");

            _logger.LogWarning("warning");

            Console.ReadKey();
        }

    }
}
