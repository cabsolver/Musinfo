using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CommonDataAccess.Finder.Interfaces;

namespace CommonDataAccess.Finder
{
    public class Finder<T> : IFinder<T>
        where T : class
    {
        private readonly DbContext _context;

        public Finder(DbContext context) => _context = context;

        public IQueryable<T> Find() => _context.Set<T>();
        public T Find(int id) => _context.Find<T>(id)!;

        public bool Exists(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);
    }
}
