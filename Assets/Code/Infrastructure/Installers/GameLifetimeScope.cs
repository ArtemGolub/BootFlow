using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Bootstrap.InstallDependencies(builder);
        }
    }
}
