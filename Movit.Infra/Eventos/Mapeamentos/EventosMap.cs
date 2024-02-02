using FluentNHibernate.Mapping;
using Movit.Dominio.Eventos.Entidades;

namespace Movit.Infra.Eventos.Mapeamentos
{
    public class EventosMap : ClassMap<Evento>
    {
        public EventosMap()
        {
            Schema("movit");
            Table("evento");
            Id(x => x.Id, "id");
            Map(x => x.Titulo, "titulo");
            Map(x => x.DataEvento, "dataevento");
            Map(x => x.Cep, "cep");
            Map(x => x.Logradouro, "logradouro");
            Map(x => x.Numero, "numero");
            Map(x => x.Complemento, "complemento");
            
            References(p => p.Cidade).Column("idcidade").NotFound.Ignore();
        } 
    }
}