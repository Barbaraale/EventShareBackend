
using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;
using tst.Repositorio;

namespace EventShareBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class UsuarioTblController : ControllerBase
    {
        EventShareContext context = new EventShareContext();

        UsuarioTblRepositorio repositorio = new UsuarioTblRepositorio();

        UploadRepositorio upload = new UploadRepositorio();

        /// <summary>
        /// Método para listar os usuário cadastrados
        /// </summary>
        /// <returns>Retorna lista de usuarios</returns>
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

        /// <summary>
        /// Método para buscar um usuario pelo ID
        /// </summary>
        /// <returns>Retorna o usuário</returns>
        /// <param name="id"></param>
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

        /// <summary>
        /// Método para criar um usuario
        /// </summary>
        /// <returns>Retorna o usuario cadastrado</returns>
        /// <param name="usuario"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UsuarioTbl>> Post([FromForm] UsuarioTbl usuario)
        {
             
            if(await repositorio.ValidaEmail(usuario)){
                return BadRequest("Esse E-mail já foi cadastrado");
            }            

            if(!usuario.UsuarioEmail.Contains('@') || !usuario.UsuarioEmail.Contains('.')){
                return BadRequest("Email inválido");
            }

            if(usuario.UsuarioSenha.Length < 8){
                return BadRequest("Senha possui menos de 8 caracteres");
            }

            try
            {
                // var arquivo = Request.Form.Files[0];
                // usuario.UsuarioImagem = upload.Upload(arquivo, "images");
                usuario.UsuarioNome = Request.Form["UsuarioNome"];
                if(usuario.UsuarioNome == null){
                    return BadRequest("Campo Nome é necessário.");
                }

                usuario.UsuarioEmail = Request.Form["UsuarioEmail"];
                if(usuario.UsuarioEmail == null){
                    return BadRequest("Campo E-mail é necessário.");
                }

                usuario.UsuarioComunidade = Request.Form["UsuarioComunidade"];

                usuario.UsuarioSenha = Request.Form["UsuarioSenha"];
                if(usuario.UsuarioSenha == null){
                    return BadRequest("Campo Senha é necessário.");
                }

                usuario.UsuarioTipoId = int.Parse(Request.Form["UsuarioTipoId"]);
                if(usuario.UsuarioTipoId == null){
                    return BadRequest("Campo do Tipo de Usuário é necessário.");
                }


                await repositorio.Post(usuario);
                return usuario;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para atualizar dados de um usuário cadastrado
        /// </summary>
        /// <returns>Retorna o usuario</returns>
        /// <param name="usuario"></param>
        [EnableCors]
        // [Authorize]
        [HttpPut]
        public async Task<ActionResult<UsuarioTbl>> Put([FromForm]UsuarioTbl usuario)
        {
            try
            {

                var arquivo = Request.Form.Files[0];
                usuario.UsuarioId = int.Parse(Request.Form["UsuarioId"]);
                usuario.UsuarioImagem = upload.Upload(arquivo, "images");
                usuario.UsuarioNome = Request.Form["UsuarioNome"];
                usuario.UsuarioEmail = Request.Form["UsuarioEmail"];
                usuario.UsuarioComunidade = Request.Form["UsuarioComunidade"];
                usuario.UsuarioSenha = Request.Form["UsuarioSenha"];
                usuario.UsuarioTipoId = int.Parse(Request.Form["UsuarioTipoId"]);

                return await repositorio.Put (usuario);   
            }
            catch (System.Exception)
            {
                var usuarioAlterado = await repositorio.Get(usuario.UsuarioId);
                if(usuarioAlterado == null)
                {
                    return NotFound();

                }else{
                    
                    throw;
                      
                }
            }
        }

        /// <summary>
        /// Método para deletar um usuário cadastrado
        /// </summary>
        /// <returns>Retorna o usuario deletado</returns>
        ///<param name="id"></param>
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