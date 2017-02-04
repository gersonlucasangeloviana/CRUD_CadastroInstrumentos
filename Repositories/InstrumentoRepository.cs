using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Instrumentos.Models;
using Instrumentos.DataAcess;

namespace Instrumentos.Repositories
{
    public class InstrumentoRepository : IInstumentoRepository
    {
        private InstrumentoContext _context;
        public InstrumentoRepository(InstrumentoContext context)
        {
            this._context = context;
        }
        public void Atualizar(Instrumento instrumento)
        {
            _context.Entry(instrumento).State = System.Data.Entity.EntityState.Modified;
        }

        public List<Instrumento> BuscarPor(Expression<Func<Instrumento, bool>> filtro)
        {
            return _context.Instrumentos.Where(filtro).ToList();
        }

        public void Cadastrar(Instrumento instrumento)
        {
            _context.Instrumentos.Add(instrumento);
        }

        public Instrumento Consultar(int id)
        {
           return _context.Instrumentos.Find(id);
        }

        public List<Instrumento> Listar()
        {
            return _context.Instrumentos.Include("Tipo").ToList();
        }

        public void Remover(int id)
        {
            var instrumento = Consultar(id);
            _context.Instrumentos.Remove(instrumento);
        }
    }
}