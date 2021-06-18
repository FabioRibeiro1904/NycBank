using Flunt.Notifications;
using Flunt.Validations;
using NycBank.Domain.Commands.Contracts;
using System;

namespace NycBank.Domain.Commands
{
    public class UpdateCategoriaCommand : Notifiable, ICommand
    {
        public UpdateCategoriaCommand()
        {

        }

        public UpdateCategoriaCommand(Guid id, string nome)
        {
            Id = id;
            NomeCategoria = nome;
        }

        public Guid Id { get; set; }
        public string NomeCategoria { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract()
            .HasMinLen(NomeCategoria, 3, "Nome", "Por favor, Coloque o Primeiro e o último nome para pesquisar"));
        }
    }
}
