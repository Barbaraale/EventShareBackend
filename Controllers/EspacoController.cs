using System.Collections.Generic;
using System.Threading.Tasks;
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

       [HttpGet("{id}")]

       public async Task<ActionResult<EventoEspacoTbl>> GetAction(int id)
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