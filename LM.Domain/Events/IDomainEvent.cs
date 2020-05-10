using System;

namespace LM.Domain.Events
{
    public interface IDomainEvent
    {
        DateTime Data { get; }
    }
}
