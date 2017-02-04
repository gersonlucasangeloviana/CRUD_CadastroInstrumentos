using Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Instrumentos.Repositories
{
public   interface IInstumentoRepository
    {
        void Cadastrar(Instrumento instrumento);
        void Atualizar(Instrumento instrumento);
        Instrumento Consultar(int id);
        void Remover(int id);
        // Instrumento Consultar(int id);
        List<Instrumento> Listar();
        List<Instrumento> BuscarPor(Expression<Func<Instrumento, bool>> filtro);
    }
}
