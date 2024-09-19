using Google.Cloud.SecretManager.V1;
using jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces;

namespace jcfvsouz.Components.GCP.SecretManager.Option.Client
{
    public class SecretManagerClient(string projectId, string secretVersionId)
        : ISecretsManagerClient
    {
        public string GetSecret(string secretKey)
        {
            var client = SecretManagerServiceClient.Create();

            var secretVersionName = new SecretVersionName(projectId, secretKey, secretVersionId);

            var result = client.AccessSecretVersion(secretVersionName);

            return result.Payload.Data.ToStringUtf8();
        }
    }
}
