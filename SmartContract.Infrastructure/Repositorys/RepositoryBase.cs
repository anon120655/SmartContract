using Microsoft.EntityFrameworkCore;
using SmartContract.Infrastructure.Interfaces;
using SmartContract.Infrastructure.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Repositorys
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly IRepositoryWrapper unitofWork;
        public RepositoryBase(IRepositoryWrapper unitOfWork)
        {
            unitofWork = unitOfWork;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return unitofWork.Context.Set<T>().AsQueryable<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync<T>() where T : class
        {
            return await unitofWork.Context.Set<T>().ToListAsync<T>();
        }

        public async Task<IEnumerable<T>> FindByConditionAync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await unitofWork.Context.Set<T>().Where(predicate).ToListAsync<T>();
        }

        public T Inster<T>(T entity) where T : class
        {
            unitofWork.Context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> InsterAsync<T>(T entity) where T : class
        {
            await unitofWork.Context.Set<T>().AddAsync(entity);
            return entity;
        }

        //public async Task<T> InsterEbAsync<T>(T entity) where T : class
        //{
        //    await unitofWork.ContextEb.Set<T>().AddAsync(entity);
        //    return entity;
        //}

        public void InsterRange<T>(IEnumerable<T> entities) where T : class
        {
            unitofWork.Context.Set<T>().AddRange(entities);
        }

        public T Update<T>(T entity) where T : class
        {
            //unitofWork.context.Set<T>().Attach(entity);
            //unitofWork.context.Entry(entity).State = EntityState.Modified;
            unitofWork.Context.Set<T>().Update(entity);

            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            //T existing = unitofWork.Context.Set<T>().Find(entity);            
            //if (existing != null) unitofWork.Context.Set<T>().Remove(existing);
            unitofWork.Context.Set<T>().Remove(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entitys) where T : class
        {
            unitofWork.Context.Set<T>().RemoveRange(entitys);
        }

        public async Task SaveAsync()
        {
            await unitofWork.Context.SaveChangesAsync();
        }

        //public async Task SaveEbAsync()
        //{
        //    await unitofWork.ContextEb.SaveChangesAsync();
        //}

    }
}
