using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using GraphQLPoc.Api.Application.Types;
using GraphQLPoc.Api.Application.Types.Enums;
using Humanizer;

namespace GraphQLPoc.Api.Application.Queries
{
    public class CompetitionQuery : QueryBase<ICompetitionRepository, Competition>
    {
        public CompetitionQuery(ICompetitionRepository repository) : base(repository)
        {
            var nameOfEntity = typeof(Competition).Name.ToCamelCase();
            var nameOfEntityPlural = nameOfEntity.Pluralize();

            Field<ListGraphType<CompetitionType>>(
                nameOfEntityPlural,
                $"Get all {nameOfEntityPlural}",
                resolve: context => { return repository.GetAll(); });

            Field<CompetitionType>(
                nameOfEntity,
                $"Get {nameOfEntity} by id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => { return repository.GetById(context.GetArgument<int>("id")); });

            Field<CompetitionType>(
                $"{nameOfEntity}ByName",
                $"Get {nameOfEntity} by name",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => { return repository.GetByName(context.GetArgument<string>("name")); });

            Field<ListGraphType<CompetitionType>>(
                $"{nameOfEntityPlural}ByCountry",
                $"Get all {nameOfEntityPlural} by country",
                arguments: new QueryArguments(new QueryArgument<CountryType> { Name = "country" }),
                resolve: context => { return repository.GetAllByCountry(context.GetArgument<Country>("country")); });
        }
    }
}