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
            .IsLowerOrEqualsThan(Preco, 0, "Preco", "por gentileza, digite um valor para o produto"));
        }
    }
}
