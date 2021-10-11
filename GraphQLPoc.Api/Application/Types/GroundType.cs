using GraphQL.Types;
using GraphQLPoc.Api.Application.Entities;

namespace GraphQLPoc.Api.Application.Types
{
    public class GroundType : ObjectGraphType<Ground>
    {
        public GroundType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Capacity);
        }
    }
}