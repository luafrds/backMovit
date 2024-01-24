using Movit.DataTransfer.Estados.Request;
using Movit.DataTransfer.Estados.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Estados.Servicos.Interfaces
{
    public interface IEstadosAppServico
    {
        Task<EstadoResponse> RecuperarAsync(int id);
        Task<EstadoResponse> InserirAsync(EstadoRequest request);
        Task<PaginacaoConsulta<EstadoResponse>> ListarAsync(EstadoListarRequest request);
        Task<EstadoResponse> EditarAsync(int id, EstadoRequest request);
        Task ExcluirAsync(int id);
    }
}