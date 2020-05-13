using System.Threading.Tasks;
using EventHorizon.Blazor.Chat.Model;

namespace EventHorizon.Blazor.Chat.Desktop.Pages
{
    public class IndexModel : ChatModel
    {
        public override Task OnSend()
        {
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
