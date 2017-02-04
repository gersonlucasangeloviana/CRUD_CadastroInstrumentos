using Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrumentos.Repositories
{
public  interface ITipoRepository
    {
        void Cadastrar(Tipo tipo);

        List<Tipo> Listar();
    }
}
