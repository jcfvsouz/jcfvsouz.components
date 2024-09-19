using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Client
{
    public class SecretManagerClient(string awsRegion,
        string versionStage = "AWSCURRENT") : ISecretsManagerClient
    {

        public string GetSecret(string secretKey)
        {
            var endpoint = RegionEndpoint.GetBySystemName(awsRegion);
            var client = new AmazonSecretsManagerClient(endpoint);

            var request = new GetSecretValueRequest
            {
                SecretId = secretKey,
                VersionStage = versionStage,
            };

            return client.GetSecretValueAsync(request)?.Result?.SecretString ?? string.Empty;
        }
    }
}