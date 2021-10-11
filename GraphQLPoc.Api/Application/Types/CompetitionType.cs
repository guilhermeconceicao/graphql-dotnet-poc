using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Enums;

namespace GraphQLPoc.Api.Application.Types
{
    public class CompetitionType : ObjectGraphType<Competition>
    {
        public CompetitionType(IClubRepository clubRepository)
        {
            Field(x => x.Id);
            Field<CountryType>(nameof(Competition.Country));
            Field(x => x.Name);
            Field(x => x.StartDate);
            Field(x => x.EndDate);
            Field<ListGraphType<ClubType>>("clubs", resolve: context => { return clubRepository.GetAllByCompetitionId(context.Source.Id); });
        }
    }
}