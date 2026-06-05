using System;
using System.Collections.Generic;

namespace Code.Infrastructure.States.Factory
{
    public interface IStateTypeRegistry<TStateTypeID> where TStateTypeID : Enum
    {
        Dictionary<TStateTypeID, Type> StateTypes { get; }
        Type GetStateType(TStateTypeID stateTypeId);
    }
}