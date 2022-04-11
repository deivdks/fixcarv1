using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models.Requests
{
    public class AddUpdateFabricanteRequest
    {
        [Required(ErrorMessage = "É preciso informar o modelo do carro.")]
        [MinLength(3, ErrorMessage = "É preciso ter ao menos 3 caracteres informados.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É preciso informar o ano do veículo")]
        public int PaisOrigemId { get; set; }

    }
}
