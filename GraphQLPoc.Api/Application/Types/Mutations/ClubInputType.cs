using GraphQL.Types;

namespace GraphQLPoc.Api.Application.Types.Mutations
{
    public class ClubInputType : InputObjectGraphType
    {
        public ClubInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("nickname");
            Field<StringGraphType>("manager");
            Field<IntGraphType>("competitionId");
            Field<IntGraphType>("groundId");
            Field<IntGraphType>("rivalId");
        }
    }
}