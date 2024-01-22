using Movit.DataTransfer.Membros.Request;
using Movit.DataTransfer.Membros.Response;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Membros.Servicos.Interfaces
{
    public interface IMembrosAppServico
    {
        Task<MembroResponse> RecuperarAsync(int id);
        Task<PaginacaoConsulta<MembroResponse>> ListarAsync(MembroListarRequest request);
        Task<MembroResponse> EditarAsync(int id, MembroRequest request);
        Task ExcluirAsync(int id);
        Task<MembroResponse> InserirAsync(MembroRequest request);
    }
}