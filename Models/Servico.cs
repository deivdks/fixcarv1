using System.ComponentModel.DataAnnotations;
using System;
namespace fixcarv1.Models
{

    public class Servico
    {
        [Key]
        public int Id{get; set;}

        [Required(ErrorMessage ="É preciso informar a data do começo do serviço.")]
        public DateTime DataEntrada{get; set;}

        
        [Required(ErrorMessage ="É preciso informar a data do fim do serviço.")]
        public DateTime DataEntrega{get; set;}

        [Required(ErrorMessage ="É preciso informar o valor total do serviço.")]
        [Range(0, float.MaxValue, ErrorMessage ="Informe um valor correto para o serviço.")]
        public float ValorTotal{get;set;}

        

    }

}