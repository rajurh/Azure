using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: FunctionsStartup(typeof(DemoApp.Startup))]

namespace DemoApp
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IHelloWorld, HelloWorld>();

            // Registering Serilog provider
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            builder.Services.AddLogging(lb => lb.AddSerilog(logger));

            //HTTP Client factory with retry can go here

            //Reading configuration section can be added here etc.
        }
    }
}
