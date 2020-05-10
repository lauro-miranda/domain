using System;

namespace LM.Domain.Events
{
    public interface IDomainEventTigger
    {
        void Register<T>(Action<T> callback) where T : IDomainEvent;

        void Raise<T>(T args) where T : IDomainEvent;

        void ClearCallbacks();
    }
}
