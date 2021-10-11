using GraphQL.Types;

namespace GraphQLPoc.Api.Application.Queries
{
    public class PocQuery : ObjectGraphType
    {
        public PocQuery()
        {
            Field<ClubQuery>("clubQuery", resolve: context => new { });
            Field<CompetitionQuery>("competitionQuery", resolve: context => new { });
            Field<GroundQuery>("groundQuery", resolve: context => new { });
            Field<PlayerQuery>("playerQuery", resolve: context => new { });
        }
    }
}