using Flunt.Notifications;
using Flunt.Validations;
using NycBank.Domain.Commands.Contracts;
using System;

namespace NycBank.Domain.Commands
{
    public class CreateProdutoCommand: Notifiable, ICommand
    {
        public CreateProdutoCommand()
        {

        }

        public CreateProdutoCommand(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public string Nome { get;  set; }

        public decimal Preco { get;  set; }

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
