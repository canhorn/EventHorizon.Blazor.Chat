using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventHorizon.Blazor.Chat.Model.Settings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace EventHorizon.Blazor.Chat.Model
{
    public abstract class ChatModel : ComponentBase
    {
        [Inject]
        public IChatSettings Settings { get; set; }

        private HubConnection hubConnection;
        protected List<string> messages = new List<string>();
        protected string userInput;
        protected string messageInput;
        protected string ErrorMessage = null;

        public abstract Task OnSend();
        public abstract Task OnMessageRecieved(string rawMessage);

        protected override async Task OnInitializedAsync()
        {
            try
            {
                hubConnection = new HubConnectionBuilder()
                    //.WithUrl("http://ada727f1.ngrok.io/chatHub")
                    .WithUrl(
                        Settings.ServerHubUrl
                    ).Build();

                hubConnection.On("ReceiveMessage", (Action<string, string>)((user, message) =>
                {
                    var userMessage = $"{user}: {message}";
                    messages.Add(userMessage);
                    OnMessageRecieved(message).GetAwaiter().GetResult();
                    StateHasChanged();
                }));

                await hubConnection.StartAsync();
                ErrorMessage = null;
                messages.Add($"Connected to: {Settings.ServerHubUrl}");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Failed to Connection";
            }
        }

        protected async Task HandleRetryConnection()
        {
            ErrorMessage = "Connecting...";
            await OnInitializedAsync();
        }

        public async Task Send()
        {
            if (string.IsNullOrEmpty(messageInput))
            {
                return;
            }
            await hubConnection.SendAsync("SendMessage", userInput, messageInput);
            messageInput = "";
            await OnSend();
        }

        public bool IsConnected =>
            hubConnection?.State == HubConnectionState.Connected;

    }
}
