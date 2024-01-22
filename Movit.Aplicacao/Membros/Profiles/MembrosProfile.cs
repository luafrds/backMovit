using AutoMapper;
using Movit.DataTransfer.Membros.Request;
using Movit.DataTransfer.Membros.Response;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Repositorios.Filtros;
using Movit.Dominio.Membros.Servicos.Comandos;

namespace Movit.Aplicacao.Membros.Profiles
{
    public class MembrosProfile : Profile
    {
        public MembrosProfile()
        {
            CreateMap<Membro, MembroResponse>();
            CreateMap<MembroListarRequest, MembroListarFiltro>();
            CreateMap<MembroRequest, MembroComando>();
        }
    } 
}