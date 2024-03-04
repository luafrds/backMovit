using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Cantinas.Repositorios;
using Movit.Dominio.Cantinas.Servicos;
using Movit.Dominio.Cantinas.Servicos.Comandos;
using Movit.Dominio.Excecoes;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Cantinas.Servicos
{
    public class CantinasServicoTestes
    {
        private readonly CantinasServico sut;
        private readonly ICantinasRepositorio cantinasRepositorio;
        private readonly Cantina cantinaValida;
        private readonly CantinaComando comando;

        public CantinasServicoTestes()
        {
            cantinaValida = Builder<Cantina>.CreateNew().Build();
            cantinasRepositorio = Substitute.For<ICantinasRepositorio>();
            comando = Builder<CantinaComando>.CreateNew().With(x => x.NomeComida, "Teste Nome comida").Build();

            sut = new CantinasServico(cantinasRepositorio);
        }

        public class ValidarAsyncMetodo : CantinasServicoTestes
        {
            [Fact]
            public void Dado_CantinaNaoEncontrada_Espero_RegraDeNegocioExcecao()
            {
                cantinasRepositorio.RecuperarAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();

            }

            [Fact]
            public async void Dado_CantinaEncontrado_Espero_CantinaValida()
            {
                cantinasRepositorio.RecuperarAsync(2).Returns(cantinaValida);
                Cantina resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(cantinaValida);
            }
        }

        public class InserirAsyncMetodo : CantinasServicoTestes
        {
            [Fact]
            public async Task Dado_CantinaValido_Espero_CantinaInserida()
            {
                Cantina resultado = await sut.InserirAsync(comando);
                cantinasRepositorio.InserirAsync(resultado).Returns(cantinaValida);

                resultado.Should().BeOfType<Cantina>();
                resultado.NomeComida.Should().Be(comando.NomeComida);
                resultado.DataCantina.Should().Be(comando.DataCantina);
                resultado.Quantidade.Should().Be(comando.Quantidade);
                resultado.Valor.Should().Be(comando.Valor);
            }
        }

        public class EditarAsyncMetodo : CantinasServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_CantinaAtualizada()
            {
                cantinasRepositorio.Recuperar(1).Returns(cantinaValida);

                sut.ValidarAsync(1).Returns(cantinaValida);
                Cantina resultado = await sut.EditarAsync(comando);
                await cantinasRepositorio.Received(1).EditarAsync(resultado);
                resultado.NomeComida.Should().Be(comando.NomeComida);
                resultado.DataCantina.Should().Be(comando.DataCantina);
                resultado.Valor.Should().Be(comando.Valor);
                resultado.Quantidade.Should().Be(comando.Quantidade);
            }
        }
    }
}