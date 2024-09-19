using jcfvsouz.Components.ApplicationBuilder;
using jcfvsouz.Components.ApplicationBuilder.Extensions;
using jcfvsouz.Components.GCP.SecretManager.Option.Extensions;
using jcfvsouz.Components.GCP.SecretManager.Option.Sample.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.GCP.SecretManager.Option.Sample
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            var config = serviceCollection.AddConfiguration();
            serviceCollection.ConfigureOptionFromSecretManager<MsSQLSettings>(config);
            serviceCollection.ConfigureOptionFromSecretManager<MySQLSettings>(config);
        }
    }
}
