using System.Threading;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WorkerService.Dependencies
{
    public interface ISleeper
    {
        Task SleepAsync(CancellationToken cancellationToken);
        void Sleep();
    }
}
