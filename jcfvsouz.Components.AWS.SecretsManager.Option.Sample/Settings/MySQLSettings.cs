using Newtonsoft.Json;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Sample.Settings
{
    public class MySQLSettings
    {
        [JsonProperty("mysqlConnectionString")]
        public required string ConnectionString { get; set; }
    }
}