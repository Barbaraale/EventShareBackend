using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class StatusRepositorio : IStatusRepositorio
    {
        EventShareContext context = new EventShareContext();
        public Task<EventoStatusTbl> Alterar(EventoStatusTbl status)
        {
            throw new System.NotImplementedException();
        }

        public Task<EventoStatusTbl> Delete(EventoStatusTbl statusRetornado)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<EventoStatusTbl>> Get()
        {
            return await context.EventoStatusTbl.ToListAsync();
        }

        public Task<EventoStatusTbl> Get(string statusNome)
        {
            throw new System.NotImplementedException();
        }

        public Task<EventoStatusTbl> Post(EventoStatusTbl status)
        {
            throw new System.NotImplementedException();
        }
    }
}