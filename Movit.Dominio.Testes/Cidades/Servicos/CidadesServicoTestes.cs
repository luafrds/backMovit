using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cidades.Entidades;
using Movit.Dominio.Cidades.Repositorios;
using Movit.Dominio.Cidades.Servicos;
using Movit.Dominio.Cidades.Servicos.Comandos;
using Movit.Dominio.Estados.Servicos.Interfaces;
using Movit.Dominio.Excecoes;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Movit.Dominio.Testes.Cidades.Servicos
{
    public class CidadesServicoTestes
    {
        private readonly CidadesServico sut;
        private readonly ICidadesRepositorio cidadesRepositorio;
        private readonly IEstadosServico estadosServico;
        private readonly Cidade cidadeValida;
        private readonly CidadeComando comando;

        public CidadesServicoTestes()
        {
            cidadeValida = Builder<Cidade>.CreateNew().Build();
            cidadesRepositorio = Substitute.For<ICidadesRepositorio>();
            estadosServico = Substitute.For<IEstadosServico>();
            comando = Builder<CidadeComando>.CreateNew().With(x => x.Descricao, "teste Cidade").Build();

            sut = new CidadesServico(cidadesRepositorio, estadosServico);
        }

        public class ValidarAsyncMetodo : CidadesServicoTestes
        {
            [Fact]
            public void Dado_CidadeNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                cidadesRepositorio.RecuperarAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }

            [Fact]
            public async void Dado_CidadeEncontrado_Espero_CidadeValida()
            {
                cidadesRepositorio.RecuperarAsync(2).Returns(cidadeValida);
                Cidade resultado = await sut.ValidarAsync(2);
                resultado.Should().BeSameAs(cidadeValida);
            }
        }

        public class InserirAsyncMetodo : CidadesServicoTestes
        {
            [Fact]
            public async Task Dado_CidadeValida_Espero_CidadeInserida()
            {
                Cidade resultado = await sut.InserirAsync(comando);
                cidadesRepositorio.InserirAsync(resultado).Returns(cidadeValida);

                resultado.Should().BeOfType<Cidade>();
                resultado.Descricao.Should().Be(comando.Descricao);
            }
        }

            public class EditarAsyncMetodo : CidadesServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_CidadeAtualizado()
            {
                cidadesRepositorio.Recuperar(1).Returns(cidadeValida);

                sut.ValidarAsync(1).Returns(cidadeValida);
                Cidade resultado = await sut.EditarAsync(comando);
                await cidadesRepositorio.Received(1).EditarAsync(resultado);
                resultado.Descricao.Should().Be(comando.Descricao);
            }
        }
    }
}