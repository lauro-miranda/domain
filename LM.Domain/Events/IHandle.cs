using System.Threading.Tasks;

namespace LM.Domain.Events
{
    public interface IHandle<T> where T : IDomainEvent
    {
        Task Handle(T args);
    }
}
