using System.Threading;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Common.Services
{
    public abstract class DefaultService : IService
    {
        private CancellationTokenSource _cancelToken;
        
        public async UniTask InitializeAsync(CancellationToken ct)
        {
            _cancelToken = new CancellationTokenSource();
            await OnInitializeAsync(ct);
        }
        
        public async UniTask ReleaseAsync(CancellationToken ct)
        {
            _cancelToken?.Cancel();
            await OnReleaseAsync();
            _cancelToken?.Dispose();
            _cancelToken = null;
        }
        
        protected virtual UniTask OnInitializeAsync(CancellationToken ct) => UniTask.CompletedTask;
        protected virtual UniTask OnReleaseAsync() => UniTask.CompletedTask;
    }
}
