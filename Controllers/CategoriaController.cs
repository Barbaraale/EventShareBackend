using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        EventShareContext context = new EventShareContext();
        CategoriaRepositorio repositorio = new CategoriaRepositorio();
        
        /// <summary>
        /// Método lista todas as categorias de evento existentes
        /// </summary>
        /// <returns>Retorna a lista de categorias</returns>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<EventoCategoriaTbl>>> Get()
        {
            try{

                return await repositorio.Get();

            }catch(System.Exception)
            {
                throw;
            }            
        }

        /// <summary>
        /// Método lista eventos pela sua categoria
        /// </summary>
        /// <returns>Retorna a lista de categorias</returns>
        /// <param name="categoriaNome"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet("{CategoriaNome}")]
       public async Task<ActionResult<EventoCategoriaTbl>> Get(string categoriaNome)
       {
          EventoCategoriaTbl categoriaRetornada = await context.EventoCategoriaTbl.Where(c => c.CategoriaNome.Contains(categoriaNome)).FirstOrDefaultAsync();
           if(categoriaRetornada == null)
           {
               return NotFound();
           }
           return categoriaRetornada;
       }

        /// <summary>
        /// Método para criar uma nova categoria, acesso restrito ao administrador
        /// </summary>
        /// <returns>Retorna categoria criada</returns>
        /// <param name="categoria"></param>
        [EnableCors]
        // [Authorize(Roles = "Administrador")]
        [HttpPost]
       public async Task<ActionResult<EventoCategoriaTbl>> Post(EventoCategoriaTbl categoria)
       {
           try
           {
               return await repositorio.Post(categoria);
           }
           catch (System.Exception)
           {
               
               throw;
           }
       }

        /// <summary>
        /// Método para atualizar uma categoria existente, acesso restrito ao administrador
        /// </summary>
        /// <returns>Retorna categoria atualizada</returns>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
       [EnableCors]
    //    [Authorize(Roles = "Administrador")]
       [HttpPut("{id}")]
       public async Task<ActionResult> Put(int id, EventoCategoriaTbl categoria)
       {
           EventoCategoriaTbl categoriaRetornada = await context.EventoCategoriaTbl.FindAsync(id);
          if(categoriaRetornada == null)
          {
              return NotFound();
          }
          categoriaRetornada.CategoriaNome = categoria.CategoriaNome;
          context.EventoCategoriaTbl.Update(categoriaRetornada);
          await context.SaveChangesAsync();

          return Ok();

       }

        /// <summary>
        /// Método para deletar uma categoria existente, acesso restrito ao administrador
        /// </summary>
        /// <returns>Retorna categoria deletada</returns>
        /// <param name="id"></param>
       [EnableCors]
    //    [Authorize(Roles = "Administrador")]
       [HttpDelete("{id}")]
       public async Task<ActionResult<EventoCategoriaTbl>> Delete(int id)
       {
           EventoCategoriaTbl categoriaRetornada = await context.EventoCategoriaTbl.FindAsync(id);
           if (categoriaRetornada == null)
           {
               return NotFound();
           }
           context.EventoCategoriaTbl.Remove(categoriaRetornada);
           await context.SaveChangesAsync();

           return categoriaRetornada;

       }
    }
}