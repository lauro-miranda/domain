using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LM.Domain.Events
{
    public class DomainEventTigger : IDomainEventTigger
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        private IServiceProvider _serviceProvider;

        public DomainEventTigger(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }

            actions.Add(callback);
        }
        public void Raise<T>(T args) where T : IDomainEvent
        {
            foreach (var handler in _serviceProvider.GetServices<IHandle<T>>())
            {
                new Task(() => handler.Handle(args)).Start();
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }
        public void ClearCallbacks()
        {
            actions = null;
        }
    }
}
