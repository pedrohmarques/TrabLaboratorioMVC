using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova1.Models
{
    public class Acao
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome de Pregão!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Código!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Atividade Principal!")]
        public string Atividade { get; set; }
    }
}
