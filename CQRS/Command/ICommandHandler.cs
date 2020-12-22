using System.Threading.Tasks;

namespace CQRS.Command
{
    public interface IQueryHandler<T> where T : class, ICommand
    {
        public Task handleAsync(T command);
    }
}