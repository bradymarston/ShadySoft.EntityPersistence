using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync(bool RollbackOnFailure = false);
    }
}