using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace EventShareBackend_master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class UsuarioTipoController : ControllerBase
    {
        EventShareContext context = new EventShareContext();
        UsuarioTipoRepositorio repositorio = new UsuarioTipoRepositorio();

        [EnableCors]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioTipoTbl>>> Get() 
        {
            try {
                return await repositorio.Get();
            } catch (System.Exception) {
                throw;
            }
        }

        [EnableCors]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioTipoTbl>> Get(int id) 
        {
            try
            {
                return await repositorio.Get(id);
            }catch(System.Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<UsuarioTipoTbl>> Post(UsuarioTipoTbl usuarioTipoTbl)
        {
            try
            {
                return await repositorio.Post(usuarioTipoTbl);
            }catch(System.Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioTipoTbl>> Put(int id, UsuarioTipoTbl usuarioTipoTbl)
        {
            try
            {
                return await repositorio.Put(id, usuarioTipoTbl);
            }catch(System.Exception)
            {
                throw;
            }
        }

        [EnableCors]
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioTipoTbl>> Delete(int id)
        {
            UsuarioTipoTbl tipoRetornado = await repositorio.Get(id);
            if(tipoRetornado == null)
            {
                return NotFound("Categoria não encontrada");
            }
            await repositorio.Delete(tipoRetornado.TipoId);
            return tipoRetornado;
        }
    }
}