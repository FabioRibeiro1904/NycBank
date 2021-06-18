using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace NycBank.Domain.Commands.Contracts
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
            .IsLowerOrEqualsThan(Preco, 0, "Preco", "por gentileza, digite um valor para o produto"));
        }
    }
}
