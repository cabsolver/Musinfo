using CommonDataAccess.Finder;
using CommonDataAccess.Finder.Interfaces;
using Microsoft.EntityFrameworkCore;
using MusinfoDB.Finders.Interface;
using System.Linq.Expressions;

namespace MusinfoDB.Finders
{
    public class CommonFinder<T> : ICommonFinder<T>
        where T : class
    {
        private readonly IFinder<T> _finder;

        public CommonFinder(DbContext context) => _finder = new Finder<T>(context);

        public List<T> Get() => _finder.Find().ToList();

        public List<T> Get(Expression<Func<T, bool>> expression) => _finder.Find().Where(expression).ToList();

        public T Get(int id) => _finder.Find(id);
        public T Get(string property) => _finder.Find(property);

        public bool Exists(Expression<Func<T, bool>> expression) => _finder.Exists(expression);

        public T? FirstOrDefault(Expression<Func<T, bool>> expression) => _finder.Find().FirstOrDefault(expression);
    }
}
