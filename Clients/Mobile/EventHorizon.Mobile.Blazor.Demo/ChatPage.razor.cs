using System.Threading.Tasks;
using EventHorizon.Blazor.Chat.Model;
using Microsoft.MobileBlazorBindings.Elements;
using XF = Xamarin.Forms;

namespace EventHorizon.Blazor.Chat.Mobile
{
    public class ChatPageModel : ChatModel
    {
        protected Entry messageInputEntry;
        protected ScrollView ScrollView;

        public override async Task OnSend()
        {
            messageInputEntry.NativeControl.Focus();
        }

        public override Task OnMessageRecieved(
            string rawMessage
        )
        {
            XF.Device.BeginInvokeOnMainThread(async () =>
            {
                // Scroll to the end of the view
                var scrollViewCasted = (ScrollView.NativeControl as XF.ScrollView);
                await scrollViewCasted.ScrollToAsync(
                    0,
                    scrollViewCasted.Height,
                    true
                );
            });
            return Task.CompletedTask;
        }
    }
}
