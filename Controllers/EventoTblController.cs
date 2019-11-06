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
        [EnableCors]
        [AllowAnonymous]
        [HttpGet ("busca/{nome}")]
        public async Task<ActionResult<List<EventoTbl>>> GetKey (string nome) {
            List<EventoTbl> listaRetornada = await repositorio.BuscarPalavraChave (nome);
            return listaRetornada;
        }
        [EnableCors]
        [AllowAnonymous]
        [HttpGet ("categoria/{categoria}")]
        public async Task<List<EventoTbl>> GetCategoria (string categoria) {
            List<EventoTbl> listaRetornada = await repositorio.BuscarPorCategoria (categoria);
            return listaRetornada;
        }
        [EnableCors]
        [Authorize(Roles = "Administrador")]
        [HttpGet ("status/(status)")]
        public async Task<List<EventoTbl>> GetStatus (string status){
            List<EventoTbl> listaRetornada = await repositorio.BuscarPorStatus(status);
            return listaRetornada;
        }
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