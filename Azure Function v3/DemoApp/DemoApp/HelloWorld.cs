using Microsoft.Extensions.Logging;

namespace DemoApp
{
    public class HelloWorld:IHelloWorld
    {
        private readonly ILogger<HelloWorld> _logger;

        public HelloWorld(ILogger<HelloWorld> logger)
        {
            _logger = logger;
        }
        public string Greeting(string name)
        {
            _logger.LogInformation("Test logging with Information");
            return $"Hello, {name}. I'm a sample hello world.";
        }
    }
}