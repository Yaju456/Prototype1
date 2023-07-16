using Prototype1.Models;

namespace Prototype1.Repository.IRepository
{
    public interface IShowClass: IRepository<ShowClass>
    {
        void Update(ShowClass entity);
    }
}
