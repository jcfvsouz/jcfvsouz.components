using jcfvsouz.Components.ApplicationBuilder;
using jcfvsouz.Components.ApplicationBuilder.Extensions;
using jcfvsouz.Components.AWS.SecretsManager.Option.Extensions;
using jcfvsouz.Components.AWS.SecretsManager.Option.Sample.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Sample
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = serviceCollection.AddConfiguration();
            serviceCollection.ConfigureOptionFromSecretsManager<MsSQLSettings>(configuration);
            serviceCollection.ConfigureOptionFromSecretsManager<MySQLSettings>(configuration);
        }
    }
}
