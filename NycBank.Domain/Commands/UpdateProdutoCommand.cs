using System;

namespace NycBank.Domain.Commands.Contracts
{
    public class UpdateProdutoCommand:ICommand
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
            throw new NotImplementedException();
        }
    }
}
