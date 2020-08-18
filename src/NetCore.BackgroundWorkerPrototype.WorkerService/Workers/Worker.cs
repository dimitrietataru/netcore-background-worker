using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore.BackgroundWorkerPrototype.WorkerService.Dependencies;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WorkerService.Workers
{
    public sealed class Worker : BackgroundService
    {
        private readonly ISleeper sleeper;
        private readonly ILogger<Worker> logger;

        public Worker(ISleeper sleeper, ILogger<Worker> logger)
        {
            this.sleeper = sleeper;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
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
