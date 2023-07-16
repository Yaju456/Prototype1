using Prototype1.Data;
using Prototype1.Repository.IRepository;

namespace Prototype1.Repository
{
    public class MainRepo : IMainRepo
    {
        public IshowDate showDate { get; private set; }

        public IShowClass showClass { get; private set; }

        public IshowTickets showTickets { get; private set; }

        ApplicationDbConetext _db;
        public MainRepo(ApplicationDbConetext db)
        {
            _db = db;
            showDate= new ShowDate(_db);
            showClass = new ShowC(_db);
            showTickets = new ShowTickets(_db);
        }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}
