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
    }
}
