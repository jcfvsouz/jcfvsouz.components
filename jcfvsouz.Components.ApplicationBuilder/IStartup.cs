using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.ApplicationBuilder
{
    public interface IStartup
    {
        public void ConfigureServices(IServiceCollection serviceCollection);
    }
}