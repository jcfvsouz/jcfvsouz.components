namespace jcfvsouz.Components.ApplicationBuilder.Sample
{
    internal class Program
    {
        static SampleApplication? Application { get; set; }
        static void Main(string[] args)
        {
            Application ??= new ApplicationBuilder<SampleApplication>()
                .WithStartup<Startup>()
                .Build();

            Application.Run();
        }
    }
}
