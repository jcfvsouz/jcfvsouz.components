using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.ApplicationBuilder
{
    public class ApplicationBuilder<T> where T : class
    {
        private readonly IServiceCollection serviceCollection;

        public ApplicationBuilder()
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<T>();
        }

        public ApplicationBuilder<T> WithStartup<TStartup>() where TStartup : IStartup, new()
        {
            new TStartup().ConfigureServices(serviceCollection);
            return this;
        }

        public T Build()
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetRequiredService<T>();
        }
    }
}
