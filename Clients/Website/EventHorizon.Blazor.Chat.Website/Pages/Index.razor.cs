using System;
using System.Threading.Tasks;
using EventHorizon.Blazor.Chat.Model;

namespace EventHorizon.Blazor.Chat.Website.Pages
{
    public class IndexModel : ChatModel
    {
        public override Task OnSend()
        {
            // TODO: Focus Message box
            return Task.CompletedTask;
        }

        public override Task OnMessageRecieved(
            string rawMessage
        )
        {
            return Task.CompletedTask;
        }
    }
}
