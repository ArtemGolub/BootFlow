using System.Threading;
using Code.Infrastructure.Services.LoadingService;
using Code.Infrastructure.States.StatesController;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Windows.UpdatableWindows.LoadingWindow;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.AppStates
{
    public sealed class LoadState : EnterExitState
    {
        private readonly ILoadingService _loadingService;
        private readonly IStatesController<AppStateTypeID> _statesController;
        private readonly LoadingUIView _view;
        private readonly LoadingUIViewModel _viewModel;

        public LoadState(
            ILoadingService loadingService,
            IStatesController<AppStateTypeID> statesController,
            LoadingUIView view,
            LoadingUIViewModel viewModel)
        {
            _loadingService = loadingService;
            _statesController = statesController;
            _view = view;
            _viewModel = viewModel;
        }

        public override async UniTask EnterAsync(CancellationToken ct)
        {
            _view.Initialize(_viewModel);
            await _loadingService.Initialize(ct);
            await _statesController.EnterStateAsync(AppStateTypeID.MenuState, ct);
        }

        public override async UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();
            await _loadingService.Release(ct);
        }
    }
}