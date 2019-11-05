using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackend_master.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackend_master.Repositories
{
    public class UsuarioTipoRepositorio : IUsuarioTipoRepositorio
    {
        
        EventShareContext context = new EventShareContext();
        public async Task<UsuarioTipoTbl> Delete(int id)
        {
            UsuarioTipoTbl tipoRetornado = await context.UsuarioTipoTbl.FindAsync(id);
            context.UsuarioTipoTbl.Remove(tipoRetornado);
            await context.SaveChangesAsync();
            return tipoRetornado;
        }

        public async Task<List<UsuarioTipoTbl>> Get()
        {
            return await context.UsuarioTipoTbl.ToListAsync();
        }

        public async Task<UsuarioTipoTbl> Get(int id)
        {
            return await context.UsuarioTipoTbl.FindAsync(id);
        }

        public async Task<UsuarioTipoTbl> Post(UsuarioTipoTbl usuarioTipoTbl)
        {
            await context.UsuarioTipoTbl.AddAsync(usuarioTipoTbl);
            await context.SaveChangesAsync();
            return usuarioTipoTbl;
        }

        public async Task<UsuarioTipoTbl> Put(int id, UsuarioTipoTbl usuarioTipoTbl)
        {
            var tipoRetornado = await context.UsuarioTipoTbl.FindAsync(id);
            tipoRetornado.TipoNome = usuarioTipoTbl.TipoNome;
            context.UsuarioTipoTbl.Update(tipoRetornado);
            await context.SaveChangesAsync();
            return tipoRetornado;
        }
    }
    
}