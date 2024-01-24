using FluentNHibernate.Mapping;
using Movit.Dominio.Estados.Entidades;

namespace Movit.Infra.Estados.Mapeamentos
{
    public class EstadosMap : ClassMap<Estado>
    {
        public EstadosMap()
        {
            Schema("movit");
            Table("estado");
            Id(x => x.Id, "id");
            Map(x => x.Descricao, "descricao");
            Map(x => x.Sigla, "sigla");
        }
           
    }
}