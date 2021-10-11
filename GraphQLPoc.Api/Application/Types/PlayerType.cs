using GraphQL.Types;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Types.Enums;

namespace GraphQLPoc.Api.Application.Types
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<PlayerPositionType>(nameof(Player.Position));
            Field(x => x.Captain);

            Field(x => x.ClubId);
            Field<ClubType>(nameof(Player.Club));
        }
    }
}