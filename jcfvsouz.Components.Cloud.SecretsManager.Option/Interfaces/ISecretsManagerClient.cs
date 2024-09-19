namespace jcfvsouz.Components.Cloud.SecretsManager.Option.Interfaces
{
    public interface ISecretsManagerClient
    {
        public string GetSecret(string secretKey);
    }
}
