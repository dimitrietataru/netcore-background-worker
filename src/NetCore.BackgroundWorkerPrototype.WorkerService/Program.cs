using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.BackgroundWorkerPrototype.WorkerService.Dependencies;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WorkerService
{
    public sealed class Program
    {
        public static async Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    {
                        services.AddHostedService<Worker>();
                        services.AddTransient<ISleeper, Sleeper>();
                    })
                .Build()
                .RunAsync()
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
