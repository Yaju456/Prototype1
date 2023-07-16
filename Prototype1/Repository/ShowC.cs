using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;

namespace Prototype1.Repository
{
    public class ShowC : Repository<ShowClass>, IShowClass
    {
        ApplicationDbConetext _db;
        public ShowC(ApplicationDbConetext db): base(db) { }
        
        public void Update(ShowClass entity)
        {
            _dataSet.Update(entity);
        }
    }
}
