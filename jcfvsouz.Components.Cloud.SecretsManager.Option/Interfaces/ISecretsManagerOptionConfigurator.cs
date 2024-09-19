using Microsoft.Extensions.DependencyInjection;

namespace jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces
{
    public interface ISecretsManagerOptionConfigurator
    {
        void ConfigureSecretsManagerOption<T>(IServiceCollection serviceCollection,
            string secretKey) where T : class;
    }
}