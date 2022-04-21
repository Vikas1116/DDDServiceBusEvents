namespace DDD.ServiceBus.Events.Gateway
{
    public interface IEventBus
    {
        Task Publish(string topic,IntegrationEvents.IntegrationEvent @event);
    }
}
