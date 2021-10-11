using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLPoc.Api.Infrastructure.Persistence.MsSql
{
    public class CompetitionRepository : SqlRepositoryBase<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(PocDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Competition GetByName(string name)
        {
            return Query().FirstOrDefault(competition => competition.Name == name);
        }

        public IEnumerable<Competition> GetAllByCountry(Country country)
        {
            return Query().Where(competition => competition.Country == country);
        }
    }
}