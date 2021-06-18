using System.Collections.Generic;
using System.Linq;

namespace NycBank.Domain.Entities
{
    public class Categoria : Entity
    {
        private IList<Produto> _produto;

        public Categoria(string nome)
        {
            Nome = nome;
            _produto = new List<Produto>();
        }

        public string Nome { get; private set; }

        public IReadOnlyCollection<Produto> Produtos { get { return _produto.ToArray(); } }


        public void UpdateCategoria(string nome)
        {
            Nome = nome;
        }


    }
}