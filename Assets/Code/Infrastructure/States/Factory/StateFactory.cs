using System;
using Code.Infrastructure.States.StateInfrastructure;
using VContainer;

namespace Code.Infrastructure.States.Factory
{
    public sealed class StateFactory: IStateFactory
    {
        private readonly IObjectResolver _resolver;

        public StateFactory(IObjectResolver resolver) => _resolver = resolver;
        
        public T GetState<T>() where T : class, IState => _resolver.Resolve<T>();

        public IState GetState(Type stateType)
        {
            if (!typeof(IState).IsAssignableFrom(stateType))
                throw new ArgumentException($"Type '{stateType.Name}' must implement {nameof(IState)}.", nameof(stateType));

            return (IState)_resolver.Resolve(stateType);
        }
    }
}