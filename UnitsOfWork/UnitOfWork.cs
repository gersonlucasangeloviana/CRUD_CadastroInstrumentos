using Instrumentos.DataAcess;
using Instrumentos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Instrumentos.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private InstrumentoContext _context = new InstrumentoContext();
  
        private ITipoRepository _tipoRepository;

        public ITipoRepository TipoRepository
        {
            get
            {
                if (_tipoRepository == null)
                {
                    _tipoRepository = new TipoRepository(_context);
                }
                return _tipoRepository;
            }
   
        }
        private IInstumentoRepository _instrumentoRepository;
        public IInstumentoRepository InstrumentoRepository
        {
            get {
                if(_instrumentoRepository == null)
                {
                    _instrumentoRepository = new InstrumentoRepository(_context);
                }
                return _instrumentoRepository;
            }
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _context.Dispose(); //Libera o recurso
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //Finaliza o UnitOfWork
        }
    }
}