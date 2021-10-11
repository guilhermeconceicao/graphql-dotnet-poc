using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using System.Linq;

namespace GraphQLPoc.Api.Infrastructure.Persistence.MsSql
{
    public class GroundRepository : SqlRepositoryBase<Ground>, IGroundRepository
    {
        public GroundRepository(PocDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Ground GetByName(string name)
        {
            return Query().FirstOrDefault(ground => ground.Name == name);
        }
    }
}