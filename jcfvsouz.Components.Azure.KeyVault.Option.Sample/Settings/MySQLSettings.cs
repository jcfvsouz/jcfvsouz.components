using Newtonsoft.Json;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Sample.Settings
{
    public class MySQLSettings
    {
        [JsonProperty("MysqlConnectionString")]
        public required string ConnectionString { get; set; }
    }
}