using System.Threading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StatesController;
using Code.Windows.StaticWindows.SplashWindow;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.AppStates
{
    public sealed class SplashState : EnterExitState
    {
        private readonly IStatesController<AppStateTypeID> _statesController;
        private readonly SplashUIView _view;
        private readonly SplashUIViewModel _viewModel;

        public SplashState(
            IStatesController<AppStateTypeID> statesController,
            SplashUIView view,
            SplashUIViewModel viewModel)
        {
            _statesController = statesController;
            _view = view;
            _viewModel = viewModel;
        }

        public override async UniTask EnterAsync(CancellationToken ct)
        {
            _view.Initialize(_viewModel);
            await UniTask.Delay(1000, cancellationToken: ct);
            await _statesController.EnterStateAsync(AppStateTypeID.LoadState, ct);
        }

        public override UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();
            return UniTask.CompletedTask;
        }
    }
}
