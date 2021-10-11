using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Common.Interfaces
{
    public interface ISqlRepositoryBase<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        int Count();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}