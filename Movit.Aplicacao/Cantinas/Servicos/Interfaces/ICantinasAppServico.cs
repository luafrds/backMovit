using Movit.DataTransfer.Cantinas.Request;
using Movit.DataTransfer.Cantinas.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Cantinas.Servicos.Interfaces
{
    public interface ICantinasAppServico
    {
        Task<CantinaResponse> RecuperarAsync(int id);
        Task<PaginacaoConsulta<CantinaResponse>> ListarAsync(CantinaListarRequest request);
        Task<CantinaResponse> EditarAsync(int id, CantinaRequest request);
        Task ExcluirAsync(int id);
    }
}