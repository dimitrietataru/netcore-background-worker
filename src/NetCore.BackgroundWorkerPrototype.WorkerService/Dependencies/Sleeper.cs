using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WorkerService.Dependencies
{
    public sealed class Sleeper : ISleeper
    {
        public async Task SleepAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        }

        public void Sleep()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
