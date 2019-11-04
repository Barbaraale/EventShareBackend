using System.Collections.Generic;
using System.Threading.Tasks;
using EventShareBackEnd.Interfaces;
using Microsoft.EntityFrameworkCore;
using PROJETO.Models;

namespace EventShareBackEnd.Repositories
{
    public class UsuarioTblRepositorio : IUsuarioTblRepositorio
    {
        EventShareContext context = new EventShareContext();

        public async Task<List<UsuarioTbl>> Get()
        {
            List<UsuarioTbl> listaU = await context.UsuarioTbl.Include(t => t.UsuarioTipo).ToListAsync();

            foreach (var usuario in listaU)
            {
                usuario.EventoTblCriadorUsuario = null;
                usuario.EventoTblResponsavelUsuario = null;
                usuario.UsuarioTipo.UsuarioTbl = null;
            }

            return listaU;
        }

        public async Task<UsuarioTbl> Get(int id)
        {
            return await context.UsuarioTbl.FindAsync(id);
        }

        public async Task<UsuarioTbl> Post(UsuarioTbl usuario)
        {
            UsuarioTbl usuarioCadastrado = usuario;
            usuarioCadastrado.UsuarioNome = usuario.UsuarioNome.ToLower();

            await context.UsuarioTbl.AddAsync(usuarioCadastrado);
            await context.SaveChangesAsync();
            return usuarioCadastrado;
        }

        public async Task<UsuarioTbl> Put(int id, UsuarioTbl usuario)
        {
            UsuarioTbl usuarioModificado = await context.UsuarioTbl.FindAsync(id);

            usuarioModificado.UsuarioNome = usuario.UsuarioNome;
            usuarioModificado.UsuarioEmail = usuario.UsuarioEmail;
            usuarioModificado.UsuarioComunidade = usuario.UsuarioComunidade;
            usuarioModificado.UsuarioSenha = usuario.UsuarioSenha;

            context.Entry(usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return usuarioModificado;
        }

        public async Task<UsuarioTbl> Delete(int id)
        {
            UsuarioTbl usuario = await context.UsuarioTbl.FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            context.UsuarioTbl.Remove(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }
    }
}