using GraphQL.Types;
using GraphQLPoc.Api.Application.Types.Enums;

namespace GraphQLPoc.Api.Application.Types.Mutations
{
    public class CompetitionInputType : InputObjectGraphType
    {
        public CompetitionInputType()
        {
            Field<IntGraphType>("id");
            Field<CountryType>("country");
            Field<StringGraphType>("name");
            Field<DateGraphType>("startDate");
            Field<DateGraphType>("endDate");
        }
    }
}