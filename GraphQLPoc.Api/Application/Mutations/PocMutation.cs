using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Entities;

namespace GraphQLPoc.Api.Application.Mutations
{
    public class PocMutation : ObjectGraphType
    {
        public PocMutation()
        {
            Field<ClubMutation>($"{typeof(Club).Name.ToCamelCase()}Mutation", resolve: context => new { });
            Field<CompetitionMutation>($"{typeof(Competition).Name.ToCamelCase()}Mutation", resolve: context => new { });
            Field<GroundMutation>($"{typeof(Ground).Name.ToCamelCase()}Mutation", resolve: context => new { });
            Field<PlayerMutation>($"{typeof(Player).Name.ToCamelCase()}Mutation", resolve: context => new { });
        }
    }
}