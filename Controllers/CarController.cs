using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fixcarv1.Data;
using fixcarv1.Models;

namespace fixcarv1.Controllers
{
    [ApiController]
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
        public async Task<ActionResult<Car>> Post([FromServices] DataContext context,[FromBody] Car car)
        {
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

    }

}