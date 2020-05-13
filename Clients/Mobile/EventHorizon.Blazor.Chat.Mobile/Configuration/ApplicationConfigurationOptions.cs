namespace EventHorizon.Blazor.Chat.Mobile.Configuration
{
    public struct ApplicationConfigurationOptions
    {
        public string EnvironmentName { get; }

        public ApplicationConfigurationOptions(
            string environmentName
        )
        {
            EnvironmentName = environmentName;
        }
    }
}
