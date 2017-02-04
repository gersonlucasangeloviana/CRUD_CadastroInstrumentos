using System.Collections.Generic;

namespace Instrumentos.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }
        public string Descricao { get; set; }

        public List<Instrumento> instrumentos { get; set; }
    }
}