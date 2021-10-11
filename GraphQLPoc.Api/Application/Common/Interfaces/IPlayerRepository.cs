using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Common.Interfaces
{
    public interface IPlayerRepository : ISqlRepositoryBase<Player>
    {
        Player GetByName(string name);

        IEnumerable<Player> GetAllCaptain();

        IEnumerable<Player> GetAllByClubIdAndPosition(int clubId, PlayerPosition position);

        IEnumerable<Player> GetAllByClubId(int clubId);
    }
}