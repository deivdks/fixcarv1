using System.ComponentModel.DataAnnotations;
using fixcarv1.Enums;

namespace fixcarv1.Models
{
    public class Produto
    {
        [Key]
        public int Id{get;set;}

        [Required(ErrorMessage ="É preciso informar o nome do produto.")]
        [MinLength(3, ErrorMessage ="O nome deve ter ao menos três caracteres informados.")]
        public string Nome{get;set;}

        [Required(ErrorMessage ="É preciso informar o preço do produto.")]
        [Range(0, float.MaxValue, ErrorMessage ="É preciso informar um valor correto ao preço do produto.")]
        public decimal Preco{get;set;}

        [Required(ErrorMessage ="É preciso informar de qual serviço é o produto.")]
        [Range(0, int.MaxValue, ErrorMessage ="É preciso informar um valor correto ao número do serviço.")]
        public int ServicoId{get;set;}
        public Servico Servico{get;set;}
        public TipoProduto TipoProduto{get;set;}
    }
}