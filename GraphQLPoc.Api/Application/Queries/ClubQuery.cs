using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types;
using Humanizer;

namespace GraphQLPoc.Api.Application.Queries
{
    public class ClubQuery : QueryBase<IClubRepository, Club>
    {
        public ClubQuery(IClubRepository repository) : base(repository)
        {
            var nameOfEntity = typeof(Club).Name.ToCamelCase();
            var nameOfEntityPlural = nameOfEntity.Pluralize();

            Field<ListGraphType<ClubType>>(
                nameOfEntityPlural,
                $"Get all {nameOfEntityPlural}",
                resolve: context => { return repository.GetAll(); });

            Field<ClubType>(
                nameOfEntity,
                $"Get {nameOfEntity} by id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return repository.GetById(context.GetArgument<int>("id")); });

            Field<ClubType>(
                $"{nameOfEntity}ByName",
                $"Get {nameOfEntity} by name",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => { return repository.GetByName(context.GetArgument<string>("name")); });

            Field<ClubType>(
                $"{nameOfEntity}ByNickame",
                $"Get {nameOfEntity} by nickname",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "nickname" }),
                resolve: context => { return repository.GetByNickame(context.GetArgument<string>("nickname")); });
        }
    }
}