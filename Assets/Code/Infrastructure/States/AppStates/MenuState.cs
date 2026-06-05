using System.Threading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Windows.StaticWindows.MenuWindow;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.AppStates
{
    public sealed class MenuState : EnterExitState
    {
        private readonly MenuUIView _view;
        private readonly MenuUIViewModel _viewModel;

        public MenuState(MenuUIView view, MenuUIViewModel viewModel)
        {
            _view = view;
            _viewModel = viewModel;
        }

        public override UniTask EnterAsync(CancellationToken ct)
        {
            _viewModel.Bind(ct);
            _view.Initialize(_viewModel);
            return UniTask.CompletedTask;
        }

        public override UniTask ExitAsync(CancellationToken ct)
        {
            _view.Release();
            return UniTask.CompletedTask;
        }
    }
}
