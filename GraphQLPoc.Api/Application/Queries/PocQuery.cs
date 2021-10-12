using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Entities;

namespace GraphQLPoc.Api.Application.Queries
{
    public class PocQuery : ObjectGraphType
    {
        public PocQuery()
        {
            Field<ClubQuery>($"{typeof(Club).Name.ToCamelCase()}Query", resolve: context => new { });
            Field<CompetitionQuery>($"{typeof(Competition).Name.ToCamelCase()}Query", resolve: context => new { });
            Field<GroundQuery>($"{typeof(Ground).Name.ToCamelCase()}Query", resolve: context => new { });
            Field<PlayerQuery>($"{typeof(Player).Name.ToCamelCase()}Query", resolve: context => new { });
        }
    }
}