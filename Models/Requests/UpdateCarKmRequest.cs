using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models.Requests
{
    public class UpdateCarKmRequest
    {
        [Required(ErrorMessage = "É preciso informar a Km atual do veículo.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe corretamente uma Km.")]
        public int Km { get; set; }

    }
}