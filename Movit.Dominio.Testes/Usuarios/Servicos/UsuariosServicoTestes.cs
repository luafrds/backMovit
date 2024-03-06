using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Usuarios.Entidades;
using Movit.Dominio.Usuarios.Repositorios;
using Movit.Dominio.Usuarios.Servicos;
using Movit.Dominio.Usuarios.Servicos.Comandos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Usuarios.Servicos
{
    public class UsuariosServicoTestes
    {
        private readonly UsuariosServico sut;
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly Usuario usuarioValido;
        private readonly UsuarioComando comando;
        
        public UsuariosServicoTestes()
        {
            usuarioValido = Builder<Usuario>.CreateNew().Build();
            usuariosRepositorio = Substitute.For<IUsuariosRepositorio>();
            comando = Builder<UsuarioComando>.CreateNew()
            .With(x=> x.Email, "teste@gmail.com")
            .With(x=> x.Senha, "Senha@1").Build();

            sut = new UsuariosServico(usuariosRepositorio);
        }

        public class ValidarAsyncMetodo : UsuariosServicoTestes
        {
            [Fact]
            public void Dado_UsuarioNaoEncontrada_Espero_RegraDeNegocioExcecao()
            {
                usuariosRepositorio.RecuperarAsync(1).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(1)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }

            [Fact]
            public async void Dado_UsuarioEncontrado_Espero_UsuarioValido()
            {
                usuariosRepositorio.RecuperarAsync(2).Returns(usuarioValido);
                Usuario resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(usuarioValido);
            }
        }

        public class InserirAsyncMetodo : UsuariosServicoTestes
        {
            [Fact]
            public async Task Dado_UsuarioValido_Espero_UsuarioInserido()
            {
                Usuario resultado = await sut.InserirAsync(comando);
                usuariosRepositorio.InserirAsync(resultado).Returns(usuarioValido);

                resultado.Should().BeOfType<Usuario>();
                resultado.Email.Should().Be(comando.Email);
                resultado.Senha.Should().Be(comando.Senha);
            }
        }

        public class EditarAsyncMetodo : UsuariosServicoTestes
        {
            [Fact]
            public async Task Quando_UsuarioChamado_Espero_UsuarioAtualizado()
            {
                usuariosRepositorio.Recuperar(1).Returns(usuarioValido);

                sut.ValidarAsync(1).Returns(usuarioValido);
                Usuario resultado = await sut.EditarAsync(comando);
                await usuariosRepositorio.Received(1).EditarAsync(resultado);
                resultado.Email.Should().Be(comando.Email);
                resultado.Senha.Should().Be(comando.Senha);
            }
        }
    }
}