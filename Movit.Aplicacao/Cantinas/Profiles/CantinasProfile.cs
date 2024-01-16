using AutoMapper;
using Movit.DataTransfer.Cantinas.Request;
using Movit.DataTransfer.Cantinas.Response;
using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios.Filtros;
using Movit.Dominio.Cantinas.Servicos.Comandos;

namespace Movit.Aplicacao.Cantinas.Profiles
{
    public class CantinasProfile : Profile
    {
        public CantinasProfile()
        {
            CreateMap<Cantina, CantinaResponse>();
            CreateMap<CantinaListarRequest, CantinaListarFiltro>();
            CreateMap<CantinaRequest, CantinaComando>();
        }
    }
}