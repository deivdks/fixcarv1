using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models.Requests
{
    public class AddCarRequest
    {
        [Required(ErrorMessage = "É preciso informar o modelo do carro.")]
        [MinLength(3, ErrorMessage = "É preciso ter ao menos 3 caracteres informados.")]
        [MaxLength(30, ErrorMessage = "Não é possível informar modelo com mais de 30 caracteres")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "É preciso informar o ano do veículo")]
        [Range(1990, 2099, ErrorMessage = "Informe o ano entre 1990 e 2099.")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "É preciso informar a Km atual do veículo.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe corretamente uma Km.")]
        public int Km { get; set; }
        public int FabricanteCarroId { get; set; }
    }
}