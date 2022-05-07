using System.Linq.Expressions;

namespace MusinfoBL.Services.Interface
{
    public interface IService<T> 
        where T : class
    {
        public List<T> Get();

        public List<T> Get(Expression<Func<T, bool>> expression);

        public T Get(int id);

        public bool Exists(Expression<Func<T, bool>> expression);

        public T? FirstOrDefault(Expression<Func<T, bool>> expression);

        public void Create(T entity);

        public void Update(T entity);

        public void Delete(int id);
    }
}
