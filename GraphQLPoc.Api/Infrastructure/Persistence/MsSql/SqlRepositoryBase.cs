using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLPoc.Api.Infrastructure.Persistence.MsSql
{
    public abstract class SqlRepositoryBase<TEntity> : ISqlRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected PocDbContext dbContext;

        protected virtual IQueryable<TEntity> Query() => dbContext.Set<TEntity>().AsQueryable();

        public virtual IEnumerable<TEntity> GetAll() => Query();

        public virtual TEntity GetById(int id) => dbContext.Find<TEntity>(id);

        public virtual int Count() => dbContext.Set<TEntity>().Count();

        public virtual void Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}