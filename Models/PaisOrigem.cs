
using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models
{
    public class PaisOrigem
    {
        [Key]
        public int Id{get;set;}
        
        [Required(ErrorMessage ="É preciso informar o nome da fabricante")]
        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o nome da fabricante.")]
        public string Nome {get;set;}
      
    }
}