using Flunt.Notifications;
using Flunt.Validations;
using NycBank.Domain.Commands.Contracts;

namespace NycBank.Domain.Commands
{
    public class CreateCategoriaCommand: Notifiable, ICommand
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
            AddNotifications(
             new Contract()
            .HasMinLen(Nome, 3, "Nome", "Por favor, Coloque o Primeiro e o último nome para pesquisar"));
        }
    }
}
