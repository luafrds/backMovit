using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Servicos.Comandos;

namespace Movit.Dominio.Membros.Servicos.Interfaces
{
    public interface IMembrosServico
    {
        Task<Membro> ValidarAsync(int id);
        Task<Membro> InserirAsync(MembroComando comando);
        Task<Membro> EditarAsync(MembroComando comando);
    }
}