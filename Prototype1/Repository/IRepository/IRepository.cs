using System.Linq.Expressions;

namespace Prototype1.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(String? IncludeProperties=null);
        T GetSome(Expression<Func<T, bool>> fileter);

        void Add(T entity);
        void Delete(T entity);


    }
}
