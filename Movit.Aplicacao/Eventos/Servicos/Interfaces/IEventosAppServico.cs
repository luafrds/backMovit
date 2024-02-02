using Movit.DataTransfer.Eventos.Request;
using Movit.DataTransfer.Eventos.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Eventos.Servicos.Interfaces
{
    public interface IEventosAppServico
    {
        Task<EventoResponse> RecuperarAsync(int id);
        Task<PaginacaoConsulta<EventoResponse>> ListarAsync(EventoListarRequest request);
        Task<EventoResponse> EditarAsync(int id, EventoRequest request);
        Task ExcluirAsync(int id);
        Task<EventoResponse> InserirAsync(EventoRequest request);
    }
}