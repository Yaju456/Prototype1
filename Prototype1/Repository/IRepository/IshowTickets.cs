using Prototype1.Models;

namespace Prototype1.Repository.IRepository
{
    public interface IshowTickets: IRepository<ShowTIcketsClass>
    {
        void update(ShowTIcketsClass entity);
    }
}
