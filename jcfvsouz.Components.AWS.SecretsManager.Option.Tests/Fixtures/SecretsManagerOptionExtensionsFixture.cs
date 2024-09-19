using AutoFixture;
using Bogus;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Configurator;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces;
using Moq;

namespace jcfvsouz.Components.Cloud.SecretsManager.Option.Tests.Fixtures
{
    public class SecretsManagerOptionConfiguratorFixture
    {
        public Faker Faker => new();
        public ConfigurationClass GetMockedConfigurationClass() => new Fixture().Create<ConfigurationClass>();
        public ConfigurationChildClass GetMockedConfigurationChildClass() => new Fixture().Create<ConfigurationChildClass>();
        public Mock<ISecretsManagerClient>? SecretsManagerClientMock { get; set; }

        public ISecretsManagerOptionConfigurator NewInstance()
        {
            InitializeMocks();
            return new SecretsManagerOptionConfigurator(SecretsManagerClientMock!.Object);
        }

        private void InitializeMocks()
        {
            SecretsManagerClientMock = new();
        }

        internal void Setup_SecretsManagerClient_GetSecret_Result(string expectedSecretValue)
        {
            SecretsManagerClientMock?.Setup(o => o.GetSecret(It.IsAny<string>()))?
                .Returns(expectedSecretValue);
        }

        public class ConfigurationClass
        {
            public string? StringConfigurationProperty { get; set; }
            public int IntegerConfigurationProperty { get; set; }
            public string[]? StringArrayConfigurationProperty { get; set; }
        }

        public class ConfigurationChildClass : ConfigurationClass
        {
            public string? StringConfigurationChildProperty { get; set; }
            public int IntegerConfigurationChildProperty { get; set; }
            public string[]? StringArrayConfigurationChildProperty { get; set; }
        }
    }
}
