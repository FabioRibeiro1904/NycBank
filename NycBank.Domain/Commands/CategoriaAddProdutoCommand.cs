using NycBank.Domain.Commands.Contracts;
using System;

namespace NycBank.Domain.Commands
{
    public class CategoriaAddProdutoCommand : ICommand
    {
        public CategoriaAddProdutoCommand()
        {

        }

        public CategoriaAddProdutoCommand(Guid produtoId, Guid categoriaId)
        {
            ProdutoId = produtoId;
            CategoriaId = categoriaId;
        }

        public Guid ProdutoId { get; set; }

        public Guid CategoriaId { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
