using CommonDataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommonDataAccess.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public void Create(T entity) => _context.Add(entity);

        public void Update(T entity) => _context.Update(entity);

        public void Delete(T entity) => _context.Remove(entity);
    }
}
