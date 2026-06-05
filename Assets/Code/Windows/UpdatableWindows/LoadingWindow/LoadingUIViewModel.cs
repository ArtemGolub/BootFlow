using Code.Infrastructure.Services.LoadingService;
using Code.UI.Abstractions;
using R3;

namespace Code.Windows.UpdatableWindows.LoadingWindow
{
    public sealed class LoadingUIViewModel : IUIViewModel
    {
        public ReadOnlyReactiveProperty<float> Progress { get; }

        public LoadingUIViewModel(ILoadingService loadingService)
        {
            Progress = loadingService.Progress;
        }
    }
}
