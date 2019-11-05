using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        EventShareContext context = new EventShareContext();
        StatusRepositorio repositorio = new StatusRepositorio();
        
        [HttpGet]
        public async Task<ActionResult<List<EventoStatusTbl>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
             catch(System.Exception)
            {
                 throw;
            }
         }
       [HttpGet("{nome}")]
       public async Task<ActionResult<EventoStatusTbl>> Get(string nome)
       {
           EventoStatusTbl eventoRetornada = await context.EventoStatusTbl.FirstOrDefaultAsync(s => s.EventoStatusNome == nome);
           if(eventoRetornada == null)
           {
               return NotFound();
           }
           return eventoRetornada;
       }
    }
}