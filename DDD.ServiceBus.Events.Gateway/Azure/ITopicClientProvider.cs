namespace DDD.ServiceBus.Events.Gateway.Azure
{
    public interface ITopicClientProvider
    {
        [ExcludeFromCodeCoverage]
        ITopicClient GetTopicClient(string topicname);
        [ExcludeFromCodeCoverage]
        ManagementClient GetManagement();
    }
}
