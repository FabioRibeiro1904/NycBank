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

        void Update(Produto produto);

        void Delete(Guid id);
    }
}
