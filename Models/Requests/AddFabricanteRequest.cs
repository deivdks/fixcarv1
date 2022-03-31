using System.ComponentModel.DataAnnotations;
using fixcarv1.Enums;

namespace fixcarv1.Models.Requests
{
    public class AddFabricanteRequest
    {
        [Required(ErrorMessage = "É preciso informar o modelo do carro.")]
        [MinLength(3, ErrorMessage = "É preciso ter ao menos 3 caracteres informados.")]
        [MaxLength(30, ErrorMessage = "Não é possível informar modelo com mais de 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É preciso informar o ano do veículo")]
        [Range(1990, 2099, ErrorMessage = "Informe o ano entre 1990 e 2099.")]
        public int PaisOrigemId { get; set; }

    }
}
