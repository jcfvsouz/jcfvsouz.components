using Newtonsoft.Json;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Sample.Settings
{
    public class MsSQLSettings
    {
        [JsonProperty("MssqlConnectionString")]
        public required string ConnectionString { get; set; }
    }
}