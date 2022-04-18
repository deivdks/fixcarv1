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
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post([FromServices] DataContext context, [FromBody] AddUpdateProdutoRequest request)
        {
            var produto = new Produto();
            produto.Nome =request.Nome;
            produto.Preco=request.Preco;
            produto.ServicoId=request.ServicoId;
            produto.TipoProduto=request.TipoProduto;
            
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                await context.SaveChangesAsync();
                return produto;
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
            var produto = await context.Produtos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (produto == null)
            {
                return BadRequest("Produto não encontrado");
            }
            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> Put([FromServices] DataContext context, [FromBody] AddUpdateProdutoRequest request, [FromRoute] int id)
        {
            var produto = await context.Produtos.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (produto == null)
            {
                return BadRequest("Produto não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            produto.Nome =request.Nome;
            produto.Preco=request.Preco;
            produto.ServicoId=request.ServicoId;
            produto.TipoProduto=request.TipoProduto;
            context.Produtos.Update(produto);
            await context.SaveChangesAsync();
            return produto;
        }
    }
}