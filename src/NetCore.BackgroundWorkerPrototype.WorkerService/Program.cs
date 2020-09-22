using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.BackgroundWorkerPrototype.WorkerService.Dependencies;
using NetCore.BackgroundWorkerPrototype.WorkerService.Workers;
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
                        services.AddTransient<ISleeper, Sleeper>();
                        services.AddHostedService<Worker>();
                    })
                .Build()
                .RunAsync()
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
