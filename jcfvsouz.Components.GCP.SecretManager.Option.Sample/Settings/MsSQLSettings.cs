using Newtonsoft.Json;

namespace jcfvsouz.Components.GCP.SecretManager.Option.Sample.Settings
{
    public class MsSQLSettings
    {
        [JsonProperty("MssqlConnectionString")]
        public required string ConnectionString { get; set; }
    }
}