using Code.Infrastructure.Services.LoadingService;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
    public sealed class ServiceInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<LoadingService>(Lifetime.Singleton).As<ILoadingService>();
        }
    }
}
