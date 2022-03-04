using System.ComponentModel.DataAnnotations;
//using Swashbuckle.AspNetCore.Annotations;

namespace fixcarv1.Models
{
    public class Fabricante
    {
        [Key]
        private int Id{get;set;}
        
        [Required(ErrorMessage ="É preciso informar o nome da fabricante")]
        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o nome da fabricante.")]
        private string Nome {get;set;}

        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o nome da fabricante.")]
        private string paisOrigem{get;set;}

    }
}