using AutoMapper;
using Movit.Dominio.Util;

namespace Movit.Aplicacao.Paginacao;

public class PaginacaoConsultasProfile : Profile
{
    public PaginacaoConsultasProfile()
    {
        CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
    }
}
