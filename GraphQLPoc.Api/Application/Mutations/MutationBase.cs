using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;

namespace GraphQLPoc.Api.Application.Mutations
{
    public abstract class MutationBase<TRepository, TEntity, TEntityInputType> : ObjectGraphType
        where TRepository : ISqlRepositoryBase<TEntity>
        where TEntity : class, new()
        where TEntityInputType : InputObjectGraphType, new()
    {
        protected MutationBase(TRepository repository)
        {
            var nameOfEntity = typeof(TEntity).Name.ToCamelCase();

            Field<StringGraphType>(
                $"{nameOfEntity}Create",
                arguments: new QueryArguments(new QueryArgument<TEntityInputType> { Name = nameOfEntity }),
                resolve: context =>
                {
                    repository.Create(context.GetArgument<TEntity>(nameOfEntity));
                    return $"{nameOfEntity} created";
                });

            Field<StringGraphType>(
                $"{nameOfEntity}Update",
                arguments: new QueryArguments(new QueryArgument<TEntityInputType> { Name = nameOfEntity }),
                resolve: context =>
                {
                    repository.Update(context.GetArgument<TEntity>(nameOfEntity));
                    return $"{nameOfEntity} updated";
                });

            Field<StringGraphType>(
                $"{nameOfEntity}Delete",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var entityBase = repository.GetById(context.GetArgument<int>("id"));
                    repository.Delete(entityBase);
                    return $"{nameOfEntity} deleted";
                });
        }
    }
}