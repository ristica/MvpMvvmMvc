using System;

namespace Demo.Common.Contracts
{
    public interface IEventHelper
    {
        void RaiseEvent(
            object objectRaisingEvent,
            EventHandler eventHandlerRaised,
            EventArgs eventArgs);
    }
}