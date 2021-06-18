using NycBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NycBank.Domain.Repository
{
    public interface ICategoriaRepository
    {
        void Create(Categoria categoria);

        IEnumerable<Categoria> GetList();

        Categoria GetName(string name);

        Categoria GetId(Guid id);

        void Update(Categoria categoria);

        void Delete(Guid id);
    }
}
