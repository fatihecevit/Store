using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {

        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public void Create(T entitiy)
        {
            _context.Set<T>().Add(entitiy);
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {

            return trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
            ? _context.Set<T>().Where(expression).SingleOrDefault()
            : _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entitiy)
        {
            _context.Set<T>().Remove(entitiy);
        }
    }
}