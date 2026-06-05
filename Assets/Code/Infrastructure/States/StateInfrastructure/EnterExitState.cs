using System.Threading;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public abstract class EnterExitState: IState
    {
        public virtual UniTask EnterAsync(CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        public virtual UniTask ExitAsync(CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}