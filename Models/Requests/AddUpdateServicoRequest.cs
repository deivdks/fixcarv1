using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace fixcarv1.Models.Requests
{
    public class AddUpdateServicoRequest
    {

        [Required(ErrorMessage = "É preciso informar o serviço efetuado.")]
        [MinLength(3, ErrorMessage = "É preciso ter ao menos 3 caracteres informados.")]
        public string ServicoEfetuado { get; set; }

        [Required(ErrorMessage = "É preciso informar a data do começo do serviço.")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "É preciso informar a data do fim do serviço.")]
        public DateTime DataEntrega { get; set; }

        [Required(ErrorMessage = "É preciso informar qual carro está no serviço.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor correto para o carro.")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "É preciso informar qual mecanico está no serviço.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um mecanico correto para o serviço.")]
        public int MecanicaId { get; set; }

        [Required(ErrorMessage = "É preciso informar um, ou mais, produto ao serviço.")]
        public virtual List<AddUpdateProdutoRequest> Produtos{get;set;}
    }
}