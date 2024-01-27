using AutoMapper;
using Movit.DataTransfer.Cidades.Request;
using Movit.DataTransfer.Cidades.Response;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios.Filtros;
using Movit.Dominio.Cidades.Servicos.Comandos;

namespace Movit.Aplicacao.Cidades.Profiles
{
    public class CidadesProfile: Profile
    {
        public CidadesProfile()
        {
            CreateMap<Cidade, CidadeResponse>();
            CreateMap<CidadeListarRequest, CidadeListarFiltro>();
            CreateMap<CidadeRequest, CidadeComando>();
        }
    }
}