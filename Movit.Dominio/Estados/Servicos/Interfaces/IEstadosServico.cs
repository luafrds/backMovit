using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Servicos.Comandos;

namespace Movit.Dominio.Estados.Servicos.Interfaces
{
    public interface IEstadosServico
    {
        Task<Estado> ValidarAsync(int id);
        Task<Estado> InserirAsync (EstadoComando comando);
        Task<Estado> EditarAsync (EstadoComando comando);
    }
}