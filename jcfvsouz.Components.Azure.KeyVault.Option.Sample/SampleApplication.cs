using jcfvsouz.Components.Azure.KeyVault.Option.Sample.Settings;
using Microsoft.Extensions.Options;

namespace jcfvsouz.Components.Azure.KeyVault.Option.Sample
{
    internal class SampleApplication(IOptions<MsSQLSettings> mssqlSettings,
        IOptions<MySQLSettings> mysqlSettings)
    {
        public void Run()
        {
            var mssqlConnectionString = mssqlSettings.Value.ConnectionString;
            var mysqlConnectionString = mysqlSettings.Value.ConnectionString;

            Console.WriteLine($"MsSqlConnectionString: {mssqlConnectionString}");
            Console.WriteLine($"MySqlConnectionString: {mysqlConnectionString}");
        }
    }
}