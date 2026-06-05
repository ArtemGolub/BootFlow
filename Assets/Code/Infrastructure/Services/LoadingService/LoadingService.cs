using System.Threading;
using Code.Infrastructure.Common.Services;
using Cysharp.Threading.Tasks;
using R3;

namespace Code.Infrastructure.Services.LoadingService
{
    public sealed class LoadingService: DefaultService, ILoadingService
    {
        public ReadOnlyReactiveProperty<float> Progress { get => _progress; }
        
        public async UniTask Initialize(CancellationToken ct) 
            => await OnInitializeAsync(ct);

        public async UniTask Release(CancellationToken ct)
            => await OnReleaseAsync();

        private readonly ReactiveProperty<float> _progress = new(0f);

        protected override async UniTask OnInitializeAsync(CancellationToken ct)
            => await AnimateProgressAsync(ct);

        protected override async UniTask OnReleaseAsync()
            => await ReleaseProperties();

        private async UniTask AnimateProgressAsync(CancellationToken ct, int steps = 5, int stepDelay = 200)
        {
            for (int i = 1; i <= steps; i++)
            {
                await UniTask.Delay(stepDelay, cancellationToken: ct);
                _progress.Value = i / (float)steps;
            }
        }

        private UniTask ReleaseProperties()
        {
            _progress.Value = 0f;
            return UniTask.CompletedTask;
        }
    }
}