using FluentAssertions;
using FluentAssertions.Execution;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Tests.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;

namespace jcfvsouz.Components.Cloud.SecretsManager.Option.Tests.UnitTests
{
    public class SecretsManagerOptionConfiguratorTests(SecretsManagerOptionConfiguratorFixture fixture)
        : IClassFixture<SecretsManagerOptionConfiguratorFixture>
    {
        [Fact]
        public void ConfigureSecretsManagerOption_ShouldConfigureOption_GivenValidConfiguration()
        {
            //arrange
            var instance = fixture.NewInstance();

            var expectedConfigurationObject = fixture.GetMockedConfigurationClass();

            fixture.Setup_SecretsManagerClient_GetSecret_Result(
                JsonConvert.SerializeObject(expectedConfigurationObject));

            var serviceCollection = new ServiceCollection();
            var secretKey = fixture.Faker.Random.Word();

            //act
            instance.ConfigureSecretsManagerOption<SecretsManagerOptionConfiguratorFixture.ConfigurationClass>
                (serviceCollection, secretKey);

            //assert
            var provider = serviceCollection.BuildServiceProvider();
            var registeredConfigurationOption = provider
                .GetRequiredService<IOptions<SecretsManagerOptionConfiguratorFixture.ConfigurationClass>>();

            registeredConfigurationOption.Value.Should().BeEquivalentTo(expectedConfigurationObject);
        }

        [Fact]
        public void ConfigureSecretsManagerOption_ShouldCallGetSecretOnce_GivenSameSecretKey()
        {
            //arrange
            var instance = fixture.NewInstance();

            var expectedConfigurationObject = fixture.GetMockedConfigurationChildClass();

            fixture.Setup_SecretsManagerClient_GetSecret_Result(
                JsonConvert.SerializeObject(expectedConfigurationObject));

            var serviceCollection = new ServiceCollection();
            var secretKey = fixture.Faker.Random.Word();

            //act
            instance.ConfigureSecretsManagerOption<SecretsManagerOptionConfiguratorFixture.ConfigurationClass>
                (serviceCollection, secretKey);

            instance.ConfigureSecretsManagerOption<SecretsManagerOptionConfiguratorFixture.ConfigurationChildClass>
                (serviceCollection, secretKey);

            //assert
            var provider = serviceCollection.BuildServiceProvider();
            var registeredConfigurationOption = provider
                .GetRequiredService<IOptions<SecretsManagerOptionConfiguratorFixture.ConfigurationChildClass>>();

            using (new AssertionScope())
            {
                registeredConfigurationOption.Value.Should().BeEquivalentTo(expectedConfigurationObject);
                fixture.SecretsManagerClientMock!.Verify(o => o.GetSecret(It.IsAny<string>()), times: Times.Once);
            }
        }
    }
}
