using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CQRS.Query
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> SendAsync<TQuery, TResult>(TQuery Query) where TQuery : class, IQuery<TResult>
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var queryHandler = scope.ServiceProvider.GetService<IQueryHandler<TQuery, TResult>>();
                return await queryHandler.handleAsync(Query);
            }
        }
    }
}