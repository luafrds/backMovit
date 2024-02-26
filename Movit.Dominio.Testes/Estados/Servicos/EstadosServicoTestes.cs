using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Estados.Repositorios;
using Movit.Dominio.Estados.Servicos;
using Movit.Dominio.Estados.Servicos.Comandos;
using Movit.Dominio.Excecoes;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Estados.Servicos
{
    public class EstadosServicoTestes
    {
        private readonly EstadosServico sut;
        private readonly IEstadosRepositorio estadosRepositorio;
        private readonly Estado estadoValido;
        private readonly EstadoComando comando;

        public EstadosServicoTestes()
        {
            estadoValido = Builder<Estado>.CreateNew().Build();
            estadosRepositorio = Substitute.For<IEstadosRepositorio>();
            comando = Builder<EstadoComando>.CreateNew()
            .With(x => x.Descricao, "Espirito Santo")
            .With(x => x.Sigla, "ES").Build();

            sut = new EstadosServico(estadosRepositorio);
        }

        public class ValidarAsyncMetodo : EstadosServicoTestes
        {
            [Fact]
            public void Dado_EstadoNaoEncontrada_Espero_RegraDeNegocioExcecao()
            {
                estadosRepositorio.RecuperarAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }

            [Fact]
            public async void Dado_EstadoEncontrado_Espero_EstadoValido()
            {
                estadosRepositorio.RecuperarAsync(2).Returns(estadoValido);
                Estado resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(estadoValido);
            }
        }

        public class InserirAsyncMetodo : EstadosServicoTestes
        {
            [Fact]
            public async Task Dado_EstadoValido_Espero_EstadoInserido()
            {
                Estado resultado = await sut.InserirAsync(comando);
                estadosRepositorio.InserirAsync(resultado).Returns(estadoValido);

                resultado.Should().BeOfType<Estado>();
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Sigla.Should().Be(comando.Sigla);
            }
        }

            public class EditarAsyncMetodo : EstadosServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_EstadoAtualizado()
            {
                estadosRepositorio.Recuperar(1).Returns(estadoValido);

                sut.ValidarAsync(1).Returns(estadoValido);
                Estado resultado = await sut.EditarAsync(comando);
                await estadosRepositorio.Received(1).EditarAsync(resultado);
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Sigla.Should().Be(comando.Sigla);
            }
        }
    }
}