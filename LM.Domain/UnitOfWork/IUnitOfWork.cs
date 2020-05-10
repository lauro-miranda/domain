using System.Threading.Tasks;

namespace LM.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}