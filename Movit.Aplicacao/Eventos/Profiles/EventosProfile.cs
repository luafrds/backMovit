using AutoMapper;
using Movit.DataTransfer.Eventos.Request;
using Movit.DataTransfer.Eventos.Response;
using Movit.Dominio.Eventos.Entidades;
using Movit.Dominio.Eventos.Repositorios.Filtros;
using Movit.Dominio.Eventos.Servicos.Comandos;

namespace Movit.Aplicacao.Eventos.Profiles
{
    public class EventosProfile: Profile
    {
        public EventosProfile()
        {
            CreateMap<Evento, EventoResponse>();
            CreateMap<EventoListarRequest, EventoListarFiltro>();
            CreateMap<EventoRequest, EventoComando>();
        }
    }
}