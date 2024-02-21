using FizzWare.NBuilder;
using FluentAssertions;
using Movit.Dominio.Excecoes;
using Movit.Dominio.Membros.Entidades;
using Movit.Dominio.Membros.Enumeradores;
using Movit.Dominio.Usuarios.Entidades;
using Xunit;

namespace Movit.Dominio.Testes.Membros.Entidades
{
    public class MembroTestes
    {
        private readonly Membro sut;
        private readonly Usuario usuarioValido;
        public MembroTestes()
        {
            sut = Builder<Membro>.CreateNew().Build();
            usuarioValido = Builder<Usuario>.CreateNew().Build();
        }

        public class SetNomeCompletoMetodo : MembroTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_NomeCompletoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string nomeCompleto)
            {
                sut.Invoking(x => x.SetNomeCompleto(nomeCompleto)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_NomeCompletoValido_Espero_PropriedadesPreenchidas()
            {
                string nomeCompleto = "Membro Teste";
                sut.SetNomeCompleto(nomeCompleto);
                sut.NomeCompleto.Should().NotBeNullOrWhiteSpace(nomeCompleto);
                sut.NomeCompleto.Should().Be(nomeCompleto);
            }

            [Fact]
            public void Dado_NomeCompletoComMenosDe4Caracteres_Espero_ExcecaoTamanhoInvalido()
            {
                string nomeCompleto = "Tes";
                Action act = () => sut.SetNomeCompleto(nomeCompleto);
                act.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_NomeCompletoComMaisDe100Caracteres_Espero_ExcecaoTamanhoInvalido()
            {
                string nomeCompleto = new string('A', 101);
                Action act = () => sut.SetNomeCompleto(nomeCompleto);
                act.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }
        }

        public class SetDataNascimentoMetodo : MembroTestes
        {
            [Fact]
            public void QuandoDataNascimento_Espero_PropriedadeSetada()
            {
                DateTime dataNascimento = new DateTime(2023, 3, 1);
                sut.SetDataNascimento(dataNascimento);
                Assert.Equal(dataNascimento, sut.DataNascimento);
            }
        }

        public class SetUsuarioMetodo : MembroTestes
        {
            [Fact]
            public void Dado_UsuarioNulo_Espero_AtributoObrigatorioExcecao()
            {
                sut.Invoking(x => x.SetUsuario(null)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_usuarioValido_EsperoPropriedadesPreenchidas()
            {
                sut.SetUsuario(usuarioValido);
                sut.Usuario.Should().Be(usuarioValido);
            }
        }

        public class SetSituacaoMembroMetodo : MembroTestes
        {
            [Fact]
            public void Dado_SituacaoMembro_Espero_PropriedadeSetada()
            {
                sut.SetSituacaoMembro(SituacaoMembroEnum.Ativo);
                sut.SituacaoMembro.Should().Be(SituacaoMembroEnum.Ativo);
            }
        }

        public class SetEmailMetodo : MembroTestes
        {
            [Fact]
            public void Dado_EmailValido_Espero_PropriedadesPreenchidas()
            {
                string email = "test@gmail.com";
                sut.SetEmail(email);
                sut.Email.Should().NotBeNullOrWhiteSpace(email);
                sut.Email.Should().Be(email);
            }

            [Theory]
            [InlineData("invalidemail")]
            [InlineData("missingat.com")]
            public void Dado_EmailInvalido_Espero_ExcecaoAtributoInvalido(string email)
            {
                Action act = () => sut.SetEmail(email);
                act.Should().Throw<AtributoInvalidoExcecao>();
            }
        }
    }
}