using Microsoft.Extensions.Configuration;
using RabbitCoopSimulation.Configuration.ConfiguraitonMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation
{
    public static class AppConfiguration
    {
        public static AppConfig GetConfig()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            return config.Get<AppConfig>();
        }        
    }
}
