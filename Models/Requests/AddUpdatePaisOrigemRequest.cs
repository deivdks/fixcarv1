using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models.Requests
{
    public class AddUpdatePaisOrigemRequest
    {
        [Required(ErrorMessage ="É preciso informar o nome do país")]
        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o nome do país.")]
        public string Nome {get;set;}
    }
}
