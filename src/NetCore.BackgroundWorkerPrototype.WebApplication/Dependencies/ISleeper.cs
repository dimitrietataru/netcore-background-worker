using System.Threading;
using System.Threading.Tasks;

namespace NetCore.BackgroundWorkerPrototype.WebApplication.Dependencies
{
    public interface ISleeper
    {
        Task SleepAsync(CancellationToken cancellationToken);
        void Sleep();
    }
}
