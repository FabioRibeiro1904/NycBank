using NycBank.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace NycBank.Domain.Queries
{
    public class CategoriaQueries
    {

        public static Expression<Func<Categoria, bool>> GetName(string nome)
        {
            return x => x.Nome == nome;
        }
    }
}
