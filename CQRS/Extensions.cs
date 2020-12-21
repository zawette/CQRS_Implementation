using CQRS.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CQRS
{
    public static class Extensions
    {
        public static IServiceCollection addCommandHandlers(this IServiceCollection serviceCollection)
        {
            var type = typeof(ICommandHandler<>);
            var Assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var Types = Assemblies
                .SelectMany(a => a.GetTypes())
                .Where(p => !p.IsAbstract && !p.IsInterface && p.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));
            foreach (var t in Types)
            {
                var interf = t.GetInterface(type.Name);
                serviceCollection.AddTransient(interf, t);
            }
            return serviceCollection;
        }

        public static IServiceCollection addComandDispatcher(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
    }
}