using NycBank.Domain.Commands.Contracts;

namespace NycBank.Domain.Commands
{
    public class CreateCategoriaCommand:ICommand
    {
        public CreateCategoriaCommand()
        {

        }
        public CreateCategoriaCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get;  set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
