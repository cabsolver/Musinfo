using System.Linq.Expressions;

namespace MusinfoDB.Finders.Interface
{
    public interface ICommonFinder<T>
        where T : class
    {
        public List<T> Get();

        public List<T> Get(Expression<Func<T, bool>> expression);

        public T Get(int id);

        public T Get(string property);

        public bool Exists(Expression<Func<T, bool>> expression);

        public T? FirstOrDefault(Expression<Func<T, bool>> expression);
    }
}
