using System.ComponentModel.DataAnnotations;

namespace TesteCedro.Models
{
    public class Produto
    {
        [Required]
        public int IDProduto { get; set; }

        [Required]
        [Display(Name = "NOME DO PRODUTO")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "DESCRIÇÃO O PRODUTO")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "PREÇO DO PRODUTO")]
        public float Valor { get; set; }

        [Required]
        [Display(Name = "LINK DA IMAGEM DO PRODUTO")]
        public string Imagem { get; set; }

    }
}
