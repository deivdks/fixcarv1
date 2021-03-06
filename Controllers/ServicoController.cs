using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fixcarv1.Data;
using fixcarv1.Models;
using fixcarv1.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fixcarv1.Controllers
{
    [ApiController]
    [Route("v1/servicos")]
    public class ServicoController : ControllerBase
    {
        [HttpGet]   
        [Route("")]
        public async Task<ActionResult<List<Servico>>> Get([FromServices] DataContext context)
        {
            return await context.Servicos.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Servico>> Post([FromServices] DataContext context, [FromBody] AddUpdateServicoRequest request)
        {
            var servico = new Servico();
            servico.DataEntrada=request.DataEntrada;
            servico.DataEntrega=request.DataEntrega;
            servico.CarId=request.CarId;
            servico.MecanicaId=request.MecanicaId;
            
            foreach (var item in request.Produtos)
            {
                var produto = new Produto();
                produto.Nome=item.Nome;
                produto.Preco=item.Preco;
                produto.TipoProduto=item.TipoProduto;
                servico.Produtos.Add(produto); 
                    //Atribuição do id serviço aos produtos é automatico, por estar dentro do serviço a lista de produtos
            }
            
            if (ModelState.IsValid)
            {
                context.Servicos.Add(servico);
                await context.SaveChangesAsync();
                return servico;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete([FromServices] DataContext context, [FromRoute] int id)
        {
            var servico = await context.Servicos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (servico == null)
            {
                return BadRequest("Mecânica não encontrada");
            }
            context.Servicos.Remove(servico);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Servico>> Put([FromServices] DataContext context, [FromBody] AddUpdateServicoRequest request, [FromRoute] int id)
        {
            var servico = await context.Servicos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (servico == null)
            {
                return BadRequest("Serviço não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            servico.DataEntrada=request.DataEntrada;
            servico.DataEntrega=request.DataEntrega;
            servico.CarId=request.CarId;
            servico.MecanicaId=request.MecanicaId;
            context.Servicos.Update(servico);
            await context.SaveChangesAsync();
            return servico;
        }
    }
}