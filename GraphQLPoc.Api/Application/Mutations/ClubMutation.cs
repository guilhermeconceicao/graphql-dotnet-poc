using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Mutations;

namespace GraphQLPoc.Api.Application.Mutations
{
    public class ClubMutation : MutationBase<IClubRepository, Club, ClubInputType>
    {
        public ClubMutation(IClubRepository repository) : base(repository)
        {
        }
    }
}