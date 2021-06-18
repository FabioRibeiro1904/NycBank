using NycBank.Domain.Commands;
using NycBank.Domain.Commands.Contracts;
using NycBank.Domain.Entities;
using NycBank.Domain.Handlers.Contracts;
using NycBank.Domain.Repository;

namespace NycBank.Domain.Handlers
{
    public class ProdutoHandler : IHandler<CreateProdutoCommand>, IHandler<UpdateProdutoCommand>, IHandler<ProdutoAddCategoriaCommand>
    {
        private readonly IProdutoRepository _repository;
        private readonly ICategoriaRepository _repositoryCategory;

        public ProdutoHandler(IProdutoRepository repository, ICategoriaRepository categoriaRepository)
        {
            _repository = repository;
            _repositoryCategory = categoriaRepository;
        }
        public ICommandResult Handle(CreateProdutoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            return new GenericCommandResult(false, "ops, por gentileza verifique os campos.", command.Notifications);

            var validName = _repository.GetName(command.Nome);
            if (validName != null)
                return new GenericCommandResult(false, "ops,esse nome ja existe", command.Notifications);


            var produto = new Produto(command.Nome, command.Preco);

            _repository.Create(produto);
                return new GenericCommandResult(true, "Produto criado com sucesso", produto);

   }

        public ICommandResult Handle(UpdateProdutoCommand command)
        {
            command.Validate();
            if(command.Invalid)
            return new GenericCommandResult(false, "Verifique os campos preenchidos", command.Notifications);


           var updateProduto = _repository.GetId(command.Id);
            updateProduto.UpdateProduto(command.Nome, command.Preco);

            _repository.Update(updateProduto);

            return new GenericCommandResult(true, "Dados alterados com sucesso", updateProduto);
                    
        }

        public ICommandResult Handle(ProdutoAddCategoriaCommand command)
        {
            if (command.CategoriaId == null && command.ProdutoId == null)
                return new GenericCommandResult(false, "Selecione um Produto e uma categoria por gentileza", command);

           var produto =  _repository.GetId(command.ProdutoId);
            var categoria = _repositoryCategory.GetId(command.CategoriaId);

            produto.AddCategoria(categoria);

            _repository.Create(produto);

            return new GenericCommandResult(false, "Categoria adicionado no produto com sucesso,", produto);

        }
    }
}
