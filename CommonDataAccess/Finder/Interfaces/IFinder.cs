﻿using System.Linq.Expressions;

namespace CommonDataAccess.Finder.Interfaces
{
    public interface IFinder<T>
        where T : class
    {
        public IQueryable<T> Find();

        public T Find(int id);
        public T Find(string property);

        public bool Exists(Expression<Func<T, bool>> expression);
    }
}
