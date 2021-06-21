using Microsoft.EntityFrameworkCore;
using NycBank.Domain.Entities;
using NycBank.Domain.Queries;
using NycBank.Domain.Repository;
using NycBank.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NycBank.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var delProduto = _context.Produtos.Find(id);
            _context.Produtos.Remove(delProduto);
            _context.SaveChanges();
        }

        public Produto GetName(string name)
        {
            return _context.Produtos.FirstOrDefault(ProdutoQueries.GetName(name));
        }

        public IEnumerable<Produto> GetList()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        public void Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Produto GetId(Guid id)
        {
            return _context.Produtos.Include(x=>x.Categorias).FirstOrDefault(ProdutoQueries.GetId(id));
        }

        public bool CheckCategoria(Guid idProduto, Guid idCategoria)
        {
            var produto = _context.Produtos.Include(x=>x.Categorias).FirstOrDefault(ProdutoQueries.GetId(idProduto));
            var categoria = _context.Categorias.FirstOrDefault(CategoriaQueries.GetId(idCategoria));

            var categoriaNaoExiste = true;
            int i = 0;

            while (categoriaNaoExiste && produto.Categorias.Count > 0 && i < produto.Categorias.Count)
            {
                if (produto.Categorias[i].CategoriaId == idCategoria)
                {
                    categoriaNaoExiste = false;
                }
                i++;

            }

            if (categoriaNaoExiste)
            {
                produto.AddCategoria(categoria);
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
            }
                return categoriaNaoExiste;
        }
        
    }
}
