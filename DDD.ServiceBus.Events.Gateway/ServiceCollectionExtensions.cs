namespace DDD.ServiceBus.Events.Gateway
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGateway(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton<ITopicClientProvider, TopicClientProvider>()
                .AddScoped<IEventBus, EventBusServiceBus>();
        }
    }
}
