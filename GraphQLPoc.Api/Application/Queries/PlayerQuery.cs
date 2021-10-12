using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using GraphQLPoc.Api.Application.Queries.Types;
using GraphQLPoc.Api.Application.Types.Enums;
using Humanizer;

namespace GraphQLPoc.Api.Application.Queries
{
    public class PlayerQuery : QueryBase<IPlayerRepository, Player>
    {
        public PlayerQuery(IPlayerRepository repository) : base(repository)
        {
            var nameOfEntity = typeof(Player).Name.ToCamelCase();
            var nameOfEntityPlural = nameOfEntity.Pluralize();

            Field<ListGraphType<PlayerType>>(
                nameOfEntityPlural,
                $"Get all {nameOfEntityPlural}",
                resolve: context => { return repository.GetAll(); });

            Field<PlayerType>(
                nameOfEntity,
                $"Get {nameOfEntity} by id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return repository.GetById(context.GetArgument<int>("id")); });

            Field<PlayerType>(
                $"{nameOfEntity}ByName",
                $"Get {nameOfEntity} by name",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => { return repository.GetByName(context.GetArgument<string>("name")); });

            Field<ListGraphType<PlayerType>>(
                $"{nameOfEntityPlural}Captains",
                $"Get all captain {nameOfEntityPlural}",
                resolve: context => { return repository.GetAllCaptain(); });

            Field<PlayerType>(
                $"{nameOfEntityPlural}ByClubAndPosition",
                $"Get all {nameOfEntityPlural} by club and position",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "clubId" }, new QueryArgument<PlayerPositionType> { Name = "position" }),
                resolve: context => { return repository.GetAllByClubIdAndPosition(context.GetArgument<int>("clubId"), context.GetArgument<PlayerPosition>("position")); });
        }
    }
}