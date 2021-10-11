using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types;
using Humanizer;

namespace GraphQLPoc.Api.Application.Queries
{
    public class GroundQuery : QueryBase<IGroundRepository, Ground>
    {
        public GroundQuery(IGroundRepository repository) : base(repository)
        {
            var nameOfEntity = typeof(Ground).Name.ToCamelCase();
            var nameOfEntityPlural = nameOfEntity.Pluralize();

            Field<ListGraphType<GroundType>>(
                nameOfEntityPlural,
                $"Get all {nameOfEntityPlural}",
                resolve: context => { return repository.GetAll(); });

            Field<GroundType>(
                nameOfEntity,
                $"Get {nameOfEntity} by id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return repository.GetById(context.GetArgument<int>("id")); });

            Field<GroundType>(
                $"{nameOfEntity}ByName",
                $"Get {nameOfEntity} by name",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => { return repository.GetByName(context.GetArgument<string>("name")); });
        }
    }
}