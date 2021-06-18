using Flunt.Notifications;
using Flunt.Validations;
using NycBank.Domain.Commands.Contracts;
using System;

namespace NycBank.Domain.Commands
{
    public class UpdateProdutoCommand: Notifiable, ICommand
    {
        public UpdateProdutoCommand()
        {

        }
        public UpdateProdutoCommand(Guid id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract()
            .HasMinLen(Nome, 3, "Nome", "Por favor, Coloque o Primeiro e o último nome para pesquisar")
            .IsGreaterThan(Preco, 0, "Preco", "Por favor, digite um valor maior que zero")
            .IsNullOrNullable(Preco, "Preco", "Por gentileza, digite um valor."));
        }
    }
}
