using System;
using System.Threading;
using Code.Infrastructure.States.AppStates;
using Code.Infrastructure.States.StatesController;
using Code.UI.Abstractions;
using Cysharp.Threading.Tasks;
using R3;

namespace Code.Windows.StaticWindows.MenuWindow
{
    public sealed class MenuUIViewModel : IUIViewModel
    {
        private readonly IStatesController<AppStateTypeID> _statesController;
        private CancellationToken _cancellationToken;

        public MenuUIViewModel(IStatesController<AppStateTypeID> statesController)
        {
            _statesController = statesController;
        }

        public void Bind(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }

        public IDisposable BindRestart(Observable<Unit> restartClicks)
        {
            return restartClicks.Subscribe(_ => RestartAsync().Forget());
        }

        private async UniTask RestartAsync()
        {
            await _statesController.EnterStateAsync(AppStateTypeID.LoadState, _cancellationToken);
        }
    }
}
