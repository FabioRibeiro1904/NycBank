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
            command.Validate();
            if (command.Invalid)
            return new GenericCommandResult(false, "ops, por gentileza verifique os campos.", command.Notifications);

            var validName = _repository.GetName(command.Nome);


            if (validName != null)
                return new GenericCommandResult(false, "ops,esse nome ja existe", command.Notifications);

            _repository.Create(validName);
                return new GenericCommandResult(true, "Produto criado com sucesso", validName);

   }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Verifique os campos preenchidos", command.Notifications);


           var updateProduto = _repository.GetName(command.Nome);
            updateProduto.UpdateProduto(command.Nome, command.Preco);
            return new GenericCommandResult(true, "Dados alterados com sucesso", updateProduto);
                    
        }
    }
}
