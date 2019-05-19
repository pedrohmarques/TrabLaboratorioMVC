using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova1.Models
{
    public class Compra
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço!")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o broker!")]
        public string Broker { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Ação!")]
        public int Acao { get; set; }
    }
}
