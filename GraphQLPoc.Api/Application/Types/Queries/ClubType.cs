using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;

namespace GraphQLPoc.Api.Application.Queries.Types
{
    public class ClubType : ObjectGraphType<Club>
    {
        public ClubType(IPlayerRepository playerRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Nickname);
            Field(x => x.Manager);

            Field(x => x.CompetitionId);
            Field<CompetitionType>(nameof(Club.Competition));

            Field(x => x.GroundId);
            Field<GroundType>(nameof(Club.Ground));

            Field(x => x.RivalId, nullable: true);
            Field<ClubType>(nameof(Club.Rival));

            Field<ListGraphType<PlayerType>>("squad", resolve: context => { return playerRepository.GetAllByClubId(context.Source.Id); });
        }
    }
}