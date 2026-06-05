using Code.Windows.StaticWindows.MenuWindow;
using Code.Windows.StaticWindows.SplashWindow;
using Code.Windows.UpdatableWindows.LoadingWindow;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
    public sealed class UIInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<SplashUIViewModel>(Lifetime.Transient);
            builder.Register<LoadingUIViewModel>(Lifetime.Transient);
            builder.Register<MenuUIViewModel>(Lifetime.Transient);

            builder.RegisterComponentInHierarchy<SplashUIView>();
            builder.RegisterComponentInHierarchy<LoadingUIView>();
            builder.RegisterComponentInHierarchy<MenuUIView>();
        }
    }
}
