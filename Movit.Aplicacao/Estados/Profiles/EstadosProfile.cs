using AutoMapper;
using Movit.DataTransfer.Estados.Request;
using Movit.DataTransfer.Estados.Response;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios.Filtros;
using Movit.Dominio.Estados.Servicos.Comandos;

namespace Movit.Aplicacao.Estados.Profiles
{
    public class EstadosProfile : Profile
    {
        public EstadosProfile()
        {
            CreateMap<Estado, EstadoResponse>();
            CreateMap<EstadoListarRequest, EstadoListarFiltro>();
            CreateMap<EstadoRequest, EstadoComando>();
        }
    }
}