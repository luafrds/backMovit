using FluentNHibernate.Mapping;
using Movit.Dominio.Cidades.Entidades;

namespace Movit.Infra.Cidades.Mapeamentos
{
    public class CidadesMap: ClassMap<Cidade>
    {
        public CidadesMap()
        {
            Schema("movit");
            Table("cidade");
            Id(x => x.Id, "id");
            Map(x => x.Descricao, "descricao");
            References(p => p.Estado).Column("idestado").NotFound.Ignore();
        }
    }

}