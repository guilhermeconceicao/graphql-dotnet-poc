using GraphQLPoc.Api.Application.Entities;

namespace GraphQLPoc.Api.Application.Common.Interfaces
{
    public interface IGroundRepository : ISqlRepositoryBase<Ground>
    {
        Ground GetByName(string name);
    }
}