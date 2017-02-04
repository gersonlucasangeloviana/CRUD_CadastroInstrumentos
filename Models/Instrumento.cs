using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Instrumentos.Models
{
    public class Instrumento
    {
        public int InstrumentoId { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(maximumLength: 150, ErrorMessage = "Máximo de 150")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Range(minimum: 1990, maximum: 2018, ErrorMessage = "Ano inválido")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFab { get; set; }
        [Display(Name = "Valor R$")]
        public Double Valor { get; set; }
        public Tipo Tipo { get; set; }
        public int TipoId { get; set; }
    }

}