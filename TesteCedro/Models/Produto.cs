using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    public class Produto
    {
        [Required]
        public int IDProduto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public float Valor { get; set; }

        [Required]
        public string Imagem { get; set; }

    }
}
