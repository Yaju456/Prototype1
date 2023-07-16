using Microsoft.EntityFrameworkCore;
using Prototype1.Data;
using Prototype1.Repository.IRepository;
using System.Data;
using System.Linq.Expressions;

namespace Prototype1.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbConetext _db;
        public DbSet<T> _dataSet;
        public Repository(ApplicationDbConetext db)
        {
            _db = db;
            _dataSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dataSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(string? IncludeProperties = null)
        {
            IQueryable<T> query = _dataSet.AsQueryable();
            if (!string.IsNullOrEmpty(IncludeProperties))
            {
                foreach (var item in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query;
        }

        public T GetSome(Expression<Func<T, bool>> fileter)
        {
            IQueryable<T> query = _dataSet.AsQueryable();
            query = query.Where(fileter);
            return query.FirstOrDefault();
        }
    }
}
