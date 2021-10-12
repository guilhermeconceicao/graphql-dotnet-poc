using GraphQL.Types;

namespace GraphQLPoc.Api.Application.Types.Mutations
{
    public class GroundInputType : InputObjectGraphType
    {
        public GroundInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("capacity");
        }
    }
}