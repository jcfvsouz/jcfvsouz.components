using jcfvsouz.Components.ApplicationBuilder;
using jcfvsouz.Components.ApplicationBuilder.Extensions;
using jcfvsouz.Components.Azure.KeyVault.Option.Extensions;
using jcfvsouz.Components.Azure.KeyVault.Option.Sample.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Sample
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            var config = serviceCollection.AddConfiguration();
            serviceCollection.ConfigureOptionFromKeyVault<MsSQLSettings>(config);
            serviceCollection.ConfigureOptionFromKeyVault<MySQLSettings>(config);
        }
    }
}
