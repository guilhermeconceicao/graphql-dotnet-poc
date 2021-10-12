using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Mutations;

namespace GraphQLPoc.Api.Application.Mutations
{
    public class PlayerMutation : MutationBase<IPlayerRepository, Player, PlayerInputType>
    {
        public PlayerMutation(IPlayerRepository repository) : base(repository)
        {
        }
    }
}