using System.Collections.Generic;

namespace NycBank.Domain.Entities
{
    public class Produto: Entity
    {
        private IList<Categoria> _categoria;
        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            Categorias = _categoria;
        }

        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public IList<Categoria> Categorias { get; private set; }

        public void UpdateProduto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public void AddCategoria(Categoria categoria)
        {
            _categoria.Add(categoria);
        }
    }
}
