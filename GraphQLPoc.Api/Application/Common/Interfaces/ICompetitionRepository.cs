using GraphQLPoc.Api.Application.Entities;
using GraphQLPoc.Api.Application.Entities.Enums;
using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Common.Interfaces
{
    public interface ICompetitionRepository : ISqlRepositoryBase<Competition>
    {
        Competition GetByName(string name);

        IEnumerable<Competition> GetAllByCountry(Country country);
    }
}