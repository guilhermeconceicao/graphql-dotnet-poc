using GraphQL.Server;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Common.Interfaces;
using GraphQLPoc.Api.Application.Mutations;
using GraphQLPoc.Api.Application.Queries;
using GraphQLPoc.Api.Application.Queries.Types;
using GraphQLPoc.Api.Application.Schemas;
using GraphQLPoc.Api.Application.Types.Enums;
using GraphQLPoc.Api.Application.Types.Mutations;
using GraphQLPoc.Api.Infrastructure.Persistence.Contexts;
using GraphQLPoc.Api.Infrastructure.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPoc.Api.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Infrastructure

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<PocDbContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();
            services.AddTransient<IGroundRepository, GroundRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            return services;
        }

        #endregion Infrastructure

        #region Graphql

        public static IServiceCollection AddPocGraphql(this IServiceCollection services)
        {
            services.AddGraphQL(options => options.EnableMetrics = false)
                    .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
                    .AddSystemTextJson();

            services.AddGraphqlEnumsTypes();
            services.AddGraphqlQueriesTypes();
            services.AddGraphqlMutationsTypes();
            services.AddTransient<ISchema, PocSchema>();

            return services;
        }

        private static IServiceCollection AddGraphqlEnumsTypes(this IServiceCollection services)
        {
            services.AddTransient<CountryType>();
            services.AddTransient<PlayerPositionType>();

            return services;
        }

        private static IServiceCollection AddGraphqlQueriesTypes(this IServiceCollection services)
        {
            services.AddTransient<PocQuery>();

            services.AddTransient<ClubType>();
            services.AddTransient<ClubQuery>();

            services.AddTransient<CompetitionType>();
            services.AddTransient<CompetitionQuery>();

            services.AddTransient<GroundType>();
            services.AddTransient<GroundQuery>();

            services.AddTransient<PlayerType>();
            services.AddTransient<PlayerQuery>();

            return services;
        }

        private static IServiceCollection AddGraphqlMutationsTypes(this IServiceCollection services)
        {
            services.AddTransient<PocMutation>();

            services.AddTransient<ClubInputType>();
            services.AddTransient<ClubMutation>();

            services.AddTransient<CompetitionInputType>();
            services.AddTransient<CompetitionMutation>();

            services.AddTransient<GroundInputType>();
            services.AddTransient<GroundMutation>();

            services.AddTransient<PlayerInputType>();
            services.AddTransient<PlayerMutation>();

            return services;
        }

        #endregion Graphql
    }
}