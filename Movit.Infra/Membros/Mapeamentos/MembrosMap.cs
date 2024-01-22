using FluentNHibernate.Mapping;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Enumeradores;

namespace Movit.Infra.Membros.Mapeamentos
{
    public class MembrosMap: ClassMap<Membro>
    {
        public MembrosMap()
        {
            Schema("movit");
            Table("membro");
            Id(x => x.Id, "id");
            Map(x => x.NomeCompleto, "nomecompleto");
            Map(x => x.Email, "email");
            Map(x => x.DataNascimento, "datanascimento");
            Map(x => x.SituacaoMembro, "situacaomembro").CustomType<SituacaoMembroEnum>();
            References(p => p.Usuario).Column("idusuario").NotFound.Ignore();
        }  
        
    }
}