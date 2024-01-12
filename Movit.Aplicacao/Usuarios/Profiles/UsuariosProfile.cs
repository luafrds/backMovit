using AutoMapper;
using Movit.DataTransfer.Autenticacoes.Response;
using Movit.DataTransfer.Usuarios.Request;
using Movit.DataTransfer.Usuarios.Response;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios.Filtros;
using Movit.Dominio.Usuarios.Servicos.Comandos;

namespace Movit.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, CadastroResponse>();
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<UsuarioListarRequest, UsuarioListarFiltro>();
            CreateMap<UsuarioRequest, UsuarioComando>();
        }
    }
}