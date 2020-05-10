using System;
using LM.Domain.Events.Models;
using LM.Domain.Helpers;

namespace LM.Domain.Events
{
    public abstract class DomainEvent<TModel> : IDomainEvent where TModel : EventModel
    {
        public DomainEvent(TModel model)
        {
            Model = model;
        }

        public DateTime Data => DateTimeHelper.GetCurrentDate();

        public TModel Model { get; private set; }
    }
}
