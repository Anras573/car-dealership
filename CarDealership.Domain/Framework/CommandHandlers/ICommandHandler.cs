using CarDealership.Domain.Framework.Commands;

namespace CarDealership.Domain.Framework.CommandHandlers
{
    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    public interface ICommandHandler { }

    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}