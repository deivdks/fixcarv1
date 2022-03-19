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
    [Route("v1/cars")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Car>>> Get([FromServices] DataContext context)
        {
            return await context.Cars.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Car>> Post([FromServices] DataContext context, [FromBody] AddCarRequest request)
        {
            var car = new Car();
            car.Modelo = request.Modelo;
            car.Ano = request.Ano;
            car.Km = request.Km;
            car.FabricanteCarroId = request.FabricanteCarroId;
            car.Transmissao = request.Transmissao;

            if (ModelState.IsValid)
            {
                context.Cars.Add(car);
                await context.SaveChangesAsync();
                return car;
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
            var car = await context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (car == null)
            {
                return BadRequest("Carro não encontrado");
            }
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
            return Ok();
        }


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


    }

}