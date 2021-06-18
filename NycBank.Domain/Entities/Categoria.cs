using System;
using System.Collections.Generic;
using System.Linq;

namespace NycBank.Domain.Entities
{
    public class Categoria
    {
        private IList<Produto> _produto;

        public Categoria(string nome)
        {
            Nome = nome;
            _produto = new List<Produto>();
        }

        public Guid CategoriaId { get; private set; }

        public string Nome { get; private set; }

        public IReadOnlyCollection<Produto> Produtos { get { return _produto.ToArray(); } }


        public void UpdateCategoria(string nome)
        {
            Nome = nome;
        }


    }
}