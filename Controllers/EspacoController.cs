using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspacoController : ControllerBase
    {
      EventShareContext context = new EventShareContext();
        
        /// <summary>
        /// Método para listar os espaços e eventos
        /// </summary>
        /// <returns>Retorna lista de espaços</returns>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet]
       public async Task<ActionResult<List<EventoEspacoTbl>>> Get()
       {
           List<EventoEspacoTbl> listadeEspaco = await context.EventoEspacoTbl.ToListAsync();
           if(listadeEspaco == null)
           {
               return NotFound();
           }

           return listadeEspaco;
       }

        /// <summary>
        /// Método para chamar o espaço de eventos pelo ID
        /// </summary>
        /// <returns>Retorna o evento</returns>
        /// <param name="id"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet("{id}")]
       public async Task<ActionResult<EventoEspacoTbl>> Get(int id)
       {
           EventoEspacoTbl EspacoRetornada = await context.EventoEspacoTbl.FindAsync(id);
           if(EspacoRetornada == null)
           {
               return NotFound();
           }
           return EspacoRetornada;
       }  
    }
}