using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackEnd.Interfaces
{
    public interface IUsuarioTblRepositorio
    {
        Task<List<UsuarioTbl>> Get();

        Task<UsuarioTbl> Get(int id);

        Task<UsuarioTbl> Post(UsuarioTbl usuario);

        Task<UsuarioTbl> Put(UsuarioTbl usuario);

        Task<UsuarioTbl> Delete(int id);
    }
}