using CarDealership.Domain.Framework.CommandHandlers;

namespace CarDealership.Domain.Framework.Commands
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : ICommand;
        void AddCommandHandler<T>(T handler) where T : ICommandHandler;
    }
}