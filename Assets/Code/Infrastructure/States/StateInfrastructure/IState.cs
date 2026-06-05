using System.Threading;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public interface IState
    {
        public UniTask EnterAsync(CancellationToken ct);
        public UniTask ExitAsync(CancellationToken ct);
    }
}