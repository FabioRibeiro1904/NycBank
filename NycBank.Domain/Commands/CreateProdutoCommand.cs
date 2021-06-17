using NycBank.Domain.Commands.Contracts;
using System;

namespace NycBank.Domain.Commands
{
    public class CreateProdutoCommand:ICommand
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
            throw new NotImplementedException();
        }
    }
}
