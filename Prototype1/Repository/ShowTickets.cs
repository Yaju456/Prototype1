using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;

namespace Prototype1.Repository
{
    public class ShowTickets : Repository<ShowTIcketsClass>, IshowTickets
    {
        ApplicationDbConetext _db;
        public ShowTickets(ApplicationDbConetext db): base(db) 
        {
            
        }
        public void update(ShowTIcketsClass entity)
        {
            _dataSet.Update(entity);
        }
    }
}
