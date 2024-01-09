using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios;
using Movit.Infra.Genericos;
using NHibernate;

namespace Movit.Infra.Cantinas.Repositorios
{
    public class CantinasRepositorio: GenericoRepositorio<Cantina>, ICantinasRepositorio
    {
        public CantinasRepositorio(ISession session) : base(session) {}
    }
}