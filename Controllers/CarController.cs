using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fixcarv1.Data;
using fixcarv1.Models;

namespace fixcarv1.Controllers
{
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Car>>> Get([FromServices] DataContext context)
        {
            return await context.Cars.AsNoTracking().ToListAsync();
        }
    }

}