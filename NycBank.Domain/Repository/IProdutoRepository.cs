using NycBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NycBank.Domain.Repository
{
    public interface IProdutoRepository
    {
        void Create(Produto produto);

        IEnumerable<Produto> GetList();

        Produto GetName(string name);

        Produto GetId(Guid id);

        void Update(Produto produto);

        void Delete(Guid id);

        //bool ProdutoAddCategoria(Guid idProduto, Guid idCategoria);
    }
}
