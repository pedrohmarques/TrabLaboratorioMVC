﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova1.Models
{
    public class Venda
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço!")]

        [Required(ErrorMessage = "Obrigatório informar a quantidade!")]

        [Required(ErrorMessage = "Obrigatório informar o broker!")]

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Ação!")]
    }
}