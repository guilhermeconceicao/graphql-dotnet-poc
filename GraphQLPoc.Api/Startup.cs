using GraphiQl;
using GraphQL.Types;
using GraphQLPoc.Api.Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLPoc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration.GetConnectionString("PocGraphqlDBConnection"));
            services.AddPocGraphql();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}