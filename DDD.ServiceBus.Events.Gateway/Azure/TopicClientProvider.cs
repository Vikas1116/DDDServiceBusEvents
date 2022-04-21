namespace DDD.ServiceBus.Events.Gateway.Azure
{
    [ExcludeFromCodeCoverage]
    internal class TopicClientProvider : ITopicClientProvider
    {
        private readonly MessageProcessingSettings _messageProcessingSettings;

        public TopicClientProvider(IOptions<MessageProcessingSettings> messageProcessingSettings)
        {
            _messageProcessingSettings = messageProcessingSettings.Value;
        }

        public ManagementClient GetManagement()
        {
            var tokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();
            var client = new ManagementClient(_messageProcessingSettings.ServiceBusEndPoint, tokenProvider);

            return client;
        }

        public ITopicClient GetTopicClient(string topicname)
        {
            var tokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();

            return new TopicClient(_messageProcessingSettings.ServiceBusEndPoint, topicname, tokenProvider);
        }
    }
}
