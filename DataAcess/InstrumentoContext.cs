using Instrumentos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Instrumentos.DataAcess
{
    public class InstrumentoContext : DbContext
    {
        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Instrumento> Instrumentos { get; set; }
    }
}