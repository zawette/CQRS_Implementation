using System.Threading.Tasks;

namespace CQRS.Command
{
    public interface ICommandHandler<T> where T : class, ICommand
    {
        public Task handleAsync(T command);
    }
}