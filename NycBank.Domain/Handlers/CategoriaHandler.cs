using NycBank.Domain.Commands;
using NycBank.Domain.Commands.Contracts;
using NycBank.Domain.Entities;
using NycBank.Domain.Handlers.Contracts;
using NycBank.Domain.Repository;

namespace NycBank.Domain.Handlers
{
    public class CategoriaHandler : IHandler<CreateCategoriaCommand>, IHandler<UpdateCategoriaCommand>
    {
        private readonly ICategoriaRepository _repository;

            public CategoriaHandler(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCategoriaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Digite um nome para categoria por gentileza", command.Notifications);


            var validName = _repository.GetName(command.Nome);
            if (validName != null)
                return new GenericCommandResult(false, "ops,esse nome ja existe", command.Notifications);

            var categoria = new Categoria (command.Nome);

            _repository.Create(categoria);
            return new GenericCommandResult(true, "Produto criado com sucesso", categoria);
        }

        public ICommandResult Handle(UpdateCategoriaCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Verifique os campos preenchidos", command.Notifications);


            var updateCategoria = _repository.GetId(command.Id);
            updateCategoria.UpdateCategoria(command.Nome);

            _repository.Update(updateCategoria);

            return new GenericCommandResult(true, "Dados alterados com sucesso", updateCategoria);
        }
    }
}
