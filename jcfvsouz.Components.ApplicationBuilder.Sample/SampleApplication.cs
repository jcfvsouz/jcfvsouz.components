using Microsoft.Extensions.Configuration;

namespace jcfvsouz.Components.ApplicationBuilder.Sample
{
    public class SampleApplication(IConfiguration configuration)
    {
        public void Run()
        {
            var userMessage = $"Welcome to {configuration.GetValue<string>("applicationName")}";
            Console.WriteLine(userMessage);
        }
    }
}
