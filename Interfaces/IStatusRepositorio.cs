using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackend_master.Interfaces
{
    public interface IStatusRepositorio
    {
    Task<List<EventoStatusTbl>> Get();

    Task<EventoStatusTbl> Get(string statusNome);

    Task<EventoStatusTbl> Post(EventoStatusTbl status);

    Task<EventoStatusTbl> Alterar(EventoStatusTbl status);

    Task<EventoStatusTbl> Delete(EventoStatusTbl statusRetornado);    
    }
}