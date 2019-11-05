using System.Collections.Generic;
using System.Threading.Tasks;
using PROJETO.Models;

namespace EventShareBackend_master.Interfaces
{
    public interface IEspacoRepositorio
    {
    Task<List<EventoEspacoTbl>> Get();

    Task<EventoEspacoTbl> Get(int id);

    Task<EventoEspacoTbl> Post(EventoEspacoTbl espaco);

    Task<EventoEspacoTbl> Alterar(EventoEspacoTbl espaco);

    Task<EventoEspacoTbl> Delete(EventoEspacoTbl EspacoRetornada);    
    }
}