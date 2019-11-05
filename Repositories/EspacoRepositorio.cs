using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class EspacoRepositorio : IEspacoRepositorio
    {
        EventShareContext context = new EventShareContext();

        public async Task<EventoEspacoTbl> Alterar(EventoEspacoTbl espaco)
        {
            context.Entry(espaco).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return espaco;
        }

        public Task<EventoEspacoTbl> Delete(EventoEspacoTbl EspacoRetornada)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<EventoEspacoTbl>> Get()
        {
            List<EventoEspacoTbl> listaDeEspaco = await context.EventoEspacoTbl.ToListAsync();
           return listaDeEspaco;
        }

        public async Task<EventoEspacoTbl> Get(int id)
        {
            return await context.EventoEspacoTbl.FindAsync(id);
        }

        public Task<EventoEspacoTbl> Post(EventoEspacoTbl espaco)
        {
            throw new System.NotImplementedException();
        }
    }
}