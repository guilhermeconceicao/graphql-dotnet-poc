using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLPoc.Api.Infrastructure.Persistence.MsSql
{
    public class ClubRepository : SqlRepositoryBase<Club>, IClubRepository
    {
        public ClubRepository(PocDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Club GetByName(string name)
        {
            return Query().FirstOrDefault(club => club.Name == name);
        }

        public Club GetByNickame(string nickname)
        {
            return Query().FirstOrDefault(club => club.Nickname == nickname);
        }

        public IEnumerable<Club> GetAllByCompetitionId(int competitionId)
        {
            return Query().Where(club => club.CompetitionId == competitionId);
        }
    }
}