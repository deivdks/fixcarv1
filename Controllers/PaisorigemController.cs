using Microsoft.AspNetCore.Mvc;
using fixcarv1.Models;
using fixcarv1.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            return await context.PaisOrigem.AsNoTracking().ToListAsync();
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<PaisOrigem>> Post([FromServices] DataContext context, [FromBody] PaisOrigem request)
        {
            PaisOrigem pais = new PaisOrigem();
            pais.Nome=request.Nome;

            if (ModelState.IsValid)
            {
                context.PaisOrigem.Add(pais);
                await context.SaveChangesAsync();
                return pais;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}