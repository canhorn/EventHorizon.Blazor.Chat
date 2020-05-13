namespace EventHorizon.Blazor.Chat.Model.Settings
{
    public class GenericChatSettings : IChatSettings
    {
        public string ServerHubUrl { get; }

        public GenericChatSettings(
            string serverUrl
        )
        {
            ServerHubUrl = serverUrl;
        }
    }
}
