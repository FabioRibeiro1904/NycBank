using NycBank.Domain.Commands.Contracts;

namespace NycBank.Domain.Commands
{
    public class UpdateCategoriaCommand : ICommand
    {
        public UpdateCategoriaCommand()
        {

        }
        public string NomeCategoria { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
