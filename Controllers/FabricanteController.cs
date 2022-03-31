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

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fabricante>> Post([FromServices] DataContext context, [FromBody] AddFabricanteRequest request)
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

//TODO:
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Car>> Put([FromServices] DataContext context, [FromBody] UpdateCarRequest request, [FromRoute] int id)
        {
            var cardb = await context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (cardb == null)
            {
                return BadRequest("Carro não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cardb.Modelo = request.Modelo;
            cardb.Ano = request.Ano;
            cardb.Km = request.Km;
            cardb.FabricanteCarroId = request.FabricanteCarroId;
            cardb.Transmissao = request.Transmissao;
            context.Cars.Update(cardb);
            await context.SaveChangesAsync();
            return cardb;
        }

        [HttpPut]
        [Route("km/{id:int}")]
        public async Task<ActionResult<Car>> PutKm([FromServices] DataContext context, [FromBody] UpdateCarKmRequest request, [FromRoute] int id)
        {
            var cardb = await context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (cardb == null)
            {
                return BadRequest("Carro não encontrado");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cardb.Km = request.Km;
            context.Cars.Update(cardb);
            await context.SaveChangesAsync();
            return cardb;
        }
    }
}