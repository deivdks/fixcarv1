using System.ComponentModel.DataAnnotations;
using fixcarv1.Enums;
//using Swashbuckle.AspNetCore.Annotations;

namespace fixcarv1.Models
{

    public class Car
    {

        [Key]
        private int Id {get; set;}

        [Required(ErrorMessage ="É preciso informar o modelo do carro.")]
        [MinLength(3, ErrorMessage ="É preciso ter ao menos 3 caracteres informados.")]
        [MaxLength(30, ErrorMessage ="Não é possível informar modelo com mais de 30 caracteres")]
        private string Modelo{get; set;}

        [Required(ErrorMessage ="É preciso informar o ano do veículo")]
        [Range(1990,2099,ErrorMessage ="Informe o ano entre 1990 e 2099.")]
        private int Ano{get;set;}

        [Required(ErrorMessage ="É preciso informar a Km atual do veículo.")]
        [Range(0, int.MaxValue, ErrorMessage ="Informe corretamente uma Km.")]
        private int Km{get;set;}

        [Required(ErrorMessage ="É obrigatório  informar a fabricante do carro.")]
        private Fabricante FabCarro{get; set;}

        private Transmissao Transmissao{get;set;}

    }

}