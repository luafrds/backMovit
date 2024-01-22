using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios;
using Movit.Dominio.Membros.Repositorios.Filtros;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Membros.Repositorios
{
    public class MembrosRepositorio : GenericoRepositorio<Membro>, IMembrosRepositorio
    {
        public MembrosRepositorio(ISession session) : base(session){}

        public async Task<IQueryable<Membro>> FiltrarAsync(MembroListarFiltro filtro)
        {
            IQueryable<Membro> query = await QueryAsync();

            if (!string.IsNullOrWhiteSpace(filtro.NomeCompleto))
            {
                query = query.Where(d => d.NomeCompleto.Contains(filtro.NomeCompleto));
            }

            return query;
        }

        // ???????

        public async Task<Membro> RecuperaUsuarioPorEmailAsync(string email)
        {
            Membro membro = await session.QueryOver<Membro>()
                                            .Where(u => u.Email == email)
                                            .SingleOrDefaultAsync();
            return membro;
        }
    }
}