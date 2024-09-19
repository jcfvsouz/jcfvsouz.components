using Newtonsoft.Json;

namespace jcfvsouz.Components.GCP.SecretManager.Option.Sample.Settings
{
    public class MySQLSettings
    {
        [JsonProperty("MysqlConnectionString")]
        public required string ConnectionString { get; set; }
    }
}