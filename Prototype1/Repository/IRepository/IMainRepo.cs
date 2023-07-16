namespace Prototype1.Repository.IRepository
{
    public interface IMainRepo
    {
        IshowDate showDate { get; }
        IShowClass showClass { get; }
        IshowTickets showTickets { get; }
        void save();

    }
}
