using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLPoc.Api.Application.Mutations;
using GraphQLPoc.Api.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLPoc.Api.Application.Schemas
{
    public class PocSchema : Schema
    {
        public PocSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<PocQuery>();
            Mutation = serviceProvider.GetRequiredService<PocMutation>();
        }
    }
}