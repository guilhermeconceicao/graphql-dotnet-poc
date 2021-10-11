using GraphQL.Server;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Queries;
using GraphQLPoc.Api.Application.Schemas;
using GraphQLPoc.Api.Application.Types;
using GraphQLPoc.Api.Application.Types.Enums;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using GraphQLPoc.Api.Infrastructure.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPoc.Api.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<PocDbContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();
            services.AddTransient<IGroundRepository, GroundRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            return services;
        }

        public static IServiceCollection AddPocGraphql(this IServiceCollection services)
        {
            services.AddGraphQL(options => options.EnableMetrics = false)
                    .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
                    .AddSystemTextJson();

            services.AddTransient<ClubType>();
            services.AddTransient<CompetitionType>();
            services.AddTransient<CountryType>();
            services.AddTransient<GroundType>();
            services.AddTransient<PlayerType>();
            services.AddTransient<PlayerPositionType>();

            services.AddTransient<ClubQuery>();
            services.AddTransient<CompetitionQuery>();
            services.AddTransient<GroundQuery>();
            services.AddTransient<PlayerQuery>();

            services.AddTransient<PocQuery>();
            services.AddTransient<ISchema, PocSchema>();

            return services;
        }
    }
}