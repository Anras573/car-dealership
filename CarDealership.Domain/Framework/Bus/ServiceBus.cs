using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Framework.CommandHandlers;
using CarDealership.Domain.Framework.Commands;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.Framework.QueryHandlers;

namespace CarDealership.Domain.Framework.Bus
{
    public class ServiceBus : ICommandSender, IQueryProcessor
    {

        private readonly Dictionary<Type, ICommandHandler> _commandHandlers = new Dictionary<Type, ICommandHandler>();
        private readonly Dictionary<Type, IQueryHandler> _queryHandlers = new Dictionary<Type, IQueryHandler>();

        public void Send<T>(T command) where T : ICommand
        {
            if (!_commandHandlers.TryGetValue(command.GetType(), out var handler))
            {
                throw new ArgumentException($"No command handler is registered for command of type {command.GetType().Name}.");
            }

            ((dynamic) handler).Handle((dynamic) command);
        }

        public void AddCommandHandler<T>(T handler) where T : ICommandHandler
        {
            var genericHandler = typeof(ICommandHandler<>);
            var supportedCommandTypes = handler.GetType()
                .GetInterfaces()
                .Where(o => o.IsGenericType && o.GetGenericTypeDefinition() == genericHandler)
                .Select(o => o.GetGenericArguments().First())
                .ToList();

            if (_commandHandlers.Keys.Any(o => supportedCommandTypes.Contains(o)))
            {
                throw new ArgumentException($"The command handled by the received handler {handler.GetType().Name} already has a registered handler.");
            }

            foreach (var commandType in supportedCommandTypes)
            {
                _commandHandlers.Add(commandType, handler);
            }
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            if (!_queryHandlers.TryGetValue(query.GetType(), out var handler))
            {
                throw new ArgumentException($"No query handler is registered for query of type {query.GetType().Name}.");
            }

            return ((dynamic)handler).Handle((dynamic)query);
        }

        public void AddQueryProcessor<T>(T processor) where T : IQueryHandler
        {
            var genericHandler = typeof(IQueryHandler<,>);
            var supportedQueryTypes = processor.GetType()
                .GetInterfaces()
                .Where(o => o.IsGenericType && o.GetGenericTypeDefinition() == genericHandler)
                .Select(o => o.GetGenericArguments().First())
                .ToList();

            if (_queryHandlers.Keys.Any(o => supportedQueryTypes.Contains(o)))
            {
                throw new ArgumentException($"The query processed by the received processor {processor.GetType().Name} already has a registered processor.");
            }

            foreach (var queryType in supportedQueryTypes)
            {
                _queryHandlers.Add(queryType, processor);
            }
        }
    }
}