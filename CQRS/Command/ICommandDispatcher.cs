using System.Threading.Tasks;

namespace CQRS.Command
{
    public interface ICommandDispatcher
    {
        Task send<T>(T command) where T : class, ICommand;
    }
}