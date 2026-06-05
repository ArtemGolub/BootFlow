using System.Threading;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.Common.Services
{
    public interface IService
    {
        UniTask InitializeAsync(CancellationToken ct);
        UniTask ReleaseAsync(CancellationToken ct);
    }
}