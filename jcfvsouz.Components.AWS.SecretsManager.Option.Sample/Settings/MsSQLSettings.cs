using Newtonsoft.Json;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Sample.Settings
{
    public class MsSQLSettings
    {
        [JsonProperty("sqlServerConnectionString")]
        public required string ConnectionString { get; set; }
    }
}