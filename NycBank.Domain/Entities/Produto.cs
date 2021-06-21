using System;
using System.Collections.Generic;

namespace NycBank.Domain.Entities
{
    public class Produto 
    {

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            this.Categorias = new List<Categoria>();
        }

        public Guid ProdutoId { get; private set; }

        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public IList<Categoria> Categorias { get; private set; }

        public void UpdateProduto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public bool AddCategoria(Produto produto, Categoria categoria)
        {

            var categoriaNaoExiste = true;
            int i = 0;

            while (categoriaNaoExiste && produto.Categorias.Count > 0 && i < produto.Categorias.Count)
            {
                if (produto.Categorias[i].CategoriaId == categoria.CategoriaId)
                {
                    categoriaNaoExiste = false;
                }
                i++;

            }
            if (categoriaNaoExiste)
                Categorias.Add(categoria);

            return categoriaNaoExiste;

        }
    }
}