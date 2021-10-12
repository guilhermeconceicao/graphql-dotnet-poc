using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Mutations;

namespace GraphQLPoc.Api.Application.Mutations
{
    public class GroundMutation : MutationBase<IGroundRepository, Ground, GroundInputType>
    {
        public GroundMutation(IGroundRepository repository) : base(repository)
        {
        }
    }
}