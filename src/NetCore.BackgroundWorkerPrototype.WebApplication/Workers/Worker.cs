using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore.BackgroundWorkerPrototype.WebApplication.Dependencies;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WebApplication.Workers
{
    public sealed class Worker : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<Worker> logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var sleeper = scope.ServiceProvider.GetRequiredService<ISleeper>();

            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();

                logger.LogInformation($"Running at: { DateTimeOffset.Now }");
                await sleeper.SleepAsync(cancellationToken);

                logger.LogInformation($"Running at: { DateTimeOffset.Now }");
                sleeper.Sleep();
            }
        }
    }
}
