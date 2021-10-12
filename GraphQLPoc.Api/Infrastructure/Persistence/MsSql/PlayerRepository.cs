using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLPoc.Api.Infrastructure.Persistence.MsSql
{
    public class PlayerRepository : SqlRepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(PocDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override IQueryable<Player> Query()
        {
            return base.Query()
                .Include(x => x.Club);
        }

        public Player GetByName(string name)
        {
            return Query().FirstOrDefault(player => player.Name == name);
        }

        public IEnumerable<Player> GetAllCaptain()
        {
            return Query().Where(player => player.Captain);
        }

        public IEnumerable<Player> GetAllByClubIdAndPosition(int clubId, PlayerPosition position)
        {
            return Query().Where(player => player.ClubId == clubId && player.Position == position);
        }

        public IEnumerable<Player> GetAllByClubId(int clubId)
        {
            return Query().Where(player => player.ClubId == clubId);
        }
    }
}