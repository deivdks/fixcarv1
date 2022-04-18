using System.ComponentModel.DataAnnotations;
using System;
using fixcarv1.Models.Requests;
using System.Collections.Generic;
using System.Linq;

namespace fixcarv1.Models
{

    public class Servico
    {
        public Servico()
        {
            Produtos = new List<Produto>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É preciso informar a data do começo do serviço.")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "É preciso informar a data do fim do serviço.")]
        public DateTime DataEntrega { get; set; }

        public decimal ValorTotal => Produtos.Sum(p => p.Preco);

        [Required(ErrorMessage = "É preciso informar qual carro está no serviço.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um valor correto para o carro.")]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        [Required(ErrorMessage = "É preciso informar qual mecanica está no serviço.")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe uma mecanica correto para o serviço.")]
        public int MecanicaId { get; set; }

        public virtual Mecanica Mecanica { get; set; }

        [Required(ErrorMessage = "É preciso informar um, ou mais, produto ao serviço.")]
        public virtual List<Produto> Produtos { get; set; }
    }

}