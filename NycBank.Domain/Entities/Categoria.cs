using System;
using System.Collections.Generic;
using System.Linq;

namespace NycBank.Domain.Entities
{
    public class Categoria
    {

        public Categoria(string nome)
        {
            Nome = nome;
            this.Produtos = new List<Produto>();
        }

        public Guid CategoriaId { get; private set; }

        public string Nome { get; private set; }

        public IList<Produto> Produtos { get; private set; }


        public void UpdateCategoria(string nome)
        {
            Nome = nome;
        }


    }
}