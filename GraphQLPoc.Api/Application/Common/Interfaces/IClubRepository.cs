using GraphQLPoc.Api.Application.Entities;
using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Common.Interfaces
{
    public interface IClubRepository : ISqlRepositoryBase<Club>
    {
        Club GetByName(string name);

        Club GetByNickame(string nickname);

        IEnumerable<Club> GetAllByCompetitionId(int competitionId);
    }
}