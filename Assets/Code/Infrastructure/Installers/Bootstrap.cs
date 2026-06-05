using System.Threading;
using Code.Infrastructure.States.AppStates;
using Code.Infrastructure.States.StatesController;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.Installers
{
    public sealed class Bootstrap : IAsyncStartable
    {
        public static void InstallDependencies(IContainerBuilder builder)
        {
            new FSMInstaller().Install(builder);
            new ServiceInstaller().Install(builder);
            new UIInstaller().Install(builder);

            builder.RegisterEntryPoint<Bootstrap>();
        }

        private readonly IStatesController<AppStateTypeID> _statesController;

        public Bootstrap(IStatesController<AppStateTypeID> statesController) =>
            _statesController = statesController;

        public async Awaitable StartAsync(CancellationToken cancellation)
            => await _statesController.EnterStateAsync(AppStateTypeID.SplashState, cancellation);
    }
}
