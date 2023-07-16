using Prototype1.Models;

namespace Prototype1.Repository.IRepository
{
    public interface IshowDate:IRepository<ShowDateClass>
    {
        void update(ShowDateClass Entity);
    }
}
