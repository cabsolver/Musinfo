using CommonDataAccess.Repository.Interfaces;
using CommonDataAccess.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusinfoBL.Services.Interface;
using MusinfoDB.Finders.Interface;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq.Expressions;
using System.Security.Claims;
using MusinfoDB.Models;

namespace MusinfoBL.Services
{
    public class Service<T> : IService<T>
        where T : class
    {
        private readonly ICommonFinder<T> _finder;
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(ICommonFinder<T> finder, IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _finder = finder;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<T> Get() => _finder.Get();

        public List<T> Get(Expression<Func<T, bool>> expression) => _finder.Get(expression);

        public T Get(int id) => _finder.Get(id);

        public bool Exists(Expression<Func<T, bool>> expression) => _finder.Exists(expression);

        public T? FirstOrDefault(Expression<Func<T, bool>> expression) => _finder.FirstOrDefault(expression);

        public void Create(T entity)
        {
            _repository.Create(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _finder.Get(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
