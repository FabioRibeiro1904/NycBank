using NycBank.Domain.Commands;
using NycBank.Domain.Commands.Contracts;
using NycBank.Domain.Handlers.Contracts;
using NycBank.Domain.Repository;

namespace NycBank.Domain.Handlers
{
    public class ProdutoHandler : IHandler<CreateProdutoCommand>, IHandler<UpdateProdutoCommand>
    {
        private readonly IProdutoRepository _repository;
        public ProdutoHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateProdutoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
