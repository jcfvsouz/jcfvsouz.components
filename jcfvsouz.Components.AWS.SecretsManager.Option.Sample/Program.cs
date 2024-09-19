using jcfvsouz.Components.ApplicationBuilder;

namespace jcfvsouz.Components.AWS.SecretsManager.Option.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var application = new ApplicationBuilder<SampleApplication>()
                .WithStartup<Startup>()
                .Build();

            application.Run();
        }
    }
}
