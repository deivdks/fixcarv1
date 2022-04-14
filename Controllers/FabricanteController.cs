using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fixcarv1.Data;
using fixcarv1.Models;
using System.Linq;
using fixcarv1.Models.Requests;

namespace fixcarv1.Controllers
{
    [ApiController]
    [Route("v1/fabricantes")]
    public class FabricantesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fabricante>>> Get([FromServices] DataContext context)
        {
            return await context.Fabricantes.AsNoTracking().ToListAsync();
        }
      
        [HttpGet]
        [Route("cars/{id:int}")]
        public async Task<ActionResult<List<Car>>> GetCars([FromServices] DataContext context, int id)
        {

            return await context.Cars.Include(c => c.FabricanteCarro)
                                     .Where(c => c.FabricanteCarroId == id).ToListAsync();   
            
        }

        [HttpGet]
        [Route("carsfabricante/{id:int}")]
        public async Task<ActionResult<Fabricante>> GetCarsFabricante([FromServices] DataContext context, int id)
        {
                                            //Include serve como uma espécie de JOIN com outra tabela (que esteja dentro da classe como objeto)
            return await context.Fabricantes.Include(i => i.Carros)
                                            .Where(i => 
                                                   i.Id == id).FirstOrDefaultAsync();
             
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fabricante>> Post([FromServices] DataContext context, [FromBody] AddUpdateFabricanteRequest request)
        {
            var fabricante = new Fabricante();
            fabricante.Nome = request.Nome;
            fabricante.PaisOrigemId = request.PaisOrigemId;
            
            if (ModelState.IsValid)
            {
                context.Fabricantes.Add(fabricante);
                await context.SaveChangesAsync();
                return fabricante;
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
            var fabricante = await context.Fabricantes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (fabricante == null)
            {
                return BadRequest("Fabricante não encontrado");
            }
            context.Fabricantes.Remove(fabricante);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Fabricante>> Put([FromServices] DataContext context, [FromBody] AddUpdateFabricanteRequest request, [FromRoute] int id)
        {
            var fabricantedb = await context.Fabricantes.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (fabricantedb == null)
            {
                return BadRequest("Fabricante não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            fabricantedb.Nome=request.Nome;
            fabricantedb.PaisOrigemId=request.PaisOrigemId;
            context.Fabricantes.Update(fabricantedb);
            await context.SaveChangesAsync();
            return fabricantedb;
        }

    }
}