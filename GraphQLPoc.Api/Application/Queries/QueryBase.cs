using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using Humanizer;

namespace GraphQLPoc.Api.Application.Queries
{
    public abstract class QueryBase<TRepository, TEntity> : ObjectGraphType
        where TRepository : ISqlRepositoryBase<TEntity>
        where TEntity : class, new()
    {
        protected QueryBase(TRepository repository)
        {
            var nameOfEntity = typeof(TEntity).Name.ToCamelCase();
            var nameOfEntityPlural = nameOfEntity.Pluralize();

            Field<IntGraphType>(
                $"{nameOfEntityPlural}Count",
                $"Count of {nameOfEntityPlural}",
                resolve: context => { return repository.Count(); });
        }
    }
}