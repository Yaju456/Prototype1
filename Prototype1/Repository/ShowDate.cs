using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;

namespace Prototype1.Repository
{
    public class ShowDate : Repository<ShowDateClass>, IshowDate
    {
        public ShowDate(ApplicationDbConetext db):base (db)
        { }
        
        public void update(ShowDateClass Entity)
        {
            _dataSet.Update(Entity);
        }
    }
}
