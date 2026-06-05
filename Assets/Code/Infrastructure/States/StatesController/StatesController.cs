using System.Threading;
using Code.Infrastructure.States.AppStates;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StatesController
{
    public sealed class StatesController : IStatesController<AppStateTypeID>
    {
        private readonly IStateFactory _stateFactory;
        private readonly IStateTypeRegistry<AppStateTypeID> _stateTypeRegistry;
        private IState _currentState;

        public StatesController(
            IStateFactory stateFactory,
            IStateTypeRegistry<AppStateTypeID> stateTypeRegistry)
        {
            _stateFactory = stateFactory;
            _stateTypeRegistry = stateTypeRegistry;
        }

        public async UniTask EnterStateAsync(AppStateTypeID appStateTypeID, CancellationToken ct)
        {
            await ExitCurrentState(ct);
            await EnterNewState(appStateTypeID, ct);
        }

        private async UniTask ExitCurrentState(CancellationToken ct)
        {
            if (_currentState == null)
                return;

            await _currentState.ExitAsync(ct);
            _currentState = null;
        }

        private async UniTask EnterNewState(AppStateTypeID appStateTypeID, CancellationToken ct)
        {
            _currentState = _stateFactory.GetState(_stateTypeRegistry.GetStateType(appStateTypeID));
            await _currentState.EnterAsync(ct);
        }
    }
}
