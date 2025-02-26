﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Create(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
