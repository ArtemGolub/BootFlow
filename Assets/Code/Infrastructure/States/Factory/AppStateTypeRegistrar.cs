using System;
using System.Collections.Generic;
using Code.Infrastructure.States.AppStates;

namespace Code.Infrastructure.States.Factory
{
    public class AppStateTypeRegistrar: IStateTypeRegistry<AppStateTypeID>
    {
        public Dictionary<AppStateTypeID, Type> StateTypes => _stateTypes;
        
        public Type GetStateType(AppStateTypeID stateTypeId)
        {
            if (!StateTypes.TryGetValue(stateTypeId, out var stateType))
                throw new ArgumentOutOfRangeException(nameof(stateTypeId), stateTypeId, "State type is not registered.");

            return stateType;
        }
        
        private readonly Dictionary<AppStateTypeID, Type> _stateTypes = new()
        {
            [AppStateTypeID.SplashState] = typeof(SplashState),
            [AppStateTypeID.LoadState] = typeof(LoadState),
            [AppStateTypeID.MenuState] = typeof(MenuState),
        };
    }
}
