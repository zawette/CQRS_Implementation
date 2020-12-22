using CQRS.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CQRS
{
    public static class Extensions
    {
        private static IServiceCollection addTransientClassesOfType(this IServiceCollection serviceCollection, Type type)
        {
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

        public static IServiceCollection addCommandHandlers(this IServiceCollection serviceCollection)
        {
            var type = typeof(IQueryHandler<>);
            return serviceCollection.addTransientClassesOfType(type);
        }

        public static IServiceCollection addQueryHandlers(this IServiceCollection serviceCollection)
        {
            var type = typeof(IQueryHandler<>);
            return serviceCollection.addTransientClassesOfType(type);
 
        }

        public static IServiceCollection addComandDispatcher(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
    }
}