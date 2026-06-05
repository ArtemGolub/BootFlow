using Code.Infrastructure.States.AppStates;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StatesController;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
    public sealed class FSMInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            InstallStates(builder);
            InstallFactories(builder);
            InstallControllers(builder);
        }

        private void InstallFactories(IContainerBuilder builder)
        {
            builder.Register<StateFactory>(Lifetime.Singleton).As<IStateFactory>();
        }

        private void InstallControllers(IContainerBuilder builder)
        {
            builder.Register<StatesController>(Lifetime.Singleton).As<IStatesController<AppStateTypeID>>();
        }

        private void InstallStates(IContainerBuilder builder)
        {
            builder.Register<AppStateTypeRegistrar>(Lifetime.Singleton).As<IStateTypeRegistry<AppStateTypeID>>();

            builder.Register<SplashState>(Lifetime.Transient);
            builder.Register<LoadState>(Lifetime.Transient);
            builder.Register<MenuState>(Lifetime.Transient);
        }
    }
}
