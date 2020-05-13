using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace EventHorizon.Blazor.Chat.Mobile.Configuration
{
    public static class ApplicationConfiguration
    {
        private static IConfigurationRoot configuration;

        public static IConfigurationRoot Build(
            ApplicationConfigurationOptions options
        )
        {
            if (configuration != null)
            {
                return configuration;
            }

            var builder = new ConfigurationBuilder()
                .AddJsonStream(
                    GetFileStream(
                        "appsettings.json"
                    )
                );

            var enviornmentSettingsStream = GetFileStream(
                $"appsettings.{options.EnvironmentName}.json"
            );

            if(enviornmentSettingsStream != null)
            {
                builder.AddJsonStream(
                    enviornmentSettingsStream
                );
            }

            configuration = builder.Build();
            return configuration;
        }

        public static IConfigurationRoot Configuration
        {
            get
            {
                return configuration ?? throw new ConfigurationNotInitialized();
            }
        }

        private static Stream GetFileStream(
            string fileName
        )
        {
            //var assembly = IntrospectionExtensions.GetTypeInfo(
            //    typeof(ApplicationConfiguration)
            //).Assembly;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ApplicationConfiguration)).Assembly;
            return assembly.GetManifestResourceStream($"EventHorizon.Blazor.Chat.Mobile.{fileName}");
        }
    }
}
