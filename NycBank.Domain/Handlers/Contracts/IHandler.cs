using NycBank.Domain.Commands.Contracts;

namespace NycBank.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
