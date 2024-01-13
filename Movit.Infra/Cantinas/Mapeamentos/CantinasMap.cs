using FluentNHibernate.Mapping;
using Movit.Dominio.Cantinas.Entidades;

namespace Movit.Infra.Cantinas.Mapeamentos
{
    public class CantinasMap : ClassMap<Cantina>
    {
        public CantinasMap()
        {
            Id(x => x.Id, "id");
            Map(x => x.NomeComida, "nomecomida");
            Map(x => x.DataCantina, "datacantina");
            Map(x => x.Valor, "valor");
            Map(x => x.Quantidade, "quantidade");
        }
    }
}