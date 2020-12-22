using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CQRS.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task send<T>(T command) where T : class, ICommand
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var commandHandler = serviceScope.ServiceProvider.GetService<IQueryHandler<T>>();
               await commandHandler.handleAsync(command);
            }
        }
    }
}