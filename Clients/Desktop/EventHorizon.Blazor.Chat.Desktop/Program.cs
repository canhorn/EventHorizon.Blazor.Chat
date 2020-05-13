namespace EventHorizon.Blazor.Chat.Desktop
{
    using WebWindows.Blazor;

    class Program
    {
        static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>(
                "Blazor Desktop", 
                "wwwroot/index.html"
            );
        }
    }
}
