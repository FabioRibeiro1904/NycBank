using NycBank.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace NycBank.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> GetName(string nome)
        {
            return x => x.Nome == nome;
        }

        public static Expression<Func<Produto, bool>> GetId(Guid id)
        {
            return x => x.ProdutoId == id;
        }
    }
}
