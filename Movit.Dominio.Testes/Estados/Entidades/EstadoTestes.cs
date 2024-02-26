using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Estados.Entidades;
using Movit.Dominio.Excecoes;
using Xunit;

namespace Movit.Dominio.Testes.Estados.Entidades
{
    public class EstadoTestes
    {
        private readonly Estado sut;

        public EstadoTestes()
        {
            sut = Builder<Estado>.CreateNew().Build();
        }

        public class SetDescricaoMetodo : EstadoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("            ")]

            public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string descricao)
            {
                sut.Invoking(x => x.SetDescricao(descricao)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dada_DescricaoComMaisDe150Caracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetDescricao(new string('*', 151))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_DescricaoValido_Espero_PropriedadesPreenchidas()
            {
                string descricao = "Descricao Teste";
                sut.SetDescricao(descricao);
                sut.Descricao.Should().NotBeNullOrWhiteSpace(descricao);
                sut.Descricao.Should().Be(descricao);
            }
        }

        public class SetSiglaMetodo : EstadoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]

            public void Dada_SiglaNula_Espero_AtributoObrigatorioExcecao(string sigla)
            {
                sut.Invoking(x => x.SetSigla(sigla)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dada_SiglaDiferenteDe2Caracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetSigla(new String('*', 3))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dada_SiglaValida_Espero_PropriedaPreenchida()
            {
                string sigla = "ES";
                sut.SetSigla(sigla);
                sut.Sigla.Length.Should().Be(2);
                sut.Sigla.Should().NotBeNull();
                sut.Sigla.Should().Be(sigla);
            }
        }
    }
}