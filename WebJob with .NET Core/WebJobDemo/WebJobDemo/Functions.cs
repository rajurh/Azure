using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WebJobDemo.Domain;

namespace WebJobDemo
{
  public  class Functions
    {
        private readonly IDemo _demo;

        public Functions(IDemo demo)
        {
            _demo = demo;
        }

        public async Task TimerTrigger([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo timerInfo, CancellationToken cancellationToken)
        {
            //Some logic goes here...
            _demo.SomeAction();
        }
    }
}
