using System.Collections.Generic;
using System.Linq;

namespace NycBank.Domain.Entities
{
    public class Produto: Entity
    {
        private IList<Categoria> _categoria;

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            _categoria = new List<Categoria>();
        }


        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public IReadOnlyCollection<Categoria> Categorias { get { return _categoria.ToArray(); } }

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
