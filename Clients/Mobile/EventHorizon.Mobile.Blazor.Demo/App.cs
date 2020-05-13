using System;
using Microsoft.MobileBlazorBindings;
using Microsoft.Extensions.Hosting;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using EventHorizon.Blazor.Chat.Model.Settings;
using Microsoft.Extensions.Configuration;
using EventHorizon.Blazor.Chat.Mobile.Configuration;

namespace EventHorizon.Blazor.Chat.Mobile
{
    public class App : Application
    {
        public App()
        {
            var host = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    ApplicationConfiguration.Build(
                        new ApplicationConfigurationOptions(
#if DEBUG
                                    "Development"
#else
                                    "Production"
#endif
                        )
                    );
                    Console.WriteLine("ServerUrl Configuration: " + ApplicationConfiguration.Configuration["ServerUrl"]);
                    // Register app-specific services
                    services.AddSingleton<IChatSettings>(
                        new GenericChatSettings(
                            ApplicationConfiguration.Configuration["ServerUrl"]
                        //"http://1dd1c1c3.ngrok.io/chatHub"
                        )
                    );

                })
                .Build();

            host.AddComponent<ChatPage>(parent: this);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
