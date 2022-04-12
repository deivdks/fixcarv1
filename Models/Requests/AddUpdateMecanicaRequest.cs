using System.ComponentModel.DataAnnotations;

namespace  fixcarv1.Models.Requests
{

    public class AddUpdateMecanicaRequest
    {
        [Required(ErrorMessage ="É preciso informar o nome da mecânica")]
        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o nome da mecânica.")]
        public string Nome {get;set;}

        [MinLength(3,ErrorMessage ="É preciso informar ao menos três caracteres para o endereço da mecânica.")]
        public string Endereco {get;set;}

        [MinLength(3,ErrorMessage ="É preciso informar ao menos três dígitos para o telefone da mecânica.")]
        public string Telefone {get;set;}
    }


}