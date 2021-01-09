using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DominandoAspNetMVCCore.Models
{
    public class Filme
    {

        public int ID { get; set; }

        [Required]
        public string Titutlo { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }

        [Required]
        public Decimal Valor { get; set; }
    }
}
