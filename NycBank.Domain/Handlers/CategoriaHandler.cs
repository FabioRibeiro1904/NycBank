using NycBank.Domain.Commands;
using NycBank.Domain.Commands.Contracts;
using NycBank.Domain.Entities;
using NycBank.Domain.Handlers.Contracts;
using NycBank.Domain.Repository;

namespace NycBank.Domain.Handlers
{
    public class CategoriaHandler : IHandler<CreateCategoriaCommand>, IHandler<UpdateCategoriaCommand>, IHandler<CategoriaAddProdutoCommand>
    {
        private readonly ICategoriaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

            public CategoriaHandler(ICategoriaRepository repository, IProdutoRepository repositoryProduto)
        {
            _repository = repository;
            _produtoRepository = repositoryProduto;
        }

        public ICommandResult Handle(CreateCategoriaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Digite um nome para categoria por gentileza", command.Notifications);


            var validName = _repository.GetName(command.NomeCategoria);
            if (validName != null)
                return new GenericCommandResult(false, "ops,esse nome ja existe", command.Notifications);

            var categoria = new Categoria (command.NomeCategoria);

            _repository.Create(categoria);
            return new GenericCommandResult(true, "Produto criado com sucesso", categoria);
        }

        public ICommandResult Handle(UpdateCategoriaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Verifique os campos preenchidos", command.Notifications);


            var updateCategoria = _repository.GetId(command.Id);
            updateCategoria.UpdateCategoria(command.NomeCategoria);

            _repository.Update(updateCategoria);

            return new GenericCommandResult(true, "Dados alterados com sucesso", updateCategoria);
        }

        public ICommandResult Handle(CategoriaAddProdutoCommand command)
        {
            if (command.CategoriaId == null && command.ProdutoId == null)
                return new GenericCommandResult(false, "Selecione um Produto e uma categoria por gentileza", command);

            var categoria = _repository.GetId(command.CategoriaId);
            var produto = _produtoRepository.GetId(command.ProdutoId);


            var categoriaAdd = produto.AddCategoria(produto, categoria);

            if (categoriaAdd)
                return new GenericCommandResult(true, "Categoria cadastrado com sucesso", categoria);

            return new GenericCommandResult(false, "Produto já posssui uma categoria", categoria);

        }
    }
}
