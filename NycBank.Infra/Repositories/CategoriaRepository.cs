using Microsoft.EntityFrameworkCore;
using NycBank.Domain.Entities;
using NycBank.Domain.Queries;
using NycBank.Domain.Repository;
using NycBank.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NycBank.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;
        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var delCategoria = _context.Categorias.Find(id);
            _context.Categorias.Remove(delCategoria);
        }

        public Categoria GetId(Guid id)
        {
            return _context.Categorias.FirstOrDefault(CategoriaQueries.GetId(id));
        }

        public IEnumerable<Categoria> GetList()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        public Categoria GetName(string name)
        {
            return _context.Categorias.AsNoTracking().FirstOrDefault(CategoriaQueries.GetName(name));
        }

        public void Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
