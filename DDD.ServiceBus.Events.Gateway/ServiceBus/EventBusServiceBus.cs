namespace DDD.ServiceBus.Events.Gateway.ServiceBus
{
    [ExcludeFromCodeCoverage]
    internal class EventBusServiceBus : IEventBus
    {
        private ITopicClientProvider _clientProvider;
        private const string INTEGRATION_EVENT_SUFIX = "IntegrationEvent";

        public EventBusServiceBus(ITopicClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public async Task Publish(string topic, IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name.Replace(INTEGRATION_EVENT_SUFIX, "");
            var jsonMessage = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var message = new Message
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = body,
                Label = eventName,
            };

            var topicClient = _clientProvider.GetTopicClient(topic);

            await topicClient.SendAsync(message);
        }
    }
}
