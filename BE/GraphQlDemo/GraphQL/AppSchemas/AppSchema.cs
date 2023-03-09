using GraphQL.Types;
using GraphQlDemo.GraphQL.Mutations;
using GraphQlDemo.GraphQL.Queries;

namespace GraphQlDemo.GraphQL.AppSchemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
