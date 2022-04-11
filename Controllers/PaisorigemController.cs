using Microsoft.AspNetCore.Mvc;
using fixcarv1.Models;
using fixcarv1.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using fixcarv1.Models.Requests;

namespace fixcarv1.Controllers
{
    [ApiController]
    [Route("v1/paises")]
    public class PaisOrigemController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PaisOrigem>>> Get([FromServices] DataContext context)
        {
            return await context.PaisesOrigem.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<PaisOrigem>> Post([FromServices] DataContext context, [FromBody] AddUpdatePaisOrigemRequest request)
        {
            PaisOrigem pais = new PaisOrigem();
            pais.Nome=request.Nome;

            if (ModelState.IsValid)
            {
                context.PaisesOrigem.Add(pais);
                await context.SaveChangesAsync();
                return pais;
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
            var pais = await context.PaisesOrigem.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (pais == null)
            {
                return BadRequest("País não encontrado");
            }
            context.PaisesOrigem.Remove(pais);
            await context.SaveChangesAsync();
            return Ok();
        }

           [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<PaisOrigem>> Put([FromServices] DataContext context, [FromBody] AddUpdatePaisOrigemRequest request, [FromRoute] int id)
        {
            var paisdb = await context.PaisesOrigem.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (paisdb == null)
            {
                return BadRequest("País não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            paisdb.Nome=request.Nome;
            context.PaisesOrigem.Update(paisdb);
            await context.SaveChangesAsync();
            return paisdb;
        }

    }
}