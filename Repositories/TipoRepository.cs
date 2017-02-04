using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Instrumentos.Models;
using Instrumentos.DataAcess;

namespace Instrumentos.Repositories
{
     public class TipoRepository : ITipoRepository
    {
        private InstrumentoContext _context;
        public TipoRepository(InstrumentoContext context)
        {
            _context = context;
        }
        public void Cadastrar(Tipo tipo)
        {
            _context.Tipos.Add(tipo);
        }

        public List<Tipo> Listar()
        {
           return _context.Tipos.ToList();
        }
    }
}