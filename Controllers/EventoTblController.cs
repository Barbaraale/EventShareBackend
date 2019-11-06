using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PROJETO.Models;
using PROJETO.Repositories;

namespace PROJETO.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    [Produces ("application/json")]
    public class EventoTblController : ControllerBase {
        EventoTblRepositorio repositorio = new EventoTblRepositorio ();

        /// <summary>
        /// Método para listar todos os eventos existentes
        /// </summary>
        /// <returns>Retorna lista de eventos</returns>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<EventoTbl>>> Get () {
            List<EventoTbl> listaE = await repositorio.ListarEventos ();

            foreach (var evento in listaE) {
                evento.EventoCategoria.EventoTbl = null;
                evento.EventoEspaco.EventoTbl = null;
                evento.EventoStatus.EventoTbl = null;
                evento.CriadorUsuario.EventoTblCriadorUsuario = null;
                evento.ResponsavelUsuario.EventoTblResponsavelUsuario = null;
            }

            return listaE;
        }

        /// <summary>
        /// Método para buscar evento pelo nome
        /// </summary>
        /// <returns>Retorna o evento</returns>
        /// <param name="nomeEvento"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet ("{nomeEvento}")]
        public async Task<ActionResult<EventoTbl>> Get (string nomeEvento) {
            EventoTbl eventoRetornado = await repositorio.BuscarPorNome (nomeEvento);

            if (eventoRetornado == null) {
                return NotFound ();
            }

            return eventoRetornado;
        }

        /// <summary>
        /// Método para listar eventos por uma palavra chave
        /// </summary>
        /// <returns>Retorna a lista de eventos</returns>
        /// <param name="nome"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet ("busca/{nome}")]
        public async Task<ActionResult<List<EventoTbl>>> GetKey (string nome) {
            List<EventoTbl> listaRetornada = await repositorio.BuscarPalavraChave (nome);
            return listaRetornada;
        }

        /// <summary>
        /// Método para filtrar os eventos de acordo com sua categoria
        /// </summary>
        /// <returns>Retorna a lista de eventos</returns>
        /// <param name="categoria"></param>
        [EnableCors]
        [AllowAnonymous]
        [HttpGet ("categoria/{categoria}")]
        public async Task<List<EventoTbl>> GetCategoria (string categoria) {
            List<EventoTbl> listaRetornada = await repositorio.BuscarPorCategoria (categoria);
            return listaRetornada;
        }

        /// <summary>
        /// Método para filtrar eventos pelo status, restrito somente ao administrador
        /// </summary>
        /// <returns>Retorna a lista de eventos</returns>
        /// <param name="status"></param>
        [EnableCors]
        [Authorize(Roles = "Administrador")]
        [HttpGet ("status/(status)")]
        public async Task<List<EventoTbl>> GetStatus (string status){
            List<EventoTbl> listaRetornada = await repositorio.BuscarPorStatus(status);
            return listaRetornada;
        }

        /// <summary>
        /// Método para cadastrar um novo evento
        /// </summary>
        /// <returns>Retorna o evento criado</returns>
        /// <param name="evento"></param>
        [EnableCors]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<EventoTbl>> Post (EventoTbl evento) {
            try {
                return await repositorio.Post (evento);
            } catch (System.Exception) {
                throw;
            }
        }

        /// <summary>
        /// Método para atualizar informaçoes de um evento previamente cadastrado
        /// </summary>
        /// <returns>Retorna o evento relacionado ao ID</returns>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        [EnableCors]
        [Authorize]
        [HttpPut ("{id}")]
        public async Task<ActionResult<EventoTbl>> Put (int id, EventoTbl evento) {
            try {
                return await repositorio.Put (id, evento);
            } catch (System.Exception) {
                var eventoRetornado = await repositorio.BuscarPorId (id);
                if (eventoRetornado == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }
        }

        /// <summary>
        /// Método para deletar um evento existente
        /// </summary>
        /// <returns>Retorna o evento deletado</returns>
        /// <param name="id"></param>
        [EnableCors]
        [Authorize]
        [HttpDelete ("{id}")]
        public async Task<ActionResult<EventoTbl>> Delete (int id) {
            try {
                return await repositorio.DeletarEvento (id);
            } catch (System.Exception) {
                var eventoRetornado = await repositorio.BuscarPorId (id);
                if (eventoRetornado == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }
        }
    }
}