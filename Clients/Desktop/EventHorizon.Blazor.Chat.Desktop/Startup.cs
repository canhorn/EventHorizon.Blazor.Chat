using EventHorizon.Blazor.Chat.Model.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebWindows.Blazor;

namespace EventHorizon.Blazor.Chat.Desktop
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IChatSettings>(
                builder => new GenericChatSettings(
                    builder.GetRequiredService<IConfiguration>()["ServerUrl"]
                )
            );
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
