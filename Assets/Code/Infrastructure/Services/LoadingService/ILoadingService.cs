using System.Threading;
using Cysharp.Threading.Tasks;
using R3;

namespace Code.Infrastructure.Services.LoadingService
{
    public interface ILoadingService
    {
        ReadOnlyReactiveProperty<float> Progress { get; }
        UniTask Initialize(CancellationToken ct);
        UniTask Release(CancellationToken ct);
    }
}