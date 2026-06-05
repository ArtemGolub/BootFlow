using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StatesController
{
    public interface IStatesController<TEnum> where TEnum : Enum
    {
        UniTask EnterStateAsync(TEnum stateTypeId, CancellationToken ct);
    }
}
