using System;
using Demo.Common.Contracts;

namespace Demo.Common
{
    public class EventHelper : IEventHelper
    {
        public void RaiseEvent(
            object objectRaisingEvent,
            EventHandler eventHandlerRaised,
            EventArgs eventArgs)
        {
            eventHandlerRaised?.Invoke(objectRaisingEvent, eventArgs);
        }
    }
}
