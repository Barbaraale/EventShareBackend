
using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;

namespace EventShareBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class UsuarioTblController : ControllerBase
    {
        EventShareContext context = new EventShareContext();

        UsuarioTblRepositorio repositorio = new UsuarioTblRepositorio();

        [EnableCors]
        [HttpGet]
        public async Task<ActionResult<List<UsuarioTbl>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [EnableCors]
        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioTbl>> Get(int id)
        {
            UsuarioTbl usuario = await repositorio.Get(id);
            

            if (usuario == null)
            {
                return  NotFound();
            }

            return usuario;
        }
        [EnableCors]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UsuarioTbl>> Post(UsuarioTbl usuario)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            if(!usuario.UsuarioEmail.Contains('@') || !usuario.UsuarioEmail.Contains('.')){
                return BadRequest();
            }

            if(usuario.UsuarioSenha.Length < 8){
                return BadRequest();
            }

            try
            {
                await repositorio.Post(usuario);
                return usuario;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [EnableCors]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioTbl>> Put(int id, UsuarioTbl usuario)
        {
            try
            {
                return await repositorio.Put(id, usuario);   
            }
            catch (System.Exception)
            {
                var usuarioAlterado = await repositorio.Get(id);
                if(usuarioAlterado == null)
                {
                    return NotFound();

                }else{
                    
                    throw;
                      
                }
            }
        }

        [EnableCors]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioTbl>> Delete(int id)
        {
            UsuarioTbl usuarioDeletado = await repositorio.Delete(id);

            if(usuarioDeletado == null){
                return NotFound();
            }
            
            return usuarioDeletado;
        }
    }
}