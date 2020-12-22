using System.Threading.Tasks;

namespace CQRS.Query
{
    public interface IQueryDispatcher
    {
        public Task<TResult> SendAsync<TQuery, TResult>(TQuery Query) where TQuery : class, IQuery<TResult>;
    }
}