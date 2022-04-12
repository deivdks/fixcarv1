
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
    [Route("v1/mecanicas")]
    public class MecanicaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Mecanica>>> Get([FromServices] DataContext context)
        {
            return await context.Mecanicas.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Mecanica>> Post([FromServices] DataContext context, [FromBody] AddUpdateMecanicaRequest request)
        {
            var mecanica = new Mecanica();
            mecanica.Nome = request.Nome;
            mecanica.Endereco = request.Endereco;
            mecanica.Telefone = request.Telefone;
            
            if (ModelState.IsValid)
            {
                context.Mecanicas.Add(mecanica);
                await context.SaveChangesAsync();
                return mecanica;
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
            var mecanica = await context.Mecanicas.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (mecanica == null)
            {
                return BadRequest("Mecânica não encontrada");
            }
            context.Mecanicas.Remove(mecanica);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Mecanica>> Put([FromServices] DataContext context, [FromBody] AddUpdateMecanicaRequest request, [FromRoute] int id)
        {
            var mecanicadb = await context.Mecanicas.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (mecanicadb == null)
            {
                return BadRequest("Mecânica não encontrada");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mecanicadb.Nome = request.Nome;
            mecanicadb.Endereco = request.Endereco;
            mecanicadb.Telefone = request.Telefone;
            context.Mecanicas.Update(mecanicadb);
            await context.SaveChangesAsync();
            return mecanicadb;
        }
    }
}