using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Servicos.Comandos;

namespace Movit.Dominio.Cidades.Servicos.Interfaces
{
    public interface ICidadesServico
    {
        Task<Cidade> ValidarAsync(int id);
        Task<Cidade> InserirAsync(CidadeComando comando);
        Task<Cidade> EditarAsync(CidadeComando comando);
    }
}