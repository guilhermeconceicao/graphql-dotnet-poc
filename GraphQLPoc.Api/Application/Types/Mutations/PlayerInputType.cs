using GraphQL.Types;
using GraphQLPoc.Api.Application.Types.Enums;

namespace GraphQLPoc.Api.Application.Types.Mutations
{
    public class PlayerInputType : InputObjectGraphType
    {
        public PlayerInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<PlayerPositionType>("position");
            Field<BooleanGraphType>("captain");
            Field<IntGraphType>("clubId");
        }
    }
}