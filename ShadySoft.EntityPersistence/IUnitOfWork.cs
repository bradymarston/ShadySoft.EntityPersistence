using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}