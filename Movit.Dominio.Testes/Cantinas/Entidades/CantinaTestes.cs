using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Cantinas.Entidades;
using Movit.Dominio.Excecoes;
using Xunit;

namespace Movit.Dominio.Testes.Cantinas.Entidades
{
    public class CantinaTestes
    {
        private readonly Cantina sut;

        public CantinaTestes()
        {
            sut = Builder<Cantina>.CreateNew().Build();
        }

        public class SetNomeComidaMetodo : CantinaTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dado_NomeComidaNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string nomeComida)
            {
                sut.Invoking(x => x.SetNomeComida(nomeComida)).Should().Throw<RegraDeNegocioExcecao>();
            }

            [Fact]
            public void Dado_NomeComidaValido_Espero_PropriedadesPreenchidas()
            {
                string nomeComida = "Cantina Teste";
                sut.SetNomeComida(nomeComida);
                sut.NomeComida.Should().NotBeNullOrWhiteSpace(nomeComida);
                sut.NomeComida.Should().Be(nomeComida);
            }
        }

        public class SetDataCantinaMetodo : CantinaTestes
        {
            [Fact]
            public void Quando_DataCantina_ForIgualAoMinValue_Espero_AtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetDataCantina(DateTime.MinValue)).Should().Throw<AtributoInvalidoExcecao>();
            }
        }

        public class SetValorMetodo : CantinaTestes
        {
            [Theory]
            [InlineData(0)]
            [InlineData(-1)]
            public void Dado_Valor_MenorOuIgualAZero_Espero_Exceção(decimal valor)
            {
                sut.Invoking(x => x.SetValor(valor)).Should().Throw<RegraDeNegocioExcecao>();
            }

            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetValor(10.39m);
                sut.Valor.Should().BeGreaterThan(0);
                sut.Valor.Should().Be(10.39m);
            }
        }

        public class SetQuantidadeMetodo : CantinaTestes
        {
            [Theory]
            [InlineData(-1)]
            public void Dado_QuantidadeMenorQueZero__Espero_Excecao(int quantidade)
            {
                sut.Invoking(x => x.SetQuantidade(quantidade)).Should().Throw<RegraDeNegocioExcecao>();
            }

            [Fact]
            public void Dado_QuantidadeValido_Espero_PropriedadesPreenchidas()
            {
                int quantidade = 10;
                sut.SetQuantidade(quantidade);
                sut.Quantidade.Should().BeGreaterThan(-1);
                sut.Quantidade.Should().Be(10);
            }
        }
    }
}