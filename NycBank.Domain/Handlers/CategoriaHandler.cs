using NycBank.Domain.Commands;
using NycBank.Domain.Commands.Contracts;
using NycBank.Domain.Handlers.Contracts;

namespace NycBank.Domain.Handlers
{
    public class CategoriaHandler : IHandler<CreateCategoriaCommand>, IHandler<UpdateProdutoCommand>
    {
        public ICommandResult Handle(CreateCategoriaCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
