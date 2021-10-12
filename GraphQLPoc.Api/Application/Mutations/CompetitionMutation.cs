using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Mutations;

namespace GraphQLPoc.Api.Application.Mutations
{
    public class CompetitionMutation : MutationBase<ICompetitionRepository, Competition, CompetitionInputType>
    {
        public CompetitionMutation(ICompetitionRepository repository) : base(repository)
        {
        }
    }
}